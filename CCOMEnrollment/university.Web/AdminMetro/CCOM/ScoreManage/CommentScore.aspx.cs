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
    public partial class CommentScore : university.UI.ManagePage
    {
        public long UserID;//修改参数
        public long Group_id;
        protected string PageTitle;
        protected string reviewTr;
        public CommentScore()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = 0;
            Group_id = 0;
            UserID = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("userid")));
            Group_id = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("groupid")));
            if (!Page.IsPostBack)
            {
                if (UserID == 0 || Group_id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                ShowInfo();
            } 
        }

        #region 赋值操作=================================
        public void ShowInfo()
        {
           // Model.CCOM.View_User user_model = new BLL.CCOM.View_User().GetModel(" User_id=" + UserID);
            var group_model = new BLL.CCOM.Reply_group().GetModel(" Group_id=" + Group_id);
            var leader_model = new BLL.CCOM.View_User().GetModel(" User_id=" + group_model.User_id);
            long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + UserID).Topic_relation_id;
            var comment_model = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + Topic_relation_id);

           // PageTitle = user_model.User_realname + "的答辩评语表";
            this.txtTeacherComment.Disabled = true;
            this.txtTeacherScore.Disabled = true;
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
                var mark_table_model = new BLL.CCOM.View_Mark_table().GetModel(" Teacher_id=" + rc.User_id + " and Student_id=" + UserID);
                score = "--";
                if (mark_table_model != null)
                {
                    score = mark_table_model.Score.ToString();
                }
                reviewTr += "<tr><td class=\"firstTab\">" + u_model.User_realname + "</td><td class=\"otherTab\">" + GetTitle(u_model.User_id) + "</td><td class=\"otherTab\">成员</td><td class=\"otherTab\">" + score + "</td></tr>";
            }

            if (comment_model != null)
            {
                this.txtTeacherComment.InnerText = comment_model.Teacher_comment;
                this.txtTeacherScore.Value = comment_model.Teacher_score.ToString();
                this.txtProblem.InnerText = comment_model.problem;
                this.txtReviewComment.InnerText = comment_model.Comment_content;
                this.txtScore.Value = comment_model.Reply_score.ToString();
            }
            if (GetAdminInfo_CCOM().User_id != leader_model.User_id)
            {
                var mark_table_model = new BLL.CCOM.View_Mark_table().GetModel(" Teacher_id=" + GetAdminInfo_CCOM().User_id + "and student_id=" + UserID);
                score="";
                if (mark_table_model != null)
                {
                    score = mark_table_model.Score.ToString();
                }
                this.txtScore.Value = score;
                this.txtProblem.Disabled = true;
                this.txtReviewComment.Disabled = true;
            }
        }
        #endregion

        #region 增加/编辑操作=================================
        private string DoAction()
        {
             var group_model = new BLL.CCOM.Reply_group().GetModel(" Group_id=" + Group_id);
             //var leader_model = new BLL.CCOM.View_User().GetModel(" User_id=" + group_model.User_id);
             string score = this.txtScore.Value;
             if (GetAdminInfo_CCOM().User_id != group_model.User_id)
            {
                if (score == "")
                {
                    return "请添加给定的成绩";
                }
                int sc = int.Parse(score);
                var student_model = new BLL.CCOM.Reply_student().GetModel(" Group_id=" + Group_id + "and User_id=" + UserID);
                var comment_model = new BLL.CCOM.Reply_commission().GetModel(" Group_id=" + Group_id + "and User_id=" + GetAdminInfo_CCOM().User_id);
                var mark_model = new BLL.CCOM.Mark_table().GetModel(" Rs_id=" + student_model.Rs_id + " and Rc_id=" + comment_model.Rc_id);
                if (mark_model != null)
                {
                    mark_model.Score = sc;
                    mark_model.Mark_date = DateTime.Now;
                    if (!new BLL.CCOM.Mark_table().Update(mark_model))
                    {
                        return "更新成绩异常";
                    }
                }
                else
                {
                    Model.CCOM.Mark_table mk_model = new Model.CCOM.Mark_table();
                    mk_model.Rc_id = comment_model.Rc_id;
                    mk_model.Rs_id = student_model.Rs_id;
                    mk_model.Score = sc;
                    mk_model.Mark_date = DateTime.Now;
                    if (new BLL.CCOM.Mark_table().Add(mk_model) == 0)
                    {
                        return "添加成绩异常";
                    }

                }
               
            }
            else
            {
                string problem = this.txtProblem.InnerText;
                string comment = this.txtReviewComment.InnerText;
                if (problem == "")
                {
                    return "请添加答辩中提出的主要问题及回答的简要情况";
                }
                if (comment == "")
                {
                    return "请添加答辩委员会（小组）的评语";
                }
                if (score == "")
                {
                    return "请添加给定的成绩";
                }
                int sc = int.Parse(score);

                long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + UserID).Topic_relation_id;
                var comment_model = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + Topic_relation_id);
                if (comment_model != null)
                {
                    comment_model.problem = problem;
                    comment_model.Comment_content = comment;
                    comment_model.Reply_score = sc;
                    if (!new BLL.CCOM.Comment().Update(comment_model))
                    {
                        return "更新评语异常";
                    }
                }
                else
                {
                    Model.CCOM.Comment com_model = new Model.CCOM.Comment();
                    com_model.problem = problem;
                    com_model.Comment_content = comment;
                    com_model.Reply_score = sc;
                    com_model.Topic_relation_id = Topic_relation_id;
                    if (new BLL.CCOM.Comment().Add(com_model) == 0)
                    {
                        return "添加评语异常";
                    }
                }
            }
            

            return "";
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = DoAction();
            if (result == "")
                JscriptMsg("提交成功！", Utils.CombUrlTxt("GroupStudentList.aspx", "groupid={0}", DESEncrypt.Encrypt(this.Group_id.ToString())), "Success");
            else
                JscriptMsg(result, "", "Error");

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