//字段来源设置
var FieldSource_ErrorProperty = -1;  //无意义的
var FieldSource_SystemProperty = 0;  //系统字段
var FieldSource_StudataProperty = 1;  //属性类数据项
var FieldSource_StudataExperience = 2; //经历类数据项
var FieldSource_StudataExperienceProperty = 3;  //经历类数据项属性
var FieldSource_IndependentAdd = 4;  //自主添加

//学生数据中心字段类型，1属性类，2记录类
var StuData_DIType_Property = 1;
var StuData_DIType_Experience = 2;

//0:管理员用户/1:校园用户/2:社会用户
var UserType_SchoolUser = 1;
var UserType_AdminUser = 0;
var UserType_SocialUser = 2;

//数据项类型
//--1-input;2-textarea;3-radio;4-select;5-checkbox;6-file;7-time，8-经历类数据项
var ItemType_Input = 1;
var ItemType_Textarea = 2;
var ItemType_Radio = 3;
var ItemType_Select = 4;
var ItemType_Checkbox = 5;
var ItemType_File = 6;
var ItemType_Time = 7;
var ItemType_StudataExperience = 8;
var ItemType_Label = 9;

//apply_type 1表示普通，2表示奖学金，默认为1
var ApplyType_Common = 1;
var ApplyType_Scholarship = 2; //带表格的


