using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class ExamMarkingTable : university.UI.ManagePage
    {
        String[,] levelCountValue = {
        {"一、","二、","三、","四、","五、","六、","七、","八、","九、","十、"},
        {"1.","2.","3.","4.","5.","6.","7.","8.","9.","10."},
        {"1)","2)","3)","4)","5)","6)","7)","8)","9)","10)"},
        {"①","②","③","④","⑤","⑥","⑦","⑧","⑨","⑩"},
        {"a.","b.","c.","d.","e.","f.","g.","h.","i.","j."},
        {"a)","b)","c)","d)","e)","f)","g)","h)","i)","j)"}
        };
        public string periodYear;
        public int examId;
        public string examInfo = "";
        Dictionary<int, Model.CCOM.Subject> subjectDic = new Dictionary<int, Model.CCOM.Subject>();
        Dictionary<int, Dictionary<int, Model.CCOM.User_subject_value>> valueDic = new Dictionary<int, Dictionary<int, Model.CCOM.User_subject_value>>();
        //曲目builder
        StringBuilder chapterBuilder;
        public ExamMarkingTable()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.CCOM.Period pbll = new BLL.CCOM.Period();
            var pmodel = pbll.GetModel("Period_state=1");
            periodYear = pmodel.Period_year;
            examId = Convert.ToInt32(DESEncrypt.Decrypt(MyRequest.GetQueryString("examId")));
            //examId = 21;
            BLL.CCOM.Examination_arrangement bll = new BLL.CCOM.Examination_arrangement();
            var model = bll.GetModel(examId);
            var roomModel = new BLL.CCOM.Examination_room().GetModel(model.Ea_room);
            examInfo += model.Ea_name + "  " + model.Ea_starttime.ToString("M月d日 hh:mm") + "    " + roomModel.Er_building + roomModel.Er_room;
            if (!IsPostBack)
            {
                BindSubject();
            }
        }

        protected void BindSubject()
        {
            BLL.CCOM.Subject ebll = new BLL.CCOM.Subject();
            DataSet ds = ebll.GetList("Subject_id IN (SELECT Esn_id FROM dbo.Examination_subject WHERE Ea_id = '" + examId + "')");
            this.ddlSubject.DataSource = ds.Tables[0].DefaultView;
            this.ddlSubject.DataTextField = "Subject_title";
            this.ddlSubject.DataValueField = "Subject_id";
            this.ddlSubject.DataBind();
            ListItem item = new ListItem("--请选择科目--", "#");
            this.ddlSubject.Items.Insert(0, item);
        }

        protected void showStudentInfo()
        {
            BLL.CCOM.User_information ubll = new BLL.CCOM.User_information();
            BLL.CCOM.User_property pbll = new BLL.CCOM.User_property();
            List<Model.CCOM.Examination_arrangement_detail> EadList = new BLL.CCOM.Examination_arrangement_detail().GetModelList(" Ea_id=" + examId);
            int num = 0;
            foreach (Model.CCOM.Examination_arrangement_detail EadModel in EadList)
            {
                TableRow studentRow = new TableRow();
                studentTable.Rows.Add(studentRow);
                var umodel = ubll.GetModel(EadModel.User_id);
                var pmodel = pbll.GetModel("User_id=" + EadModel.User_id);
                TableCell numCell = new TableCell();
                numCell.HorizontalAlign = HorizontalAlign.Center;
                studentRow.Cells.Add(numCell);
                TableCell idCell = new TableCell();
                idCell.HorizontalAlign = HorizontalAlign.Center;
                studentRow.Cells.Add(idCell);
                TableCell nameCell = new TableCell();
                nameCell.HorizontalAlign = HorizontalAlign.Center;
                studentRow.Cells.Add(nameCell);
                TableCell scoreCell = new TableCell();
                scoreCell.HorizontalAlign = HorizontalAlign.Center;
                studentRow.Cells.Add(scoreCell);
                TableCell chapterCell = new TableCell();
                studentRow.Cells.Add(chapterCell);
                Label numLabel = new Label();
                numLabel.Text = (++num).ToString();
                numCell.Controls.Add(numLabel);
                Label upCcomNum = new Label();
                upCcomNum.Text = pmodel.UP_CCOM_number;
                idCell.Controls.Add(upCcomNum);
                Label name = new Label();
                name.Text = umodel.User_realname;
                nameCell.Controls.Add(name);
                Label chapter = newChapterLabel(umodel.User_id);
                chapterCell.Controls.Add(chapter);
            }
        }

        protected Label newChapterLabel(long userId)
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
            BindChapter(subjectDic[Convert.ToInt32(ddlSubject.SelectedValue)], 0);
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
                BindChapter(Cmodel, -1);
            }
        }

        /*protected void exportword_ServerClick(object sender, EventArgs e)
        {
            Response.Clear();
            Response.BufferOutput = true;
            //设定输出的字符集
            Response.Charset = "GB2312";
            //假定导出的文件名为FileName.doc
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + "作曲专业：初试分数" + ".doc");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            ////设置导出文件的格式
            Response.ContentType = "application/ms-word";
            //关闭ViewState
            // GrwResult.EnableViewState = false;
            exportRoom.EnableViewState = false;
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ZH-CN", true);
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(cultureInfo);
            System.Web.UI.HtmlTextWriter textWriter = new System.Web.UI.HtmlTextWriter(stringWriter);

            exportRoom.RenderControl(textWriter);
            //   GrwResult.RenderControl(textWriter);

            // //把HTML写回浏览器
            Response.Write(stringWriter.ToString());
            Response.End();

            /*Object Nothing = System.Reflection.Missing.Value;
            //取得Word文件保存路径
            object filename = @SaveAs.Text;
            //创建一个名为WordApp的组件对象
            Word.Application WordApp = new Word.ApplicationClass();
            //创建一个名为WordDoc的文档对象
            Word.Document WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
        }

        protected void exportpdf_ServerClick(object sender, EventArgs e)
        {
            // PDF中使用的字体 
            string fileName = DateTime.Now.ToString();
            System.Text.StringBuilder strb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(strb);
            System.Web.UI.HtmlTextWriter htw = new HtmlTextWriter(sw);
            export_room.RenderControl(htw);
            string htmlText = strb.ToString();
            byte[] pdfFile = new ChineseFontFactory().ConvertHtmlTextToPDF(htmlText);
            Response.ContentType = "application/pdf";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.OutputStream.Write(pdfFile, 0, pdfFile.Length);
            Response.End();
        }*/
        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentTable.Rows.Clear();
            if (ddlSubject.SelectedItem.Value == "#")
                return;
            //添加表头
            TableHeaderRow header = new TableHeaderRow();
            this.studentTable.Controls.Add(header);
            TableHeaderCell headerCell1 = new TableHeaderCell();
            headerCell1.Text = "序号";
            headerCell1.Attributes.Add("width", "10%");
            header.Cells.Add(headerCell1);
            TableHeaderCell headerCell2 = new TableHeaderCell();
            headerCell2.Text = "准考证";
            headerCell2.Attributes.Add("width", "14%");
            header.Cells.Add(headerCell2);
            TableHeaderCell headerCell3 = new TableHeaderCell();
            headerCell3.Text = "姓名";
            headerCell3.Attributes.Add("width", "12%");
            header.Cells.Add(headerCell3);
            TableHeaderCell headerCell4 = new TableHeaderCell();
            headerCell4.Text = "成绩";
            headerCell4.Attributes.Add("width", "12%");
            header.Cells.Add(headerCell4);
            TableHeaderCell headerCell5 = new TableHeaderCell();
            headerCell5.Text = "曲目名称";
            headerCell5.Attributes.Add("width", "52%");
            header.Cells.Add(headerCell5);
            //修改科目字典
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            try
            {
                List<Model.CCOM.Subject> subjectList = bll.GetModelList("Major_Agency_id IN ( SELECT Major_Agency_id FROM admissions.dbo.Subject WHERE Subject_id = '" + Convert.ToInt32(ddlSubject.SelectedValue) + "')");
                foreach (Model.CCOM.Subject subject in subjectList)
                {
                    subjectDic.Add(subject.Subject_id, subject);
                }
            }
            catch (Exception error)
            {
                return;
            }
            showStudentInfo();
        }
    }
}