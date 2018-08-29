using System;
using System.IO;
using System.Web;
using university.Common;

namespace university.Web.home.news
{
    public partial class Attach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                String filePath = HttpUtility.UrlDecode(MyRequest.GetQueryString("address"));
                String fileName = HttpUtility.UrlDecode(MyRequest.GetQueryString("name"));
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
}
