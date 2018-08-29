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

namespace university.Web.AdminMetro.CCOM.ResManage
{
    public partial class ResourceBatchAdd : university.UI.ManagePage
    {
        public int uoid = 0;
        public ResourceBatchAdd()
        {
            //this.checkFunID = true;
            //this.fun_id = MyRequest.GetQueryString("fun_id");
            //this.adminfuncition = true;

            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //BindDataItems();
            }
        }

        //动态生成Excel
        protected void prodExcel_Click(object sender, EventArgs e)
        {
            WriteXls();
        }

        public void WriteXls()
        {
            bool res = true;
            Application excel = new Application();
            try
            {
                excel.Workbooks.Add(true);
                excel.Visible = false;
                int col = 1;
                SetCol("名称", 1, "", col++, excel);
                string xlsName = "资源导入模板";
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
                string msbox = "parent.f_errorTab(\"错误提示\", \"对不起，导出出错，请重新打开重试！\");";
                Response.Write("<script type=\"text/javascript\">" + msbox + "</script>");
                Response.End();
            }
        }

        protected void SetCol(string name,int required, string check, int col, Application excel)
        {
            excel.Cells[1, col] = name;
            excel.Range[excel.Cells[1, col], excel.Cells[1, col]].Font.Bold = true;                //设置字体加粗
            if (required == 1)
                excel.Range[excel.Cells[1, col], excel.Cells[1, col]].Font.ColorIndex = 3; //红色
            else
                excel.Range[excel.Cells[1, col], excel.Cells[1, col]].Font.ColorIndex = 1;
            if (check == "")
                return;
            if (check.Split('|')[0] == "select" && check.Split('|')[1].Length > 0)
            {
                Range range = excel.Range[excel.Cells[2, col], excel.Cells[9999, col]];
                string str = check.Split('|')[1].Replace(';', ',');
                range.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Type.Missing, str, Type.Missing);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            string result = "";
            if (this.txtUserUpload.PostedFile.FileName == "")
            {
                JscriptMsg("请选择上传文件", "", "Error");
                return;
            }
            if (this.ddlResourceType.SelectedValue.Equals(""))
            {
                JscriptMsg("请选择资源类型", "", "Error");
                return;
            }
            DataSet ds = new DataSet();
            string path = "../../../upload/excel/";

            #region 解决360获取绝对路径导致出错的问题
            string AbsolutePath = this.txtUserUpload.PostedFile.FileName;
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

            this.txtUserUpload.SaveAs(filePath);
            int success = 0, error = 0;
            try
            {
                var excel = new Common.ExcelToData();
                ds = excel.GetExcelData(filePath);
                result = ImportDataItem(ds, ref success, ref error);
            }
            catch (Exception ex)
            {
                LOGGER.Debug(ex.Message, ex);
                result = "导入发生异常情况，请联系客服";
            }
            string divinfo = "<div class=\"alert alert-block alert-info fade in\">";
            divinfo += "<button data-dismiss=\"alert\" class=\"close\" type=\"button\">×</button>";
            divinfo += "<h4 class=\"alert-heading\">导入结果</h4>";
            divinfo += "<p>";
            if (success != ds.Tables[0].DefaultView.Count)
                divinfo += "部分导入成功!<br>";
            else
                divinfo += "全部导入成功!<br>";
            divinfo += "*共有" + ds.Tables[0].DefaultView.Count + "条数据，成功" + success + "条，失败" + error + "条；<br/>";
            if (result != "")
                divinfo += "详细信息如下:<br><font color='red'>" + result;
            divinfo += "</font></p>";
            divinfo += "</div>";
            this.lblError.Text = divinfo;
            File.Delete(filePath);

        }

