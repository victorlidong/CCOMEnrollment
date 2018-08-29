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
    public partial class ImportFractionalline : university.UI.ManagePage
    {
        protected int period_id = 0;
        public ImportFractionalline()
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
        //动态生成Excel
        protected void prodExcel_Click(object sender, EventArgs e)
        {
            bool res = true;
            string xlsName = "批量导入分数线模板";
            Application excel = new Application();
            try
            {
                excel.Workbooks.Add(true);
                excel.Visible = false;

                excel.Cells[1, 1] = "省份";
                excel.Cells[1, 2] = "文科一本线";
                excel.Cells[1, 3] = "理科一本线";
                excel.Cells[1, 4] = "文科二本线";
                excel.Cells[1, 5] = "理科二本线";
                excel.Cells[1, 6] = "文科三本线";
                excel.Cells[1, 7] = "理科三本线";
                excel.Cells[1, 8] = "艺术类最低控制线（文科）";
                excel.Cells[1, 9] = "艺术类最低控制线（理科）";
                excel.Cells[1, 10] = "文科满分";
                excel.Cells[1, 11] = "理科满分";

                Range noticerange = excel.Range[excel.Cells[1, 12], excel.Cells[11, 15]];
                noticerange.MergeCells = true;
                noticerange.WrapText = true;
                noticerange.Font.Size = 15;
                noticerange.set_Value(Type.Missing, "提示：请勿修改默认字段名称以及顺序，个别字段需从下拉列表中选取填写内容，给您带来的不便敬请见谅！");
                noticerange.Font.ColorIndex = 3;
                noticerange.Font.Bold = true;

                //获取标题行的单元格
                Range range = excel.Range[excel.Cells[1, 1], excel.Cells[1, 11]];
                range.Font.Bold = true;                //设置字体加粗
                range.Font.ColorIndex = 0;                //设置字体颜色
                //设置颜色背景
                //range.Interior.ColorIndex = 15;

                //给必填项添加样式
                range = excel.Range[excel.Cells[1, 1], excel.Cells[1, 1]];                //获取标题行的单元格
                range.Font.ColorIndex = 3;                //设置字体颜色
                range = excel.Range[excel.Cells[1, 10], excel.Cells[1, 11]];                //获取标题行的单元格
                range.Font.ColorIndex = 3;                //设置字体颜色

                //-----做省份的下拉列表-----//
                range = excel.Range[excel.Cells[2, 1], excel.Cells[9999, 1]];
                string listStr = "";
                BLL.CCOM.Province bllPro = new BLL.CCOM.Province();
                DataSet dsPro = bllPro.GetList("");

                for (int i = 0; i < dsPro.Tables["ds"].Rows.Count; i++)
                {
                    listStr += dsPro.Tables["ds"].Rows[i]["Province_name"].ToString().Trim() + ",";
                }
                listStr = listStr.Substring(0, listStr.Length - 1);

                range.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Type.Missing, listStr, Type.Missing);
                xlsName = xlsName + ".xlsx";
                string serverUrl = Server.MapPath("~/");//serverUrl + xlsName

                //excel.ActiveWorkbook.SaveAs(serverUrl + xlsName,Excel.XlFileFormat.xlExcel8);
                excel.ActiveWorkbook.SaveCopyAs(serverUrl + xlsName);

                FileStream myFileStream = new FileStream(serverUrl + xlsName, FileMode.Open);

                long fileSize = myFileStream.Length;
                byte[] buffer = new byte[(int)fileSize];
                myFileStream.Read(buffer, 0, (int)fileSize);
                myFileStream.Close();


                HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.Charset = "UTF-8";
                response.ContentType = "application/vnd.ms-excel";

                response.AppendHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(xlsName, Encoding.UTF8).ToString()));
                response.BinaryWrite(buffer);
                response.Flush();
                response.Close();

                File.Delete(serverUrl + xlsName);
            }
            catch (Exception ex)
            {
                LOGGER.Debug(ex.Message, ex);
                res = false;
            }
            finally
            {
                excel.DisplayAlerts = false;
                excel.ActiveWorkbook.Application.DisplayAlerts = false;
                excel.Quit();
                excel = null;//这一句是非常重要的，否则Excel对象不能从内存中退出
            }
            if (!res)
            {
                string msbox = "parent.f_errorTab(\"错误提示\", \"对不起，导出出错，请重新尝试！\");";
                Response.Write("<script type=\"text/javascript\">" + msbox + "</script>");
                Response.End();
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
                BLL.CCOM.Province PBll = new BLL.CCOM.Province();

                var excel = new Common.ExcelToData();
                ds = excel.GetExcelData(filePath);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string _ProName = ds.Tables[0].Rows[i]["省份"].ToString().Trim();

                    var p_model = PBll.GetModel("Province_name='" + _ProName + "'");
                    if (p_model == null)
                    {
                        result += "×第" + (i + 1).ToString() + "行添加失败，该省份‘" + ds.Tables[0].Rows[i]["省份"].ToString().Trim() + "’不存在，请按照模板格式下拉选择；<br/>";
                        error++;
                        continue;
                    }

                    var model = new Model.CCOM.Fractional_line();
                    var _model = new Model.CCOM.Fractional_line();

                    int Pro_id = p_model.Province_id;
                    model = new BLL.CCOM.Fractional_line().GetModel(" Period_id = " + period_id + " and Fl_Province=" + Pro_id);

                    _model.WenKeYiBen = ((ds.Tables[0].Rows[i]["文科一本线"].ToString().Trim() == "") ? 0 : (Convert.ToDecimal(ds.Tables[0].Rows[i]["文科一本线"].ToString().Trim())));
                    _model.LiKeYiBen = (ds.Tables[0].Rows[i]["理科一本线"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["理科一本线"].ToString().Trim()));
                    _model.WenKeErBen = (ds.Tables[0].Rows[i]["文科二本线"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["文科二本线"].ToString().Trim()));
                    _model.LiKeErBen = (ds.Tables[0].Rows[i]["理科二本线"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["理科二本线"].ToString().Trim()));
                    _model.WenKeSanBen = (ds.Tables[0].Rows[i]["文科三本线"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["文科三本线"].ToString().Trim()));
                    _model.LiKeSanBen = (ds.Tables[0].Rows[i]["理科三本线"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["理科三本线"].ToString().Trim()));
                    _model.WenKeYiShuXian = (ds.Tables[0].Rows[i]["艺术类最低控制线（文科）"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["艺术类最低控制线（文科）"].ToString().Trim()));
                    _model.LiKeYiShuXian = (ds.Tables[0].Rows[i]["艺术类最低控制线（理科）"].ToString().Trim() == "" ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[i]["艺术类最低控制线（理科）"].ToString().Trim()));
                    if (ds.Tables[0].Rows[i]["文科满分"].ToString().Trim() == "")
                    {
                        result += "×第" + (i + 1).ToString() + "行添加失败，文科满分不能为空；<br/>";
                        error++;
                        continue;                    
                    }
                    _model.WenKeZongFen = Convert.ToDecimal(ds.Tables[0].Rows[i]["文科满分"].ToString().Trim());
                    if (ds.Tables[0].Rows[i]["理科满分"].ToString().Trim() == "")
                    {
                        result += "×第" + (i + 1).ToString() + "行添加失败，理科满分不能为空；<br/>";
                        error++;
                        continue;
                    }
                    _model.LiKeZongFen = Convert.ToDecimal(ds.Tables[0].Rows[i]["理科满分"].ToString().Trim());

                    bool isOK = false;
                    if (model != null)
                    {
                        _model.Fl_id = model.Fl_id;
                        _model.Period_id = model.Period_id;
                        _model.Fl_Province = model.Fl_Province;
                        _model.Fl_addtime = model.Fl_addtime;
                        isOK = DoUpdate(_model);
                    }
                    else
                    {
                        _model.Fl_Province = Pro_id;
                        _model.Period_id = period_id;
                        _model.Fl_addtime = DateTime.Now;
                        isOK = DoAdd(_model);
                    }

                    if (isOK)
                    {
                        success++;
                    }
                    else
                    {
                        result += "×第" + (i + 1).ToString() + "行‘" + ds.Tables[0].Rows[i]["省份"].ToString().Trim() + "’信息异常，导入失败。<br/>";
                        error++;
                    }
                }
                new Calculation().calculateFenShuXian();
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

        protected bool DoAdd(Model.CCOM.Fractional_line Fl)
        {
            try
            {
                BLL.CCOM.Fractional_line Bfl = new BLL.CCOM.Fractional_line();
                Bfl.Add(Fl);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        protected bool DoUpdate(Model.CCOM.Fractional_line Fl)
        {
            try
            {
                BLL.CCOM.Fractional_line Bfl = new BLL.CCOM.Fractional_line();
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
            Response.Redirect("FractionallineList.aspx?fun_id=" + get_fun_id("CCOM/CEEManege/FractionallineList.aspx"));
        }
    }
}