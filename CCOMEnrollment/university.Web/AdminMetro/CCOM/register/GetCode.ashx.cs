using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.Web.SessionState;
namespace university.Web.AdminMetro.CCOM.register
{
    /// <summary>
    /// GetCode1 的摘要说明
    /// </summary>
    public class GetCode1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string phoneNumber = context.Request.Params["phoneNumber"].ToString();
            if (!Validator.IsMobile(phoneNumber))
            {
                context.Response.Write("手机号无效"); 
                return;
            }
            //查询数据库中是否已经注册过
            //Model.CCOM.User_infomation model = new BLL.CCOM.User_infomation().GetModel("User_mobile='" + phoneNumber + "'");
            //if (model != null)
            //{
            //    context.Response.Write("该手机号已被注册"); 
            //    return;

            //}
            
            if (HttpContext.Current.Session[MyKeys.SESSION_PHONE_CODE_TIME] != null)
            {
                var dt = (DateTime)HttpContext.Current.Session[MyKeys.SESSION_PHONE_CODE_TIME];
                if (dt.Add(new TimeSpan(0, 0, 60)) > DateTime.Now)
                {
                    context.Response.Write("1分钟内只能获取一次验证码，请稍后获取"); 
                    return;
                }
            }

            //发送验证码
            String code = Utils.Number(6);
            HttpContext.Current.Session[MyKeys.SESSION_PHONE_CODE] = code;
            HttpContext.Current.Session[MyKeys.SESSION_PHONE_CODE_TIME] = DateTime.Now;
            if (ManDaoSMS.SendSMS(phoneNumber, GetVCodeSms(phoneNumber, code)) == ManDaoSMS.RESULT_SUCCESS)
            {
                context.Response.Write("1"); 
            }
            else
            {
                context.Response.Write("获取验证码失败，请重新获取"); 
            }
            
        }

        protected String GetVCodeSms(String phonenumber, String code)
        {
            return String.Format("{0}您好，您的验证码是：{1}。", phonenumber, code);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}