using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.StudentScore
{
    public partial class StudentStatus : university.UI.ManagePage
    {
        protected long user_id = 0;
        protected int period_id = 0;
        protected Model.CCOM.User_property model;
        public StudentStatus()
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

            int type = (int)model.UP_calculation_status;
            
            this.div_AEE.InnerHtml = getStudentStatus(type);
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

        protected string getStudentStatus(int type)
        {
            string str = "";
            switch (type)
            {
                case 0: str = "你还未缴费报名，请尽快报名！"; break;
                case 1: str = "你处在初试阶段，未进入复试。"; break;
                case 2: str = "你处在初试阶段，未进入复试。"; break;
                case 3: str = "你处在复试阶段，未进入文考。"; break;
                case 4: str = "你处在复试阶段，未录取。"; break;
                case 5: str = "<b style='color:red;'>恭喜你，你已被我院正式录取！！</b>"; break;
                default: str = ""; break;
            }
            var _model = new BLL.CCOM.Transcript().GetModel(" Period_id=" + period_id + " AND User_id=" + user_id);
            if (_model != null)
            {
                string txt = "";
                txt += " 你的成绩如下：<br/><br/>";
                txt += "<table width='100%' border='0' cellspacing='0' cellpadding='0' class='table table-striped table-bordered table-hover'><tbody>";

                string th = "<tr><th>名称</th><th>成绩/序</th></tr>";
                string td = "";
                td += "<tr><td>专业成绩</td><td>" + ((decimal)_model.Transcript_AEE_score).ToString("F2") + "</td></tr>";
                td += "<tr><td>专业平均序</td><td>" + ((decimal)_model.Transcript_AEE_sequence).ToString("F2") + "</td></tr>";
                td += "<tr><td>专业排名</td><td>" + ((decimal)_model.Transcript_AEE_ranking).ToString("F2") + "</td></tr>";
                if (_model.Transcript_CEE_score != null)
                {
                    td += "<tr><td>高考成绩</td><td>" + ((decimal)_model.Transcript_CEE_score).ToString("F2") + "</td></tr>";
                    td += "<tr><td>高考折合分（百分制）</td><td>" + ((decimal)_model.Transcript_CEE_convert_score).ToString("F2") + "</td></tr>";
                    td += "<tr><td>高考成绩是否过线</td><td>" + (_model.Transcript_passline == true ? "是" : "否") + "</td></tr>";
                    td += "<tr><td>最终成绩</td><td>" + ((decimal)_model.Transcript_score).ToString("F2") + "</td></tr>";
                }
                else
                {
                    td += "<tr><td>高考成绩</td><td></td></tr>";
                    td += "<tr><td>高考折合分（百分制）</td><td></td></tr>";
                    td += "<tr><td>高考成绩是否过线</td><td></td></tr>";
                    td += "<tr><td>最终成绩</td><td></td></tr>";
                }
                txt += th + td;
                txt += "</tbody></table>";
                str += txt;
            }
            return str;
        }
    }
}