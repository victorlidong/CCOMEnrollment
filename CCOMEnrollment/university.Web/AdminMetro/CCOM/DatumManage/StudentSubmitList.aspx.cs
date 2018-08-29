using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.DatumManage
{
    public partial class StudentSubmitList : university.UI.ManagePage
    {
        public StudentSubmitList()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if(GetAdminInfo_CCOM().Role_id != 3)
                //{
                //    JscriptMsg("只有学生用户才可以提交材料！", "back", "Error");
                //    return;
                //}
                ////判断学生是否已经选题
                //Model.CCOM.Topic_relation model = new BLL.CCOM.Topic_relation().GetModel(" Student_id='" + GetAdminInfo_CCOM().User_id + "' and Accept_state=1");
                //if (model == null)
                //{
                //    JscriptMsg("请先选择毕业设计题目！", "back", "Error");
                //    return;
                //}
                Bind_Data();
            } 
        }

        public void Bind_Data()
        {
            BLL.CCOM.Teach_week week_bll = new BLL.CCOM.Teach_week();
            List<university.Model.CCOM.Teach_week> week_models = week_bll.GetModelList("");
            string ht = "";

            foreach (university.Model.CCOM.Teach_week week_model in week_models)
            {
                if (week_model != null) 
                {
                    ht += "<li id=\"section-1\" class=\"mainTab\">";
                    ht += "<hr style=\"height:10px;border:none;border-top:10px groove skyblue;\" />";
                    ht += "<div class=\"content\">";
                    ht += "<div class=\"span4\">";
                    ht += "<h3 class=\"sectionname\"><span>" + GetDateString(week_model.Start_time) + " - " + GetDateString(week_model.End_time) + "</span></h3><hr /></div>";
                    ht += "<div class=\"span6\" style=\"padding:22px 0;\">";
                    ht += "</div><ul class=\"span12\">";
                    BLL.CCOM.Homework work_bll = new BLL.CCOM.Homework();
                    List<university.Model.CCOM.Homework> work_models = work_bll.GetModelList(" Week_id=" + week_model.TeachWeek_id);
                    foreach (university.Model.CCOM.Homework work_model in work_models)
                    {
                        ht += "<li class=\"fileTab\"><div><div class=\"mod-indent-outer\"><div class=\"mod-indent\"></div><div><div class=\"activityinstance\">";
                        ht += "<a href=\"StudentSubmit.aspx?homeworkId=" + work_model.Homework_id + "&fun_id=<%=DESEncrypt.Encrypt(\"15\") %><img src=\"/images/sendfile.png\"/>  提交" + (new BLL.CCOM.Datum_type().GetModel(work_model.DatumType_id).DatumType_name) + "</a>";
                        ht += "</div></div></div></div></li>";
                    }
                    ht += "</ul></div></li>";
                }
            }
            Model.CCOM.Topic_relation model = new Model.CCOM.Topic_relation();
            model= new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + GetAdminInfo_CCOM().User_id+"and Accept_state=1");
            if (model == null)
            {
                ht = " <div class=\"content\" align=\"center\"><h3>您尚无选题<h3></div>";
            }
             this.week_list.InnerHtml = ht;
        }

        public string GetDateString(DateTime time) 
        {
            return time.ToString("MM月dd日");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            

        }
    }
}