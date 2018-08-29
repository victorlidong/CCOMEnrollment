using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using System.Text.RegularExpressions;
using university.Common;
using university.Web.UI;
using LitJson;
using Newtonsoft.Json;

namespace university.Web.tools
{
    /// <summary>
    /// AjaxPushUsers 的摘要说明
    /// </summary>
    public class SendSMS : IHttpHandler, IRequiresSessionState
    {
        private const long OK = 200;
        private const long ERROR = 201;

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                switch (context.Request["action"])
                {
                    case "sendSMSById":
                        SendSMSById(context);
                        break;
                    //case "batchCheckApply":
                    //    batchCheckApply(context);
                    //    break;
                    //case "getStatisticData":
                    //    GetStatisticData(context);
                    //    break;
                    //case "GetDF":
                    //    GetDF(context);
                    //    break;
                    //case "DelRecord":
                    //    DelRecord(context);
                    //    break;
                    //case "GetSysProperty":
                    //    GetSysProperty(context);
                    //    break;
                    //case "BindApplyDeptList":
                    //    BindApplyDeptList(context);
                    //    break;
                    //case "DownLoadFileFromQiNiu":
                    //    DownLoadFileFromQiNiu(context);
                    //    break;
                    //case "getSmsNum":
                    //    getSmsNum(context);
                    //    break;


                    //case "bindAdminList":
                    //    bindAdminList(context);
                    //    break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = ex.ToString() }));
            }
        }


        private void FlushResponse(HttpContext context, String res)
        {
            context.Response.Write(res);
            context.Response.Flush();
        }

        private void SendSMSById(HttpContext context)
        {
            long userid = long.Parse(DESEncrypt.Decrypt(MyRequest.GetString("userid")));
            string smsContent = "您有一项任务未完成，请加快进度。 任务标题：" + DESEncrypt.Decrypt(MyRequest.GetString("tasktitle"));
            string res = ManDaoSMS.SendSMS(new BLL.admin.Universities_UserInfo().GetModel(userid).UI_Mobile, smsContent);
            FlushResponse(context, res);
        }




        class ReturnObject
        {
            public long Result { get; set; }
            public String Msg { get; set; }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //    private void bindAdminList(HttpContext context)
        //    {

        //        string applyid = DESEncrypt.Decrypt(MyRequest.GetString("applyid"));
        //        if (applyid == "")
        //            return;
        //        var modellist = new BLL.admin.View_AdminUser().GetModelList("UserID in (select AU_AdminUser from OA_Declaration_AdminUser where Apply_ID = " + applyid + ")");


        //        string res = "";

        //        res = "<select name=\"NextCheckList\" id=\"NextCheckList\"><option value=\"" + DESEncrypt.Encrypt("-1") + "\">请选择</option>";

        //        foreach (Model.admin.View_AdminUser model in modellist)
        //        {
        //            //如果审批人是自己，跳过
        //            if (model.UserID == GetAdminInfo().UserID)
        //                continue;
        //            res += "<option value=\"" + DESEncrypt.Encrypt(model.UserID.ToString()) + "\">" + model.UI_RealName + "</option>";
        //        }

        //        res += "</select>";

        //        FlushResponse(context, res);

        //    }

        //    private void getSmsNum(HttpContext context)
        //    {
        //        String depList = MyRequest.GetString("depList");
        //        String userList = MyRequest.GetString("userList");
        //        String orgUserList = MyRequest.GetString("orgUserList");

