using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.AEEManage
{
    public partial class SetFirstIn : university.UI.ManagePage
    {
        protected long user_id = 0;
        protected int agency_id = -1;
        protected string major_id = "0";
        protected int period_id = 0;

        protected bool hasFirstIn = true;

        public SetFirstIn()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = GetAdminInfo_CCOM().User_id;
            var agency = new BLL.CCOM.Admin_agency().GetModel("User_id = " + user_id);
            if (agency != null)
            {
                agency_id = agency.Agency_id;
            }
            var period = new BLL.CCOM.Period().GetModel("Period_state = " + DataDic.Period_state_On);
            if (period != null)
            {
                period_id = period.Period_id;
            }

            string str = MyRequest.GetQueryString("major_id");
            if (str != null && str != "")
                major_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("major_id"));

            if (!Page.IsPostBack)
            {
                RalBind();
            }
            this.major_id = this.ddlMajor.SelectedValue;
        }

        private void RalBind()
        {
            try
            {
                string strWhere = "";
                if (agency_id == DataDic.CCOM_Agency_id)
                {
                    strWhere += (" Agency_type = " + DataDic.CCOM_Clique_type);
                }
                else
                {
                    strWhere += (" Agency_id = " + agency_id);
                }

                BLL.CCOM.Agency Bll = new BLL.CCOM.Agency();
                DataSet ds = Bll.GetList(strWhere);
                this.ddlClique.DataSource = ds.Tables[0].DefaultView;
                this.ddlClique.DataTextField = "Agency_name";
                this.ddlClique.DataValueField = "Agency_id";
                this.ddlClique.DataBind();
                ListItem item = new ListItem("--请选择系--", "#");
                this.ddlClique.Items.Insert(0, item);

                if (agency_id != DataDic.CCOM_Agency_id)
                {
                    this.ddlClique.SelectedValue = agency_id.ToString();
                    this.ddlClique.Enabled = false;
                    ddlClique_SelectedIndexChanged(null, null);
                }
            }
            catch
            {
                JscriptMsg("数据出错", "", "Error");
            }
        }

        protected void ddlClique_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlMajor.Items.Clear();
            this.radioSub.Items.Clear();
            this.major_id = "";
            if (this.ddlClique.SelectedValue == null || this.ddlClique.SelectedValue == "#")
            {
                this.LabelExamRoom.Text = "";
                JscriptMsg("请选择系", "", "Error");
                return;
            }

            string father_id = this.ddlClique.SelectedValue;
            string strWhere = " Agency_type=" + DataDic.CCOM_Major_type + " AND Agency_father = " + father_id;

            BLL.CCOM.Agency Bll = new BLL.CCOM.Agency();
            DataSet ds = Bll.GetList(strWhere);
            this.ddlMajor.DataSource = ds.Tables[0].DefaultView;
            this.ddlMajor.DataTextField = "Agency_name";
            this.ddlMajor.DataValueField = "Agency_id";
            this.ddlMajor.DataBind();
            ListItem item = new ListItem("--请选择专业方向--", "#");
            this.ddlMajor.Items.Insert(0, item);
            if (this.major_id != "0" && this.major_id != "")
            {
                this.ddlMajor.SelectedValue = major_id;
                this.major_id = this.ddlMajor.SelectedValue;
                ddlMajor_SelectedIndexChanged(null, null);
            }
        }

        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.radioSub.Items.Clear();
            if (this.ddlClique.SelectedValue == null || this.ddlClique.SelectedValue == "#")
            {
                this.LabelExamRoom.Text = "";
                JscriptMsg("请选择系", "", "Error");
                return;
            }
            if (this.ddlMajor.SelectedValue == null || this.ddlMajor.SelectedValue == "#")
            {
                this.LabelExamRoom.Text = "";
                JscriptMsg("请选择专业方向", "", "Error");
                return;
            }

            string father_id = this.ddlMajor.SelectedValue;
            string strWhere = " Major_Agency_id = " + father_id + " AND Subject_level=1";

            BLL.CCOM.Subject Bll = new BLL.CCOM.Subject();
            DataSet ds = Bll.GetList(strWhere);
            this.radioSub.DataSource = ds.Tables[0].DefaultView;
            this.radioSub.DataTextField = "Subject_title";
            this.radioSub.DataValueField = "Subject_id";
            this.radioSub.DataBind();

            string str = " Major_id=" + father_id + " AND Period_id="+period_id;
            var model1 = new BLL.CCOM.Exam_firstin_subject().GetModel(str);
            if (model1 != null)
            {
                this.radioSub.SelectedValue = model1.Esn_id.ToString();
                hasFirstIn = false;
            }
            this.radioSub.Enabled = hasFirstIn;
            this.btnSubmit.Enabled = hasFirstIn;
        }

        protected void radioSub_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.ddlClique.SelectedValue == null || this.ddlClique.SelectedValue == "#")
            {
                this.LabelExamRoom.Text = "";
                JscriptMsg("请选择系", "", "Error");
                return;
            }
            if (this.ddlMajor.SelectedValue == null || this.ddlMajor.SelectedValue == "")
            {
                JscriptMsg("请选择专业方向", "", "Error");
                return;
            }
            if (this.radioSub.SelectedValue == null || this.radioSub.SelectedValue == "")
            {
                JscriptMsg("请选择科目", "", "Error");
                return;
            }
            if (addPreliminary(this.ddlMajor.SelectedValue, this.radioSub.SelectedValue))
            {
                calPreliminary(this.radioSub.SelectedValue);
            }
            

            //Response.Redirect(Utils.CombUrlTxt("SubjectScoreList.aspx", "fun_id={0}&major_id={1}&esn_id={2}", this.fun_id, DESEncrypt.Encrypt(this.ddlMajor.SelectedValue), DESEncrypt.Encrypt(this.radioSub.SelectedValue)));
        }
        public bool addPreliminary(string major, string subject_id)
        {
            try
            {
                string strWhere = " Major_id=" + major + " AND Period_id="+ this.period_id;
                BLL.CCOM.Exam_firstin_subject bll = new BLL.CCOM.Exam_firstin_subject();
                var model = bll.GetModel(strWhere);
                var _model = new Model.CCOM.Exam_firstin_subject();

                if (model == null)
                {
                    _model.Esn_id = Convert.ToInt32(subject_id);
                    _model.Major_id = Convert.ToInt32(major);
                    _model.Period_id = this.period_id;
                    bll.Add(_model);
                }
                else
                {
                    model.Esn_id = Convert.ToInt32(subject_id);
                    bll.Update(model);
                }
                return true;
            }
            catch
            {
                JscriptMsg("数据出错", "", "Error");
                return false;
            }
        }
        public bool calPreliminary(string subject_id)
        {
            try
            {
                decimal weights = 0;
                string strWhere = " Fs_id=" + subject_id;
                var subjectList = new BLL.CCOM.Subject().GetModelList(strWhere);
                if (subjectList.Count > 0)
                {
                    foreach (var model in subjectList)
                    {
                        weights += (decimal)(model.Subject_weight);
                    }
                }

                if (weights != 0)
                {
                    strWhere = " Agency_id=" + this.ddlMajor.SelectedValue + " AND UP_calculation_status > 0";
                    var examineeList = new BLL.CCOM.View_GetExaminee().GetModelList(strWhere);

                    foreach (var model in examineeList)
                    {
                        long user_id = model.User_id;
                        decimal score = 0, xu = 0;
                        int num = 0;

                        foreach (var _model in subjectList)
                        {
                            var __model = new BLL.CCOM.Examination_subject_average_score().GetModel(" Esn_id=" + _model.Subject_id + " AND User_id=" + user_id);
                            if (__model != null)
                            {
                                num++;
                                score += (decimal)(__model.Esas_score * (_model.Subject_weight / weights));
                                if (__model.Esas_sequence != null)
                                {
                                    xu += (decimal)(__model.Esas_sequence * (_model.Subject_weight / weights));
                                }
                            }
                        }

                        if (num > 0)
                        {
                            var model1 = new BLL.CCOM.Exam_firstin_subject().GetModel(" Esn_id=" + subject_id + " AND Major_id=" + this.major_id + " AND Period_id=" + period_id);

                            BLL.CCOM.Exam_firstin_subject_score bll2 = new BLL.CCOM.Exam_firstin_subject_score();
                            var model2 = bll2.GetModel(" Efs_id=" + model1.Efs_id + " AND User_id=" + user_id);
                            var _model2 = new Model.CCOM.Exam_firstin_subject_score();
                            if (model2 != null){
                                model2.Efs_id = model1.Efs_id;
                                model2.User_id = user_id;
                                model2.Efss_score = score;
                                if (xu != 0)
                                {
                                    model2.Efss_sequence = xu;
                                }
                                else
                                {
                                    model2.Efss_sequence = null;
                                }
                                bll2.Update(model2);
                            }
                            else
                            {
                                _model2.Efs_id = model1.Efs_id;
                                _model2.User_id = user_id;
                                _model2.Efss_score = score;
                                if (xu != 0)
                                {
                                    _model2.Efss_sequence = xu;
                                }
                                else
                                {
                                    _model2.Efss_sequence = null;
                                }
                                bll2.Add(_model2);
                            }
                        }
                    }
                    JscriptMsg("设置初试二轮科目成功", "SelectToPreliminary.aspx?fun_id=" + get_fun_id("CCOM/AEEManage/SelectToPreliminary.aspx"), "Success");
                    return true;
                }
                else
                {
                    JscriptMsg("总权重为零", "", "Error");
                    return false;
                }
            }
            catch
            {
                JscriptMsg("填加数据出错", "", "Error");
            }
            return false;
        }
    }
}