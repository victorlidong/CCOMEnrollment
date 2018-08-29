using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.AEEManage
{
    public partial class SelectToCEE : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string keywords = "";
        protected long user_id = 0;
        protected int agency_id = -1;
        protected string major_id = "0";
        protected int period_id = 0;

        protected bool hasCEE = true;
        public SelectToCEE()
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
            string str = MyRequest.GetQueryString("major_id");
            if (str != null && str != "")
                major_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("major_id"));

            if (!Page.IsPostBack)
            {
                keywords = MyRequest.GetQueryString("keywords");
                if (Tools.CheckParams(keywords))
                {
                    keywords = "";
                }
                this.txtKeywords.Text = keywords;

                RalBind();
            }

            this.major_id = this.ddlMajor.SelectedValue;
        }


        private void RalBind()
        {
            try
            {
                string strWhere = " Agency_type = " + DataDic.CCOM_Major_type;
                if (agency_id != DataDic.CCOM_Agency_id)
                {
                    strWhere += (" AND Agency_father = " + agency_id);
                }

                BLL.CCOM.Agency Bll = new BLL.CCOM.Agency();
                DataSet ds = Bll.GetList(strWhere);
                this.ddlMajor.DataSource = ds.Tables[0].DefaultView;
                this.ddlMajor.DataTextField = "Agency_name";
                this.ddlMajor.DataValueField = "Agency_id";
                this.ddlMajor.DataBind();

                this.ddlMajor.SelectedValue = major_id;

                this.major_id = this.ddlMajor.SelectedValue;

                ddlMajor_SelectedIndexChanged(null, null);
            }
            catch
            {
                JscriptMsg("数据出错", "", "Error");
            }
        }

        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str1 = " Agency_id=" + major_id + " AND Period_id=" + period_id + " AND UP_calculation_status > 3";
            var model1 = new BLL.CCOM.User_property().GetModelList(str1);
            if (model1.Count > 0)
            {
                hasCEE = false;

            }
            this.btnCalculation.Enabled = hasCEE;

            string order = "";
            string strWhere = "";

            order = "AEE_score DESC, AEE_sequence DESC ,UP_CCOM_number asc";
            strWhere = CombSqlTxt(this.keywords);
            try
            {
                RptBind(strWhere, order);
            }
            catch
            {
                JscriptMsg("获取考生成绩出错", "", "Error");
            }
        }

        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(30); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;

            BLL.CCOM.View_AEE_Score bll = new BLL.CCOM.View_AEE_Score();

            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);
            //   txtSearchResult.Text = "本次命中" + totalCount.ToString() + "条";

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);

            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("SelectToCEE.aspx", "fun_id={0}&page={1}&keywords={2}&major_id={3}", DESEncrypt.Encrypt(this.fun_id), "__id__",
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id));
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            if (Tools.CheckParams(_keywords))
                return " 1=0 ";

            StringBuilder strTemp = new StringBuilder();

            //搜索关键字
            _keywords = _keywords.Trim();
            if (!_keywords.Equals(""))
            {
                strTemp.Append(" (User_realname like '%" + _keywords + "%'");
                strTemp.Append(" or UP_CCOM_number= '" + _keywords + "')");
            }
            else
            {
                strTemp.Append(" 1=1 ");
            }

            strTemp.Append(" AND Period_id=" + period_id + " AND Agency_id=" + major_id);

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("SelectToCEE"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 设置分页数量=====================
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("SelectToCEE_page_size", _pagesize.ToString(), 43200);
                }
            }
            string keywords = MyRequest.GetQueryString("keywords");
            Response.Redirect(Utils.CombUrlTxt("SelectToCEE.aspx", "fun_id={0}&keywords={1}&major_id={2}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id)));
        }
        #endregion

        public string getIntoCEE(string _up_calculation_status, string _user_id)
        {
            int num = Convert.ToInt32(_up_calculation_status);
            if (num > 3)
            {
                string str = " User_id=" + _user_id + " AND Period_id=" + period_id;
                var model1 = new BLL.CCOM.Transcript().GetModel(str);
                if (model1 != null)
                {
                    int t = model1.Transcript_type;
                    if (t == 1)
                        return "备取";
                    else if (t == 2)
                        return "合格";
                    else if (t == 3)
                        return "正取";
                }
                return "不取"; 
            }
            else
            {
                if (this.hasCEE == true)
                    return "";
                else
                    return "不取";
            }
        }

        protected void btnSelectCEE_Click(object sender, EventArgs e)
        {
            string order = "Epss_score DESC, Epss_sequence DESC ,UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);

            try
            {
                //var bll = new BLL.CCOM.View_Preliminary_Score();
                //List<Model.CCOM.View_Preliminary_Score> modelList = bll.GetModelList(strWhere + " order by " + order);
                var bll = new BLL.CCOM.Transcript();
                var bll1 = new BLL.CCOM.Examination_AEE_score();
                var bll2 = new BLL.CCOM.User_property();
                //增加只导出选择部分学生的功能
                string name = "";
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    HiddenField hf = (HiddenField)rptList.Items[i].FindControl("hidChkId");
                    string _user_id = hf.Value;
                    DropDownList dd = (DropDownList)rptList.Items[i].FindControl("ddlType");
                    string type = dd.SelectedValue;

                    if (type.Equals("0"))
                    {
                        var model = bll.GetModel(" User_id=" + _user_id + " AND Period_id=" + period_id);
                        if (model != null)
                        {
                            bll.Delete(model.Transcript_id);
                        } 
                        
                        var usermodel = bll2.GetModel(" User_id=" + _user_id + " AND Period_id=" + period_id);
                        usermodel.UP_calculation_status = 3;
                        bll2.Update(usermodel);
                    }
                    else
                    {
                        var AEEmodel = bll1.GetModel(" User_id=" + _user_id + " AND Period_id=" + period_id);

                        var model = bll.GetModel(" User_id=" + _user_id + " AND Period_id=" + period_id);
                        var _model = new Model.CCOM.Transcript();

                        if (model != null)
                        {
                            model.Transcript_AEE_score = AEEmodel.AEE_score;
                            model.Transcript_AEE_ranking = AEEmodel.AEE_ranking;
                            model.Transcript_AEE_sequence = AEEmodel.AEE_sequence;
                            model.Transcript_type = Convert.ToInt16(type);
                            bll.Update(model);
                        }
                        else
                        {
                            _model.Transcript_type = Convert.ToInt16(type);
                            _model.Transcript_AEE_score = AEEmodel.AEE_score;
                            _model.Transcript_AEE_ranking = AEEmodel.AEE_ranking;
                            _model.Transcript_AEE_sequence = AEEmodel.AEE_sequence;
                            _model.Period_id = period_id;
                            _model.User_id = (long)AEEmodel.User_id;
                            bll.Add(_model);
                        }

                        var usermodel = bll2.GetModel(" User_id=" + _user_id + " AND Period_id=" + period_id);
                        usermodel.UP_calculation_status = 4;
                        bll2.Update(usermodel);
                    }
                }
                JscriptMsg("已添加进入文考名单", "SelectToCEE.aspx?fun_id="+DESEncrypt.Encrypt(this.fun_id)+"&keywords="+this.txtKeywords.Text+"&major_id="+DESEncrypt.Encrypt(this.major_id), "Success");
            }
            catch
            {
                JscriptMsg("添加进入文考名单出错", "", "Error");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("SelectToCEE.aspx", "fun_id={0}&keywords={1}&major_id={2}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id)));
        }
        protected void exportexcel_ServerClick(object sender, EventArgs e)
        {
            string str1 = " Agency_id=" + major_id + " AND Period_id=" + period_id + " AND UP_calculation_status > 3";
            var model1 = new BLL.CCOM.User_property().GetModelList(str1);
            if (model1.Count > 0)
            {
                hasCEE = false;

            }
            this.btnCalculation.Enabled = hasCEE;

            string order = "AEE_score DESC, AEE_sequence DESC ,UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);
            try
            {
                BLL.CCOM.View_AEE_Score bll = new BLL.CCOM.View_AEE_Score();

                List<Model.CCOM.View_AEE_Score> modelList = bll.GetModelList(strWhere + " order by " + order);

                DataSet ds = new DataSet();
                ds.Tables.Clear();

                DataTable dt = ds.Tables.Add("Sheet1");
                DataRow dr;
                DataColumn column;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "序号";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "状态";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "考生号";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "姓名";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "专业总分";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "专业总平均序";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "专业排名";
                ds.Tables["Sheet1"].Columns.Add(column);

                int count = modelList.Count;
                for (int i = 0, num = 1; i < count; i++, num++)
                {
                    dr = ds.Tables["Sheet1"].NewRow();
                    dr["序号"] = num.ToString();
                    dr["状态"] = getIntoCEE(modelList[i].UP_calculation_status.ToString(), modelList[i].User_id.ToString());
                    dr["姓名"] = modelList[i].User_realname;
                    dr["考生号"] = modelList[i].UP_CCOM_number;
                    dr["专业总分"] = ((decimal)(modelList[i].AEE_score)).ToString("F2");
                    dr["专业总平均序"] = ((decimal)modelList[i].AEE_sequence).ToString("F2");
                    dr["专业排名"] = modelList[i].AEE_ranking;

                    ds.Tables["Sheet1"].Rows.Add(dr);
                }

                DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), this.ddlMajor.SelectedItem.Text+"_进入文考情况_" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("获取进入文考情况出错", "", "Error");
            }
        }
    }
}