using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notification
{
    /// <summary>
    /// GetNewsReadNum 的摘要说明
    /// </summary>
    public class GetNewsReadNum : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request.Params["newsId"];
            int newsId = int.Parse(DESEncrypt.Decrypt(id));
            Model.CCOM.News model = new BLL.CCOM.News().GetModel(newsId);
            if(model!=null)
            {
                context.Response.Write(model.News_readnumber);
            }
            else
            {
                context.Response.Write("0");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}