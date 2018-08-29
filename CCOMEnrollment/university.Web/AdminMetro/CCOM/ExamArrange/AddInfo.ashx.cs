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

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    /// <summary>
    /// UpdateSchoolUser 的摘要说明
    /// </summary>
    public class AddInfo : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            string fun = context.Request["fun"];
            context.Response.ContentType = "text/json";
            switch (fun)
            {
                case "AddStudent":
                    context.Response.Write(AddStudent());
                    break;
                case "RemoveStudent":
                    context.Response.Write(RemoveStudent());
                    break;
                case "BatchAddStudent":
                    context.Response.Write(BatchAddStudent());
                    break;
                case "BatchRemoveStudent":
                    context.Response.Write(BatchRemoveStudent());
                    break;
                case "AddTeacher":
                    context.Response.Write(AddTeacher());
                    break;
                case "RemoveTeacher":
                    context.Response.Write(RemoveTeacher());
                    break;
                case "BatchAddTeacher":
                    context.Response.Write(BatchAddTeacher());
                    break;
                case "BatchRemoveTeacher":
                    context.Response.Write(BatchRemoveTeacher());
                    break;
                default:
                    break;
            }

        }

        protected string BatchRemoveStudent()
        {
            JsonData data = new JsonData();
            string Group_id = MyRequest.GetString("GroupID");
            string value = MyRequest.GetString("StudentID");
            string msg = "";
            if (Tools.CheckParams(Group_id + value))
            {
                msg = "传输异常，存在非法字符！";
            }
            else if (value == "")
            {
                msg = "参数异常！";
            }
            else
            {
                try
                {
                    value = Utils.DelLastComma(value);
                    string[] list = value.Split(',');
                    foreach (var tmp in list)
                    {
                        long userid = long.Parse(tmp);
                        int groupid = int.Parse(Group_id);
                        BLL.CCOM.Reply_student bll = new BLL.CCOM.Reply_student();
                        Model.CCOM.Reply_student model = bll.GetModel(" Group_id=" + groupid + " and User_id=" + userid);
                        if (msg == "")
                        {
                            if (model == null) continue;
                            else
                            {
                                if (!bll.Delete(model.Rs_id)) msg = "移除失败";
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    msg = "移除发生异常！";
                }
            }
            if (msg == "")
            {
                data["msg"] = "移除成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string BatchAddStudent()
        {
            JsonData data = new JsonData();
            string Group_id = MyRequest.GetString("GroupID");
            string User_id_List = MyRequest.GetString("StudentID");
            string msg = "";
            if (Tools.CheckParams(Group_id + User_id_List))
            {
                msg = "传输异常，存在非法字符！";
            }
            else if (User_id_List == "")
            {
                msg = "参数异常！";
            }
            else
            {
                try
                {
                    User_id_List = Utils.DelLastComma(User_id_List);
                    string[] list = User_id_List.Split(',');
                    foreach (var tmp in list)
                    {
                        long userid = long.Parse(tmp);
                        long groupid = long.Parse(Group_id);

                        var user_model = new BLL.CCOM.User_information().GetModel(userid);
                        //判断学生是否已经选题
                        var topic_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userid + " and Accept_state=1");
                        if (topic_model == null) msg = user_model.User_realname + "尚未选择毕设题目！";

                        BLL.CCOM.Reply_student bll = new BLL.CCOM.Reply_student();
                        Model.CCOM.Reply_student model = bll.GetModel(" Group_id=" + groupid + " and User_id=" + userid);
                        if (msg == "")
                        {
                            if (model != null) continue;
                            else
                            {
                                bool isIn = true;
                                var student_models = new BLL.CCOM.Reply_student().GetModelList(" User_id=" + userid);
                                var group_model = new BLL.CCOM.Reply_group().GetModel(long.Parse(Group_id));
                                Model.CCOM.Reply_group other_model = null; ;
                                foreach (Model.CCOM.Reply_student student_model in student_models)
                                {
                                    if (new BLL.CCOM.Reply_group().GetModel(student_model.Group_id).Group_type.Equals(group_model.Group_type))
                                    {
                                        isIn = false;
                                        other_model = new BLL.CCOM.Reply_group().GetModel(student_model.Group_id);
                                        break;
                                    }
                                }

                                if (isIn)
                                {
                                    model = new Model.CCOM.Reply_student();
                                    model.Group_id = groupid;
                                    model.User_id = userid;
                                    if (bll.Add(model) <= 0) msg = "添加失败";
                                }
                                else
                                {
                                    string name = new BLL.CCOM.User_information().GetModel(userid).User_realname;
                                    msg = "学生" + name + "已在" + other_model.Group_name + "答辩组中";
                                }
                                
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    msg = "添加发生异常！";
                }
            }
            if (msg == "")
            {
                data["msg"] = "添加成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string RemoveStudent()
        {
            JsonData data = new JsonData();
            string Group_id = MyRequest.GetString("GroupID");
            string User_id = MyRequest.GetString("StudentID");
            string msg = "";
            if (Tools.CheckParams(Group_id + User_id))
            {
                msg = "传输异常，存在非法字符！";
            }
            else
            {
                try
                {
                    long userid = long.Parse(User_id);
                    int groupid = int.Parse(Group_id);
                    BLL.CCOM.Reply_student bll = new BLL.CCOM.Reply_student();
                    Model.CCOM.Reply_student model = bll.GetModel(" Group_id=" + groupid + " and User_id=" + userid);
                    if (msg == "")
                    {
                        if (model == null) msg = "学生不在该答辩组中";
                        else
                        {
                            if (!bll.Delete(model.Rs_id)) msg = "移除失败";
                        }
                    }
                }
                catch (Exception)
                {
                    msg = "移除发生异常！";
                }
            }
            if (msg == "")
            {
                data["msg"] = "移除成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string AddStudent()
        {
            JsonData data = new JsonData();
            string Group_id = MyRequest.GetString("GroupID");
            string User_id = MyRequest.GetString("StudentID");
            string msg = "";
            if (Tools.CheckParams(Group_id + User_id))
            {
                msg = "传输异常，存在非法字符！";
            }
            else
            {
                try
                {
                    long userid = long.Parse(User_id);
                    long groupid = long.Parse(Group_id);

                    //判断学生是否已经选题
                    var topic_model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + userid + " and Accept_state=1");
                    if (topic_model == null) msg = "该同学尚未选择毕设题目！";

                    BLL.CCOM.Reply_student bll = new BLL.CCOM.Reply_student();
                    Model.CCOM.Reply_student model = bll.GetModel(" Group_id=" + groupid + " and User_id=" + userid);
                    if (msg == "")
                    {
                        if (model != null) msg = "学生已在该答辩组中";
                        else
                        {
                            bool isIn = true;
                            var student_models = new BLL.CCOM.Reply_student().GetModelList(" User_id=" + User_id);
                            var group_model = new BLL.CCOM.Reply_group().GetModel(long.Parse(Group_id));
                            Model.CCOM.Reply_group other_model = null; ;
                            foreach (Model.CCOM.Reply_student student_model in student_models)
                            {
                                if (new BLL.CCOM.Reply_group().GetModel(student_model.Group_id).Group_type.Equals(group_model.Group_type))
                                {
                                    isIn = false;
                                    other_model = new BLL.CCOM.Reply_group().GetModel(student_model.Group_id);
                                    break;
                                }
                            }

                            if (isIn)
                            {
                                model = new Model.CCOM.Reply_student();
                                model.Group_id = groupid;
                                model.User_id = userid;
                                if (bll.Add(model) <= 0) msg = "添加失败";
                            }
                            else
                            {
                                string name = new BLL.CCOM.User_information().GetModel(userid).User_realname;
                                msg = "学生" + name + "已在" + other_model.Group_name + "答辩组中";
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    msg = "添加发生异常！";
                }
            }
            if (msg == "")
            {
                data["msg"] = "添加成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string BatchRemoveTeacher()
        {
            JsonData data = new JsonData();
            string Group_id = MyRequest.GetString("GroupID");
            string value = MyRequest.GetString("StudentID");
            string msg = "";
            if (Tools.CheckParams(Group_id + value))
            {
                msg = "传输异常，存在非法字符！";
            }
            else if (value == "")
            {
                msg = "参数异常！";
            }
            else
            {
                try
                {
                    value = Utils.DelLastComma(value);
                    string[] list = value.Split(',');
                    foreach (var tmp in list)
                    {
                        long userid = long.Parse(tmp);
                        int groupid = int.Parse(Group_id);
                        BLL.CCOM.Reply_commission bll = new BLL.CCOM.Reply_commission();
                        Model.CCOM.Reply_commission model = bll.GetModel(" Group_id=" + groupid + " and User_id=" + userid);
                        if (msg == "")
                        {
                            if (model == null) continue;
                            else
                            {
                                if (!bll.Delete(model.Rc_id)) msg = "移除失败";
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    msg = "移除发生异常！";
                }
            }
            if (msg == "")
            {
                data["msg"] = "移除成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string BatchAddTeacher()
        {
            JsonData data = new JsonData();
            string Group_id = MyRequest.GetString("GroupID");
            string User_id_List = MyRequest.GetString("TeacherID");
            string msg = "";
            if (Tools.CheckParams(Group_id + User_id_List))
            {
                msg = "传输异常，存在非法字符！";
            }
            else if (User_id_List == "")
            {
                msg = "参数异常！";
            }
            else
            {
                try
                {
                    User_id_List = Utils.DelLastComma(User_id_List);
                    string[] list = User_id_List.Split(',');
                    foreach (var tmp in list)
                    {
                        long userid = long.Parse(tmp);
                        long groupid = long.Parse(Group_id);
                        BLL.CCOM.Reply_commission bll = new BLL.CCOM.Reply_commission();
                        Model.CCOM.Reply_commission model = bll.GetModel(" Group_id=" + groupid + " and User_id=" + userid);
                        if (msg == "")
                        {
                            if (model != null) continue;
                            else
                            {
                                model = new Model.CCOM.Reply_commission();
                                model.Group_id = groupid;
                                model.User_id = userid;
                                if (bll.Add(model) <= 0) msg = "添加失败";
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    msg = "添加发生异常！";
                }
            }
            if (msg == "")
            {
                data["msg"] = "添加成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string RemoveTeacher()
        {
            JsonData data = new JsonData();
            string Group_id = MyRequest.GetString("GroupID");
            string User_id = MyRequest.GetString("TeacherID");
            string msg = "";
            if (Tools.CheckParams(Group_id + User_id))
            {
                msg = "传输异常，存在非法字符！";
            }
            else
            {
                try
                {
                    long userid = long.Parse(User_id);
                    int groupid = int.Parse(Group_id);
                    BLL.CCOM.Reply_commission bll = new BLL.CCOM.Reply_commission();
                    Model.CCOM.Reply_commission model = bll.GetModel(" Group_id=" + groupid + " and User_id=" + userid);
                    if (msg == "")
                    {
                        if (model == null) msg = "教师不在该答辩组中";
                        else
                        {
                            if (!bll.Delete(model.Rc_id)) msg = "移除失败";
                        }
                    }
                }
                catch (Exception)
                {
                    msg = "移除发生异常！";
                }
            }
            if (msg == "")
            {
                data["msg"] = "移除成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        protected string AddTeacher()
        {
            JsonData data = new JsonData();
            string Group_id = MyRequest.GetString("GroupID");
            string User_id = MyRequest.GetString("TeacherID");
            string msg = "";
            if (Tools.CheckParams(Group_id + User_id))
            {
                msg = "传输异常，存在非法字符！";
            }
            else
            {
                try
                {
                    long userid = long.Parse(User_id);
                    long groupid = long.Parse(Group_id);
                    BLL.CCOM.Reply_commission bll = new BLL.CCOM.Reply_commission();
                    Model.CCOM.Reply_commission model = bll.GetModel(" Group_id=" + groupid + " and User_id=" + userid);
                    if (msg == "")
                    {
                        if (model != null) msg = "教师已在该答辩组中";
                        else
                        {
                            model = new Model.CCOM.Reply_commission();
                            model.Group_id = groupid;
                            model.User_id = userid;
                            if (bll.Add(model) <= 0) msg = "添加失败";
                        }
                    }
                }
                catch (Exception)
                {
                    msg = "添加发生异常！";
                }
            }
            if (msg == "")
            {
                data["msg"] = "添加成功";
                data["code"] = 1;
            }
            else
            {
                data["msg"] = msg;
                data["code"] = 0;
            }
            return data.ToJson();
        }

        //protected string AddExam() {
        //    JsonData data = new JsonData();
        //    string Name = MyRequest.GetString("Name");
        //    string Buliding = MyRequest.GetString("Buliding");
        //    string Floor = MyRequest.GetString("Floor");
        //    string Room = MyRequest.GetString("Room");
        //    string ExamID = MyRequest.GetString("ExamID");
        //    string RestBuilding = MyRequest.GetString("RestBuilding");
        //    string RestFloor = MyRequest.GetString("RestFloor");
        //    string RestRoom = MyRequest.GetString("RestRoom");
        //    string StartTime = MyRequest.GetString("StartTime");
        //    string EndTime = MyRequest.GetString("EndTime");
        //    string Subject = MyRequest.GetString("Subject");
        //    string msg = "";
        //    DateTime start = DateTime.Now, end = DateTime.Now;
        //    try
        //    {
        //        start = System.Convert.ToDateTime(StartTime);
        //        end = System.Convert.ToDateTime(EndTime);
        //    }
        //    catch {
        //        msg = "时间格式异常！";
        //    }

        //    if (Tools.CheckParams(Name + Buliding + Floor + Room + RestBuilding + RestFloor + RestRoom + StartTime + EndTime + Subject))
        //    {
        //        msg = "传输异常，存在非法字符！";
        //    }
        //    else if (msg == "" && DateTime.Compare(start, end) >= 0)
        //    {
        //        msg = "开始时间必须小于结束时间！";
        //    }
        //    else if(msg == "")
        //    {
        //        try
        //        {
        //            if (ExamID == "0" || ExamID == "")
        //            {
        //                BLL.CCOM.Examination_arrangement bll = new BLL.CCOM.Examination_arrangement();
        //                Model.CCOM.Examination_arrangement model = new Model.CCOM.Examination_arrangement();
        //                model.Ea_name = Name;
        //                model.Ea_starttime = System.Convert.ToDateTime(StartTime);
        //                model.Ea_endtime = System.Convert.ToDateTime(EndTime);

        //                model.Ea_room = new BLL.CCOM.Examination_room().GetModel(" Er_building='" + Buliding
        //                    + "' and Er_floor='" + Floor + "' and Er_room='" + Room + "'").Er_id;
        //                model.Ea_restroom = new BLL.CCOM.Examination_room().GetModel(" Er_building='" + RestBuilding
        //                    + "' and Er_floor='" + RestFloor + "' and Er_room='" + RestRoom + "'").Er_id;

        //                msg = checkPlace(model.Ea_room, start, end, 0);
        //                if (msg == "")
        //                {
        //                    model.Group_id = bll.Add(model);
        //                    if (model.Group_id > 0)
        //                    {
        //                        Model.CCOM.Examination_subject subject_model = new Model.CCOM.Examination_subject();
        //                        string[] names = Subject.Split('|');
        //                        int result = 0;
        //                        int i = 0;
        //                        foreach (string name in names)
        //                        {
        //                            if (name == "") continue;
        //                            subject_model.Group_id = model.Group_id;
        //                            subject_model.Esn_id = int.Parse(name);

        //                            result = new BLL.CCOM.Examination_subject().Add(subject_model);
        //                            if (result == 0)
        //                                break;
        //                        }

        //                        if (result == 0)
        //                        {
        //                            msg = "科目添加失败！";
        //                        }
        //                    }
        //                    else msg = "添加失败，输入异常！";
        //                }
        //            }
        //            else {
        //                BLL.CCOM.Examination_arrangement bll = new BLL.CCOM.Examination_arrangement();
        //                Model.CCOM.Examination_arrangement model = bll.GetModel(" Group_id=" + ExamID);
        //                if (model != null)
        //                {
        //                    model.Ea_name = Name;
        //                    model.Ea_starttime = System.Convert.ToDateTime(StartTime);
        //                    model.Ea_endtime = System.Convert.ToDateTime(EndTime);

        //                    model.Ea_room = new BLL.CCOM.Examination_room().GetModel(" Er_building='" + Buliding
        //                        + "' and Er_floor='" + Floor + "' and Er_room='" + Room + "'").Er_id;
        //                    model.Ea_restroom = new BLL.CCOM.Examination_room().GetModel(" Er_building='" + RestBuilding
        //                        + "' and Er_floor='" + RestFloor + "' and Er_room='" + RestRoom + "'").Er_id;

        //                    msg = checkPlace(model.Ea_room, start, end, int.Parse(ExamID));
        //                    if (msg == "")
        //                    {
        //                        if (bll.Update(model))
        //                        {
        //                            BLL.CCOM.Examination_subject subject_bll = new BLL.CCOM.Examination_subject();
        //                            subject_bll.Delete(" Group_id='" + model.Group_id + "'");
        //                            Model.CCOM.Examination_subject subject_model = new Model.CCOM.Examination_subject();
        //                            string[] names = Subject.Split('|');
        //                            int result = 0;
        //                            int i = 0;
        //                            foreach (string name in names)
        //                            {
        //                                if (name == "") continue;
        //                                subject_model.Group_id = model.Group_id;
        //                                subject_model.Esn_id = int.Parse(name);

        //                                result = new BLL.CCOM.Examination_subject().Add(subject_model);
        //                                if (result == 0)
        //                                    break;
        //                            }

        //                            if (result == 0)
        //                            {
        //                                msg = "科目修改失败！";
        //                            }
        //                        }
        //                        else msg = "修改失败，输入异常！";
        //                    }
        //                }
        //                else
        //                { 
        //                    msg = "修改发生异常！";
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            if (ExamID == "0" || ExamID == "") msg = "添加发生异常！";
        //            else msg = "修改发生异常！";
        //        }
        //    }
        //    if (msg == "")
        //    {
        //        if (ExamID == "0" || ExamID == "") data["msg"] = "添加成功";
        //        else data["msg"] = "修改成功";
        //        data["code"] = 1;
        //    }
        //    else
        //    {
        //        data["msg"] = msg;
        //        data["code"] = 0;
        //    }
        //    return data.ToJson();
        //}

        //protected string checkPlace(int placeid, DateTime start, DateTime end, int id) {
        //    BLL.CCOM.Examination_arrangement bll = new BLL.CCOM.Examination_arrangement();
        //    string msg = "";
        //    var models = bll.GetModelList(" ");
        //    foreach (Model.CCOM.Examination_arrangement model in models)
        //    {
        //        if (model.Group_id == id) continue;
        //        if (model.Ea_room == placeid) {
        //            if (DateTime.Compare(start, (DateTime)model.Ea_endtime) > 0 || DateTime.Compare(end, model.Ea_starttime) < 0)
        //            {
        //                continue;
        //            }
        //            else {
        //                msg = "设置时间与其他考试冲突，请修改考试时间";
        //                break;
        //            }
        //        }
        //    }
        //    return msg;
        //}

        //protected string addSubject() {
        //    string Oragin = MyRequest.GetString("Oragin");
        //    string Subject = MyRequest.GetString("Subject");
        //    string msg = "";
        //    if (Tools.CheckParams(Oragin + Subject))
        //    {
        //        msg = "传输异常，存在非法字符！";
        //    }
        //    else if (Oragin == "")
        //    {
        //        msg = "请选择专业方向！";
        //    }
        //    else if (Subject == "")
        //    {
        //        msg = "请选择科目！";
        //    }
        //    else if (Oragin == "0" )
        //    {
        //        msg = "请选择正确的专业方向！";
        //    }
        //    else if (Subject == "0")
        //    {
        //        msg = "请选择正确的科目！";
        //    }
        //    else
        //    {
        //        try
        //        {
        //            Model.CCOM.Agency agency_model = new BLL.CCOM.Agency().GetModel(Utils.StrToInt(Oragin, -1));
        //            Model.CCOM.Subject subject_model = new BLL.CCOM.Subject().GetModel(Utils.StrToInt(Subject, -1));
        //            if (agency_model == null)
        //            {
        //                msg = "请选择正确的专业方向！";
        //            }
        //            if (subject_model == null)
        //            {
        //                msg = "请选择正确的科目！";
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            msg = "添加发生异常！";
        //        }
        //    }
        //    if (msg == "")
        //    {
        //        Model.CCOM.Agency agency_model = new BLL.CCOM.Agency().GetModel(Utils.StrToInt(Oragin, -1));
        //        Model.CCOM.Subject subject_model = new BLL.CCOM.Subject().GetModel(Utils.StrToInt(Subject, -1));
        //        return "<input name=\"dep\" type=\"text\" data-id=\"" + Subject + "\" value=" + agency_model.Agency_name + "--" + subject_model.Subject_title + " readonly=\"true\" style=\"width: 205px;margin-top:5px;\" /><br/>";
        //        //return "<input name=\"dep\" type=\"text\" data-id=\"" + Subject + "\" value=" + Oragin + "--" + Subject + " readonly=\"true\" style=\"width: 205px;margin-top:5px;\" /><br/>";
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        //protected string getSubject() {
        //    string rtnstr = "";
        //    string Agency = MyRequest.GetString("Agency");
        //    string Manager = MyRequest.GetString("Manager");

        //    BLL.CCOM.Period per_bll = new BLL.CCOM.Period();
        //    Model.CCOM.Period per_model = per_bll.GetModel(" Period_state=1");
        //    if (per_model != null)
        //    {
        //        string agency_group = GetSonUOList(Utils.StrToInt(Agency, -1));
        //        string[] agencys = agency_group.Split(',');
        //        string subject_group = "";
        //        for (int i = 0; i < agencys.Length; i++)
        //        {
        //            string agency = agencys[i];
        //            var subject_models = new BLL.CCOM.Subject().GetModelList(" Major_Agency_id=" + agency + " and Subject_level=2");
        //            foreach (Model.CCOM.Subject subject_model in subject_models)
        //            {
        //                if (subject_model.Manage_Agency_id == Utils.StrToInt(Manager, -1)) subject_group += subject_model.Subject_id + ",";
        //            }
        //        }
        //        if (subject_group != "") subject_group = Utils.DelLastComma(subject_group);

        //        DropDownList ddl = new DropDownList();
        //        ddl.DataSource = new BLL.CCOM.Subject().GetList(" Subject_id in (" + subject_group + ")");
        //        ddl.DataTextField = "Subject_title";
        //        ddl.DataValueField = "Subject_id";
        //        ddl.DataBind();
        //        ddl.Items.Insert(0, new ListItem("请选择", "0"));

        //        foreach (ListItem item in ddl.Items)
        //        {
        //            rtnstr += "<option value=\"" + item.Value + "\" >" + item.Text + "</option>";
        //        }
        //        return rtnstr;
        //    }
        //    else {
        //        return "<option value=\"0\" >请开启报考周期</option>";
        //    }
        //}

        ////得到指定部门下所有的机构列表
        //public string GetSonUOList(int UO_ID)
        //{
        //    string res = "";
        //    if (new BLL.CCOM.Agency().GetModel(UO_ID).Agency_type == 3)
        //        res += UO_ID.ToString() + ",";
        //    List<Model.CCOM.Agency> modellist = new BLL.CCOM.Agency().GetModelList(" Agency_father = " + UO_ID + " and Agency_status=1");
        //    foreach (Model.CCOM.Agency model in modellist)
        //    {
        //        res += GetSonUOList(model.Agency_id) + ",";
        //    }
        //    if (res != "") return Utils.DelLastComma(res);
        //    else return "0";
        //}

        //protected string getNumber()
        //{
        //    string building = MyRequest.GetString("building");
        //    string floor = MyRequest.GetString("floor");
        //    string room = MyRequest.GetString("room");

        //    BLL.CCOM.Examination_room bll = new BLL.CCOM.Examination_room();
        //    Model.CCOM.Examination_room model = bll.GetModel(" Er_building='" + building + "' and Er_floor='" + floor + "' and Er_room='" + room + "'");

        //    return "<b style=\"color: red;\">容量：" + model.Er_capacity + "</b>";
        //}

        //protected string getRoom()
        //{
        //    string rtnstr = "";
        //    string building = MyRequest.GetString("building");
        //    string floor = MyRequest.GetString("floor");

        //    DropDownList ddl = new DropDownList();
        //    BLL.CCOM.Examination_room bll = new BLL.CCOM.Examination_room();
        //    ddl.DataSource = bll.GetList(" Er_building='" + building + "' and Er_floor='" + floor + "'");
        //    ddl.DataTextField = "Er_room";
        //    ddl.DataValueField = "Er_room";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem("请选择", "0"));

        //    foreach (ListItem item in ddl.Items)
        //    {
        //        rtnstr += "<option value=\"" + item.Value + "\" >" + item.Text + "</option>";
        //    }
        //    return rtnstr;
        //}

        //protected string getFloor()
        //{
        //    string rtnstr = "";
        //    string id = MyRequest.GetString("depid");
        //    DropDownList ddl = new DropDownList();
        //    BLL.CCOM.Examination_room bll = new BLL.CCOM.Examination_room();
        //    ddl.DataSource = bll.GetList(" Er_building='" + id + "'");
        //    ddl.DataTextField = "Er_floor";
        //    ddl.DataValueField = "Er_floor";
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, new ListItem("请选择", "0"));

        //    foreach (ListItem item in ddl.Items)
        //    {
        //        if (!rtnstr.Contains(item.Text + "层"))
        //        { 
        //            rtnstr += "<option value=\"" + item.Value + "\" >" + item.Text + "层</option>";
        //        }
        //    }
        //    return rtnstr;
        //}

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}