using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.OnlineView
{
    public partial class OnlinePdfView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var src = Server.UrlDecode(MyRequest.GetQueryString("src"));
            if (src != null)
            {
                var fileExt = src.Substring(src.LastIndexOf('.') + 1);
                if (Utils.IsPdfExt(fileExt))
                {
                    ResponsePreview(src);
                }

            }
        }
        protected void ResponsePreview(String pdfFilePath)
        {
            string fileName = FileOperate.GetFileName(pdfFilePath);
            Response.ContentType = "Application/pdf";
            Response.AddHeader("content-disposition", "filename=" + fileName);
            Response.WriteFile(Server.MapPath(pdfFilePath));
            Response.End();
        }
    }
}