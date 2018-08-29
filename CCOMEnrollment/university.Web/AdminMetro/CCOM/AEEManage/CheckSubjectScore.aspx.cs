using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using university.Database;

namespace university.Web.AdminMetro.CCOM.AEEManage
{
    public partial class CheckSubjectScore : university.UI.ManagePage
    {
        protected long user_id = 0;
        protected int agency_id = -1;
        protected string major_id = "0";
        protected int period_id = 0;

        public CheckSubjectScore()
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

            string str = MyRequest.GetQueryString("major_id");
            if (str != null && str != "")
                major_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("major_id"));

            var period = new BLL.CCOM.Period().GetModel("Period_state = " + DataDic.Period_state_On);
            if (period != null)
            {
                period_id = period.Period_id;
            }

            if (!Page.IsPostBack)
            {
                RalBind();

                string strWhere = " Major_Agency_id = " + major_id + " AND Subject_level=2 AND Period_id=" + period_id;
                string order = "";
                RptBind(strWhere, order);
            }
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
            if (this.ddlClique.SelectedValue == null || this.ddlClique.SelectedValue == "#")
            {
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
            if (this.ddlClique.SelectedValue == null || this.ddlClique.SelectedValue == "#")
            {
                JscriptMsg("请选择系", "", "Error");
                return;
            }
            if (this.ddlMajor.SelectedValue == null || this.ddlMajor.SelectedValue == "#")
            {
                JscriptMsg("请选择专业方向", "", "Error");
                return;
            }

            major_id = this.ddlMajor.SelectedValue;
            string strWhere = " Major_Agency_id = " + major_id + " AND Subject_level=2 AND Period_id=" + period_id;
            string order = "";

            try
            {
                RptBind(strWhere, order);
            }
            catch
            {
                JscriptMsg("获取科目出错", "", "Error");
            }

        }

        private void RptBind(string _strWhere, string _order)
        {
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();

            //绑定当页
            this.rptList.DataSource = bll.GetList(_strWhere+_order);

            this.rptList.DataBind();
        }
        protected string getMajorName(string _major_id)
        {
            string strWhere = " Agency_id=" + _major_id;
            Model.CCOM.Agency major = new BLL.CCOM.Agency().GetModel(strWhere);
            string name = "";
            if (major != null)
            {
                name = major.Agency_name;
            }

            return name;
        }
        protected string getMajorScoreNum(string _major_id, string _subject_id)
        {
            string strWhere = "select * from Examination_subject_average_score where Esn_id=" + _subject_id + " and  User_id in (select User_id from User_property where Agency_id="+_major_id+" AND Period_id="+period_id+")";
            var modeldata = DBSQL.Query(strWhere);
            int num = modeldata.Tables[0].Rows.Count;
            return num.ToString();
        }
        protected string getMajorRetrialNum(string _major_id)
        {
            string strWhere = " Agency_id=" + _major_id + " AND Period_id=" + period_id + " AND UP_calculation_status > 2";
            var user_modellist = new BLL.CCOM.User_property().GetModelList(strWhere);
            string num = "";
            if (user_modellist != null)
            {
                num = user_modellist.Count.ToString();
            }

            return num;
        }
        protected string getMajorNum(string _major_id)
        {
            string strWhere = " Agency_id=" + _major_id + " AND Period_id=" + period_id + " AND UP_calculation_status > 0";
            var user_modellist = new BLL.CCOM.User_property().GetModelList(strWhere);
            string num = "";
            if (user_modellist != null)
            {
                num = user_modellist.Count.ToString();
            }

            return num;
        }
    }
}