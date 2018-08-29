using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.IO;

namespace university.Web.AdminMetro.CCOM.update_info
{
    public partial class UpdateInfo : university.UI.ManagePage
    {
        public long UserID;//修改参数
        public UpdateInfo()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = GetAdminInfo_CCOM().User_id;
            if (!Page.IsPostBack)
            {
                if (new BLL.CCOM.User_information().GetModel(UserID).Role_id == 2)
                {
                    this.student_page.Visible = false;
                    this.other_page.Visible = false;
                    ShowTeacherInfo();
                }
                else if (new BLL.CCOM.User_information().GetModel(UserID).Role_id == 3)
                {
                    this.teacher_page.Visible = false;
                    this.other_page.Visible = false;
                    ShowStudentInfo();
                }
                else
                {
                    this.student_page.Visible = false;
                    this.teacher_page.Visible = false;
                    ShowOtherInfo();
                }
            } 
        }

        #region 赋值操作=================================
        public void ShowTeacherInfo()
        {
            var user_view_model = new BLL.CCOM.View_User().GetModel(" User_id=" + UserID);
            var user_model = new BLL.CCOM.User_information().GetModel(UserID);
            var teacher_model = new BLL.CCOM.Tutor().GetModel(" User_id=" + UserID);
            this.lblNumber.InnerText = user_view_model.User_number;
            this.lblName.InnerText = user_view_model.User_realname;
            this.ddlGender.SelectedValue = (Boolean)user_view_model.User_gender ? "1" : "0";
            this.lblAgency.InnerText = user_view_model.Agency_name;
            this.txtPhone.Value = user_model.User_phone;
            DataSet ds = new BLL.CCOM.Title().GetList("");
            this.ddlTitle.DataSource = ds.Tables[0].DefaultView;
            this.ddlTitle.DataTextField = "Title_name";
            this.ddlTitle.DataValueField = "Title_id";
            this.ddlTitle.DataBind();
            this.ddlTitle.Items.Add(new ListItem("未设置","0"));
            if (teacher_model != null)
            {
                if (teacher_model.Title_id != null) this.ddlTitle.SelectedValue = teacher_model.Title_id.ToString();
                else this.ddlTitle.SelectedValue = "0";
                this.txtSubject.Value = teacher_model.Subject;
                this.txtEmail.Value = teacher_model.Tutor_email;
                this.txtFixedPhone.Value = teacher_model.Tutor_fixedphone;
                this.txtPlace.Value = teacher_model.Tutor_location;
                this.txtIntroduce.Value = teacher_model.Tutor_introduce;
            }
        }

        public void ShowStudentInfo()
        {
            var user_view_model = new BLL.CCOM.View_User().GetModel(" User_id=" + UserID);
            var user_model = new BLL.CCOM.User_information().GetModel(UserID);
            this.lblOtherNumber.InnerText = user_view_model.User_number;
            this.lblOtherName.InnerText = user_view_model.User_realname;
            this.ddlOtherGender.SelectedValue = (Boolean)user_view_model.User_gender ? "1" : "0";
            this.txtOtherPhone.Value = user_model.User_phone;
            this.lblClass.InnerText = user_view_model.Agency_name;
            if (user_view_model.User_birthday != null) this.txtBirthday.Text = user_view_model.User_birthday.Value.ToString("yyyy-MM-dd");
            new BLL.CCOM.Nationality().BindDDL(this.ddlNationality);
            this.ddlNationality.Items.Add(new ListItem("未设置", "0"));
            if (user_model.Nationality_id != null) this.ddlNationality.SelectedValue = user_model.Nationality_id.ToString();
            else this.ddlNationality.SelectedValue = "0";
            new BLL.CCOM.Politics().BindDDL(this.ddlPolitic);
            this.ddlPolitic.Items.Add(new ListItem("未设置", "0"));
            if (user_model.Politic_id != null) this.ddlPolitic.SelectedValue = user_model.Politic_id.ToString();
            else this.ddlPolitic.SelectedValue = "0";
        }

        public void ShowOtherInfo()
        {
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information user_model = user_bll.GetModel(UserID);

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
            int agency_id = 0;
            agency_id = user_model.Agency_id;
            BLL.CCOM.Agency user_agency_bll = new BLL.CCOM.Agency();
            Model.CCOM.Agency user_agency_model = user_agency_bll.GetModel(agency_id);
            if (user_agency_model.Agency_id != 0)
            {
                txt_Agency.Text = user_agency_model.Agency_name;
            }
            else
            {
                div_user_agency.Visible = false;
            }

            //移动电话
            this.txt_User_number.Text = user_model.User_number;

            //性别
            if ((Boolean)user_model.User_gender)
            {
                this.rbl_User_gender.SelectedIndex = 1;
            }

            //出生日期
            if (user_model.User_birthday == null)
            {
                txt_User_birthday.Text = "请填写出生日期";
            }
            else
            {
                this.txt_User_birthday.Text = Convert.ToDateTime(user_model.User_birthday).ToString("yyyy-MM-dd");
            }

            //添加日期
            this.txt_User_addtime.Text = Convert.ToDateTime(user_model.User_addtime).ToString("yyyy-MM-dd");
        }
        #endregion

        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (UserID != 0)
            {
                bool result = false;
                if (new BLL.CCOM.User_information().GetModel(UserID).Role_id == 2)
                {
                    result = UpdateTeacherInfo();
                }
                else if (new BLL.CCOM.User_information().GetModel(UserID).Role_id == 3)
                {
                    result = UpdateStudentInfo();
                }
                else
                {
                    result = UpdateOtherInfo();
                }
                if (result)
                {
                    JscriptMsg("更新成功！", "UpdateInfo.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
                }
                else
                {
                    JscriptMsg("更新信息失败！", "", "Error");
                }
            }
        }

