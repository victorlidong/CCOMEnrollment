using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ConfExamInfor
{
    public partial class ConfMajor : university.UI.ManagePage
    {
        protected string keywordTab0 = string.Empty;
        protected string keywordTab1 = string.Empty;
        private static long _id = 0;
        public ConfMajor()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.CCOM.User_infomation model = GetAdminInfo_CCOM();
            _id = model.User_id;

            String keywords = MyRequest.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                this.keywordTab0 = keywords;
                RptBind(CombSqlTxt(keywords), " Agency_id desc ");
            }
        }

        #region 更新操作=================================

        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConfManager.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id.ToString()));
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            //string keywords = MyRequest.GetQueryString("keywords");
            string keywords = this.keywordTab0;
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Text = keywords;

            var bll = new BLL.CCOM.Agency();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("MajorList.aspx", "fun_id={0}&keywords={1}&page={2}", DESEncrypt.Encrypt(this.fun_id), keywords, "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" Agency_name like '%" + _keywords + "%' and Agency_type = 3");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("MajorList_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("MajorList.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("MajorList_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("MajorList.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.keywordTab0));
        }

        //获取学制
        protected string GetAcademic(int id) {
            try
            {
                Model.CCOM.Major model = new BLL.CCOM.Major().GetModel(" Agency_id=" + id);
                return model.Major_academic;
            }
            catch {
                return "--";
            }
        }

        //获取报考要求
        protected string GetRequire(int id) {
            try
            {
                Model.CCOM.Major model = new BLL.CCOM.Major().GetModel(" Agency_id=" + id);
                return model.Major_require;
            }
            catch
            {
                return "--";
            }
        }

        //获取参考书
        protected string GetReference(int id) {
            try
            {
                Model.CCOM.Major model = new BLL.CCOM.Major().GetModel(" Agency_id=" + id);
                return model.Major_reference;
            }
            catch
            {
                return "--";
            }
        }

        //获取备注
        protected string GetRemark(int id) {
            try
            {
                Model.CCOM.Major model = new BLL.CCOM.Major().GetModel(" Agency_id=" + id);
                return model.Major_remark;
            }
            catch
            {
                return "--";
            }
        }

    }
}