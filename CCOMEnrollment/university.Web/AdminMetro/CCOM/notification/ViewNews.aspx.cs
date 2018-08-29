using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notification
{
    public partial class ViewNews : System.Web.UI.Page
    {
        //public ViewNews()
        //{
        //    this.checkFunID = false;
        //    this.checkUserStaus = false;
        //    this.checkSchoolLevelAdminUser = false;
        //}
        //private static String tokenValidateUrl = ConfigurationManager.AppSettings["ApiServerUrl"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            String encNewsId = "";
            //String userAgent = "";
            //if (Request.Headers["user-agent"] != null)
            //{
            //    userAgent = Request.Headers["user-agent"].ToString();
            //}
            int newsId = 0;
            try
            {
                encNewsId = MyRequest.GetString("id");
                newsId = Int32.Parse(DESEncrypt.Decrypt(encNewsId));
            }
            catch (Exception ex)
            {
                Response.Redirect("/home/news/template/news_error.html");
            }
            
            if(newsId>0)
            {
                ShowNews(newsId);
            }
            
        }

        private void ShowNews(int newsId)
        {
            String name = NewsHtml.GetWebNewsPath(newsId);
            NewsHtml.CreateWebNewsHtml(newsId+"", Server.MapPath(name));
            if (!System.IO.File.Exists(Server.MapPath(name)))
            {
                Response.Redirect("/home/news/template/news_404.html");
            }
            else
            {
                NewsHtml.UpdateNewsReadNum(newsId);
                Response.Redirect(name);
            }
        }
    }
}