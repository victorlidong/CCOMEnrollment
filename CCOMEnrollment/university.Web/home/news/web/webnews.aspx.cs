using System;
using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json.Linq;
using university.Common;
using university.Web.admin.api;

namespace university.Web.home.news.web
{
    public partial class webnews : System.Web.UI.Page
    {
        private static String tokenValidateUrl = ConfigurationManager.AppSettings["ApiServerUrl"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            String encNewsId = "";
            Int64 userid = 0;
            String token = "";
            String userAgent = "";
             if (Request.Headers["user-agent"] != null)
            {
                userAgent = Request.Headers["user-agent"].ToString();
            }

            if (NewsHtml.IsFromMobile(userAgent))
            {
                Response.Redirect("/home/news/news.aspx?id=" + MyRequest.GetString("id"));
            }
            else
            {
                try
                {
                    encNewsId = MyRequest.GetString("id");
                    //userid = Convert.ToInt64(MyRequest.GetString("userid"));
                    //token = MyRequest.GetString("token");
                    if (NewsHtml.IsAdminLogin())
                    {
                        userid = NewsHtml.GetAdminInfo().UserID;
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/home/news/template/news_error.html");
                }
                // if (!IsLegalToken(userid, token))
                // {
                // Response.Redirect("news_error.html");
                // }
                String[] arrStr = DESEncrypt.Decrypt(encNewsId).Split(',');
                if (arrStr[1] == "1") //正常新闻
                {
                    ShowNews(userid, arrStr[0]);
                }
                else
                {
                    ShowPushNews(userid, arrStr[0]);
                }
            }

        }

        #region "news"

        private void ShowNews(Int64 userid, String newsId)
        {
            String name = NewsHtml.GetWebNewsPath(long.Parse(newsId));
            NewsHtml.CreateWebNewsHtml(newsId, Server.MapPath(name));
            if (!System.IO.File.Exists(Server.MapPath(name)))
            {
                Response.Redirect("/home/news/template/news_404.html");
            }
            else
            {
                NewsHtml.UpdateNewsReadNum(long.Parse(newsId),userid);
                //记录阅读状态
                NewsHtml.AddNewsReadRecord(long.Parse(newsId), userid, "web");
                Response.Redirect(name);
            }
        }

        #endregion


        #region "push news"

        private void ShowPushNews(Int64 userid, String newsId)
        {
            String name =NewsHtml.PushNewsBaseDir  + DESEncrypt.Encrypt(newsId) + ".html";
            NewsHtml.CreatePushNewsHtml(newsId, Server.MapPath(name));
            if (!System.IO.File.Exists(Server.MapPath(name)))
            {
                Response.Redirect("/home/news/template/news_404.html");
            }
            else
            {
                Response.Redirect(name);
            }
        }

        #endregion

        private static bool IsLegalToken(Int64 userId, String token)
        {
            String vRes = Utils.HttpPost(tokenValidateUrl, "action=Auth&userID=" + userId + "&token=" + token);
            try
            {
                JObject jObj = JObject.Parse(vRes);
                if (jObj["result"].ToString() == "ok")
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }


    }
}