using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.IO;  

namespace university.Web.AdminMetro.CCOM.DatumManage
{
    public partial class StudentSubmit : university.UI.ManagePage
    {
        public int homeworkId;//修改参数
        public StudentSubmit()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            homeworkId = 0;
            homeworkId = MyRequest.GetQueryInt("homeworkId");
            if (!Page.IsPostBack)
            {
                if (homeworkId == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                //if(GetAdminInfo_CCOM().Role_id != 3)
                //{
                //    JscriptMsg("只有学生用户才可以提交材料！", "back", "Error");
                //    return;
                //}
                ShowInfo(homeworkId);
            } 
        }

        #region 赋值操作=================================
        public void ShowInfo(int homeworkId)
        {
            Model.CCOM.Homework work_model = new BLL.CCOM.Homework().GetModel(homeworkId);
            this.type.InnerText = new BLL.CCOM.Datum_type().GetModel(work_model.DatumType_id).DatumType_name;
            Boolean isOpen = new BLL.CCOM.Teach_week().GetModel(work_model.Week_id).State;
            if(isOpen)
            {
                this.massage.InnerText = "";
                this.txtUserUpload.Enabled = true;
                this.btnUpload.Enabled = true;
                this.btnSubmit.Text = "提 交";
                this.btnSubmit.Enabled = true;
            }
            else
            {
                this.massage.InnerText = "已关闭";
                this.txtUserUpload.Enabled = false;
                this.btnUpload.Enabled = false;
                this.btnSubmit.Text = "已关闭";
                this.btnSubmit.Enabled = false;
            }
            if (work_model.DatumType_id == 1)
            {
                this.fileTR.Visible = false;
                this.logTRcontent.Visible = true;
                this.logTRproblem.Visible = true;
                this.logTRplan.Visible = true;
                this.logTRstarttime.Visible = true;
                this.logTRendtime.Visible = true;
                this.btnSubmit.Visible = true;
                Model.CCOM.Week_log log_model = new BLL.CCOM.Week_log().GetModel(" Homework_id=" + homeworkId);
                if (log_model == null)
                {
                    this.state.InnerText = "未提交";
                }
                else
                {
                    this.state.InnerText = "已提交";
                    this.time.InnerText = log_model.Submit_time.ToString("yyyy年MM月dd日 ddd HH:mm");
                    this.advice.InnerText = log_model.Advice;
                    this.txtStarttime.Value = log_model.Start_time.ToString("yyyy-MM-dd");
                    this.txtEndtime.Value = log_model.End_time.ToString("yyyy-MM-dd");
                    this.txtContent.InnerText = log_model.Work_condition;
                    this.txtProblem.InnerText = log_model.Problem;
                    this.txtPlan.InnerText = log_model.Work_plan;
                    this.btnSubmit.Text = "重新提交";
                }
            }
            else
            {
                this.fileTR.Visible = true;
                this.logTRcontent.Visible = false;
                this.logTRproblem.Visible = false;
                this.logTRplan.Visible = false;
                this.logTRstarttime.Visible = false;
                this.logTRendtime.Visible = false;
                this.btnSubmit.Visible = false;
                Model.CCOM.View_Datum model = new BLL.CCOM.View_Datum().GetModel(" Homework_id=" + homeworkId);
                if (model == null)
                {
                    this.state.InnerText = "未提交";
                }
                else
                {
                    this.state.InnerText = "已提交";
                    this.time.InnerText = model.Submit_time.ToString("yyyy年MM月dd日 ddd HH:mm");
                    this.advice.InnerText = model.Tutor_advice;
                    this.lbtnDownLoad.Text = model.File_name;
                    this.btnSubmit.Text = "重新提交";
                }
            }

        }
        #endregion

        #region 增加/编辑操作=================================
        private string DoAction()
        {
            string result = "";

            #region 上传文件
            if (this.txtUserUpload.PostedFile.FileName == "")
            {
                return "请选择上传文件";
            }
            string path = "../../../upload/file/";

            //取出所选文件的本地路径  
            string fullFileName = this.txtUserUpload.PostedFile.FileName;
            //从路径中截取出文件名  
            string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);
            //限定上传文件的格式  
            string type = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
            string saveFileName = "";
            if (type == "doc" || type == "docx" || type == "xls" || type == "xlsx" || type == "ppt" || type == "pptx" || type == "pdf" || type == "jpg" || type == "bmp" || type == "gif" || type == "png" || type == "txt" || type == "zip" || type == "rar")
            {
                //将文件保存在服务器中根目录下的files文件夹中  
                saveFileName = Server.MapPath(path) + "\\" + fileName;
                this.txtUserUpload.PostedFile.SaveAs(saveFileName);
             }
            else
            {
                return "请选择正确的文件格式";
            }  
            #endregion

