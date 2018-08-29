using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.RoleManage
{
    public partial class RoleList : university.UI.ManagePage
    {
        protected string keywords = string.Empty;
        public RoleList()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MyRequest.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                RptBind(CombSqlTxt(this.keywords), " Role_id desc ");
                TriBind();
            }
        }

        //tab1
        #region 数据绑定=================================

        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Text = keywords;

            var bll = new BLL.CCOM.Role();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("RoleList.aspx", "fun_id={0}&keywords={1}&page={2}", DESEncrypt.Encrypt(this.fun_id), this.keywords, "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }

        protected void TriBind()
        {
            for (int i = 0; i < this.rptList.Items.Count; i++)
            {
                ScriptManager scriptMan = ScriptManager.GetCurrent(this);
                LinkButton btn = this.rptList.Items[i].FindControl("lbtAble") as LinkButton;
                if (btn != null)
                {
                    btn.Click += lbtAble_Click;
                    scriptMan.RegisterAsyncPostBackControl(btn);
                    AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                    trigger.ControlID = btn.UniqueID;
                    trigger.EventName = "Click";
                    this.UpdatePanel1.Triggers.Add(trigger);
                }
            }
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" Role_id>0");
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Role_name like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("Role_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("RoleList.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("Role_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("RoleList.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.keywords));
        }

        protected void lbtAble_Click(object sender, EventArgs e)
        {
            var bll = new BLL.CCOM.Role();

            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var id = Int64.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool isOn = false;
                bool result = true;
                try
                {
                    var m = bll.GetModel("Role_id=" + id);
                    isOn = m.Role_status == true;
                    m.Role_status = isOn ^ true;
                    if (bll.Update(m) == false)
                        result = false;
                }
                catch
                {
                    result = false;
                }
                string keywords = MyRequest.GetQueryString("keywords");
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    JscriptMsg(isOn ? "禁用成功！" : "启用成功！", Utils.CombUrlTxt("RoleList.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Success");
                }
                else
                    JscriptMsg(isOn ? "禁用失败！" : "启用失败！", Utils.CombUrlTxt("RoleList.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Error");
                RptBind(CombSqlTxt(this.keywords), " Role_id desc ");
            }
        }

        protected String GetStatusText(Boolean isOn)
        {
            if (isOn == true)
            {
                return "<i class='icon-arrow-down'></i>禁用";
            }
            return "<i class='icon-arrow-up'></i>启用";
        }
    }
}