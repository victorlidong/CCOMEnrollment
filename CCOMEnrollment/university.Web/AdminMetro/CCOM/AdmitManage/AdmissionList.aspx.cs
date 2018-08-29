using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.AdmitManage
{
    public partial class AdmissionList : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected long user_id = 0;
        protected int period_id = 0;
        protected int agency_id;
        protected string clique_id;

        List<Model.CCOM.Agency> majorList;
        public AdmissionList()
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

            var adminModel = new BLL.CCOM.Admin_agency().GetModel(" User_id="+user_id);
            agency_id = adminModel.Agency_id;
            if (!IsPostBack)
            {
                Bind();
            }
        }

        protected void Bind()
        {
            string strWhere = " Agency_type=" + DataDic.CCOM_Clique_type;
            BLL.CCOM.Agency Bll = new BLL.CCOM.Agency();
            DataSet ds = Bll.GetList(strWhere);
            this.ddlClique.DataSource = ds.Tables[0].DefaultView;
            this.ddlClique.DataTextField = "Agency_name";
            this.ddlClique.DataValueField = "Agency_id";
            this.ddlClique.DataBind();
            if (agency_id == 1)
            {
                this.ddlClique.SelectedIndex = 0;
                clique_id = this.ddlClique.SelectedValue;
            }
            else
            {
                this.ddlClique.SelectedValue = agency_id.ToString();
                this.ddlClique.Enabled = false;
            }
            clique_id = this.ddlClique.SelectedValue;
            ddlClique_SelectedIndexChanged(null, null);

            var bll = new BLL.CCOM.Province();
            this.rptList1.DataSource = bll.GetList("");
            this.rptList1.DataBind();
        }
        protected void ddlClique_SelectedIndexChanged(object sender, EventArgs e)
        {
            clique_id = this.ddlClique.SelectedValue;
            string strWhere = " Agency_father=" + clique_id + " AND Agency_type= " + DataDic.CCOM_Major_type;

            try
            {
                var bll = new BLL.CCOM.Agency();
                majorList = bll.GetModelList(strWhere);

                this.rptList.DataSource = bll.GetList(strWhere);
                this.rptList.DataBind();
            }
            catch
            {
                JscriptMsg("获取专业方向出错", "", "Error");
            }
        }

        public string GetProvinceName(string pro_id)
        {
            string pro_name = "";
            try
            {
                var bll = new BLL.CCOM.Province();
                var model = bll.GetModel(" Province_id=" + pro_id);
                pro_name = model.Province_name;
            }
            catch
            {

            }
            return pro_name;
        }

        protected int getProvinceAdmissionNum(string _pro_id)
        {
            string strWhere = " UP_province=" + _pro_id + " AND UP_calculation_status > 4" + " AND Period_id=" + period_id;
            var numModel = new BLL.CCOM.User_property().GetModelList(strWhere);

            return numModel.Count;
        }
        protected string getProvinceAdmission(string _pro_id)
        {
            string strWhere = " UP_province=" + _pro_id + " AND UP_calculation_status > 4" + " AND Period_id=" + period_id;
            var numModel = new BLL.CCOM.User_property().GetModelList(strWhere);
            var allnumModel = new BLL.CCOM.User_property().GetModelList(" UP_province=" + _pro_id + " AND UP_calculation_status > 0"+ " AND Period_id=" + period_id);
            if (allnumModel.Count == 0) return "";
            int wid = (int)(numModel.Count * 1.0 / allnumModel.Count * 100);
            string txt = "<div style='width:" + wid + "px;height:14px;background:blue;margin-right:6px;float:left;'></div> ";
            return txt + (numModel.Count * 1.0 / allnumModel.Count * 100).ToString("F2") + "%";
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

        protected int getMajorAdmissionNum(string _major_id)
        {
            string strWhere = " Agency_id=" + _major_id + " AND UP_calculation_status > 4" + " AND Period_id=" + period_id;
            var numModel = new BLL.CCOM.User_property().GetModelList(strWhere);

            return numModel.Count;
        }
        protected string getMajorAdmission(string _major_id)
        {
            string strWhere = " Agency_id=" + _major_id + " AND UP_calculation_status > 4" + " AND Period_id=" + period_id;
            var numModel = new BLL.CCOM.User_property().GetModelList(strWhere);
            var allnumModel = new BLL.CCOM.User_property().GetModelList(" Agency_id=" + _major_id + " AND UP_calculation_status > 0"+ " AND Period_id=" + period_id);
            if (allnumModel.Count == 0) return "";
            int wid = (int)(numModel.Count * 1.0 / allnumModel.Count * 100);
            string txt = "<div style='width:" + wid + "px;height:14px;background:blue;margin-right:6px;float:left;'></div> ";
            return txt+(numModel.Count * 1.0 / allnumModel.Count * 100).ToString("F2") + "%";
        }
    }
}