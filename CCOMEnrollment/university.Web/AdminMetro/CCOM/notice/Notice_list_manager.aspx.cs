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
    public partial class Notice_list_manager : university.UI.ManagePage
    {
        protected string keywords = string.Empty;
        private const int READ_STATUS = 1;
        private long ptId = 0;//图文通知下的类别
        private int NoticeType = 0;//区别图文通知或文字通知
        public Notice_list_manager()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.fun_id = get_fun_id("CCOM/notice/Notice_list_manager.aspx");
            //string _id = MyRequest.GetQueryString("notice_type_id");
            string _type=MyRequest.GetQueryString("notice_type");
            if(_type!=null&&_type.Length>0)
            {
                NoticeType = int.Parse(_type);
            }
            //if(_id!=null&&_id.Length>0)
            //{
            //    this.ptId = long.Parse(DESEncrypt.Decrypt(_id));
            //}
            this.keywords = MyRequest.GetQueryString("keywords");
            if(!IsPostBack)
            {
                RptBind(CombSqlTxt(this.ptId, this.keywords), " Notice_date DESC ");
            }
            if (NoticeType==1)
            {
                this.image_word_notice.CssClass = "btn btn-success";
                this.word_notice.CssClass = "btn";
                //BindPushType();
            }
            else
            {
                this.image_word_notice.CssClass = "btn";
                this.word_notice.CssClass = "btn btn-success";
            }
        }


        //绑定通知类别
        //private void BindPushType()
        //{
        //    var typeList = new BLL.CCOM.Notice_type().GetModelList("");
            
        //    if(typeList!=null&&typeList.Count>0)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        var className = "btn btn-success";
        //        var className1 = "btn";
        //        string noticeTypeId = MyRequest.GetQueryString("notice_type_id");
        //        if(noticeTypeId==null||noticeTypeId.Length==0)//若为传值则默认为未分类
        //        {
        //            sb.Append("<a href=\"Notice_list_manager.aspx?notice_type_id=" + DESEncrypt.Encrypt("0") + "&notice_type=" + this.NoticeType + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className + "'>");
        //            sb.Append("未分类</a>&nbsp;&nbsp;");
        //            for(int i=0;i<typeList.Count;i++)
        //            {
        //                sb.Append("<a href=\"Notice_list_manager.aspx?notice_type_id=" + DESEncrypt.Encrypt(typeList[i].Notice_type_id.ToString()) + "&notice_type=" + this.NoticeType + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className1 + "'>");
        //                sb.Append(typeList[i].Notice_type_name + "</a>&nbsp;&nbsp;"); 
        //            }
        //            this.NoticeTypeDiv.InnerHtml = sb.ToString();
        //        }
        //        else
        //        {
        //            try
        //            {
        //                long notice_type_id = long.Parse(DESEncrypt.Decrypt(noticeTypeId));
        //                if(notice_type_id==0)
        //                {
        //                    sb.Append("<a href=\"Notice_list_manager.aspx?notice_type_id=" + DESEncrypt.Encrypt("0") + "&notice_type=" + this.NoticeType + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className + "'>");
        //                    sb.Append("未分类</a>&nbsp;&nbsp;");
        //                    for (int i = 0; i < typeList.Count; i++)
        //                    {
        //                        sb.Append("<a href=\"Notice_list_manager.aspx?notice_type_id=" + DESEncrypt.Encrypt(typeList[i].Notice_type_id.ToString()) + "&notice_type=" + this.NoticeType + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className1 + "'>");
        //                        sb.Append(typeList[i].Notice_type_name + "</a>&nbsp;&nbsp;");
        //                    }
        //                }
        //                else
        //                {
        //                    sb.Append("<a href=\"Notice_list_manager.aspx?notice_type_id=" + DESEncrypt.Encrypt("0") + "&notice_type=" + this.NoticeType + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className1 + "'>");
        //                    sb.Append("未分类</a>&nbsp;&nbsp;");
        //                    for (int i = 0; i < typeList.Count; i++)
        //                    {
        //                        if(typeList[i].Notice_type_id==notice_type_id)
        //                        {
        //                            sb.Append("<a href=\"Notice_list_manager.aspx?notice_type_id=" + DESEncrypt.Encrypt(typeList[i].Notice_type_id.ToString())+"&notice_type="+this.NoticeType + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className + "'>");
        //                            sb.Append(typeList[i].Notice_type_name + "</a>&nbsp;&nbsp;"); 
        //                        }
        //                        else
        //                        {
        //                            sb.Append("<a href=\"Notice_list_manager.aspx?notice_type_id=" + DESEncrypt.Encrypt(typeList[i].Notice_type_id.ToString()) + "&notice_type=" + this.NoticeType + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className1 + "'>");
        //                            sb.Append(typeList[i].Notice_type_name + "</a>&nbsp;&nbsp;"); 
        //                        }
        //                    }
        //                }
        //                this.NoticeTypeDiv.InnerHtml = sb.ToString();
        //            }
        //            catch
        //            {

        //            }
        //        }
        //    }

        //}

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(10);  //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Text = keywords;

            var bll = new BLL.CCOM.Notice();

            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            var ds = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataSource = ds;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&keywords={1}&page={2}&notice_type_id={3}", DESEncrypt.Encrypt(this.fun_id), this.keywords, "__id__", DESEncrypt.Encrypt(this.ptId.ToString()));
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion
        //搜索
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&notice_type_id={1}&keywords={2}",
                DESEncrypt.Encrypt(this.fun_id), DESEncrypt.Encrypt(this.ptId.ToString()), this.txtKeywords.Text));
        }

        

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("PushNewsList_page_size", _pagesize.ToString(), 43200);
                }
            }

            Response.Redirect(Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&ptId={1}&keywords={2}",
                DESEncrypt.Encrypt(this.fun_id), this.ptId.ToString(), this.keywords));
        }

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("PushNewsList_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion
        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var bll = new BLL.CCOM.Notice();
            var result = true;
            int iCnt = 0;
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                long id = Convert.ToInt64(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    iCnt++;
                    try
                    {
                        var m = bll.GetModel(id);
                        if (IsSelfPush(m.Notice_sender_id.ToString()) == false)
                        {
                            JscriptMsg("您无权进行删除！", "", "Error");
                            return;
                        }
                        bll.Delete(id);
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }

            if (iCnt < 1)
            {
                JscriptMsg("请您选择需要删除的信息！", "", "Error");
                return;
            }
            string keywords = MyRequest.GetQueryString("keywords");
            int page = MyRequest.GetQueryInt("page", 1);
            if (result == true)
            {
                JscriptMsg("批量删除成功！", Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&ptId={1}&keywords={2}&page={3}",
                    DESEncrypt.Encrypt(this.fun_id), this.ptId.ToString(), keywords, page.ToString()), "Success");
            }
            else
            {
                JscriptMsg("批量删除失败！", Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&ptId={1}&keywords={2}&page={3}",
                    DESEncrypt.Encrypt(this.fun_id), this.ptId.ToString(), keywords, page.ToString()), "Error");
            }
        }


        //删除单条通知
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            var bll = new BLL.CCOM.Notice();
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var id = Int64.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool result = true;
                try
                {
                    var m = bll.GetModel(id);
                    if (IsSelfPush(m.Notice_sender_id.ToString()) == false)
                    {
                        JscriptMsg("您无权进行删除！", "", "Error");
                        return;
                    }
                    bll.Delete(id);
                   
                }
                catch
                {
                    result = false;
                }
                string keywords = MyRequest.GetQueryString("keywords");
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&ptId={1}&keywords={2}&page={3}",
                    DESEncrypt.Encrypt(this.fun_id), this.ptId.ToString(), keywords, page.ToString()), "Success");
                }
                else
                {
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&ptId={1}&keywords={2}&page={3}",
                    DESEncrypt.Encrypt(this.fun_id), this.ptId.ToString(), keywords, page.ToString()), "Error");
                }
            }
        }


        protected void btn_type_change(object sender, EventArgs e)
        {
            string type = this.notice_type.Value;
            if(type=="0")
            {
                Response.Redirect(Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&ptId={1}&keywords={2}&notice_type={3}",
                DESEncrypt.Encrypt(this.fun_id), this.ptId.ToString(), this.keywords,"0"));
            }
            else
            {
                Response.Redirect(Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&ptId={1}&keywords={2}&notice_type={3}",
                DESEncrypt.Encrypt(this.fun_id), this.ptId.ToString(), this.keywords,"1"));
            }
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(long ptId, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();

            strTemp.Append(" Notice_type=" + NoticeType);
            //根据类别筛选, -1表示未分类
            if (ptId != 0)
            {
                strTemp.Append(" and Notice_type_id= "+ptId);
            }
            strTemp.Append(" and Notice_flag=0");
            //根据关键词筛选
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and Notice_content like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        #region================为前端提供数据
        protected bool IsSelfPush(string sender_id)
        {
            return GetAdminInfo_CCOM().User_id == long.Parse(sender_id);
        }
        

        //显示图文通知部分内容
        protected String WrapPushContent(string id)
        {
            var content = "";
            int maxLength = 60;
            try
            {
                var model = new BLL.CCOM.Notice().GetModel(long.Parse(id));
                if ((bool)model.Notice_type)
                {
                    content = model.Notice_content;
                    maxLength = 30;
                }
                else
                {
                    content = model.Notice_content;
                }
            }
            catch
            {
            }

            if (content.Length > maxLength)
            {
                var shortContent = content.Substring(0, maxLength) + "...";

                var toolTip = "<a style=\"cursor:pointer;\" onmouseover=\"layer.tips('" + content + "', this, {";
                toolTip += "style: ['background-color:#e8e8e8; color:#000', '#e8e8e8'], maxWidth:385, time: 3,closeBtn:[0, true]});\">详细</a>";
                return shortContent + toolTip;
            }
            return content;
        }

        protected string GetDeleteText(string creator_id)
        {
            if (!IsSelfPush(creator_id))
            {
                return "<span style=\"text-decoration:line-through;\">删除</span>";
            }
            return "<span>删除</span>";
        }
        protected string GetMyScript(string creator_id)
        {
            if (IsSelfPush(creator_id))
            {
                return "return confirm('确定要删除该通知吗?');void(0);";
            }
            return "";
        }

        protected string GetLastEditorName(string last_editor_id)
        {
            if(!string.IsNullOrEmpty(last_editor_id))
            {
                var model = new BLL.CCOM.User_information().GetModel(long.Parse(last_editor_id));
                if(model!=null)
                {
                    return model.User_realname;
                }
            }
            return "--";
        }

        //获取通知类别名称
        protected string GetPushType(int Notice_id)
        {
            Model.CCOM.Notice model = new BLL.CCOM.Notice().GetModel(Notice_id);
            if(model.Notice_type_id!=null&&model.Notice_type_id>0)
            {
                return new BLL.CCOM.Notice_type().GetModel((long)model.Notice_type_id).Notice_type_name;
            }
            return "未分类";
        }
        #endregion
    }
}