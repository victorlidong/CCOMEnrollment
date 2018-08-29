using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI.MobileControls;
using university.Common;

namespace university.Web.AdminMetro
{
    public partial class getpwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowVisitInfo();
            }
            this.hidIsTick.Value = "0";
        }
        protected void ShowVisitInfo()
        {
            var currentVisitCount = "0";
            try
            {
                int ran = 0;
                if (Session["visit_ran"] != null)
                {
                    ran = (int)Session["visit_ran"];
                }
                else
                {
                    ran = 100 + new Random(DateTime.Now.Millisecond).Next(100);
                    Session["visit_ran"] = ran;
                }
                currentVisitCount = ((int)this.Application["count"] + ran).ToString("###,###");
                //this.divCurrentVisit.InnerHtml = ((int) this.Application["count"]+ran).ToString("###,###");
            }
            catch
            {
                //this.divCurrentVisit.InnerHtml = "0";
            }
        }

        protected void btnGetPwd_Click(object sender, EventArgs e)
        {
            GetPwdByPhone();
        }

        protected void GetPwdByPhone()
        {

            if (Session[MyKeys.SESSION_PHONE_CODE] == null)
            {
                this.lblReInfo.Text = "请输入手机验证码！";
                return;
            }
            if (Session[MyKeys.SESSION_PHONE_CODE].ToString() != this.txtPhoneCode.Text)
            {
                this.lblReInfo.Text = "验证码输入不正确！";
                return;
            }
            String userName = this.txtUserName1.Text.Trim();
            String phone = this.txtPhone.Text.Trim();
            if (userName == "")
            {
                this.lblReInfo.Text = "用户名为空！";
                return;
            }
            if (userName.Length > 50 || !Common.Utils.IsSafeSqlString(userName))
            {
                this.lblReInfo.Text = "用户名不合法！";
                return;
            }
            if (!Validator.IsMobile(phone))
            {
                this.lblReInfo.Text = "手机号不合法！";
                return;
            }
            //判断用户是否存在
            BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information model = bll.GetModel(" User_number='" + phone + "'");
            if (model == null)
            {
                this.lblReInfo.Text = "用户信息不匹配！";
                return;
            }
            BLL.CCOM.User_property userEx_bll = new BLL.CCOM.User_property();
            Model.CCOM.User_property userEx_model = userEx_bll.GetModel(" User_id=" + model.User_id);
            if (userEx_model == null)
            {
                if (!model.User_realname.Equals(userName))
                {
                    this.lblReInfo.Text = "用户信息不匹配！";
                    return;
                }
            }
            else
            {
                if (!model.User_realname.Equals(userName) && !userEx_model.UP_CEE_number.Equals(userName))
                {
                    this.lblReInfo.Text = "用户信息不匹配！";
                    return;
                }
            }
            //更改密码
            String newPwd = Utils.Number(6);
            model.User_password = DESEncrypt.MD5Encrypt(newPwd);//敏感字段
            bll.Update(model);
            ManDaoSMS.SendSMS(phone, GetChangePwdSms(model.User_realname, newPwd));
            this.lblReInfo.Text = "新密码已发送您的手机，请查看！";
        }

        protected void btnPhoneCode_Click(object sender, EventArgs e)
        {
            String userName = this.txtUserName1.Text.Trim();
            String phone = this.txtPhone.Text.Trim();
            if (userName == "")
            {
                this.lblReInfo.Text = "用户名为空！";
                return;
            }
            if (userName.Length > 50 || !Common.Utils.IsSafeSqlString(userName))
            {
                this.lblReInfo.Text = "用户名不合法！";
                return;
            }
            if (!Validator.IsMobile(phone))
            {
                this.lblReInfo.Text = "手机号不合法！";
                return;
            }
            BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information model = bll.GetModel(" User_number='" + phone + "'");
            if (model == null)
            {
                this.lblReInfo.Text = "用户信息不匹配！";
                return;
            }
            BLL.CCOM.User_property userEx_bll = new BLL.CCOM.User_property();
            Model.CCOM.User_property userEx_model = userEx_bll.GetModel(" User_id=" + model.User_id);
            if (userEx_model == null)
            {
                if (!model.User_realname.Equals(userName))
                {
                    this.lblReInfo.Text = "用户信息不匹配！";
                    return;
                }
            }
            else 
            {
                if (!model.User_realname.Equals(userName) && !userEx_model.UP_CEE_number.Equals(userName))
                {
                    this.lblReInfo.Text = "用户信息不匹配！";
                    return;
                }
            }
            if (Session[MyKeys.SESSION_PHONE_CODE_TIME] != null)
            {
                DateTime dt = (DateTime)Session[MyKeys.SESSION_PHONE_CODE_TIME];
                if (dt.Add(new TimeSpan(0, 0, 60)) > DateTime.Now)
                {
                    this.lblReInfo.Text = "请您60秒后再获取手机验证码！";
                    return;
                }
            }
            //发送验证码
            String code = Utils.Number(6);
            Session[MyKeys.SESSION_PHONE_CODE] = code;
            Session[MyKeys.SESSION_PHONE_CODE_TIME] = DateTime.Now;
            ManDaoSMS.SendSMS(phone, GetVCodeSms(model.User_realname, code));
            this.lblReInfo.Text = "手机验证码已发送到您的手机！";
            this.hidIsTick.Value = "1";
        }

        protected String GetVCodeSms(String realName, String code)
        {
            return String.Format("{0}您好，您的验证码是：{1}。", realName, code);
        }

        protected String GetChangePwdSms(String realName, String pwd)
        {
            return String.Format("{0}您好，您刚操作了找回密码功能，您的新密码是：{1}。请您登录后，重设密码。如非本人操作，请联系{2}", realName, pwd, "contact@quanquan6.com");
        }

    }
}