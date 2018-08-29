using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.notice
{
    public partial class ReleaseOrEditNotice : university.UI.ManagePage
    {
        public ReleaseOrEditNotice()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        //新版推送接口
        private static string NOTICE_PUSH_URL = ConfigurationManager.AppSettings["sendpush"].ToString();

        private static int USER_TYPE = 3;

        private const string NC_Code = DataDic.OFFICE_CHANNEL;

        private string action = MyEnums.ActionEnum.Add.ToString(); //操作类型
        protected long pushId = 0;
        protected int ddlValue = 0;
        protected string keywords = string.Empty;
        protected long gid = 0; //将要发送的推送组的ID
        protected bool completeFirstIntro = false;
        //protected bool verifySecurityPwd = true;

        protected int editType = -1;
        
        protected int TotalNumber = 0;   //学工处通知使用的总人数和


        

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.fun_id = get_fun_id("CCOM/notice/ReleaseOrEditNotice.aspx");
            string _action = MyRequest.GetQueryString("action");
            this.keywords = MyRequest.GetQueryString("keywords");
            if (!string.IsNullOrEmpty(_action) && _action == MyEnums.ActionEnum.Edit.ToString())
            {
                this.action = MyEnums.ActionEnum.Edit.ToString();   //修改类型
                long.TryParse(DESEncrypt.Decrypt(MyRequest.GetQueryString("id")), out this.pushId);
                if (this.pushId == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.CCOM.Notice().Exists(this.pushId))
                {
                    JscriptMsg("通知不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!IsPostBack)
            {
                //绑定推送类别
                //BindPushType();
                if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.pushId);
                }
            }
        }




        //绑定类别
        //protected void BindPushType()
        //{
        //    //默认选中未分类
        //    string strNoType = "<a href=\"javascript:;\" class='btn btn-success' onclick='selectPushType(this,\"" + DESEncrypt.Encrypt("0") + "\")'>未分类</a>&nbsp;&nbsp;";
        //    this.divPushType.InnerHtml = strNoType;

        //    var ml = new BLL.CCOM.Notice_type().GetModelList("");
        //    var sb = new StringBuilder();
        //    foreach (var m in ml)
        //    {
        //        sb.Append("<a href=\"javascript:;\" class='btn' onclick='selectPushType(this,\"" + DESEncrypt.Encrypt(m.Notice_type_id.ToString()) + "\")'>" + m.Notice_type_name + "</a>");
        //    }
        //    sb.Append("<a href=\"javascript:;\" class='btn' style='font-size: 18px;' onclick='addPushType()'><i class=\"icon-plus\"></i></a>");

        //    this.divPushType.InnerHtml += sb.ToString();
        //}

        private void ShowInfo(long _id)
        {
            var bll = new BLL.CCOM.Notice();
            var model = bll.GetModel(_id);

            this.btnSubmit.Visible = false;
            this.divSave.Visible = true;

            //**********  0(false)表示文字通知，1(true)表示图文通知****************//
            if(model.Notice_type!=null)
            {
                if((bool)model.Notice_type)//图文通知
                {
                    this.txtTitle.Text = model.Notice_title;
                    this.hidEditorCnt.Value = model.Notice_content;
                    //绑定附件
                    var attachList = new BLL.CCOM.Notice_attach().GetModelList("Notice_id=" + _id);
                    if(attachList!=null&&attachList.Count>0)
                    {
                        this.rptAttach.DataSource = attachList;
                        this.rptAttach.DataBind();
                    }

                    //选择通知类型
                    ScriptManager.RegisterStartupScript(this, this.Page.GetType(), "setParam", "selectImagePush();", true);
                }
                else//文字通知
                {
                    this.txtContent.Text = model.Notice_content;
                }

                //绑定推送人员
                if(model.Notice_receiver_id!=null&&model.Notice_receiver_id.Length>0)
                {
                    string receiver = model.Notice_receiver_id;
                    if(receiver!=null&&receiver.Length>0)
                    {
                        BindNoticeUser(receiver);
                    } 
                }
            }
            
        }

        private void BindNoticeUser(string ids)
        {
            var userIdList = new List<long>();
            var nameNodeList = new Hashtable();
            string[] receivers_id = ids.Split(',');
            for(int i=0;i<receivers_id.Length;i++)
            {
                userIdList.Add(long.Parse(receivers_id[i]));
                var model=new BLL.CCOM.User_information().GetModel(long.Parse(receivers_id[i]));
                if(model!=null)
                {
                    string realName = model.User_realname;
                    //加入返回的节点集合中，格式为(type|id, name)
                    if (!nameNodeList.Contains(USER_TYPE + "|" + receivers_id[i]))
                    {
                        nameNodeList.Add(USER_TYPE + "|" + receivers_id[i], realName);
                    }
                    if (i > 300)
                    {
                        nameNodeList.Add(USER_TYPE + "|" + 0, "...");
                        break;
                    }
                }
                
            }

            //调用前台js函数，将结果返回父页面
            var js = "selectUserDeptCallBack('', '', '" + String.Join(",", userIdList.ToArray()) + "', '" + LitJson.JsonMapper.ToJson(nameNodeList) + "', '" + userIdList.Count + "');";
            JscriptReponse(js);
        }

        #region 添加附件
        private void AddAttach(long id)
        {
            string hidFileList = Request.Params["hidFileName"];
            if (!string.IsNullOrEmpty(hidFileList))
            {
                var bll = new BLL.CCOM.Notice_attach();
                string[] fileListArr = hidFileList.Split(',');
                for (int i = 0; i < fileListArr.Length; i++)
                {
                    string[] fileArr = fileListArr[i].Split('|');
                    if (fileArr.Length == 3)
                    {
                        long attach_id = Int64.Parse(fileArr[0]);
                        String toFilePath = DataDic.News_Attach_Path + DateTime.Now.Ticks.ToString() + i.ToString() +
                        FileOperate.GetPostfixStr(fileArr[2]);
                        toFilePath = fileArr[2];    //原有附件地址不变
                        try
                        {
                            FileOperate.FileMove(Server.MapPath(fileArr[2]), Server.MapPath(toFilePath));

                            //上传附件至文件服务器
                            UI.UpLoad.UploadFileThread(toFilePath);
                        }
                        catch
                        {
                            toFilePath = fileArr[2];
                        }
                        var attach_model=new Model.CCOM.Notice_attach ();
                        attach_model.Notice_attach_name=fileArr[1];
                        attach_model.Notice_id=id;
                        attach_model.Notice_attach_address=toFilePath;
                        bll.Add(attach_model);
                    }
                }
                
            }
        }
        #endregion

        #region  生成静态页面
        

        //生成静态页面
        private void CreateHtmlPage(long id)
        {
            String name = NoticeHtml.WebPushBaseDir + DESEncrypt.Encrypt(id.ToString()) + ".html";
            NoticeHtml.CreateWebPushHtml(id.ToString(), Server.MapPath(name));
        }
        #endregion


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(Check())
            {
                if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
                {
                    if (this.pushId == 0)
                    {
                        JscriptMsg("编辑的通知不存在！", "", "Error");
                        return;
                    }
                    DoEdit(this.pushId);
                }
                else
                {
                    DoAdd();
                }
                
            }
        }

        //保存前检查
        private bool Check()
        {
            int type = this.hidIsImagePush.Value == "1" ? 1 : 0;
            if (type == 0)
            {
                //文字通知
                if (this.txtContent.Text.Trim().Length == 0 || this.txtContent.Text.Trim().Length > 250)
                {
                    JscriptMsg("文字通知内容必须在1~250个字符之间！！", "", "Error");
                    return false;
                }
            }
            else
            {
                //图文通知
                if (this.txtTitle.Text.Trim() == "")
                {
                    JscriptMsg("通知标题不能为空！", "", "Error");
                    return false;
                }
                if (this.txtTitle.Text.Trim().Length > 100)
                {
                    JscriptMsg("通知标题超过100字！", "", "Error");
                    return false;
                }
                if (Tools.CheckParams(this.txtTitle.Text.Trim()))
                {
                    JscriptMsg("通知标题含有非法字符！", "", "Error");
                    return false;
                }
                if (this.hidEditorCnt.Value.Trim().Replace("'", "") == "")
                {
                    JscriptMsg("通知内容不能为空！", "", "Error");
                    return false;
                }
            }
            return true;
        }

        #region 修改操作=================================
        private void DoEdit(long id)
        {
            int totalUserCount = 0;
            Int32.TryParse(this.hidTotalUserCount.Value, out totalUserCount);
            if (totalUserCount == 0)
            {
                JscriptMsg("选择的推送用户数不能为0！", "", "Error");
                return;
            }
            BLL.CCOM.Notice bll=new BLL.CCOM.Notice();
            var model = bll.GetModel(id);
            model.Notice_last_editor = GetAdminInfo_CCOM().User_id;
            model.Notice_receiver_id = this.hidUserList.Value.ToString();
            int type = this.hidIsImagePush.Value == "1" ? 1 : 0;
            if (type == 0)
            {
                model.Notice_content = txtContent.Text.Trim().Replace("'", "");
            }
            else
            {
                //图文通知
                model.Notice_title = this.txtTitle.Text.Trim();
                model.Notice_content = this.hidEditorCnt.Value.Replace("'", "");
                new BLL.CCOM.Notice_attach().Delete(" Notice_id=" + id);
                AddAttach(id);
            }
            bool result=bll.Update(model);
            //修改推送用户的阅读状态为未读，相当于重新推送覆盖之前
            if(result)
            {
                var userIdList = this.hidUserList.Value.ToString().Split(',').ToList();
                string[] receiver_ids = this.hidUserList.Value.ToString().Split(',');

                if (receiver_ids != null && receiver_ids.Length > 0)
                {
                    var bll1 = new BLL.CCOM.User_notice();
                    for (int i = 0; i < receiver_ids.Length; i++)
                    {
                        var user_notice_model = bll1.GetModel(" User_id= " + receiver_ids[i]);
                        if (user_notice_model != null)
                        {
                            string[] notice_ids=user_notice_model.Notice_id.Split(',');
                            string[] notice_read_ids = user_notice_model.Notice_read_id.Split(',');
                            //新加的用户
                            if (!notice_ids.Contains(model.Notice_id.ToString()) && !notice_read_ids.Contains(model.Notice_id.ToString()))
                            {
                                if(user_notice_model.Notice_id==null||user_notice_model.Notice_id.Length<=0)//暂无未读通知
                                {
                                    user_notice_model.Notice_id = model.Notice_id.ToString();
                                }
                                else
                                {
                                    user_notice_model.Notice_id = user_notice_model.Notice_id+","+model.Notice_id.ToString();
                                }
                                bll1.Update(user_notice_model);
                            }
                            else//之前发送过的用户
                            {
                                if(notice_read_ids.Contains(model.Notice_id.ToString()))//已经阅读过，从已读移到未读
                                {
                                    //从已读去掉
                                    List<string> read_ids = notice_read_ids.ToList();
                                    read_ids.Remove(model.Notice_id.ToString());
                                    
                                    string temp = string.Empty;
                                    for (int j = 0; j < read_ids.Count;j++)
                                    {
                                        temp = temp + read_ids[j] + ",";
                                    }
                                    temp = temp.Substring(0, temp.Length - 1);
                                    user_notice_model.Notice_read_id = temp;

                                    //加入未读
                                    if (user_notice_model.Notice_id == null || user_notice_model.Notice_id.Length <= 0)
                                    {
                                        user_notice_model.Notice_id = model.Notice_id.ToString();
                                    }
                                    else
                                    {
                                        user_notice_model.Notice_id = user_notice_model.Notice_id + "," + model.Notice_id.ToString();
                                    }
                                    //更新
                                    bll1.Update(user_notice_model);
                                }
                                
                            }
                        }
                        else
                        {
                            //表中暂无该用户记录，创建该用户记录
                            Model.CCOM.User_notice mod = new Model.CCOM.User_notice();
                            mod.Notice_id = model.Notice_id.ToString();
                            mod.User_id = long.Parse(receiver_ids[i]);
                            bll1.Add(mod);
                        }
                    }
                }

                if (this.chbSmsSend.Checked)
                {
                    SmsHelper.SendSmsNotice(userIdList, model.Notice_content, GetAdminInfo_CCOM().User_id);
                    //if (new BLL.CCOM.User_sms().GetModel(GetAdminInfo_CCOM().User_id).User_sms_left < userIdList.Count)
                    //{
                    //    JscriptMsg("您的剩余短信已不足，请申请短信！！", "", "Error");
                    //    return;
                    //}
                }
                //生成静态页
                NoticeHtml.CreateHtml(id, false);
                string pageUrl = Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&pushId={1}", get_fun_id("CCOM/notice/Notice_list_manager.aspx"), pushId.ToString());
                JscriptMsg("修改成功 ，跳转至结果页面...", pageUrl, "Success");
            }
            
        }
        #endregion

        #region 增加操作=================================
        private void DoAdd()
        {
            int totalUserCount = 0;
            Int32.TryParse(this.hidTotalUserCount.Value, out totalUserCount);
            if (totalUserCount == 0)
            {
                JscriptMsg("选择的推送用户数不能为0！", "", "Error");
                return;
            }
            var model = new Model.CCOM.Notice();
            int type = this.hidIsImagePush.Value == "1" ? 1 : 0;
            if (type == 0)
            {
                //文字通知
                model.Notice_title = "通知[" +GetAdminInfo_CCOM().User_realname + "]";
                model.Notice_content = txtContent.Text.Trim().Replace("'", "");
                model.Notice_type = false;
            }
            else
            {
                //图文通知
                model.Notice_title = this.txtTitle.Text.Trim();
                model.Notice_content = this.hidEditorCnt.Value.Replace("'", "");
                model.Notice_type = true;
            }
            model.Notice_date = DateTime.Now;
            model.Notice_flag = false;
            StringBuilder list = new StringBuilder();
            if (!string.IsNullOrEmpty(this.hidUserList.Value.ToString()))
            {
                list.Append(this.hidUserList.Value.ToString());
            }
            //string group = this.hidGroupList.Value.ToString();
            //if (!string.IsNullOrEmpty(group))
            //{
            //    string[] agency_id_list = group.Split(',');
            //    for(int i=0;i<agency_id_list.Length;i++)
            //    {
            //        var model_list = new BLL.CCOM.User_property().GetModelList(" Agency_id=" + agency_id_list[i]);
            //        if(model_list!=null&&model_list.Count>0)
            //        {
            //            for(int j=0;j<model_list.Count;j++)
            //            {
            //                if(list.ToString().Length>0)
            //                {
            //                    list.Append(",");
            //                    list.Append(model_list[j].User_id);
            //                }
            //                else if (list.ToString().Length == 0)
            //                {
            //                    list.Append(model_list[j].User_id);
            //                }
            //            }
            //        }
            //    }
            //}
            model.Notice_receiver_id = list.ToString();
            if (model.Notice_receiver_id.Length<=0)
            {
                JscriptMsg("请选择推送人员！！", "", "Error");
                return;
            }
            model.Notice_sender_id = GetAdminInfo_CCOM().User_id;
            long notice_id = new BLL.CCOM.Notice().Add(model);
            if(notice_id>0)
            {
                string[] receiver_ids = list.ToString().Split(',');

                if(receiver_ids!=null&&receiver_ids.Length>0)
                {
                    var bll = new BLL.CCOM.User_notice();
                    for(int i=0;i<receiver_ids.Length;i++)
                    {
                        var user_notice_model = bll.GetModel(" User_id= " + receiver_ids[i]);
                        if(user_notice_model!=null)
                        {
                            string _id = user_notice_model.Notice_id;
                            if(_id!=null&&_id.Length>0)
                            {
                                user_notice_model.Notice_id = _id + "," + notice_id;
                            }
                            else
                            {
                                user_notice_model.Notice_id = notice_id.ToString();
                            }
                            bll.Update(user_notice_model);
                        }
                        else
                        {
                            Model.CCOM.User_notice user_model = new Model.CCOM.User_notice();
                            user_model.User_id = long.Parse(receiver_ids[i]);
                            user_model.Notice_id = notice_id.ToString();
                            bll.Add(user_model);
                        }
                    }
                }
                else
                {
                    JscriptMsg("通知推送出错！！", "", "Error");
                    return;
                }
                AddAttach(notice_id);
                var userIdList = list.ToString().Split(',').ToList();
                if (this.chbSmsSend.Checked)
                {
                    //var User_sms_model=new BLL.CCOM.User_sms().GetModel(GetAdminInfo_CCOM().User_id);
                    //if (User_sms_model == null||User_sms_model.User_sms_left < userIdList.Count)
                    //{
                    //    JscriptMsg("您的剩余短信已不足，请申请短信！！", "", "Error");
                    //    return;
                    //}
                    SmsHelper.SendSmsNotice(userIdList, model.Notice_content, GetAdminInfo_CCOM().User_id);
                }
                //生成静态页
                CreateHtmlPage(notice_id);
                string pageUrl = Utils.CombUrlTxt("Notice_list_manager.aspx", "fun_id={0}&pushId={1}", get_fun_id("CCOM/notice/Notice_list_manager.aspx"), pushId.ToString());
                JscriptMsg("推送完成，跳转至结果页面...", pageUrl, "Success");
            }
        }
        #endregion

        private void sendPushResultSms(int count)
        {
            string pushResult = "您刚使用中央音乐学院招生系统给" + count + "位用户成功推送了一条通知.欲了解详情，请登录中央音乐学院招生系统，进入通知推送系统查看。";
            if (ManDaoSMS.SendSMS(GetAdminInfo_CCOM().User_phone, pushResult) != ManDaoSMS.RESULT_SUCCESS)
            {
                JscriptMsg("推送结果的短信发送失败", "", "Error");
            }
        }
        

        //protected int GetSMSNumber()
        //{
        //    var model = new BLL.CCOM.User_sms().GetModel(" User_id="+GetAdminInfo_CCOM().User_id);
        //    if(model==null)
        //    {
        //        return 0;
        //    }  
        //    else
        //    {
        //        this.SMS_left.Value = model.User_sms_left+"";
        //        return model.User_sms_left;
        //    }
        //}
    }
}