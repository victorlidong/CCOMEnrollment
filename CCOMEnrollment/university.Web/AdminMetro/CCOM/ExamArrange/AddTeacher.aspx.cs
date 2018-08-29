using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb;
using org.in2bits.MyXls;
using university.Common;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class AddTeacher : university.UI.ManagePage
    {
        protected string keywords = string.Empty;
        protected int apply_id = 0;
        //存放导出数据的表头
        protected ArrayList urlParamsList = new ArrayList();

        public AddTeacher()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.fun_id = get_fun_id("CCOM/ExamArrange/AddTeacher.aspx");
            this.keywords = MyRequest.GetQueryString("keywords");
            this.apply_id = int.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("id")));
            if (this.apply_id == 0)
            {
                JscriptMsg("传输参数不正确！", "back", "Error");
                return;
            }
            if (!Page.IsPostBack)
            {
                ShowApplyTitle();
                this.txtKeywords.Text = this.keywords;
                RptBind(CombSqlTxt(this.keywords), " User_id asc ");
            }
       
        }

        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            //if (GetSonUOList(apply_id) != "") strTemp.Append(" Agency_id in (" + GetSonUOList(apply_id) + ")");
            //else strTemp.Append(" Agency_id = 0");

            //BLL.CCOM.Period per_bll = new BLL.CCOM.Period();
            //Model.CCOM.Period per_model = per_bll.GetModel(" Period_state=1");
            //if (per_model != null) strTemp.Append(" and Period_id='" + per_model.Period_id + "'");
            //else strTemp.Append(" and Period_id='0'");
            BLL.CCOM.Reply_group per_bll = new BLL.CCOM.Reply_group();
            Model.CCOM.Reply_group per_model = per_bll.GetModel("Group_id=" + apply_id);
            strTemp.Append(" Role_id != 3 and Role_id != 1 and Role_id != 4 and User_id !=" + per_model.User_id);//非学生，教学干事，系统管理员，组长
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (");
                strTemp.Append(" User_realname like '%" + _keywords + "%' ");
                strTemp.Append(" or User_number like '%" + _keywords + "%' ");
                strTemp.Append(" or Agency_name like '%" + _keywords + "%' ");
                strTemp.Append(")");
            }
            return strTemp.ToString();
        }

        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            //this.txtKeywords.Text = keywords;

            var bll = new BLL.CCOM.View_User();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, totalCount);
            this.rptList.DataBind();

            //绑定页码
            //txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("AddTeacher.aspx", "fun_id={0}&id={1}&keywords={2}&page={3}",MyRequest.GetQueryString("fun_id"), MyRequest.GetQueryString("id"),this.keywords, "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }

        //绑定导出数据的表
        private DataTable RptBindExport(string _strWhere)
        {
            var bll = new BLL.CCOM.Examination_arrangement_detail();
            return bll.GetList(_strWhere).Tables["ds"];
        }

        protected bool HasApplyAttach()
        {
            var ml =
                new BLL.CCOM.Examination_arrangement_detail().GetModelList(" Ea_id=" + this.apply_id);
            return ml != null && ml.Count > 0;
        }

        private void ShowApplyTitle()
        {
            var m = new BLL.CCOM.Reply_group().GetModel((int)this.apply_id);

            title.HRef = "ExamList.aspx?fun_id=" + MyRequest.GetQueryString("fun_id");
            this.lblTitle.Text += m.Group_name;
        }

        //得到指定部门下所有的机构列表
        public string GetSonUOList(long Ea_id)
        {
            string res = "";
            try
            {
                var bll = new BLL.CCOM.Examination_subject();
                List<Model.CCOM.Examination_subject> modellist = bll.GetModelList(" Ea_id = " + Ea_id);
                foreach (Model.CCOM.Examination_subject model in modellist)
                {
                    Model.CCOM.Subject m = new BLL.CCOM.Subject().GetModel(model.Esn_id);
                    res += m.Major_Agency_id + ",";
                }
            }
            catch
            {
            }
            if (res.Length > 1) return Utils.DelLastComma(res);
            else return "";
        }

        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("Exam_Student_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("AddTeacher.aspx", "fun_id={0}&keywords={1}&id={2}",MyRequest.GetQueryString("fun_id"), txtKeywords.Text, MyRequest.GetQueryString("id")));
        }

        ////设置分页数量
        //protected void txtPageNum_TextChanged(object sender, EventArgs e)
        //{
        //    int _pagesize;
        //    if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
        //    {
        //        if (_pagesize > 0)
        //        {
        //            Utils.WriteCookie("Exam_Student_page_size", _pagesize.ToString(), 43200);
        //        }
        //    }
        //    Response.Redirect(Utils.CombUrlTxt("AddTeacher.aspx", "fun_id={0}&keywords={1}&id={2}", MyRequest.GetQueryString("fun_id"), txtKeywords.Text, MyRequest.GetQueryString("id")));
        //}

        protected String GetUserStatus(long userId)
        {
            var model = new BLL.CCOM.User_information().GetModel(userId);
            if (model != null)
            {
                if (model.User_status) return "<b style=\"color: green;\">可用</b>";
                else return "<b style=\"color: red;\">停用</b>";
            }
                
            return "--";
        }
      
        protected String GetAddStatus(long userId ,int Group_id)
        {
            var bll = new BLL.CCOM.Reply_commission();
            try
            {
                var model = new BLL.CCOM.Reply_commission().GetModel(" User_id=" + userId + "and Group_id=" + Group_id);
                if (model != null) return "<b style=\"color: green;\">已添加</b>";
                else return "<b style=\"color: red;\">未添加</b>";
            }
            catch
            {
                return "--";
            }
        }

        //}
        protected void btnExport_Click(object sender, EventArgs e)
        {
            //var m = new BLL.CCOM.Examination_arrangement().GetModel(this.apply_id);
            //string title = m.Ea_name;
            //DataTableExportToExcel(this.apply_id, title + "的考生名单", "sheet1");
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

            //2---姓名
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "姓名";
            ds.Tables["Sheet1"].Columns.Add(column);
            //3---报名号
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "高考报名号";
            ds.Tables["Sheet1"].Columns.Add(column);
            //4---手机
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "手 机";
            ds.Tables["Sheet1"].Columns.Add(column);
            //5---报考方向
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "报考方向";
            ds.Tables["Sheet1"].Columns.Add(column);


            var ml = new BLL.CCOM.Examination_arrangement_detail().GetModelList(" Ea_id=" + applyId);

            for (int row = 0; row < ml.Count; row++)
            {
                var m = ml[row];

                //申请人基本信息
                //学生用户
                Model.CCOM.View_UserAgency model = new BLL.CCOM.View_UserAgency().GetModel(" User_id=" + m.User_id);
                dr = ds.Tables["Sheet1"].NewRow();
                dr[0] = model.User_realname;
                dr[1] = model.UP_CEE_number;
                dr[2] = model.User_number;
                dr[3] = model.Agency_name;

                ds.Tables["Sheet1"].Rows.Add(dr);
            }

            //导出EXCEL，速度有点慢
            DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), xlsName + ".xlsx", this.Page);

        }

    }
}