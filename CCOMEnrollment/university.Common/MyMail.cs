using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;
using System.Net.Mail;

namespace university.Common
{
    public class MyMail
    {
        #region 发送电子邮件
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="smtpserver">SMTP服务器</param>
        /// <param name="userName">登录帐号</param>
        /// <param name="pwd">登录密码</param>
        /// <param name="nickName">发件人昵称</param>
        /// <param name="strfrom">发件人</param>
        /// <param name="strto">收件人</param>
        /// <param name="subj">主题</param>
        /// <param name="bodys">内容</param>
        public static void sendMail(string smtpserver, string userName, string pwd, string nickName, string strfrom, string strto, string subj, string bodys)
        {
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtpserver;//指定SMTP服务器
            _smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//用户名和密码

            //MailMessage _mailMessage = new MailMessage(strfrom, strto);
            MailAddress _from = new MailAddress(strfrom, nickName);
            MailAddress _to = new MailAddress(strto);
            MailMessage _mailMessage = new MailMessage(_from, _to);
            _mailMessage.Subject = subj;//主题
            _mailMessage.Body = bodys;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.Default;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.Normal;//优先级
            _smtpClient.Send(_mailMessage);
        }
        #endregion

        //通过参数发送邮件
        //strbody是发送的邮件内容
        public static string postEmail(string toMail, string strbody, string strtitle)
        {
            string res = "";
            try
            {
                //管理员的邮箱
                string adminEmail = (string)ConfigurationManager.AppSettings["mailname"];

                //管理员的账号
                string adminCount = adminEmail.Substring(0, adminEmail.IndexOf("@"));

                //邮箱密码
                string adminEmailPwd = (string)ConfigurationManager.AppSettings["mailpwd"];
                //服务器的地址
                string server = (string)ConfigurationManager.AppSettings["mailhost"];
                //服务器端口
                int port = Convert.ToInt32((string)ConfigurationManager.AppSettings["mailport"]);

                //.net smtp类进行邮件发送，支持认证，附件添加；

                ////设置发件人信箱,及显示名字
                MailAddress from = new MailAddress(adminEmail, (string)ConfigurationManager.AppSettings["mailtitle"]);
                //设置收件人信箱,及显示名字 

                MailMessage mailmsg = new MailMessage();
                mailmsg.From = from;

                mailmsg.To.Add(toMail.ToString());

                mailmsg.Body = strbody.ToString();
                mailmsg.IsBodyHtml = true;

                mailmsg.Subject = strtitle;//(string)ConfigurationManager.AppSettings["postUserTitle"];

                SmtpClient smtp = new SmtpClient(server);


                smtp.Credentials = new NetworkCredential(adminEmail, adminEmailPwd);
                smtp.EnableSsl = true;

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mailmsg);
                res = "";
            }
            catch (Exception ee)
            {
                res = ee.ToString();
            }
            finally
            {

            }
            return res;
        }

    }
}
