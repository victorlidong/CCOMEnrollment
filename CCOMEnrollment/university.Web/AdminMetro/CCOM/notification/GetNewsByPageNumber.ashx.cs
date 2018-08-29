using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace university.Web.AdminMetro.CCOM.notification
{
    /// <summary>
    /// GetNewsByPageNumber 的摘要说明
    /// </summary>
    public class GetNewsByPageNumber : IHttpHandler
    {
        private int count = 0;
        List<string> page_item = null;
        public void ProcessRequest(HttpContext context)
        {
            count++;
            context.Response.ContentType = "text/plain";
            int page=Convert.ToInt32(context.Request.Params["cur_page"]);
            page_item = new List<string>();
            string resulst = InitialPage(0, page);//默认查询所有通知
            context.Response.Write(resulst);
        }
        /// <summary>
        /// 获取通知信息
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="page">返回页码</param>
        /// <returns></returns>
        protected string InitialPage(Int32 typeId,int page)
        {
            string sqlWhere = string.Empty;
            if (typeId != 0)
            {
                sqlWhere = " News_type_id='" + typeId + "'";
            }
            //不按时间
            //var list = new BLL.CCOM.News().GetModelList(sqlWhere);
            //if (list != null && list.Count > 0)
            //{
            //    List<string> page_item = new List<string>();
            //    StringBuilder sb = new StringBuilder();
            //    for (int i = 1; i <= list.Count; i++)
            //    {
            //        Model.CCOM.News model = list[0];
            //        sb.Append("<li class='notice-li'>" + "<a href='" + model.News_URL + "'>" + i  + "、" + model.News_title + "<a/>" + "<li/>");
            //        if (i % 10 == 0)
            //        {
            //            page_item.Add(sb.ToString());
            //            sb = new StringBuilder();
            //        }
            //    }
            //    if(page_item.Count==0)
            //    {
            //        page_item.Add(sb.ToString());
            //    }
            //    this.news_list.InnerHtml = page_item[page];
            //}

            //按时间
            DataTable dt = new BLL.CCOM.News().GetList(0, sqlWhere, " News_date DESC").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                int i = 1;
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("<li class=\"notice-li\">" + "<a href=\"" + dr["News_URL"] + "\">" + i + "、" + dr["News_title"] + "<a/>" + "<li/>");
                    if (i % 10 == 0)
                    {
                        page_item.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                    i++;
                }
                if (sb != null && sb.ToString().Length > 0)
                {
                    page_item.Add(sb.ToString());
                }
                return page_item[page-1];
            }
            return null;
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