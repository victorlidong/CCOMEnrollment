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
    public partial class ProposalList : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string keywords = MyRequest.GetQueryString("keywords");

        public ProposalList()
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

        protected String GetScore(long userId)
        {
            var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId);
            if (relation_model == null) return "--";
            var model = new BLL.CCOM.Proposal().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
            if (model == null) return "--";
            if (model.Result == 0) return "未审核";
            if (model.Result == 1) return "已通过";
            if (model.Result == 2) return "未通过";
            return "--";
        }

        protected String GetURL(long userId)
        {
            var relation_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userId);
            if (relation_model == null) return "--";
            var model = new BLL.CCOM.Proposal().GetModel(" Topic_relation_id=" + relation_model.Topic_relation_id);
            if (model == null) return "--";

            var rs_models = new BLL.CCOM.Reply_student().GetModelList(" User_id=" + userId);
            foreach(var rs_model in rs_models)
            {
                long group_id = rs_model.Group_id;
                if (new BLL.CCOM.Reply_group().GetModel(group_id).Group_type == 2)
                {
                    return "<a href=\"ProposalReview.aspx?userId=" + DESEncrypt.Encrypt(userId.ToString()) + "&groupid=" + DESEncrypt.Encrypt(group_id.ToString()) + "&fun_id=<%=DESEncrypt.Encrypt(\"15\") %>开题评审表</a>";
                    break;
                }
            }
            return "--";
        }

    }
}