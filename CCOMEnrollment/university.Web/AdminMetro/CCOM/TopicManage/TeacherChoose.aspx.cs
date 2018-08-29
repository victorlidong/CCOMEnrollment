﻿using System;
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
    public partial class TeacherChoose : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string keywords = MyRequest.GetQueryString("keywords");

        public TeacherChoose()
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
                //判断是不是管理员登录
                //Model.CCOM.User_information model = GetAdminInfo_CCOM();
                //if (model.User_type != 6)
                //    InnerRedirect(MyEnums.RediirectErrorEnum.NotAdmin);

                BindRpt();

            }
        }

        protected void BindRpt()
        {
            
            string _order = MyRequest.GetString("sort").Replace(",", " ");
            if (_order == "" || Tools.CheckParams(_order)) _order = " Topic_id asc";
            RptBind( CombSqlTxt(this.keywords), _order);
        }
        
        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {

            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            strTemp.Append(" Check_state=1 ");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" Topic_name like '%" + _keywords + "%' ");
                //strTemp.Append(" or User_number like '%" + _keywords + "%' ");
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

            BLL.CCOM.Topic bll = new BLL.CCOM.Topic();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("TeacherChoose.aspx", "fun_id={0}&keywords={1}&sort={2}&page={3}", this.fun_id, this.keywords, MyRequest.GetString("sort"), "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);

            //绑定我的选题
            BLL.CCOM.View_Selete_Topic selete_bll = new BLL.CCOM.View_Selete_Topic();
            this.rptList2.DataSource = selete_bll.GetList(" Teacher_id =" + GetAdminInfo_CCOM().User_id);
           // this.rptList2.DataSource = selete_bll.GetListByPage(_strWhere + "and Teacher_id =" + GetAdminInfo_CCOM().User_id, _order, start_index, end_index);
            this.rptList2.DataBind();
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
            Response.Redirect(Utils.CombUrlTxt("TeacherChoose.aspx", "fun_id={0}&keywords={2}", this.fun_id.ToString(), this.txtKeywords.Value));
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
            Response.Redirect(Utils.CombUrlTxt("TeacherChoose.aspx", "fun_id={0}&keywords={2}", this.fun_id, this.keywords));
        }

        public string GetTeacherName(string UserID)
        {
            BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
            string str = string.Empty;
            try
            {
                Model.CCOM.User_information model = bll.GetModel(" User_id='" + UserID + "'");
                str = model.User_realname;
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

        public string GetAcceptState(string state, string TrID)
        {
            if (state.Equals("0"))
                //return "未审核";
                return "&nbsp;<a href=\"javascript:void(0);\" onclick='AcceptCheck(" + TrID + ")'>审核";
            if (state.Equals("1")) return "已接收";
            return "已拒绝";
        }

    }
}