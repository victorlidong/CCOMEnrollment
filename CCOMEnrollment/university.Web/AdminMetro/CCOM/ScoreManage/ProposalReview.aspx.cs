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
    public partial class ProposalReview : university.UI.ManagePage
    {
        public long UserID;//修改参数
        public long Group_id;
        protected string PageTitle;
        protected string reviewTr;
        public ProposalReview()
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
            Model.CCOM.View_User user_model = new BLL.CCOM.View_User().GetModel(" User_id=" + UserID);
            var group_model = new BLL.CCOM.Reply_group().GetModel(" Group_id=" + Group_id);
            var leader_model = new BLL.CCOM.View_User().GetModel(" User_id=" + group_model.User_id);

            if (GetAdminInfo_CCOM().User_id != leader_model.User_id)
            {
                this.txtOpinion.Disabled = true;
                this.ddlresult.Enabled = false;
                this.btnSubmit.Visible = false;
            }

            this.lblName.InnerText = user_model.User_realname;
            this.lblNumber.InnerHtml = user_model.User_number;
            var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + UserID);
            if (relation_model != null)
            {
                this.lblTeacher.InnerText = new BLL.CCOM.User_information().GetModel(relation_model.Teacher_id).User_realname;
                var topic_model = new BLL.CCOM.Topic().GetModel(relation_model.Topic_id);
                this.lblTitle.InnerText = topic_model.Topic_name;
                this.lblNature.InnerText = topic_model.Topic_nature;
                this.lblSource.InnerText = topic_model.Topic_source;
            }
            else
            {
                return;
            }

            string leader_title = "--";
            var leader_tutor_model = new BLL.CCOM.Tutor().GetModel(" User_id=" + leader_model.User_id);
            if (leader_tutor_model != null)
            {
                if (leader_tutor_model.Title_id != null)
                {
                    leader_title = new BLL.CCOM.Title().GetModel((int)leader_tutor_model.Title_id).Title_name;
                }
                else
                {
                    leader_title = "--";
                }
            }
            reviewTr = "<tr><td style=\"text-align:center;\">组长</td><td style=\"text-align:center;\">" + leader_model.User_realname + "</td><td style=\"text-align:center;\">" + leader_title + "</td><td colspan=\"3\" style=\"text-align:center;\">" + leader_model.Agency_name + "</td></tr>";
            var rcs = new BLL.CCOM.Reply_commission().GetModelList(" Group_id=" + Group_id);
            foreach (var rc in rcs)
            {
                var u_model = new BLL.CCOM.View_User().GetModel(" User_id=" + rc.User_id);
                string title = "--";
                var tutor_model = new BLL.CCOM.Tutor().GetModel(" User_id=" + rc.User_id);
                if (tutor_model != null)
                {
                    if (tutor_model.Title_id != null)
                    {
                        title = new BLL.CCOM.Title().GetModel((int)tutor_model.Title_id).Title_name;
                    }
                    else
                    {
                        title = "--";
                    }
                }
                reviewTr += "</tr><td style=\"text-align:center;\">组员</td><td style=\"text-align:center;\">" + u_model.User_realname + "</td><td style=\"text-align:center;\">" + title + "</td><td colspan=\"3\" style=\"text-align:center;\">" + u_model.Agency_name + "</td></tr>";
            }

            var proposal_model = new BLL.CCOM.Proposal().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
            if (proposal_model != null)
            {
                this.txtOpinion.InnerText = proposal_model.Review;
                this.ddlresult.SelectedValue = proposal_model.Result.ToString();
            }
        }
        #endregion

        #region 增加/编辑操作=================================
        private string DoAction()
        {
            string opinion = this.txtOpinion.InnerText;
            string result = this.ddlresult.SelectedValue;
            if (opinion == "") return "请添加评审意见";
            if (result == "0") return "请添加评审结果";

            long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + UserID).Topic_relation_id;
            var proposal_model = new BLL.CCOM.Proposal().GetModel(" Topic_relation_id=" + Topic_relation_id);
            if (proposal_model == null)//添加评审意见
            {
                Model.CCOM.Proposal p_model = new Model.CCOM.Proposal();
                p_model.Topic_relation_id = Topic_relation_id;
                p_model.Review = opinion;
                p_model.Result = int.Parse(result);
                if (new BLL.CCOM.Proposal().Add(p_model) == 0) return "添加评审结果异常";
            }
            else//更新评审意见
            {
                proposal_model.Review = opinion;
                proposal_model.Result = int.Parse(result);
                if (!new BLL.CCOM.Proposal().Update(proposal_model)) return "更新评审结果异常";
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

    }
}