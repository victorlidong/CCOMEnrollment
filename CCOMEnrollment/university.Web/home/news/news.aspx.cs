using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using university.Common;

namespace university.Web.home.news
{
    public partial class news : System.Web.UI.Page
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
                try
                {
                    encNewsId = MyRequest.GetString("id");
                    //userid = Convert.ToInt64(MyRequest.GetString("userid"));
                    token = MyRequest.GetString("token");
                    if (token == "")
                    {
                        token = "0";
                    }
                    else
                    {
                        userid = new BLL.admin.AppLoginHistory().Get_AppUser_UserID(token);
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/home/news/template/news_error.html");
                }
             
                String[] arrStr = DESEncrypt.Decrypt(encNewsId).Split(',');
                if (arrStr[1] == "1") //正常新闻
                {

                    ShowNews(userid, arrStr[0], token);
                }
                else
                {
                    ShowPushNews(userid, arrStr[0]);
                }
            }
            else
            {
                Response.Redirect("/home/news/web/webnews.aspx?id="+MyRequest.GetString("id"));
            }
        }

        #region "news"

        private void ShowNews(Int64 userid, String newsId, String token)
        {
            String name = NewsHtml.GetAppNewsPath(long.Parse(newsId));
            NewsHtml.CreateNewsHtml(newsId, Server.MapPath(name));
            if (!System.IO.File.Exists(Server.MapPath(name)))
            {
                Response.Redirect("/home/news/template/news_404.html");
            }
            else
            {
                NewsHtml.UpdateNewsReadNum(long.Parse(newsId), userid);
                //记录阅读状态
                NewsHtml.AddNewsReadRecord(long.Parse(newsId),userid,"app");
                Response.Redirect(name + "?t=" + token);
            }
        }

        #endregion


        #region "push news"

        private void ShowPushNews(Int64 userid, String newsId)
        {
            String name = NewsHtml.PushNewsBaseDir + DESEncrypt.Encrypt(newsId) + ".html";
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