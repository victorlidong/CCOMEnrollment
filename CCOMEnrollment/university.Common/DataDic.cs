using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace university.Common
{
    public class DataDic
    {



        public const int MUST = 1;
        public const int NOT_MUST = 0;
        public const int ACTIVE = 1;
        public const int NOT_ACTIVE = 0;
        public const int IS_RSS = 1;
        public const int IS_NOT_RSS = 0;
        public const int IDType_NchId = 1;
        public const int IDType_CmpId = 2;
        /// <summary>
        /// 频道调用代码
        /// </summary>
        public const String SYS_CHANNEL = "sysinfo";
        public const String SOCIETY_CHANNEL = "society";
        public const String CAMPUS_CHANNEL = "campus";
        public const String OFFICE_CHANNEL = "office";
        public const String PARTY_CHANNEL = "party";

        /// <summary>
        /// 文件上传路径
        /// </summary>
        public const String Channel_Logo_Path = "/upload/news/logo/";
        public const String User_Face_Path = "/upload/users/face/";
        public const String News_Attach_Path = "/upload/news/attach/";
        public const String Notice_Attach_Path = "/upload/notice/attach/";
        public const String Files_Upload_Path = "/upload/Files/";

        /// <summary>
        /// 图片上传路径
        /// </summary>
        public const string UP_ID_picture_Path = "/upload/user/UP_ID_picture/";//证件复印件图片
        public const string UP_picture_Path = "/upload/user/UP_picture/";//近期免冠照片
        public const string UP_AEE_picture_Path = "/upload/user/UP_AEE_picture/";//省联考合格证
        public const string FILE_URL = "http://localhost:20000/";



        public const String Task_Attach_Path = "/upload/task/attach/";

        public const String Batch_Path = "/upload/temp/batch/";


        public const String News_Pic_WebPath = "/upload/news/pic/web/";
        public const String News_Pic_AppPath = "/upload/news/pic/"; //新闻内容中的图片默认存储app新闻图片的路径

        public const String Channel_Default_Logo = "/images/news/logo/default.png";

        //默认logo
        public const String Sys_Channel_DefaultLogo = "/images/news/logo/sys_default_logo.png";
        public const String Campus_Channel_DefaultLogo = "/images/news/logo/campu_default_logo.png";
        public const String Society_Channel_DefaultLogo = "/images/news/logo/society_default_logo.png";
        public const String Office_Channel_DefaultLogo = "/images/news/logo/office_default_logo.png";

        //置顶新闻数
        public const int TOP_NEWS_LIMIT = 8;



        //字段来源设置
        public const int FieldSource_ErrorProperty = -1;  //无意义的
        public const int FieldSource_SystemProperty = 0;  //系统字段
        public const int FieldSource_StudataProperty = 1;  //属性类数据项
        public const int FieldSource_StudataExperience = 2; //经历类数据项
        public const int FieldSource_StudataExperienceProperty = 3;  //经历类数据项属性
        public const int FieldSource_IndependentAdd = 4;  //自主添加

        //学生数据中心字段类型，1属性类，2记录类
        public const int StuData_DIType_Property = 1;
        public const int StuData_DIType_Experience = 2;

        //0:管理员用户/1:校园用户/2:社会用户
        public const int UserType_SchoolUser = 1;
        public const int UserType_AdminUser = 0;
        public const int UserType_SocialUser = 2;


        //数据项类型
        //--1-input;2-textarea;3-radio;4-select;5-checkbox;6-file;7-time，8-经历类数据项
        public const int ItemType_Input = 1;
        public const int ItemType_Textarea = 2;
        public const int ItemType_Radio = 3;
        public const int ItemType_Select = 4;
        public const int ItemType_Checkbox = 5;
        public const int ItemType_File = 6;
        public const int ItemType_Time = 7;
        public const int ItemType_StudataExperience = 8;
        public const int ItemType_Label = 9;

        //数据项类型
        //--1-input;2-textarea;3-radio;4-select;5-checkbox;6-file;7-time，8-经历类数据项
        public const string ItemTypeCode_Input = "input";
        public const string ItemTypeCode_Textarea = "textarea";
        public const string ItemTypeCode_Radio = "radio";
        public const string ItemTypeCode_Select = "select";
        public const string ItemTypeCode_Checkbox = "checkbox";
        public const string ItemTypeCode_File = "file";
        public const string ItemTypeCode_Time = "time";

        //apply_type 1表示普通，2表示考核，默认为1
        public const int ApplyType_Approve = 1;
        //public const int ApplyType_Scholarship = 2; //带表格的
        public const int ApplyType_Examine = 2; //考核

        //1.apply_status:1-开启；0-关闭，-1表示还未完成发布，中途保存,默认-1
        public const int ApplyStatus_Save = -1;
        public const int ApplyStatus_Open = 1;
        public const int ApplyStatus_Close = 2; 


        //1.check_status:1-通过；0-未通过，-1表示还未完成发布，中途保存,默认-1
        public const int CheckStatus_Pass = 1;
        public const int CheckStatus_Fail = 0;


        public const int PrimaryKeyType_RoleId = 2;
        public const int PrimaryKeyType_UserId = 1;


        //申报用户ApplyUser的来源，1表示来自组织机构，2是来自通信组，3是来自学校通讯录
        public const int ApplyUserSrc_Org = 1;
        public const int ApplyUserSrc_Group = 2;
        public const int ApplyUserSrc_SchoolContact = 3;


        //审批条目的状态
        public const int Check_NotCheck = 1;
        public const int Check_YES = 2;
        public const int Check_NO = 3;



        //考核条目的状态
        public const int Exam_NotExam = 0;
        public const int Exam_NotCheck = 1;
        public const int Exam_CheckYes = 2;
        public const int Exam_CheckNo = 3;

        //考核条目的状态
        public const string Exam_NotExamText = "未考核";
        public const string Exam_NotCheckText = "未审核";
        public const string Exam_CheckYesText = "审核通过";
        public const string Exam_CheckNoText = "审核未通过";


        //审批条目的显示内容
        public const string Check_NotCheckText = "未审批";
        public const string Check_YesText = "通过";
        public const string Check_NoText = "驳回";



        //用于Task_info和Task_user表
        //Task_info是任务主表，Task_user是任务执行人和执行情况
        //任务的状态
        public const int Task_NotRead = -1;
        public const int Task_NotFinish = 0;
        public const int Task_Overdue = 1;
        public const int Task_Finished = 2;

        //任务的状态
        public const string Task_NotReadText = "未查看";
        public const string Task_NotFinishText = "进行中";
        public const string Task_OverdueText = "已过期";
        public const string Task_FinishedText = "已完成";


        public const int NoneID = -1;

        //功能的层级
        public const int Father_Function = 0;


        //周期状态
        public const int Period_state_On = 1;
        public const int Period_state_Close = 0;

        //最顶层机构ID
        public const int CCOM_Agency_id = 1;

        //系机构的类型
        public const int CCOM_Clique_type = 2;

        //专业方向机构的类型
        public const int CCOM_Major_type = 3;


        //考生状态
        public const int UP_calculation_status_off = 0;   //未报名成功
        public const int UP_calculation_status_on = 1;    //报名缴费成功
        public const int UP_calculation_status_preliminary = 2;  //进入复试
        public const int UP_calculation_status_CEE = 3;     //进入文考（高考）
        public const int UP_calculation_status_admit = 4;   //录取

        public class HiddenDataItem{
            public string key = "";
            public string title = "";
            public long id = 0;
            public int src = FieldSource_ErrorProperty;
            public int activity = 0;
        }

        public class ApplyUserDepartment
        {
            public List<Int32> depList;
            public List<Int64> userList;
            public List<String> orgUserList;
            public long applyId;
            public int isSms = 0;
            public int isPush = 0;
        }

    }
}