using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace university.Web.AdminMetro.CCOM.notice
{
    public class SmsConfig
    {

        //申请阈值（低于提醒申请）
        public const int ApplyThreshold = 1001;
        //首次申请条数
        public const int FirstApplyNumber = 1000;

        //申请类型
        public const int Type_FirstApply = 1;
        public const int Type_SelfApply = 2;
        public const int Type_LoginApply = 3;

        //申请状态
        public const int Status_Applying = 1;
        public const int Status_Success = 2;
        public const int Status_Fail = 0;
        //默认申请理由
        public const String DefaultApplyReason = "因办公通知提醒需求量大，特申请短信发送，望批准！";
        //70字一条短信
        public const int LengthPerSms = 70;

        //获取申请类型描述
        public static String GetApplyTypeStr(int type)
        {
            var typeName = "";
            switch (type)
            {
                case Type_FirstApply:
                    typeName = "首次赠送";
                    break;
                case Type_SelfApply:
                    typeName = "自主申请";
                    break;
                case Type_LoginApply:
                    typeName = "登录赠送";
                    break;
                default:
                    typeName = "";
                    break;
            }
            return typeName;
        }
        //获取申请状态描述
        public static String GetApplyStatusStr(int type)
        {
            var typeName = "";
            switch (type)
            {
                case Status_Applying:
                    typeName = "审核中";
                    break;
                case Status_Success:
                    typeName = "成功";
                    break;
                case Status_Fail:
                    typeName = "失败";
                    break;
                default:
                    typeName = "";
                    break;
            }
            return typeName;
        }

    }
}