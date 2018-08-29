using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace university.Web.AdminMetro.CCOM.ExamManage
{
    public partial class ShowSubject : university.UI.ManagePage
    {
        Model.CCOM.Subject root = null;
        Dictionary<int, Model.CCOM.Subject> subjectDic = new Dictionary<int, Model.CCOM.Subject>();

        public ShowSubject()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartment();
            }
            BindAllSubject();
        }

        public void BindDepartment()
        {
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            DataSet ds = bll.GetList(" Agency_type = 2");
            this.ddlDepartment.DataSource = ds.Tables[0].DefaultView;
            this.ddlDepartment.DataTextField = "Agency_name";
            this.ddlDepartment.DataValueField = "Agency_id";
            this.ddlDepartment.DataBind();
            ListItem item = new ListItem("--请选择系--", "#");
            this.ddlDepartment.Items.Insert(0, item);
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.subjectTable.Rows.Clear();
            string departmentId = this.ddlDepartment.SelectedItem.Value;
            if (departmentId.Equals("#"))
            {
                this.ddlMajor.Items.Clear();
                ListItem item1 = new ListItem("--请选择专业--", "#");
                this.ddlMajor.Items.Insert(0, item1);
                return;
            }
            string sql = " Agency_father = " + departmentId;
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            DataSet ds = bll.GetList(sql);

            this.ddlMajor.Items.Clear();

            this.ddlMajor.DataSource = ds.Tables[0].DefaultView;
            this.ddlMajor.DataTextField = "Agency_name";
            this.ddlMajor.DataValueField = "Agency_id";
            this.ddlMajor.DataBind();
            ListItem item = new ListItem("--请选择专业--", "#");
            this.ddlMajor.Items.Insert(0, item);
        }

        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.subjectTable.Rows.Clear();
            subjectDic.Clear();
            BindAllSubject();
        }

        protected void BindAllSubject()
        {
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            try
            {
                List<Model.CCOM.Subject> subjectList = bll.GetModelList("Major_Agency_id=" + Convert.ToInt32(this.ddlMajor.SelectedItem.Value));
                foreach (Model.CCOM.Subject subject in subjectList)
                {
                    subjectDic.Add(subject.Subject_id, subject);
                }
            }
            catch (Exception e)
            {
                return;
            }
            //添加表头
            TableHeaderRow header = new TableHeaderRow();
            this.subjectTable.Controls.Add(header);
            TableHeaderCell headerCell1 = new TableHeaderCell();
            headerCell1.Text = "标题";
            headerCell1.Attributes.Add("width", "20%");
            header.Cells.Add(headerCell1);
            TableHeaderCell headerCell3 = new TableHeaderCell();
            headerCell3.Text = "考试方式";
            headerCell3.Attributes.Add("width", "20%");
            header.Cells.Add(headerCell3);
            TableHeaderCell headerCell6 = new TableHeaderCell();
            headerCell6.Text = "描述";
            headerCell6.Attributes.Add("width", "20%");
            header.Cells.Add(headerCell6);
            int majorId = Convert.ToInt32(this.ddlMajor.SelectedItem.Value);
            root = bll.GetModel("Major_Agency_id=" + majorId + "and Subject_level=0");
            BindSubject(root);
        }

        protected void BindSubject(Model.CCOM.Subject model)
        {
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            int subjectId = model.Subject_id;
            if (model.Subject_level != 0)
            {
                TableRow subjectRow = newSubjectRow(model);
                this.subjectTable.Rows.Add(subjectRow);
            }
            if (model.Subject_level <= 1)
            {
                foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                {
                    if (Cmodel.Fs_id == subjectId)
                    {
                        BindSubject(Cmodel);
                    }
                }
            }
        }

        protected TableRow newSubjectRow(Model.CCOM.Subject model)
        {
            int level = model.Subject_level;
            int subjectId = model.Subject_id;
            //当前项TableRow
            TableRow subjectRow = new TableRow();
            TableCell titleCell = new TableCell();
            subjectRow.Cells.Add(titleCell);
            //空格
            Label span = new Label();
            string blank = "";
            for (int i = 0; i < model.Subject_level; i++)
            {
                blank += "&nbsp;&nbsp;";
            }
            span.Text = blank;
            titleCell.Controls.Add(span);

            TableCell subjectTypeCell = new TableCell();
            subjectTypeCell.HorizontalAlign = HorizontalAlign.Center;
            subjectRow.Cells.Add(subjectTypeCell);
            TableCell descriptionCell = new TableCell();
            descriptionCell.HorizontalAlign = HorizontalAlign.Center;
            subjectRow.Cells.Add(descriptionCell);
            //标题
                Label title = new Label();
                title.ID = "title" + subjectId;
                title.Text = model.Subject_title;
                if (model.Subject_level == 1)
                {
                    title.Font.Bold = true;
                }
                titleCell.Controls.Add(title);
            if (level == 2)
            {
                //笔试/面试
                Label subjectType = new Label();
                subjectType.ID = "subjectType" + subjectId;
                subjectType.Text = (bool)model.Subject_type ? "面试" : "笔试";
                subjectTypeCell.Controls.Add(subjectType);
            }
            TextBox description = new TextBox();
            description.ID = "description" + subjectId;
            description.ReadOnly = true;
            description.TextMode = TextBoxMode.MultiLine;
            description.Rows = 2;
            description.Text = model.Subject_description.ToString();
            descriptionCell.Controls.Add(description);

            return subjectRow;
        }
    }
}