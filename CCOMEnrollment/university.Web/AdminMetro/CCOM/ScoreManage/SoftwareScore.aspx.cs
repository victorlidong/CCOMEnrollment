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
    public partial class SoftwareScore : university.UI.ManagePage
    {
        public long UserID;//修改参数
        public long Group_id;
        protected string PageTitle;
        protected string reviewTr;
        public SoftwareScore()
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

           // PageTitle = user_model.User_realname + "的软件验收表";

            this.txtDataList.Disabled = true;
            this.txtAnguage.Disabled = true;
            this.txtEnvironmental.Disabled = true;
            this.txtLineCount.Disabled = true;
            this.txtLineHand.Disabled = true;

            if (GetAdminInfo_CCOM().User_id != leader_model.User_id)
            {
                this.txtRunStatus.Disabled = true;
                this.txtFeature.Disabled = true;
                this.txtScore.Disabled = true;
                this.btnSubmit.Visible = false;
            }

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
                    leader_title= "--";
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
                this.lblTime.InnerText = software_model.Time.Value.ToString("yyyy年MM月dd日 HH:mm:ss");
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
            string RunStatus = this.txtRunStatus.InnerText;
            string Feature = this.txtFeature.InnerText;
            string Score = this.txtScore.Value;
            if (RunStatus == "") return "请添加软件运行状况";
            if (Feature == "") return "请添加软件特点及应用情况";
            if (Score == "") return "请添加验收结论（最后须给出定量的百分制结论）";
            int sc = int.Parse(Score);

            long Topic_relation_id = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + UserID).Topic_relation_id;
            var software_model = new BLL.CCOM.Software_accept().GetModel(" Topic_relation_id=" + Topic_relation_id);
            if (software_model != null)
            {
                software_model.Run_status = RunStatus;
                software_model.Feature = Feature;
                software_model.Conclusion = sc;
                software_model.Time = DateTime.Now;
                if (!new BLL.CCOM.Software_accept().Update(software_model))
                {
                    return "更新验收结果异常";
                }
            }
            else
            {
                Model.CCOM.Software_accept soft_model = new Model.CCOM.Software_accept();
                soft_model.Run_status = RunStatus;
                soft_model.Feature = Feature;
                soft_model.Conclusion = sc;
                soft_model.Topic_relation_id = Topic_relation_id;
                soft_model.Time = DateTime.Now;
                if (new BLL.CCOM.Software_accept().Add(soft_model) == 0)
                {
                    return "添加验收结果异常";
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