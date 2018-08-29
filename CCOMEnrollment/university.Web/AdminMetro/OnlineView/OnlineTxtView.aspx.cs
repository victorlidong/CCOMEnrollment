using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.OnlineView
{
    public partial class OnlineTxtView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var src = Server.UrlDecode(MyRequest.GetQueryString("src"));
            var name = Server.UrlDecode(MyRequest.GetQueryString("name"));
            if (src != null)
            {
                var fileExt = src.Substring(src.LastIndexOf('.') + 1);
                if (Utils.IsTxtExt(fileExt))
                {
                    //读取文件显示
                    if (File.Exists(Server.MapPath(src)))
                    {
                        ShowFileName(src, name);
                        //var content = FileOperate.Read_Txt(Server.MapPath(src), code);
                        var content = FileOperate.ReadFile(Server.MapPath(src), Encoding.Default);
                        content = content.Replace("\n", "<br />");
                        this.txtContainner.InnerHtml = content;
                        //ResponsePreview(src);
                    }
                    else
                    {
                        this.txtContainner.InnerHtml = "预览文件不存在！";
                    }
                }
            }
        }

     
        protected  void ResponsePreview( string inFilePath)
        {
            string fileName = FileOperate.GetFileName(inFilePath);
           Response.ContentType = "text/plain";
           Response.ContentEncoding = System.Text.Encoding.UTF8;  //保持和文件的编码格式一致
           Response.AddHeader("content-disposition", "filename=" + fileName);
           Response.WriteFile(Server.MapPath(inFilePath));
           Response.End();
        }
        protected void ShowFileName(String inFilePath, String fileName)
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
        {
            if (fileName=="")
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