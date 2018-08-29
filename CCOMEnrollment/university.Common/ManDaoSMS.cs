using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace university.Common
{
    /// <summary>
    /// ManDaoSMS 的摘要说明：漫道科技短信服务
    /// ws url：http://sdk3.entinfo.cn:8060/webservice.asmx
    /// </summary>
    public class ManDaoSMS
    {
        //发送结果
        public const String RESULT_SUCCESS = "0 成功";
        
        private string mobile;
        private string content;
        private string datetime;
        //private const String SIGNATRUE = "[圈圈乐]";
        //private const String SIGNATRUE = "[北理工软件学院]";
        //private const String SIGNATRUE = "[圈圈校园]";
        private const String SIGNATRUE = "[中央音乐学院]";
        private const String EXT = "1";
        public ManDaoSMS()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 发送短信息
        /// </summary>
        /// <param name="mobile">手机号，多个用","间隔</param>
        /// <param name="content">短信内容，字数不限，短信服务接口自动处理；内容字符无限制；70个字符为一条短信</param>
        /// <returns>"1"-余额不足，"0"-成功，串码-失败</returns>
        public static string SendSMS(string mobile, string content)
        {
            //Common.FileOperate.WriteFile("C:\\sms.txt", mobile + "-" + content);
            string sn = (string) ConfigurationManager.AppSettings["sn"];
            string pwd = (string) ConfigurationManager.AppSettings["pwd"];
            string password = (string) ConfigurationManager.AppSettings["password"];
            cn.entinfo.sdk3.WebService ws = new cn.entinfo.sdk3.WebService();
            string[] count = mobile.Split(',');
            //检验余额
            string Overage = ws.GetBalance(sn, pwd);
            int money = Utils.StrToInt(Overage, 0);
            if (money < count.Length)
                return "1"; //余额不足
            int rnd = new Random(DateTime.Now.Millisecond).Next();
            String sendTime = "(" + DateTime.Now.ToString("MM-dd HH:mm") + ")";
            string result = "";
           //多于500人后需要分批发送
            if (count.Length <= 500)
            {
                //result = ws.SendSMSEx(sn, pwd, mobile, content + SIGNATRUE, "1");
                result = ws.mt(sn, password, mobile, content + sendTime+SIGNATRUE, EXT, "", rnd.ToString());
            }
            else
            {
                //分批发送
                for (int i = 0; i < (count.Length/500) + ((count.Length%500 == 0) ? 0 : 1); i++)
                {
                    string mobilestr = "";
                    for (int j = i*500; j < count.Length; j++)
                    {
                        mobilestr += count[j] + ",";
                    }
                    result = ws.mt(sn, password, mobile, content + sendTime+SIGNATRUE, EXT, "", rnd.ToString());
                }
            }
            //Common.FileOperate.WriteFile("C:\\sms.txt",  " result-" + result);
            if (result == rnd.ToString())
            {
                return RESULT_SUCCESS;
            }
            return "error";
        }


       /// <summary>
       /// 获取特定子号的所有回复（只能获取一次，回复获取后服务器将删除）
       /// </summary>
       /// <returns></returns>
        public static ManDaoSMS[] ReceiveSMS()
        {
            string sn = (string) ConfigurationManager.AppSettings["sn"];
            string pwd = (string) ConfigurationManager.AppSettings["pwd"];
            string password = (string) ConfigurationManager.AppSettings["password"];
            cn.entinfo.sdk3.WebService ws = new cn.entinfo.sdk3.WebService();
            cn.entinfo.sdk3.MOBody[] msgs;
            msgs = ws.RECSMSEx(sn, pwd, "1");
            ManDaoSMS[] msg = new ManDaoSMS[msgs.Length];
            return msg;
        }

        /// <summary>
        /// 获取剩余短信
        /// </summary>
        /// <returns></returns>
        public static int GetLeftSmsNum()
        {
            string sn = (string)ConfigurationManager.AppSettings["sn"];
            string pwd = (string)ConfigurationManager.AppSettings["pwd"];
            cn.entinfo.sdk3.WebService ws = new cn.entinfo.sdk3.WebService();
            //检验余额
            string Overage = ws.GetBalance(sn, pwd);
            int money = Utils.StrToInt(Overage, 0);
            return money;
        }

    }
}