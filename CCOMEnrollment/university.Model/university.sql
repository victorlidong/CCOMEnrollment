if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_AdminUser') and o.name = 'AdminUserUserID')
alter table App_Universities_AdminUser
   drop constraint AdminUserUserID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_AdminUser') and o.name = 'AdminUserUO_ID')
alter table App_Universities_AdminUser
   drop constraint AdminUserUO_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_AdminUser') and o.name = 'AdminUserAdminID')
alter table App_Universities_AdminUser
   drop constraint AdminUserAdminID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'Mother')
alter table App_Universities_SchoolUser
   drop constraint Mother
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'UTD_ID')
alter table App_Universities_SchoolUser
   drop constraint UTD_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'USD_ID')
alter table App_Universities_SchoolUser
   drop constraint USD_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'UEB_ID')
alter table App_Universities_SchoolUser
   drop constraint UEB_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'SchoolUserAdminID')
alter table App_Universities_SchoolUser
   drop constraint SchoolUserAdminID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'UD_ID')
alter table App_Universities_SchoolUser
   drop constraint UD_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'UST_ID')
alter table App_Universities_SchoolUser
   drop constraint UST_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'SchoolUserUserID')
alter table App_Universities_SchoolUser
   drop constraint SchoolUserUserID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'SchoolUserUS_ID')
alter table App_Universities_SchoolUser
   drop constraint SchoolUserUS_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'SchoolUserUO_ID')
alter table App_Universities_SchoolUser
   drop constraint SchoolUserUO_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SchoolUser') and o.name = 'Father')
alter table App_Universities_SchoolUser
   drop constraint Father
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SecondaryDiscipline') and o.name = 'TOPID')
alter table App_Universities_SecondaryDiscipline
   drop constraint TOPID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SocialUser') and o.name = 'SocialUserUserID')
alter table App_Universities_SocialUser
   drop constraint SocialUserUserID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_SocialUser') and o.name = 'SocialUserUS_ID')
alter table App_Universities_SocialUser
   drop constraint SocialUserUS_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_UserInfo') and o.name = 'UN_ID')
alter table App_Universities_UserInfo
   drop constraint UN_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_UserInfo') and o.name = 'UPL_ID')
alter table App_Universities_UserInfo
   drop constraint UPL_ID
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('App_Universities_UserRight') and o.name = 'AdminUserID')
alter table App_Universities_UserRight
   drop constraint AdminUserID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_AdminUser')
            and   type = 'U')
   drop table App_Universities_AdminUser
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_Degree')
            and   type = 'U')
   drop table App_Universities_Degree
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_EducationalBackground')
            and   type = 'U')
   drop table App_Universities_EducationalBackground
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_Nation')
            and   type = 'U')
   drop table App_Universities_Nation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_Organization')
            and   type = 'U')
   drop table App_Universities_Organization
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_PoliticalLandscape')
            and   type = 'U')
   drop table App_Universities_PoliticalLandscape
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_SchoolUser')
            and   type = 'U')
   drop table App_Universities_SchoolUser
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_SecondaryDiscipline')
            and   type = 'U')
   drop table App_Universities_SecondaryDiscipline
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_SocialUser')
            and   type = 'U')
   drop table App_Universities_SocialUser
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_StudentType')
            and   type = 'U')
   drop table App_Universities_StudentType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_TopDiscipline')
            and   type = 'U')
   drop table App_Universities_TopDiscipline
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_UserInfo')
            and   type = 'U')
   drop table App_Universities_UserInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_UserRight')
            and   type = 'U')
   drop table App_Universities_UserRight
go

if exists (select 1
            from  sysobjects
           where  id = object_id('App_Universities_UserStatus')
            and   type = 'U')
   drop table App_Universities_UserStatus
go

