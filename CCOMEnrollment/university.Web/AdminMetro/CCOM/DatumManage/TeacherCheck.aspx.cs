using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using university.Web.AdminMetro.OnlineView;
using System.IO;  

namespace university.Web.AdminMetro.CCOM.DatumManage
{
    public partial class TeacherCheck : university.UI.ManagePage
    {
        public int CheckId;//修改参数
        public int Homework_id;
        public TeacherCheck()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Homework_id = 0;
            CheckId = 0;
            CheckId = MyRequest.GetQueryInt("CheckId");
            Homework_id = MyRequest.GetQueryInt("Homework_id");
            if (!Page.IsPostBack)
            {
                if (CheckId == 0 || Homework_id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                //if(GetAdminInfo_CCOM().Role_id != 3)
                //{
                //    JscriptMsg("只有学生用户才可以提交材料！", "back", "Error");
                //    return;
                //}
                ShowInfo();
            } 
        }

        #region 赋值操作=================================
        public void ShowInfo()
        {
            Model.CCOM.Homework work_model = new BLL.CCOM.Homework().GetModel(Homework_id);
            this.type.InnerText = new BLL.CCOM.Datum_type().GetModel(work_model.DatumType_id).DatumType_name;
            if (work_model.DatumType_id == 1)//周志
            {
                this.fileTR.Visible = false;
                this.logTRcontent.Visible = true;
                this.logTRproblem.Visible = true;
                this.logTRplan.Visible = true;
                this.logTRstarttime.Visible = true;
                this.logTRendtime.Visible = true;

                Model.CCOM.Week_log week_model = new BLL.CCOM.Week_log().GetModel(CheckId);
                Model.CCOM.Topic_relation rela_model = new BLL.CCOM.Topic_relation().GetModel(week_model.Topic_relation_id);
                this.name.InnerText = new BLL.CCOM.User_information().GetModel(rela_model.Student_id).User_realname;
                this.time.InnerText = week_model.Submit_time.ToString("yyyy年MM月dd日 ddd HH:mm");
                this.txtAdvice.InnerText = week_model.Advice;
                this.txtStarttime.InnerText = week_model.Start_time.ToString("yyyy-MM-dd");
                this.txtEndtime.InnerText = week_model.End_time.ToString("yyyy-MM-dd");
                this.lbContent.InnerText = week_model.Work_condition;
                this.lbProblem.InnerText = week_model.Problem;
                this.lbPlan.InnerText = week_model.Work_plan;
            }
            else                            //其他
            {
                this.fileTR.Visible = true;
                this.logTRcontent.Visible = false;
                this.logTRproblem.Visible = false;
                this.logTRplan.Visible = false;
                this.logTRstarttime.Visible = false;
                this.logTRendtime.Visible = false;

                Model.CCOM.Datum datum_model = new BLL.CCOM.Datum().GetModel(CheckId);
                Model.CCOM.Topic_relation rela_model = new BLL.CCOM.Topic_relation().GetModel(datum_model.Topic_relation_id);
                this.name.InnerText = new BLL.CCOM.User_information().GetModel(rela_model.Student_id).User_realname;
                this.time.InnerText = datum_model.Submit_time.ToString("yyyy年MM月dd日 ddd HH:mm");
                this.txtAdvice.InnerText = datum_model.Tutor_advice;

                //this.file.InnerHtml = "<p><a href='" + 
                //                "/home/news/Attach.aspx?id=" + DESEncrypt.Encrypt(datum_model.Datum_id.ToString()) + 
                //                ("&address=") + (HttpUtility.UrlEncode(datum_model.File_path)) + 
                //                ("&name=") + (HttpUtility.UrlEncode(datum_model.File_name)) + 
                //                ("' target='_blank' >") + 
                //                (datum_model.File_name) + 
                //                ("</a>") + 
                //                (OnlineViewHelper.GetOnlineViewWrapLink(datum_model.File_path, datum_model.File_name)) + ("</p>");
                this.lbtnDownLoad.Text = datum_model.File_name;
            }
        }
        #endregion

        #region 指导教师评价=================================
        private string DoSubmit()
        {
            string result = "";

            Model.CCOM.Homework work_model = new BLL.CCOM.Homework().GetModel(Homework_id);
            this.type.InnerText = new BLL.CCOM.Datum_type().GetModel(work_model.DatumType_id).DatumType_name;
            if (work_model.DatumType_id == 1)//周志
            {
                Model.CCOM.Week_log week_model = new BLL.CCOM.Week_log().GetModel(CheckId);
                week_model.Advice = this.txtAdvice.InnerText;
                if(!new BLL.CCOM.Week_log().Update(week_model)){
                    result = "评价发生异常";
                }
            }
            else                            //其他
            {
                Model.CCOM.Datum datum_model = new BLL.CCOM.Datum().GetModel(CheckId);
                datum_model.Tutor_advice = this.txtAdvice.InnerText;
                if (!new BLL.CCOM.Datum().Update(datum_model))
                {
                    result = "评价发生异常";
                }
            }
            
            return result;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = DoSubmit();
            if (result == "")
            {
                JscriptMsg("评价成功！", Utils.CombUrlTxt("TeacherCheckList.aspx", "fun_id={0}", DESEncrypt.Encrypt(this.fun_id)), "Success");
            }
            else
                JscriptMsg(result, "", "Error");

        }

        protected void lbtnDownLoad_Command(object sender, CommandEventArgs e)
        {
            Model.CCOM.View_Datum model = new BLL.CCOM.View_Datum().GetModel(" Homework_id=" + Homework_id);
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