        //        int count = 0;
        //        if (depList != "")
        //        {
        //            String sql = "select UserID from App_Universities_SchoolUser where UO_ID in (" + depList + ") and SchoolUser_Activity = 1";
        //            sql += " union";
        //            sql += " select UserID from App_Universities_AdminUser where UO_ID in (" + depList + ") and AdminUser_Activtiy = 1";
        //            sql += " union";
        //            sql += " select UserID from App_Universities_SocialUser where UO_ID in (" + depList + ") and SocialUser_Activity = 1";
        //            var ds = Database.DBSQL.Query(sql);
        //            if (ds != null) count += ds.Tables[0].DefaultView.Count;
        //        }
        //        count += userList.Split(',').Length;
        //        count += orgUserList.Split(',').Length;
        //        if (new BLL.news.News_SmsNumber().GetSmsNumber(GetAdminInfo().UserID) > count)  //短信条数够
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = "" }));
        //            return;
        //        }
        //        else
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "" }));
        //            return;
        //        }
        //    }

        //    private void DownLoadFileFromQiNiu(HttpContext context)
        //    {
        //        string url =  MyRequest.GetString("url");
        //        string key =  MyRequest.GetString("key");
        //        if (key != "qq661507181244qq")
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
        //            return;
        //        }
        //        if (url == "")
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
        //            return;
        //        }
        //        if (url.StartsWith("http://" + MyRequest.GetCurrentFullHost()))
        //        {
        //            string path = url.Replace("http://" + MyRequest.GetCurrentFullHost(), "");
        //            if (File.Exists(Utils.GetMapPath(path)))
        //            {
        //                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = DESEncrypt.Encrypt(path) }));
        //                return;
        //            }
        //            else
        //            {
        //                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = "" }));
        //                return;
        //            }
        //        }
        //        if (url == "")
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = "" }));
        //            return;
        //        }
        //        try
        //        {
        //            FileOperate.WriteFile(Utils.GetMapPath("./log.txt"), url);
        //            string dirPath = new university.Web.UI.UpLoad().GetUpLoadPath();
        //            //物理完整路径                    
        //            string toFileFullPath = Utils.GetMapPath(dirPath);
        //            //检查有该路径是否就创建
        //            if (!Directory.Exists(toFileFullPath))
        //            {
        //                Directory.CreateDirectory(toFileFullPath);
        //            }

        //            string extension = url.Substring(url.LastIndexOf('.') + 1, url.Length - url.LastIndexOf('.') - 1);

        //            //检查文件扩展名是否合法
        //            if (!new university.Web.UI.UpLoad().CheckFileExt(extension))
        //            {
        //                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "文件不合法" }));
        //                return;
        //            }
        //            string filePath = dirPath + DateTime.Now.ToFileTime() + "." + extension.ToLower();
        //            //类文件中不能直接使用Server.MapPath
        //            string physicalPath = Utils.GetMapPath(filePath);
        //            //WebClient.DownloadFileAsync(url, physicalPath);
        //            FileOperate.WriteFile(Utils.GetMapPath("./log.txt"), physicalPath);
        //            FileOperate.WriteFile(Utils.GetMapPath("./log.txt"), url.Substring(0, url.LastIndexOf('.')));
        //            FileOperate.WriteFile(Utils.GetMapPath("./log.txt"), "");
        //            WebClient.DownloadFileAsync(url.Substring(0, url.LastIndexOf('.')), physicalPath);
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = DESEncrypt.Encrypt(filePath) }));
        //            return;
        //        }
        //        catch (Exception ex)
        //        {
        //            //logger.Debug(ex.Message, ex);
        //            FileOperate.WriteFile(Utils.GetMapPath("./log.txt"), ex.ToString());
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "出错了" }));
        //            return;
        //        } 
        //    }

        //    //绑定可选机构
        //    protected void BindApplyDeptList(HttpContext context)
        //    {
        //        if (!IsAdminLogin())
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "error" }));
        //            return;
        //        }
        //        long apply_id = long.Parse(DESEncrypt.Decrypt(MyRequest.GetString("id")));
        //        if (apply_id == 0)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
        //            return;
        //        }

        //        var uoIdList = new List<long>();
        //        var uoNameList = new List<String>();
        //        var userIdList = new List<long>();
        //        var userNameList = new List<String>();
        //        var orgUserList = new List<String>();

        //        var orgl = new BLL.declaration.ApplyOrganization().GetModelList(" Apply_ID=" + apply_id);
        //        var ugl = new BLL.declaration.ApplyUser().GetModelList(" Apply_ID=" + apply_id + " and AU_Src = " + DataDic.ApplyUserSrc_Group);
        //        var uscl = new BLL.declaration.ApplyUser().GetModelList(" Apply_ID=" + apply_id + " and AU_Src = " + DataDic.ApplyUserSrc_SchoolContact);
        //        if (orgl != null && orgl.Count > 0)
        //        {

        //            var bll = new BLL.admin.Universities_Organization();
        //            foreach (var m in orgl)
        //            {
        //                if (m == null) continue;

        //                uoIdList.Add(m.UO_ID);
        //                var ouM = bll.GetModel(m.UO_ID);
        //                if (ouM == null) continue;
        //                String name = ouM.UO_Name;
        //                //if (ouM.UO_FatherID != 0)
        //                //{
        //                //    var pOuM = bll.GetModel(ouM.UO_FatherID);
        //                //    name = pOuM.UO_Name + "->" + name;
        //                //}
        //                uoNameList.Add(name);
        //            }
        //        }

        //        if (ugl != null && ugl.Count > 0)
        //        {
        //            var bll = new BLL.admin.Universities_UserInfo();
        //            foreach (var u in ugl)
        //            {
        //                var uModel = bll.GetModel(u.UserID);
        //                if (uModel == null) continue;
        //                userIdList.Add(u.UserID);
        //                userNameList.Add(uModel.UI_RealName);
        //            }
        //        }

        //        if (uscl != null && uscl.Count > 0)
        //        {
        //            var bll = new BLL.admin.Universities_UserInfo();
        //            foreach (var u in uscl)
        //            {

        //                var uModel = bll.GetModel(u.UserID);
        //                if (uModel == null) continue;
        //                //userIdList.Add(u.UserID);
        //                userNameList.Add(uModel.UI_RealName);

        //                if (u.User_Roleid == null) continue;
        //                orgUserList.Add(u.UserID + "_" + u.User_Roleid + "_" + u.UserType);

        //            }
        //        }

        //        //this.hidUserDept.Value = String.Join(",", uoIdList.ToArray());
        //        //this.txtUserDept.Text = String.Join(",", uoNameList.ToArray());
        //        String Msg = String.Join(",", uoIdList.ToArray()) + "|" + String.Join("; ", uoNameList.ToArray()) + "|" + String.Join(",", userIdList.ToArray()) + "|" + String.Join(",",orgUserList) + "|" + String.Join("; ", userNameList.ToArray());
        //        FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = Msg }));
        //        return;

        //    }

        //    private void GetStatisticData(HttpContext context)
        //    {
        //        if (!IsAdminLogin())
        //        {
        //            FlushResponse(context, "[]");
        //            return;
        //        }
        //        var userId = GetAdminInfo().UserID;
        //        var applyId = long.Parse(DESEncrypt.Decrypt(MyRequest.GetString("id")));
        //        if (!WebHelper.IsApplyAdminUser(applyId, userId))
        //        {
        //            FlushResponse(context, "[]");
        //        }
        //        //获取统计数据
        //        var readCnt = new university.BLL.declaration.ApplyRecord().GetRecordCount("Record_ID in (select Record_ID from OA_Declaration_ApplySignIn where SignIn_Status = 1) and Apply_ID="+applyId);
        //        //var unreadCnt = new university.BLL.declaration.ApplyRecord().GetRecordCount("Record_ID  in (select Record_ID from OA_Declaration_ApplyRecord where Apply_ID = " + applyId + ") and SignIn_Status is null");
        //        var totalCnt = new university.BLL.declaration.ApplyRecord().GetRecordCount("Apply_ID = " + applyId);
        //        var unreadCnt = totalCnt - readCnt;
        //        var seriesList = new List<Hashtable>();
        //        var readHt = new Hashtable {{"name", "签到统计"}, {"type", "pie"}};

        //        var readData = new List<Hashtable>();
        //        var htRead = new Hashtable();
        //        var htUnread = new Hashtable();
        //        htRead.Add("value", readCnt);
        //        htRead.Add("name", "已签到");
        //        htUnread.Add("value", unreadCnt);
        //        htUnread.Add("name", "未签到");
        //        htUnread.Add("selected", true);
        //        readData.Add(htRead);
        //        readData.Add(htUnread);
        //        readHt.Add("data", readData);
        //        seriesList.Add(readHt);
        //        FlushResponse(context, JsonConvert.SerializeObject(seriesList));
        //    }




        //    private void CheckApply(HttpContext context)
        //    {
        //        if (!IsAdminLogin())
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "error" }));
        //            return;
        //        }

        //        int status = MyRequest.GetQueryInt("s");
        //        long record_id = long.Parse(DESEncrypt.Decrypt(MyRequest.GetString("id")));
        //        int endcheck = MyRequest.GetQueryInt("end");

        //        long adminid = long.Parse(DESEncrypt.Decrypt(MyRequest.GetString("adminid")));


        //        if (record_id == 0)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
        //            return;
        //        }
        //        //判断是否有权限审核
        //        var userId = GetAdminInfo().UserID;
        //        var applyId = new BLL.declaration.ApplyRecord().GetModel(record_id).Apply_ID;

        //        if (!WebHelper.IsApplyAdminUser(applyId,userId))
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
        //            return;
        //        }
        //        String reason = HttpContext.Current.Server.UrlDecode(MyRequest.GetString("r"));
        //        if (reason.Length > 1000)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "意见文字太多！" }));
        //            return;
        //        }
        //        if (Tools.CheckParams(reason))
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "审批意见含有敏感字符！" }));
        //            return;
        //        }
        //        //
        //        var recordBll = new BLL.declaration.ApplyRecord();
        //        var checkBll = new BLL.declaration.ApplyCheck();
        //        bool result = false;
        //        var checkMList = checkBll.GetModelList("Record_ID = " + record_id + " and Check_User = "+GetAdminInfo().UserID);
        //        if (checkMList.Count <= 0 )
        //        {
        //            //add
        //            var checkM = new Model.declaration.ApplyCheck();
        //            checkM.Check_Status = status;
        //            checkM.Check_Comment = reason;
        //            checkM.Check_Time = DateTime.Now;
        //            checkM.Check_User = GetAdminInfo().UserID;
        //            checkM.Record_ID = record_id;
        //            var id=checkBll.Add(checkM);
        //            if (id > 0)
        //                result = true;
        //        }
        //        else
        //        {
        //            //update
        //            var checkM = checkMList[0];
        //            checkM.Check_Status = status;
        //            checkM.Check_Comment = reason;
        //            checkM.Check_User = GetAdminInfo().UserID;
        //            checkM.Check_Time = DateTime.Now;
        //            result = checkBll.Update(checkM);
        //        }

        //        if (result)
        //        {
        //            var recordM = recordBll.GetModel(record_id);


        //            //if (recordM.Record_Status == status) 
        //            //{
        //            //    FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = "审批成功！" }));
        //            //    return;
        //            //}

        //            //recordM.Record_Status = status;

        //            //如果选择下一级审核
        //            if (endcheck == 0)
        //            {
        //                //正在审核
        //                //recordM.Record_Status = DataDic.Check_NO;
        //                //添加一条check记录
        //                var checkmodel= new Model.declaration.ApplyCheck();
        //                checkmodel.Check_Status= DataDic.Check_NotCheck;
        //                checkmodel.Check_Time=DateTime.Now;
        //                checkmodel.Check_User=adminid;
        //                checkmodel.Create_Time=DateTime.Now;
        //                checkmodel.Record_ID=record_id;
        //                new BLL.declaration.ApplyCheck().Add(checkmodel);

        //            }
        //            //结束审批
        //            else
        //            {
        //                recordM.Record_Status = status;
        //            }


        //            if (recordBll.Update(recordM))
        //            {
        //                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() {Result = OK, Msg = "审批成功！"}));
        //                //发送提醒
        //                var applyTitle = new BLL.declaration.ApplySubject().GetModel(applyId).Apply_Title;
        //                PushHelper.PushWhenCheckApply(applyId, recordM.Record_User, status);
        //            }
        //            else
        //            {
        //                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "审批失败！" }));
        //            }
        //        }
        //        else
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数有误，审批失败！" }));
        //        }
        //    }



        //    private void batchCheckApply(HttpContext context)
        //    {
        //        if (!IsAdminLogin())
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "error" }));
        //            return;
        //        }
        //        String reason = HttpContext.Current.Server.UrlDecode(MyRequest.GetString("r"));
        //        if (reason.Length > 250)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "说明文字太多！" }));
        //            return;
        //        }
        //        if (Tools.CheckParams(reason))
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "审批理由含有敏感字符！" }));
        //            return;
        //        }

        //        int status = MyRequest.GetQueryInt("s");
        //        string value = MyRequest.GetString("id");
        //        if (value == "")
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法" }));
        //            return;
        //        }
        //        value = Utils.DelLastComma(value);
        //        string[] list_record = value.Split(',');
        //        foreach (var tmp in list_record)
        //        {
        //            try
        //            {
        //                long record_id = long.Parse(tmp);
        //                if (record_id == 0)
        //                {
        //                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
        //                    return;
        //                }
        //                //判断是否有权限审核
        //                var userId = GetAdminInfo().UserID;
        //                var applyId = new BLL.declaration.ApplyRecord().GetModel(record_id).Apply_ID;

        //                if (!WebHelper.IsApplyAdminUser(applyId, userId))
        //                {
        //                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
        //                    return;
        //                }

        //                var recordBll = new BLL.declaration.ApplyRecord();
        //                var checkBll = new BLL.declaration.ApplyCheck();
        //                bool result = false;
        //                var checkMList = checkBll.GetModelList("Record_ID = " + record_id);
        //                if (checkMList.Count <= 0)
        //                {
        //                    //add
        //                    var checkM = new Model.declaration.ApplyCheck();
        //                    checkM.Check_Status = status;
        //                    checkM.Check_Comment = reason;
        //                    checkM.Check_Time = DateTime.Now;
        //                    checkM.Check_User = GetAdminInfo().UserID;
        //                    checkM.Record_ID = record_id;
        //                    var id = checkBll.Add(checkM);
        //                    if (id > 0)
        //                        result = true;
        //                }
        //                else
        //                {
        //                    //update
        //                    var checkM = checkMList[0];
        //                    checkM.Check_Status = status;
        //                    checkM.Check_Comment = reason;
        //                    checkM.Check_User = GetAdminInfo().UserID;
        //                    checkM.Check_Time = DateTime.Now;
        //                    result = checkBll.Update(checkM);
        //                }
        //                if (result)
        //                {
        //                    var recordM = recordBll.GetModel(record_id);
        //                    if (recordM.Record_Status == status) continue;
        //                    recordM.Record_Status = status;
        //                    if (recordBll.Update(recordM))
        //                    {
        //                        // FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = "审批成功！" }));
        //                        //发送提醒
        //                        var applyTitle = new BLL.declaration.ApplySubject().GetModel(applyId).Apply_Title;
        //                        PushHelper.PushWhenCheckApply(applyId, recordM.Record_User, status);
        //                    }
        //                    else
        //                    {
        //                        FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "审批失败！" }));
        //                        return;
        //                    }
        //                }
        //                else
        //                {
        //                    FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数有误，审批失败！" }));
        //                    return;
        //                }
        //            }
        //            catch
        //            {
        //                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "审批失败！" }));
        //                return;
        //            }
        //        }//循环foreach
        //        FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = "审批成功！" }));
        //    }



        //    private void DelRecord(HttpContext context)
        //    {
        //        if (!IsAdminLogin())
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "error" }));
        //            return;
        //        }
        //        long record_id = long.Parse(DESEncrypt.Decrypt(MyRequest.GetString("id")));
        //        if (record_id == 0)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数不合法！" }));
        //            return;
        //        }
        //        //判断是否有权限审核
        //        var userId = GetAdminInfo().UserID;
        //        int cnt = new BLL.declaration.ApplyRecord().GetRecordCount("Record_ID = " + record_id + " and Record_User =" + userId); //+ " and Record_User_Roleid = " + GetRoleUserId() + " and Record_User_Type =" + WebHelper.GetUserType());

        //        if (cnt <= 0)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "没有权限！" }));
        //            return;
        //        }

        //        try
        //        {
        //            var bll = new BLL.declaration.ApplyRecord();
        //            if (bll.Delete(record_id))
        //            {
        //                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = "取消申报成功！" }));
        //            }
        //            else
        //            {
        //                FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = "操作失败！" }));
        //            }
        //        }
        //        catch { FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = "操作失败！" })); }
        //    }


        //    private void GetDF(HttpContext context)
        //    {
        //        if (!IsAdminLogin())
        //        {
        //            FlushResponse(context, "请先登录");
        //            return;
        //        }
        //        int id = MyRequest.GetInt("id", -1);
        //        if (id == -1)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数错误！" }));
        //            return;
        //        }
        //        int sort = MyRequest.GetInt("sort", -1);
        //        if (sort == -1)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数错误！" }));
        //            return;
        //        }
        //        var model = new BLL.studata.StuData_DataField().GetModel(id);
        //        if (model != null)
        //        {
        //            string str = model.DF_Type + "|";
        //            str += model.DF_Name + "|";
        //            if (model.DF_Check.StartsWith("select")) str += model.DF_Check.Split('|')[1] + "|";
        //            else str += model.DF_Notice + "|";
        //            str += sort + "|";
        //            str += model.DF_Required + "|";
        //            str += model.DF_ID.ToString();
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = str }));
        //        }
        //        else
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数错误！" }));
        //            return;
        //        }
        //    }


        //    private void GetSysProperty(HttpContext context)
        //    {
        //        if (!IsAdminLogin())
        //        {
        //            FlushResponse(context, "请先登录");
        //            return;
        //        }
        //        int id = MyRequest.GetInt("id", -1);
        //        if (id == -1)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数错误！" }));
        //            return;
        //        }
        //        int sort = MyRequest.GetInt("sort", -1);
        //        if (sort == -1)
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数错误！" }));
        //            return;
        //        }
        //        var model = new BLL.declaration.SysProperty().GetModel(id);
        //        if (model != null)
        //        {
        //            string str = model.DP_Type + "|";
        //            str += model.DP_Title + "|";
        //            if (model.DP_Check.StartsWith("select")) str += model.DP_Check.Split('|')[1] + "|";
        //            else str += model.DP_Notice + "|";
        //            str += sort + "|";
        //            str += model.DP_Required + "|";
        //            str += model.DP_ID.ToString();
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = OK, Msg = str }));
        //        }
        //        else
        //        {
        //            FlushResponse(context, JsonConvert.SerializeObject(new ReturnObject() { Result = ERROR, Msg = "参数错误！" }));
        //            return;
        //        }
        //    }

        //    /// <summary>
        //    /// 判断用户是否登录
        //    /// </summary>
        //    /// <returns></returns>
        //    private bool IsAdminLogin()
        //    {
        //        //如果Session为Null
        //        if (HttpContext.Current.Session[MyKeys.SESSION_ADMIN_INFO] != null)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }

        //    /// <summary>
        //    /// 取得用户小表信息
        //    /// </summary>
        //    public int GetUserUO_ID()
        //    {
        //        if (IsAdminLogin())
        //        {
        //            if ((MyEnums.UserStatus)HttpContext.Current.Session[MyKeys.SESSION_USER_TABLE] == MyEnums.UserStatus.App_Universities_AdminUser)
        //            {
        //                Model.admin.Universities_AdminUser adminuser = new Model.admin.Universities_AdminUser();
        //                BLL.admin.Universities_AdminUser bll = new BLL.admin.Universities_AdminUser();
        //                adminuser = bll.GetModel(Convert.ToInt64(HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID]));
        //                return adminuser.UO_ID;
        //            }
        //            else if ((MyEnums.UserStatus)HttpContext.Current.Session[MyKeys.SESSION_USER_TABLE] == MyEnums.UserStatus.App_Universities_SchoolUser)
        //            {
        //                Model.admin.Universities_SchoolUser schooluser = new Model.admin.Universities_SchoolUser();
        //                BLL.admin.Universities_SchoolUser bll = new BLL.admin.Universities_SchoolUser();
        //                schooluser = bll.GetModel(Convert.ToInt64(HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID]));
        //                return schooluser.UO_ID;
        //            }
        //            else if ((MyEnums.UserStatus)HttpContext.Current.Session[MyKeys.SESSION_USER_TABLE] == MyEnums.UserStatus.App_Universities_SocialUser)
        //            {
        //                Model.admin.Universities_SocialUser socialuser = new Model.admin.Universities_SocialUser();
        //                BLL.admin.Universities_SocialUser bll = new BLL.admin.Universities_SocialUser();
        //                socialuser = bll.GetModel(Convert.ToInt64(HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID]));
        //                return socialuser.UO_ID;
        //            }
        //        }
        //        return 0;
        //    }

        //    /// <summary>
        //    /// 取得用户信息
        //    /// </summary>
        //    public Model.admin.Universities_UserInfo GetAdminInfo()
        //    {
        //        if (IsAdminLogin())
        //        {
        //            Model.admin.Universities_UserInfo model = HttpContext.Current.Session[MyKeys.SESSION_ADMIN_INFO] as Model.admin.Universities_UserInfo;
        //            if (model != null)
        //            {
        //                return model;
        //            }
        //        }
        //        return null;
        //    }

        //    /// <summary>
        //    ///获取用户身份表(即用户小表-SchoolUser、SocialUser、AdminUser)的UserId
        //    /// </summary>
        //    /// <returns></returns>
        //    public Int64 GetRoleUserId()
        //    {
        //        if (HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID] != null)
        //            return Convert.ToInt64(HttpContext.Current.Session[MyKeys.SESSION_USER_STATUSID]);
        //        return 0;
        //    }



        //    public bool IsReusable
        //    {
        //        get
        //        {
        //            return false;
        //        }
        //    }
        //}

        //class ReturnObject
        //{
        //    public long Result { get; set; }
        //    public String Msg { get; set; }
        //}

    }
}