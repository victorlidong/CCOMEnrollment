using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using university.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Configuration;
namespace university.Web.AdminMetro.CCOM.Certificate
{
    public partial class Admission_ticket : university.UI.ManagePage
    {
        Model.CCOM.Subject root = null;
        //报考科目
        List<int> sub = new List<int>();
        Dictionary<int, Model.CCOM.Subject> subjectDic = new Dictionary<int, Model.CCOM.Subject>();
        public Admission_ticket()
        {
            //this.checkFunID = false;

            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindUserInfo();
            }
        }
        protected void bindUserInfo()
        {
            //int[] margin = {1,1,2,2,2,3,3,4};
            long _id = GetAdminInfo_CCOM().User_id;
            var user_model = new BLL.CCOM.User_infomation().GetModel(_id);
            if ((int)user_model.User_type != 1)
            {
                JscriptMsg("只有考生才有打印准考证功能", "/AdminMetro/index.aspx", "Error");
                return;
            }
            var property_model = new BLL.CCOM.User_property().GetModel(" User_id=" + _id);
            if (property_model != null)
            {
                if (property_model.UP_picture != null && property_model.UP_picture != "")
                {
                    if (!property_model.UP_picture.StartsWith("http"))
                    {
                        this.stu_pic.Src = DataDic.FILE_URL + property_model.UP_picture;
                    }
                    else
                    {
                        this.stu_pic.Src = property_model.UP_picture;
                    }
                }
                else
                {
                    this.stu_pic.Src = "/admin/images/default_user_avatar.gif";
                }
                try
                {
                    int period = int.Parse(new BLL.CCOM.Period().GetModel(property_model.Period_id).Period_year);
                    this.tit.Text = "中央音乐学院本科招生" + period + "年专业考试准考证";
                }
                catch
                {
                    JscriptMsg("考生信息出错", "/AdminMetro/index.aspx", "Error");
                    //Response.Redirect("");
                }
                
                this.print_time.Text = "打印时间：" + DateTime.Now.ToString("yyyy年MM月dd日");
                //var user_model = new BLL.CCOM.User_infomation().GetModel(_id);
                this.stu_name.Text = user_model.User_realname;
                this.addmission_number.Text = property_model.UP_CCOM_number;
                this.ID_number.Text = user_model.User_ID_number;
                //this.qrcode.Src = "QrCode.ashx?data=" + DESEncrypt.Encrypt(property_model.UP_CCOM_number);
                if (property_model.Agency_id >0)
                {
                    var angency_model = new BLL.CCOM.Agency().GetModel(property_model.Agency_id);
                    if (angency_model != null)
                    {
                        this.major.Text = angency_model.Agency_name;
                    }

                    //获取报考科目
                    int majorId = property_model.Agency_id;
                    //科目字典
                    BLL.CCOM.Subject sub_bll = new BLL.CCOM.Subject();
                    try
                    {
                        List<Model.CCOM.Subject> subjectList = sub_bll.GetModelList("Major_Agency_id=" + majorId);
                        foreach (Model.CCOM.Subject subject in subjectList)
                        {
                            subjectDic.Add(subject.Subject_id, subject);
                        }
                    }
                    catch (Exception e)
                    {
                        return;
                    }
                    root = sub_bll.GetModel("Major_Agency_id=" + majorId + "and Subject_level=0");
                    foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                    {
                        if (Cmodel.Fs_id == root.Subject_id)
                        {
                            BindSubject(Cmodel,0, true);
                        }
                    }


                    //获取已排考科目
                    //var exam_list = new BLL.CCOM.Examination_arrangement_detail().GetModelList(" User_id=" + GetAdminInfo_CCOM().User_id);
                    //if (exam_list != null && exam_list.Count>0)
                    //{
                    //    var bll = new BLL.CCOM.Examination_subject();
                    //    Model.CCOM.Examination_subject model = null;
                    //    for(int i=0;i<exam_list.Count;i++)
                    //    {
                    //        model = bll.GetModel(" Ea_id="+exam_list[i].Ea_id);

                    //    }
                    //}
                    //else//未有排考信息
                    //{
                    //    JscriptMsg("尚未排考完成，请等候排考结束再行打印!", "/AdminMetro/index.aspx", "Error");
                    //    return;
                    //}



                    long user_id = GetAdminInfo_CCOM().User_id;
                    int flag = 0;//记录该场考试是否已排该考生
                    StringBuilder sb = new StringBuilder();
                    BLL.CCOM.Examination_subject exam_sub_bll = new BLL.CCOM.Examination_subject();
                    BLL.CCOM.Examination_arrangement_detail exam_detail_bll = new BLL.CCOM.Examination_arrangement_detail();

                    int single = 0; //单选只输出一次
                    for (int i = 0; i < sub.Count; i++)
                    {
                        var exam_sub_model_list = exam_sub_bll.GetModelList(" Esn_id=" + sub[i]);
                        if (exam_sub_model_list != null)
                        {
                            for (int j = 0; j < exam_sub_model_list.Count; j++)
                            {
                                if (single == 1)
                                {
                                    single = 0;
                                    continue;
                                }
                                if (new BLL.CCOM.Subject().GetModel(sub[i]).Value_type == 1 && single == 0)
                                {
                                    single = 1;
                                }

                                flag = 0;
                                var detail_model_list = exam_detail_bll.GetModelList(" Ea_id=" + exam_sub_model_list[j].Ea_id);
                                for (int k = 0; k < detail_model_list.Count; k++)
                                {
                                    if (detail_model_list[k].User_id == user_id)
                                    {
                                        
                                        flag = 1;
                                        var model = new BLL.CCOM.Examination_arrangement().GetModel(" Ea_id=" + detail_model_list[k].Ea_id);
                                        string st_time = model.Ea_starttime.ToString("MM月dd日hh:mm");
                                        //st_time = st_time.Substring(0, st_time.Length - 6);
                                        string end_time = ((DateTime)model.Ea_endtime).ToString("hh:mm");
                                        var room = new BLL.CCOM.Examination_room().GetModel(model.Ea_room);
                                        
                                        sb.Append("<div class=\"exam_line\">");
                                        sb.Append("<div class=\"course\">");
                                        sb.Append("<span>");
                                        sb.Append(model.Ea_name);
                                        sb.Append("</span>");
                                        sb.Append("</div>");
                                        sb.Append("<div class=\"arrange\">");
                                        sb.Append("<span>");
                                        sb.Append(st_time+"-"+end_time);
                                        sb.Append("</span>");
                                        sb.Append("<br />");
                                        sb.Append("<span >");
                                        sb.Append("考场："+room.Er_building+room.Er_room);
                                        if (model.Ea_restroom != null)
                                        {
                                            var rest_room = new BLL.CCOM.Examination_room().GetModel((int)model.Ea_restroom);
                                            sb.Append(" 候考场：" + room.Er_building +    room.Er_room);
                                        }
                                        sb.Append("</span>");
                                        sb.Append(" </div>");
                                        sb.Append(" </div>");

                                        break;
                                    }
                                }
                                if (flag == 0)//该科目尚未排考
                                {

                                }
                            }
                        }
                    }
                    this.exam_info.InnerHtml=sb.ToString();
                }
                if (user_model.User_gender != null)
                {
                    if ((bool)user_model.User_gender)
                    {
                        this.gender.Text = "女";
                    }
                    else
                    {
                        this.gender.Text = "男";
                    }
                }
            }
            else
            {
                JscriptMsg("考生不存在", "", "Error");
                return;
            }
        }
        
        
        //children:0表示不是子节点，超过0表示第几个子节点
        protected void BindSubject(Model.CCOM.Subject model, int children, bool isShow)
        {
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            int subjectId = model.Subject_id;
            
            if (children != 0&&model.Subject_level==2)
            {
                sub.Add(model.Subject_id);
            }
            if (children <= 0)
            {
               
                //子节点
                if (model.Value_type == 0)
                {
                    int i = 0;
                    //多项类型，往下Bind
                    foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                    {
                        if (Cmodel.Fs_id == model.Subject_id)
                        {
                            BindSubject(Cmodel,  -++i, isShow);
                        }
                    }
                }
                else if (model.Value_type == 1)
                {
                    //单选，绑一个
                    BindSubject(model,  1, isShow);
                }
                else if (model.Value_type == 2)
                {
                    //多选类型，有几个绑几个
                    for (int i = 1; i <= model.Value_count; i++)
                    {
                        BindSubject(model,  i, isShow);
                    }
                }
            }
            else
            {
                
                foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                {
                    if (Cmodel.Fs_id == subjectId)
                    {
                        BindSubject(Cmodel,  0, false);
                    }
                }
            }
        }


        

        protected void export_word(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.BufferOutput = true;
            ////设置Http的头信息,编码格式  
            //HttpContext.Current.Response.Buffer = true;
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.Charset = "gb2312";
            //HttpContext.Current.Response.ClearContent();
            //HttpContext.Current.Response.ClearHeaders();
            //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            //HttpContext.Current.Response.ContentType = "application/ms-word";
            //HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=fileDown.doc");
            ////关闭控件的视图状态  ,如果仍然为true，RenderControl将启用页的跟踪功能，存储与控件有关的跟踪信息
            //this.EnableViewState = false;
            ////print_div.EnableViewState = false;
            //System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ZH-CN", true);
            //System.IO.StringWriter stringWriter = new System.IO.StringWriter(cultureInfo);
            //System.Web.UI.HtmlTextWriter textWriter = new System.Web.UI.HtmlTextWriter(stringWriter);
            //print_div.RenderControl(textWriter);
            //// //把HTML写回浏览器
            //HttpContext.Current.Response.Write(stringWriter.ToString());
            //HttpContext.Current.Response.End();

        }

        protected void export_pdf(object sender, EventArgs e)
        {
           
        }
    }
}