using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.Text;
using LitJson;

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class ExamList : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string uo_id = MyRequest.GetQueryString("uo_id").Trim();
        protected string keywords = MyRequest.GetQueryString("keywords");
        protected string subject = MyRequest.GetQueryString("subject");

        public ExamList()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected bool completeFirstIntro = false;
        public int StuCount = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fun_id = MyRequest.GetQueryString("fun_id");

            if (!Page.IsPostBack)
            {
                //判断是不是管理员登录
                //Model.CCOM.User_information model = GetAdminInfo_CCOM();
                //BLL.CCOM.Period per_bll = new BLL.CCOM.Period();
                //Model.CCOM.Period per_model = per_bll.GetModel(" Period_state=1");
                //BLL.CCOM.Subject agency_bll = new BLL.CCOM.Subject();
                //int agency_id = new BLL.CCOM.View_Admin().GetModel(" User_id='" + GetAdminInfo_CCOM().User_id + "'").Agency_id;
                //string agency_group = GetSonXiList(agency_id);
                //if (per_model != null)
                //{
                //    this.ddlSubject.DataSource = agency_bll.GetList(" Subject_level=2 and Period_id='" + per_model.Period_id + "' and Manage_Agency_id in (" + agency_group + ")");
                //}
                //else {
                //    this.ddlSubject.DataSource = agency_bll.GetList(" 1=0");
                //}
                //this.ddlSubject.DataTextField = "Subject_title";
                //this.ddlSubject.DataValueField = "Subject_id";
                //this.ddlSubject.DataBind();
                //this.ddlSubject.Items.Insert(0, new ListItem("全选", "0"));
                //this.ddlSubject.SelectedValue = subject;
                BindRpt();
                //  CheckIsFinish();
            }

        }

        protected void BindRpt()
        {
            string _order = MyRequest.GetString("sort").Replace(",", " ");
            if (_order == "" || Tools.CheckParams(_order)) _order = " Group_id asc";
            RptBind("", _order);
        }

        #region 组合SQL查询语句==========================
        //protected string CombSqlTxt(string _uo_id, string _keywords)
        //{
        //    StringBuilder strTemp = new StringBuilder();
        //    _keywords = _keywords.Replace("'", "");
        //    //添加科目筛选
        //    if (subject != null && subject != "")
        //    {
        //        if (GetSubjectToExam(subject) != "") strTemp.Append(" Ea_id in (" + GetSubjectToExam(subject) + ")");
        //        else strTemp.Append(" Ea_id = 0");
        //    }
        //    if (!string.IsNullOrEmpty(_keywords))
        //    {
        //        //姓名，登录名，学号，手机号
        //        strTemp.Append(" and Ea_name like '%" + _keywords + "%'");
        //        strTemp.Append(" or Ea_room like '%" + _keywords + "%'");
        //        strTemp.Append(" or Ea_restroom like '%" + _keywords + "%'");
        //        strTemp.Append(" or Ea_starttime like '%" + _keywords + "%'");
        //        strTemp.Append(" or Ea_endtime like '%" + _keywords + "%'");
        //    }
        //    return strTemp.ToString();
        //}
        #endregion

        //public string GetSubjectToExam(string subject)
        //{
        //    string res = "";
        //    try
        //    {
        //        List<Model.CCOM.Examination_subject> modellist = new BLL.CCOM.Examination_subject().GetModelList(" Esn_id=" + subject);
        //        foreach (Model.CCOM.Examination_subject model in modellist)
        //        {
        //            res += model.Ea_id + ",";
        //        }
        //    }
        //    catch {
        //        res = "";
        //    }
        //    if (res == "") return "";
        //    else return Utils.DelLastComma(res);
        //}

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            this.st_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
           // this.txtKeywords.Value = keywords;

            BLL.CCOM.Reply_group bll = new BLL.CCOM.Reply_group();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("ExamList.aspx", "fun_id={0}&keywords={1}&sort={2}&page={3}", this.fun_id, this.keywords, MyRequest.GetString("sort"), "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("exam_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //删除
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Reply_group bll = new BLL.CCOM.Reply_group();
            var lbtn = sender as LinkButton;
            if (lbtn != null)
            {
                var id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool result = true;
                try
                {
                    result = bll.Delete(id);
                }
                catch
                {
                    result = false;
                }
                string keywords = this.keywords;
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("ExamList.aspx", "fun_id={0}&keywords={1}&sort={2}&page={3}",
                        this.fun_id, this.keywords, MyRequest.GetString("sort"), "__id__"), "Success");
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("ExamList.aspx", "fun_id={0}&keywords={1}&sort={2}&page={3}",
                        this.fun_id, this.keywords, MyRequest.GetString("sort"), "__id__"), "Error");
            }
        }

        //导出考生
        protected void lbtExportStudent_Click(object sender, EventArgs e)
        {
            //BLL.CCOM.Examination_arrangement bll = new BLL.CCOM.Examination_arrangement();
            //var lbtn = sender as LinkButton;
            //if (lbtn != null)
            //{
            //    var id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
            //    //var id = Int32.Parse(DESEncrypt.Decrypt(this.txtExamID.Text));
            //    var m = new BLL.CCOM.Examination_arrangement().GetModel(id);
            //    string title = m.Ea_name;
            //    DataTableExportToExcel(id, title + "的考生名单", "sheet1");
            //}
        }

        /// <summary>
        /// Myxls导出Excel，保存在客户端
        /// </summary>
        private void DataTableExportToExcel(long applyId, string xlsName, string sheetName)
        {
            //表头
            //决定Datatable显示哪些内容
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Sheet1");
            DataRow dr;
            DataColumn column;

            //1---序号
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "序号";
            ds.Tables["Sheet1"].Columns.Add(column);

            //2---准考证号
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "准考证号";
            ds.Tables["Sheet1"].Columns.Add(column);
            //3---姓名
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "姓名";
            ds.Tables["Sheet1"].Columns.Add(column);
            //4---专业
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "专业";
            ds.Tables["Sheet1"].Columns.Add(column);

            var ml = new BLL.CCOM.Examination_arrangement_detail().GetModelList(" Ea_id='" + applyId + "' order by newid()");

            for (int row = 0; row < ml.Count; row++)
            {
                var m = ml[row];

                //申请人基本信息
                //学生用户
                try
                {
                    Model.CCOM.View_UserAgency model = new BLL.CCOM.View_UserAgency().GetModel(" User_id='" + m.User_id + "'");
                    dr = ds.Tables["Sheet1"].NewRow();
                    dr[0] = row + 1;
                    dr[1] = model.UP_CCOM_number;
                    dr[2] = model.User_realname;
                    dr[3] = model.Agency_name;

                    ds.Tables["Sheet1"].Rows.Add(dr);
                }
                catch
                {
                    continue;
                }
            }

            //导出EXCEL，速度有点慢
            DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), xlsName + ".xlsx", this.Page);

        }

        //切换科目
        //protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect(Utils.CombUrlTxt("ExamList.aspx", "fun_id={0}&keywords={1}&subject={2}",
        //        this.fun_id.ToString(), this.keywords, this.ddlSubject.SelectedValue));
        //}

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    string keywords = this.txtKeywords.Value;
        //    Response.Redirect(Utils.CombUrlTxt("ExamList.aspx", "fun_id={0}&keywords={1}", this.fun_id.ToString(), this.txtKeywords.Value));
        //}

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("exam_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("ExamList.aspx", "fun_id={0}&keywords={1}", this.fun_id, this.keywords));
        }

        public string GetRoom(int id)
        {
            try
            {
                Model.CCOM.Examination_arrangement exam_model = new BLL.CCOM.Examination_arrangement().GetModel(id);
                Model.CCOM.Examination_room model = new BLL.CCOM.Examination_room().GetModel(exam_model.Ea_room);
                return model.Er_building + "/" + model.Er_floor + "层/" + model.Er_room + "/" + model.Er_capacity + "人";
            }
            catch
            {
                return "";
            }
        }

        public string GetRestRoom(int id)
        {
            try
            {
                Model.CCOM.Examination_arrangement exam_model = new BLL.CCOM.Examination_arrangement().GetModel(id);
                Model.CCOM.Examination_room model = new BLL.CCOM.Examination_room().GetModel((int)exam_model.Ea_restroom);
                return model.Er_building + "/" + model.Er_floor + "层/" + model.Er_room + "/" + model.Er_capacity + "人";
            }
            catch
            {
                return "";
            }
        }

        public string GetStudentNumber(long id)
        {
            try
            {
                var ml = new BLL.CCOM.Reply_student().GetModelList(" Group_id=" + id);
                int number = ml.Count;
               // if (number == 0) return "0";
               return Utils.ObjectToStr(number) ;
            }
            catch
            {
                return "0";
            }
        }

        public string GetGroupType(string type)
        {
            if (type == "1")
                return "软件验收";
            else if (type == "0")
                return "口头答辩";
            else if (type == "2")
                return "开题评审";
            else return "";
        }

        public string GetTeacherName(long id)
        {
            try
            {
                BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
                Model.CCOM.User_information model = bll.GetModel(id);
                return model.User_realname;
            }
            catch
            {
                return "该教师用户不存在";
            }
        }

        //得到指定部门下所有的机构列表
        public string GetSonUOList(int UO_ID)
        {
            string res = "";
            if (new BLL.CCOM.Agency().GetModel(UO_ID).Agency_type == 3)
                res += UO_ID.ToString() + ",";
            List<Model.CCOM.Agency> modellist = new BLL.CCOM.Agency().GetModelList(" Agency_father = " + UO_ID + " and Agency_status=1");
            foreach (Model.CCOM.Agency model in modellist)
            {
                res += GetSonUOList(model.Agency_id) + ",";
            }
            return Utils.DelLastComma(res);
        }

        //得到指定部门下所有的系
        public string GetSonXiList(int UO_ID)
        {
            string res = "";
            if (new BLL.CCOM.Agency().GetModel(UO_ID).Agency_type == 2)
                res += UO_ID.ToString() + ",";
            List<Model.CCOM.Agency> modellist = new BLL.CCOM.Agency().GetModelList(" Agency_father = " + UO_ID + " and Agency_status=1");
            foreach (Model.CCOM.Agency model in modellist)
            {
                res += GetSonXiList(model.Agency_id) + ",";
            }
            if (res != "") return Utils.DelLastComma(res);
            else return "0";
        }

        //protected void CheckIsFinish() {
        //    int flag = 1;
        //    string msg = "";
        //    int agency_id = new BLL.CCOM.View_Admin().GetModel(" User_id='" + GetAdminInfo_CCOM().User_id + "'").Agency_id;
        //    string agency_group = GetSonXiList(agency_id);
        //    string[] agencys = agency_group.Split(',');
        //    Model.CCOM.Period per_model = new BLL.CCOM.Period().GetModel(" Period_state=1");
        //    if (per_model == null) {
        //        this.lblTip.ForeColor = Color.Red;
        //        this.lblTip.Text = "未开启任何周期" + msg;
        //        return;
        //    }
        //    for (int i = 0; i < agencys.Length; i++) 
        //    {
        //        string agency = agencys[i];
        //        var subject_models = new BLL.CCOM.Subject().GetModelList(" Manage_Agency_id=" + agency + " and Subject_level=2 and Period_id='" + per_model.Period_id + "'");
        //        foreach (Model.CCOM.Subject subject_model in subject_models) 
        //        {
        //            if (new BLL.CCOM.Examination_subject().GetModel(" Esn_id=" + subject_model.Subject_id) == null) {
        //                msg = msg + (flag++) + "、“" + new BLL.CCOM.Agency().GetModel(" Agency_id=" + subject_model.Major_Agency_id).Agency_name + "--" + subject_model.Subject_title + "”尚未排考！     ";
        //            }
        //        }
        //    }
        //    agency_group = GetSonUOList(agency_id);
        //    agencys = agency_group.Split(',');
        //    for (int i = 0; i < agencys.Length; i++)
        //    {
        //        string agency = agencys[i];
        //        var subject_models = new BLL.CCOM.Subject().GetModelList(" Major_Agency_id=" + agency + " and Subject_level=2 and Period_id='" + per_model.Period_id + "'");
        //        foreach (Model.CCOM.Subject subject_model in subject_models)
        //        {
        //            var student_models = new BLL.CCOM.View_UserAgency().GetModelList(" Agency_id=" + agency);
        //            foreach (Model.CCOM.View_UserAgency student_model in student_models)
        //            {
        //                int n = 0;
        //                var exam_models = new BLL.CCOM.Examination_subject().GetModelList(" Esn_id=" + subject_model.Subject_id);
        //                foreach (Model.CCOM.Examination_subject exam_model in exam_models)
        //                {
        //                    n = n + new BLL.CCOM.Examination_arrangement_detail().GetModelList(" Ea_id=" + exam_model.Ea_id + " and User_id=" + student_model.User_id).Count;
        //                }
        //                if (n == 0) {
        //                    msg = msg + (flag++) + "、“考生：" + student_model.User_realname + "的科目：" + subject_model.Subject_title + "”尚未排考！";
        //                }
        //                else if (n > 1) 
        //                {
        //                    msg = msg + (flag++) + "、“考生：" + student_model.User_realname + "的科目：" + subject_model.Subject_title + "”存在重排，请检查！";
        //                }
        //            }
        //        }
        //    }

        //    if (msg == "")
        //    {
        //        this.lblTip.ForeColor = Color.Green;
        //        this.lblTip.Text = "您已完成全部排考";
        //    }
        //    else
        //    {
        //        this.lblTip.ForeColor = Color.Red;
        //        this.lblTip.Text = "漏排与重排检查：" + msg;
        //    }
        //}

        //protected void exportpdf_ServerClick(object sender, EventArgs e)
        //{
        //    // PDF中使用的字体 
        //    BaseFont bfHei = BaseFont.CreateFont(@"c:/windows/fonts/SIMHEI.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        //    BaseFont bfChinese = BaseFont.CreateFont(@"c:/windows/fonts/SIMSUN.TTC,0", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED); //宋体

        //    Font Biaoti = new Font(bfHei, 15, Font.BOLD);
        //    Font Zhengwen = new Font(bfChinese, 10);
        //    Font Jiacu = new Font(bfChinese, 8, Font.BOLD);

        //    MemoryStream MStream = new MemoryStream();
        //    Document document = new Document(PageSize.A4, 10, 10, 10, 20);
        //    PdfWriter writer = PdfWriter.GetInstance(document, MStream);
        //    document.Open();

        //    Paragraph Title = new Paragraph(this.divApplyTitle.InnerHtml, Biaoti);
        //    Title.Alignment = Element.ALIGN_CENTER;

        //    float[] widths = { 80, 110, 75, 180, 75, 180 };//设置表格的列宽   
        //    PdfPTable table1 = new PdfPTable(widths);
        //    PdfPCell cell;

        //    //#region 基本信息写入============================================================================================

        //    //cell = new PdfPCell(new Phrase(new Chunk("姓名", Jiacu)));
        //    //cell.FixedHeight = 30;
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.UseAscender = true;
        //    //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);
        //    //cell = new PdfPCell(new Phrase(new Chunk(this.lblUI_RealName.Text, Zhengwen)));
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.PaddingLeft = 5;
        //    //cell.UseAscender = true;
        //    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);


        //    //cell = new PdfPCell(new Phrase(new Chunk("性别", Jiacu)));
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.HorizontalAlignment = 1;
        //    //cell.UseAscender = true;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);
        //    //cell = new PdfPCell(new Phrase(new Chunk(this.lblUI_Sex.Text, Zhengwen)));
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.HorizontalAlignment = 0;
        //    //cell.PaddingLeft = 5;
        //    //cell.UseAscender = true;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);

        //    //cell = new PdfPCell(new Phrase(new Chunk("出生年月", Jiacu)));
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.HorizontalAlignment = 1;
        //    //cell.UseAscender = true;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);
        //    //cell = new PdfPCell(new Phrase(new Chunk(this.lblUI_Birthday.Text, Zhengwen)));
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.HorizontalAlignment = 0;
        //    //cell.PaddingLeft = 5;
        //    //cell.UseAscender = true;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);

        //    //cell = new PdfPCell(new Phrase(new Chunk("班级", Jiacu)));
        //    //cell.FixedHeight = 30;
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.UseAscender = true;
        //    //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);
        //    //cell = new PdfPCell(new Phrase(new Chunk(this.lblUO_Name.Text, Zhengwen)));
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.PaddingLeft = 5;
        //    //cell.UseAscender = true;
        //    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);

        //    //cell = new PdfPCell(new Phrase(new Chunk("学号", Jiacu)));
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.HorizontalAlignment = 1;
        //    //cell.UseAscender = true;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);
        //    //cell = new PdfPCell(new Phrase(new Chunk(this.lblSchoolUser_No.Text, Zhengwen)));
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.HorizontalAlignment = 0;
        //    //cell.PaddingLeft = 5;
        //    //cell.UseAscender = true;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);

        //    //cell = new PdfPCell(new Phrase(new Chunk("联系电话", Jiacu)));
        //    //cell.FixedHeight = 30;
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.UseAscender = true;
        //    //cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);
        //    //cell = new PdfPCell(new Phrase(new Chunk(this.lblUI_Mobile.Text, Zhengwen)));
        //    //cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //    //cell.PaddingLeft = 5;
        //    //cell.UseAscender = true;
        //    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    //cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //    //table1.AddCell(cell);

        //    //#endregion==============================================================================================

        //    #region 自定义申报信息写入==============================================================================
        //    var recordM = new BLL.declaration.ApplyRecord().GetModel(record_id);
        //    var model = new BLL.declaration.ApplySubject().GetModel(recordM.Apply_ID);
        //    var SubjectItem = new BLL.declaration.ApplyItem().GetModelList("Apply_ID = " + recordM.Apply_ID);
        //    //this.divApplyTitle.InnerHtml = model.apply_title + "——用户申报内容";
        //    foreach (var item in SubjectItem)
        //    {
        //        if (item.Item_Type == DataDic.ItemType_File.ToString())
        //        {
        //            continue;
        //            //iTextSharp.text.Anchor anchor = new Anchor("点击下载", Zhengwen);
        //            //anchor.Reference = ConfigurationManager.AppSettings["SiteUrl"].ToString() + GetItemValue(recordM.ValueItem, item);

        //            //Font link = FontFactory.GetFont("Arial", 12, Font.UNDERLINE, new BaseColor(0, 0, 255));
        //            //Anchor anchor = new Anchor("www.mikesdotnetting.com", Zhengwen);
        //            //anchor.Reference = "http://www.mikesdotnetting.com";

        //            //cell = new PdfPCell(new Phrase(new Chunk("", Zhengwen)));
        //            //cell.AddElement(anchor);
        //        }
        //        cell = new PdfPCell(new Phrase(new Chunk(item.Item_Title, Jiacu)));
        //        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //        cell.HorizontalAlignment = 1;
        //        cell.UseAscender = true;
        //        cell.FixedHeight = 30;
        //        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //        table1.AddCell(cell);
        //        cell = new PdfPCell(new Phrase(new Chunk(WebHelper.GetItemValue(item, record_id), Zhengwen)));

        //        cell.Colspan = 5;
        //        cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //        cell.HorizontalAlignment = 0;
        //        cell.Padding = 5;
        //        cell.UseAscender = true;
        //        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //        table1.AddCell(cell);
        //    }
        //    #endregion

        //    #region 审核意见==============================================================================





        //    string checkcomment = "";
        //    string checkuser = "";
        //    var checklist = new BLL.declaration.ApplyCheck().GetModelList("record_id = " + record_id);
        //    if (checklist.Count <= 0)
        //    {
        //        checkcomment = "";
        //        checkuser = "";
        //    }
        //    else
        //    {
        //        foreach (Model.declaration.ApplyCheck checkmodel in checklist)
        //        {
        //            checkcomment = "";
        //            checkuser = "";

        //            switch (checkmodel.Check_Status)
        //            {
        //                case DataDic.Check_NotCheck:
        //                    checkcomment += DataDic.Check_NotCheckText + "。";
        //                    break;
        //                case DataDic.Check_YES:
        //                    checkcomment += DataDic.Check_YesText + "。";
        //                    break;
        //                case DataDic.Check_NO:
        //                    checkcomment += DataDic.Check_NoText + "。";
        //                    break;
        //            }

        //            checkcomment += "\n" + checkmodel.Check_Comment;
        //            checkuser += "审批人：" + new BLL.admin.Universities_UserInfo().GetModel(checkmodel.Check_User).UI_RealName;
        //            if (checkmodel.Check_Status != DataDic.Check_NotCheck)
        //                checkuser += "\n" + checkmodel.Check_Time.ToString("yyyy年MM月dd日");

        //            cell = new PdfPCell(new Phrase(new Chunk("审批意见", Jiacu)));
        //            cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER;
        //            cell.HorizontalAlignment = 1;
        //            cell.UseAscender = true;
        //            cell.FixedHeight = 100;
        //            cell.Rowspan = 2;
        //            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            table1.AddCell(cell);

        //            cell = new PdfPCell(new Phrase(new Chunk(checkcomment, Zhengwen)));
        //            cell.Colspan = 5;
        //            cell.FixedHeight = 70;
        //            cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER | Rectangle.NO_BORDER;
        //            cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //            cell.Padding = 5;
        //            cell.UseAscender = true;
        //            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            table1.AddCell(cell);

        //            cell = new PdfPCell(new Phrase(new Chunk(checkuser, Zhengwen)));
        //            cell.Colspan = 5;
        //            cell.FixedHeight = 30;
        //            cell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.NO_BORDER | Rectangle.BOTTOM_BORDER;
        //            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //            cell.Padding = 5;
        //            cell.UseAscender = true;
        //            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            table1.AddCell(cell);
        //        }

        //    }
        //    //this.divApplyTitle.InnerHtml = model.apply_title + "——用户申报内容";



        //    #endregion


        //    #region 向pdf中添加标题和表=============================================================================
        //    document.Add(Title);
        //    document.Add(new Phrase(new Chunk("", Zhengwen)));
        //    document.Add(table1);
        //    document.Close();
        //    #endregion =============================================================================================


        //    //物理完整路径                    
        //    string toFileFullPath = Utils.GetMapPath(DataDic.Batch_Path + DESEncrypt.Encrypt(model.Apply_ID.ToString()) + "/");
        //    //检查有该路径是否就创建
        //    if (!Directory.Exists(toFileFullPath))
        //    {
        //        Directory.CreateDirectory(toFileFullPath);
        //    }
        //    string filePath = Server.MapPath(DataDic.Batch_Path + DESEncrypt.Encrypt(model.Apply_ID.ToString()) + "/" + DESEncrypt.Encrypt(record_id.ToString()) + ".pdf");
        //    if (System.IO.File.Exists(filePath) != true)
        //    {
        //        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        //        BinaryWriter w = new BinaryWriter(fs);
        //        w.Write(MStream.ToArray());
        //        fs.Close();
        //    }

        //    Response.ContentType = "application/pdf";
        //    Response.Charset = "gb2312";
        //    Response.AddHeader("content-disposition", "attachment;filename=" + this.divApplyTitle.InnerHtml + "_" + new BLL.admin.Universities_UserInfo().GetModel(recordM.Record_User).UI_RealName + ".pdf");
        //    Response.OutputStream.Write(MStream.GetBuffer(), 0, MStream.GetBuffer().Length);
        //    Response.OutputStream.Flush();
        //    MStream.Close();
        //}

    }
}