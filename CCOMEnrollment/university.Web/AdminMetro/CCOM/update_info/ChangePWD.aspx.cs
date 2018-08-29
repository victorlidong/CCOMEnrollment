using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.update_info
{
    public partial class ChangePWD : university.UI.ManagePage
    {
        private static long _id = 0;
        public ChangePWD()
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
            }
        }

        #region 更新操作=================================

        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                string oldPwd = this.txtOldPwd.Text.Trim();
                if (DESEncrypt.MD5Encrypt(oldPwd) == GetAdminInfo_CCOM().User_password)
                {
                    string msg = Pass(this.txtNewPwd.Text.Trim(), this.txtNewPwd2.Text.Trim());
                    if (msg == ""){
                        Session[MyKeys.SESSION_ADMIN_INFO] = null;
                        Session.Clear();
                        Utils.WriteCookie("UniversityLoginInfo", "", -14400);
                        Response.Write(" <script> parent.window.location.href= '../../login_page.aspx ' </script> ");
                    }
                    else JscriptMsg(msg, "back", "Error");
                }
                else 
                {
                    JscriptMsg("原密码输入错误！", "back", "Error");
                }
            }
        }

        protected string Pass(string Pass, string PassConfirm)
        {
            string msg = "";
            if (Tools.CheckParams(Pass + PassConfirm))
            {
                msg = "传输异常，存在非法字符！";
            }
            else
            {
                if (Pass.Length < 6 || Pass.Length > 16) msg = "密码长度请控制在6-16位！";
                else if (Pass != PassConfirm) msg = "两次密码输入不一致！";
                else
                {
                    try
                    {
                        BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
                        Model.CCOM.User_information model = GetAdminInfo_CCOM();
                        model.User_password = DESEncrypt.MD5Encrypt(Pass);
                        bool res = bll.Update(model);
                        if (res == false)
                            msg = "修改失败，参数发生异常！";
                    }
                    catch (Exception)
                    {
                        msg = "修改发生异常！";
                    }
                }
            }
            return msg;
        }
        #endregion

    }
}