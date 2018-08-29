using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace university.Web.AdminMetro.CCOM.notification
{
    /// <summary>
    /// GetNewsList 的摘要说明
    /// </summary>
    public class GetNewsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //按时间先后
            DataTable dt = new BLL.CCOM.News().GetList(0, "", " News_date DESC").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                var class_media = "media";
                var class_span = "label pull-left news-bg";
                var class_img_circle = "img-circle";
                var img_src = "/admin/images/water.jpg";
                var class_media_body = "media-body";
                var p_title = "text news-title";
                var img_style = "width:40px; height:40px;";
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("<li><div class=\"" + class_media + "\"><span class=\"" + class_span + "\"><img class=\"" +
                        class_img_circle + "\" src=\"" + img_src + "\" alt=\"资讯\" style=\"" + img_style + "\"/></span>");
                    sb.Append("<div class=\"" + class_media_body + "\"><p class=\"" + p_title + "\"><a href=\"" + dr["News_URL"] + "\">" +
                        dr["News_title"] + "</a></p><span>" + dr["News_date"] + "</span></div></div></li>");
                }
                context.Response.Write(sb.ToString());
            }
            else
            {
                context.Response.Write("暂无资讯");
            }


            //不按时间先后
            //var news_list = new BLL.CCOM.News().GetModelList("");
            //if (news_list != null && news_list.Count > 0)
            //{
            //    var class_media = "media";
            //    var class_span = "label pull-left news-bg";
            //    var class_img_circle = "img-circle";
            //    var img_src = "/admin/images/water.jpg";
            //    var class_media_body = "media-body";
            //    var p_title = "text news-title";
            //    var img_style = "width:40px; height:40px;";
            //    StringBuilder sb = new StringBuilder();
            //    for (int i = 0; i < news_list.Count; i++)
            //    {
            //        Model.CCOM.News model = news_list[i];
            //        sb.Append("<li><div class=\"" + class_media + "\"><span class=\"" + class_span + "\"><img class=\"" +
            //            class_img_circle + "\" src=\"" + img_src + "\" alt=\"资讯\" style=\"" + img_style + "\"/></span>");
            //        sb.Append("<div class=\"" + class_media_body + "\"><p class=\"" + p_title + "\"><a href=\"" + model.News_URL + "\">" +
            //            model.News_title + "</a></p><span>" + model.News_date + "</span></div></div></li>");
            //        //context.Response.Write(sb.ToString());
            //    }
            //    context.Response.Write(sb.ToString());
            //}
            //else
            //{
            //    context.Response.Write("暂无资讯");
            //}
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