/*==============================================================*/
/* Table: App_Universities_AdminUser                            */
/*==============================================================*/
create table App_Universities_AdminUser (
   AdminUserID          bigint               identity(1,1),
   UserID               bigint               not null,
   UO_ID                int                  not null,
   AdminUser_Role       varchar(200)         null,
   AdminUser_HomeProvince int                  null,
   AdminUser_HomeCity   int                  null,
   AdminUser_OfficeAddress varchar(200)         null,
   AdminUser_OfficePhone varchar(30)          null,
   AdminUser_Activtiy   int                  not null default 1,
   AdminUser_Time       datetime             not null default getdate(),
   AdminUser_IP         varchar(200)         not null,
   AdminUser_UserID     bigint               not null,
   constraint PK_APP_UNIVERSITIES_ADMINUSER primary key (AdminUserID)
)
go

/*==============================================================*/
/* Table: App_Universities_Degree                               */
/*==============================================================*/
create table App_Universities_Degree (
   UD_ID                int                  identity(1,1),
   UD_Name              varchar(200)         not null,
   UD_FirstLetter       varchar(10)          not null,
   constraint PK_APP_UNIVERSITIES_DEGREE primary key (UD_ID)
)
go

/*==============================================================*/
/* Table: App_Universities_EducationalBackground                */
/*==============================================================*/
create table App_Universities_EducationalBackground (
   UEB_ID               int                  identity(1,1),
   UEB_Name             varchar(200)         not null,
   UEB_FirstLetter      varchar(10)          not null,
   constraint PK_APP_UNIVERSITIES_EDUCATIONA primary key (UEB_ID)
)
go

/*==============================================================*/
/* Table: App_Universities_Nation                               */
/*==============================================================*/
create table App_Universities_Nation (
   UN_ID                int                   identity(1,1),
   UN_Name              varchar(200)         not null,
   UN_FirstLetter       varchar(10)          not null,
   constraint PK_APP_UNIVERSITIES_NATION primary key (UN_ID)
)
go

/*==============================================================*/
/* Table: App_Universities_Organization                         */
/*==============================================================*/
create table App_Universities_Organization (
   UO_ID                int                  identity(1,1),
   UI_ID                int                  null,
   UO_Name              varchar(300)         not null,
   UO_Level             int                  not null,
   UO_Sort              int                  not null,
   UO_FatherID          int                  not null,
   UO_Activity          int                  not null default 1,
   UO_Time              datetime             not null default getdate(),
   UO_IP                varchar(200)         null,
   UO_AdminID           int                  not null,
   constraint PK_APP_UNIVERSITIES_ORGANIZATI primary key (UO_ID),
   constraint AK_UI_ID_APP_UNIV unique (UI_ID)
)
go

/*==============================================================*/
/* Table: App_Universities_PoliticalLandscape                   */
/*==============================================================*/
create table App_Universities_PoliticalLandscape (
   UPL_ID               int                  identity(1,1),
   UPL_Name             varchar(200)         not null,
   UPL_FirstLetter      varchar(10)          not null,
   constraint PK_APP_UNIVERSITIES_POLITICALL primary key (UPL_ID)
)
go

/*==============================================================*/
/* Table: App_Universities_SchoolUser                           */
/*==============================================================*/
create table App_Universities_SchoolUser (
   SchoolUserID         bigint               identity(1,1),
   UserID               bigint               not null,
   UO_ID                int                  not null,
   US_ID                int                  not null,
   SchoolUser_No        varchar(50)          not null,
   SchoolUser_EntranceTime datetime             not null default getdate(),
   SchoolUser_State     int                  not null default 1,
   SchoolUser_SchoolAddress varchar(200)         null,
   SchoolUser_HomeProvince int                  null,
   SchoolUser_HomeCity  int                  null,
   SchoolUser_FatherID  bigint               null,
   SchoolUser_MotherID  bigint               null,
   UTD_ID               int                  null,
   USD_ID               int                  null,
   UST_ID               int                  null,
   SchoolUser_Specialty varchar(200)         null,
   UD_ID                int                  not null,
   UEB_ID               int                  not null,
   AdminID              bigint               null,
   LastAdminTime        datetime             null,
   SchoolUser_Activity  int                  not null default 1,
   constraint PK_APP_UNIVERSITIES_SCHOOLUSER primary key (SchoolUserID)
)
go

