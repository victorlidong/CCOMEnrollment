using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using university.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Configuration;
namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class PrintExamInfor : university.UI.ManagePage
    {
        protected int Group_id = 0;
        protected string reviewTr1;
        protected string reviewTr2;
        protected string page_title;
        public PrintExamInfor()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    Group_id = int.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("groupid")));
                    if (Group_id <= 0)
                    {
                        JscriptMsg("传输异常！", "back", "Error");
                        return;
                    }
                    //this.txtExamID.Text = Utils.ObjectToStr(Group_id);
                    bindTitleInfo();
                    //bindStudentInfo();
                }
                catch {
                    JscriptMsg("传输异常！", "back", "Error");
                    return;
                }
            }
        }

        protected void bindTitleInfo()
        {
            //Model.CCOM.Examination_arrangement exam_model = new BLL.CCOM.Examination_arrangement().GetModel(Group_id);
            //Model.CCOM.Examination_room room_model = new BLL.CCOM.Examination_room().GetModel(exam_model.Ea_room);
            //Model.CCOM.Examination_subject subject_model = new BLL.CCOM.Examination_subject().GetModel(" Ea_id='" + exam_model.Ea_id + "'");
            //string year = "";
            //if (subject_model != null)
            //{
            //    Model.CCOM.Subject s_model = new BLL.CCOM.Subject().GetModel(subject_model.Esn_id);
            //    year = new BLL.CCOM.Period().GetModel(s_model.Period_id).Period_year;
            //}
            //if (year == "") year = Utils.ObjectToStr(DateTime.Now.Year);
            //this.lbltime.Text = Convert.ToDateTime(exam_model.Ea_starttime).ToString("MM月dd日  HH:mm");
            //this.lblplace.Text = room_model.Er_building + room_model.Er_floor + "层" + room_model.Er_room;
            Model.CCOM.Reply_group rg_model = new BLL.CCOM.Reply_group().GetModel(Group_id);
            this.lbltime.Text = rg_model.Reply_time.ToString("yyyy年MM月dd日 HH:mm");
            this.lblplace.Text = rg_model.Reply_room;
            this.lbltitle.Text = rg_model.Group_name;
            if (rg_model.Group_type == 0)
            {
                page_title = "2017软件学院毕业设计答辩安排";
                this.lbltype.Text = "口头答辩";
            }
            else if (rg_model.Group_type == 1)
            {
                page_title = "2017软件学院毕业设计软件验收安排";
                this.lbltype.Text = "软件验收";
            }
            else if (rg_model.Group_type == 2)
            {
                page_title = "2017软件学院开题评审答辩安排";
                this.lbltype.Text = "开题评审";
            }

            //绑定答辩委员会
            var group_model = new BLL.CCOM.Reply_group().GetModel(" Group_id=" + Group_id);
            var leader_model = new BLL.CCOM.View_User().GetModel(" User_id=" + group_model.User_id);
            reviewTr1 = "<tr><td style=\"text-align:center\">" + leader_model.User_realname + "</td><td style=\"text-align:center\">" + leader_model.Role_name + "</td><td style=\"text-align:center\">主席</td></tr>";
            var rcs = new BLL.CCOM.Reply_commission().GetModelList(" Group_id=" + Group_id);
            foreach (var rc in rcs)
            {
                var u_model = new BLL.CCOM.View_User().GetModel(" User_id=" + rc.User_id);
                reviewTr1 += "<tr><td style=\"text-align:center\">" + u_model.User_realname + "</td><td style=\"text-align:center\">" + u_model.Role_name + "</td><td style=\"text-align:center\">成员</td></tr>";
            }
            //绑定学生
            var rss = new BLL.CCOM.Reply_student().GetModelList("Group_id=" + Group_id + " order by User_id");
            BLL.CCOM.View_Selete_Topic user_bll = new BLL.CCOM.View_Selete_Topic();
            foreach (var rs in rss)
            {
                var s_model = new BLL.CCOM.View_Selete_Topic().GetModel(" Student_id=" + rs.User_id);
                reviewTr2 += "<tr><td style=\"text-align:center\">" + s_model.Student_name + "</td><td style=\"text-align:center\">" + s_model.User_number + "</td><td style=\"text-align:center\">" + s_model.Teacher_name + "</td><td style=\"text-align:center\">" + s_model.Topic_name + "</td></tr>";
           
            }
        }
    }
}