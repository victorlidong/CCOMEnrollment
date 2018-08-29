using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using university.Database;

namespace university.Web.AdminMetro.CCOM.AEEManage
{
    public partial class SelectSubject : university.UI.ManagePage
    {
        protected long user_id = 0;
        protected int period_id = 0;
        public SelectSubject()
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

            if (!Page.IsPostBack)
            {
                RalBind();
            }
        }
        private void RalBind()
        {
            try
            {
                var modelList = new BLL.CCOM.Judge().GetModelList("");

                if (modelList.Count > 0)
                {
                    foreach(Model.CCOM.Judge judge in modelList)
                    {
                        ListItem item = new ListItem();
                        item.Text = judge.Judge_name.ToString()+" # "+judge.Judge_staff_number;
                        item.Value = judge.Judge_id.ToString();
                        this.ddlJudge_ID.Items.Add(item);
                    }
                }
                ListItem item1 = new ListItem("--请选择评委--", "#");
                this.ddlJudge_ID.Items.Insert(0, item1);


                var examList = new BLL.CCOM.View_AEE_ManegeSubject().GetModelList(" Period_id = "+period_id+" AND User_id=" + user_id + " order by Ea_id asc");
                if (examList.Count > 0)
                {
                    int Ea_id = 0;
                    foreach (Model.CCOM.View_AEE_ManegeSubject exam in examList)
                    {
                        int _Ea_id = exam.Ea_id;
                        if (Ea_id != _Ea_id)
                        {
                            Ea_id = _Ea_id;

                            var exam_detail = new BLL.CCOM.Examination_arrangement().GetModel(Ea_id);

                            ListItem item = new ListItem();
                            item.Text = exam_detail.Ea_name.ToString();
                            item.Value = exam_detail.Ea_id.ToString();

                            this.ddlExam.Items.Add(item);
                        }
                    }
                }
                ListItem item2 = new ListItem("--请选择考试--", "#");
                this.ddlExam.Items.Insert(0, item2);
            }
            catch
            {
                JscriptMsg("数据出错", "", "Error");
            }
        }

        public string getRoomName(int Ea_id)
        {
            try
            {
                var exam = new BLL.CCOM.Examination_arrangement().GetModel(Ea_id);
                int room_id = exam.Ea_room;
                var room = new BLL.CCOM.Examination_room().GetModel(room_id);
                return " -"+room.Er_building + room.Er_floor + "楼" + room.Er_room + " -考试开始时间： " + exam.Ea_starttime;
            }
            catch
            {
                JscriptMsg("获取考试出错", "", "Error");
            }
            return "";
        }

        protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.radioSub.Items.Clear();
            //this.lblNowHasJudge.Text = "";
            this.div.InnerHtml = "";
            this.div1.InnerHtml = "";
            if (this.ddlExam.SelectedValue == null || this.ddlExam.SelectedValue == "#")
            {
                //this.LabelExamRoom.Text = "";
                JscriptMsg("请选择考试", "", "Error");
                return;
            }
            string text = "";
            text += "<br/><table width='60%' border='0' cellspacing='0' cellpadding='0' class='table table-striped table-bordered table-hover'><tbody><tr><th class='span1'>考试基本信息</th></tr>";
            text += "<tr><td>" + getRoomName(Convert.ToInt32(this.ddlExam.SelectedValue)) + "</td></tr>";
            text += "</tbody></table>";
            this.div1.InnerHtml = text;
            var subModelList = new BLL.CCOM.View_AEE_ManegeSubject().GetModelList(" User_id=" + user_id + " AND Ea_id="+this.ddlExam.SelectedValue);

            if (subModelList.Count > 0)
            {
                foreach (Model.CCOM.View_AEE_ManegeSubject subject in subModelList)
                {
                    ListItem item = new ListItem();
                    item.Text = subject.Subject_title.ToString();
                    item.Value = subject.Subject_id.ToString();
                    this.radioSub.Items.Add(item);
                }
            }
        }

        protected void radioSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlExam.SelectedValue == null || this.ddlExam.SelectedValue == "#")
            {
                //this.LabelExamRoom.Text = "";
                this.div1.InnerHtml = "";
                JscriptMsg("请选择考试", "", "Error");
                return;
            }
            string Id;
            Id = radioSub.SelectedValue;

            try
            {
                this.div.InnerHtml = "";
                string text = "<br/><table width='40%' border='0' cellspacing='0' cellpadding='0' class='table table-striped table-bordered table-hover'><tbody><tr><th class='span1'>本科目已录入过成绩的评委</th></tr>";
                var modeldata = DBSQL.Query("SELECT Judge_id from Examination_subject_score where Esn_id = " + Id + " group by Judge_id");
                if (modeldata.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < modeldata.Tables[0].Rows.Count; i++)    //逐行遍历  i 是当前行
                    {
                        text += "<tr><td class='span1'>" + new BLL.CCOM.Judge().GetModel(Convert.ToInt32(modeldata.Tables[0].Rows[i]["Judge_id"])).Judge_name + "</td></tr>";
                    }
                }
                text += "</tbody></table>";
                this.div.InnerHtml = text;
            }
            catch
            {
                JscriptMsg("获取科目信息出错", "", "Error");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.ddlExam.SelectedValue == null || this.ddlExam.SelectedValue == "#")
            {
                //this.LabelExamRoom.Text = "";
                this.div1.InnerHtml = "";
                JscriptMsg("请选择考试", "", "Error");
                return;
            }
            if (this.radioSub.SelectedValue == null || this.radioSub.SelectedValue == "")
            {
                JscriptMsg("请选择科目", "", "Error");
                return;
            }
            if (this.ddlJudge_ID.SelectedValue == null || this.ddlJudge_ID.SelectedValue == "#")
            {
                JscriptMsg("请选择评委", "", "Error");
                return;
            }

            Response.Redirect(Utils.CombUrlTxt("JudgeSubjectScoreList.aspx", "fun_id={0}&ea_id={1}&esn_id={2}&judge_id={3}", DESEncrypt.Encrypt(this.fun_id), DESEncrypt.Encrypt(this.ddlExam.SelectedValue), DESEncrypt.Encrypt(this.radioSub.SelectedValue), DESEncrypt.Encrypt(this.ddlJudge_ID.SelectedValue)));

        }
    }
}