/*==============================================================*/
/* Table: App_Universities_SecondaryDiscipline                  */
/*==============================================================*/
create table App_Universities_SecondaryDiscipline (
   USD_ID               int                  identity(1,1),
   TopID                int                  not null,
   USD_Name             varchar(200)         not null,
   USD_No               varchar(20)          not null,
   USD_FirstLetter      varchar(10)          not null,
   constraint PK_APP_UNIVERSITIES_SECONDARYD primary key (USD_ID),
   constraint AK_USD_NO_APP_UNIV unique (USD_No)
)
go

/*==============================================================*/
/* Table: App_Universities_SocialUser                           */
/*==============================================================*/
create table App_Universities_SocialUser (
   SocialUserID         bigint               identity(1,1),
   UserID               bigint               not null,
   UserType             int                  null,
   SocialUser_HomeProvince int                  null,
   SocialUser_HomeCity  int                  null,
   SocialUser_WorkUnit  varchar(200)         null,
   SocialUser_Activity  int                  not null default 1,
   constraint PK_APP_UNIVERSITIES_SOCIALUSER primary key (SocialUserID)
)
go

/*==============================================================*/
/* Table: App_Universities_StudentType                          */
/*==============================================================*/
create table App_Universities_StudentType (
   UST_ID               int                  identity(1,1),
   UST_Name             varchar(200)         not null,
   UST_FirstLetter      varchar(10)          not null,
   constraint PK_APP_UNIVERSITIES_STUDENTTYP primary key (UST_ID)
)
go

/*==============================================================*/
/* Table: App_Universities_TopDiscipline                        */
/*==============================================================*/
create table App_Universities_TopDiscipline (
   UTD_ID               int                  identity(1,1),
   UTD_Name             varchar(200)         not null,
   UTD_No               varchar(20)          not null,
   UTD_FirstLetter      varchar(10)          not null,
   constraint PK_APP_UNIVERSITIES_TOPDISCIPL primary key (UTD_ID),
   constraint AK_UTD_NO_APP_UNIV unique (UTD_No)
)
go

/*==============================================================*/
/* Table: App_Universities_UserInfo                             */
/*==============================================================*/
create table App_Universities_UserInfo (
   UserID               bigint               identity(1,1),
   UI_RealName          varchar(200)         not null,
   UI_LoginName         varchar(200)         not null,
   UI_NickName          varchar(200)         null,
   UI_PWD               varchar(200)         not null,
   UI_Sex               tinyint              not null default 1,
   UI_NationID          int                  not null,
   UPL_ID               int                  null,
   UI_Email             varchar(100)         null,
   UI_Intro             varchar(400)         null,
   UI_Face              varchar(200)         null,
   UI_Mobile            varchar(30)          null,
   UI_QQ                varchar(30)          null,
   UI_WeiXin            varchar(200)         null,
   UI_Birthday          datetime             null,
   UI_IdentityID        varchar(150)         null,
   UI_WeiBo             varchar(200)         null,
   UI_HomeAddress       varchar(400)         null,
   UI_ZipCode           varchar(50)          null,
   UI_EndTime           datetime             not null default getdate(),
   UI_LastIP            varchar(100)         null,
   UI_LastModifyTime    datetime             not null default getdate(),
   UI_PrivacyState      int                  not null default 2,
   UI_Activtity         int                  not null default 1,
   SchoolUser_AccountRelation bigint               not null default 0,
   SocialUser_AccountRelation bigint               not null default 0,
   AdminUser_AccountRelation bigint               not null default 0,
   constraint PK_APP_UNIVERSITIES_USERINFO primary key (UserID),
   constraint AK_UI_LOGINNAME_APP_UNIV unique (UI_LoginName),
   constraint AK_UI_EMAIL_APP_UNIV unique (UI_Email),
   constraint AK_UI_MOBILE_APP_UNIV unique (UI_Mobile),
   constraint AK_UI_QQ_APP_UNIV unique (UI_QQ),
   constraint AK_UI_WEIXIN_APP_UNIV unique (UI_WeiXin),
   constraint AK_UI_IDENTITYID_APP_UNIV unique (UI_IdentityID),
   constraint AK_UI_WEIBO_APP_UNIV unique (UI_WeiBo)
)
go