            Model.CCOM.Homework work_model = new BLL.CCOM.Homework().GetModel(homeworkId);
            Model.CCOM.View_Datum model = new BLL.CCOM.View_Datum().GetModel(" Homework_id=" + homeworkId);
            try
            {
                if (model == null)          //增加一条数据
                {
                    Model.CCOM.Datum datum_model = new Model.CCOM.Datum();
                    datum_model.Homework_id = homeworkId;
                    datum_model.Submit_time = DateTime.Now;
                    datum_model.DatumType_id = work_model.DatumType_id;
                    datum_model.File_name = fileName;
                    datum_model.File_path = saveFileName;
                    datum_model.Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + GetAdminInfo_CCOM().User_id).Topic_relation_id;
                    new BLL.CCOM.Datum().Add(datum_model);
                }
                else                        //更新一条数据
                {
                    Model.CCOM.Datum datum_model = new BLL.CCOM.Datum().GetModel(model.Datum_id);
                    FileOperate.FileDel(datum_model.File_path);//删除原有文件
                    datum_model.Submit_time = DateTime.Now;
                    datum_model.File_name = fileName;
                    datum_model.File_path = saveFileName;
                    new BLL.CCOM.Datum().Update(datum_model);
                }
            }
            catch {
                result = "提交发生异常";
            }
            
            return result;
        }
        #endregion

        #region 提交周志=================================
        private string DoSubmit()
        {
            string result = "";

            Model.CCOM.Homework work_model = new BLL.CCOM.Homework().GetModel(homeworkId);
            Model.CCOM.Week_log model = new BLL.CCOM.Week_log().GetModel(" Homework_id=" + homeworkId);
            try
            {
                if (model == null)          //增加一条数据
                {
                    Model.CCOM.Week_log log_model = new Model.CCOM.Week_log();
                    log_model.Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + GetAdminInfo_CCOM().User_id).Topic_relation_id;
                    log_model.Homework_id = homeworkId;
                    log_model.Start_time = Convert.ToDateTime(this.txtStarttime.Value);
                    log_model.End_time = Convert.ToDateTime(this.txtEndtime.Value);
                    log_model.Work_condition = this.txtContent.InnerText;
                    log_model.Problem = this.txtProblem.InnerText;
                    log_model.Work_plan = this.txtPlan.InnerText;
                    log_model.Submit_time = DateTime.Now;
                    if (log_model.Start_time == null || log_model.End_time == null || log_model.Work_condition == "" || log_model.Problem == "" || log_model.Work_plan == "")
                        return "请完善所有表项";
                    new BLL.CCOM.Week_log().Add(log_model);
                }
                else                        //更新一条数据
                {
                    model.Start_time = Convert.ToDateTime(this.txtStarttime.Value);
                    model.End_time = Convert.ToDateTime(this.txtEndtime.Value);
                    model.Work_condition = this.txtContent.InnerText;
                    model.Problem = this.txtProblem.InnerText;
                    model.Work_plan = this.txtPlan.InnerText;
                    model.Submit_time = DateTime.Now;
                    if (model.Start_time == null || model.End_time == null || model.Work_condition == "" || model.Problem == "" || model.Work_plan == "")
                        return "请完善所有表项";
                    new BLL.CCOM.Week_log().Update(model);
                }
            }
            catch
            {
                result = "提交发生异常";
            }

            return result;
        }
        #endregion
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string result = DoAction();
            if (result == "")
            {
                JscriptMsg("提交成功", "", "Success");
                Response.Redirect("StudentSubmit.aspx?homeworkId=" + homeworkId + "&fun_id=" + get_fun_id("CCOM/DatumManage/WeeklyList.aspx"));
            }
            else
                JscriptMsg(result, "", "Error");

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = DoSubmit();
            if (result == "")
                JscriptMsg("提交成功！", Utils.CombUrlTxt("StudentSubmitList.aspx", "fun_id={0}", DESEncrypt.Encrypt(this.fun_id)), "Success");
            else
                JscriptMsg(result, "", "Error");

        }

        protected void lbtnDownLoad_Command(object sender, CommandEventArgs e)
        {
            Model.CCOM.View_Datum model = new BLL.CCOM.View_Datum().GetModel(" Homework_id=" + homeworkId);
            // 定义文件名    
            string fileName = this.lbtnDownLoad.Text;
            // 获取文件在服务器的地址    
            string url = model.File_path;

            // 判断传输地址是否为空    
            if (url == "")
            {
                // 提示“该文件暂不提供下载”    
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script defer>alert('该文件暂不提供下载！');</script>");
                return;
            }
            // 判断获取的是否为地址，而非文件名    
            if (url.IndexOf("\\") > -1)
            {
                // 获取文件名    
                fileName = url.Substring(url.LastIndexOf("\\") + 1);
            }
            else
            {
                // url为文件名时，直接获取文件名    
                fileName = url;
            }
            // 以字符流的方式下载文件    
            FileStream fileStream = new FileStream(@url, FileMode.Open);
            byte[] bytes = new byte[(int)fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            Response.ContentType = "application/octet-stream";

            // 通知浏览器下载   
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }  
    }
}