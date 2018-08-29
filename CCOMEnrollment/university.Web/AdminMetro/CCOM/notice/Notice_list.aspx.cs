using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notice
{
    public partial class Notice_list : university.UI.ManagePage
    {
        protected string keywords = string.Empty;
        private int type = 0;
        public Notice_list()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.fun_id = get_fun_id("CCOM/notice/Notice_list.aspx");
            this.keywords = Server.UrlDecode(MyRequest.GetQueryString("keywords"));
            string t= MyRequest.GetQueryString("type");
            if(t!=null&&t.Length>0)
            {
                try
                {
                    this.type = int.Parse(DESEncrypt.Decrypt(t));
                }
                catch
                {
                    this.type = 0;
                }
            }
            //if (!Page.IsPostBack)
            {
                RptBind();
            }
        }

        //返回用户每页数量
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("notice_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.keywords = this.txtKeywords.Value.Trim();
            Response.Redirect(Utils.CombUrlTxt("Notice_list.aspx", "keywords={0}&fun_id={1}&type={2}", this.keywords, DESEncrypt.Encrypt(this.fun_id),DESEncrypt.Encrypt(this.type.ToString())));
        }
        #region 数据绑定=================================
        private void RptBind()
        {
            int pageSize = 10; //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = this.keywords;//MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Value = keywords;
            StringBuilder ulSb = new StringBuilder();
            //获取该用户的所有未读通知Id
            BLL.CCOM.User_notice bll = new BLL.CCOM.User_notice();
            Model.CCOM.User_notice model = bll.GetModel(" User_id="+GetAdminInfo_CCOM().User_id);
            if(model!=null)
            {
                string all_news_id = string.Empty;
                if(type==0)
                {
                    all_news_id = model.Notice_id;
                    this.no_read.Style.Value = "background-color:#a5d16c";
                    this.read.Style.Value = "background-color:lightgrey";
                }
                else
                {
                    all_news_id = model.Notice_read_id;
                    this.read.Style.Value = "background-color:#a5d16c";
                    this.no_read.Style.Value = "background-color:lightgrey";
                }
                if (all_news_id.Length > 0)
                {
                    string[] ids = all_news_id.Split(',');
                    string strWhere = string.Empty;
                    if (keywords != null && keywords.Length>0)
                    {
                        strWhere += "  Notice_content like '%" + keywords + "%' ";
                    }
                    else
                    {
                        strWhere += " 1=1";
                    }
                    if (ids.Length > 0)
                    {
                        for (int i = 0; i < ids.Length; i++)
                        {
                            if (i == 0)
                            {
                                strWhere += "  and ( Notice_id=" + ids[i];
                            }
                            else
                            {
                                strWhere += " or Notice_id=" + ids[i];
                            }
                        }
                        strWhere += " )";
                        //获取通知信息
                        BLL.CCOM.Notice bll_notice = new BLL.CCOM.Notice();
                        int totalCount = bll_notice.GetRecordCount(strWhere);//计算数量
                        DataTable dt = bll_notice.GetListByPage(strWhere, "Notice_date DESC", start_index, end_index).Tables[0];//绑定当页
                        long userId = GetAdminInfo_CCOM().User_id;
                        if (dt.Rows.Count > 0)
                        {
                            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
                            string realname = string.Empty;
                            foreach (DataRow dr in dt.Rows)
                            {
                                var content = "";
                                content = "<a href=\"ViewNotice.aspx?id=" + DESEncrypt.Encrypt(dr["Notice_id"].ToString()) + "\" target=\"_blank\">";
                                content += dr["Notice_title"] + "</a>";
                                content += "<br />";
                                content += dr["Notice_content"];
                                try
                                {
                                    realname = user_bll.GetModel(Convert.ToInt32(dr["Notice_sender_id"])).User_realname;
                                }
                                catch
                                {
                                    realname = "---";
                                }
                                ulSb.Append("<li>");
                                ulSb.Append("<div class=\"media\">");
                                ulSb.Append("<span class=\"label pull-left label-success\"><i class=\"icon-bell\"></i></span>");
                                ulSb.Append("<div class=\"media-body\">");
                                ulSb.Append("<div class=\"notice-collapse\" style=\"padding: 5px;\">");
                                ulSb.Append("<div class=\"text\" style=\"padding: 2px 4px; text-decoration: none;\">");
                                ulSb.Append(" <p style=\"font-weight:bold;\">" + content + "</p>");
                                ulSb.Append(" <p class=\"attribution\">" + realname + "&nbsp;&nbsp;" + ((DateTime)dr["Notice_date"]).ToString("yyyy-MM-dd HH:mm") + "</p>");
                                ulSb.Append("</div>");
                                ulSb.Append("</div>");
                                ulSb.Append("</div>");
                                ulSb.Append("</div>");
                                ulSb.Append("</li>");
                            }
                            //this.page_size.Style.Add("display", "");
                        }
                        else
                        {
                            //this.page_size.Style.Add("display", "none");
                            ulSb.Append("<li style=\"height:40px;font-size:18px;text-align:center;padding-top:21px;\">暂无通知消息！</li>");
                        }
                        //绑定页码
                        
                        string pageUrl = Utils.CombUrlTxt("Notice_list.aspx", "keywords={0}&page={1}&fun_id={2}&type={3}", this.keywords, "__id__", DESEncrypt.Encrypt(this.fun_id),DESEncrypt.Encrypt(this.type.ToString()));
                        this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
                    }
                }
                else
                {
                    ulSb.Append("<li style=\"height:40px;font-size:18px;text-align:center;padding-top:21px;\">暂无通知消息！</li>");
                    //this.page_size.Style.Add("display", "none");
                }
            }
            else//为空则创建该用户
            {
                Model.CCOM.User_notice user_notice_model = new Model.CCOM.User_notice();
                user_notice_model.User_id = GetAdminInfo_CCOM().User_id;
                bll.Add(user_notice_model);
            }
            this.noticeList.InnerHtml = ulSb.ToString();
            
           
        }
        #endregion

        protected string GetRealname(string userId)
        {
            return new BLL.CCOM.User_information().GetModel(long.Parse(userId)).User_realname;
        }
    }
}