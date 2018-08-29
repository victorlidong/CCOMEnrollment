using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class ApplyBest : university.UI.ManagePage
    {
        private static long _id = 0;
        public ApplyBest()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.CCOM.User_information model = GetAdminInfo_CCOM();
            _id = model.User_id;

            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }

        protected void ShowInfo()
        {
            var form_model = new BLL.CCOM.Form_review().GetModel(" User_id=" + GetAdminInfo_CCOM().User_id + " and Form_type_id=1");
            var form2_model = new BLL.CCOM.Form_review().GetModel(" User_id=" + GetAdminInfo_CCOM().User_id + " and Form_type_id=2");
            if (form_model == null)
            {
                this.lblResult.InnerText = "尚未提交形式审查表一";
                this.lblSubmit.Disabled = true;
            }
            else if (form_model.Review_result == 0)
            {
                this.lblResult.InnerText = "形式审查表一尚未通过审核";
                this.lblSubmit.Disabled = true;
            }
            else if (form_model.Review_result == 1)
            {
                this.lblResult.InnerText = "形式审查表一合格";
                if (form2_model == null)
                {
                    this.lblSubmit.HRef = "FormReview2.aspx?studentID=" + DESEncrypt.Encrypt(GetAdminInfo_CCOM().User_id.ToString());
                }
                else
                {
                    this.lblSubmit.InnerText = "已提交评优申请";
                }
            }
            else
            {
                this.lblResult.InnerText = "形式审查表一不合格";
                this.lblSubmit.Disabled = true;
            }
        }
    }
}