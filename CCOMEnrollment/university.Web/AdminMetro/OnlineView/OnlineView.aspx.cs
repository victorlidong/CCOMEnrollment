using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.OnlineView
{
    public partial class OnlineView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var src = Server.UrlDecode(MyRequest.GetQueryString("src"));
            var name = Server.UrlDecode(MyRequest.GetQueryString("name"));
            if (src != null&&File.Exists(Server.MapPath(src)))
            {
                var fileExt = src.Substring(src.LastIndexOf('.') + 1);
                if (Utils.IsOfficeExt(fileExt))
                {
                    ViewOffice(src,name);
                }
                else if (Utils.IsImgExt(fileExt))
                {
                    ViewImage(src,name);
                }
                else if (Utils.IsPdfExt(fileExt))
                {
                    ViewPdf(src,name);
                }
                else if (Utils.IsTxtExt(fileExt))
                {
                    ViewTxt(src, name);
                }
                else
                {
                    this.divViewer.InnerText = "暂时无法支持该类型文件的预览！";
                }
            }
            else
            {
                this.divViewer.InnerText = "无法预览文件！";
            }
        }

        protected void ViewPdf(String relativeFilePath,String name)
        {
            var url = "/AdminMetro/OnlineView/OnlinePdfView.aspx?src=" + Server.UrlEncode(relativeFilePath);
            url += "&name=" + Server.UrlEncode(name);
            Response.Redirect(url);
        }

        protected void ViewTxt(String relativeFilePath, String name)
        {
            var url = "/AdminMetro/OnlineView/OnlineTxtView.aspx?src=" + Server.UrlEncode(relativeFilePath);
            url += "&name=" + Server.UrlEncode(name);
            Response.Redirect(url);
        }

        protected void ViewImage(String relativeFilePath, String name)
        {
            var url = "/AdminMetro/OnlineView/OnlineImgView.aspx?src=" + Server.UrlEncode(relativeFilePath);
            url += "&name=" + Server.UrlEncode(name);
            Response.Redirect(url);
        }

        protected void ViewOffice(String relativeFilePath, String name)
        {
            var msOfficeOnlineViewService = OnlineViewHelper.GetMsOnlineOfficeViewServiceUrl();
            var src = "http://" + Common.MyRequest.GetCurrentFullHost() + relativeFilePath.Replace("\\", "/");
            var url = msOfficeOnlineViewService + "?src=" + Server.UrlEncode(src);
            Response.Redirect(url);
        }
    }
}