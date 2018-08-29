using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.StudentManage
{
    public partial class InitSystem : university.UI.ManagePage
    {
        public InitSystem()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            var student_models = new BLL.CCOM.User_information().GetModelList(" Role_id=3");
            foreach(var student_model in student_models)
            {
                if (!new BLL.CCOM.User_information().Delete(student_model.User_id)) 
                {
                    JscriptMsg("删除学生：" + student_model.User_realname + "时，发生异常！", "", "Error");
                    return;
                }
            }

            var topic_models = new BLL.CCOM.Topic().GetModelList("");
            foreach (var topic_model in topic_models)
            {
                if (!new BLL.CCOM.Topic().Delete(topic_model.Topic_id))
                {
                    JscriptMsg("删除选题：" + topic_model.Topic_name + "时，发生异常！", "", "Error");
                    return;
                }
            }

            var teachweek_models = new BLL.CCOM.Teach_week().GetModelList("");
            foreach (var teachweek_model in teachweek_models)
            {
                if (!new BLL.CCOM.Teach_week().Delete(teachweek_model.TeachWeek_id))
                {
                    JscriptMsg("删除异常！", "", "Error");
                    return;
                }
            }

            var reply_models = new BLL.CCOM.Reply_group().GetModelList("");
            foreach (var reply_model in reply_models)
            {
                if (!new BLL.CCOM.Reply_group().Delete(reply_model.Group_id))
                {
                    JscriptMsg("删除答辩组：" + reply_model.Group_name + "时，发生异常！", "", "Error");
                    return;
                }
            }

            var user_models = new BLL.CCOM.User_information().GetModelList(" Role_id!=1");
            foreach (var student_model in user_models)
            {
                if (!new BLL.CCOM.User_information().Delete(student_model.User_id))
                {
                    JscriptMsg("删除用户：" + student_model.User_realname + "时，发生异常！", "", "Error");
                    return;
                }
            }

            JscriptMsg("初始化成功！", "InitSystem.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
        }

    }
}