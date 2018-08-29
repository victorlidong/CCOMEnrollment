using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using university.Common;
using university.Web.admin.NewsAdmin;
using university.Web.admin.NewsApi;
using university.Web.AdminMetro.OnlineView;

namespace university.Web.home.news
{
    public class NewsHtml
    {
        public static String NewsBaseDir = "/home/news/app/";
        public static String WebNewsBaseDir = "/home/news/web/";
        public static String PushNewsBaseDir = "/home/pushnews/";

        //获取APP新闻的相对路径
        public static String GetAppNewsPath(long newsId)
        {
            return GetNewsPath(NewsBaseDir, newsId);
        }
        //获取Web新闻的相对路径
        public static String GetWebNewsPath(long newsId)
        {
            return GetNewsPath(WebNewsBaseDir, newsId);
        }

        private static String GetNewsPath(String newsBaseDir, long newsId)
        {
            var datePath = GetNewsDatePath(newsId);
            var baseDir = newsBaseDir + datePath;
            var toFileFullPath = Utils.GetMapPath(baseDir);
            //检查有该路径是否就创建
            if (!Directory.Exists(toFileFullPath))
            {
                Directory.CreateDirectory(toFileFullPath);
            }
            return baseDir + DESEncrypt.Encrypt(newsId.ToString()) + ".html";
        }
        /// <summary>
        /// 获取新闻生成的日期目录
        /// </summary>
        /// <param name="newsId">新闻Id</param>
        private static string GetNewsDatePath(long newsId)
        {
            var m = new BLL.news.News_NewsInfo().GetModel(newsId);
            if (m.NI_Created == null)
                return "";
            //按年月/日存入不同的文件夹
            DateTime dt = Convert.ToDateTime(m.NI_Created);
            return dt.ToString("yyyyMM") + "/" + dt.ToString("dd") + "/";
        }

        //生成静态页
        public static void CreateHtml(long newsId, bool checkExists)
        {
            String name = GetAppNewsPath(newsId);
            CreateNewsHtml(newsId.ToString(), Utils.GetMapPath(name), checkExists);
            String webname = GetWebNewsPath(newsId);
            CreateWebNewsHtml(newsId.ToString(), Utils.GetMapPath(webname), checkExists);
        }

        //app html news
        public static void CreateNewsHtml(String newsId, String fileName)
        {
            CreateNewsHtml(newsId, fileName, true);
            //同时生成web html news
            String webname = GetWebNewsPath(long.Parse(newsId));
            CreateWebNewsHtml(newsId.ToString(), Utils.GetMapPath(webname), true);
        }
        public static void CreateNewsHtml(String newsId, String fileName, bool checkExists)
        {
            if ((!checkExists) || (!System.IO.File.Exists(fileName)))
            {
                var news = new BLL.news.V_NewsInfo().GetModel(Int64.Parse(newsId));
                if (news != null)
                {
                    // 读取模板文件
                    string temp = HttpContext.Current.Server.MapPath("/home/news/template/news_template.html");
                    String newsStr = FileOperate.ReadFile(temp);
                    newsStr = newsStr.Replace("titlexxx", news.NI_Tile);
                    StringBuilder sb = new StringBuilder();
                    if (news.UI_RealName != "")
                        sb.Append("<span>发布者：").Append(news.UI_RealName).Append("</span>");
                    var isCampusCol = IsCampusCol(news.NCh_Id);
                    if (isCampusCol)
                    {
                        var newsChannel = new BLL.news.News_NewsChannel().GetModel(news.NCh_Id);
                        //content += "<p>来源：<a href='" + newsChannel.NCh_RssUrl + "'>" + newsChannel.NCh_Name + "</a></p>";
                        sb.Append("&nbsp;&nbsp;<span>来源：" + newsChannel.NCh_Name + "</span>");
                    }
                    sb.Append("&nbsp;&nbsp;");
                    sb.Append(news.CN_PubDate);
                    //sb.Append("&nbsp;&nbsp;").Append("阅读次数：").Append(news.NI_ReadNum);
                    newsStr = newsStr.Replace("desxxx", sb.ToString());
                    String content = HttpContext.Current.Server.HtmlDecode(news.NI_Content);

                    //newsStr = newsStr.Replace("contentxxx", content);
                    newsStr = newsStr.Replace("contentxxx", NewsHelper.SetHtmlImgWidth(content, "98%", ""));
                    sb.Clear();
                    var newsAttach = new BLL.news.News_NewsInfo().GetModel(Int64.Parse(newsId)).NewsAttach;
                    if (newsAttach != null && newsAttach.Count > 0)
                    {
                        sb.Append("<p class='attachTitle'>附件：</p>");
                        var itemCnt = 1;
                        foreach (var item in newsAttach)
                        {
                            sb.Append("<p class='attachItem'>(").Append(itemCnt).Append(")&nbsp;<a href='")
                                .Append("/home/news/Attach.aspx?id=").Append(DESEncrypt.Encrypt(item.NA_Id.ToString()))
                                .Append("&address=").Append(HttpUtility.UrlEncode(item.NA_Address))
                                .Append("&name=").Append(HttpUtility.UrlEncode(item.NA_Name))
                                .Append("' target='_blank' >")
                                .Append(item.NA_Name)
                                .Append("</a>")
                                .Append(OnlineViewHelper.GetOnlineViewWrapLink(item.NA_Address, item.NA_Name))
                                .Append("</p>");
                            itemCnt++;
                        }
                    }
                    newsStr = newsStr.Replace("attachxxx", sb.ToString());
                    //写文件
                    FileOperate.WriteNewFile(fileName, newsStr);
                }
            }
           
        }

