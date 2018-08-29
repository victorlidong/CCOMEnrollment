using System;
using university.Common;

namespace university.Web.tools
{
    /// <summary>
    /// 发送运维管理提醒邮件
    /// </summary>
    public class ManageReminder
    {
        private const string EmailList =
            "linsiran@quanquan6.com;guojin@quanquan6.com;1418565926@qq.com;37863581@qq.com;93436059@qq.com;709960951@qq.com;396620708@qq.com";
        //private const string EmailList =
        //   "570111649@qq.com;709960951@qq.com";
        public static void Send(string title, string content)
        {
            SendEmail(title, content);
        }

        private static void SendEmail(string title, string content)
        {
            String[] emails = EmailList.Split(';');
            foreach (var email in emails)
            {
                var toEmail = email.Trim();
                if (toEmail != "")
                {
                    MyMail.postEmail(email, content, title);
                }
            }
        }
    }
}
