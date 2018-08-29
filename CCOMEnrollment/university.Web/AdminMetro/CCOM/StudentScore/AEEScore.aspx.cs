using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.StudentScore
{
    public partial class AEEScore : university.UI.ManagePage
    {
        protected long user_id = 0;
        protected int period_id = 0;
        protected Model.CCOM.User_property model;
        public AEEScore()
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

            text = "你的各科考试成绩如下：" + getSubjectScore();
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
            else{
                name = "暂未选择";
            }
            return name;
        }
        protected string getSubjectScore()
        {
            string txt = "";
            string strWhere = " Agency_id=" + model.Agency_id + " AND Period_id="+period_id + " AND User_id="+user_id;
            var scoreList = new BLL.CCOM.View_AEE_Subject_Score().GetModelList(strWhere);

            if (scoreList.Count > 0)
            {
                txt += "<br/><br/><table width='100%' border='0' cellspacing='0' cellpadding='0' class='table table-striped table-bordered table-hover'><tbody>";

                string th = "<tr><th>考试科目名称</th><th>考试科目成绩</th><th>考试科目序</th></tr>";
                string td = "";
                foreach (var subScore in scoreList)
                {
                    td += "<tr>";
                    td += "<td>" + getSubjectName(subScore.Subject_id.ToString())+ "</td>";
                    td += "<td>" + getSubjectAverageScore(user_id.ToString(), subScore.Subject_id.ToString()) + "</td>";
                    td += "<td>" + getSubjectAverageXu(user_id.ToString(), subScore.Subject_id.ToString()) + "</td>";
                    td += "</tr>";
                }
                txt += th + td;
                txt += "</tbody></table>";
            }
            else
            {
                txt = "暂无记录";
            }
            return txt;
        }
        protected string getSubjectName(string _esn_id)
        {
            string strWhere = " Subject_id=" + _esn_id;
            Model.CCOM.Subject sub = new BLL.CCOM.Subject().GetModel(strWhere);
            string subname = "";
            if (sub != null)
            {
                subname = sub.Subject_title;
            }

            return subname;
        }
        protected string getSubjectAverageScore(string _user_id, string _esn_id)
        {
            string strWhere = " User_id=" + _user_id + " AND Esn_id=" + _esn_id;
            Model.CCOM.Examination_subject_average_score subAvgScore = new BLL.CCOM.Examination_subject_average_score().GetModel(strWhere);
            string score = "";
            if (subAvgScore != null)
            {
                score = subAvgScore.Esas_score.ToString("F2");
            }

            return score;
        }

        protected string getSubjectAverageXu(string _user_id, string _esn_id)
        {
            string strWhere = " User_id=" + _user_id + " AND Esn_id=" + _esn_id;
            Model.CCOM.Examination_subject_average_score sub = new BLL.CCOM.Examination_subject_average_score().GetModel(strWhere);
            string Xu = "";
            if (sub != null)
            {
                Xu = ((decimal)(sub.Esas_sequence)).ToString("F2");
            }

            return Xu;
        }
    }
}