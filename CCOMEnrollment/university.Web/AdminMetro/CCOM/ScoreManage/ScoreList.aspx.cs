using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.Text;
using LitJson;

namespace university.Web.AdminMetro.CCOM.ScoreManage
{
    public partial class ScoreList : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string keywords = MyRequest.GetQueryString("keywords");

        public ScoreList()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fun_id = MyRequest.GetQueryString("fun_id");

            if (!Page.IsPostBack)
            {
                ShowScoreInfo();
                 BindRpt();
            }

        }

        protected void BindRpt()
        {
            string _order = MyRequest.GetString("sort").Replace(",", " ");
            if (_order == "" || Tools.CheckParams(_order)) _order = " User_id asc";
            RptBind( CombSqlTxt(this.keywords), _order);
        }
        
        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" Role_id = 3");   
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and User_realname like '%" + _keywords + "%' ");
                strTemp.Append(" or User_number like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            this.st_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Value = keywords;

            BLL.CCOM.View_User bll = new BLL.CCOM.View_User();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("ScoreList.aspx", "fun_id={0}&keywords={1}&page={2}", this.fun_id, this.keywords, "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("stu_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keywords = this.txtKeywords.Value;
            Response.Redirect(Utils.CombUrlTxt("ScoreList.aspx", "fun_id={0}&keywords={1}", this.fun_id.ToString(), this.txtKeywords.Value));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("stu_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ScoreList.aspx", "fun_id={0}&keywords={1}", this.fun_id, this.keywords));
        }

        protected String GetTeacher(long userId)
        {
            try
            {
                var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId);
                return new BLL.CCOM.User_information().GetModel(relation_model.Teacher_id).User_realname;
            }
            catch {
                return "--";
            }
        }

        protected String GetTopic(long userId)
        {
            try
            {
                var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId);
                return new BLL.CCOM.Topic().GetModel(relation_model.Topic_id).Topic_name;
            }
            catch
            {
                return "--";
            }
        }

        protected String GetCommentScore(long userId,int type)
        {
            int score;
            try
            {
                var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId);
                var model= new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
                if (type == 1)
                    score = (int)model.Teacher_score;
                else
                {
                    float sc = GetUser_CommentScore(userId);
                    if (sc != -1) return sc.ToString();
                    else return "--";
                }
            }
            catch
            {
                return "--";
            }
            return score.ToString();
        }

        protected String GetSoftwareScore(long userId)
        {
            int score;
            try
            {
                var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId);
                var model= new BLL.CCOM.Software_accept().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
                score = (int)model.Conclusion;
            }
            catch
            {
                return "--";
            }
            return score.ToString();
        }

        protected String GetScore(long userId)
        {
            var model = new BLL.CCOM.Comput_score().GetModel(1);
            try
            {
                int score_t = 0, score_s = 0, score_c = 0;
                decimal score = 0;
                var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId);
                Model.CCOM.Comment model_c = new BLL.CCOM.Comment().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
                Model.CCOM.Software_accept model_s = new BLL.CCOM.Software_accept().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
                score_t = (int)model_c.Teacher_score;
                score_c = (int)model_c.Reply_score;
                score_s=(int)model_s.Conclusion;
                if (model.Ratio_software == 0)
                {
                    score = score_t * model.Ratio_teacher + (int)((score_s < score_c ? score_s : score_c) * model.Ratio_review);
                }
                else
                {
                    score = score_t * model.Ratio_teacher + (int)((score_s > score_c ? score_s : score_c) * model.Ratio_review);
                }
                return score.ToString();
            }
            catch
            {
                return "--";
            }
        }

        protected void ShowScoreInfo()
        {
            var model = new BLL.CCOM.Comput_score().GetModel(1);
            this.lblScroeInfor.InnerText = "成绩说明：最终成绩=指导教师评分*" + model.Ratio_teacher.ToString() + "+" + (model.Ratio_software == 1 ? "较大值" : "较小值") + "（口头答辩成绩，软件验收成绩）*" + model.Ratio_review.ToString();
        }
    }
}