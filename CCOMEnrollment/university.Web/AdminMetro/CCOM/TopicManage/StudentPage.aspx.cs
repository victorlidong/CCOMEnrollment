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
    public partial class StudentPage : university.UI.ManagePage
    {
        public long StudentID;//修改参数
        public StudentPage()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            StudentID = 0;
            StudentID = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("studentid")));
            //StudentID = 5;
            if (!Page.IsPostBack)
            {
                if (StudentID == 0)
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
            var user_model = new BLL.CCOM.View_User().GetModel(" User_id=" + StudentID);
            this.lblNumber.InnerText = user_model.User_number;
            this.lblName.InnerText = user_model.User_realname;
            this.lblGender.InnerText = user_model.User_gender ? "女" : "男";
            this.lblPhone.InnerText = new BLL.CCOM.User_information().GetModel(StudentID).User_phone;
            this.lblAgency.InnerText = user_model.Agency_name;
            if (user_model.User_birthday != null) this.lblBirthday.InnerText = user_model.User_birthday.Value.ToString("yyyy年MM月dd日");
            else this.lblBirthday.InnerText = "--";

            var user = new BLL.CCOM.User_information().GetModel(StudentID);
            if (user.Nationality_id != null)
            {
                this.lblNationality.InnerText = new BLL.CCOM.Nationality().GetModel((int)user.Nationality_id).Nationality_name;
            }
            else this.lblNationality.InnerText = "--";
            if (user.Politic_id != null) 
            {
                this.lblPolitic.InnerText = new BLL.CCOM.Politics().GetModel((int)user.Politic_id).Politics_name;
            }
            else this.lblPolitic.InnerText = "--";
        }
        #endregion

    }
}