        protected string ImportDataItem(DataSet ds, ref int success, ref int error)//基础数据
        {
            string result = "";
            BLL.CCOM.Province bll_Province = new BLL.CCOM.Province();
            Model.CCOM.Province model_Province = new Model.CCOM.Province();
            BLL.CCOM.Politics bll_Politics = new BLL.CCOM.Politics();
            Model.CCOM.Politics model_Politics = new Model.CCOM.Politics();
            BLL.CCOM.Nationality bll_Nationality = new BLL.CCOM.Nationality();
            Model.CCOM.Nationality model_Nationality = new Model.CCOM.Nationality();
            BLL.CCOM.Nation bll_Nation = new BLL.CCOM.Nation();
            Model.CCOM.Nation model_Nation = new Model.CCOM.Nation();
            BLL.CCOM.Musical_instrument bll_Musical_instrument = new BLL.CCOM.Musical_instrument();
            Model.CCOM.Musical_instrument model_Musical_instrument = new Model.CCOM.Musical_instrument();
            BLL.CCOM.Degree bll_Degree = new BLL.CCOM.Degree();
            Model.CCOM.Degree model_Degree = new Model.CCOM.Degree();
            BLL.CCOM.Certificate_type bll_Certificate_type = new BLL.CCOM.Certificate_type();
            Model.CCOM.Certificate_type model_Certificate_type = new Model.CCOM.Certificate_type();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string checkmsg = null;
                string name = ds.Tables[0].Rows[i]["名称"].ToString().Trim();
                if (!ValidDFValue(name, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，名称" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                switch (this.ddlResourceType.SelectedValue) { 
                    case "1":
                        if (name != "") model_Province.Province_name = name;
                        if (bll_Province.GetModel(" Province_name='" + name + "'") != null)
                        {
                            result += "×第" + (i + 1).ToString() + "行，系统已存在该数据<br/>";
                            error++;
                            continue;
                        }
                        else if (bll_Province.Add(model_Province) == 0)
                        {
                            result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                            error++;
                            continue;
                        }
                        else success++;
                        break;
                    case "2":
                        if (name != "") model_Politics.Politics_name = name;
                        if (bll_Politics.GetModel(" Politics_name='" + name + "'") != null)
                        {
                            result += "×第" + (i + 1).ToString() + "行，系统已存在该数据<br/>";
                            error++;
                            continue;
                        }
                        else if (bll_Politics.Add(model_Politics) == 0)
                        {
                            result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                            error++;
                            continue;
                        }
                        else success++;
                        break;
                    case "3":
                        if (name != "") model_Nationality.Nationality_name = name;
                        if (bll_Nationality.GetModel(" Nationality_name='" + name + "'") != null)
                        {
                            result += "×第" + (i + 1).ToString() + "行，系统已存在该数据<br/>";
                            error++;
                            continue;
                        }
                        else if (bll_Nationality.Add(model_Nationality) == 0)
                        {
                            result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                            error++;
                            continue;
                        }
                        else success++;
                        break;
                    case "4":
                        if (name != "") model_Nation.Nation_name = name;
                        if (bll_Nation.GetModel(" Nation_name='" + name + "'") != null)
                        {
                            result += "×第" + (i + 1).ToString() + "行，系统已存在该数据<br/>";
                            error++;
                            continue;
                        }
                        else if (bll_Nation.Add(model_Nation) == 0)
                        {
                            result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                            error++;
                            continue;
                        }
                        else success++;
                        break;
                    case "5":
                        if (name != "") model_Musical_instrument.Mi_name = name;
                        if (bll_Musical_instrument.GetModel(" Mi_name='" + name + "'") != null)
                        {
                            result += "×第" + (i + 1).ToString() + "行，系统已存在该数据<br/>";
                            error++;
                            continue;
                        }
                        else if (bll_Musical_instrument.Add(model_Musical_instrument) == 0)
                        {
                            result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                            error++;
                            continue;
                        }
                        else success++;
                        break;
                    case "6":
                        if (name != "") model_Degree.Degree_name = name;
                        if (bll_Degree.GetModel(" Degree_name='" + name + "'") != null)
                        {
                            result += "×第" + (i + 1).ToString() + "行，系统已存在该数据<br/>";
                            error++;
                            continue;
                        }
                        else if (bll_Degree.Add(model_Degree) == 0)
                        {
                            result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                            error++;
                            continue;
                        }
                        else success++;
                        break;
                    case "7":
                        if (name != "") model_Certificate_type.Ct_name = name;
                        if (bll_Certificate_type.GetModel(" Ct_name='" + name + "'") != null)
                        {
                            result += "×第" + (i + 1).ToString() + "行，系统已存在该数据<br/>";
                            error++;
                            continue;
                        }
                        else if (bll_Certificate_type.Add(model_Certificate_type) == 0)
                        {
                            result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                            error++;
                            continue;
                        }
                        else success++;
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        protected bool ValidDFValue(string value, bool required, string check, ref string msg)
        {
            value = value.Trim();
            if (Tools.CheckParams(value))
            {
                msg = "存在非法字符";
                return false;
            }
            if (value == "" && required)
            {
                msg = "必填字段不能为空";
                return false;
            }
            if (check.Split('|')[0] == "select" && value != "")
            {
                string[] options = check.Split('|')[1].Split(',');
                if (!options.ToList().Contains(value))
                {
                    msg = "信息不在给定范围中";
                    return false;
                }
            }
            msg = "";
            return true;
        }

    }
}