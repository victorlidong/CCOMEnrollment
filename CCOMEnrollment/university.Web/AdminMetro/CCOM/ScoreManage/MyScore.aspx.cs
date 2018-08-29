using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ScoreManage
{
    public partial class MyScore : university.UI.ManagePage
    {
        protected long _id = 0;
        public MyScore()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.CCOM.User_information model = GetAdminInfo_CCOM();
            _id = model.User_id;
            this.txtID.Text = _id.ToString();
            if (!Page.IsPostBack)
            {
                ShowScoreInfo();
                ShowInfo();
            }
        }
        #region 赋值操作=================================
        protected void ShowInfo()
        {
            int score_t=-1,score_c=-1,score_s=-1;
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information user_model = user_bll.GetModel(_id);

            if (user_model == null)
            {
                InnerRedirect(MyEnums.RediirectErrorEnum.ParameterError);
            }

            //真实姓名
            if (user_model.User_realname == null)
            {
                txt_User_realname.Text = "请填写真实姓名";
            }
            else
            {
                this.txt_User_realname.Text = user_model.User_realname;
            }
            this.txt_User_number.Text = user_model.User_number;

            var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + _id);
            if (relation_model == null) return;

            var comment_model = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
            try
            {
                score_t = (int)comment_model.Teacher_score;
                this.txtTeacherScore.Text = comment_model.Teacher_score.ToString();
            }
            catch
            {
                this.txtTeacherScore.Text = "未评分";
            }
            try
            {
                score_c=(int)comment_model.Reply_score;
                float sc = GetUser_CommentScore(_id);
                if (sc != -1)
                    this.txtCommentScore.Text = sc.ToString();
                else this.txtCommentScore.Text = "未评分";
                this.lblComment.HRef = "CommentPage.aspx?userId=" + DESEncrypt.Encrypt(_id.ToString());
            }
            catch {
                this.txtCommentScore.Text = "未评分";
            }
            try
            {
                var soft_model = new BLL.CCOM.Software_accept().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
                score_s=(int)soft_model.Conclusion;
                this.txtScoftwareScore.Text = soft_model.Conclusion.ToString();
                this.lblSoft.HRef = "SoftwarePage.aspx?userId=" + DESEncrypt.Encrypt(_id.ToString());
            }
            catch
            {
                this.txtScoftwareScore.Text = "未评分";
            }
            if(score_c>=0&&score_s>=0&&score_t>=0)
            {
                var model = new BLL.CCOM.Comput_score().GetModel(1);
                decimal score = 0;
                if (model.Ratio_software == 0)
                {
                    score = score_t * model.Ratio_teacher + (int)((score_s < score_c ? score_s : score_c) * model.Ratio_review);
                }
                else
                {
                    score = score_t * model.Ratio_teacher + (int)((score_s > score_c ? score_s : score_c) * model.Ratio_review);
                }
                this.txtScore.Text = score.ToString();
            }
        }
        #endregion

        protected void ShowScoreInfo() {
            var model = new BLL.CCOM.Comput_score().GetModel(1);
            this.lblScroeInfor.InnerText = "成绩说明：最终成绩=指导教师评分*" + model.Ratio_teacher.ToString() + "+" + (model.Ratio_software == 1 ? "较大值" : "较小值") + "（口头答辩成绩，软件验收成绩）*" + model.Ratio_review.ToString();
        }

        public string GetUserId() {
            return DESEncrypt.Encrypt(_id.ToString());
        }
    }
}