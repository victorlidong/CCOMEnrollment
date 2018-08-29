using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.util;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using LitJson;
using Microsoft.JScript;
using Microsoft.Office.Interop.Excel;
using university.Common;
using System.Data;

namespace university.Web.AdminMetro.CCOM.StudentApply
{
    /// <summary>
    /// UpdateSchoolUser 的摘要说明
    /// </summary>
    public class UpdateUserInfor : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string fun = context.Request["fun"];
            context.Response.ContentType = "text/json";
            switch (fun)
            {
                case "TopicState":
                    context.Response.Write(UpdateTopicState());
                    break;
                case "Pass"://修改密码
                    context.Response.Write(Pass(context));
                    break;
                case "DeleteWeek":
                    context.Response.Write(DeleteWeek());
                    break;
                case "UpdateFormValue":
                    context.Response.Write(UpdateFormValue());
                    break;
                case "SutdentSubmitForm":
                    context.Response.Write(SutdentSubmitForm());
                    break;
                case "TeacherSubmitForm":
                    context.Response.Write(TeacherSubmitForm());
                    break;
                default:
                    break;
            }

        }

        protected string TeacherSubmitForm()
        {
            JsonData data = new JsonData();
            string userId = MyRequest.GetString("userid");
            string type = MyRequest.GetString("type");
            string result = MyRequest.GetString("result");
            string msg = "";
            try
            {
                var form_model = new BLL.CCOM.Form_review().GetModel(" User_id=" + userId + " and Form_type_id=" + type);
                if (form_model == null)
                {
                    msg = "学生尚未提交形式审查表！";
                }
                else
                {
                    form_model.Review_result = int.Parse(result);
                    if (!new BLL.CCOM.Form_review().Update(form_model))
                    {
                        msg = "审核失败！";
                    }
                }
            }
            catch
            {
                msg = "审核发生异常！";
            }

            if (msg == "")
            {
                data["msg"] = "审核成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string SutdentSubmitForm()
        {
            JsonData data = new JsonData();
            string userId = MyRequest.GetString("userid");
            string type = MyRequest.GetString("type");
            string msg = "";
            try
            {
                var form_model = new BLL.CCOM.Form_review().GetModel(" User_id=" + userId + " and Form_type_id=" + type);
                if (form_model == null) 
                {
                    Model.CCOM.Form_review model = new Model.CCOM.Form_review();
                    model.User_id = long.Parse(userId);
                    model.Form_type_id = int.Parse(type);
                    model.Review_result = 0;
                    if (new BLL.CCOM.Form_review().Add(model) == 0)
                    {
                        msg = "提交失败！";
                    }
                }
                else
                {
                    form_model.Review_result = 0;
                    if (!new BLL.CCOM.Form_review().Update(form_model))
                    {
                        msg = "提交失败！";
                    }
                }
            }
            catch
            {
                msg = "提交发生异常！";
            }

            if (msg == "")
            {
                data["msg"] = "提交成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string UpdateFormValue() {
            JsonData data = new JsonData();
            string userid = MyRequest.GetString("UserID");
            string formid = MyRequest.GetString("FormID");
            string selectValue = MyRequest.GetString("SelectValue");
            string msg = "";
            try
            {
                var form_value_model = new BLL.CCOM.Form_value().GetModel(" User_id=" + userid + " and Form_id=" + formid);
                if (form_value_model == null)   //增加一条记录
                {
                    Model.CCOM.Form_value value_model = new Model.CCOM.Form_value();
                    value_model.User_id = long.Parse(userid);
                    value_model.Form_id = int.Parse(formid);
                    value_model.Self_value = int.Parse(selectValue);
                    value_model.Tea_value = 0;
                    if (new BLL.CCOM.Form_value().Add(value_model) == 0) msg = "添加失败";
                }
                else//更新一条记录
                {
                    form_value_model.Self_value = int.Parse(selectValue);
                    if (!new BLL.CCOM.Form_value().Update(form_value_model)) msg = "更新失败";
                }
            }
            catch
            {
                msg = "发生异常！";
            }

            if (msg == "")
            {
                data["msg"] = "";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string DeleteWeek()
        {
            JsonData data = new JsonData();
            string id = MyRequest.GetString("ID");
            string msg = "";
            try
            {
                BLL.CCOM.Teach_week bll = new BLL.CCOM.Teach_week();
                bll.Delete(Int32.Parse(id));
            }
            catch
            {
                msg = "删除发生异常！";
            }

            if (msg == "")
            {
                data["msg"] = "删除成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string UpdateTopicState()
        {
            JsonData data = new JsonData();
            string id = MyRequest.GetString("ID");
            string myid = MyRequest.GetString("MYID");
            string msg = "";

            try
            {
                var bll = new BLL.CCOM.Topic();
                var m = bll.GetModel("Topic_id=" + id);
                Boolean isOn = m.Selected_state == true;
                m.Selected_state = isOn ^ true;

                Model.CCOM.Topic_relation rela_model;
                rela_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + myid);
                if (rela_model == null)
                {
                    rela_model = new Model.CCOM.Topic_relation();
                    rela_model.Student_id = Int64.Parse(myid);
                    rela_model.Teacher_id = m.Teacher_id;
                    rela_model.Topic_id = m.Topic_id;
                    rela_model.Apply_time = DateTime.Now;
                    rela_model.Accept_state = 0;
                    long rela_id = (new BLL.CCOM.Topic_relation()).Add(rela_model);
                    if (rela_id != 0)
                    {
                        if (bll.Update(m) == false)
                        {
                            new BLL.CCOM.Topic_relation().Delete(rela_id);
                            msg = "修改发生异常！";
                        }
                    }
                    else
                    {
                        msg = "选题发生异常！";
                    }
                }
                else
                {
                    Model.CCOM.Topic last_model = new BLL.CCOM.Topic().GetModel(rela_model.Topic_id);
                    last_model.Selected_state = false;
                    bll.Update(last_model);

                    rela_model.Student_id = Int64.Parse(myid);
                    rela_model.Teacher_id = m.Teacher_id;
                    rela_model.Topic_id = m.Topic_id;
                    rela_model.Apply_time = DateTime.Now;
                    rela_model.Accept_state = 0;
                    if (new BLL.CCOM.Topic_relation().Update(rela_model))
                    {
                        if (bll.Update(m) == false)
                        {
                            new BLL.CCOM.Topic_relation().Delete(rela_model.Topic_relation_id);
                            msg = "修改发生异常！";
                        }
                    }
                    else
                    {
                        msg = "选题发生异常！";
                    }
                }

                
            }
            catch
            {
                msg = "修改发生异常！";
            }

            if (msg == "")
            {
                data["msg"] = "修改成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string Pass(HttpContext context)
        {
            JsonData data = new JsonData();
            string _schooluserid = MyRequest.GetString("schooluserid");
            string Pass = MyRequest.GetString("pass");
            string PassConfirm = MyRequest.GetString("passconfirm");
            string msg = "";
            if (Tools.CheckParams(Pass + PassConfirm))
            {
                msg = "传输异常，存在非法字符！";
            }
            else
            {
                if (Pass.Length < 6 || Pass.Length > 16) msg = "密码长度请控制在6-16位！";
                else if (Pass != PassConfirm) msg = "两次密码输入不一致！";
                else
                {
                    try
                    {
                        BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
                        long schooluserid = long.Parse(DESEncrypt.Decrypt(_schooluserid));
                        Model.CCOM.User_information model = bll.GetModel(schooluserid);
                        model.User_password = DESEncrypt.MD5Encrypt(Pass);
                        bool res = bll.Update(model);
                        if (res == false)
                            msg = "修改失败，参数发生异常！";
                    }
                    catch (Exception)
                    {
                        msg = "修改发生异常！";
                    }
                }
            }
            if (msg == "")
            {
                data["msg"] = "修改成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}