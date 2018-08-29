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
    public partial class WeeklyList : university.UI.ManagePage
    {
        public WeeklyList()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                    ht += "<a href=\"WeeklyAdd.aspx?weeklyId=" + week_model.TeachWeek_id + "&action=" + MyEnums.ActionEnum.Edit.ToString() + "&fun_id=<%=DESEncrypt.Encrypt(\"15\") %><i class=\"icon-pencil\"></i>修改</a>&nbsp;";
                    ht += "<a onclick=\"javascript:DeleteWeekly(" + week_model.TeachWeek_id + ")\"><i class=\"icon-remove\"></i>删除</a></div>";
                    ht += "<ul class=\"span12\">";
                    BLL.CCOM.Homework work_bll = new BLL.CCOM.Homework();
                    List<university.Model.CCOM.Homework> work_models = work_bll.GetModelList(" Week_id=" + week_model.TeachWeek_id);
                    foreach (university.Model.CCOM.Homework work_model in work_models)
                    {
                        ht += "<li class=\"fileTab\"><div><div class=\"mod-indent-outer\"><div class=\"mod-indent\"></div><div><div class=\"activityinstance\">";
                        ht += "<a><img src=\"/images/sendfile.png\"/>  提交" + (new BLL.CCOM.Datum_type().GetModel(work_model.DatumType_id).DatumType_name) + "</a>";
                        ht += "</div></div></div></div></li>";
                    }
                    ht += "</ul></div></li>";
                }
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