        //web html news
        public static void CreateWebNewsHtml(String newsId, String fileName)
        {
            CreateWebNewsHtml(newsId, fileName, true);
            //同时生成app html news
            String name = GetAppNewsPath(long.Parse(newsId));
            CreateNewsHtml(newsId.ToString(), Utils.GetMapPath(name), true);

        }
        public static void CreateWebNewsHtml(String newsId, String fileName, bool checkExists)
        {
            if ((!checkExists) || (!System.IO.File.Exists(fileName)))
            {
                var news = new BLL.news.V_NewsInfo().GetModel(Int64.Parse(newsId));
                if (news != null)
                {
                    // 读取模板文件
                    string temp = HttpContext.Current.Server.MapPath("/home/news/template/webnews_template.html");
                    String newsStr = FileOperate.ReadFile(temp);
                    newsStr = newsStr.Replace("titlexxx", news.NI_Tile);
                    StringBuilder sb = new StringBuilder();
                    if (news.UI_RealName != "")
                        sb.Append("<span>发布者：").Append(news.UI_RealName).Append("</span>");
                    var isCampusCol = IsCampusCol(news.NCh_Id);
                    if (isCampusCol)
                    {
                        var newsChannel = new BLL.news.News_NewsChannel().GetModel(news.NCh_Id);
                        //content += "<p>来源：<a href='" + newsChannel.NCh_RssUrl + "'>" + newsChannel.NCh_Name + "</a></p>";
                        sb.Append("&nbsp;&nbsp;<span>来源：" + newsChannel.NCh_Name + "</span>");
                    }
                    sb.Append("&nbsp;&nbsp;");
                    sb.Append(news.CN_PubDate);
                    //sb.Append("&nbsp;&nbsp;").Append("阅读次数：").Append(news.NI_ReadNum);
                    newsStr = newsStr.Replace("desxxx", sb.ToString());
                    String content = HttpContext.Current.Server.HtmlDecode(news.NI_Content);

                    newsStr = newsStr.Replace("contentxxx", content);
                    sb.Clear();
                    var newsAttach = new BLL.news.News_NewsInfo().GetModel(Int64.Parse(newsId)).NewsAttach;
                    if (newsAttach != null && newsAttach.Count > 0)
                    {
                        sb.Append("<p class='attachTitle'>附件：</p>");
                        var itemCnt = 1;
                        foreach (var item in newsAttach)
                        {
                            sb.Append("<p class='attachItem'>(").Append(itemCnt).Append(")&nbsp;<a href='")
                                .Append("/home/news/Attach.aspx?id=").Append(DESEncrypt.Encrypt(item.NA_Id.ToString()))
                                .Append("&address=").Append(HttpUtility.UrlEncode(item.NA_Address))
                                .Append("&name=").Append(HttpUtility.UrlEncode(item.NA_Name))
                                .Append("' target='_blank' >")
                                .Append(item.NA_Name)
                                .Append("</a>")
                                .Append(OnlineViewHelper.GetOnlineViewWrapLink(item.NA_Address, item.NA_Name))
                                .Append("</p>");
                            itemCnt++;
                        }
                    }
                    newsStr = newsStr.Replace("attachxxx", sb.ToString());
                    //写文件
                    FileOperate.WriteNewFile(fileName, newsStr);
                }
            }
          
        }

        //push news
        public static void CreatePushNewsHtml(String newsId, String fileName)
        {
            if (!System.IO.File.Exists(fileName))
            {
                var news = new BLL.news.V_PushNewsInfo().GetModel(Int64.Parse(newsId));
                if (news != null)
                {
                    // 读取模板文件
                    string temp = HttpContext.Current.Server.MapPath("/home/news/template/pushnews_template.html");
                    String newsStr = FileOperate.ReadFile(temp);
                    newsStr = newsStr.Replace("titlexxx", news.NI_Title);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<span>发布者：").Append(news.UI_RealName).Append("</span>").Append("&nbsp;&nbsp;");
                    sb.Append(news.NI_Created.ToString("yyyy-MM-dd"));
                    newsStr = newsStr.Replace("desxxx", sb.ToString());
                    newsStr = newsStr.Replace("contentxxx", news.NI_Content);
                    newsStr = newsStr.Replace("attachxxx", "");
                    //写文件
                    FileOperate.WriteNewFile(fileName, newsStr);
                }
            }
        }