/*==============================================================*/
/* Table: App_Universities_UserRight                            */
/*==============================================================*/
create table App_Universities_UserRight (
   UR_ID                bigint               identity(1,1),
   CFCI_ID              int                  not null,
   UserID               bigint               not null,
   UserType             int                  not null,
   Inherit_AdminUserID  bigint               not null,
   UR_Time              datetime             not null,
   UR_IP                varchar(30)          not null,
   constraint PK_APP_UNIVERSITIES_USERRIGHT primary key (UR_ID)
)
go

/*==============================================================*/
/* Table: App_Universities_UserStatus                           */
/*==============================================================*/
create table App_Universities_UserStatus (
   US_ID                int                  identity(1,1),
   US_Name              varchar(200)         not null,
   US_Activity          int                  not null default 1,
   constraint PK_APP_UNIVERSITIES_USERSTATUS primary key (US_ID)
)
go

alter table App_Universities_AdminUser
   add constraint AdminUserUserID foreign key (UserID)
      references App_Universities_UserInfo (UserID)
go

alter table App_Universities_AdminUser
   add constraint AdminUserUO_ID foreign key (UO_ID)
      references App_Universities_Organization (UO_ID)
go

alter table App_Universities_AdminUser
   add constraint AdminUserAdminID foreign key (AdminUser_UserID)
      references App_Universities_UserInfo (UserID)
go

alter table App_Universities_SchoolUser
   add constraint Mother foreign key (SchoolUser_MotherID)
      references App_Universities_UserInfo (UserID)
go

alter table App_Universities_SchoolUser
   add constraint UTD_ID foreign key (UTD_ID)
      references App_Universities_TopDiscipline (UTD_ID)
go

alter table App_Universities_SchoolUser
   add constraint USD_ID foreign key (USD_ID)
      references App_Universities_SecondaryDiscipline (USD_ID)
go

alter table App_Universities_SchoolUser
   add constraint UEB_ID foreign key (UEB_ID)
      references App_Universities_EducationalBackground (UEB_ID)
go

alter table App_Universities_SchoolUser
   add constraint SchoolUserAdminID foreign key (AdminID)
      references App_Universities_UserInfo (UserID)
go

alter table App_Universities_SchoolUser
   add constraint UD_ID foreign key (UD_ID)
      references App_Universities_Degree (UD_ID)
go

alter table App_Universities_SchoolUser
   add constraint UST_ID foreign key (UST_ID)
      references App_Universities_StudentType (UST_ID)
go

alter table App_Universities_SchoolUser
   add constraint SchoolUserUserID foreign key (UserID)
      references App_Universities_UserInfo (UserID)
go

alter table App_Universities_SchoolUser
   add constraint SchoolUserUS_ID foreign key (US_ID)
      references App_Universities_UserStatus (US_ID)
go

alter table App_Universities_SchoolUser
   add constraint SchoolUserUO_ID foreign key (UO_ID)
      references App_Universities_Organization (UO_ID)
go

alter table App_Universities_SchoolUser
   add constraint Father foreign key (SchoolUser_FatherID)
      references App_Universities_UserInfo (UserID)
go

alter table App_Universities_SecondaryDiscipline
   add constraint TOPID foreign key (TopID)
      references App_Universities_TopDiscipline (UTD_ID)
go

