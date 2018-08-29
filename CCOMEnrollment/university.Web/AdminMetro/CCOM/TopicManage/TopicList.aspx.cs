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

namespace university.Web.AdminMetro.CCOM.TopicManage
{
    public partial class TopicList : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string keywords = MyRequest.GetQueryString("keywords");

        public TopicList()
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
            if (_order == "" || Tools.CheckParams(_order)) _order = " Topic_id asc";
            Model.CCOM.User_information user_model = GetAdminInfo_CCOM();
            RptBind(" Teacher_id=" + user_model.User_id, _order);
        }
        
        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            Model.CCOM.User_information user_model = GetAdminInfo_CCOM();

            strTemp.Append(" Teacher_id=" + user_model.User_id);
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" Topic_name like '%" + _keywords + "%' ");
                //strTemp.Append(" or User_number like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        //删除
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Topic bll = new BLL.CCOM.Topic();


            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool result = true;
                try
                {
                    result = bll.Delete(id);
                }
                catch
                {
                    result = false;
                }
                string keywords = MyRequest.GetQueryString("keywords");
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true) 
                {
                    //JscriptMsg("删除成功！", Utils.CombUrlTxt("ManagerList.aspx", "fun_id={0}&keywords={1}&page={2}",
                    //    DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Success");
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("TopicList.aspx", "fun_id={0}&keywords={1}&page={2}",this.fun_id, keywords, page.ToString()), "Success");
                   // Response.Redirect("TopicList.aspx?fun_id=" + get_fun_id("CCOM/TopicManage/TopicList.aspx"));
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("TopicList.aspx", "fun_id={0}&keywords={1}&page={2}",DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Error");
            }
        }

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

            BLL.CCOM.Topic bll = new BLL.CCOM.Topic();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("TopicList.aspx", "fun_id={0}&keywords={2}&sort={3}&page={4}", this.fun_id, this.keywords, MyRequest.GetString("sort"), "__id__");
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
            Response.Redirect(Utils.CombUrlTxt("TopicList.aspx", "fun_id={0}&keywords={2}", this.fun_id.ToString(), this.txtKeywords.Value));
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
            Response.Redirect(Utils.CombUrlTxt("TopicList.aspx", "fun_id={0}&keywords={2}", this.fun_id, this.keywords));
        }

        public string GetTeacherName(string UserID)
        {
          
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            string str = string.Empty;
            try
            {
                Model.CCOM.User_information user_model = user_bll.GetModel(" User_id='" + UserID + "'");
                str = user_model.User_realname;
            }
            catch
            {
                str = "未设置";
            }
            return str;
        }

        public string GetTitle(string UserID)
        {
            BLL.CCOM.Tutor bll = new BLL.CCOM.Tutor();
            string str = string.Empty;
            try
            {
                Model.CCOM.Tutor model = bll.GetModel(" User_id='" + UserID + "'");
                str = new BLL.CCOM.Title().GetModel((int)model.Title_id).Title_name;
            }
            catch
            {
                str = "未设置";
            }
            return str;
        }

        public string GetState(string state)
        {
            if (state.Equals("0")) return "未审核";
            if (state.Equals("1")) return "已通过";
            return "未通过";
        }

    }
}