        public static bool IsCampusCol(Int64 chnId)
        {
            String NC_Code = DataDic.CAMPUS_CHANNEL;
            Int64 NC_Id = new BLL.news.News_NewsColumn().GetModelId(NC_Code);
            Int64 t_NC_Id = new BLL.news.News_NewsChannel().GetModel(chnId).NC_Id;
            return NC_Id == t_NC_Id;
        }

        public static bool IsSocietyCol(Int64 chnId)
        {
            String NC_Code = DataDic.SOCIETY_CHANNEL;
            Int64 NC_Id = new BLL.news.News_NewsColumn().GetModelId(NC_Code);
            Int64 t_NC_Id = new BLL.news.News_NewsChannel().GetModel(chnId).NC_Id;
            return NC_Id == t_NC_Id;
        }

        #region "判断请求是否来自移动端"
        public static bool IsFromMobile(String userAgent)
        {
            return IsFromAndroid(userAgent) || IsFromIos(userAgent);
        }

        public static bool IsFromAndroid(String userAgent)
        {
            return userAgent.ToLower().Contains("android");
        }

        public static bool IsFromIos(String userAgent)
        {
            return userAgent.ToLower().Contains("ipad") || userAgent.ToLower().Contains("iphone");
        }

        public static bool IsFromWeiXin(String userAgent)
        {
            return userAgent.ToLower().Contains("micromessenger");
        }

        public static void UpdateNewsReadNum(long newsId, long userId)
        {
            if (HttpContext.Current.Session[newsId.ToString()] == null)
            {
                var news = new BLL.news.News_NewsInfo().GetModel(newsId);
                news.NI_ReadNum++;
                new BLL.news.News_NewsInfo().Update(news);
                HttpContext.Current.Session[newsId.ToString()] = 1;
            }
        }

        /// <summary>
        /// 添加新闻阅读记录
        /// </summary>
        /// <param name="newsId">新闻Id</param>
        /// <param name="userId">用户登录Id</param>
        /// <param name="from">来源:app|web</param>
        public static void AddNewsReadRecord(long newsId, long userId, string from)
        {
            if (newsId != 0 && userId != 0)
            {
                var newsM = new BLL.news.News_NewsInfo().GetModel(newsId);
                if (newsM != null&&newsM.NI_IsRecordRead==1)
                {
                    var bll = new BLL.news.News_NewsReader();
                    //var ml = bll.GetModelList(" NI_Id=" + newsId + " and UserId=" + userId);
                    //if (ml == null || ml.Count < 1)
                    {
                        var model = new Model.news.News_NewsReader()
                        {
                            NI_Id = newsId,
                            NR_From = from,
                            UserId = userId,
                            NR_Time = DateTime.Now
                        };
                        bll.Add(model);
                    }
                }
            }
        }

        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsAdminLogin()
        {
            //如果Session为Null
            if (HttpContext.Current.Session[MyKeys.SESSION_ADMIN_INFO] != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 取得用户小表信息
        /// </summary>
        public static int GetUserUO_ID()
        {
            if (IsAdminLogin())
            {
                if ((MyEnums.UserStatus)HttpContext.Current.Session[MyKeys.SESSION_USER_TABLE] == MyEnums.UserStatus.App_Universities_AdminUser)
                {
                    Model.admin.Universities_AdminUser adminuser = new Model.admin.Universities_AdminUser();
                    BLL.admin.Universities_AdminUser bll = new BLL.admin.Universities_AdminUser();
                    adminuser = bll.GetModel(Convert.ToInt64(HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID]));
                    return adminuser.UO_ID;
                }
                else if ((MyEnums.UserStatus)HttpContext.Current.Session[MyKeys.SESSION_USER_TABLE] == MyEnums.UserStatus.App_Universities_SchoolUser)
                {
                    Model.admin.Universities_SchoolUser schooluser = new Model.admin.Universities_SchoolUser();
                    BLL.admin.Universities_SchoolUser bll = new BLL.admin.Universities_SchoolUser();
                    schooluser = bll.GetModel(Convert.ToInt64(HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID]));
                    return schooluser.UO_ID;
                }
                else if ((MyEnums.UserStatus)HttpContext.Current.Session[MyKeys.SESSION_USER_TABLE] == MyEnums.UserStatus.App_Universities_SocialUser)
                {
                    Model.admin.Universities_SocialUser socialuser = new Model.admin.Universities_SocialUser();
                    BLL.admin.Universities_SocialUser bll = new BLL.admin.Universities_SocialUser();
                    socialuser = bll.GetModel(Convert.ToInt64(HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID]));
                    return socialuser.UO_ID;
                }
            }
            return 0;
        }

        /// <summary>
        /// 取得用户信息
        /// </summary>
        public static Model.admin.Universities_UserInfo GetAdminInfo()
        {
            if (IsAdminLogin())
            {
                Model.admin.Universities_UserInfo model = HttpContext.Current.Session[MyKeys.SESSION_ADMIN_INFO] as Model.admin.Universities_UserInfo;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }

        #endregion

    }
}