alter table App_Universities_SocialUser
   add constraint SocialUserUserID foreign key (UserID)
      references App_Universities_UserInfo (UserID)
go

alter table App_Universities_SocialUser
   add constraint SocialUserUS_ID foreign key (UserType)
      references App_Universities_UserStatus (US_ID)
go

alter table App_Universities_UserInfo
   add constraint UN_ID foreign key (UI_NationID)
      references App_Universities_Nation (UN_ID)
go

alter table App_Universities_UserInfo
   add constraint UPL_ID foreign key (UPL_ID)
      references App_Universities_PoliticalLandscape (UPL_ID)
go

alter table App_Universities_UserRight
   add constraint AdminUserID foreign key (Inherit_AdminUserID)
      references App_Universities_AdminUser (AdminUserID)
go


CREATE VIEW App_View_AdminUser
AS
SELECT   dbo.App_Universities_Organization.UI_ID, dbo.App_Universities_Organization.UO_Name, 
                dbo.App_Universities_Organization.UO_Level, dbo.App_Universities_Organization.UO_FatherID, 
                dbo.App_Universities_Organization.UO_Activity, dbo.App_Universities_AdminUser.AdminUserID, 
                dbo.App_Universities_AdminUser.UserID, dbo.App_Universities_AdminUser.UO_ID, 
                dbo.App_Universities_AdminUser.AdminUser_Role, dbo.App_Universities_AdminUser.AdminUser_HomeProvince, 
                dbo.App_Universities_AdminUser.AdminUser_OfficeAddress, dbo.App_Universities_AdminUser.AdminUser_HomeCity, 
                dbo.App_Universities_AdminUser.AdminUser_OfficePhone, dbo.App_Universities_AdminUser.AdminUser_Activtiy, 
                dbo.App_Universities_AdminUser.AdminUser_UserID, dbo.App_Universities_AdminUser.AdminUser_Time, 
                dbo.App_Universities_AdminUser.AdminUser_IP, dbo.App_Universities_Nation.UN_Name, 
                dbo.App_Universities_PoliticalLandscape.UPL_Name, dbo.App_Universities_UserInfo.UI_RealName, 
                dbo.App_Universities_UserInfo.UI_LoginName, dbo.App_Universities_UserInfo.UI_NickName, 
                dbo.App_Universities_UserInfo.UI_PWD, dbo.App_Universities_UserInfo.UI_Sex, 
                dbo.App_Universities_UserInfo.UI_NationID, dbo.App_Universities_UserInfo.UPL_ID, 
                dbo.App_Universities_UserInfo.UI_Email, dbo.App_Universities_UserInfo.UI_Intro, 
                dbo.App_Universities_UserInfo.UI_Face, dbo.App_Universities_UserInfo.UI_Mobile, 
                dbo.App_Universities_UserInfo.UI_QQ, dbo.App_Universities_UserInfo.UI_WeiXin, 
                dbo.App_Universities_UserInfo.UI_Birthday, dbo.App_Universities_UserInfo.UI_IdentityID, 
                dbo.App_Universities_UserInfo.UI_WeiBo, dbo.App_Universities_UserInfo.UI_HomeAddress, 
                dbo.App_Universities_UserInfo.UI_ZipCode, dbo.App_Universities_UserInfo.UI_EndTime, 
                dbo.App_Universities_UserInfo.UI_LastIP, dbo.App_Universities_UserInfo.UI_LastModifyTime, 
                dbo.App_Universities_UserInfo.UI_PrivacyState, dbo.App_Universities_UserInfo.UI_Activtity
FROM      dbo.App_Universities_AdminUser INNER JOIN
                dbo.App_Universities_Organization ON 
                dbo.App_Universities_AdminUser.UO_ID = dbo.App_Universities_Organization.UO_ID INNER JOIN
                dbo.App_Universities_UserInfo ON 
                dbo.App_Universities_AdminUser.UserID = dbo.App_Universities_UserInfo.UserID INNER JOIN
                dbo.App_Universities_Nation ON 
                dbo.App_Universities_UserInfo.UI_NationID = dbo.App_Universities_Nation.UN_ID INNER JOIN
                dbo.App_Universities_PoliticalLandscape ON 
                dbo.App_Universities_UserInfo.UPL_ID = dbo.App_Universities_PoliticalLandscape.UPL_ID

