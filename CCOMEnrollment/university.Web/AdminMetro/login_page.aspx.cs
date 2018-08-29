using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI.MobileControls;
using university.Common;

namespace university.Web.AdminMetro
{
    public partial class login_page : System.Web.UI.Page
    {
        private const int TryNumber = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtUserName.Text = Utils.GetCookie(MyKeys.COOKIE_USER_NAME_REMEMBER);
                this.hidselectedschool.Value = Utils.GetCookie(MyKeys.COOKIE_USER_SCHOOL_REMEMBER);
                if (Utils.GetCookie(MyKeys.COOKIE_USER_LOGINTYPE_REMEMBER) != "")
                    this.showLoginTab.Value = Utils.GetCookie(MyKeys.COOKIE_USER_LOGINTYPE_REMEMBER);

            }
            InitialPage(1);//初始化资讯
        }
        /// <summary>
        /// 初始化资讯
        /// </summary>
        /// <param name="typeId"></param>
        protected void InitialPage(int page)
        {

            //更新置顶数据
            var bll = new BLL.CCOM.News();
            var list = bll.GetModelList("News_top=1");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].News_date != null)
                {
                    DateTime date = Convert.ToDateTime(list[i].News_date);
                    if (list[i].News_top_time != null)
                    {
                        if (date.AddDays((double)list[i].News_top_time) < DateTime.Now)
                        {
                            var model = bll.GetModel(list[i].News_id);
                            model.News_top = false;
                            model.News_top_time = 0;
                            bll.Update(model);
                        }

                    }
                    else
                    {
                        //若为空，默认为3天
                        if (date.AddDays(3.0) < DateTime.Now)
                        {
                            var model = bll.GetModel(list[i].News_id);
                            model.News_top = false;
                            model.News_top_time = 0;
                            bll.Update(model);
                        }
                    }
                }
            }
            int start_index = 1;
            int end_index = 10;

            DataTable dt = bll.GetListByPage("", "News_top DESC ,News_date DESC ", start_index, end_index).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string li = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    bool top = false;
                    try
                    {
                        top = Convert.ToBoolean(dr["News_top"]);
                    }
                    catch
                    {
                        top = false;
                    }
                    finally
                    {
                        DateTime date = Convert.ToDateTime(dr["News_date"]);
                        string time = date.ToString("yyyy/MM/dd");
                        if (top)
                        {
                            li += "<li class=\"notice-li\">"  + "<a href=\"" +
                               dr["News_URL"] + "\"  target=\"_blank\">" + "<img src=\"/images/news/news_logo2.png\"  class=\"img_logo\"/>" + "<span style=\"color:red;\">[置顶] </span>" +
                               dr["News_title"] + "</a>" + "<span class=\"date\">" +
                               time + "</span>" + "</li>";
                        }
                        else
                        {
                            li += "<li class=\"notice-li\">"  + "<a href=\"" +
                               dr["News_URL"] + "\"  target=\"_blank\">" + "<img src=\"/images/news/news_logo2.png\" class=\"img_logo\"/>" +
                               dr["News_title"] + "</a>" + "<span class=\"date\">" +
                               time + "</span>" + "</li>";
                        }
                    }
                }
                this.news_list.InnerHtml = li;
            }
            int newsNum = bll.GetRecordCount("");
            int pageNum = 0;
            if (newsNum % 10 == 0)
            {
                pageNum = newsNum / 10;
            }
            else
            {
                pageNum = newsNum / 10 + 1;
            }
            this.page_num.Value = pageNum + "";

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cookie = Utils.GetCookie("try_time");
            //if (!string.IsNullOrEmpty(Utils.GetCookie("try_time")) && int.Parse(Utils.GetCookie("try_time")) > TryNumber)
            //{
            //    this.lblTip.Text = "您尝试次数超过限制，请3分钟后再试";
            //    Session[MyKeys.NEED_VCODE] = 0;
            //    this.txtCode.Text = "";
            //    return;
            //}
            //else
            {
                string userName = txtUserName.Text.Trim();
                //string userStuNo = this.txtStuNo.Text.Trim();
                string userPwd = txtUserPwd.Text.Trim();
                //string code = txtCode.Text.Trim();

                if (Tools.CheckParams(userName))
                {
                    lblTip.Visible = true;
                    lblTip.Text = "请勿输入非法字符";
                    this.txtCode.Text = "";
                    return;
                }
                //用户名登录
                if (userName.Equals("") || userPwd.Equals(""))
                {
                    lblTip.Visible = true;
                    lblTip.Text = "请输入用户名或密码";
                    this.txtCode.Text = "";
                    return;
                }
                if (userName.Length > 200)
                {
                    lblTip.Visible = true;
                    lblTip.Text = "用户名不合法";
                    this.txtCode.Text = "";
                    return;
                }
                if (userPwd.Length > 200)
                {
                    lblTip.Visible = true;
                    lblTip.Text = "密码不合法";
                    return;
                }
                //需要验证码
                if(this.showVCode.Value=="1")
                {
                    string code = this.txtCode.Text.Trim();

                    if (code.Equals(""))
                    {
                        lblTip.Visible = true;
                        lblTip.Text = "请输入验证码";
                        this.txtCode.Text = "";
                        return;
                    }
                    if (Session[MyKeys.SESSION_CODE] == null)
                    {
                        lblTip.Visible = true;
                        lblTip.Text = "系统找不到验证码";
                        this.txtCode.Text = "";
                        return;
                    }
                    if (code.ToLower() != Session[MyKeys.SESSION_CODE].ToString().ToLower())
                    {
                        lblTip.Visible = true;
                        lblTip.Text = "验证码输入不正确";
                        this.txtCode.Text = "";
                        return;
                    }
                }
                
                

                BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
                Model.CCOM.User_information model = null;





                string sql = "User_number='" + userName + "' and User_password='" + DESEncrypt.MD5Encrypt(userPwd) + "'";
                //string sql = "User_number='" + userName + "'";

                model = bll.GetModel(sql);
                //model = bll.GetModel(userName, DESEncrypt.MD5Encrypt(userPwd));//敏感字段
                if (model == null)
                {
                    lblTip.Text = "用户名或密码有误";
                    this.txtCode.Text = "";
                    lblTip.Visible = true;
                    ////记录错误次数
                    if (Session[MyKeys.NEED_VCODE] == null)
                    {
                        Session[MyKeys.NEED_VCODE] = 1;
                    }
                    else
                    {
                        int num = (int)Session[MyKeys.NEED_VCODE];
                        Session[MyKeys.NEED_VCODE] = (int)Session[MyKeys.NEED_VCODE] + 1;
                        if ((int)Session[MyKeys.NEED_VCODE] == TryNumber)
                        {
                            this.showVCode.Value = "1";
                            this.show_code.Style["display"] = "block";
                            //Utils.WriteCookie("try_time",((int)Session[MyKeys.NEED_VCODE]).ToString(),3);
                        }  
                    }

                    return;
                }

                if (model != null)
                {
                    if (model.User_status == false)
                    {
                        lblTip.Text = "用户已禁用";
                        model = null;
                        return;
                    }
                    else
                    {
                        //写入Cookies
                        if (cbRememberId.Checked)
                        {
                            Utils.WriteCookie(MyKeys.COOKIE_USER_NAME_REMEMBER, userName, 144000);
                        }
                        else
                        {
                            Utils.WriteCookie(MyKeys.COOKIE_USER_NAME_REMEMBER, userName, -144000);
                        }


                    }
                }

                //写入登录方式的cookie
                Utils.WriteCookie(MyKeys.COOKIE_USER_LOGINTYPE_REMEMBER, this.showLoginTab.Value, 144000);

                Session[MyKeys.NEED_VCODE] = null;
                Session[MyKeys.SESSION_ADMIN_INFO] = model;
                Session.Timeout = 600;

                Utils.WriteCookie("UniversityLoginInfo", DESEncrypt.Encrypt(DateTime.Now.Date.ToString() + "," + model.User_id), 1200);

                Response.Redirect("index.aspx");
                return;
            }
            
        }


    }
}