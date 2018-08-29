using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notification
{
    public partial class News : university.UI.ManagePage
    {
        public News()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitialNewsType();
            }
        }
        private void InitialNewsType()
        {
            var news_type_list = new BLL.CCOM.News_type().GetModelList("");
            if (news_type_list != null && news_type_list.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                var className = "btn btn-success";
                //添加全部一栏
                sb.Append("<input type=\"hidden\" name=\"typeId\" value='" +
                                            DESEncrypt.Encrypt("0") + "' />");
                sb.Append("<a href=\"javascript:;\" class='" + className +
                                     "' onclick='newsTypeTabs(\"#newsList\",\"" +
                                     DESEncrypt.Encrypt("0") + "\",this)'>");
                sb.Append("全部</a>&nbsp;&nbsp;");
                int index = 0;
                for (int i = 0; i < news_type_list.Count; i++)
                {
                    var className1 = "btn";

                    sb.Append("<input type=\"hidden\" name=\"typeId\" value='" +
                                        DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString()) + "' />");
                    sb.Append("<a href=\"javascript:;\" class='" + className1 +
                                     "' onclick='newsTypeTabs(\"#newsList\",\"" +
                                     DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString()) + "\",this)'>");
                    sb.Append(news_type_list[i].News_type_name + "</a>&nbsp;&nbsp;");
                    index++;
                }
                this.divNewsType.InnerHtml = sb.ToString();
            }
        }
        
    }
}