GO


CREATE VIEW App_View_SchoolUser
AS
SELECT   dbo.App_Universities_Degree.UD_Name, dbo.App_Universities_Organization.UO_Level, 
                dbo.App_Universities_Organization.UO_FatherID, dbo.App_Universities_Organization.UO_Activity, 
                dbo.App_Universities_Organization.UO_Name, dbo.App_Universities_Organization.UI_ID, 
                dbo.App_Universities_userStatus.US_Name, dbo.App_Universities_userStatus.US_Activity, 
                dbo.App_Universities_TopDiscipline.UTD_Name, dbo.App_Universities_TopDiscipline.UTD_No, 
                dbo.App_Universities_SecondaryDiscipline.USD_Name, dbo.App_Universities_SecondaryDiscipline.USD_No, 
                dbo.App_Universities_StudentType.UST_Name, dbo.App_Universities_EducationalBackground.UEB_Name, 
                dbo.App_Universities_SchoolUser.SchoolUserID, dbo.App_Universities_SchoolUser.UserID, 
                dbo.App_Universities_SchoolUser.UO_ID, dbo.App_Universities_SchoolUser.US_ID, 
                dbo.App_Universities_SchoolUser.SchoolUser_No, dbo.App_Universities_SchoolUser.SchoolUser_EntranceTime, 
                dbo.App_Universities_SchoolUser.SchoolUser_State, dbo.App_Universities_SchoolUser.SchoolUser_SchoolAddress, 
                dbo.App_Universities_SchoolUser.SchoolUser_HomeProvince, 
                dbo.App_Universities_SchoolUser.SchoolUser_HomeCity, dbo.App_Universities_SchoolUser.SchoolUser_FatherID, 
                dbo.App_Universities_SchoolUser.SchoolUser_MotherID, dbo.App_Universities_SchoolUser.UTD_ID, 
                dbo.App_Universities_SchoolUser.USD_ID, dbo.App_Universities_SchoolUser.UST_ID, 
                dbo.App_Universities_SchoolUser.SchoolUser_Specialty, dbo.App_Universities_SchoolUser.UD_ID, 
                dbo.App_Universities_SchoolUser.UEB_ID, dbo.App_Universities_SchoolUser.AdminID, 
                dbo.App_Universities_SchoolUser.LastAdminTime, dbo.App_Universities_SchoolUser.SchoolUser_Activity, 
                dbo.App_Universities_Nation.UN_Name, dbo.App_Universities_PoliticalLandscape.UPL_Name, 
                dbo.App_Universities_UserInfo.UI_RealName, dbo.App_Universities_UserInfo.UI_LoginName, 
                dbo.App_Universities_UserInfo.UI_NickName, dbo.App_Universities_UserInfo.UI_PWD, 
                dbo.App_Universities_UserInfo.UI_Sex, dbo.App_Universities_UserInfo.UI_NationID, 
                dbo.App_Universities_UserInfo.UPL_ID, dbo.App_Universities_UserInfo.UI_Email, 
                dbo.App_Universities_UserInfo.UI_Intro, dbo.App_Universities_UserInfo.UI_Face, 
                dbo.App_Universities_UserInfo.UI_Mobile, dbo.App_Universities_UserInfo.UI_QQ, 
                dbo.App_Universities_UserInfo.UI_WeiXin, dbo.App_Universities_UserInfo.UI_Birthday, 
                dbo.App_Universities_UserInfo.UI_IdentityID, dbo.App_Universities_UserInfo.UI_WeiBo, 
                dbo.App_Universities_UserInfo.UI_HomeAddress, dbo.App_Universities_UserInfo.UI_ZipCode, 
                dbo.App_Universities_UserInfo.UI_EndTime, dbo.App_Universities_UserInfo.UI_LastIP, 
                dbo.App_Universities_UserInfo.UI_LastModifyTime, dbo.App_Universities_UserInfo.UI_PrivacyState, 
                dbo.App_Universities_UserInfo.UI_Activtity
