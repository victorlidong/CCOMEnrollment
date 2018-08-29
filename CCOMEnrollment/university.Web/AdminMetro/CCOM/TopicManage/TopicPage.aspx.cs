using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.IO;

namespace university.Web.AdminMetro.CCOM.TopicManage
{
    public partial class TopicPage : university.UI.ManagePage
    {
        public long TopicID;//修改参数
        public TopicPage()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TopicID = 0;
            TopicID = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("topicid")));
            //TopicID = 3;
            if (!Page.IsPostBack)
            {
                if (TopicID == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                ShowInfo();
            } 
        }

        #region 赋值操作=================================
        public void ShowInfo()
        {
            var model = new BLL.CCOM.Topic().GetModel(TopicID);
            this.lblName.InnerText = model.Topic_name;
            if (model.Topic_source != null) this.lblSource.InnerText = model.Topic_source;
            else this.lblSource.InnerText = "--";
            if (model.Topic_nature != null) this.lblNature.InnerText = model.Topic_nature;
            else this.lblNature.InnerText = "--";
            if (model.Topic_content != null) this.lblContent.InnerText = model.Topic_content;
            else this.lblContent.InnerText = "--";
            if (model.Topic_task != null) this.lblTask.InnerText = model.Topic_task;
            else this.lblTask.InnerText = "--";
        }
        #endregion

    }
}