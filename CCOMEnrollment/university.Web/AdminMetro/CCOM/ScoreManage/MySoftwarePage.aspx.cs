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
    public partial class MySoftwarePage : university.UI.ManagePage
    {
        public long UserID;//修改参数
        protected string PageTitle;
        protected string reviewTr;
        public MySoftwarePage()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = 0;
            UserID = GetAdminInfo_CCOM().User_id;
            if (!Page.IsPostBack)
            {
                if (UserID == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                string ht = "";
                Model.CCOM.Topic_relation model = new Model.CCOM.Topic_relation();
                model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + GetAdminInfo_CCOM().User_id + "and Accept_state=1");
                if (model == null)
                {
                    ht = " <div class=\"content\" align=\"center\"><h3>您尚无选题<h3><table class=\"table table-striped table-bordered dataTable\"></table></div>";
                    this.print_div.InnerHtml = ht;
                    btnSubmit.Visible = false;
                    //JscriptMsg("您尚无选题！", "back", "Error");
                    //return;

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
            Model.CCOM.View_User user_model = new BLL.CCOM.View_User().GetModel(" User_id=" + UserID);
            long Group_id = GetGroupId(UserID);
            if (Group_id == 0)
            {
                this.print_div.InnerHtml = " <div class=\"content\" align=\"center\"><h3>您尚未被分配到任何软件验收组<h3><table class=\"table table-striped table-bordered dataTable\"></table></div>"; ;
                btnSubmit.Visible = false;
                return;
            }
            var group_model = new BLL.CCOM.Reply_group().GetModel(" Group_id=" + Group_id);
            var leader_model = new BLL.CCOM.View_User().GetModel(" User_id=" + group_model.User_id);

            PageTitle = user_model.User_realname + "的软件验收表";

            this.txtRunStatus.Disabled = true;
            this.txtFeature.Disabled = true;
            this.txtScore.Disabled = true;

            this.lblName.InnerText = user_model.User_realname;
            this.lblNumber.InnerHtml = user_model.User_number;

            var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + UserID);
            if (relation_model != null)
            {
                this.lblTeacher.InnerText = new BLL.CCOM.User_information().GetModel(relation_model.Teacher_id).User_realname;
                this.lblTitle.InnerText = new BLL.CCOM.Topic().GetModel(relation_model.Topic_id).Topic_name;
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
                        title= new BLL.CCOM.Title().GetModel((int)tutor_model.Title_id).Title_name;
                    }
                    else
                    {
                        title= "--";
                    }
                }
                reviewTr += "</tr><td style=\"text-align:center;\">组员</td><td style=\"text-align:center;\">" + u_model.User_realname + "</td><td style=\"text-align:center;\">" + title + "</td><td colspan=\"3\" style=\"text-align:center;\">" + u_model.Agency_name + "</td></tr>";
            }

            var software_model = new BLL.CCOM.Software_accept().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
            if (software_model != null)
            {
                if (software_model.Time != null) this.lblTime.InnerText = software_model.Time.Value.ToString("yyyy年MM月dd日 HH:mm:ss");
                this.txtDataList.InnerText = software_model.Data_list;
                this.txtAnguage.InnerText = software_model.anguage;
                this.txtEnvironmental.InnerText = software_model.Environmental;
                this.txtLineCount.InnerText = software_model.Line_count;
                this.txtLineHand.InnerText = software_model.Line_hand;
                this.txtRunStatus.InnerText = software_model.Run_status;
                this.txtFeature.InnerText = software_model.Feature;
                this.txtScore.Value = software_model.Conclusion.ToString();
            }
        }
        #endregion

        #region 增加/编辑操作=================================
        private string DoAction()
        {
            string DataList = this.txtDataList.InnerText;
            string Anguage = this.txtAnguage.InnerText;
            string Environmental = this.txtEnvironmental.InnerText;
            string LineCount = this.txtLineCount.InnerText;
            string LineHand = this.txtLineHand.InnerText;
            if (DataList == "") return "请添加验收资料清单";
            if (Anguage == "") return "请添加源语言/开发环境";
            if (Environmental == "") return "请添加运行环境/系统配置";
            if (LineCount == "") return "请添加总代码行数/字节数（KB）";
            if (LineHand == "") return "请添加手工编写代码行数";

            long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + UserID).Topic_relation_id;
            var software_model = new BLL.CCOM.Software_accept().GetModel(" Topic_relation_id=" + Topic_relation_id);
            if (software_model != null)
            {
                software_model.Data_list = DataList;
                software_model.anguage = Anguage;
                software_model.Environmental = Environmental;
                software_model.Line_count = LineCount;
                software_model.Line_hand = LineHand;
                if (!new BLL.CCOM.Software_accept().Update(software_model))
                {
                    return "更新软件验收表异常";
                }
            }
            else
            {
                Model.CCOM.Software_accept soft_model = new Model.CCOM.Software_accept();
                soft_model.Data_list = DataList;
                soft_model.anguage = Anguage;
                soft_model.Environmental = Environmental;
                soft_model.Line_count = LineCount;
                soft_model.Line_hand = LineHand;
                soft_model.Topic_relation_id = Topic_relation_id;
                if (new BLL.CCOM.Software_accept().Add(soft_model) == 0)
                {
                    return "添加软件验收表异常";
                }
            }
            return "";
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = DoAction();
            if (result == "")
                JscriptMsg("提交成功！", Utils.CombUrlTxt("MySoftwarePage.aspx", "groupid={0}", DESEncrypt.Encrypt("0")), "Success");
            else
                JscriptMsg(result, "", "Error");

        }

        private long GetGroupId(long user_id)
        {
            var groups = new BLL.CCOM.Reply_student().GetModelList(" User_id=" + user_id);
            foreach (var group in groups)
            {
                long group_id = group.Group_id;
                if (new BLL.CCOM.Reply_group().GetModel(group_id).Group_type == 1)
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