FROM      dbo.App_Universities_SchoolUser INNER JOIN
                dbo.App_Universities_Degree ON 
                dbo.App_Universities_SchoolUser.UD_ID = dbo.App_Universities_Degree.UD_ID INNER JOIN
                dbo.App_Universities_Organization ON 
                dbo.App_Universities_SchoolUser.UO_ID = dbo.App_Universities_Organization.UO_ID INNER JOIN
                dbo.App_Universities_EducationalBackground ON 
                dbo.App_Universities_SchoolUser.UEB_ID = dbo.App_Universities_EducationalBackground.UEB_ID INNER JOIN
                dbo.App_Universities_SecondaryDiscipline ON 
                dbo.App_Universities_SchoolUser.USD_ID = dbo.App_Universities_SecondaryDiscipline.USD_ID INNER JOIN
                dbo.App_Universities_TopDiscipline ON 
                dbo.App_Universities_SchoolUser.UTD_ID = dbo.App_Universities_TopDiscipline.UTD_ID INNER JOIN
                dbo.App_Universities_StudentType ON 
                dbo.App_Universities_SchoolUser.UST_ID = dbo.App_Universities_StudentType.UST_ID INNER JOIN
                dbo.App_Universities_userStatus ON 
                dbo.App_Universities_SchoolUser.US_ID = dbo.App_Universities_userStatus.US_ID INNER JOIN
                dbo.App_Universities_UserInfo ON 
                dbo.App_Universities_SchoolUser.UserID = dbo.App_Universities_UserInfo.UserID INNER JOIN
                dbo.App_Universities_Nation ON 
                dbo.App_Universities_UserInfo.UI_NationID = dbo.App_Universities_Nation.UN_ID INNER JOIN
                dbo.App_Universities_PoliticalLandscape ON 
                dbo.App_Universities_UserInfo.UPL_ID = dbo.App_Universities_PoliticalLandscape.UPL_ID

GO


CREATE VIEW App_View_SocialUser
AS
SELECT   dbo.App_Universities_Nation.UN_Name, dbo.App_Universities_PoliticalLandscape.UPL_Name, 
                dbo.App_Universities_UserInfo.UI_RealName, dbo.App_Universities_UserInfo.UI_LoginName, 
                dbo.App_Universities_UserInfo.UI_PWD, dbo.App_Universities_UserInfo.UI_NickName, 
                dbo.App_Universities_UserInfo.UI_Sex, dbo.App_Universities_UserInfo.UI_NationID, 
                dbo.App_Universities_UserInfo.UPL_ID, dbo.App_Universities_UserInfo.UI_Email, 
                dbo.App_Universities_UserInfo.UI_Intro, dbo.App_Universities_UserInfo.UI_Face, 
                dbo.App_Universities_UserInfo.UI_Mobile, dbo.App_Universities_UserInfo.UI_QQ, 
                dbo.App_Universities_UserInfo.UI_WeiXin, dbo.App_Universities_UserInfo.UI_Birthday, 
                dbo.App_Universities_UserInfo.UI_IdentityID, dbo.App_Universities_UserInfo.UI_WeiBo, 
                dbo.App_Universities_UserInfo.UI_HomeAddress, dbo.App_Universities_UserInfo.UI_ZipCode, 
                dbo.App_Universities_UserInfo.UI_EndTime, dbo.App_Universities_UserInfo.UI_LastModifyTime, 
                dbo.App_Universities_UserInfo.UI_LastIP, dbo.App_Universities_UserInfo.UI_PrivacyState, 
                dbo.App_Universities_UserInfo.UI_Activtity, dbo.App_Universities_SocialUser.SocialUserID, 
                dbo.App_Universities_SocialUser.UserType, dbo.App_Universities_SocialUser.SocialUser_HomeProvince, 
                dbo.App_Universities_SocialUser.SocialUser_HomeCity, dbo.App_Universities_SocialUser.SocialUser_WorkUnit, 
                dbo.App_Universities_SocialUser.SocialUser_Activity, dbo.App_Universities_SocialUser.UserID, 
                dbo.App_Universities_UserStatus.US_Name, dbo.App_Universities_UserStatus.US_Activity
