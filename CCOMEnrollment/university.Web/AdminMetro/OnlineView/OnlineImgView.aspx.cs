using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.OnlineView
{
    public partial class OnlineImgView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var src = Server.UrlDecode(MyRequest.GetQueryString("src"));
            var name = Server.UrlDecode(MyRequest.GetQueryString("name"));
            if (src != null)
            {
                 var fileExt = src.Substring(src.LastIndexOf('.') + 1);
                if (Utils.IsImgExt(fileExt))
                {
                    ShowFileName(src, name);
                    this.imgViewer.ImageUrl = src;
                }
            
            }
        }

        protected void ShowFileName(String inFilePath,String fileName)
        {
            if (fileName == "")
            fileName = FileOperate.GetFileName(inFilePath);
            this.divFileName.InnerText = fileName;
        }
        protected void Button1_OnClick(object sender, EventArgs e)
        {
            var src = Server.UrlDecode(MyRequest.GetQueryString("src"));
            var name = Server.UrlDecode(MyRequest.GetQueryString("name"));
            DownLoadFile(src, name);
        }
        protected void DownLoadFile(String filePath, string fileName)
        {   if (fileName=="")
            fileName = FileOperate.GetFileName(filePath);
            filePath = Server.MapPath(filePath);
            var file = new System.IO.FileInfo(filePath);
            if (System.IO.File.Exists(filePath) & filePath.Contains("upload"))
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition",
                    "attachment;   filename=" + HttpUtility.UrlEncode(fileName));
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                Response.WriteFile(file.FullName);
                Response.Flush();
                //Response.End();
            }
            else
            {
                Response.Write("附件不存在！");
                Response.Flush();
            }
        }
    }
}