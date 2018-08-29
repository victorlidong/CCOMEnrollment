using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace university.Web.AdminMetro.CCOM.Certificate
{
    public partial class Application_form : university.UI.ManagePage
    {
        Model.CCOM.Subject root = null;
        //报考科目
        List<int> sub = new List<int>();
        string[] str_num = { "①", "②", "③", "④", "⑤", "⑥", "⑦", "⑧", "⑨", "⑩" };
        String[,] levelCountValue = {
        {"一、","二、","三、","四、","五、","六、","七、","八、","九、","十、"},
        {"1.","2.","3.","4.","5.","6.","7.","8.","9.","10."},
        {"1)","2)","3)","4)","5)","6)","7)","8)","9)","10)"},
        {"①","②","③","④","⑤","⑥","⑦","⑧","⑨","⑩"},
        {"a.","b.","c.","d.","e.","f.","g.","h.","i.","j."},
        {"a)","b)","c)","d)","e)","f)","g)","h)","i)","j)"}
        };
        Dictionary<int, Model.CCOM.Subject> subjectDic = new Dictionary<int, Model.CCOM.Subject>();
        Dictionary<int, Dictionary<int, Model.CCOM.User_subject_value>> valueDic = new Dictionary<int, Dictionary<int, Model.CCOM.User_subject_value>>();
        //曲目builder
        StringBuilder chapterBuilder;
        public Application_form()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindData();
            }
        }

        private void bindData()
        {
            long _id = GetAdminInfo_CCOM().User_id;
            if(_id>0)
            {
                Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(_id);
                if((int)user_model.User_type!=1)
                {
                    JscriptMsg("只有考生才有打印报名表功能", "/AdminMetro/index.aspx", "Error");
                    return;
                }
                Model.CCOM.User_property property_model = new BLL.CCOM.User_property().GetModel(" User_id=" + _id);

                try
                {
                    int period = int.Parse(new BLL.CCOM.Period().GetModel(property_model.Period_id).Period_year);
                    this.title.Text = "中央音乐学院" + period + "年本科招生专业考试报名表";
                }
                catch
                {
                    JscriptMsg("考生信息出错", "/AdminMetro/index.aspx", "Error");
                    //Response.Redirect("");
                }

                if (user_model != null && property_model!=null)
                {
                    this.name.Text = user_model.User_realname;
                    this.id_number.Text = user_model.User_ID_number;
                    if(user_model.User_gender!=null&&(bool)user_model.User_gender)
                    {
                        this.gender.Text = "女";
                    }
                    else
                    {
                        this.gender.Text = "男";
                    }
                    if(user_model.User_birthday!=null)
                    {
                        this.birthday.Text = ((DateTime)user_model.User_birthday).ToString("yyyyMMdd");
                    }
                    else
                    {
                        
                        JscriptMsg("出生日期信息不全，请先完善信息再行打印", "/AdminMetro/index.aspx", "Error");
                        return;
                    }
                    
                    var nation_model = new BLL.CCOM.Nationality().GetModel(property_model.UP_nationality);
                    if(nation_model!=null)
                    {
                        this.nation.Text = nation_model.Nationality_name;
                    }
                    else
                    {
                        JscriptMsg("民族不存在", "/AdminMetro/index.aspx", "Error");
                        return;
                    }
                    
                    
                    var province_model = new BLL.CCOM.Province().GetModel(property_model.UP_province);
                    if(province_model!=null)
                    {
                        this.birth_place.Text = province_model.Province_name;
                        this.stu_province.Text = province_model.Province_name;
                    }
                    else
                    {
                        JscriptMsg("省份不存在，请先完善信息再行打印", "/AdminMetro/index.aspx", "Error");
                        return;
                    }
                    
                    if(property_model.UP_high_school!=null)
                    {
                        this.file_address.Text = property_model.UP_high_school;
                    }
                    else
                    {
                        JscriptMsg("高中院校信息不全，请先完善信息再行打印", "/AdminMetro/index.aspx", "Error");
                        return;
                    }

                    
                    var politics_model = new BLL.CCOM.Politics().GetModel(property_model.UP_politics);
                    if (politics_model != null)
                    {
                        this.politics.Text = politics_model.Politics_name;
                    }
                    else
                    {
                        JscriptMsg("政治面貌不存在，请先完善信息再行打印", "/AdminMetro/index.aspx", "Error");
                        return;
                    }
                    
                    if(property_model.UP_picture!=null)
                    {
                        this.head_pic.Src = property_model.UP_picture;
                    }
                    else
                    {
                        JscriptMsg("证件照信息不全，请先完善信息再行打印", "/AdminMetro/index.aspx", "Error");
                        return;
                    }


                    
                    var agency_model = new BLL.CCOM.Agency().GetModel(property_model.Agency_id);
                    if(agency_model!=null)
                    {
                        this.major.Text = agency_model.Agency_name;
                    }
                    else
                    {
                        JscriptMsg("专业不存在，请先完善信息再行打印", "/AdminMetro/index.aspx", "Error");
                        return;
                    }
                    
                    this.entrance_exam_number.Text = property_model.UP_CCOM_number;
                    this.stu_entrance_number.Text = property_model.UP_CCOM_number;

                    if(property_model.UP_receiver_phone!=null)
                    {
                        this.exam_phone.Text = property_model.UP_receiver_phone;
                        this.reciever_phone.Text = property_model.UP_receiver_phone; 
                    }
                    else
                    {
                        JscriptMsg("联系电话信息不全，请先完善信息再行打印", "/AdminMetro/index.aspx", "Error");
                        return;
                    }
                    if(property_model.UP_address!=null)
                    {
                        this.admit_address.Text = property_model.UP_address;
                    }
                    else
                    {
                        JscriptMsg("录取通知书邮寄地址信息不全，请先完善信息再行打印", "/AdminMetro/index.aspx", "Error");
                        return;
                    }
                    if(property_model.UP_postal_code!=null)
                    {
                        this.city_id.Text = property_model.UP_postal_code;
                    }
                    else
                    {
                        JscriptMsg("邮编信息不全，请先完善信息再行打印", "/AdminMetro/index.aspx", "Error");
                        return;
                    }
                    this.reciever.Text = user_model.User_realname;
                    this.stu_name.Text = user_model.User_realname;

                }
                else
                {
                    JscriptMsg("考生不存在", "/AdminMetro/index.aspx", "Error");
                    return;
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
                        BindSubject(Cmodel, 0, true);
                    }
                }
                StringBuilder sb = new StringBuilder();
                Model.CCOM.Subject sub_model = null;
                int flag = 0;
                for(int i=0;i<sub.Count;i++)
                {
                    sub_model = sub_bll.GetModel(sub[i]);
                    if (sub_model!=null)
                    {
                        if (flag == 1)
                        {
                            flag = 0;
                            continue;
                        }
                        if (sub_model.Value_type == 1 && flag == 0)
                        {
                            flag = 1;
                        }
                        sb.Append("<div class=\"control-group\" style=\"margin-top:5px;\"><div class=\"line\">");
                        sb.Append("<div class=\"course_name\">");
                        sb.Append("<span>");
                        sb.Append(sub_model.Subject_title);
                        sb.Append("</span>");
                        sb.Append("</div>");
                        sb.Append("<div class=\"exam_form\">");
                        sb.Append("<span>");
                        if (sub_model.Subject_type!=null&&(bool)sub_model.Subject_type)
                        {
                            sb.Append("面试");
                        }
                        else
                        {
                            sb.Append("笔试");
                        }
                        sb.Append("</span>");
                        sb.Append("</div>");


                        Label chapter=newChapterLabel(_id, sub[i]);
                        sb.Append("<div class=\"exam_song\">");
                        sb.Append(chapter.Text.ToString());
                        sb.Append("</div>");

                        sb.Append("</div></div><br>");
                        //sb.Append("<div class=\"line_decration\"></div>");
                    }
                }
                this.examination_course.InnerHtml = sb.ToString();

            }
        }


        //children:0表示不是子节点，超过0表示第几个子节点
        protected void BindSubject(Model.CCOM.Subject model, int children, bool isShow)
        {
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            int subjectId = model.Subject_id;

            if (children != 0 && model.Subject_level == 2)
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
                            BindSubject(Cmodel, -++i, isShow);
                        }
                    }
                }
                else if (model.Value_type == 1)
                {
                    //单选，绑一个
                    BindSubject(model, 1, isShow);
                }
                else if (model.Value_type == 2)
                {
                    //多选类型，有几个绑几个
                    for (int i = 1; i <= model.Value_count; i++)
                    {
                        BindSubject(model, i, isShow);
                    }
                }
            }
            else
            {

                foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                {
                    if (Cmodel.Fs_id == subjectId)
                    {
                        BindSubject(Cmodel, 0, false);
                    }
                }
            }
        }

        protected Label newChapterLabel(long userId,int sub_id)
        {
            Label chapter = new Label();
            //值字典
            valueDic.Clear();
            BLL.CCOM.User_subject_value vbll = new BLL.CCOM.User_subject_value();
            try
            {
                List<Model.CCOM.User_subject_value> valueList = vbll.GetModelList("User_id=" + userId);
                foreach (Model.CCOM.User_subject_value value in valueList)
                {
                    if (!valueDic.ContainsKey(value.Subject_id))
                    {
                        valueDic.Add(value.Subject_id, new Dictionary<int, Model.CCOM.User_subject_value>());
                    }
                    if (value.Usv_children == null)
                    {
                        valueDic[value.Subject_id].Add(0, value);
                    }
                    else
                    {
                        valueDic[value.Subject_id].Add((int)value.Usv_children, value);
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
            chapterBuilder = new StringBuilder();
            //BindChapter(subjectDic[Convert.ToInt32(ddlSubject.SelectedValue)], 0);
            BindChapter(subjectDic[sub_id], 0);
            chapter.Text = chapterBuilder.ToString();
            return chapter;
        }

        protected void BindChapter(Model.CCOM.Subject model, int children)
        {
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            int subjectId = model.Subject_id;
            if (model.Value_type == 3)
            {
                //数字
                if (children > 0)
                {
                    chapterBuilder.Append(levelCountValue[model.Subject_level - 1, Math.Abs(children) - 1]);
                }
                else if (children == 0)
                {
                    chapterBuilder.Append(levelCountValue[model.Subject_level - 1, 0]);
                }
                else
                {
                    chapterBuilder.Append(levelCountValue[model.Subject_level - 2, Math.Abs(children) - 1]);
                }
                chapterBuilder.Append(valueDic[model.Subject_id][0].Usv_value + "<br/>");
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
                            BindChapter(Cmodel, -++i);
                        }
                    }
                }
                else if (model.Value_type == 1)
                {
                    //单选，绑一个
                    BindChapter(model, 1);
                }
                else if (model.Value_type == 2)
                {
                    //多选类型，有几个绑几个
                    for (int i = 1; i <= model.Value_count; i++)
                    {
                        BindChapter(model, i);
                    }
                }
            }
            else
            {
                Model.CCOM.Subject Cmodel = subjectDic[Convert.ToInt32(valueDic[subjectId][children].Usv_value)];
                //数字
                chapterBuilder.Append(levelCountValue[Cmodel.Subject_level - 2, children - 1]);
                chapterBuilder.Append(Cmodel.Subject_title + "<br/>");
                BindChapter(Cmodel, 0);
            }
        }
    }
}