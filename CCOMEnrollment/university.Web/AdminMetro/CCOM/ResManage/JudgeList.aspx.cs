using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ResManage
{
    public partial class JudgeList : university.UI.ManagePage
    {
        protected string keywordTab0 = string.Empty;
        protected string keywordTab1 = string.Empty;
        public JudgeList()
        {
            //this.checkFunID = true;

            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            String keywords = MyRequest.GetQueryString("keywords");
            if (!Page.IsPostBack)
            {
                this.keywordTab0 = keywords;
                RptBind(CombSqlTxt(keywords), " Judge_id desc ");
            }
        }

        //tab1===================
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

            var bll = new BLL.CCOM.Judge();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("JudgeList.aspx", "fun_id={0}&keywords={1}&page={2}", DESEncrypt.Encrypt(this.fun_id), keywords, "__id__");
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
                strTemp.Append(" Judge_name like '%" + _keywords + "%' ");
                strTemp.Append(" or Judge_staff_number like '%" + _keywords + "%' ");
                strTemp.Append(" or Judge_department like '%" + _keywords + "%' ");
                strTemp.Append(" or Judge_title like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("JudgeList_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("JudgeList.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("JudgeList_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("JudgeList.aspx", "fun_id={0}&keywords={1}", DESEncrypt.Encrypt(this.fun_id), this.keywordTab0));
        }

        //删除
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Judge bll = new BLL.CCOM.Judge();
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
                string keywords = this.keywordTab0;
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("JudgeList.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Success");
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("JudgeList.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Error");
            }
        }

        //获取评委姓名
        protected String GetJudgeName(int id)
        {
            return new BLL.CCOM.Judge().GetModel(" Judge_id=" + id).Judge_name;
        }

        //获取评委教工号
        protected String GetJudgeStaffNumber(int id)
        {
            return new BLL.CCOM.Judge().GetModel(" Judge_id=" + id).Judge_staff_number;
        }

        //获取评委部门
        protected String GetJudgeDepartment(int id)
        {
            return new BLL.CCOM.Judge().GetModel(" Judge_id=" + id).Judge_department;
        }

        //获取评委职称
        protected String GetJudgeTitle(int id)
        {
            return new BLL.CCOM.Judge().GetModel(" Judge_id=" + id).Judge_title;
        }

        protected String GetEditLink(String enc_Id)
        {
            String link = "<a href=\"JudgeAdd.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "&action="+MyEnums.ActionEnum.Edit.ToString() +"&id=" +
                          enc_Id + "\">编辑</a>";
            return link;
        }
    }
}