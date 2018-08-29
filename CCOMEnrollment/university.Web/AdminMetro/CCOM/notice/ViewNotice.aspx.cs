using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notice
{
    public partial class ViewNotice : university.UI.ManagePage
    {
        public ViewNotice()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        private static String tokenValidateUrl = ConfigurationManager.AppSettings["ApiServerUrl"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //将Page_Load里的处理逻辑挪到此方法中，客户端种完js后再由前台调用此方法，通过隐藏域传token
        protected void PushRedirect(object sender, EventArgs e)
        {
            String pushId = "";
            Int64 userid = 0;
            String token = "";
            String userAgent = "";

            if (Request.Headers["user-agent"] != null)
            {
                userAgent = Request.Headers["user-agent"].ToString();
            }
            pushId = MyRequest.GetString("id");
            try
            {
                pushId = DESEncrypt.Decrypt(pushId);
            }
            catch
            {
                Response.Redirect("/home/push/template/push_error.html");
            }
            try
            {
                if (IsAdminLogin())
                {
                    userid = GetAdminInfo_CCOM().User_id;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/home/push/template/push_error.html");
            }

            ShowWebPush(userid, pushId);
        }

        #region "Web Push"
        private void ShowWebPush(Int64 userid, String pushId)
        {
            String name = NoticeHtml.GetWebPushPath(long.Parse(pushId));
            NoticeHtml.CreateWebPushHtml(pushId, Server.MapPath(name));

            if (!System.IO.File.Exists(Server.MapPath(name)))
            {
                Response.Redirect("/home/push/template/push_404.html");
            }
            else
            {
                UpdateReadStatus(userid, pushId);
                Response.Redirect(name);
            }
        }
        #endregion

        //更新阅读状态
        private void UpdateReadStatus(long userId,string noticeId)
        {
            BLL.CCOM.User_notice bll = new BLL.CCOM.User_notice();
            Model.CCOM.User_notice model = bll.GetModel("User_id="+userId);
            string[] notices = model.Notice_id.Split(',');
            string readNotice = model.Notice_read_id;
            int index = -1;

            
            if(notices!=null&&notices.Length>0)
            {
                for(int i=0;i<notices.Length;i++)
                {
                    if(notices[i]==noticeId)
                    {
                        index = i;
                        break;
                    }
                }
                if(index>=0)
                {
                    string notice_id = string.Empty;
                    for(int i=0;i<notices.Length;i++)
                    {
                        if(i!=index)
                        {
                            notice_id += notices[i] + ",";
                        }
                    }
                    //从未读中去除
                    if (notice_id.Length>0)
                    {
                        notice_id = notice_id.Substring(0, notice_id.Length - 1);//去除最后一个分隔符
                    }
                        
                    //加入已读中
                    if (readNotice != null)
                    {
                        if (readNotice.Length==0)
                        {
                            readNotice = notices[index];
                        }
                        else
                        {
                            readNotice = readNotice + "," + notices[index];
                        }
                        
                    }
                    model.Notice_id = notice_id;
                    model.Notice_read_id = readNotice;
                    bll.Update(model);
                }
                
            }   
        }
    }
}