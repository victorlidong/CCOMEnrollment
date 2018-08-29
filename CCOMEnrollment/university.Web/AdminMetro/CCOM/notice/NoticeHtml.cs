using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using university.Common;
using university.Web.AdminMetro.OnlineView;

namespace university.Web.AdminMetro.CCOM.notice
{
    public class NoticeHtml
    {
        public static String WebPushBaseDir = "/home/push/web/";
        //获取Web通知的相对路径
        public static String GetWebPushPath(long pushId)
        {
            return GetPushPath(WebPushBaseDir, pushId);
        }

        //获取通知的相对路径
        private static String GetPushPath(String PushBaseDir, long pushId)
        {
            var datePath = GetPushDatePath(pushId);
            var baseDir = PushBaseDir + datePath;
            var toFileFullPath = Utils.GetMapPath(baseDir);

            //检查是否有该路径,没有就创建
            if (!Directory.Exists(toFileFullPath))
            {
                Directory.CreateDirectory(toFileFullPath);
            }
            return baseDir + DESEncrypt.Encrypt(pushId.ToString()) + ".html";
        }

        /// <summary>
        /// 获取通知生成的日期目录
        /// </summary>
        /// <param name="pushId">通知Id</param>
        private static string GetPushDatePath(long pushId)
        {
            var m = new BLL.CCOM.Notice().GetModel(pushId);
            if (m == null || m.Notice_date == null)
            {
                return "";
            }

            //按年月/日存入不同的文件夹
            DateTime dt = Convert.ToDateTime(m.Notice_date);
            return dt.ToString("yyyyMM") + "/" + dt.ToString("dd") + "/";
        }

        //生成静态页
        public static void CreateHtml(long pushId, bool checkExists)
        {
            
        
            String webname = GetWebPushPath(pushId);
            CreateWebPushHtml(pushId.ToString(), Utils.GetMapPath(webname), checkExists);
        }

       
        //web html push
        public static void CreateWebPushHtml(String pushId, String fileName)
        {
            CreateWebPushHtml(pushId, fileName, true);
        }

        public static void CreateWebPushHtml(String pushId, String fileName, bool checkExists)
        {
            if ((!checkExists) || (!System.IO.File.Exists(fileName)))
            {
                var push = new BLL.CCOM.Notice().GetModel(Int64.Parse(pushId));
                if (push != null)
                {
                    //根据通知类型，读取对应的模板文件
                    string temp = HttpContext.Current.Server.MapPath("/AdminMetro/CCOM/notice/Notice_temp.html");
                    //图文通知
                    if (push.Notice_type!=null&&(bool)push.Notice_type)
                    {
                        temp = HttpContext.Current.Server.MapPath("/AdminMetro/CCOM/notice/Notice_image_temp.html");
                    }

                    String pushStr = FileOperate.ReadFile(temp);

                    //替换推送者
                    string realname = new BLL.CCOM.User_information().GetModel(push.Notice_sender_id).User_realname;
                    pushStr = pushStr.Replace("authorxxx", realname);

                    //替换发布日期
                    pushStr = pushStr.Replace("pubdatexxx", push.Notice_date.ToString());

                    //替换通知内容
                    String content = HttpContext.Current.Server.HtmlDecode(push.Notice_content);
                    pushStr = pushStr.Replace("contentxxx", content);

                    //替换标题
                    pushStr = pushStr.Replace("titlexxx", push.Notice_title);

                    //图文通知还需要替换附件
                    if (push.Notice_type!=null&&(bool)push.Notice_type)
                    {
                        //替换附件
                        StringBuilder sb = new StringBuilder();

                        var attachList = new BLL.CCOM.Notice_attach().GetModelList("Notice_id = " + pushId);
                        if (attachList.Count > 0)
                        {
                            sb.Append("<p class='attachTitle'>附件：</p>");
                            var itemCnt = 1;
                            foreach (var item in attachList)
                            {
                                sb.Append("<p class='attachItem'>(").Append(itemCnt).Append(")&nbsp;<a href='")
                                    .Append("/home/push/Attach.aspx?id=").Append(DESEncrypt.Encrypt(item.Notice_attach_id.ToString()))
                                    .Append("&address=").Append(HttpUtility.UrlEncode(item.Notice_attach_address))
                                    .Append("&name=").Append(HttpUtility.UrlEncode(item.Notice_attach_name))
                                    .Append("' target='_blank' >")
                                    .Append(item.Notice_attach_name)
                                    .Append("</a>")
                                    .Append(OnlineViewHelper.GetOnlineViewWrapLink(item.Notice_attach_address, item.Notice_attach_name))
                                    .Append("</p>");
                                itemCnt++;
                            }
                        }
                        pushStr = pushStr.Replace("attachxxx", sb.ToString());
                    }

                    //写文件
                    FileOperate.WriteNewFile(fileName, pushStr);
                }
            }
        }

    }
}