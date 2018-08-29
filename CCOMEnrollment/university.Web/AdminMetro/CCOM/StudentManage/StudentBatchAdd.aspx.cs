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

namespace university.Web.AdminMetro.CCOM.StudentManage
{
    public partial class StudentBatchAdd : university.UI.ManagePage
    {
        public int uoid = 0;
        public StudentBatchAdd()
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
                SetCol("姓名", 1, "", col++, excel);
                SetCol("学号/工号", 1, "", col++, excel);
                SetCol("性别", 1, "", col++, excel);
                SetCol("机构/班号", 1, "", col++, excel);
                SetCol("角色", 1, "", col++, excel);
                //SetCol("生日", 0, "", col++, excel);
                //SetCol("教师职称", 0, "", col++, excel);
                string xlsName = "用户模板";
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
                response.End();

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
            BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information model = new Model.CCOM.User_information();
          
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string checkmsg = null;
                //姓名
                string name = ds.Tables[0].Rows[i]["姓名"].ToString().Trim();
                if (!ValidDFValue(name, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，姓名" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (name != "")
                {
                    model.User_realname  = name;
                }
                //学号/工号
                string mobile = ds.Tables[0].Rows[i]["学号/工号"].ToString().Trim();
                if (!Validator.IsMobile(mobile))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，学号/工号要为整数<br/>";
                    error++;
                    continue;
                }
                if (!ValidDFValue(mobile, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，学号/工号" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (bll.GetRecordCount(" User_number='" + mobile + "'") > 0)
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，该学号/工号已被添加<br/>";
                    error++;
                    continue;
                }
                else if (mobile != "")
                {
                    model.User_number  = mobile;
                }
                //性别
                string gender = ds.Tables[0].Rows[i]["性别"].ToString().Trim();
                if (!ValidDFValue(gender, true, "男|女", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，性别" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (gender == "男")
                {
                    model.User_gender = false;
                }
                else if (gender == "女")
                {
                    model.User_gender = true;
                }
                //机构
                string angency = ds.Tables[0].Rows[i]["机构/班号"].ToString().Trim();
                if (!ValidDFValue(angency, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，所在机构/班号" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                BLL.CCOM.Agency agency_bll = new BLL.CCOM.Agency();
                Model.CCOM.Agency agency_model = new Model.CCOM.Agency();
                agency_model = agency_bll.GetModel(" Agency_name='" + angency+"'");
                if (agency_model == null)
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，所在机构/班号不存在<br/>";
                    error++;
                    continue;
                }
                model.Agency_id = agency_model.Agency_id;
                //角色
                string role = ds.Tables[0].Rows[i]["角色"].ToString().Trim();
                if (!ValidDFValue(role, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，角色<br/>";
                    error++;
                    continue;
                }
                BLL.CCOM.Role role_bll = new BLL.CCOM.Role();
                Model.CCOM.Role role_model = new Model.CCOM.Role();
                role_model=role_bll.GetModel(" Role_name='" + role + "'");
                if (role_model == null)
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，用户角色不存在<br/>";
                    error++;
                    continue;
                }
                model.Role_id = role_model.Role_id;
            
                //生日
                //string birthday = ds.Tables[0].Rows[i]["生日"].ToString().Trim();
                //if (!ValidDFValue(birthday, false, "", ref checkmsg))
                //{
                //    result += "×第" + (i + 1).ToString() + "行数据更新失败，生日" + checkmsg + "<br/>";
                //    error++;
                //    continue;
                //}
                //else if (birthday != "")
                //{
                //    if (!Validator.IsBirthday(birthday))
                //    {
                //        result += "×第" + (i + 1).ToString() + "行数据更新失败，生日格式不对<br/>";
                //        error++;
                //        continue;
                //    }
                //    model.User_birthday = Convert.ToDateTime(birthday); 
                //}
                //model.User_password = mobile;

                ////教师职称
                //string title = ds.Tables[0].Rows[i]["教师职称"].ToString().Trim();
             
                //BLL.CCOM.Title title_bll = new BLL.CCOM.Title();
                //Model.CCOM.Title title_model = new Model.CCOM.Title();
                //title_model = title_bll.GetModel(" Title_name='" + title + "'");
                //if (title_model == null)
                //{
                //    result += "×第" + (i + 1).ToString() + "行数据更新失败，该教师职称不存在<br/>";
                //    error++;
                //    continue;
                //}
                //else if (!ValidDFValue(title, true, "", ref checkmsg))
                //{
                //    result += "×第" + (i + 1).ToString() + "行数据更新失败，教师职称<br/>";
                //    error++;
                //    continue;
                //}
                model.User_password = DESEncrypt.MD5Encrypt(mobile);
                if (bll.Add(model)==0)
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                    error++;
                    continue;
                }
                else
                {

                    success++;
                    BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
                    Model.CCOM.User_information user_model = user_bll.GetModel("User_number='" + mobile + "'");
                    if (model.Role_id == 2 )//如果为指导教师，插入Tutor表
                    {
                        BLL.CCOM.Tutor tutor_bll = new BLL.CCOM.Tutor();
                        Model.CCOM.Tutor tutor_model = new Model.CCOM.Tutor();
                        tutor_model.User_id = user_model.User_id;
                        tutor_model.Title_id = 1;
                        tutor_bll.Add(tutor_model);
                    }
                    if (model.Role_id == 3)//如果为学生，插入Student表
                    {
                        BLL.CCOM.Student student_bll = new BLL.CCOM.Student();
                        Model.CCOM.Student student_model = new Model.CCOM.Student();
                        student_model.User_id = user_model.User_id;
                        student_model.Period_id = 4;
                        student_bll.Add(student_model);
                    }
                }
            }
            return result;
        }

        protected bool  ValidDFValue(string value, bool required, string check, ref string msg)
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