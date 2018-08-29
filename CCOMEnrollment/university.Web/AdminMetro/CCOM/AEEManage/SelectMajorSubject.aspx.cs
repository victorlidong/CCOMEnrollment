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
    public partial class SelectMajorSubject : university.UI.ManagePage
    {
        protected long user_id = 0;
        protected int agency_id = -1;
        protected int period_id = 0;

        public SelectMajorSubject()
        {
            this.checkFunID = true;
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

            if (!Page.IsPostBack)
            {
                RalBind();
            }
        }

        private void RalBind()
        {
            try
            {
                string strWhere = "";
                if (agency_id == DataDic.CCOM_Agency_id)
                {
                    strWhere += (" Agency_type = "+ DataDic.CCOM_Clique_type);
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
            if (this.ddlClique.SelectedValue == null || this.ddlClique.SelectedValue == "#")
            {
                this.LabelExamRoom.Text = "";
                JscriptMsg("请选择系", "", "Error");
                return;
            }

            string father_id = this.ddlClique.SelectedValue;
            string strWhere = " Agency_type=3 AND Agency_father = " + father_id;

            BLL.CCOM.Agency Bll = new BLL.CCOM.Agency();
            DataSet ds = Bll.GetList(strWhere);
            this.ddlMajor.DataSource = ds.Tables[0].DefaultView;
            this.ddlMajor.DataTextField = "Agency_name";
            this.ddlMajor.DataValueField = "Agency_id";
            this.ddlMajor.DataBind();
            ListItem item = new ListItem("--请选择专业方向--", "#");
            this.ddlMajor.Items.Insert(0, item);
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
            string strWhere = " Major_Agency_id = " + father_id + " AND Subject_level=2 AND Period_id="+period_id;

            BLL.CCOM.Subject Bll = new BLL.CCOM.Subject();
            DataSet ds = Bll.GetList(strWhere);
            this.radioSub.DataSource = ds.Tables[0].DefaultView;
            this.radioSub.DataTextField = "Subject_title";
            this.radioSub.DataValueField = "Subject_id";
            this.radioSub.DataBind();
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
            if (this.radioSub.SelectedValue == null || this.radioSub.SelectedValue == "#")
            {
                JscriptMsg("请选择科目", "", "Error");
                return;
            }

            Response.Redirect(Utils.CombUrlTxt("SubjectScoreList.aspx", "fun_id={0}&major_id={1}&esn_id={2}", DESEncrypt.Encrypt(this.fun_id), DESEncrypt.Encrypt(this.ddlMajor.SelectedValue), DESEncrypt.Encrypt(this.radioSub.SelectedValue)));
        }

    }
}