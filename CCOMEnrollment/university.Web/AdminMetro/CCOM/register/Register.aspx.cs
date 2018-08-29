using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.register
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                
            }
            //txtUserPwd.Attributes["value"] = txtUserPwd.Text;
            //txtUser_pasword_confer.Attributes["value"] = txtUser_pasword_confer.Text;
            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string phoneNumber = this.txtPhoneNumber.Text.Trim();
            string password = this.txtUserPwd.Text.Trim();
            string password_confer = this.txtUser_pasword_confer.Text.Trim();

            if (phoneNumber.Length <= 0)
            {
                lblTip.Visible = true;
                lblTip.Text = "请填写手机号";
                return;
            }
            if (phoneNumber.Length > 14 || !IsNumber(phoneNumber))
            {
                lblTip.Visible = true;
                lblTip.Text = "请正确填写手机号";
                return;
            }
            if (Tools.CheckParams(phoneNumber))
            {
                lblTip.Visible = true;
                lblTip.Text = "手机号包含非法字符，请修改";
                return;
            }
            //查询数据库中是否已经注册过
            BLL.CCOM.User_infomation bll = new BLL.CCOM.User_infomation();

            if (bll.GetRecordCount(" User_mobile='" + phoneNumber + "'") > 0)
            {
                lblTip.Visible = true;
                lblTip.Text = "该账号已被注册";
                return;

            }
            if (password.Length <= 0)
            {
                lblTip.Visible = true;
                lblTip.Text = "请填写密码";
                return;
            }
            if (password.Length < 6 || password.Length > 16 || !IsNumAndEnCh(password))
            {
                lblTip.Visible = true;
                lblTip.Text = "请正确填写密码";
                return;
            }
            if (Tools.CheckParams(password))
            {
                lblTip.Visible = true;
                lblTip.Text = "密码包含非法字符，请修改";
                return;
            }
            if (!password.Equals(password_confer))
            {
                lblTip.Visible = true;
                lblTip.Text = "密码前后不一，请确认";
                return;
            }

            if (Session[MyKeys.SESSION_PHONE_CODE] == null)
            {
                lblTip.Visible = true;
                lblTip.Text = "请获取手机验证码";
                return;
            }
            if (Session[MyKeys.SESSION_PHONE_CODE].ToString() != this.txtSmsCode.Text)
            {

                lblTip.Visible = true;
                lblTip.Text = "手机验证码不正确";
                return;
            }
            BLL.CCOM.Period period_bll = new BLL.CCOM.Period();
            int open_year = DateTime.Now.Year;
            var period_model = period_bll.GetModel(" Period_state=1");
            if (period_model != null)
            {
                try
                {
                    open_year = int.Parse(period_model.Period_year);
                }
                catch
                {

                }
            }
            else
            {
                lblTip.Visible = true;
                lblTip.Text = "当前暂未开启注册";
                return;
            }

            Model.CCOM.User_infomation UserModel = new Model.CCOM.User_infomation();
            UserModel.User_mobile = phoneNumber;
            UserModel.User_password = DESEncrypt.MD5Encrypt(password);
            UserModel.User_type = 1;//默认为大陆考生
            UserModel.User_status = true;//默认为启用状态
            UserModel.User_addtime = DateTime.Now;
            UserModel.User_gender = false;//默认为男
            UserModel.User_realname = "请填写姓名";
            BLL.CCOM.User_infomation user_bll = new BLL.CCOM.User_infomation();
            long _id=user_bll.Add(UserModel);//这里不知为什么返回值不是User_id;
            if(_id>0)
            {
                //鉴于上述问题，这里重新查询User_id;
                DataTable user_table=user_bll.GetList(1, "", " User_id DESC").Tables[0];
                _id = long.Parse(user_table.Rows[0]["User_id"].ToString());
                lblTip.Visible = false;
                
                BLL.CCOM.User_property User_property_bll = new BLL.CCOM.User_property();
                Model.CCOM.User_property User_property_model = new Model.CCOM.User_property();
                User_property_model.User_id = _id;
                User_property_model.Period_id= period_bll.GetModel(" Period_year=" + open_year).Period_id;
                BLL.CCOM.Temp_record temp_record_bll = new BLL.CCOM.Temp_record();
                var temp_record_model = temp_record_bll.GetModel(" Period_year=" + open_year);
                
                //临时表中无该年度记录，则需创建该年度记录
                if(temp_record_model==null)
                {
                    
                    string last_record = open_year + "B" + "0001";

                    Model.CCOM.Temp_record record_model = new Model.CCOM.Temp_record();
                    record_model.Last_CCOM_number = last_record;
                    record_model.Period_year = open_year + "";
                    DataTable table = User_property_bll.GetList(1, "", "UP_id DESC").Tables[0];
                    if (table != null && table.Rows.Count > 0)
                    {
                        DataRow dr = table.Rows[0];
                        last_record=dr["UP_CCOM_number"].ToString();
                        record_model.Last_CCOM_number = open_year + "B" + (int.Parse(last_record.Substring(5)) + 1).ToString("0000");
                    }
                    //插入最后一条记录到临时表
                    temp_record_bll.Add(record_model);

                    //插入个人属性表
                    User_property_model.UP_CCOM_number = record_model.Last_CCOM_number;
                    User_property_model.UP_calculation_status = 0;
                    User_property_bll.Add(User_property_model);
                }
                else//临时表中有该年度记录，则直接取该年度记录
                {
                    int last_record = int.Parse(temp_record_model.Last_CCOM_number.Substring(5));
                    //更新临时表
                    temp_record_model.Last_CCOM_number = open_year + "B" + (last_record + 1).ToString("0000");
                    temp_record_bll.Update(temp_record_model);

                    //插入个人属性表
                    User_property_model.UP_CCOM_number = temp_record_model.Last_CCOM_number;
                    User_property_model.UP_calculation_status = 0;
                    User_property_bll.Add(User_property_model);
                }
                //JscriptMsg("注册成功！", "/AdminMetro/login_page.aspx", "Success");

                var user_notice_bll = new BLL.CCOM.User_notice();
                var user_notice_model = new Model.CCOM.User_notice();
                user_notice_model.User_id = _id;
                var notice_model = new BLL.CCOM.Notice().GetModel(" Notice_flag=1");
                user_notice_model.Notice_id = notice_model.Notice_id.ToString();
                user_notice_bll.Add(user_notice_model);

                Response.Write("<script>window.location.href='/AdminMetro/login_page.aspx';</script>");
            }
            else
            {
                //JscriptMsg("注册失败！", "/AdminMetro/CCOM/register/Register.aspx", "Error");
                Response.Write("<script>window.location.href='/AdminMetro/CCOM/register/Register.aspx';</script>");
            }
            
        }
        /// <summary>
        /// 判断仅包含数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsNumber(string str)
        {
            string pattern = @"^[-]?\d+[.]?\d*$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(str);
        }
        /// <summary>
        /// 判断仅包含数字和字母
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsNumAndEnCh(string input)
        {
            string pattern = @"^[A-Za-z0-9]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
        
    }
}