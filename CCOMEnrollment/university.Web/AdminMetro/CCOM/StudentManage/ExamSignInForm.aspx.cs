using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class ExamSignInForm : university.UI.ManagePage
    {
        public string periodYear;
        public int examId;
        public string examInfo = "";
        public ExamSignInForm()
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
            BLL.CCOM.Examination_arrangement bll = new BLL.CCOM.Examination_arrangement();
            var model = bll.GetModel(examId);
            var roomModel = new BLL.CCOM.Examination_room().GetModel(model.Ea_room);
            examInfo += model.Ea_name + "  " + model.Ea_starttime.ToString("M月d日 hh:mm") + "    " + roomModel.Er_building + roomModel.Er_room;
            showStudentInfo();
        }

        protected void showStudentInfo()
        {
            BLL.CCOM.User_information ubll = new BLL.CCOM.User_information();
            BLL.CCOM.User_property pbll = new BLL.CCOM.User_property();
            List<Model.CCOM.Examination_arrangement_detail> EadList = new BLL.CCOM.Examination_arrangement_detail().GetModelList(" Ea_id=" + examId);
            int num = 0;
            TableRow studentRow = new TableRow();
            foreach (Model.CCOM.Examination_arrangement_detail EadModel in EadList)
            {
                num++;
                var umodel = ubll.GetModel(EadModel.User_id);
                var pmodel = pbll.GetModel("User_id=" + EadModel.User_id);
                TableCell studentCell = new TableCell();
                studentCell.HorizontalAlign = HorizontalAlign.Center;
                studentRow.Cells.Add(studentCell);
                Image upPicture = new Image();
                upPicture.ImageUrl = "../../.." + pmodel.UP_picture;
                upPicture.Width = 60;
                studentCell.Controls.Add(upPicture);
                Panel panel1 = new Panel();
                studentCell.Controls.Add(panel1);
                Label upCcomNum = new Label();
                upCcomNum.Text = pmodel.UP_CCOM_number;
                panel1.Controls.Add(upCcomNum);
                Panel panel2 = new Panel();
                studentCell.Controls.Add(panel2);
                Label name = new Label();
                name.Text = umodel.User_realname;
                panel2.Controls.Add(name);

                if (num % 6 == 0)
                {
                    studentTable.Rows.Add(studentRow);
                    studentRow = new TableRow();
                }
            }
            if (num % 6 != 0)
            {
                studentTable.Rows.Add(studentRow);
            }
        }

        protected void exportword_ServerClick(object sender, EventArgs e)
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
            Word.Document WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);*/
        }

        /*protected void exportpdf_ServerClick(object sender, EventArgs e)
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
    }
}