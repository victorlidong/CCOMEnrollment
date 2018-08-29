using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notification
{
    public partial class ReleaseOrEditNews :  university.UI.ManagePage
    {
        protected int newsId = 0;
        private string action;
        public ReleaseOrEditNews()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            action = MyEnums.ActionEnum.Add.ToString(); //默认为添加操作类型
            if (!checkParam())
            {
                return;
            }
            
            if(!IsPostBack)
            {
                InitialNewsType();
                if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.newsId);
                    this.btnSubmit.Text = "保存";
                }
                else
                {
                    this.txtReleaseTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm");
                } 
            }
        }


        /// <summary>
        /// 检查URL参数
        /// </summary>
        /// <returns></returns>
        private bool checkParam()
        {
            string _action = MyRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == MyEnums.ActionEnum.Edit.ToString())//编辑
            {
                this.action = MyEnums.ActionEnum.Edit.ToString();//修改类型
                string news_id = MyRequest.GetQueryString("id");
                if (news_id != null && news_id.Length > 0)
                {
                    string id = DESEncrypt.Decrypt(news_id);
                    if (id != null && id.Length > 0)
                    {
                        this.newsId = int.Parse(id);
                    }
                    else
                    {
                        JscriptMsg("传输参数不正确！", "back", "Error");
                        return false;
                    }
                }
                else
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return false;
                }
                if (this.newsId <= 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return false;
                }
                if (!new BLL.CCOM.News().Exists(this.newsId))
                {
                    JscriptMsg("资讯不存在或已被删除！", "back", "Error");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 初始化资讯类别
        /// </summary>
        private void InitialNewsType()
        {
            var news_type_list = new BLL.CCOM.News_type().GetModelList("");
            StringBuilder sb = new StringBuilder();
            if (news_type_list != null && news_type_list.Count > 0)
            {
                string news_id = MyRequest.GetQueryString("id");
                var className = "btn btn-success";
                var className1 = "btn";
                if (news_id != null && news_id.Length>0)//编辑
                {
                    Model.CCOM.News model = new BLL.CCOM.News().GetModel(int.Parse(DESEncrypt.Decrypt(news_id)));
                    if(model!=null)
                    {
                        int news_type_id = model.News_type_id;
                        if (news_type_id!=0)
                        {
                            sb.Append("<a href=\"javascript:;\" class='btn' onclick='newsTypeTabs(\"" + DESEncrypt.Encrypt("0") + "\",this)'>未分类</a>&nbsp;&nbsp;");
                            for (int i = 0; i < news_type_list.Count; i++)
                            {
                                if (news_type_list[i].News_type_id == news_type_id)
                                {
                                    sb.Append("<a href=\"javascript:;\" class='" + className +
                                                 "' onclick='newsTypeTabs(\"" +
                                                 DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString()) + "\",this)'>");
                                    this.hidNewsType.Value = DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString());
                                }
                                else
                                {
                                    sb.Append("<a href=\"javascript:;\" class='" + className1 +
                                                 "' onclick='newsTypeTabs(\"" +
                                                 DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString()) + "\",this)'>");
                                }
                                sb.Append(news_type_list[i].News_type_name + "</a>&nbsp;&nbsp;");
                            }
                        }
                        else
                        {
                            this.hidNewsType.Value = DESEncrypt.Encrypt("0");
                            sb.Append("<a href=\"javascript:;\" class='btn btn-success' onclick='newsTypeTabs(\"" + DESEncrypt.Encrypt("0") + "\",this)'>未分类</a>&nbsp;&nbsp;");
                            for (int i = 0; i < news_type_list.Count; i++)
                            {
                                sb.Append("<a href=\"javascript:;\" class='" + className1 +
                                                "' onclick='newsTypeTabs(\"" +
                                                DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString()) + "\",this)'>");
                                sb.Append(news_type_list[i].News_type_name + "</a>&nbsp;&nbsp;");
                            }
                        }
                    }
                }
                else//发布
                {
                    this.hidNewsType.Value = DESEncrypt.Encrypt("0");
                    sb.Append("<a href=\"javascript:;\" class='btn btn-success' onclick='newsTypeTabs(\"" + DESEncrypt.Encrypt("0") + "\",this)'>未分类</a>&nbsp;&nbsp;");
                    for (int i = 0; i < news_type_list.Count; i++)
                    {
                        sb.Append("<a href=\"javascript:;\" class='" + className1 +
                                        "' onclick='newsTypeTabs(\"" +
                                        DESEncrypt.Encrypt(news_type_list[i].News_type_id.ToString()) + "\",this)'>");
                        sb.Append(news_type_list[i].News_type_name + "</a>&nbsp;&nbsp;");
                    }
                }
            }
            else
            {
                sb.Append("<a href=\"javascript:;\" class='btn btn-success' onclick='newsTypeTabs(\"" + DESEncrypt.Encrypt("0") + "\",this)'>未分类</a>&nbsp;&nbsp;");
                this.hidNewsType.Value = DESEncrypt.Encrypt("0");
            }
            sb.Append("<a href=\"javascript:;\" class='btn' style='font-size: 18px;' onclick='addPushType()'><i class=\"icon-plus\"></i></a>");
            this.NewsTypeDiv.InnerHtml = sb.ToString();
        }


        /// <summary>
        /// 初始化修改页面
        /// </summary>
        /// <param name="newsId">新闻id</param>
        private void ShowInfo(int newsId)
        {
            BLL.CCOM.News bll = new BLL.CCOM.News();
            Model.CCOM.News model = bll.GetModel(newsId);
            if(model!=null)
            {
                this.txtTitle.Text = model.News_title;
                //this.hidNewsType.Value = model.News_type_id.ToString();
                this.txtReleaseTime.Text = model.News_date.ToString();
                this.hidEditorCnt.Value = model.News_content;
                if (model.News_top!=null)
                {
                    this.optTop.Checked = (bool)model.News_top;
                    this.txtTopTime.Text = model.News_top_time.ToString();
                    //this.trTop.Style.Add("display", "");
                }   
                List<Model.CCOM.News_attach> attach_model = new BLL.CCOM.News_attach().GetModelList(" News_id=" + newsId);
                if(attach_model!=null&&attach_model.Count>0)
                {
                    rptAttach.DataSource = attach_model;
                    rptAttach.DataBind();
                }
            }
            else
            {
                JscriptMsg("资讯不存在或已被删除！", "back", "Error");
            }
        }


        /// <summary>
        /// 发布或保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.txtTitle.Text.Trim() == "")
            {
                JscriptMsg("资讯标题不能为空！", "", "Error");
                return;
            }
            if (this.txtTitle.Text.Trim().Length > 100)
            {
                JscriptMsg("资讯标题超过100字！", "", "Error");
                return;
            }
            if (Tools.CheckParams(this.txtTitle.Text.Trim()))
            {
                JscriptMsg("资讯标题含有非法字符！", "", "Error");
                return;
            }

            //创建文件夹
            FileOperate.FolderCreate(Utils.GetMapPath(DataDic.News_Attach_Path));

            if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
            {
                if (!DoEdit(this.newsId))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                String reStr = "资讯修改成功！";
                string pageUrl = "News_list_manager.aspx?fun_id=" + get_fun_id("CCOM/notification/News_list_manager.aspx");
                JscriptMsg(reStr, pageUrl, "Success");
                
            }
            else //添加
            {
                Int32 newsId = DoAdd();
                if (newsId < 1)
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                String reStr = "资讯发布成功！";
                string pageUrl = "News_list_manager.aspx?fun_id=" + get_fun_id("CCOM/notification/News_list_manager.aspx");
                JscriptMsg(reStr, pageUrl, "Success");
            }
        }
        
        
        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPreView_Click(object sender, EventArgs e)
        {
            String title = this.txtTitle.Text;
            String newsDes = "<span>发布者：" + GetAdminInfo_CCOM().User_realname + "</span>&nbsp;&nbsp;" +
                             DateTime.Now.ToString("yyyy-MM-dd");
            String content = this.hidEditorCnt.Value;
            String attach = "";
            var sb = new StringBuilder();
            //附件列表
            string hidFileList = Request.Params["hidFileName"];
            if (!string.IsNullOrEmpty(hidFileList))
            {
                string[] fileListArr = hidFileList.Split(',');
                sb.Append("<p class='attachTitle'>附件：</p>");
                for (int i = 0; i < fileListArr.Length; i++)
                {
                    string[] fileArr = fileListArr[i].Split('|');
                    if (fileArr.Length == 3)
                    {
                        sb.Append("<p class='attachItem'>(").Append(i + 1).Append(")<a href='")
                               .Append(fileArr[2])
                               .Append("' target='_blank' >")
                               .Append(fileArr[1])
                               .Append("</a>")
                               .Append("</p>");
                    }
                }
            }
            attach = sb.ToString();
            var newsObj = new PreviewNewsObject()
            {
                Title = title,
                Content = content,
                NewsDes = newsDes,
                AttachList = attach
            };
            Session["preview_news"] = newsObj;
            JscriptWinOpen("PreviewNews.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "_blank");
        }


        #region 修改操作=================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_id">资讯ID</param>
        /// <returns></returns>
        private bool DoEdit(int _id)
        {

            #region=====================================附件
            string hidFileList = Request.Params["hidFileName"];
            string strWhere = " News_id=" + _id;
            var news_attach = new BLL.CCOM.News_attach().GetModelList(strWhere);
            if (!string.IsNullOrEmpty(hidFileList))
            {
                string[] fileListArr = hidFileList.Split(',');
                //附件发生变化，重新上传(从无到有，数目发生变化，内容发生变化)
                if (news_attach != null && news_attach.Count > 0 && news_attach.Count != fileListArr.Length || this.attachChange.Value == "1" || news_attach.Count==0)
                {
                    var bll = new BLL.CCOM.News_attach();
                    for (int i = 0; i < news_attach.Count; i++)
                    {
                        string str = " News_attach_id=" + news_attach[i].News_attach_id;
                        bll.Delete(str);
                    }

                    for (int i = 0; i < fileListArr.Length; i++)
                    {
                        string[] fileArr = fileListArr[i].Split('|');
                        if (fileArr.Length == 3)
                        {
                            long attach_id = Int64.Parse(fileArr[0]);
                            String toFilePath = DataDic.News_Attach_Path + DateTime.Now.Ticks.ToString() + i.ToString() +
                            FileOperate.GetPostfixStr(fileArr[2]);
                            //新增文件
                            if (attach_id == 0)
                            {
                                try
                                {
                                    FileOperate.FileMove(Server.MapPath(fileArr[2]),
                                        Server.MapPath(toFilePath));
                                    //上传附件至文件服务器
                                    UI.UpLoad.UploadFileThread(toFilePath);
                                }
                                catch
                                {
                                    toFilePath = fileArr[2];
                                }
                            }
                            else
                            {
                                toFilePath = fileArr[2];    //原有附件地址不变
                            }
                            
                            Model.CCOM.News_attach model_attach = new Model.CCOM.News_attach();
                            model_attach.News_id = newsId;
                            model_attach.News_attach_name = fileArr[1];
                            model_attach.News_attach_address = toFilePath;
                            new BLL.CCOM.News_attach().Add(model_attach);
                        }
                    } 
                }  
            }
            else
            {
                //从有到无，删除数据库数据
                if(news_attach!=null&&news_attach.Count>0)
                {
                    var bll = new BLL.CCOM.News_attach();
                    for (int i = 0; i < news_attach.Count; i++)
                    {
                        string str = " News_attach_id=" + news_attach[i].News_attach_id;
                        bll.Delete(str);
                    }
                }
            }
            #endregion
            //var model = new Model.CCOM.News();
            var model = new BLL.CCOM.News().GetModel(_id);
            model.News_title = this.txtTitle.Text.Trim();
            if (this.txtReleaseTime.Text.Trim() != null && this.txtReleaseTime.Text.Trim().Length>0)
            {
                model.News_date = Convert.ToDateTime(this.txtReleaseTime.Text.Trim());
            }
            model.News_last_editor = (int)GetAdminInfo_CCOM().User_id;
            model.News_type_id = int.Parse(DESEncrypt.Decrypt(this.hidNewsType.Value));
            model.News_content = this.hidEditorCnt.Value.Replace("'", "");
            model.News_top = false;//默认不置顶
            if (this.optTop.Checked)
            {
                model.News_top = true;
                string time = this.txtTopTime.Text.Trim();
                if(time!=null&&time.Length>0)
                {
                    int last_time = int.Parse(time);
                    model.News_top_time = last_time;
                }
                else
                {
                    model.News_top_time = 3;//默认置顶3天
                }
            }
           
           if(new BLL.CCOM.News().Update(model))
           {
               NewsHtml.CreateHtml(_id, false);
               return true;
           }
           else
           {
               return false;
           }
        }
        #endregion


        #region 增加操作=================================
        private int DoAdd()
        {
            var model = new Model.CCOM.News();
            model.News_title = this.txtTitle.Text.Trim();
            model.News_URL = "/AdminMetro/index.aspx";
            model.News_creator_id =(int) GetAdminInfo_CCOM().User_id;
            if (this.txtReleaseTime.Text.Trim() != null && this.txtReleaseTime.Text.Trim().Length>0)
            {
                model.News_date =Convert.ToDateTime(this.txtReleaseTime.Text.Trim());
            }
            else
            {
                model.News_date = DateTime.Now;
            }
            model.News_readnumber = 1;
            model.News_type_id = int.Parse(DESEncrypt.Decrypt(this.hidNewsType.Value));
            model.News_content = this.hidEditorCnt.Value.Replace("'", "");
            model.News_top = false;
            if (this.optTop.Checked)
            {
                model.News_top = true;
                string time = this.txtTopTime.Text.Trim();
                if (time != null && time.Length > 0)
                {
                    int last_time = int.Parse(time);
                    model.News_top_time = last_time;
                }
                else
                {
                    model.News_top_time = 3;//默认置顶3天
                }
            }
           
            Int32 newsId = 0;
            newsId =new BLL.CCOM.News().Add(model);
            if (newsId > 0)
            {
                #region====================附件
                //保存附件
                string hidFileList = Request.Params["hidFileName"];
                if (!string.IsNullOrEmpty(hidFileList))
                {
                    string[] fileListArr = hidFileList.Split(',');
                    //var list = new List<Model.CCOM.News_attach>();
                    for (int i = 0; i < fileListArr.Length; i++)
                    {
                        string[] fileArr = fileListArr[i].Split('|');
                        if (fileArr.Length == 3)
                        {
                            int attach_id = Int32.Parse(fileArr[0]);
                            String toFilePath = DataDic.News_Attach_Path + DateTime.Now.Ticks.ToString() + i.ToString() +
                                     FileOperate.GetPostfixStr(fileArr[2]);
                            try
                            {
                                FileOperate.FileMove(Server.MapPath(fileArr[2]),
                                    Server.MapPath(toFilePath));
                                //上传附件至文件服务器
                                UI.UpLoad.UploadFileThread(toFilePath);
                            }
                            catch (Exception ex)
                            {
                                toFilePath = fileArr[2];
                            }
                            Model.CCOM.News_attach model_attach = new Model.CCOM.News_attach();
                            model_attach.News_id = newsId;
                            model_attach.News_attach_name = fileArr[1];
                            model_attach.News_attach_address = toFilePath;
                            new BLL.CCOM.News_attach().Add(model_attach);
                        }
                    }
                }
                #endregion
                //修改URL
                Model.CCOM.News model1 = new BLL.CCOM.News().GetModel(newsId);
                model1.News_URL = "/AdminMetro/CCOM/notification/ViewNews.aspx?id=" + DESEncrypt.Encrypt(newsId.ToString());
                new BLL.CCOM.News().Update(model1);
                //生成静态页
                NewsHtml.CreateHtml(newsId, false);
            }
            return newsId;
        }
        #endregion
    }
}