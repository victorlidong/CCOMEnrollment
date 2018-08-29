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
    public partial class AcceptStudent : university.UI.ManagePage
    {
        public AcceptStudent()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        String TopicIDS = "";
        string[] topicrelation;
        protected void Page_Load(object sender, EventArgs e)
        {
            TopicIDS = MyRequest.GetQueryString("id");
            topicrelation = TopicIDS.Split(',');
            if (!IsPostBack)
            {
                
            }
         
        }

        protected void btnSubmit_Success(object sender, EventArgs e)
        {
            BLL.CCOM.Topic_relation bll = new BLL.CCOM.Topic_relation();
            for (int i = 0; i < topicrelation.Length; i++) {
                try
                {
                    Model.CCOM.Topic_relation model = bll.GetModel(" Topic_relation_id=" + topicrelation[i]);
                    if (model != null)
                    {
                        model.Accept_state = 1;
                        if (bll.Update(model))
                        {
                            JscriptMsg("审核成功啦！", "TeacherChoose.aspx?fun_id=" + get_fun_id("CCOM/TopicManage/TeacherChoose.aspx"), "Success");

                        }
                        else
                        {
                            JscriptMsg("审核失败", "TeacherChoose.aspx?fun_id=" + get_fun_id("CCOM/TopicManage/TeacherChoose.aspx"), "Success");

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
            BLL.CCOM.Topic_relation bll = new BLL.CCOM.Topic_relation();
            for (int i = 0; i < topicrelation.Length; i++)
            {
                try
                {
                    Model.CCOM.Topic_relation model = bll.GetModel(" Topic_relation_id=" + topicrelation[i]);
                    if (model != null)
                    {
                        model.Accept_state = 2;
                        if (bll.Update(model))
                        {

                            BLL.CCOM.Topic topic_bll = new BLL.CCOM.Topic();
                            Model.CCOM.Topic topic_model = topic_bll.GetModel(model.Topic_id);
                            topic_model.Selected_state = false;
                            topic_bll.Update(topic_model);

                            JscriptMsg("审核成功啦！", "TeacherChoose.aspx?fun_id=" + get_fun_id("CCOM/TopicManage/TeacherChoose.aspx"), "Success");

                        }
                        else {
                            JscriptMsg("审核失败", "TeacherChoose.aspx?fun_id=" + get_fun_id("CCOM/TopicManage/TeacherChoose.aspx"), "Success");

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