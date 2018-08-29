using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using university.Web.AdminMetro.CCOM.CEEManege;

namespace university.Web.AdminMetro.CCOM.AEEManage
{
    public partial class JudgeSubjectScoreList : university.UI.ManagePage
    {
        protected string keywords = "";
        protected string ea_id = "";
        protected string esn_id = "";
        protected string judge_id = "";
        public JudgeSubjectScoreList()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ea_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("ea_id"));
            esn_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("esn_id"));
            judge_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("judge_id"));
            if (!Page.IsPostBack)
            {
                keywords = MyRequest.GetQueryString("keywords");
                if (Tools.CheckParams(keywords))
                {
                    keywords = "";
                }
                this.txtKeywords.Text = keywords;

                RptBind();
            }
        }

        private void RptBind()
        {
            BLL.CCOM.Judge Bj = new BLL.CCOM.Judge();
            DataSet ds = Bj.GetList("");
            this.ddlJudge.DataSource = ds.Tables[0].DefaultView;
            this.ddlJudge.DataTextField = "Judge_name";
            this.ddlJudge.DataValueField = "Judge_id";
            this.ddlJudge.DataBind();

            string order = "UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);
            this.ddlJudge.SelectedValue = judge_id;
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

            BLL.CCOM.View_AEE_Subject_Score bll = new BLL.CCOM.View_AEE_Subject_Score();

            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);
            //   txtSearchResult.Text = "本次命中" + totalCount.ToString() + "条";

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("JudgeSubjectScoreList.aspx", "fun_id={0}&page={1}&keywords={2}&ea_id={3}&esn_id={4}&judge_id={5}", DESEncrypt.Encrypt(this.fun_id), "__id__",
                this.txtKeywords.Text, DESEncrypt.Encrypt(ea_id), DESEncrypt.Encrypt(esn_id), DESEncrypt.Encrypt(this.ddlJudge.SelectedValue));
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

            if (!esn_id.Equals(""))
            {
                strTemp.Append(" AND Subject_id = " + esn_id);
            }

            if (!ea_id.Equals(""))
            {
                strTemp.Append(" AND Ea_id = " + ea_id);
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("JudgeSubjectScoreList_page_size"), out _pagesize))
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
                    Utils.WriteCookie("JudgeSubjectScoreList_page_size", _pagesize.ToString(), 43200);
                }
            }
            string keywords = MyRequest.GetQueryString("keywords");
            Response.Redirect(Utils.CombUrlTxt("JudgeSubjectScoreList.aspx", "fun_id={0}&keywords={1}&ea_id={2}&esn_id={3}&judge_id={4}", DESEncrypt.Encrypt(this.fun_id), 
                this.txtKeywords.Text, DESEncrypt.Encrypt(ea_id), DESEncrypt.Encrypt(esn_id), DESEncrypt.Encrypt(this.ddlJudge.SelectedValue)));
        }
        #endregion

        protected string getSubjectScore(string _user_id, string _esn_id, string _judge_id){
            string strWhere = " User_id="+_user_id + " AND Esn_id="+_esn_id+ " AND Judge_id=" + _judge_id;
            Model.CCOM.Examination_subject_score subScore = new BLL.CCOM.Examination_subject_score().GetModel(strWhere);
            string score = "";
            if (subScore != null)
            {
                score = subScore.Ess_score.ToString();
            }

            return score;
        }

        protected string getSubjectXu(string _user_id, string _esn_id, string _judge_id)
        {
            string strWhere = " User_id=" + _user_id + " AND Esn_id=" + _esn_id + " AND Judge_id=" + _judge_id;
            Model.CCOM.Examination_subject_score subScore = new BLL.CCOM.Examination_subject_score().GetModel(strWhere);
            string Xu = "";
            if (subScore != null)
            {
                Xu = subScore.Ess_sequence.ToString();
            }

            return Xu;
        }

        protected string getSubjectName(string _esn_id)
        {
            string strWhere = " Subject_id=" + _esn_id;
            Model.CCOM.Subject subject = new BLL.CCOM.Subject().GetModel(strWhere);
            string name = "";
            if (subject != null)
            {
                name = subject.Subject_title;
            }
            return name;
        }
        protected void ddlJudge_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("JudgeSubjectScoreList.aspx", "fun_id={0}&keywords={1}&ea_id={2}&esn_id={3}&judge_id={4}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(ea_id), DESEncrypt.Encrypt(esn_id), DESEncrypt.Encrypt(this.ddlJudge.SelectedValue)));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("JudgeSubjectScoreList.aspx", "fun_id={0}&keywords={1}&ea_id={2}&esn_id={3}&judge_id={4}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(ea_id), DESEncrypt.Encrypt(esn_id), DESEncrypt.Encrypt(this.ddlJudge.SelectedValue)));
        }


        protected void Excel_Click(object sender, EventArgs e)
        {
            string order = "UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);
            try
            {
                BLL.CCOM.View_AEE_Subject_Score bll = new BLL.CCOM.View_AEE_Subject_Score();

                List<Model.CCOM.View_AEE_Subject_Score> modelList = bll.GetModelList(strWhere + " order by " + order);

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
                column.ColumnName = "考生号";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "姓名";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科目名称";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科目成绩";
                ds.Tables["Sheet1"].Columns.Add(column);

                int count = modelList.Count;
                for (int i = 0, num = 1; i < count; i++, num++)
                {
                    dr = ds.Tables["Sheet1"].NewRow();
                    dr["序号"] = num.ToString();
                    dr["姓名"] = modelList[i].User_realname;
                    dr["考生号"] = modelList[i].UP_CCOM_number;
                    dr["科目名称"] = getSubjectName(modelList[i].Subject_id.ToString());

                    
                    string score = getSubjectScore(modelList[i].User_id.ToString(), modelList[i].Subject_id.ToString(), this.judge_id.ToString());
                    if (score != null && score!="")
                    {
                        dr["科目成绩"] = score;
                    }
                    ds.Tables["Sheet1"].Rows.Add(dr);
                }
                
                DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), "导入考生科目成绩模板" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("获取考生成绩模板出错", "", "Error");
            }
        }
        protected void exportexcel_ServerClick(object sender, EventArgs e)
        {
            string order = "UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);
            try
            {
                BLL.CCOM.View_AEE_Subject_Score bll = new BLL.CCOM.View_AEE_Subject_Score();

                List<Model.CCOM.View_AEE_Subject_Score> modelList = bll.GetModelList(strWhere + " order by " + order);

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
                column.ColumnName = "考生号";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "姓名";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科目名称";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科目成绩";
                ds.Tables["Sheet1"].Columns.Add(column);

                int count = modelList.Count;
                for (int i = 0, num = 1; i < count; i++, num++)
                {
                    dr = ds.Tables["Sheet1"].NewRow();
                    dr["序号"] = num.ToString();
                    dr["姓名"] = modelList[i].User_realname;
                    dr["考生号"] = modelList[i].UP_CCOM_number;
                    dr["科目名称"] = getSubjectName(modelList[i].Subject_id.ToString());


                    string score = getSubjectScore(modelList[i].User_id.ToString(), modelList[i].Subject_id.ToString(), this.judge_id.ToString());
                    if (score != null && score != "")
                    {
                        dr["科目成绩"] = score;
                    }
                    ds.Tables["Sheet1"].Rows.Add(dr);
                }

                DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), "考生科目成绩_" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("获取考生科目成绩出错", "", "Error");
            }
        }
        /*
        protected void btnCalculation_Click(object sender, EventArgs e)
        {
            try
            {
                new Calculation().calculateSubjectXu(this.esn_id, this.judge_id);
                JscriptMsg("计算科目序成功", "JudgeSubjectScoreList.aspx?fun_id=" + MyRequest.GetString("fun_id") + "&ea_id=" + DESEncrypt.Encrypt(ea_id) + "&esn_id=" + DESEncrypt.Encrypt(esn_id) + "&judge_id=" + DESEncrypt.Encrypt(this.ddlJudge.SelectedValue), "Success");
            }
            catch
            {
                JscriptMsg("计算科目序失败，请重新尝试", "", "Error");
            }
        }
         */
    }
}