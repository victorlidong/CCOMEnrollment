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
    public partial class CommentPage : university.UI.ManagePage
    {
        public long UserID;//修改参数
        protected string PageTitle;
        protected string reviewTr;
        public CommentPage()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = 0;
            UserID = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("userid")));
            if (!Page.IsPostBack)
            {
                if (UserID == 0)
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
          //  Model.CCOM.View_User user_model = new BLL.CCOM.View_User().GetModel(" User_id=" + UserID);
            this.txtTeacherComment.Disabled = true;
            this.txtTeacherScore.Disabled = true;
            this.txtProblem.Disabled = true;
            this.txtReviewComment.Disabled = true;
            this.txtScore.Disabled = true;

            long Group_id = GetGroupId(UserID);
            if (Group_id == 0) return;
            var group_model = new BLL.CCOM.Reply_group().GetModel(" Group_id=" + Group_id);
            var leader_model = new BLL.CCOM.View_User().GetModel(" User_id=" + group_model.User_id);
            long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + UserID).Topic_relation_id;
            var comment_model = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + Topic_relation_id);

           // PageTitle = user_model.User_realname + "的答辩评语表";
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
                //this.txtScore.Value = comment_model.Reply_score.ToString();
                this.txtScore.Value = GetUser_CommentScore(UserID).ToString();
            }
        }
        #endregion

        private long GetGroupId(long user_id) {
            var groups = new BLL.CCOM.Reply_student().GetModelList(" User_id=" + user_id);
            foreach (var group in groups)
            {
                long group_id = group.Group_id;
                if (new BLL.CCOM.Reply_group().GetModel(group_id).Group_type == 0) {
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