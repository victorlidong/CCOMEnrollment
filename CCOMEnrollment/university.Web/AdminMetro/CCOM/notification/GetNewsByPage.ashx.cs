using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notification
{
    /// <summary>
    /// GetNewsByPage 的摘要说明
    /// </summary>
    public class GetNewsByPage : IHttpHandler
    {
        private const int pageSize = 10;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string _action = context.Request.Params["action"];
            int typeId = 0;
            string type = context.Request.Params["typeId"].ToString();
            int page = int.Parse(context.Request.Params["page"].ToString());
            string keyWord = context.Request.Params["keyWord"].ToString();
            
            if (type.Length > 2)
            {
                typeId = int.Parse(DESEncrypt.Decrypt(type));
            }
            else
            {
                typeId = int.Parse(type);
            }
            string strWhere = string.Empty;
            if (typeId != 0)
            {
                strWhere = " News_type_id=" + typeId;
            }
            if (!Common.Utils.IsSafeSqlString(keyWord))
            {
                keyWord = "";
            }
            if (keyWord != "")
            {
                keyWord = keyWord.Replace("'", "");
                if (strWhere!="")
                {
                    strWhere = strWhere + " and News_title like '%" + keyWord + "%' ";
                }
                else
                {
                    strWhere = " News_title like '%" + keyWord + "%' ";
                }
                strWhere = strWhere + " and News_title like '%" + keyWord + "%' ";
            }
            switch(_action)
            {
                case "getAllNewsList":
                {
                    GetAllNewList(context, typeId, strWhere,page);
                    break;
                }
                case "getNewsPage":
                {
                    GetNewsPage(context, typeId, strWhere,page);
                    break;
                }
                default:
                    break;
            }
        }
        /// <summary>
        /// 获取所有新闻
        /// </summary>
        /// <param name="context"></param>
        private void GetAllNewList(HttpContext context, int typeId, string strWhere,int page)
        {
            //初始化置顶数据
            if(page==1)
            {
                var bll = new BLL.CCOM.News();
                var list = bll.GetModelList("News_top=1");
                for(int i=0;i<list.Count;i++)
                {
                    if(list[i].News_date!=null)
                    {
                        DateTime date = Convert.ToDateTime(list[i].News_date);
                        if (list[i].News_top_time!=null)
                        {
                            if(date.AddDays((double)list[i].News_top_time) < DateTime.Now)
                            {
                                var model = bll.GetModel(list[i].News_id);
                                model.News_top = false;
                                model.News_top_time = 0;
                                bll.Update(model);
                            }
                            
                        }
                        else
                        {
                            //若为空，默认为3天
                            if(date.AddDays(3.0) < DateTime.Now)
                            {
                                var model = bll.GetModel(list[i].News_id);
                                model.News_top = false;
                                model.News_top_time = 0;
                                bll.Update(model);
                            }
                        }
                    }
                }
            }
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            DataTable dt = new BLL.CCOM.News().GetListByPage(strWhere, "News_top DESC ,News_date DESC ", start_index, end_index).Tables[0];
            string json = ToJson(dt);
            context.Response.Write(json);
        }
        /// <summary>
        /// 获取页码
        /// </summary>
        /// <param name="context"></param>
        private void GetNewsPage(HttpContext context, int typeId, string strWhere, int page)
        {
            //var response = new HttpBaseResponse(); 
            int total_count = new BLL.CCOM.News().GetRecordCount(strWhere);
            string pageStr = Utils.OutPageList(pageSize, page, total_count, "javascript:gotoNewsPage(__id__);", 8, true);
            context.Response.Write(pageStr);
        }
        private string ToJson(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = new ArrayList();
                int news_type = 0; 
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, object> dictionary = new Dictionary<string, object>(); //实例化一个参数集合
                    foreach(DataColumn dc in dt.Columns)
                    {
                        dictionary.Add(dc.ColumnName, dr[dc.ColumnName].ToString());
                        string colname = dc.ColumnName;
                        if (dc.ColumnName == "News_type_id")
                        {
                            news_type = int.Parse(dr[dc.ColumnName].ToString());
                        }
                    }
                    //扩展News_type_name到新表
                    var model = new BLL.CCOM.News_type().GetModel(news_type);
                    if (model != null)
                    {
                        dictionary.Add("News_type_name", model.News_type_name);
                    }
                    else
                    {
                        dictionary.Add("News_type_name", "未分类");
                    }
                    arrayList.Add(dictionary); //ArrayList集合中添加键值
                }
                return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串
            }
            else
            {
                return null;
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