using LitJson;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using university.Common;
using university.Database;

namespace university.Web.AdminMetro.CCOM.notice
{
    /// <summary>
    /// NoticeHandler 的摘要说明
    /// </summary>
    public class NoticeHandler : IHttpHandler, IRequiresSessionState
    {

        private const long OK = 200;
        private const long ERROR = 201;
        private static readonly ILog logger = LogManager.GetLogger("quanquan");
        private const int pageSize = 10;
        private static string RESEND_PUSH_URL = "http://if.quanquan6.com/?if=ReSendPush";

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                switch (context.Request["action"])
                {
                    
                    case "getStatisticData":
                        GetStatisticData(context);
                        break;
                    
                    case "checkSmsApply":
                        CheckSmsApply(context);
                        break;
                    case "denySmsApply":
                        DenySmsApply(context);
                        break;
                    case "getUserNotice":
                        GetUserNotice(context);
                        break;
                    case "addPushType":   //添加推送类别
                        AddPushType(context);
                        break;
                    case "getSelectedUserCount":
                        GetSelectedUserCount(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = ex.ToString() }));
            }
        }

        private void GetStatisticData(HttpContext context)
        {
            if (!IsAdminLogin())
            {
                FlushResponse(context, "[]");
                return;
            }
            int count = 0;
            var model = new BLL.CCOM.User_notice().GetModel(" User_id="+GetUserId());
            if(model!=null)
            {
                string notice_ids = model.Notice_id;
                var bll = new BLL.CCOM.Notice();
                Model.CCOM.Notice notice_model = null;
                DataTable dt = new DataTable();
                dt.Columns.Add("Notice_id");
                dt.Columns.Add("Notice_content");
                dt.Columns.Add("Notice_date");
                dt.Columns.Add("Notice_read_status");//0：未读，1：已读
                if (notice_ids!=null&&notice_ids.Length > 0)
                {
                    string[] _ids = notice_ids.Split(',');
                    for(int i=_ids.Length-1;i>=0;i--)//反序则时间递减
                    {
                        notice_model = bll.GetModel(long.Parse(_ids[i]));
                        if(notice_model!=null)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Notice_id"] =DESEncrypt.Encrypt(notice_model.Notice_id.ToString());
                            if(notice_model.Notice_type!=null&&(bool)notice_model.Notice_type)
                            {
                                dr["Notice_content"] = notice_model.Notice_title;
                            }
                            else
                            {
                                dr["Notice_content"] = notice_model.Notice_content;
                            }
                            dr["Notice_date"] = notice_model.Notice_date;
                            dr["Notice_read_status"] = 0;
                            dt.Rows.Add(dr);
                            dt.AcceptChanges();   
                            count++;
                            if(count>=10)
                            {
                                break;
                            }
                        }
                    }
                 
                }
                if (count < 10)//未读不足10条，从已读取
                {
                    string read_ids = model.Notice_read_id;
                    if (read_ids != null && read_ids.Length > 0)
                    {
                        string[] _read = read_ids.Split(',');
                        if (_read.Length > 0)
                        {
                            for (int i = _read.Length - 1; i >= 0; i--)
                            {
                                notice_model = bll.GetModel(long.Parse(_read[i]));
                                if (notice_model != null)
                                {
                                    DataRow dr = dt.NewRow();
                                    dr["Notice_id"] = DESEncrypt.Encrypt(notice_model.Notice_id.ToString());
                                    if (notice_model.Notice_type != null && (bool)notice_model.Notice_type)
                                    {
                                        dr["Notice_content"] = notice_model.Notice_title;
                                    }
                                    else
                                    {
                                        dr["Notice_content"] = notice_model.Notice_content;
                                    }
                                    dr["Notice_date"] = notice_model.Notice_date;
                                    dr["Notice_read_status"] = 1;
                                    dt.Rows.Add(dr);
                                    dt.AcceptChanges();   
                                    count++;
                                    if (count >= 10)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                string result=ToJson(dt);
                context.Response.Write(result);
            }
            else
            {
                context.Response.Write("[]");
            }
        }

        private void CheckSmsApply(HttpContext context)
        {
        //    string SMS_apply_id = context.Request.Params["SMS_apply_id"];
        //    if(!string.IsNullOrEmpty(SMS_apply_id))
        //    {
        //        long id=long.Parse(SMS_apply_id);
        //        BLL.CCOM.SMS_apply_record bll=new BLL.CCOM.SMS_apply_record();
        //        var model = bll.GetModel(id);
        //        if(model!=null)
        //        {
        //            string SMS_check_reason = context.Request.Params["reason"];
        //            model.SMS_check_reason = SMS_check_reason;
        //            model.SMS_give_number = int.Parse(context.Request.Params["agree_number"]);
        //            model.SMS_apply_status = SmsConfig.Status_Success;
        //            bool result=bll.Update(model);
        //            if(result)//更新余量
        //            {
        //                var sms_bll=new BLL.CCOM.User_sms();
        //                var user_sms_model = sms_bll.GetModel(" User_id=" + model.User_id);
        //                if(user_sms_model!=null)
        //                {
        //                    user_sms_model.User_sms_modify_time = DateTime.Now;
        //                    user_sms_model.User_sms_left = user_sms_model.User_sms_left + model.SMS_give_number;
        //                    result= sms_bll.Update(user_sms_model);
        //                }
        //                else
        //                {
        //                    Model.CCOM.User_sms sms_model = new Model.CCOM.User_sms();
        //                    sms_model.User_sms_left = model.SMS_give_number;
        //                    sms_model.User_id = model.User_id;
        //                    sms_model.User_sms_create_time = DateTime.Now;
        //                    sms_bll.Add(sms_model);
        //                }
        //            }
        //            context.Response.Write(result);
        //        }
        //    }
        }

        private void DenySmsApply(HttpContext context)
        {
        //    string SMS_apply_id = context.Request.Params["SMS_apply_id"];
        //    if(!string.IsNullOrEmpty(SMS_apply_id))
        //    {
        //        long id = long.Parse(SMS_apply_id);
        //        BLL.CCOM.SMS_apply_record bll = new BLL.CCOM.SMS_apply_record();
        //        var model = bll.GetModel(id);
        //        if(model!=null)
        //        {
        //            string SMS_check_reason = context.Request.Params["reason"];
        //            model.SMS_check_reason = SMS_check_reason;
        //            model.SMS_apply_status = SmsConfig.Status_Fail;
        //            bool result = bll.Update(model);
        //            context.Response.Write(result);
        //        }
        //    }
        }

        private static int SortA(NoticeItem a1, NoticeItem a2)
        {
            return Convert.ToDateTime(a1.Date) > Convert.ToDateTime(a2.Date) ? -1 : 1;
        }

        private void GetSelectedUserCount(HttpContext context)
        {
            
            string deptList = context.Request.Params["deptList"];
            string groupList = context.Request.Params["groupList"];
            string userList = context.Request.Params["userList"];
            List<string> userIdList = new List<string>();
            if(!string.IsNullOrEmpty(deptList))
            {
                var list = deptList.Split(',').ToList();
            }
            if(!string.IsNullOrEmpty(groupList))
            {
                var list = groupList.Split(',').ToList();
                var bll = new BLL.CCOM.User_property();
                for(int i=0;i<list.Count;i++)
                {
                    var modelList = bll.GetModelList(" Agency_id=" + list[i]);
                    for(int j=0;j<modelList.Count;j++)
                    {
                        if(!userIdList.Contains(modelList[j].User_id.ToString()))
                        {
                            userIdList.Add(modelList[j].User_id.ToString());
                        }
                    }
                }
            }
            if(!string.IsNullOrEmpty(userList))
            {
                var list = userList.Split(',').ToList();
                for(int i=0;i<list.Count;i++)
                {
                    if(!userIdList.Contains(list[i]))
                    {
                        userIdList.Add(list[i]);
                    }
                }
            }
            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = userIdList.Count.ToString() }));
            //context.Response.Write(count);
        }
        /// <summary>
        /// 根据与用户相关的推送通知
        /// </summary>
        /// <param name="context"></param>
        public void GetUserNotice(HttpContext context)
        {
            try
            {
                if (!IsAdminLogin())
                {
                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "error" }));
                    return;
                }
                var userId = GetAdminInfo().User_id;
                //var topN = 10;
                //var pushNewsItemList = new List<NoticeItem>();
                string notice_type = context.Request.Params["notice_type"];
                int page = int.Parse(context.Request.Params["page"]);
                var model = new BLL.CCOM.User_notice().GetModel("User_id=" + userId);
                if(notice_type!=null&&notice_type!="")
                {
                    StringBuilder ulSb = new StringBuilder();
                    string[] notice_ids=null;
                    if (notice_type == "no_read")
                    {
                        string ids = model.Notice_id;
                        if(ids!=null&&ids.Length>0&&ids!="")
                        {
                            notice_ids = ids.Split(','); 
                        } 
                    }
                    else
                    {
                        string ids =model.Notice_read_id;
                        if (ids != null && ids.Length > 0 && ids != "")
                        {
                            notice_ids = ids.Split(',');
                        }
                    }
                    var sb = new StringBuilder();
                    if (notice_ids!=null&&notice_ids.Length > 0)
                    {
                        for (int i = 0; i < notice_ids.Length; i++)
                        {
                            if (i == 0)
                            {
                                sb.Append("Notice_id=" + notice_ids[i]);
                            }
                            else
                            {
                                sb.Append(" or Notice_id=" + notice_ids[i]);
                            }
                        }
                        int start_index = pageSize * (page - 1) + 1;
                        int end_index = pageSize * page;
                        DataTable dt = new BLL.CCOM.Notice().GetListByPage(sb.ToString(), "Notice_date DESC ", start_index, end_index).Tables[0];
                        
                        if (dt.Rows.Count > 0)
                        {
                            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
                            string realname = string.Empty;
                            foreach (DataRow dr in dt.Rows)
                            {
                                var content = "";
                                content = "<a href=\"ViewNotice.aspx?id=" + DESEncrypt.Encrypt(dr["Notice_id"].ToString()) + "\" target=\"_blank\">";
                                content += dr["Notice_title"] + "</a>";
                                content += "<br />";
                                content += dr["Notice_content"];
                                try
                                {
                                    realname = user_bll.GetModel(Convert.ToInt32(dr["Notice_sender_id"])).User_realname;
                                }
                                catch
                                {
                                    realname = "---";
                                }
                                ulSb.Append("<li>");
                                ulSb.Append("<div class=\"media\">");
                                ulSb.Append("<span class=\"label pull-left label-success\"><i class=\"icon-bell\"></i></span>");
                                ulSb.Append("<div class=\"media-body\">");
                                ulSb.Append("<div class=\"notice-collapse\" style=\"padding: 5px;\">");
                                ulSb.Append("<div class=\"text\" style=\"padding: 2px 4px; text-decoration: none;\">");
                                ulSb.Append(" <p style=\"font-weight:bold;\">" + content + "</p>");
                                ulSb.Append(" <p class=\"attribution\">" + realname + "&nbsp;&nbsp;" + ((DateTime)dr["Notice_date"]).ToString("yyyy-MM-dd HH:mm") + "</p>");
                                ulSb.Append("</div>");
                                ulSb.Append("</div>");
                                ulSb.Append("</div>");
                                ulSb.Append("</div>");
                                ulSb.Append("</li>");
                            }
                        }
                        else
                        {
                            ulSb.Append("<li style=\"height:40px;font-size:18px;text-align:center;padding-top:21px;\">暂无通知消息！</li>");
                        }
                        
                    }
                    else
                    {
                        ulSb.Append("<li style=\"height:40px;font-size:18px;text-align:center;padding-top:21px;\">暂无通知消息！</li>");
                    }
                    context.Response.Write(ulSb.ToString());
                    //string json = ToJson(dt);
                }
                else//传参不正确
                {
                    
                }  
            }
            catch (Exception ex)
            {
                String logContent = "GetUserNotice-";
                logContent += "Ex:" + ex.ToString() + "\r\n";
                Common.FileOperate.WriteFile(context.Server.MapPath("error-" + DateTime.Now.ToString("yyyyMMdd") + ".txt"), logContent);
                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "error" }));
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
            var typeBll = new BLL.CCOM.Notice_type();
            var userId = GetAdminInfo().User_id;
            var roleType = GetUserRoleType();
            var roleId = GetRoleUserId();

            string strWhere = "Notice_type_name='" + typeName + "'";
            if (typeBll.GetModelList(strWhere).Count == 0)
            {
                var typeModel = new Model.CCOM.Notice_type()
                {
                    Notice_type_name = typeName,
                    Notice_type_creator_id = userId,
                    Notice_type_date = DateTime.Now
                };

                var typeId = typeBll.Add(typeModel);
                //添加成功，返回typeId和typeName
                if (typeId > 0)
                {
                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnType() { Result = OK, Msg = "推送类别添加成功！", id = DESEncrypt.Encrypt(typeId.ToString()), name = typeName }));
                }
                else
                {
                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "推送类别添加失败！" }));
                }
            }
            else
            {
                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "该通知类别已存在！" }));
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

        private long GetUserId()
        {
            var model = HttpContext.Current.Session[MyKeys.SESSION_ADMIN_INFO] as Model.CCOM.User_information;
            return model.User_id;
        }

        

        /// <summary>
        ///获取用户身份表(即用户小表-SchoolUser、SocialUser、AdminUser)的UserId
        /// </summary>
        /// <returns></returns>
        public Int64 GetRoleUserId()
        {
            if (HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID] != null)
            {
                return Convert.ToInt64(HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID]);
            }
            return 0;
        }

        /// <summary>
        /// 获取用户当前的身份类型(0-SchoolUser，1-SocialUser，2-AdminUser)
        /// </summary>
        /// <returns></returns>
        public Int32 GetUserRoleType()
        {
            if (HttpContext.Current.Session[MyKeys.SESSION_USER_TABLE] != null)
            {
                return (int)((MyEnums.UserStatus)HttpContext.Current.Session[MyKeys.SESSION_USER_TABLE]);
            }
            return 0;
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

    class NoticeItem
    {
        public String Id { get; set; }
        public String Type { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public String From { get; set; }
        public String Date { get; set; }
    }

    class ReturnPushList
    {
        public long Result { get; set; }
        public int Count { get; set; }
        public String Msg { get; set; }
    }
}