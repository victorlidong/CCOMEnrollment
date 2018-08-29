using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using university.Web.tools;

namespace university.Web.AdminMetro.CCOM.notice
{
    public partial class ApplySms : university.UI.ManagePage
    {
        public ApplySms()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var userId = GetAdminInfo_CCOM().User_id;
                var bll = new BLL.CCOM.User_sms();
                if (bll.IsFirstApplySmsNumber(userId))
                {
                    this.divFirstApply.Visible = true;
                    this.divNormalApply.Visible = false;
                }
                else
                {
                    this.divFirstApply.Visible = false;
                    this.divNormalApply.Visible = true;
                    this.txtNumber.Text = SmsConfig.FirstApplyNumber.ToString();
                    this.txtReason.Text = SmsConfig.DefaultApplyReason;
                    //判断是否已有申请记录
                    if (new BLL.CCOM.SMS_apply_record().IsApplyStatus(userId, SmsConfig.Status_Applying))
                    {
                        this.txtNumber.Enabled = false;
                        this.txtReason.Enabled = false;
                        this.btnApply.Enabled = false;
                        var url = "ApplyRecord.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id);
                        this.lblWarning.Text = "<b style='color:red;'>申请审核中</b>，<a class='btn' href='javascript:void(0);' onclick='gotoApplyRecord(\"" + url + "\")'>点此查看申请结果</a>";
                    }
                }
            }

        }
        protected void btnFirstApply_Click(object sender, EventArgs e)
        {
            var userId = GetAdminInfo_CCOM().User_id;
            var bll = new BLL.CCOM.User_sms();
            if (bll.IsFirstApplySmsNumber(userId))
            {
                //申请
                var m = new Model.CCOM.User_sms()
                {
                    User_id = userId,
                    User_sms_left = SmsConfig.FirstApplyNumber,
                    User_sms_create_time=DateTime.Now
                };
                if (bll.Add(m) > 0)
                {
                    var rm = new Model.CCOM.SMS_apply_record()
                    {
                        SMS_apply_number = SmsConfig.FirstApplyNumber,
                        SMS_apply_status = SmsConfig.Status_Success,
                        SMS_apply_reason = "",
                        SMS_apply_type = SmsConfig.Type_FirstApply,
                        SMS_give_number = SmsConfig.FirstApplyNumber,
                        User_id = userId,
                        SMS_apply_time=DateTime.Now
                    };
                    new BLL.CCOM.SMS_apply_record().Add(rm);
                    var number = bll.GetModel(" User_id="+userId).User_sms_left;
                    //申请成功
                    JscriptReponse("applySuccess('免费短信领取成功啦！',1," + number + ")");
                }
                else
                {
                    this.lblFirstApply.Text = "Sorry，福利获取失败！";
                }
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            var userId = GetAdminInfo_CCOM().User_id;
            var bll = new BLL.CCOM.User_sms();
            if (!bll.IsFirstApplySmsNumber(userId))
            {
                var numberStr = this.txtNumber.Text;
                var reason = this.txtReason.Text;
                if (!Common.Utils.IsNumeric(numberStr))
                {
                    this.lblApply.Text = "申请条数不合法！";
                    return;
                }
                if(reason.Length<=0)
                {
                    this.lblApply.Text = "申请理由不能为空！";
                    return;
                }
                var number = int.Parse(numberStr);
                if (number < 1)
                {
                    this.lblApply.Text = "申请条数不合法！";
                    return;
                }
                reason = reason.Replace("'", "");
                if(Tools.CheckParams(reason))
                {
                    this.lblApply.Text = "申请理由中不能包含非法字符！";
                    return;
                }
                var rm = new Model.CCOM.SMS_apply_record()
                {
                    SMS_apply_number = number,
                    SMS_apply_status = SmsConfig.Status_Applying,
                    SMS_apply_reason = reason,
                    SMS_apply_type = SmsConfig.Type_SelfApply,
                    User_id = userId,
                    SMS_apply_time = DateTime.Now,
                };
                if (new BLL.CCOM.SMS_apply_record().Add(rm) > 0)
                {

                    //申请成功
                    ThreadPool.UnsafeQueueUserWorkItem(SendSmsApplyRemind, GetRemindContent(number, reason));
                    JscriptReponse("applySuccess('申请成功，请等待管理员审核！',0)");
                }
                else
                {
                    this.lblApply.Text = "Sorry，短信申请失败！";
                }
            }
        }

        protected String GetRemindContent(int number, String reason)
        {
            var sb = new StringBuilder();
            sb.Append("新的短信申请信息：<br />");
            sb.Append("【申请人】：").Append(GetAdminInfo_CCOM().User_realname).Append("<br />");
            sb.Append("【申请条数】：").Append(number).Append("<br />");
            sb.Append("【申请理由】：").Append(reason).Append("<br />");
            sb.Append("<br />请您及时中央音乐学院招生系统进行审批！<br />");
            sb.Append("中央音乐学院招生系统登录地址：http://" + Common.MyRequest.GetCurrentFullHost() + "<br />");
            sb.Append("来自：中央音乐学院");
            return sb.ToString();
        }
        protected static void SendSmsApplyRemind(object state)
        {
            try
            {
                var content = state as String;
                ManageReminder.Send("短信申请审核提示", content);
            }
            catch (Exception)
            {

            }
        }
    }
}