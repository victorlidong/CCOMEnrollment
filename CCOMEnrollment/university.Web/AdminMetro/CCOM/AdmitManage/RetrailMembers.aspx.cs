using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.AdmitManage
{
    public partial class RetrailMembers : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string keywords = "";
        protected long user_id = 0;
        protected int agency_id = -1;
        protected string major_id = "0";
        protected int period_id = 0;
        protected List<Model.CCOM.Subject> subList = new List<Model.CCOM.Subject>();

        protected int count = 0;
        protected bool hasRetrial = true;
        public RetrailMembers()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
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
        }

        private void RalBind()
        {
            try
            {
                string order = "";
                string strWhere = " Major_id=" + major_id + " AND Period_id=" + period_id;

                BLL.CCOM.Exam_preliminary_subject bll = new BLL.CCOM.Exam_preliminary_subject();
                var epsmodel = bll.GetModel(strWhere);

                if (epsmodel != null)
                {
                    int Esn_id = epsmodel.Esn_id;
                    subList = new BLL.CCOM.Subject().GetModelList(" Fs_id=" + Esn_id);
                    count = subList.Count;
                }

                order = "Epss_score DESC, Epss_sequence DESC ,UP_CCOM_number asc";
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
            catch
            {
                JscriptMsg("数据出错", "", "Error");
            }
        }


        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(50); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;

            BLL.CCOM.View_Preliminary_Score bll = new BLL.CCOM.View_Preliminary_Score();

            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);
            //   txtSearchResult.Text = "本次命中" + totalCount.ToString() + "条";

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);

            this.rptList.DataBind();


            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("RetrailMembers.aspx", "fun_id={0}&page={1}&keywords={2}&major_id={3}", DESEncrypt.Encrypt(this.fun_id), "__id__",
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

            strTemp.Append(" AND Period_id=" + period_id + " AND Major_id=" + major_id);

            strTemp.Append(" AND UP_calculation_status > 2");

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("RetrailMembers_page_size"), out _pagesize))
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
                    Utils.WriteCookie("RetrailMembers_page_size", _pagesize.ToString(), 43200);
                }
            }
            string keywords = MyRequest.GetQueryString("keywords");
            Response.Redirect(Utils.CombUrlTxt("RetrailMembers.aspx", "fun_id={0}&keywords={1}&major_id={2}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id)));
        }
        #endregion


        public string getSubjectDetail(string user_id)
        {
            string str = "";
            foreach (var model in subList)
            {
                str += "<td align=\"left\">" + getSubjectAverageScore(user_id, model.Subject_id.ToString()) + "</td>";
                str += "<td align=\"left\">" + getSubjectAverageXu(user_id, model.Subject_id.ToString()) + "</td>";
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

        protected string getMajorName()
        {
            string strWhere = " Agency_id=" + major_id;
            Model.CCOM.Agency majormodel = new BLL.CCOM.Agency().GetModel(strWhere);
            string name = "";
            if (majormodel != null)
            {
                name = majormodel.Agency_name.ToString();
            }

            return name;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("RetrailMembers.aspx", "fun_id={0}&keywords={1}&major_id={2}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id)));
        }

        protected void exportexcel_ServerClick(object sender, EventArgs e)
        {
            string order = "";
            string strWhere = "";

            order = "Epss_score DESC, Epss_sequence DESC ,UP_CCOM_number asc";
            strWhere = CombSqlTxt(this.keywords);
            try
            {
                string strWhere1 = " Major_id=" + major_id + " AND Period_id=" + period_id;

                BLL.CCOM.Exam_preliminary_subject bll1 = new BLL.CCOM.Exam_preliminary_subject();
                var epsmodel = bll1.GetModel(strWhere1);

                if (epsmodel != null)
                {
                    int Esn_id = epsmodel.Esn_id;
                    subList = new BLL.CCOM.Subject().GetModelList(" Fs_id=" + Esn_id);
                    count = subList.Count;
                }


                BLL.CCOM.View_Preliminary_Score bll = new BLL.CCOM.View_Preliminary_Score();
                List<Model.CCOM.View_Preliminary_Score> modelList = bll.GetModelList(strWhere + " order by " + order);

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

                    dr["总成绩"] = ((decimal)(modelList[i].Epss_score)).ToString("F2");
                    dr["总平均序"] = ((decimal)modelList[i].Epss_sequence).ToString("F2");

                    _ds.Tables["Sheet1"].Rows.Add(dr);
                }

                DataToExcel.ExportToExcel(_ds, Server.MapPath("/upload/excel/"), getMajorName() + "_复试名单_" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("导出最终成绩出错", "", "Error");
            }
        }
    }
}