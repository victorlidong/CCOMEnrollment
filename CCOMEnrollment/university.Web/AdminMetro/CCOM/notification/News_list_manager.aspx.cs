//using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notification
{
    public partial class News_list_manager : university.UI.ManagePage
    {
        private string keywords = string.Empty;
        
        public News_list_manager()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            keywords = MyRequest.GetQueryString("keywords");
            //this.txtKeywords.Text = keywords;
            if(!IsPostBack)
            {
                bindNewsType();
                bindNewsData();
            } 
        }
        private void bindNewsType()
        {
            var news_type_list = new BLL.CCOM.News_type().GetModelList("");
            if (news_type_list != null && news_type_list.Count > 0)
            {
                
                StringBuilder sb = new StringBuilder();
                var className = "btn btn-success";
                var className1 = "btn";
                string newsTypeId=MyRequest.GetQueryString("news_type_id");
                if (newsTypeId == null || newsTypeId.Length==0)
                {
                    //添加全部一栏
                    sb.Append("<a href=\"News_list_manager.aspx?news_type_id=" + DESEncrypt.Encrypt("0") +"&fun_id="+DESEncrypt.Encrypt(this.fun_id)+ "\" class='" + className + "'>");
                    sb.Append("全部</a>&nbsp;&nbsp;");
                    for (int i = 0; i < news_type_list.Count; i++)
                    {
                        sb.Append("<a href=\"News_list_manager.aspx?news_type_id=" + DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString()) + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className1 + "'>");
                        sb.Append(news_type_list[i].News_type_name + "</a>&nbsp;&nbsp;"); 
                    }
                    this.NewsTypeDiv.InnerHtml = sb.ToString();
                }
                else
                {
                    int typeId = int.Parse(DESEncrypt.Decrypt(newsTypeId));
                    if(typeId==0)
                    {
                        sb.Append("<a href=\"News_list_manager.aspx?news_type_id=" + DESEncrypt.Encrypt("0") + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className + "'>");
                    }
                    else
                    {
                        sb.Append("<a href=\"News_list_manager.aspx?news_type_id=" + DESEncrypt.Encrypt("0") + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className1 + "'>");
                    }
                    
                    sb.Append("全部</a>&nbsp;&nbsp;");
                    for (int i = 0; i < news_type_list.Count; i++)
                    {
                        if(typeId==news_type_list[i].News_type_id)
                        {
                            sb.Append("<a href=\"News_list_manager.aspx?news_type_id=" + DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString()) + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className + "'>");
                        }
                        else
                        {
                            sb.Append("<a href=\"News_list_manager.aspx?news_type_id=" + DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString()) + "&fun_id=" + DESEncrypt.Encrypt(this.fun_id) + "\" class='" + className1 + "'>");
                        }
                        sb.Append(news_type_list[i].News_type_name + "</a>&nbsp;&nbsp;"); 
                    }
                    this.NewsTypeDiv.InnerHtml = sb.ToString();
                }
            }
        }

        /// <summary>
        /// 绑定资讯内容
        /// </summary>
        private void bindNewsData()
        {
            //更新置顶数据
            var bll = new BLL.CCOM.News();
            var list = bll.GetModelList("News_top=1");
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].News_date != null)
                {
                    DateTime date = Convert.ToDateTime(list[i].News_date);
                    if (list[i].News_top_time != null)
                    {
                        if (date.AddDays((double)list[i].News_top_time) < DateTime.Now)
                        {
                            var model = bll.GetModel(list[i].News_id);
                            model.News_top = false;
                            model.News_top_time = 0;
                            bll.Update(model);
                        }

                    }
                    else
                    {
                        //若为空，默认为3天
                        if (date.AddDays(3.0) < DateTime.Now)
                        {
                            var model = bll.GetModel(list[i].News_id);
                            model.News_top = false;
                            model.News_top_time = 0;
                            bll.Update(model);
                        }
                    }
                }
            }


            string strWhere = string.Empty;
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            keywords = MyRequest.GetQueryString("keywords");
            string news_type_id = MyRequest.GetQueryString("news_type_id");
            if(news_type_id!=null&&news_type_id.Length>0)
            {
                string news_type = DESEncrypt.Decrypt(news_type_id);
                if(news_type!="0")
                    strWhere += " News_type_id=" + news_type;
            }
            if (keywords != null && keywords.Length > 0)
            {
                if(strWhere!="")
                {
                    strWhere = strWhere + " and News_title like '%" + keywords + "%' ";
                }
                else
                {
                    strWhere = " News_title like '%" + keywords + "%' ";
                }
            }
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            
            
            //计算数量
            int totalCount = bll.GetRecordCount("");

            //绑定当页

            this.rptList.DataSource = bll.GetListByPage(strWhere, " News_date DESC ", start_index, end_index);
            this.rptList.DataBind();

            //for (int i = 0; i < rptList.Items.Count; i++)
            //{
            //    LinkButton lbt = (LinkButton)rptList.Items[i].FindControl("lbtDelete");
            //    HiddenField hide = (HiddenField)rptList.Items[i].FindControl("hideCreatorId");
            //    int CreatorId = int.Parse(hide.Value);
            //    if(CreatorId==GetAdminInfo_CCOM().User_id)
            //    {

            //    }
            //}
                //绑定页码
                this.txtPageNum.Text = pageSize.ToString();
                string pageUrl = Utils.CombUrlTxt("News_list_manager.aspx", "keywords={0}&page={1}&fun_id={2}", keywords, "__id__", DESEncrypt.Encrypt(this.fun_id));
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("NewsList_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.News bll = new BLL.CCOM.News();
            BLL.CCOM.News_attach bll1=new BLL.CCOM.News_attach();
            int count=0;
            bool result = false;
            for(int i=0;i<this.rptList.Items.Count;i++)
            {
                System.Web.UI.WebControls.CheckBox cb = (System.Web.UI.WebControls.CheckBox)rptList.Items[i].FindControl("chkId");
                if(!cb.Checked)
                {
                    continue;
                }
                else
                { 
                    int newsId = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                    if(newsId>0)
                    {
                        Model.CCOM.News model = bll.GetModel(newsId);
                        if(model.News_creator_id==GetAdminInfo_CCOM().User_id)
                        {
                            //删除附件
                            var list = bll1.GetModelList(" News_id=" + newsId);
                            if (list != null && list.Count > 0)
                            {
                                for (int j = 0; j < list.Count; j++)
                                {
                                    string path = list[j].News_attach_address;
                                    if (File.Exists(Server.MapPath(path)))
                                    {
                                        FileInfo fi = new FileInfo(path);
                                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                                        {
                                            fi.Attributes = FileAttributes.Normal;
                                        }
                                        File.Delete(Server.MapPath(path));
                                    }
                                    bll1.Delete(list[j].News_attach_id);
                                }
                            }

                            //删除静态页
                            String name = NewsHtml.GetWebNewsPath(newsId);
                            if (File.Exists(Server.MapPath(name)))
                            {
                                FileInfo fi = new FileInfo(name);
                                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                                {
                                    fi.Attributes = FileAttributes.Normal;
                                }
                                string path_name = Server.MapPath(name);
                                File.Delete(Server.MapPath(name));
                            }

                            //删除记录
                            result = bll.Delete(model.News_id);  
                        }
                        if(result)
                        {
                            count++;
                        }  
                    }
                }
            }
            if (count < 1)
            {
                JscriptMsg("请您选择需要删除的新闻！", "", "Error");
                return;
            }
            string keywords = MyRequest.GetQueryString("keywords");
            int page = MyRequest.GetQueryInt("page", 1);
            if (result == true)
            {
                JscriptMsg("批量删除成功！", Utils.CombUrlTxt("News_list_manager.aspx", "&keywords={0}&page={1}&fun_id={2}",
                     keywords, page.ToString(), DESEncrypt.Encrypt(this.fun_id)), "Success");
            }
            else
            {
                JscriptMsg("批量删除失败！", Utils.CombUrlTxt("News_list_manager.aspx", "keywords={0}&page={1}&fun_id={2}",
                     keywords, page.ToString(), DESEncrypt.Encrypt(this.fun_id)), "Error");
            }
        }


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            keywords = this.txtKeywords.Text.Trim().ToString();
            Response.Redirect(Utils.CombUrlTxt("News_list_manager.aspx", "keywords={0}&fun_id={1}", keywords, DESEncrypt.Encrypt(this.fun_id)));
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
                    Utils.WriteCookie("NewsList_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("News_list_manager.aspx", "keywords={0}&fun_id={1}", this.keywords, DESEncrypt.Encrypt(this.fun_id)));
        }

        #endregion



        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.News bll = new BLL.CCOM.News();
            BLL.CCOM.News_attach bll1 = new BLL.CCOM.News_attach();
            var lbtn = sender as LinkButton;
            if(lbtn!=null)
            {
                int news_id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                if(news_id>0)
                {
                    Model.CCOM.News model = bll.GetModel(news_id);
                    bool result = false;
                    if (model != null)
                    {
                        if(model.News_creator_id==GetAdminInfo_CCOM().User_id)
                        {
                             //删除附件
                            var list = bll1.GetModelList(" News_id=" + news_id);
                            if (list != null && list.Count > 0)
                            {
                                for (int j = 0; j < list.Count; j++)
                                {
                                    string path = list[j].News_attach_address;
                                    if (File.Exists(Server.MapPath(path)))
                                    {
                                        FileInfo fi = new FileInfo(path);
                                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                                        {
                                            fi.Attributes = FileAttributes.Normal;
                                        }
                                        File.Delete(Server.MapPath(path));
                                    }
                                    bll1.Delete(list[j].News_attach_id);
                                }
                            }

                            //删除静态页
                            String name = NewsHtml.GetWebNewsPath(news_id);
                            if (File.Exists(Server.MapPath(name)))
                            {
                                FileInfo fi = new FileInfo(name);
                                if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                                {
                                    fi.Attributes = FileAttributes.Normal;
                                }
                                string path_name = Server.MapPath(name);
                                File.Delete(Server.MapPath(name));
                            }
                           result= bll.Delete(model.News_id);
                        }
                    }
                    string keywords = MyRequest.GetQueryString("keywords");
                    int page = MyRequest.GetQueryInt("page", 1);
                    if(result==true)
                    {
                        JscriptMsg("删除成功！", Utils.CombUrlTxt("News_list_manager.aspx", "&keywords={0}&page={1}&fun_id={2}",
                             keywords, page.ToString(), get_fun_id("CCOM/notification/News_list_manager.aspx")), "Success");
                    }
                    else
                    {
                        JscriptMsg("删除失败！", Utils.CombUrlTxt("News_list_manager.aspx", "keywords={0}&page={1}&fun_id={2}",
                             keywords, page.ToString(), get_fun_id("CCOM/notification/News_list_manager.aspx")), "Error");
                    }
                        
                } 
            }
        }
        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         protected void lbtTop_Click(object sender, EventArgs e)
        {
            var bll = new BLL.CCOM.News();
            var lbtn = sender as LinkButton;
            if(lbtn!=null)
            {
                int news_id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool isTop = false;
                bool result = true;
                try
                {
                    var model = bll.GetModel(news_id);
                    if(model.News_top!=null&&!(bool)model.News_top)
                    {
                        isTop = false;
                        model.News_top = true;
                        DateTime date =Convert.ToDateTime(model.News_date);
                        TimeSpan time_span = DateTime.Now - date;
                        int day = time_span.Days;
                        model.News_top_time = day+3;
                        bll.Update(model);
                    }
                    else
                    {
                        isTop = true;
                        model.News_top = false;
                        model.News_top_time = 0;
                        bll.Update(model);
                    }
                    result = true;
                }
                catch
                {
                    result = false;
                }
                //string keywords = MyRequest.GetQueryString("keywords");
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    JscriptMsg(isTop ? "取消置顶成功！" : "置顶成功！", Utils.CombUrlTxt("News_list_manager.aspx", "keywords={0}&page={1}&fun_id={2}",
                        keywords, page.ToString(), DESEncrypt.Encrypt(this.fun_id)), "Success");
                }
                else
                {
                    JscriptMsg(isTop ? "取消置顶失败！" : "置顶失败！", Utils.CombUrlTxt("News_list_manager.aspx", "keywords={0}&page={1}&fun_id={2}",
                        keywords, page.ToString(), DESEncrypt.Encrypt(this.fun_id)), "Error");
                }
                    
            }
        }


         #region===========================为前端提供数据
         protected bool IsSelfNews(String userId)
        {
            if (GetAdminInfo_CCOM().User_id.ToString() == userId)
                return true;
            return false;
        }


        protected string GetNewsType(string newsTypeId)
        {
            int id = int.Parse(newsTypeId);
            var model = new BLL.CCOM.News_type().GetModel(id);
            if(model==null)
            {
                return "未分类";
            }
            return model.News_type_name;
        }
        protected string GetLastEditor(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return "---";
            return new BLL.CCOM.User_information().GetModel(long.Parse(userId)).User_realname;
        }
        protected int GetNewsAttachNum(string newsId)
        {
            var list = new BLL.CCOM.News_attach().GetModelList(" News_id=" + newsId);
            if(list!=null)
                return list.Count;
            return 0;
        }
        protected string GetRealName(string userId)
        {
            return new BLL.CCOM.User_information().GetModel(long.Parse(userId)).User_realname;
        }

        protected String GetTopText(string isTop)
        {
            if (isTop=="True")
            {
                return "<i class='icon-arrow-down'></i>取消置顶";
            }
            return "<i class='icon-arrow-up'></i>置顶";
        }
        protected string GetDeleteText(string creator_id)
        {
            if (!IsSelfNews(creator_id))
            {
                return "<span style=\"text-decoration:line-through;\">删除</span>";
            }
            return "<span>删除</span>";
        }
        protected string GetMyScript(string creator_id)
        {
            if (IsSelfNews(creator_id))
            {
                return "return confirm('确定要删除该资讯吗?');void(0);";
            }
            return "";
        }
        protected bool chechUser(string user_id)
        {
            if(int.Parse(user_id)==GetAdminInfo_CCOM().User_id)
            {
                return true;
            }
            return false;
        }

        //protected string GetDeleteInfo(string _creator_id)
        //{
        //    int creatorId=int.Parse(_creator_id);
        //    if(creatorId>0)
        //    {
        //        string str = "";
        //    }
        //    return "";
        //}
        #endregion
    }
}