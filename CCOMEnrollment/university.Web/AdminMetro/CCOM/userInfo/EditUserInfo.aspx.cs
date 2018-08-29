using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.userInfo
{
    public partial class EditUserInfo : university.UI.ManagePage
    {
        private static long id = 0;
        public EditUserInfo()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            Model.CCOM.User_information model = GetAdminInfo_CCOM();
            id = model.User_id;
            if (!Page.IsPostBack)
            {
                new BLL.CCOM.Certificate_type().BindDDL(this.ddl_identity_type);
                showInfo();
            }

        }
        private void showInfo()
        {
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information user_model = user_bll.GetModel(id);
            if (user_model == null)
            {
                InnerRedirect(MyEnums.RediirectErrorEnum.ParameterError);
            }
            //this.txt_identity_number.Text = user_model.User_ID_number;
            this.txt_realname.Text = user_model.User_realname;
            if (user_model.User_birthday != null)
            {
                this.txtBirthday.Value = Convert.ToDateTime(user_model.User_birthday).ToString("yyyy-MM-dd");
            }
            this.lbl_phone_number.Text = user_model.User_number;

            //this.ddl_identity_type.SelectedValue = user_model.User_ID_number_type.ToString();

            if ((Boolean)user_model.User_gender)
                this.ddl_Sex.SelectedIndex = 1;

            //this.ddl_user_type.SelectedValue = user_model.User_type.ToString();
            this.lbl_register_time.Text = Convert.ToDateTime(user_model.User_addtime).ToString("yyyy-MM-dd");

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}