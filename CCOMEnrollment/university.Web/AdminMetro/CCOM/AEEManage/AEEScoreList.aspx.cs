using System;
using System.Collections;
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
    public partial class AEEScoreList : university.UI.ManagePage
    {
        protected string keywords = "";
        protected long user_id = 0;
        protected int agency_id = -1;
        protected string major_id = "0";
        protected int period_id = 0;
        protected List<Model.CCOM.Subject> subList = new List<Model.CCOM.Subject>();
        protected Hashtable Weights = new Hashtable();

        protected int count = 0;

        public AEEScoreList()
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
            string order = "";
            string strWhere = " Major_Agency_id=" + major_id + " AND Period_id=" + period_id + " AND Subject_level=2";

            subList = new BLL.CCOM.Subject().GetModelList(strWhere+order);
            count = subList.Count;

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
            string pageUrl = Utils.CombUrlTxt("AEEScoreList.aspx", "fun_id={0}&page={1}&keywords={2}&major_id={3}", DESEncrypt.Encrypt(this.fun_id), "__id__",
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
            if (int.TryParse(Utils.GetCookie("AEEScoreList"), out _pagesize))
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
                    Utils.WriteCookie("AEEScoreList_page_size", _pagesize.ToString(), 43200);
                }
            }
            string keywords = MyRequest.GetQueryString("keywords");
            Response.Redirect(Utils.CombUrlTxt("AEEScoreList.aspx", "fun_id={0}&keywords={1}&major_id={2}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id)));
        }
        #endregion

        public string getSubjectDetail(string user_id)
        {
            string str = "";
            foreach (var model in subList)
            {
                str += "<td align=\"center\">" + getSubjectAverageScore(user_id, model.Subject_id.ToString()) + "</td>";
                str += "<td align=\"center\">" + getSubjectAverageXu(user_id, model.Subject_id.ToString()) + "</td>";
            }
            return str;
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

        protected void btnCalAEEScore_Click(object sender, EventArgs e)
        {
            getSubjectWeights();

            string order = "";
            string strWhere = " Major_Agency_id=" + major_id + " AND Period_id=" + period_id + " AND Subject_level=2";

            subList = new BLL.CCOM.Subject().GetModelList(strWhere + order);
            count = subList.Count;

            order = " order by UP_CCOM_number asc";
            strWhere = CombSqlTxt("");
            BLL.CCOM.View_AEE_Score bll = new BLL.CCOM.View_AEE_Score();
            BLL.CCOM.Examination_AEE_score bll1 = new BLL.CCOM.Examination_AEE_score();

            var userList = bll.GetModelList(strWhere + order);
            try
            {
                foreach (var model in userList)
                {
                    decimal _score = 0;
                    decimal _sequence = 0;
                    foreach (var model1 in subList)
                    {
                        decimal weight = ((decimal)Weights[model1.Subject_id] / (decimal)Weights[0]) * ((decimal)model1.Subject_weight / (decimal)Weights[model1.Fs_id]);
                        _score += Convert.ToDecimal(getSubjectAverageScore(model.User_id.ToString(), model1.Subject_id.ToString())) * weight;
                        if (getSubjectAverageXu(model.User_id.ToString(), model1.Subject_id.ToString()) != "")
                        {
                            _sequence += Convert.ToDecimal(getSubjectAverageXu(model.User_id.ToString(), model1.Subject_id.ToString())) * weight;
                        }
                    }

                    var _model = bll1.GetModel(" User_id="+model.User_id + " AND Period_id="+period_id);
                    var __model = new Model.CCOM.Examination_AEE_score();
                    __model.AEE_score = _score;
                    __model.AEE_sequence = _sequence;
                    __model.Period_id = period_id;
                    __model.User_id = model.User_id;
                    if (_model != null)
                    {
                        __model.AEE_id = _model.AEE_id;
                        bll1.Update(__model);
                    }
                    else
                    {

                        bll1.Add(__model);
                    }
                }
                var userList1 = bll.GetModelList(strWhere + " order by AEE_score DESC, AEE_sequence DESC, UP_CCOM_number asc");
                int rank = 1;
                foreach (var model in userList1)
                {
                    var _model = bll1.GetModel(" User_id=" + model.User_id + " AND Period_id=" + period_id);
                    _model.AEE_ranking = rank++;
                    bll1.Update(_model);
                }

                JscriptMsg("计算成绩成功", "AEEScoreList.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "&keywords=" + this.txtKeywords.Text + "&major_id=" + DESEncrypt.Encrypt(this.major_id), "Success");
            }
            catch
            {
                JscriptMsg("计算成绩出错", "", "Error");
            }
        }

        protected void getSubjectWeights()
        {
            string order = "";
            string strWhere = " Major_Agency_id=" + major_id + " AND Period_id=" + period_id + " AND Subject_level=1";

            var subList1 = new BLL.CCOM.Subject().GetModelList(strWhere + order);
            decimal weights = 0;
            Weights.Clear();

            foreach (var model in subList1)
            {
                strWhere = " Major_Agency_id=" + major_id + " AND Period_id=" + period_id + " AND Subject_level=2 AND Fs_id="+model.Subject_id;
                var subList2 = new BLL.CCOM.Subject().GetModelList(strWhere);
                decimal _weights = 0;
                foreach (var _model in subList2)
                {
                    _weights += (decimal)_model.Subject_weight;

                    Weights.Add(_model.Subject_id, model.Subject_weight);
                }

                Weights.Add(model.Subject_id, _weights);
                weights += (decimal)model.Subject_weight;
            }
            Weights.Add(0, weights);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("AEEScoreList.aspx", "fun_id={0}&keywords={1}&major_id={2}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id)));
        }
        protected void exportexcel_ServerClick(object sender, EventArgs e)
        {
            string order = "AEE_score DESC, AEE_sequence DESC ,UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);

            try
            {
                string order1 = "";
                string strWhere1 = " Major_Agency_id=" + major_id + " AND Period_id=" + period_id + " AND Subject_level=2";

                subList = new BLL.CCOM.Subject().GetModelList(strWhere1 + order1);
                count = subList.Count;

                BLL.CCOM.View_AEE_Score bll = new BLL.CCOM.View_AEE_Score();
                List<Model.CCOM.View_AEE_Score> modelList = bll.GetModelList(strWhere + " order by " + order);

                DataSet _ds = new DataSet();
                _ds.Tables.Clear();

                DataTable dt = _ds.Tables.Add("Sheet1");
                DataRow dr;
                DataColumn column;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "序号";
                _ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "考生号";
                _ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "姓名";
                _ds.Tables["Sheet1"].Columns.Add(column);

                if (count > 0)
                    foreach (var model in subList)
                    {
                        column = new DataColumn();
                        column.DataType = System.Type.GetType("System.String");
                        column.ColumnName = model.Subject_title;
                        _ds.Tables["Sheet1"].Columns.Add(column);

                        column = new DataColumn();
                        column.DataType = System.Type.GetType("System.String");
                        column.ColumnName = model.Subject_title + "序";
                        _ds.Tables["Sheet1"].Columns.Add(column);
                    }

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "总成绩";
                _ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "总平均序";
                _ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "专业排名";
                _ds.Tables["Sheet1"].Columns.Add(column);

                int _count = modelList.Count;
                for (int i = 0, num = 1; i < _count; i++, num++)
                {
                    dr = _ds.Tables["Sheet1"].NewRow();
                    dr["序号"] = num.ToString();
                    dr["姓名"] = modelList[i].User_realname;
                    dr["考生号"] = modelList[i].UP_CCOM_number;

                    int t = 0;
                    if (count > 0)
                        foreach (var model in subList)
                        {
                            dr[3 + t] = getSubjectAverageScore(modelList[i].User_id.ToString(), model.Subject_id.ToString());
                            dr[3 + t + 1] = getSubjectAverageXu(modelList[i].User_id.ToString(), model.Subject_id.ToString());
                            t += 2;
                        }

                    dr["总成绩"] = ((decimal)(modelList[i].AEE_score)).ToString("F2");
                    dr["总平均序"] = ((decimal)modelList[i].AEE_sequence).ToString("F2");
                    dr["专业排名"] = modelList[i].AEE_ranking;

                    _ds.Tables["Sheet1"].Rows.Add(dr);
                }
                DataToExcel.ExportToExcel(_ds, Server.MapPath("/upload/excel/"), "艺考科目成绩_" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("获取艺考科目成绩出错", "", "Error");
            }
        }
    }

}