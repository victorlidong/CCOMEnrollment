using log4net;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notification
{
    /// <summary>
    /// News_handler 的摘要说明
    /// </summary>
    public class News_handler : IHttpHandler, IRequiresSessionState
    {
        private const long OK = 200;
        private const long ERROR = 201;
        private static readonly ILog logger = LogManager.GetLogger("中央音乐学院");
        private const int pageSize = 10;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string _action = context.Request.Params["action"];
            switch(_action)
            {
                case "addPushType":
                    {
                        AddPushType(context);
                        break;
                    }
                case "get_news_type":
                    {
                        GetNewsTypeName(context);
                        break;
                    }
                case "editNewsType":
                    {
                        EditNewsType(context);
                        break;
                    }
                default:
                    break;
            }
            
        }

        /// <summary>
        /// 添加通知类别
        /// </summary>
        /// <param name="context"></param>
        private void AddPushType(HttpContext context)
        {
            if (!IsAdminLogin())
            {
                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "error" }));
                return;
            }

            String typeName = MyRequest.GetString("t").Trim();
            if (!Common.Utils.IsSafeSqlString(typeName) || typeName == "")
            {
                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
                return;
            }

            //添加通知类别
            var typeBll = new BLL.CCOM.News_type();
            var userId = GetAdminInfo().User_id;

            string strWhere = " News_type_name='" + typeName + "'";
            if (typeBll.GetModelList(strWhere).Count == 0)
            {
                var typeModel = new Model.CCOM.News_type()
                {
                    News_type_name = typeName,
                    News_type_creator_id = (int)userId,
                    News_type_date = DateTime.Now
                };

                var typeId = typeBll.Add(typeModel);
                //添加成功，返回typeId和typeName
                if (typeId > 0)
                {
                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnType() { Result = OK, Msg = "资讯类别添加成功！", id = DESEncrypt.Encrypt(typeId.ToString()), name = typeName }));
                }
                else
                {
                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "资讯类别添加失败！" }));
                }
            }
            else
            {
                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "该资讯类别已存在！" }));
            }
        }


        private void EditNewsType(HttpContext context)
        {
            string news_type_name = context.Request.Params["t"].Trim();
            if (!Common.Utils.IsSafeSqlString(news_type_name) || news_type_name == "")
            {
                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
                return;
            }
            string news_type_id = context.Request.Params["news_type_id"];
            if(!string.IsNullOrEmpty(news_type_id))
            {
                int _id = 0;
                try
                {
                    _id = int.Parse(DESEncrypt.Decrypt(news_type_id));
                }
                catch
                {
                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
                    return;
                }
                var bll=new BLL.CCOM.News_type();
                var model = bll.GetModel(_id);
                
                if(model!=null)
                {
                    model.News_type_name = news_type_name;
                    bool result = bll.Update(model);
                    if(result)
                    {
                        FlushResponse(context, JsonConvert.SerializeObject(new ReturnType() { Result = OK, Msg = "资讯类别修改成功！", id = DESEncrypt.Encrypt(model.News_type_id.ToString()), name = news_type_name }));
                    }
                    else
                    {
                        FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "资讯类别修改失败！" }));
                    }
                }
                else
                {
                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
                    
                }
            }
            else
            {
                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
            }
        }

        private void GetNewsTypeName(HttpContext context)
        {
            //int type_id=0;
            //string result = "未分类";
            //try
            //{
            //    type_id = int.Parse(context.Request.Params["news_type"]);

            //}
            // catch
            //{
            //    type_id = 0;
            //}
            //Model.CCOM.News_type model = new BLL.CCOM.News_type().GetModel(type_id);
            //if(model!=null)
            //{
            //    result = model.News_type_name;
            //}
            //context.Response.Write(result);
            var news_type = new BLL.CCOM.News_type().GetAllList().Tables[0];
            if(news_type!=null&&news_type.Rows.Count>0)
            {
                string result = ToJson(news_type);
                context.Response.Write(result);
            }
        }
        #region===============datatable转json
        private string ToJson(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = new ArrayList();
                
                foreach (DataRow dr in dt.Rows)
                {
                    Dictionary<string, object> dictionary = new Dictionary<string, object>(); //实例化一个参数集合
                    foreach (DataColumn dc in dt.Columns)
                    {
                        dictionary.Add(dc.ColumnName, dr[dc.ColumnName].ToString());
                        
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

        #endregion


        #region 底层通用方法
        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns></returns>
        private bool IsAdminLogin()
        {
            //如果Session为Null
            if (HttpContext.Current.Session[MyKeys.SESSION_ADMIN_INFO] != null)
            {
                return true;
            }
            return false;
        }

        
        /// <summary>
        /// 取得用户信息
        /// </summary>
        public Model.CCOM.User_information GetAdminInfo()
        {
            if (IsAdminLogin())
            {
                Model.CCOM.User_information model = HttpContext.Current.Session[MyKeys.SESSION_ADMIN_INFO] as Model.CCOM.User_information;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }
        private void FlushResponse(HttpContext context, String res)
        {
            context.Response.Write(res);
            context.Response.Flush();
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    class ReturnObject
    {
        public long Result { get; set; }
        public String Msg { get; set; }
    }

    class ReturnType
    {
        public long Result { get; set; }
        public String Msg { get; set; }
        public String id { get; set; }
        public String name { get; set; }
    }

}