using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using university.Database;

namespace university.Web.AdminMetro.CCOM.AEEManage
{
    public partial class SubjectScoreList : university.UI.ManagePage
    {        
        protected string keywords = "";
        protected string esn_id = "";
        protected string major_id = "";
        protected int j=0 , k = 0;

        protected int count = 0;
        protected DataSet ds;
        public SubjectScoreList()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            esn_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("esn_id"));
            major_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("major_id"));

            string sqlStr = "SELECT DISTINCT Judge_id FROM Examination_subject_score WHERE Esn_id=" + esn_id + " AND User_id IN (SELECT User_id FROM User_property WHERE Agency_id=" + major_id + ")";
            var judgeList = DBSQL.Query(sqlStr);

            count = judgeList.Tables[0].Rows.Count;
            if (count > 0)
            {
                ds = judgeList;

            }

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
            string order = "UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);
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
            string pageUrl = Utils.CombUrlTxt("SubjectScoreList.aspx", "fun_id={0}&page={1}&keywords={2}&esn_id={3}&major_id={4}", DESEncrypt.Encrypt(this.fun_id), "__id__",
                this.txtKeywords.Text, DESEncrypt.Encrypt(esn_id), DESEncrypt.Encrypt(major_id));
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

            if (!major_id.Equals(""))
            {
                strTemp.Append(" AND Agency_id = " + major_id);
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("SubjectScoreList_page_size"), out _pagesize))
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
                    Utils.WriteCookie("SubjectScoreList_page_size", _pagesize.ToString(), 43200);
                }
            }
            string keywords = MyRequest.GetQueryString("keywords");
            Response.Redirect(Utils.CombUrlTxt("SubjectScoreList.aspx", "fun_id={0}&keywords={1}&esn_id={2}&major_id={3}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(esn_id), DESEncrypt.Encrypt(major_id)));
        }
        #endregion

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

        protected string getJudgeName(string _judge_id)
        {
            string strWhere = " Judge_id=" + _judge_id;
            Model.CCOM.Judge judge = new BLL.CCOM.Judge().GetModel(strWhere);
            string name = "";
            if (judge != null)
            {
                name = judge.Judge_name;
            }
            return name;
        }

        protected string getSubjectScore(string _user_id, string _esn_id, string _judge_id)
        {
            string strWhere = " User_id=" + _user_id + " AND Esn_id=" + _esn_id + " AND Judge_id=" + _judge_id;
            Model.CCOM.Examination_subject_score subScore = new BLL.CCOM.Examination_subject_score().GetModel(strWhere);
            string score = "";
            if (subScore != null)
            {
                score = subScore.Ess_score.ToString();
            }
            j++;
            return score;
        }

        protected bool getSubjectScoreStatus(string _user_id, string _esn_id, string _judge_id)
        {
            string strWhere = " User_id=" + _user_id + " AND Esn_id=" + _esn_id + " AND Judge_id=" + _judge_id;
            Model.CCOM.Examination_subject_score subScore = new BLL.CCOM.Examination_subject_score().GetModel(strWhere);
            bool score = true;
            if (subScore != null)
            {
                score = (bool)(subScore.Ess_score_status);
            }

            return score;
        }

        protected string getSubjectXu(string _user_id, string _esn_id, string _judge_id)
        {
            string strWhere = " User_id=" + _user_id + " AND Esn_id=" + _esn_id + " AND Judge_id=" + _judge_id;
            Model.CCOM.Examination_subject_score sub = new BLL.CCOM.Examination_subject_score().GetModel(strWhere);
            string Xu = "";
            if (sub != null)
            {
                Xu = sub.Ess_sequence.ToString();
            }
            k++;
            return Xu;
        }

        protected bool getSubjectXuStatus(string _user_id, string _esn_id, string _judge_id)
        {
            string strWhere = " User_id=" + _user_id + " AND Esn_id=" + _esn_id + " AND Judge_id=" + _judge_id;
            Model.CCOM.Examination_subject_score sub = new BLL.CCOM.Examination_subject_score().GetModel(strWhere);
            bool Xu = true;
            if (sub != null)
            {
                Xu = (bool)(sub.Ess_order_status);
            }

            return Xu;
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
            if (sub != null && sub.Esas_sequence!=null)
            {
                Xu = ((decimal)(sub.Esas_sequence)).ToString("F2");
            }

            return Xu;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("SubjectScoreList.aspx", "fun_id={0}&keywords={1}&esn_id={2}&major_id={3}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(esn_id), DESEncrypt.Encrypt(major_id)));
        }

        public string outHtml1(string user_id, string subject_id)
        {
           string str="";
           for (int i = 0; i < count; i++)
           {
               if (getSubjectScoreStatus(user_id, subject_id, ds.Tables[0].Rows[j % count]["Judge_id"].ToString()))
               {
                   str += "<td align=\"center\">" + getSubjectScore(user_id, subject_id, ds.Tables[0].Rows[j % count]["Judge_id"].ToString()) + "</td>";
               }
               else
               {
                   str += "<td align=\"center\" style=\"text-decoration:line-through;\">" + getSubjectScore(user_id, subject_id, ds.Tables[0].Rows[j % count]["Judge_id"].ToString()) + "</td>";
               }
           }
           return str;
        }

        public string outHtml2(string user_id, string subject_id)
        {
            string str = "";
            for (int i = 0; i < count; i++)
            {
                if (getSubjectXuStatus(user_id, subject_id, ds.Tables[0].Rows[k % count]["Judge_id"].ToString())) {
                    str += "<td align=\"center\">" + getSubjectXu(user_id, subject_id, ds.Tables[0].Rows[k % count]["Judge_id"].ToString()) + "</td>";
                }
                else
                {
                    str += "<td align=\"center\" style=\"text-decoration:line-through;\">" + getSubjectXu(user_id, subject_id, ds.Tables[0].Rows[k % count]["Judge_id"].ToString()) + "</td>";
                }
            }
            return str;
        }

        protected void btnCalculationScore_Click(object sender, EventArgs e)
        {
            string strWhere = " Agency_id= " + major_id + " order by User_id";      //获取当前计算考生列表
            var userList = new BLL.CCOM.User_property().GetModelList(strWhere);

            int user_count = userList.Count;

            ScoreManege();
        }


        public bool DoAvgScore(Model.CCOM.Examination_subject_average_score _model)
        {
            try
            {
                BLL.CCOM.Examination_subject_average_score bll = new BLL.CCOM.Examination_subject_average_score();
                var model = bll.GetModel(" Esn_id= "+_model.Esn_id + " AND User_id="+_model.User_id);

                if (model != null)
                {
                    _model.Esas_id = model.Esas_id;
                    bll.Update(_model);
                }
                else
                {
                    bll.Add(_model);
                }
                return true;
            }
            catch
            {
                JscriptMsg("计算考生平均成绩出错", "", "Error");
                return false;
            }
        }

        public int DelScore(int amount)
        {
            int number = 0;
            switch (amount)
            {
                case 1:
                case 2:{
                    number = 0;
                    break;
                }
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    {
                        number = 1;
                        break;
                    }
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    {
                        number = 2;
                        break;
                    }
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                    {
                        number = 3;
                        break;
                    }
                default: 
                    number = 4;
                    break;
            }

            return number;
        }
        protected void exportexcel_ServerClick(object sender, EventArgs e)
        {
            string order = "UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);
            try
            {
                BLL.CCOM.View_AEE_Subject_Score bll = new BLL.CCOM.View_AEE_Subject_Score();
                List<Model.CCOM.View_AEE_Subject_Score> modelList = bll.GetModelList(strWhere + " order by " + order);

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

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科目名称";
                _ds.Tables["Sheet1"].Columns.Add(column);

                for (int i = 0; i < count; i++)
                {
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = getJudgeName(ds.Tables[0].Rows[i]["Judge_id"].ToString());
                    _ds.Tables["Sheet1"].Columns.Add(column);
                }

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科目平均成绩";
                _ds.Tables["Sheet1"].Columns.Add(column);

                for (int i = 0; i < count; i++)
                {
                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = getJudgeName(ds.Tables[0].Rows[i]["Judge_id"].ToString()) + "序";
                    _ds.Tables["Sheet1"].Columns.Add(column);
                }

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "科目平均序";
                _ds.Tables["Sheet1"].Columns.Add(column);

                int _count = modelList.Count;
                for (int i = 0, num = 1; i < _count; i++, num++)
                {
                    dr = _ds.Tables["Sheet1"].NewRow();
                    dr["序号"] = num.ToString();
                    dr["姓名"] = modelList[i].User_realname;
                    dr["考生号"] = modelList[i].UP_CCOM_number;
                    dr["科目名称"] = getSubjectName(modelList[i].Subject_id.ToString());

                    for (int x = 0; x < count; x++)
                    {
                        dr[4 + x] = getSubjectScore(modelList[i].User_id.ToString(), modelList[i].Subject_id.ToString(), ds.Tables[0].Rows[x % count]["Judge_id"].ToString());
                    }
                    dr["科目平均成绩"] = getSubjectAverageScore(modelList[i].User_id.ToString(), modelList[i].Subject_id.ToString());

                    for (int y = 0; y < count; y++)
                    {
                        dr[4 + y + count + 1] = getSubjectXu(modelList[i].User_id.ToString(), modelList[i].Subject_id.ToString(), ds.Tables[0].Rows[y % count]["Judge_id"].ToString());
                    }
                    dr["科目平均序"] = getSubjectAverageXu(modelList[i].User_id.ToString(), modelList[i].Subject_id.ToString());

                    _ds.Tables["Sheet1"].Rows.Add(dr);
                }
                DataToExcel.ExportToExcel(_ds, Server.MapPath("/upload/excel/"), "考生科目成绩_" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("获取考生科目成绩出错", "", "Error");
            }
        }

        public void ScoreManege()
        {
            string str = CombSqlTxt("");
            BLL.CCOM.View_AEE_Subject_Score bll1 = new BLL.CCOM.View_AEE_Subject_Score();
            var userModelList = bll1.GetModelList(str);

            foreach (var user_model in userModelList)
            {
                string sqlStr = "SELECT DISTINCT Judge_id FROM Examination_subject_score WHERE Esn_id=" + esn_id + " AND User_id ="+user_model.User_id;
                var judgeList = DBSQL.Query(sqlStr);

                int _count = judgeList.Tables[0].Rows.Count;

                string strWhere = " Esn_id= " + esn_id + " AND User_id=" + user_model.User_id + " order by Ess_score DESC";
                var scoreList = new BLL.CCOM.Examination_subject_score().GetModelList(strWhere);
                int score_count = scoreList.Count;

                BLL.CCOM.Examination_subject_score blls = new BLL.CCOM.Examination_subject_score();
                BLL.CCOM.Examination_subject_average_score bll = new BLL.CCOM.Examination_subject_average_score();
                int now = 0;
                int num = DelScore(_count);
                int chushu = 0;
                decimal avgScore = 0;
                int? avgXu = 0;

                foreach (var score_model in scoreList)
                {
                    if (now > num - 1 && now < _count - num)
                    {
                        avgScore += score_model.Ess_score;
                        avgXu += score_model.Ess_sequence;
                        chushu++;
                        score_model.Ess_score_status = true;
                        score_model.Ess_order_status = true;
                    }
                    else
                    {
                        score_model.Ess_score_status = false;
                        score_model.Ess_order_status = false;
                    }
                    blls.Update(score_model);
                    if (now == _count - 1)
                    {
                        Model.CCOM.Examination_subject_average_score _model = new Model.CCOM.Examination_subject_average_score();
                        _model.Esas_score = avgScore / chushu;
                        _model.Esas_sequence = (decimal)(avgXu / (1.0 * chushu));
                        _model.User_id = score_model.User_id;
                        _model.Esn_id = score_model.Esn_id;

                        DoAvgScore(_model);
                        avgScore = 0;
                        avgXu = 0;
                        now = chushu = 0;
                        continue;
                    }
                    now++;
                }
            }
            JscriptMsg("计算科目成绩成功", "SubjectScoreList.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "&keywords=" + this.txtKeywords.Text + "&esn_id=" + DESEncrypt.Encrypt(esn_id) + "&major_id=" + DESEncrypt.Encrypt(major_id), "Success");
        }
    }
}