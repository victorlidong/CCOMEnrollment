using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university.Common;
using System.Web.UI.WebControls;
using System.Text;
namespace university.Web.AdminMetro.CCOM.notice
{
    public class SmsHelper
    {
        /// <summary>
        //根据用户Id列表发送短信
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="content"></param>
        public static String SendSmsNotice(List<string> userIdList, String content, long userId)
        {
            var userName = new BLL.CCOM.User_information().GetModel(userId).User_realname;
            if (userName != "")
            {
                userName = "(" + userName + ")";
            }
            if (new BLL.CCOM.User_sms().GetModel(" User_id="+userId).User_sms_left > 0)
            {
                var ml =
                    new BLL.CCOM.User_information().GetModelList(" User_id in(" +
                                                                       String.Join(",", userIdList.ToArray()) + ")");
                var phoneList = new List<String>();
                foreach (var m in ml)
                {
                    phoneList.Add(m.User_phone);
                }
                var res = ManDaoSMS.SendSMS(String.Join(",", phoneList.ToArray()), content + userName);
                if (res == ManDaoSMS.RESULT_SUCCESS)
                {
                    //扣费
                    //ReduceUserSmsNumber(userId, phoneList.Count, content);
                }
                return res;
            }
            return "no sms";
        }

        //根据用户手机号列表发送
        public static String SendSmsByPhone(List<String> phoneList, String content, long userId)
        {
            var userName =new BLL.CCOM.User_information().GetModel(userId).User_realname;
            if (userName != "")
            {
                userName = "(" + userName + ")";
            }
            if (new BLL.CCOM.User_sms().GetModel(" User_id=" + userId).User_sms_left > 0)
            {
                var res = ManDaoSMS.SendSMS(String.Join(",", phoneList.ToArray()), content + userName);
                if (res == ManDaoSMS.RESULT_SUCCESS)
                {
                    //扣费
                    //ReduceUserSmsNumber(userId, phoneList.Count, content);
                }
                return res;
            }
            return "no sms";
        }

        //短信条数计算
        //private static void ReduceUserSmsNumber(long userId, int cnt, String content)
        //{
        //    int times = (content.Length) / SmsConfig.LengthPerSms + 1;
        //    var bll = new BLL.CCOM.User_sms();
        //    var ml = bll.GetModelList(" User_id=" + userId);
        //    if (ml != null && ml.Count > 0)
        //    {
        //        ml[0].User_sms_left -= cnt * times;
        //        bll.Update(ml[0]);
        //    }
        //}

        //public static void ShowSmsLeftNumber(Label lbl, long userId)
        //{
        //    var number = new BLL.CCOM.User_sms().GetModel(" User_id="+userId).User_sms_left;
        //    var sb = new StringBuilder();
        //    sb.Append("<span style='color:red;'>（剩余短信：<span id='smsCnt'>").Append(number).Append("</span>");
        //    if (number < SmsConfig.ApplyThreshold)
        //    {
        //        sb.Append("&nbsp;&nbsp;<b><a href=javascript:void(0); onclick='applySms()'>").Append("申请短信").Append("</a></b>");
        //    }
        //    sb.Append("）</span>");
        //    lbl.Text = sb.ToString();
        //}
        //public static void ShowSmsLeftNumberNoApply(Label lbl, long userId)
        //{
        //    var number = new BLL.CCOM.User_sms().GetModel(" User_id=" + userId).User_sms_left;
        //    var sb = new StringBuilder();
        //    sb.Append("<span style='color:red;'>（剩余短信：<span id='smsCnt'>").Append(number).Append("</span>");
        //    sb.Append("）</span>");
        //    lbl.Text = sb.ToString();
        //}
    }
}