        private bool UpdateTeacherInfo()
        {
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information user_model = user_bll.GetModel(UserID);
            bool result = false;

            if (this.ddlGender.SelectedValue == "0")
            {
                user_model.User_gender = false;
            }
            else
            {
                user_model.User_gender = true;
            }

            if (this.txtPhone.Value != "")
            {
                user_model.User_phone = this.txtPhone.Value;
            }

            try
            {
                bool res = user_bll.Update(user_model);
                if (res == true)
                {
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            BLL.CCOM.Tutor teacher_bll = new BLL.CCOM.Tutor();
            Model.CCOM.Tutor teacher_model = teacher_bll.GetModel(" User_id=" + UserID);

            if (teacher_model != null)
            {
                if (this.ddlTitle.SelectedValue != "0") teacher_model.Title_id = int.Parse(this.ddlTitle.SelectedValue);
                if (this.txtSubject.Value != "") teacher_model.Subject = this.txtSubject.Value;
                if (this.txtEmail.Value != "") teacher_model.Tutor_email = this.txtEmail.Value;
                if (this.txtFixedPhone.Value != "") teacher_model.Tutor_fixedphone = this.txtFixedPhone.Value;
                if (this.txtPlace.Value != "") teacher_model.Tutor_location = this.txtPlace.Value;
                if (this.txtIntroduce.Value != "") teacher_model.Tutor_introduce = this.txtIntroduce.Value;
                if (teacher_bll.Update(teacher_model)) result = true;
            }
            else
            {
                teacher_model = new Model.CCOM.Tutor();
                teacher_model.User_id = UserID;
                if (this.ddlTitle.SelectedValue != "0") teacher_model.Title_id = int.Parse(this.ddlTitle.SelectedValue);
                if (this.txtSubject.Value != "") teacher_model.Subject = this.txtSubject.Value;
                if (this.txtEmail.Value != "") teacher_model.Tutor_email = this.txtEmail.Value;
                if (this.txtFixedPhone.Value != "") teacher_model.Tutor_fixedphone = this.txtFixedPhone.Value;
                if (this.txtPlace.Value != "") teacher_model.Tutor_location = this.txtPlace.Value;
                if (this.txtIntroduce.Value != "") teacher_model.Tutor_introduce = this.txtIntroduce.Value;
                if (teacher_bll.Add(teacher_model) != 0) result = true;
            }

            return result;
        }

        private bool UpdateStudentInfo()
        {
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information user_model = user_bll.GetModel(UserID);
            bool result = false;

            if (this.ddlOtherGender.SelectedValue == "0")
            {
                user_model.User_gender = false;
            }
            else
            {
                user_model.User_gender = true;
            }

            if (this.txtOtherPhone.Value != "") 
            {
                user_model.User_phone = this.txtOtherPhone.Value;
            }

            if (this.txtBirthday.Text != "")
            {
                user_model.User_birthday = Convert.ToDateTime(this.txtBirthday.Text);
            }

            if (this.ddlNationality.SelectedValue != "0")
            {
                user_model.Nationality_id = int.Parse(this.ddlNationality.SelectedValue);
            }

            if (this.ddlPolitic.SelectedValue != "0")
            {
                user_model.Politic_id = int.Parse(this.ddlPolitic.SelectedValue);
            }
            try
            {
                bool res = user_bll.Update(user_model);
                if (res == true)
                {
                    return res;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private bool UpdateOtherInfo()
        {
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information user_model = user_bll.GetModel(UserID);

            bool result = false;

            //更新姓名
            if (txt_User_realname.Text == "")
            {
                JscriptMsg("请填写真实姓名！", "", "Error");
                return false;
            }
            else
            {
                user_model.User_realname = this.txt_User_realname.Text;
            }

            //更新手机号，内容不变
            user_model.User_number = this.txt_User_number.Text;

            //更新性别

            if (this.rbl_User_gender.SelectedIndex == 0)
            {
                user_model.User_gender = false;
            }
            else
            {
                user_model.User_gender = true;
            }

            //更新出生日期
            try
            {
                user_model.User_birthday = Convert.ToDateTime(this.txt_User_birthday.Text);
            }
            catch
            {
                user_model.User_birthday = null;
            }

            //更新的状态
            try
            {
                bool res = user_bll.Update(user_model);
                if (res == true)
                {
                    return res;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}