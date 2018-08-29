using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.Data;
using System.Text;

namespace university.Web.AdminMetro.CCOM.TopicManage
{
    public partial class BatchCheck : university.UI.ManagePage
    {
        public BatchCheck()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        String TopicIDS = "";
        string[] topics;
        protected void Page_Load(object sender, EventArgs e)
        {
            TopicIDS = MyRequest.GetQueryString("id");
            topics = TopicIDS.Split(',');
            if (!IsPostBack)
            {
                
            }
         
        }

        protected void btnSubmit_Success(object sender, EventArgs e)
        {
            BLL.CCOM.Topic bll = new BLL.CCOM.Topic();
            for (int i = 0; i < topics.Length; i++) {
                try
                {
                    Model.CCOM.Topic model = bll.GetModel(" Topic_id=" + topics[i]);
                    if (model != null)
                    {
                        model.Check_state = 1;
                        if (bll.Update(model))
                        {
                            JscriptMsg("审核成功啦！", "TopicCheckList.aspx?fun_id=" + get_fun_id("CCOM/TopicManage/TopicCheckList.aspx"), "Success");

                        }
                        else
                        {
                            JscriptMsg("审核失败", "TopicCheckList.aspx?fun_id=" + get_fun_id("CCOM/TopicManage/TopicCheckList.aspx"), "Success");

                        }
                    }
                }
                catch {
                    continue;
                }
                
            }
        }

        protected void btnSubmit_Error(object sender, EventArgs e)
        {
            BLL.CCOM.Topic bll = new BLL.CCOM.Topic();
            for (int i = 0; i < topics.Length; i++)
            {
                try
                {
                    Model.CCOM.Topic model = bll.GetModel(" Topic_id=" + topics[i]);
                    if (model != null)
                    {
                        model.Check_state = 2;
                        if (bll.Update(model))
                        {
                            JscriptMsg("审核成功啦！", "TopicCheckList.aspx?fun_id=" + get_fun_id("CCOM/TopicManage/TopicCheckList.aspx"), "Success");

                        }
                        else {
                            JscriptMsg("审核失败", "TopicCheckList.aspx?fun_id=" + get_fun_id("CCOM/TopicManage/TopicCheckList.aspx"), "Success");

                        }
                        
                    }
                }
                catch
                {
                    continue;
                }
                
            }
        }
    }
}