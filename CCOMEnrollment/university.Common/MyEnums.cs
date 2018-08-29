using System;
using System.Collections.Generic;
using System.Text;

namespace university.Common
{
    public class MyEnums
    {
        /// <summary>
        /// 统一管理操作枚举
        /// </summary>
        public enum ActionEnum
        {
            /// <summary>
            /// 所有
            /// </summary>
            All,
            /// <summary>
            /// 查看
            /// </summary>
            View,
            /// <summary>
            /// 添加
            /// </summary>
            Add,
            /// <summary>
            /// 修改
            /// </summary>
            Edit,
            /// <summary>
            /// 删除
            /// </summary>
            Delete,
            /// <summary>
            /// 审核
            /// </summary>
            Audit,
            /// <summary>
            /// 回复
            /// </summary>
            Reply,
            /// <summary>
            /// 取消
            /// </summary>
            Cancel,
            /// <summary>
            /// 作废
            /// </summary>
            Invalid
        }

        /// <summary>
        /// 属性类型枚举
        /// </summary>
        public enum AttributeEnum
        {
            /// <summary>
            /// 输入框
            /// </summary>
            Text,
            /// <summary>
            /// 下拉框
            /// </summary>
            Select,
            /// <summary>
            /// 单选框
            /// </summary>
            Radio,
            /// <summary>
            /// 复选框
            /// </summary>
            CheckBox
        }

        /// <summary>
        /// 用户生成码枚举
        /// </summary>
        public enum CodeEnum
        {
            /// <summary>
            /// 邮箱验证注册
            /// </summary>
            RegVerify,
            /// <summary>
            /// 邀请注册
            /// </summary>
            Register,
            /// <summary>
            /// 取回密码
            /// </summary>
            Password,
        }

        /// <summary>
        /// 金额类型枚举
        /// </summary>
        public enum AmountTypeEnum
        {
            /// <summary>
            /// 系统赠送
            /// </summary>
            SysGive,
            /// <summary>
            /// 在线充值
            /// </summary>
            Recharge,
            /// <summary>
            /// 用户消费
            /// </summary>
            Consumption,
            /// <summary>
            /// 购买商品
            /// </summary>
            BuyGoods,
            /// <summary>
            /// 积分兑换
            /// </summary>
            Convert
        }
        /// <summary>
        /// 跳转错误类型枚举
        /// </summary>
        public enum RediirectErrorEnum 
        {
            /// <summary>
            /// 未登录
            /// </summary>
            SessionNull,
            /// <summary>
            /// 身份
            /// </summary>
            FunIDNull,
            /// <summary>
            /// 非管理员
            /// </summary>
            NotAdmin,
            /// <summary>
            /// 参数错误
            /// </summary>
            ParameterError,
            /// <summary>
            /// http链接错误
            /// </summary>
            HttpError
        }

        /// <summary>
        /// 用户身份类型枚举
        /// </summary>
        public enum UserStatus
        {
            /// <summary>
            /// schooluser
            /// </summary>
            App_Universities_SchoolUser=0,
            /// <summary>
            /// socialuser
            /// </summary>
            App_Universities_SocialUser=1,
            /// <summary>
            /// adminuser
            /// </summary>
            App_Universities_AdminUser=2
        }
    }
}
