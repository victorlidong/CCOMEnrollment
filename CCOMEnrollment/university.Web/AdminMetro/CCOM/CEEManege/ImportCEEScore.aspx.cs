using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using org.in2bits.MyXls;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;// For COMException 
using log4net;

namespace university.Web.AdminMetro.CCOM.CEEManege
{
    public partial class ImportCEEScore : university.UI.ManagePage
    {
        protected int period_id = 0;
        public ImportCEEScore()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var period = new BLL.CCOM.Period().GetModel("Period_state = " + DataDic.Period_state_On);
            if (period != null)
            {
                period_id = period.Period_id;
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string result = "";
            if (this.txtFraUpload.PostedFile.FileName == "")
            {
                JscriptMsg("请选择上传文件", "", "Error");
                return;
            }
            DataSet ds = new DataSet();
            string path = "/upload/excel/";

            #region 解决360获取绝对路径导致出错的问题
            string AbsolutePath = this.txtFraUpload.PostedFile.FileName;
            string[] pathList = new string[] { };

            pathList = AbsolutePath.Split('\\');
            AbsolutePath = pathList[pathList.Length - 1];
            #endregion

            string fileName = DateTime.Now.ToFileTime() + "_" + AbsolutePath;
            string FexName = fileName.Substring(fileName.LastIndexOf(".") + 1);
            if (FexName != "xls" && FexName != "xlsx")
            {
                JscriptMsg("请上传Excel文件", "", "Error");
                return;
            }

            string filePath = Server.MapPath(path + fileName);

            this.txtFraUpload.SaveAs(filePath);
            int success = 0, error = 0;
            try
            {
                var excel = new Common.ExcelToData();
                ds = excel.GetExcelData(filePath);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["考生号"].ToString().Trim() == "")
                    {
                        result += "×第" + (i + 1).ToString() + "行添加失败，考生号不能为空；<br/>";
                        error++;
                        continue;
                    }

                    var __model = new BLL.CCOM.User_property().GetModel(" UP_CCOM_number='" + ds.Tables[0].Rows[i]["考生号"].ToString().Trim() + "'");
                    if (__model == null)
                    {
                        result += "×第" + (i + 1).ToString() + "行添加失败，考生号错误；<br/>";
                        error++;
                        continue;
                    }
                    long user_id = __model.User_id;

                    string WenOrLi = ds.Tables[0].Rows[i]["文理"].ToString().Trim();
                    if (WenOrLi == "" ||( WenOrLi != "1" && WenOrLi != "2" && WenOrLi!="3"))
                    {
                        result += "×第" + (i + 1).ToString() + "行添加失败，文理格式错误或为空；<br/>";
                        error++;
                        continue;
                    }

                    var model = new Model.CCOM.Examination_CEE_score();
                    var _model = new Model.CCOM.Examination_CEE_score();
                    model = new BLL.CCOM.Examination_CEE_score().GetModel(" Period_id = " + period_id + " and User_id=" + user_id);

                    _model.CEE_type = Convert.ToInt16(ds.Tables[0].Rows[i]["文理"].ToString().Trim());
                    _model.CEE_Chinese_score = (ds.Tables[0].Rows[i]["语文"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["语文"].ToString().Trim()));
                    _model.CEE_Math_score = (ds.Tables[0].Rows[i]["数学"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["数学"].ToString().Trim()));
                    _model.CEE_English_score = (ds.Tables[0].Rows[i]["外语"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["外语"].ToString().Trim()));
                    _model.CEE_comprehensive_score = (ds.Tables[0].Rows[i]["综合"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["综合"].ToString().Trim()));
                    _model.CEE_extra_score = (ds.Tables[0].Rows[i]["附加分"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["附加分"].ToString().Trim()));
                    _model.CEE_score = _model.CEE_Chinese_score + _model.CEE_Math_score + _model.CEE_English_score + _model.CEE_comprehensive_score + _model.CEE_extra_score;

                    bool isOK = false;
                    if (model != null)
                    {
                        _model.Period_id = model.Period_id;
                        _model.CEE_id = model.CEE_id;
                        _model.CEE_status = model.CEE_status;
                        _model.User_id = model.User_id;
                        isOK = DoUpdate(_model);
                    }
                    else
                    {
                        _model.Period_id = period_id;
                        _model.User_id = user_id;
                        _model.CEE_status = false;
                        isOK = DoAdd(_model);
                    }

                    if (isOK)
                    {
                        success++;
                    }
                    else
                    {
                        result += "×第" + (i + 1).ToString() + "行‘" + ds.Tables[0].Rows[i]["考生号"].ToString().Trim() + "’信息异常，导入失败。<br/>";
                        error++;
                    }
                }
            }
            catch (Exception ex)
            {
                ILog LOGGER = LogManager.GetLogger("quanquan");
                LOGGER.Debug("导入分数线异常" + ex.Message, ex);
                result = "导入分数线异常，请联系客服";
            }

            string divinfo = "<div class=\"alert alert-block alert-info fade in\">";
            divinfo += "<button data-dismiss=\"alert\" class=\"close\" type=\"button\">×</button>";
            divinfo += "<h4 class=\"alert-heading\">导入结果</h4>";
            divinfo += "<p>";
            if (success != ds.Tables[0].DefaultView.Count)
                divinfo += "部分导入成功，您可以按照提示修改Excel并重新提交<br>";
            else
                divinfo += "全部导入成功，请您进入下一步确认导入信息<br>";
            divinfo += "*共有" + ds.Tables[0].DefaultView.Count + "条数据，成功" + success + "条，失败" + error + "条；<br/>";
            if (result != "")
                divinfo += "详细信息如下:<br><font color='red'>" + result;
            divinfo += "</font></p>";
            divinfo += "</div>";
            this.lblError.Text = divinfo;

            //显示下一步
            if (success > 0)
            {
                this.btnSubmit.Visible = true;
            }
            //删除上传的文件
            File.Delete(filePath);
        }

        protected bool DoAdd(Model.CCOM.Examination_CEE_score Fl)
        {
            try
            {
                BLL.CCOM.Examination_CEE_score Bfl = new BLL.CCOM.Examination_CEE_score();
                Bfl.Add(Fl);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        protected bool DoUpdate(Model.CCOM.Examination_CEE_score Fl)
        {
            try
            {
                BLL.CCOM.Examination_CEE_score Bfl = new BLL.CCOM.Examination_CEE_score();
                Bfl.Update(Fl);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect("CEEScoreList.aspx?fun_id=" + get_fun_id("CCOM/CEEManege/CEEScoreList.aspx"));
        }
    }
}