using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.IO;

namespace university.Web.AdminMetro.CCOM.TopicManage
{
    public partial class TeacherPage : university.UI.ManagePage
    {
        public long TeacherID;//修改参数
        public TeacherPage()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TeacherID = 0;
            TeacherID = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("teacherid")));
            //TeacherID = 3;
            if (!Page.IsPostBack)
            {
                if (TeacherID == 0)
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
            var tutor_model = new BLL.CCOM.Tutor().GetModel(" User_id=" + TeacherID);
            var user_model = new BLL.CCOM.View_User().GetModel(" User_id=" + TeacherID);
            this.lblNumber.InnerText = user_model.User_number;
            this.lblName.InnerText = user_model.User_realname;
            this.lblGender.InnerText = user_model.User_gender ? "女" : "男";
            this.lblAgency.InnerText = user_model.Agency_name;
            if (tutor_model.Title_id != null) this.lblTitle.InnerText = new BLL.CCOM.Title().GetModel((int)tutor_model.Title_id).Title_name;
            else this.lblTitle.InnerText = "--";
            if (tutor_model.Subject != null) this.lblSubject.InnerText = tutor_model.Subject;
            else this.lblSubject.InnerText = "--";
            if (tutor_model.Tutor_email != null) this.lblEmail.InnerText = tutor_model.Tutor_email;
            else this.lblEmail.InnerText = "--";
            this.lblPhone.InnerText = new BLL.CCOM.User_information().GetModel(TeacherID).User_phone;
            if (tutor_model.Tutor_fixedphone != null) this.lblFixedPhone.InnerText = tutor_model.Tutor_fixedphone;
            else this.lblFixedPhone.InnerText = "--";
            if (tutor_model.Tutor_location != null) this.lblLocation.InnerText = tutor_model.Tutor_location;
            else this.lblLocation.InnerText = "--";
            if (tutor_model.Tutor_introduce != null) this.lblIntroduce.InnerText = tutor_model.Tutor_introduce;
            else this.lblIntroduce.InnerText = "--";
        }
        #endregion

    }
}