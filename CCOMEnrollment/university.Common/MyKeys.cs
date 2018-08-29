using System;
using System.Collections.Generic;
using System.Text;

namespace university.Common
{
    public class MyKeys
    {
        //系统版本
        /// <summary>
        /// 版本号全称
        /// </summary>
        public const string ASSEMBLY_VERSION = "1.0";
        /// <summary>
        /// 版本年号
        /// </summary>
        public const string ASSEMBLY_YEAR = "2014";
        //File======================================================
        /// <summary>
        /// 插件配制文件名
        /// </summary>
        public const string FILE_PLUGIN_XML_CONFING = "plugin.config";
        /// <summary>
        /// 站点配置文件名
        /// </summary>
        public const string FILE_SITE_XML_CONFING = "Configpath";
        /// <summary>
        /// URL配置文件名
        /// </summary>
        public const string FILE_URL_XML_CONFING = "Urlspath";
        /// <summary>
        /// 用户配置文件名
        /// </summary>
        public const string FILE_USER_XML_CONFING = "Userpath";
        //Directory==================================================
        /// <summary>
        /// ASPX目录
        /// </summary>
        public const string DIRECTORY_REWRITE_ASPX = "aspx";
        /// <summary>
        /// HTML目录
        /// </summary>
        public const string DIRECTORY_REWRITE_HTML = "html";

        //Cache======================================================
        /// <summary>
        /// 站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG = "cache_site_config";
        /// <summary>
        /// 用户配置
        /// </summary>
        public const string CACHE_USER_CONFIG = "cache_user_config";
        /// <summary>
        /// 客户端站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG_CLIENT = "cache_site_client_config";
        /// <summary>
        /// HttpModule映射类
        /// </summary>
        public const string CACHE_SITE_HTTP_MODULE = "cache_http_module";
        /// <summary>
        /// URL重写映射表
        /// </summary>
        public const string CACHE_SITE_URLS = "cache_site_urls";
     

        //Session=====================================================
        /// <summary>
        /// 验证码
        /// </summary>
        public const string SESSION_CODE = "session_code";
        /// <summary>
        /// 后台管理员
        /// </summary>
        public const string SESSION_ADMIN_INFO = "session_admin_info";
        /// <summary>
        /// 会员用户
        /// </summary>
        public const string SESSION_USER_INFO = "session_user_info";

        /// <summary>
        /// 校级管理员，内存储加密后的验证码，不为空说明验证通过
        /// </summary>
        public const string SESSION_SCHOOL_ADMINUSER = "session_school_adminuser";

        //Cookies=====================================================
        /// <summary>
        /// 防重复顶踩KEY
        /// </summary>
        public const string COOKIE_DIGG_KEY = "cookie_digg_key";
        /// <summary>
        /// 防重复评论KEY
        /// </summary>
        public const string COOKIE_COMMENT_KEY = "cookie_comment_key";
        /// <summary>
        /// 防止下载重复扣各分
        /// </summary>
        public const string COOKIE_DOWNLOAD_KEY = "download_attach_key";
        /// <summary>
        /// 记住选择的学校
        /// </summary>
        public const string COOKIE_USER_SCHOOL_REMEMBER = "cookie_school_remember";
        /// <summary>
        /// 记住登录方式
        /// </summary>
        public const string COOKIE_USER_LOGINTYPE_REMEMBER = "cookie_logintype_remember";
        /// <summary>
        /// 记住会员用户名
        /// </summary>
        public const string COOKIE_USER_NAME_REMEMBER = "cookie_user_name_remember";
        /// <summary>
        /// 记住会员密码
        /// </summary>
        public const string COOKIE_USER_PWD_REMEMBER = "cookie_user_pwd_remember";
        /// <summary>
        /// 返回上一页
        /// </summary>
        public const string COOKIE_URL_REFERRER = "cookie_url_referrer";


        /// <summary>
        /// 返回上一页
        /// </summary>
        public const string COOKIE_SELECTSTATUS = "cookie_select_status";

        /// <summary>
        /// APIUniversity的Token
        /// </summary>
        public const string Token_APIUniversity = "zhchonga";

        /// <summary>
        /// API中用到的DES加密的Key
        /// </summary>
        public const string API_DES_KEY = "zhchonga";

        /// <summary>
        /// 用户身份表名称的Session
        /// </summary>
        public const string SESSION_USER_TABLE = "session_admin_table";

        /// <summary>
        /// 用户身份小表的Session
        /// </summary>
        public const string SESSION_USER_STATUSID = "session_admin_us";

        /// <summary>
        /// 用户学校的ID
        /// </summary>
        public const string SESSION_USER_SCHOOL = "session_user_school";

        /// <summary>
        /// 手机验证码
        /// </summary>
        public const string SESSION_PHONE_CODE = "session_phone_code";

        /// <summary>
        /// 手机验证码发送时间
        /// </summary>
        public const string SESSION_PHONE_CODE_TIME = "session_phone_code_time";

        /// <summary>
        /// 用户学校的ID
        /// </summary>
        public const string REGIST_KEY = "qqregist";

        /// <summary>
        /// 验证码
        /// </summary>
        public const string NEED_VCODE = "need_vcode";

        /// <summary>
        /// 批量导入学生加密之后的UserID_List
        /// </summary>
        public const string IMPORT_USERID = "import_userid";

        /// <summary>
        /// 批量导入学生加密之后的SchoolUserID_List
        /// </summary>
        public const string IMPORT_STUUSERID = "import_stuuserid";

        /// <summary>
        /// 记录批量导入信件信息的成功记录ID
        /// </summary>
        public const string COOKIE_SUCCESSFUL_LETTERID = "cookie_successful_letterid";

        /// <summary>
        /// 选中社团组织人员OAM_IDList的加密结果
        /// </summary>
        public const string SELECTED_OAMID = "selected_oamid";

        /// <summary>
        /// 用户第一次登录标识
        /// </summary>
        public const string SESSION_FIRST_LOGIN = "sesion_first_login";
    }
}
