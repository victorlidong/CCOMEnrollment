using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.StudentScore
{
    public partial class CEEScore : university.UI.ManagePage
    {
        protected long user_id = 0;
        protected int period_id = 0;
        protected Model.CCOM.User_property model;
        public CEEScore()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = GetAdminInfo_CCOM().User_id;
            var period = new BLL.CCOM.Period().GetModel("Period_state = " + DataDic.Period_state_On);
            if (period != null)
            {
                period_id = period.Period_id;
            }

            Bind();
        }
        public void Bind()
        {
            model = new BLL.CCOM.User_property().GetModel(" User_id = " + user_id);
            string text = "";
            text += model.UP_CCOM_number + " " + new BLL.CCOM.User_infomation().GetModel(GetAdminInfo_CCOM().User_id).User_realname + " 同学";
            this.div_msg.InnerHtml = text;

            text = "你今年报考是 " + getMajorName();
            this.div_major.InnerHtml = text;

            text = getSubjectScore();
            this.div_AEE.InnerHtml = text;
        }

        protected string getMajorName()
        {
            string strWhere = " Agency_id=" + model.Agency_id;
            Model.CCOM.Agency agency = new BLL.CCOM.Agency().GetModel(strWhere);
            string name = "";
            if (agency != null)
            {
                var _agency = new BLL.CCOM.Agency().GetModel(" Agency_id=" + agency.Agency_father);

                name = _agency.Agency_name + agency.Agency_name + " 专业";
            }
            else
            {
                name = "暂未选择";
            }
            return name;
        }

        protected string getSubjectScore()
        {
            string txt = "";//
            string strWhere = " Period_id=" + period_id + " AND User_id=" + user_id;
            var score = new BLL.CCOM.Examination_CEE_score().GetModel(strWhere);

            if (score !=null)
            {

                txt += "你的考生类型： " + (score.CEE_type == 1 ? "文科" : "理科") + "考生";
                txt += ", 你的高考各科考试成绩如下：<br/><br/>";
                txt += "<table width='100%' border='0' cellspacing='0' cellpadding='0' class='table table-striped table-bordered table-hover'><tbody>";

                string th = "<tr><th>考试科目名称</th><th>考试科目成绩</th></tr>";
                string td = "";
                td += "<tr><td>语文</td><td>" + ((decimal)score.CEE_Chinese_score).ToString("F2") +"</td></tr>";
                td += "<tr><td>数学</td><td>" + ((decimal)score.CEE_Math_score).ToString("F2") + "</td></tr>";
                td += "<tr><td>外语</td><td>" + ((decimal)score.CEE_English_score).ToString("F2") + "</td></tr>";
                td += "<tr><td>综合</td><td>" + ((decimal)score.CEE_comprehensive_score).ToString("F2") + "</td></tr>";
                td += "<tr><td>附加分</td><td>" + ((decimal)score.CEE_extra_score).ToString("F2") + "</td></tr>";
                td += "<tr><td>总分</td><td>" + ((decimal)score.CEE_score).ToString("F2") + "</td></tr>";
                txt += th + td;
                txt += "</tbody></table>";
            }
            else
            {
                txt = "你的高考各科目成绩是： 暂无记录";
            }
            return txt;
        }
    }
}