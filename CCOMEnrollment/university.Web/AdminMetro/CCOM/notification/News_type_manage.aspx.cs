using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notification
{
    public partial class News_type_manage : university.UI.ManagePage
    {
        private string keywords = string.Empty;
        public News_type_manage()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.keywords = MyRequest.GetQueryString("keywords");
            if (!IsPostBack)
            {
                bindData();
            } 
        }

        private void bindData()
        {

            BLL.CCOM.News_type bll = new BLL.CCOM.News_type();
            string strWhere = string.Empty;
            int pageSize = GetPageSize(10); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            keywords = MyRequest.GetQueryString("keywords");
            
            if (keywords != null && keywords.Length > 0)
            {
                if (strWhere != "")
                {
                    strWhere = strWhere + " and News_type_name '%" + keywords + "%' ";
                }
                else
                {
                    strWhere = " News_type_name like '%" + keywords + "%' ";
                }
            }
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;

            //计算数量
            int totalCount = bll.GetRecordCount("");

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(strWhere, " News_type_date DESC ", start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            this.txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("News_type_manage.aspx", "keywords={0}&page={1}&fun_id={2}", keywords, "__id__", DESEncrypt.Encrypt(this.fun_id));
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.keywords = this.txtKeywords.Text.Trim().ToString();
            Response.Redirect(Utils.CombUrlTxt("News_type_manage.aspx", "keywords={0}&fun_id={1}", keywords, DESEncrypt.Encrypt(this.fun_id)));
        }
        //单个删除
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            var lbtn = sender as LinkButton;
            BLL.CCOM.News_type bll = new BLL.CCOM.News_type();
            BLL.CCOM.News news_bll = new BLL.CCOM.News();
            if(lbtn!=null)
            {
                bool result=false;
                int newsTypeId = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                if (newsTypeId > 0)
                {
                    Model.CCOM.News_type model = bll.GetModel(newsTypeId);
                    if (model.News_type_creator_id == GetAdminInfo_CCOM().User_id)
                    {
                        news_bll.Delete(" News_type_id=" + newsTypeId);
                        result = bll.Delete(newsTypeId);
                    }
                    int page = MyRequest.GetQueryInt("page", 1);
                    if(result)
                    {
                        JscriptMsg("删除成功！", Utils.CombUrlTxt("News_type_manage.aspx", "&keywords={0}&page={1}&fun_id={2}",
                     keywords, page.ToString(), DESEncrypt.Encrypt(this.fun_id)), "Success");
                    }
                }
            }
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.News_type bll = new BLL.CCOM.News_type();
            int count = 0;
            bool result = false;
            for (int i = 0; i < this.rptList.Items.Count; i++)
            {
                System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)rptList.Items[i].FindControl("chkId");
                if (!cb.Checked)
                {
                    continue;
                }
                else
                {
                    int newsTypeId = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                    if (newsTypeId > 0)
                    {
                        Model.CCOM.News_type model = bll.GetModel(newsTypeId);
                        if (model.News_type_creator_id == GetAdminInfo_CCOM().User_id)
                        {
                            result=bll.Delete(newsTypeId);
                        }
                        if (result)
                        {
                            count++;
                        }
                    }
                }
            }
            if (count < 1)
            {
                JscriptMsg("请您选择需要删除的资讯类别！", "", "Error");
                return;
            }
            string keywords = MyRequest.GetQueryString("keywords");
            int page = MyRequest.GetQueryInt("page", 1);
            if (result == true)
            {
                JscriptMsg("批量删除成功！", Utils.CombUrlTxt("News_type_manage.aspx", "&keywords={0}&page={1}&fun_id={2}",
                     keywords, page.ToString(), DESEncrypt.Encrypt(this.fun_id)), "Success");
            }
            else
            {
                JscriptMsg("批量删除失败！", Utils.CombUrlTxt("News_type_manage.aspx", "keywords={0}&page={1}&fun_id={2}",
                     keywords, page.ToString(), DESEncrypt.Encrypt(this.fun_id)), "Error");
            }
        }

        #region  设置分页数量====================
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("NewsTypeList_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("News_type_manage.aspx", "keywords={0}&fun_id={1}", this.keywords, DESEncrypt.Encrypt(this.fun_id)));
        }

        #endregion


        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("NewsTypeList_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion


        #region=================为前端提供数据
        protected bool IsSelfNews(string sender_id)
        {
            return GetAdminInfo_CCOM().User_id == long.Parse(sender_id);
        }
        protected string GetDeleteText(string creator_id)
        {
            if (!IsSelfNews(creator_id))
            {
                return "<span style=\"text-decoration:line-through;\">删除</span>";
            }
            return "<span>删除</span>";
        }
        protected string GetEditText(string creator_id)
        {
            if (!IsSelfNews(creator_id))
            {
                return "<span style=\"text-decoration:line-through;\">编辑</span>";
            }
            return "<span>编辑</span>";
        }
        protected string GetMyScript(string creator_id)
        {
            if (IsSelfNews(creator_id))
            {
                return "return confirm('确定要删除该资讯类别吗?若删除该类别则该类别下的所有资讯也将被删除!!!');void(0);";
            }
            return "";
        }
        protected string GetEditOnclick(string creator_id)
        {
            if(IsSelfNews(creator_id))
            {
                return "editNewsType(this)";
            }
            return "";
        }
        protected string GetCreatorName(long creator_id)
        {
            var model = new BLL.CCOM.User_information().GetModel(creator_id);
            if(model!=null)
            {
                return model.User_realname;
            }
            return "";
        }
        protected string GetTypeName()
        {
            string type = this.current_type_id.Value;
            if(!string.IsNullOrEmpty(type))
            {
                try
                {
                    return new BLL.CCOM.News_type().GetModel(int.Parse(DESEncrypt.Decrypt(type))).News_type_name;
                }
                catch
                {
                    return "";
                }
            }
            return "";
        }
        #endregion
    }
}