FROM      dbo.App_Universities_Nation INNER JOIN
                dbo.App_Universities_UserInfo ON 
                dbo.App_Universities_Nation.UN_ID = dbo.App_Universities_UserInfo.UI_NationID INNER JOIN
                dbo.App_Universities_PoliticalLandscape ON 
                dbo.App_Universities_UserInfo.UPL_ID = dbo.App_Universities_PoliticalLandscape.UPL_ID INNER JOIN
                dbo.App_Universities_SocialUser ON 
                dbo.App_Universities_UserInfo.UserID = dbo.App_Universities_SocialUser.UserID INNER JOIN
                dbo.App_Universities_UserStatus ON 
                dbo.App_Universities_SocialUser.UserType = dbo.App_Universities_UserStatus.US_ID

GO


CREATE VIEW App_View_UserInfo
AS
SELECT   dbo.App_Universities_Nation.UN_Name, dbo.App_Universities_PoliticalLandscape.UPL_Name, 
                dbo.App_Universities_UserInfo.UserID, dbo.App_Universities_UserInfo.UI_RealName, 
                dbo.App_Universities_UserInfo.UI_LoginName, dbo.App_Universities_UserInfo.UI_NickName, 
                dbo.App_Universities_UserInfo.UI_PWD, dbo.App_Universities_UserInfo.UI_Sex, 
                dbo.App_Universities_UserInfo.UI_NationID, dbo.App_Universities_UserInfo.UPL_ID, 
                dbo.App_Universities_UserInfo.UI_Email, dbo.App_Universities_UserInfo.UI_Intro, 
                dbo.App_Universities_UserInfo.UI_Face, dbo.App_Universities_UserInfo.UI_Mobile, 
                dbo.App_Universities_UserInfo.UI_QQ, dbo.App_Universities_UserInfo.UI_WeiXin, 
                dbo.App_Universities_UserInfo.UI_Birthday, dbo.App_Universities_UserInfo.UI_IdentityID, 
                dbo.App_Universities_UserInfo.UI_WeiBo, dbo.App_Universities_UserInfo.UI_HomeAddress, 
                dbo.App_Universities_UserInfo.UI_ZipCode, dbo.App_Universities_UserInfo.UI_EndTime, 
                dbo.App_Universities_UserInfo.UI_LastIP, dbo.App_Universities_UserInfo.UI_LastModifyTime, 
                dbo.App_Universities_UserInfo.UI_PrivacyState, dbo.App_Universities_UserInfo.UI_Activtity
FROM      dbo.App_Universities_UserInfo INNER JOIN
                dbo.App_Universities_Nation ON 
                dbo.App_Universities_UserInfo.UI_NationID = dbo.App_Universities_Nation.UN_ID INNER JOIN
                dbo.App_Universities_PoliticalLandscape ON 
                dbo.App_Universities_UserInfo.UPL_ID = dbo.App_Universities_PoliticalLandscape.UPL_ID

GO

alter table App_Universities_AdminUser add constraint AdminUO_ID foreign key(AdminUO_ID) references App_Universities_Organization(UO_ID) 
go

alter table App_Universities_SocialUser add constraint SocialUserUO_ID foreign key(UO_ID) references App_Universities_Organization(UO_ID) 
go