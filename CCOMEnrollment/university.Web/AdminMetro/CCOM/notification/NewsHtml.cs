using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using university.Common;
using university.Web.AdminMetro.OnlineView;

namespace university.Web.AdminMetro.CCOM.notification
{
    public class NewsHtml : university.UI.ManagePage
    {
        public static String WebNewsBaseDir = "/home/news/web/";

        public NewsHtml()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        //获取Web新闻的相对路径
        public static String GetWebNewsPath(int newsId)
        {
            return GetNewsPath(WebNewsBaseDir, newsId);
        }

        private static String GetNewsPath(String newsBaseDir, int newsId)
        {
            var datePath = GetNewsDatePath(newsId);
            var baseDir = newsBaseDir + datePath;
            var toFileFullPath = Utils.GetMapPath(baseDir);
            //检查是否有该路径无就创建
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
        private static string GetNewsDatePath(int newsId)
        {
            //var m = new BLL.news.News_NewsInfo().GetModel(newsId);
            var model = new BLL.CCOM.News().GetModel(newsId);
            if (model==null||model.News_date == null)
                return "";
            //按年月/日存入不同的文件夹
            DateTime dt = Convert.ToDateTime(model.News_date);
            return dt.ToString("yyyyMM") + "/" + dt.ToString("dd") + "/";
        }

        //生成静态页
        public static void CreateHtml(int newsId, bool checkExists)
        {
            String webname = GetWebNewsPath(newsId);
            CreateWebNewsHtml(newsId.ToString(), Utils.GetMapPath(webname), checkExists);
        }

        //web html news
        public static void CreateWebNewsHtml(String newsId, String fileName)
        {
            CreateWebNewsHtml(newsId, fileName, true);
        }
        public static void CreateWebNewsHtml(String newsId, String fileName, bool checkExists)
        {
            if ((!checkExists) || (!System.IO.File.Exists(fileName)))
            {
                var news = new BLL.CCOM.News().GetModel(Int32.Parse(newsId));
                if (news != null)
                {
                    // 读取模板文件
                    string temp = HttpContext.Current.Server.MapPath("news_temp.html");
                    String newsStr = FileOperate.ReadFile(temp);
                    newsStr = newsStr.Replace("titlexxx", news.News_title);
                    StringBuilder sb = new StringBuilder();
                    int creator_id = news.News_creator_id;
                    string realname = new BLL.CCOM.User_information().GetModel(creator_id).User_realname;
                    if (realname != "请填写真实姓名")
                        sb.Append("<span>发布者：").Append(realname).Append("</span>");
                    
                    sb.Append("&nbsp;&nbsp;");
                    sb.Append(news.News_date);
                    //sb.Append("&nbsp;&nbsp;").Append("阅读次数：").Append(news.NI_ReadNum);
                    newsStr = newsStr.Replace("desxxx", sb.ToString());
                    String content = HttpContext.Current.Server.HtmlDecode(news.News_content);

                    newsStr = newsStr.Replace("contentxxx", content);
                    sb.Clear();
                    //var newsAttach = new BLL.news.News_NewsInfo().GetModel(Int64.Parse(newsId)).NewsAttach;
                    string strWhere=" News_id="+newsId;
                    var newsAttach=new BLL.CCOM.News_attach().GetModelList(strWhere);
                    if (newsAttach != null && newsAttach.Count > 0)
                    {
                        sb.Append("<p class='attachTitle'>附件：</p>");
                        var itemCnt = 1;
                        foreach (var item in newsAttach)
                        {
                            sb.Append("<p class='attachItem'>(").Append(itemCnt).Append(")&nbsp;<a href='")
                                .Append("/home/news/Attach.aspx?id=").Append(DESEncrypt.Encrypt(item.News_attach_id.ToString()))
                                .Append("&address=").Append(HttpUtility.UrlEncode(item.News_attach_address))
                                .Append("&name=").Append(HttpUtility.UrlEncode(item.News_attach_name))
                                .Append("' target='_blank' >")
                                .Append(item.News_attach_name)
                                .Append("</a>")
                                .Append(OnlineViewHelper.GetOnlineViewWrapLink(item.News_attach_address, item.News_attach_name))
                                .Append("</p>");
                            itemCnt++;
                        }
                    }
                    newsStr = newsStr.Replace("attachxxx", sb.ToString());
                    ////写文件
                    FileOperate.WriteNewFile(fileName, newsStr);
                }
            }

        }

        public static void UpdateNewsReadNum(int newsId)
        {
            if (HttpContext.Current.Session[newsId.ToString()] == null)
            {
                var news = new BLL.CCOM.News().GetModel(newsId);
                news.News_readnumber++;
                new BLL.CCOM.News().Update(news);
                HttpContext.Current.Session[newsId.ToString()] = 1;
            }
        }

    }

}