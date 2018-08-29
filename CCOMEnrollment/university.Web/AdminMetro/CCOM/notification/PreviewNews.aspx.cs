using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace university.Web.AdminMetro.CCOM.notification
{
    public partial class PreviewNews : university.UI.ManagePage
    {
        public PreviewNews()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["preview_news"] != null)
            {
                var newsObj = Session["preview_news"] as PreviewNewsObject;
                if (newsObj != null)
                {
                    this.txtHeadTitle.Text =  newsObj.Title;
                    this.txtTitle.InnerHtml = newsObj.Title;
                    this.txtDes.InnerHtml = newsObj.NewsDes;
                    this.txtContent.InnerHtml = newsObj.Content;
                    this.txtAttach.InnerHtml = newsObj.AttachList;
                }
                else
                {
                    this.txtBody.InnerHtml = "预览失败！";
                }
            }
            else
            {
                this.txtBody.InnerHtml = "预览失败！";
            }
        }
    }
}