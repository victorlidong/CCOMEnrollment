using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.IO;

namespace university.Web.AdminMetro.CCOM.ScoreManage
{
    public partial class TeacherComment : university.UI.ManagePage
    {
        public long relationID;//修改参数
        public long studentID;
        protected string PageTitle;
        protected string reviewTr;
        public TeacherComment()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            relationID = 0;
            studentID = 0;
            if (GetAdminInfo_CCOM().Role_id == 3)
            {
                studentID = GetAdminInfo_CCOM().User_id;
                this.btnSubmit.Visible = false;
            }
            else
                studentID = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("studentID")));
            string ht = "";
            Model.CCOM.Topic_relation model = new Model.CCOM.Topic_relation();
            model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + studentID + "and Accept_state=1");
            if (model != null)
                relationID = model.Topic_relation_id;
            if (!Page.IsPostBack)
            {
                if (studentID == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                //if(GetAdminInfo_CCOM().Role_id != 3)
                //{
                //    JscriptMsg("只有学生用户才可以提交材料！", "back", "Error");
                //    return;
                //}

                if (model == null)
                {
                    ht = " <div class=\"content\" align=\"center\"><h3>该学生尚无选题<h3><table class=\"table table-striped table-bordered dataTable\"></table></div>";
                    this.print_div.InnerHtml = ht;
                }
                else
                {
                    ShowInfo();
                }
            } 
        }

        #region 赋值操作=================================
        public void ShowInfo()
        {
            //Model.CCOM.View_User user_model = new BLL.CCOM.View_User().GetModel(" User_id=" + studentID);
            //PageTitle = user_model.User_realname + "的答辩评语表";
            var comment_model = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + relationID);
            this.txtProblem.Disabled = true;
            this.txtReviewComment.Disabled = true;
            this.txtScore.Disabled = true;
            long Group_id = GetGroupId(studentID);
            if (Group_id != 0)
            {
                var group_model = new BLL.CCOM.Reply_group().GetModel(" Group_id=" + Group_id);
                var leader_model = new BLL.CCOM.View_User().GetModel(" User_id=" + group_model.User_id);
                string score = "--";
                if (comment_model != null)
                {
                    score = comment_model.Reply_score.ToString();
                }
                reviewTr = "<tr><td class=\"firstTab\">" + leader_model.User_realname + "</td><td class=\"otherTab\">" + GetTitle(leader_model.User_id) + "</td><td class=\"otherTab\">主席</td><td class=\"otherTab\">" + score + "</td></tr>";
                var rcs = new BLL.CCOM.Reply_commission().GetModelList(" Group_id=" + Group_id);
                foreach (var rc in rcs)
                {
                    var u_model = new BLL.CCOM.View_User().GetModel(" User_id=" + rc.User_id);
                    var mark_table_model = new BLL.CCOM.View_Mark_table().GetModel(" Teacher_id=" + rc.User_id + " and Student_id=" + studentID);
                    score = "--";
                    if (mark_table_model != null)
                    {
                        score = mark_table_model.Score.ToString();
                    }
                    reviewTr += "<tr><td class=\"firstTab\">" + u_model.User_realname + "</td><td class=\"otherTab\">" + GetTitle(u_model.User_id) + "</td><td class=\"otherTab\">成员</td><td class=\"otherTab\">" + score + "</td></tr>";
                }
            }
          //  long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + UserID).Topic_relation_id;
            
            if (comment_model != null)
            {
                this.txtTeacherComment.InnerText = comment_model.Teacher_comment;
                this.txtTeacherScore.Value = comment_model.Teacher_score.ToString();
                this.txtProblem.InnerText = comment_model.problem;
                this.txtReviewComment.InnerText = comment_model.Comment_content;
                this.txtScore.Value = comment_model.Reply_score.ToString();
            }
        }
        #endregion

        #region 增加/编辑操作=================================
        private string DoAction()
        {
            string comment = this.txtTeacherComment.InnerText;
            string score = this.txtTeacherScore.Value;
            if (comment == "")
            {
                return "请添加指导教师的评语";
            }
            if (score == "")
            {
                return "请添加指导教师的评分";
            }
            int sc = int.Parse(score);

           // long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + studentID).Topic_relation_id;
            var comment_model = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + relationID);
            if (comment_model != null)
            {
                comment_model.Teacher_comment = comment;
                comment_model.Teacher_score = sc;
                if (!new BLL.CCOM.Comment().Update(comment_model)) {
                    return "更新评语异常";
                }
            }
            else
            {
                Model.CCOM.Comment com_model = new Model.CCOM.Comment();
                com_model.Teacher_comment = comment;
                com_model.Teacher_score = sc;
                com_model.Topic_relation_id = relationID;
                if (new BLL.CCOM.Comment().Add(com_model) == 0)
                {
                    return "添加评语异常";
                }
            }

            return "";
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = DoAction();
            if (result == "")
                JscriptMsg("提交成功！", "../ExamArrange/MyStudentList.aspx?fun_id=" + get_fun_id("CCOM/ExamArrange/MyStudentList.aspx"), "Success");
            else
                JscriptMsg(result, "", "Error");

        }

        private long GetGroupId(long user_id)
        {
            var groups = new BLL.CCOM.Reply_student().GetModelList(" User_id=" + user_id);
            foreach (var group in groups)
            {
                long group_id = group.Group_id;
                if (new BLL.CCOM.Reply_group().GetModel(group_id).Group_type == 0)
                {
                    return group_id;
                }
            }
            return 0;
        }

        private string GetTitle(long user_id)
        {
            var tutor_model = new BLL.CCOM.Tutor().GetModel(" User_id=" + user_id);
            if (tutor_model != null)
            {
                if (tutor_model.Title_id != null)
                {
                    return new BLL.CCOM.Title().GetModel((int)tutor_model.Title_id).Title_name;
                }
                else
                {
                    return "--";
                }
            }
            else
            {
                return "--";
            }
        }
    }
}