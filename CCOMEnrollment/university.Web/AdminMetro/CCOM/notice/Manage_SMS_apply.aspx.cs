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
    public partial class Manage_SMS_apply : university.UI.ManagePage
    {
        protected string keywords = string.Empty;
        private string type = string.Empty;
        private int check_type = -1;
        public Manage_SMS_apply()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fun_id = MyRequest.GetQueryString("fun_id");
            this.keywords = MyRequest.GetQueryString("keywords");
            type = MyRequest.GetQueryString("check_type");
            if (!string.IsNullOrEmpty(type))
            {
                try
                {
                    check_type = int.Parse(DESEncrypt.Decrypt(type));
                }
                catch
                {
                    check_type = -1;
                }
            }
            if (!Page.IsPostBack)
            {
                TypeBind();
                RptBind(CombSqlTxt(this.keywords), " SMS_apply_time desc");
                //SmsHelper.ShowSmsLeftNumberNoApply(this.lblSms, GetAdminInfo_CCOM().User_id);
            }
        }

        private void TypeBind()
        {
            StringBuilder sb = new StringBuilder();
            
            if(check_type==-1||check_type==0)//默认为未审批
            {
                sb.Append("<div class=\"span6\" style=\"width:90px;\">");
                sb.Append("<a href=\"/AdminMetro/CCOM/notice/Manage_SMS_apply.aspx?check_type=" + DESEncrypt.Encrypt("0") + "&fun_id=" + this.fun_id + "\" class=\"btn btn-success\">未审批</a>");
                sb.Append("</div>");
                sb.Append("<div class=\"span6\" style=\"width:90px;\">");
                sb.Append("<a href=\"/AdminMetro/CCOM/notice/Manage_SMS_apply.aspx?check_type=" + DESEncrypt.Encrypt("1") + "&fun_id=" + this.fun_id + "\" class=\"btn\">已审批</a>");
                sb.Append("</div>");
                this.none_check.Style["display"] = "block";
                this.had_check.Style["display"] = "none";
            }
            else
            {
                sb.Append("<div class=\"span6\" style=\"width:90px;\">");
                sb.Append("<a href=\"/AdminMetro/CCOM/notice/Manage_SMS_apply.aspx?check_type=" + DESEncrypt.Encrypt("0") + "&fun_id=" + this.fun_id + "\" class=\"btn\">未审批</a>");
                sb.Append("</div>");
                sb.Append("<div class=\"span6\" style=\"width:90px;\">");
                sb.Append("<a href=\"/AdminMetro/CCOM/notice/Manage_SMS_apply.aspx?check_type=" + DESEncrypt.Encrypt("1") + "&fun_id=" + this.fun_id + "\" class=\"btn btn-success\">已审批</a>");
                sb.Append("</div>");
                this.none_check.Style["display"] = "none";
                this.had_check.Style["display"] = "block";
            }
            this.CheckType.InnerHtml = sb.ToString();
            
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
            if (check_type == 0 || check_type==-1)
            {
                this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
                this.rptList.DataBind();
            }
            else
            {
                this.Repeater1.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
                this.Repeater1.DataBind();
            }

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            
            string pageUrl = Utils.CombUrlTxt("Manage_SMS_apply.aspx", "fun_id={0}&keywords={1}&page={2}",this.fun_id, this.keywords, "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (check_type == 0||check_type==-1)
            {
                strTemp.Append(" SMS_apply_status=1 ");

            }
            else
            {
                strTemp.Append(" SMS_apply_status=0 or SMS_apply_status=2 ");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                if (strTemp.ToString().Length>0)
                {
                    strTemp.Append(" and SMS_apply_reason like '%" + _keywords + "%'");
                }
                else
                {
                    strTemp.Append(" SMS_apply_reason like '%" + _keywords + "%'");
                }
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("CheckApplyRecord_page_size"), out _pagesize))
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
                    Utils.WriteCookie("CheckApplyRecord_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("Manage_SMS_apply.aspx", "fun_id={0}&keywords={1}", this.fun_id, this.keywords));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("Manage_SMS_apply.aspx", "fun_id={0}&keywords={1}", this.fun_id.ToString(), txtKeywords.Text));
        }
        
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            var bll = new BLL.CCOM.SMS_apply_record();
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var SMS_apply_id = Int64.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool result = true;
                try
                {
                    result=bll.Delete(SMS_apply_id);
                }
                catch
                {
                    result = false;
                }
                //string keywords = MyRequest.GetQueryString("keywords");
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("Manage_SMS_apply.aspx", "fun_id={0}&keywords={1}&page={2}",
                    this.fun_id,  this.keywords, page.ToString()), "Success");
                }
                else
                {
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("Manage_SMS_apply.aspx", "fun_id={0}&keywords={1}&page={2}",
                    this.fun_id,  this.keywords, page.ToString()), "Error");
                }
            }
        }

        #region==============为前端提供数据
        protected String GetWrapReason(int type, String reason)
        {
            if (type == SmsConfig.Type_FirstApply || type == SmsConfig.Type_LoginApply||string.IsNullOrEmpty(reason))
                return "--";
            return reason;
        }


        protected string GetGiveNumber(int status, String number)
        {
            if (status != SmsConfig.Status_Success)
                return "--";
            return number;
        }

        protected string GetRealname(string user_id)
        {
            return new BLL.CCOM.User_information().GetModel(" User_id=" +user_id).User_realname;
        }

        protected string GetApplyNumber()
        {
            if(this.hidId.Value!="0")
            {
                long hidId = long.Parse(DESEncrypt.Decrypt(this.hidId.Value));
                return new BLL.CCOM.SMS_apply_record().GetModel(hidId).SMS_apply_number.ToString();
            }
            
            return "";
        }
        #endregion
    }
}