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
    public partial class DataBatchAdd : university.UI.ManagePage
    {
        public int uoid = 0;
        public DataBatchAdd()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
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
                SetCol("学号", 1, "", col++, excel);
                SetCol("姓名", 1, "", col++, excel);
                SetCol("专业代码", 0, "男|女", col++, excel);
                SetCol("行政班", 1, "", col++, excel);
                SetCol("毕业设计题目", 1, "", col++, excel);
                SetCol("题目类型", 0, "", col++, excel);
                SetCol("题目性质", 0, "", col++, excel);
                SetCol("题目来源", 0, "", col++, excel);
                SetCol("指导教师", 1, "", col++, excel);
                SetCol("辅助指导教师", 0, "", col++, excel);
                SetCol("职称", 1, "讲师|副教授|教授|实验师|研究员", col++, excel);
                SetCol("年龄", 0, "", col++, excel);
                SetCol("成绩", 0, "", col++, excel);
                SetCol("状态", 0, "", col++, excel);
                SetCol("题目详情", 1, "", col++, excel);
                SetCol("周志情况", 0, "", col++, excel);
                SetCol("场所", 0, "", col++, excel);
                SetCol("任务书", 0, "", col++, excel);
                string xlsName = "一键导入模板";
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
            BLL.CCOM.User_information stu_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information stu_model = new Model.CCOM.User_information();
            BLL.CCOM.Topic topic_bll = new BLL.CCOM.Topic();
            Model.CCOM.Topic topic_model = new Model.CCOM.Topic();
            BLL.CCOM.Topic_relation rela_bll = new BLL.CCOM.Topic_relation();
            Model.CCOM.Topic_relation rela_model = new Model.CCOM.Topic_relation();
          
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string checkmsg = null;
                #region 添加学生信息==========================
                //学号
                string number = ds.Tables[0].Rows[i]["学号"].ToString().Trim(); 
                if (!ValidDFValue(number, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，学号" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (stu_bll.GetModel(" User_number='" + number + "'") != null) {
                    stu_model = stu_bll.GetModel(" User_number='" + number + "'");
                }
                else if (number != "")
                {
                    stu_model.User_number = number;
                }
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
                    stu_model.User_realname = name;
                }
                //性别
                //string gender = ds.Tables[0].Rows[i]["性别"].ToString().Trim();
                //if (!ValidDFValue(gender, true, "男|女", ref checkmsg))
                //{
                //    result += "×第" + (i + 1).ToString() + "行数据更新失败，性别" + checkmsg + "<br/>";
                //    error++;
                //    continue;
                //}
                //else if (gender == "男")
                //{
                //    stu_model.User_gender = false;
                //}
                //else if (gender == "女")
                //{
                //    stu_model.User_gender = true;
                //}
                //机构
                stu_model.User_gender = false;
                string angency = ds.Tables[0].Rows[i]["行政班"].ToString().Trim();
                if (!ValidDFValue(angency, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，所在班号" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                BLL.CCOM.Agency agency_bll = new BLL.CCOM.Agency();
                Model.CCOM.Agency agency_model = new Model.CCOM.Agency();
                agency_model = agency_bll.GetModel(" Agency_name='" + angency + "'");
                if (agency_model == null)
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，所在班号不存在<br/>";
                    error++;
                    continue;
                }
                stu_model.Agency_id = agency_model.Agency_id;
                stu_model.Role_id = 3;

                stu_model.User_password = DESEncrypt.MD5Encrypt(number);
                if (stu_bll.GetModel(" User_number='" + number + "'") == null)
                {
                    stu_model.User_id = stu_bll.Add(stu_model);
                    if (stu_model.User_id == 0)
                    {
                        result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                        error++;
                        continue;
                    }
                    else
                    {
                        BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
                        Model.CCOM.User_information user_model = user_bll.GetModel("User_number='" + number + "'");
                        BLL.CCOM.Student student_bll = new BLL.CCOM.Student();
                        Model.CCOM.Student student_model = new Model.CCOM.Student();
                        student_model.User_id = user_model.User_id;
                        student_model.Period_id = 4;
                        student_bll.Add(student_model);
                    }
                }
                else 
                {
                    if (!stu_bll.Update(stu_model)) {
                        result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                        error++;
                        continue;
                    }
                }
                #endregion

                #region 更新导师信息==========================
                var tea_model = new Model.CCOM.Tutor();
                //姓名
                string tea_name = ds.Tables[0].Rows[i]["指导教师"].ToString().Trim();
                if (!ValidDFValue(tea_name, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，指导教师" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (tea_name != "")
                {
                    var tea_user_model = new BLL.CCOM.User_information().GetModel(" User_realname='" + tea_name + "'");
                    if (tea_user_model == null)
                    {
                        result += "×第" + (i + 1).ToString() + "行数据更新失败，指导教师" + tea_name + "不存在<br/>";
                        error++;
                        continue;
                    }
                    tea_model = new BLL.CCOM.Tutor().GetModel(" User_id=" + tea_user_model.User_id);
                    string title_name = ds.Tables[0].Rows[i]["职称"].ToString().Trim();
                    if (!ValidDFValue(title_name, true, "", ref checkmsg))
                    {
                        result += "×第" + (i + 1).ToString() + "行数据更新失败，职称" + checkmsg + "<br/>";
                        error++;
                        continue;
                    }
                    else if (title_name != "")
                    {
                        var title_model = new BLL.CCOM.Title().GetModel(" Title_name='" + title_name + "'");
                        if (title_model == null) {
                            result += "×第" + (i + 1).ToString() + "行数据更新失败，职称" + title_name + "不存在<br/>";
                            error++;
                            continue;
                        }
                        tea_model.Title_id = title_model.Title_id;
                        if (!new BLL.CCOM.Tutor().Update(tea_model)) {
                            result += "×第" + (i + 1).ToString() + "行数据更新失败，更新导师信息失败<br/>";
                            error++;
                            continue;
                        }
                    }

                }
                #endregion

                #region 导入选题信息==========================
                string topic_name = ds.Tables[0].Rows[i]["毕业设计题目"].ToString().Trim();
                if (!ValidDFValue(topic_name, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，题目名称" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (topic_name != "")
                {
                    topic_model.Topic_name = topic_name;
                }

                string Topic_nature = ds.Tables[0].Rows[i]["题目性质"].ToString().Trim();
                if (!ValidDFValue(Topic_nature, false, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，题目性质" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (Topic_nature != "")
                {
                    topic_model.Topic_nature = Topic_nature;
                }

                string Topic_source = ds.Tables[0].Rows[i]["题目来源"].ToString().Trim();
                if (!ValidDFValue(Topic_source, false, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，题目来源" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (Topic_source != "")
                {
                    topic_model.Topic_source = Topic_source;
                }

                string Topic_content = ds.Tables[0].Rows[i]["题目详情"].ToString().Trim();
                if (!ValidDFValue(Topic_content, false, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，题目详情" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (Topic_content != "")
                {
                    topic_model.Topic_content = Topic_content;
                }

                string Topic_task = ds.Tables[0].Rows[i]["任务书"].ToString().Trim();
                if (!ValidDFValue(Topic_task, false, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，任务书" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (Topic_task != "")
                {
                    topic_model.Topic_task = Topic_task;
                }

                topic_model.Selected_state = true;
                topic_model.Check_state = 1;
                topic_model.Teacher_id = tea_model.User_id;
                topic_model.Company = "软件学院";
                topic_model.Topic_id = topic_bll.Add(topic_model);
                if (topic_model.Topic_id == 0)
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                    error++;
                    continue;
                }
                #endregion

                #region 选题对应关系信息==========================
                if (rela_bll.GetModel(" Student_id=" + stu_model.User_id) != null && rela_bll.GetModel(" Student_id=" + stu_model.User_id).Accept_state != 2)

                {
                    result += "×第" + (i + 1).ToString() + "行学生选题对应关系更新异常，该学生已经在系统有选题记录！<br/>";
                    error++;
                    continue;
                }
                rela_model.Student_id = stu_model.User_id;
                rela_model.Teacher_id = tea_model.User_id;
                rela_model.Topic_id = topic_model.Topic_id;
                rela_model.Accept_state = 1;
                rela_model.Apply_time = DateTime.Now;
                rela_model.Topic_relation_id = rela_bll.Add(rela_model);
                if (rela_model.Topic_relation_id == 0)
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                    error++;
                    continue;
                }
                else
                {
                    success++;
                }
                #endregion
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