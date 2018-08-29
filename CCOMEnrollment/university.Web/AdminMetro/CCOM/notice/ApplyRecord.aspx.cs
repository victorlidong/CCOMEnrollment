using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
namespace university.Web.AdminMetro.CCOM.notice
{
    public partial class ApplyRecord : university.UI.ManagePage
    {
        protected string keywords = string.Empty;
        public ApplyRecord()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fun_id = MyRequest.GetQueryString("fun_id");
            this.keywords = MyRequest.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                RptBind(CombSqlTxt(this.keywords), " SMS_apply_time desc");
                SmsHelper.ShowSmsLeftNumberNoApply(this.lblSms, GetAdminInfo_CCOM().User_id);
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Text = keywords;

            var bll = new BLL.CCOM.SMS_apply_record();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("ApplyRecord.aspx", "fun_id={0}&keywords={1}&page={2}", this.fun_id, this.keywords, "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("ApplyRecord.aspx", "fun_id={0}&keywords={1}", this.fun_id.ToString(), txtKeywords.Text));
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append("  User_id=" + GetAdminInfo_CCOM().User_id);
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and SMS_apply_reason like '%" + _keywords + "%'");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("ApplyRecord_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("ApplyRecord_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ApplyRecord.aspx", "fun_id={0}&keywords={1}", this.fun_id, this.keywords));
        }


        #region==============为前端提供数据
        protected String GetWrapReason(int type, String reason)
        {
            if (type == SmsConfig.Type_FirstApply || type == SmsConfig.Type_LoginApply)
                return "--";
            return reason;
        }
        

        protected string GetGiveNumber(int status, String number)
        {
            if (status != SmsConfig.Status_Success)
                return "--";
            return number;
        }
        #endregion
    }
}