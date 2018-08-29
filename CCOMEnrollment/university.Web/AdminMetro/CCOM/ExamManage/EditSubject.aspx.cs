using AjaxControlToolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ExamManage
{
    public partial class EditSubject : university.UI.ManagePage
    {
        Model.CCOM.Subject root = null;
        Dictionary<int, Model.CCOM.Subject> subjectDic = new Dictionary<int, Model.CCOM.Subject>();
        DataTable dt = null;
        DataSet ds = null;

        public EditSubject()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDepartment();
            }
            dt = new DataTable();
            ds = new DataSet();
            dt.Columns.Add(new DataColumn("Agency_name", typeof(string)));
            dt.Columns.Add(new DataColumn("Agency_id", typeof(string))); //加密后的id
            BindChildAgency(null, 0);
            ds.Tables.Add(dt);
            BindAllSubject(false);
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
            BindAllSubject(true);
            MakeClickableErrorMessage();
        }

        protected void BindAllSubject(bool initial)
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
            headerCell1.Attributes.Add("width", "26%");
            header.Cells.Add(headerCell1);
            TableHeaderCell headerCell2 = new TableHeaderCell();
            headerCell2.Text = "值类型";
            headerCell2.Attributes.Add("width", "16%");
            header.Cells.Add(headerCell2);
            TableHeaderCell headerCell3 = new TableHeaderCell();
            headerCell3.Text = "考试方式";
            headerCell3.Attributes.Add("width", "8%");
            header.Cells.Add(headerCell3);
            TableHeaderCell headerCell4 = new TableHeaderCell();
            headerCell4.Text = "管理机构";
            headerCell4.Attributes.Add("width", "14%");
            header.Cells.Add(headerCell4);
            TableHeaderCell headerCell5 = new TableHeaderCell();
            headerCell5.Text = "权值";
            headerCell5.Attributes.Add("width", "8%");
            header.Cells.Add(headerCell5);
            TableHeaderCell headerCell6 = new TableHeaderCell();
            headerCell6.Text = "描述";
            headerCell6.Attributes.Add("width", "16%");
            header.Cells.Add(headerCell6);
            TableHeaderCell headerCell7 = new TableHeaderCell();
            headerCell7.Text = "操作";
            headerCell7.Attributes.Add("width", "12%");
            header.Cells.Add(headerCell7);
            BLL.CCOM.Period pbll = new BLL.CCOM.Period();
            var pmodel = pbll.GetModel("Period_state=1");
            int periodId = pmodel.Period_id;
            if (this.ddlMajor.SelectedItem.Value == "#")
            {
                this.subjectTable.Controls.Clear();
                return;
            }
            int majorId = Convert.ToInt32(this.ddlMajor.SelectedItem.Value);
            root = bll.GetModel("Major_Agency_id=" + majorId + "and Subject_level=0");
            if (root == null)
            {
                Model.CCOM.Subject model = new Model.CCOM.Subject();
                model.Major_Agency_id = majorId;
                model.Period_id = periodId;
                model.Fs_id = 0;
                model.Subject_weight = 0;
                model.Value_type = 0;
                model.Subject_level = 0;
                model.Subject_title = "";
                int Fsid = bll.Add(model);
                root = bll.GetModel(Fsid);
            }
            BindSubject(root, true, initial, 0);
        }

        //initial 是否为第一次绑定
        protected int BindSubject(Model.CCOM.Subject model, bool isShow, bool initial,int style)
        {
            int attachRowValue = 0; 
            int subjectId = model.Subject_id;
            TableRow subjectRow = newSubjectRow(model);
            subjectRow.ID = "subjectRow" + subjectId;
            subjectRow.Visible = isShow;
            switch (style)
            {
                case 0: subjectRow.BackColor = Color.LightGray; break;
                case 1: subjectRow.BackColor = Color.LightSteelBlue; break;
                case 2: subjectRow.BackColor = Color.LightPink; break;
                case 3: subjectRow.BackColor = Color.LightGreen; break;
            }
            this.subjectTable.Rows.Add(subjectRow);
            DropDownList value_type = (DropDownList)subjectRow.FindControl("valueType" + subjectId);
            int value = 5;
            if ((!initial) && value_type != null)
            {
                value = Convert.ToInt32(value_type.SelectedValue);
            }
            else
            {
                value = model.Value_type;
            }
            //有值类型，往下Bind
            bool flag = true;
            int childrenId = -1;
            foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
            {
                if (Cmodel.Fs_id == model.Subject_id)
                {
                    childrenId++;
                    if (value <= 2)
                    {
                        attachRowValue = BindSubject(Cmodel, isShow, initial, style == 0 ? childrenId % 3 + 1 : style);
                        if (attachRowValue != 0)
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        if (initial)
                        {
                            //第一次读取也不会出现，中途关闭产物。删除
                            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
                            bll.Delete(Cmodel.Subject_id);
                            //subjectDic.Remove(Cmodel.Subject_id);
                        }
                        else
                        {
                            attachRowValue = BindSubject(Cmodel, false, initial, style == 0 ? childrenId % 3 + 1 : style);
                            if (attachRowValue != 0)
                            {
                                flag = false;
                            }
                        }
                    }
                }
            }
            if (flag)
            {
                attachRowValue = subjectTable.Rows.GetRowIndex(subjectRow);
            }
            if (value > 2)
            {
                if (subjectRow.FindControl("btnAdd" + model.Subject_id) != null)
                {
                    subjectRow.FindControl("btnAdd" + model.Subject_id).Visible = false;
                }
            }
            if (value == 2)
            {
                subjectRow.FindControl("valueCount" + model.Subject_id).Visible = true;
                subjectRow.FindControl("Label1" + model.Subject_id).Visible = true;
                subjectRow.FindControl("Label2" + model.Subject_id).Visible = true;
                subjectRow.FindControl("btnValueCountUp" + subjectId).Visible = true;
                subjectRow.FindControl("btnValueCountDown" + subjectId).Visible = true;
            }
            HiddenField attachRow = (HiddenField)subjectRow.FindControl("attachRow" + subjectId);
            attachRow.Value = attachRowValue.ToString();

            return attachRowValue;
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
            //加减号
            ImageButton symbol = new ImageButton();
            symbol.ID = "symbol" + subjectId;
            symbol.ImageUrl = "../../../images/exam/minus.png";
            symbol.Click += symbol_Click;
            symbol.CausesValidation = false;
            symbol.Width = 10;
            titleCell.Controls.Add(symbol);
            Label space = new Label();
            space.Text = "&nbsp";
            titleCell.Controls.Add(space);

            TableCell valueTypeCell = new TableCell();
            valueTypeCell.HorizontalAlign = HorizontalAlign.Center;
            subjectRow.Cells.Add(valueTypeCell);
            TableCell subjectTypeCell = new TableCell();
            subjectTypeCell.HorizontalAlign = HorizontalAlign.Center;
            subjectRow.Cells.Add(subjectTypeCell);
            TableCell manageAgencyCell = new TableCell();
            manageAgencyCell.HorizontalAlign = HorizontalAlign.Center;
            subjectRow.Cells.Add(manageAgencyCell);
            TableCell weightCell = new TableCell();
            weightCell.HorizontalAlign = HorizontalAlign.Center;
            subjectRow.Cells.Add(weightCell);
            TableCell descriptionCell = new TableCell();
            descriptionCell.HorizontalAlign = HorizontalAlign.Center;
            subjectRow.Cells.Add(descriptionCell);
            TableCell btnCell = new TableCell();
            btnCell.HorizontalAlign = HorizontalAlign.Center;
            subjectRow.Cells.Add(btnCell);
            HiddenField attachRow = new HiddenField();
            attachRow.ID = "attachRow" + subjectId;
            btnCell.Controls.Add(attachRow);
            if (level == 0)
            {
                //标题
                Label title = new Label();
                title.ID = "title" + subjectId;
                title.Text = ddlMajor.SelectedItem.Text + "专业科目";
                titleCell.Controls.Add(title);
            }
            else
            {
                //标题
                TextBox title = new TextBox();
                title.ID = "title" + subjectId;
                title.Text = model.Subject_title;
                title.Attributes.Add("OnFocus", "if(this.value=='请输入标题') {this.value=''}");
                title.Attributes.Add("OnBlur", "if(this.value==''){this.value='请输入标题'}");
                title.Attributes.Add("OnChange", "document.getElementById('btnSave').className='btn btn-success';document.getElementById('labelSave').innerHTML='内容已变更，请保存';");
                titleCell.Controls.Add(title);
                RequiredFieldValidator titleValidator = new RequiredFieldValidator();
                titleValidator.ControlToValidate = "title" + subjectId;
                titleValidator.ID = "titleValidator" + subjectId;
                titleValidator.Display = ValidatorDisplay.Dynamic;
                titleValidator.ErrorMessage = "请输入标题";
                titleValidator.InitialValue = "请输入标题";
                titleCell.Controls.Add(titleValidator);
                CustomValidator CtitleValidator = new CustomValidator();
                CtitleValidator.ControlToValidate = "title" + subjectId;
                CtitleValidator.ID = "CtitleValidator" + subjectId;
                CtitleValidator.Display = ValidatorDisplay.Dynamic;
                CtitleValidator.ServerValidate += invalid_ServerValidate;
                CtitleValidator.ErrorMessage = "请勿输入非法字符";
                titleCell.Controls.Add(CtitleValidator);
                //值方式
                DropDownList valueType = new DropDownList();
                valueType.ID = "valueType" + subjectId;
                if (model.Subject_level <= 5)
                {
                    valueType.Items.Add(new ListItem("多项","0"));
                    valueType.Items.Add(new ListItem("单选","1"));
                    valueType.Items.Add(new ListItem("多选","2"));
                }
                valueType.Items.Add(new ListItem("文本","3"));
                valueType.Items.Add(new ListItem("不填","4"));
                valueType.SelectedValue = model.Value_type.ToString();
                valueType.Width = 70;
                valueType.SelectedIndexChanged += valueType_SelectedIndexChanged;
                valueType.AutoPostBack = true;
                valueTypeCell.Controls.Add(valueType);

                Label label1 = new Label();
                label1.ID = "label1" + subjectId;
                label1.Text = "&nbsp;";
                label1.Visible = false;
                valueTypeCell.Controls.Add(label1);
                TextBox valueCount = new TextBox();
                valueCount.ID = "valueCount" + subjectId;
                valueCount.Text = "2";
                valueCount.Enabled = false;
                valueCount.Width = 20;
                valueCount.Visible = false;
                valueTypeCell.Controls.Add(valueCount);
                ImageButton btnValueCountUp = new ImageButton();
                btnValueCountUp.ID = "btnValueCountUp" + subjectId;
                btnValueCountUp.Width = 12;
                btnValueCountUp.Style["position"] = "relative";
                btnValueCountUp.Style["top"] = "-8px";
                btnValueCountUp.Style["left"] = "2px";
                btnValueCountUp.ImageUrl = "../../../images/exam/add.png";
                btnValueCountUp.Visible = false;
                btnValueCountUp.CausesValidation = false;
                valueTypeCell.Controls.Add(btnValueCountUp);
                ImageButton btnValueCountDown = new ImageButton();
                btnValueCountDown.ID = "btnValueCountDown" + subjectId;
                btnValueCountDown.Width = 12;
                btnValueCountDown.Style["position"] = "relative";
                btnValueCountDown.Style["top"] = "8px";
                btnValueCountDown.Style["left"] = "-10px";
                btnValueCountDown.ImageUrl = "../../../images/exam/minus.png";
                btnValueCountDown.Visible = false;
                btnValueCountDown.CausesValidation = false;
                valueTypeCell.Controls.Add(btnValueCountDown);
                NumericUpDownExtender valueCountUpDown = new NumericUpDownExtender();
                valueCountUpDown.TargetControlID = "valueCount" + subjectId;
                valueCountUpDown.Maximum = 10;
                valueCountUpDown.Minimum = 2;
                valueCountUpDown.TargetButtonUpID = "btnValueCountUp" + subjectId;
                valueCountUpDown.TargetButtonDownID = "btnValueCountDown" + subjectId;
                valueTypeCell.Controls.Add(valueCountUpDown);
                Label label2 = new Label();
                label2.ID = "label2" + subjectId;
                label2.Text = "项";
                label2.Visible = false;
                valueTypeCell.Controls.Add(label2);
                CustomValidator lackSonValidator = new CustomValidator();
                lackSonValidator.ControlToValidate = "valueType" + subjectId;
                lackSonValidator.ID = "lackSonValidator" + subjectId;
                lackSonValidator.Display = ValidatorDisplay.Dynamic;
                lackSonValidator.ServerValidate += lackSonValidator_ServerValidate;
                lackSonValidator.ErrorMessage = "缺少子项目";
                valueTypeCell.Controls.Add(lackSonValidator);
                CustomValidator errorSonValidator = new CustomValidator();
                errorSonValidator.ControlToValidate = "valueType" + subjectId;
                errorSonValidator.ID = "errorSonValidator" + subjectId;
                errorSonValidator.Display = ValidatorDisplay.Dynamic;
                errorSonValidator.ServerValidate += errorSonValidator_ServerValidate;
                errorSonValidator.ErrorMessage = "多选子项只可以为文本或不填";
                valueTypeCell.Controls.Add(errorSonValidator);
                if (level == 1 || level == 2)
                {
                    if (level == 2)
                    {
                        //笔试/面试
                        DropDownList subjectType = new DropDownList();
                        subjectType.ID = "subjectType" + subjectId;
                        subjectType.Items.Insert(0, "笔试");
                        subjectType.Items.Insert(1, "面试");
                        subjectType.Width = 70;
                        subjectType.SelectedIndex = (Convert.ToBoolean(model.Subject_type) ? 1 : 0);
                        subjectTypeCell.Controls.Add(subjectType);
                        DropDownList manageAgency = new DropDownList();
                        manageAgency.ID = "manageAgency" + subjectId;
                        BindAgency(manageAgency);
                        manageAgency.Width = 140;
                        manageAgency.SelectedValue = model.Manage_Agency_id.ToString();
                        manageAgencyCell.Controls.Add(manageAgency);
                    }
                    //权值
                    TextBox weight = new TextBox();
                    weight.ID = "weight" + subjectId;
                    weight.Width = 30; 
                    weight.Text = model.Subject_weight.ToString();
                    weight.Enabled = false;
                    weightCell.Controls.Add(weight);
                    ImageButton btnWeightUp = new ImageButton();
                    btnWeightUp.ID = "btnWeightUp" + subjectId;
                    btnWeightUp.Width = 12;
                    btnWeightUp.Style["position"] = "relative";
                    btnWeightUp.Style["top"] = "-8px";
                    btnWeightUp.Style["left"] = "2px";
                    btnWeightUp.ImageUrl = "../../../images/exam/add.png";
                    weightCell.Controls.Add(btnWeightUp);
                    ImageButton btnWeightDown = new ImageButton();
                    btnWeightDown.ID = "btnWeightDown" + subjectId;
                    btnWeightDown.Width = 12;
                    btnWeightDown.Style["position"] = "relative";
                    btnWeightDown.Style["top"] = "8px";
                    btnWeightDown.Style["left"] = "-10px";
                    btnWeightDown.ImageUrl = "../../../images/exam/minus.png";
                    weightCell.Controls.Add(btnWeightDown);
                    NumericUpDownExtender weightUpDown = new NumericUpDownExtender();
                    weightUpDown.TargetControlID = "weight" + subjectId;
                    weightUpDown.Maximum = 10;
                    weightUpDown.Minimum = 0;
                    weightUpDown.TargetButtonUpID = "btnWeightUp" + subjectId;
                    weightUpDown.TargetButtonDownID = "btnWeightDown" + subjectId;
                    weightCell.Controls.Add(weightUpDown);
                }
                TextBox description = new TextBox();
                description.ID = "description" + subjectId;
                description.TextMode = TextBoxMode.MultiLine;
                description.Rows = 2;
                description.Width = 150;
                description.Text = model.Subject_description.ToString();
                descriptionCell.Controls.Add(description);
                CustomValidator CdescriptionValidator = new CustomValidator();
                CdescriptionValidator.ControlToValidate = "description" + subjectId;
                CdescriptionValidator.ID = "CdescriptionValidator" + subjectId;
                CdescriptionValidator.Display = ValidatorDisplay.Dynamic;
                CdescriptionValidator.ServerValidate += invalid_ServerValidate;
                CdescriptionValidator.ErrorMessage = "请勿输入非法字符";
                descriptionCell.Controls.Add(CdescriptionValidator);
            }
            //按钮
            if (level != 0)
            {
                Button btnDelete = new Button();
                btnDelete.ID = "btnDelete" + subjectId;
                btnDelete.Text = "删除";
                btnDelete.Click += btnDelete_Click;
                btnDelete.CssClass = "btn";
                btnDelete.CausesValidation = false;
                btnCell.Controls.Add(btnDelete);
            }
            if (level <= 5)
            {
                Button btnAdd = new Button();
                btnAdd.ID = "btnAdd" + subjectId;
                btnAdd.Text = "新建";
                btnAdd.Click += btnAdd_Click;
                btnAdd.CssClass = "btn";
                btnAdd.CausesValidation = false;
                btnCell.Controls.Add(btnAdd);
            }
            return subjectRow;
        }

        protected int refreshAttachRow(Model.CCOM.Subject model)
        {
            int attachRowValue = 0;
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            int subjectId = model.Subject_id;
            TableRow subjectRow = (TableRow)this.subjectTable.FindControl("subjectRow" + subjectId);
            DropDownList value_type = (DropDownList)subjectRow.FindControl("valueType" + subjectId);
            int value = 5;
            if (value_type != null)
            {
                value = Convert.ToInt32(value_type.SelectedValue);
            }
            else
            {
                value = model.Value_type;
            }
            if (value <= 2)
            {
                //有值类型，往下Bind
                int flag = 0;
                foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                {
                    if (Cmodel.Fs_id == model.Subject_id)
                    {
                        attachRowValue = refreshAttachRow(Cmodel);
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    attachRowValue = subjectTable.Rows.GetRowIndex(subjectRow);
                }
                if (value == 0 && flag >= 10)
                {
                    Button btnAdd = (Button)subjectRow.FindControl("btnAdd" + subjectId);
                    btnAdd.Visible = false;
                }
                if (value == 0 && flag < 10)
                {
                    Button btnAdd = (Button)subjectRow.FindControl("btnAdd" + subjectId);
                    btnAdd.Visible = true;
                }
            }
            else
            {
                if (subjectRow.FindControl("btnAdd" + model.Subject_id) != null)
                {
                    subjectRow.FindControl("btnAdd" + model.Subject_id).Visible = false;
                }
                attachRowValue = subjectTable.Rows.GetRowIndex(subjectRow);
            }
            HiddenField attachRow = (HiddenField)subjectRow.FindControl("attachRow" + subjectId);
            attachRow.Value = attachRowValue.ToString();

            return attachRowValue;
        }

        #region 变化触发函数
        protected void valueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList valueType = (DropDownList)sender;
            int subjectId = Convert.ToInt32(valueType.ID.Replace("valueType", ""));
            if (Convert.ToInt32(valueType.SelectedValue) >= 3)
            {
                //无值类型
                changeChildrenRow(subjectDic[subjectId], false, true);
                if (valueType.Parent.FindControl("btnAdd" + subjectId) != null)
                {
                    valueType.Parent.FindControl("btnAdd" + subjectId).Visible = false;
                }
            }
            else
            {
                //有值类型
                changeChildrenRow(subjectDic[subjectId], true, false);
                if (valueType.Parent.FindControl("btnAdd" + subjectId) != null)
                {
                    valueType.Parent.FindControl("btnAdd" + subjectId).Visible = true;
                }
            }
            if (Convert.ToInt32(valueType.SelectedValue) == 2)
            {
                valueType.Parent.FindControl("valueCount" + subjectId).Visible = true;
                valueType.Parent.FindControl("Label1" + subjectId).Visible = true;
                valueType.Parent.FindControl("Label2" + subjectId).Visible = true;
                valueType.Parent.FindControl("btnValueCountUp" + subjectId).Visible = true;
                valueType.Parent.FindControl("btnValueCountDown" + subjectId).Visible = true;
            }
            else
            {
                valueType.Parent.FindControl("valueCount" + subjectId).Visible = false;
                valueType.Parent.FindControl("Label1" + subjectId).Visible = false;
                valueType.Parent.FindControl("Label2" + subjectId).Visible = false;
                valueType.Parent.FindControl("btnValueCountUp" + subjectId).Visible = false;
                valueType.Parent.FindControl("btnValueCountDown" + subjectId).Visible = false;
            }
            rowHadEdit(subjectId);
        }

        void symbol_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton symbol = (ImageButton)sender;
            int subjectId = Convert.ToInt32(symbol.ID.Replace("symbol", ""));
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            if (symbol.ImageUrl == "../../../images/exam/minus.png")
            {
                //无值类型
                changeChildrenRow(subjectDic[subjectId], false, true);
                symbol.ImageUrl = "../../../images/exam/add.png";
            }
            else
            {
                //有值类型
                changeChildrenRow(subjectDic[subjectId], true, true);
                symbol.ImageUrl = "../../../images/exam/minus.png";
            }
        }

        protected void rowHadEdit(int subjectId)
        {
            Model.CCOM.Subject model = subjectDic[subjectId];
            Button btnSave = ((Button)this.subjectTable.FindControl("btnSave" + subjectId));
            if (model.Fs_id != 0)
            {
                rowHadEdit(model.Fs_id);
            }
        }
        #endregion

        #region 增存删隐
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Button btnAdd = (Button)sender;
            int fatherId = Convert.ToInt32(btnAdd.ID.Replace("btnAdd", ""));
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            Model.CCOM.Subject fatherModel = subjectDic[fatherId];

            //新建model
            Model.CCOM.Subject model = new Model.CCOM.Subject();
            //通过父节点赋值
            model.Fs_id = Convert.ToInt32(fatherId);
            model.Major_Agency_id = fatherModel.Major_Agency_id;
            model.Period_id = fatherModel.Period_id;
            model.Subject_level = fatherModel.Subject_level + 1;
            //默认值
            model.Subject_title = "请输入标题";
            model.Value_type = 4;
            if (model.Subject_level == 1 || model.Subject_level == 2)
            {
                if (model.Subject_level == 2)
                {
                    model.Subject_type = false;
                    model.Manage_Agency_id = Convert.ToInt32(ddlDepartment.SelectedValue);
                }
                model.Subject_weight = 1;
            }
            if (model.Subject_level != 0)
            {
                model.Subject_description = "";
            }

            //新建TableRow
            model.Subject_id = bll.Add(model);
            TableRow subjectRow = newSubjectRow(model);
            subjectRow.ID = "subjectRow" + model.Subject_id;
            subjectDic.Add(model.Subject_id, model);

            //找准位置
            TableRow fatherRow = (TableRow)btnAdd.Parent.Parent;
            HiddenField attachRow = (HiddenField)FindControl("attachRow" + fatherId);
            int attachRowValue = Convert.ToInt32(attachRow.Value);
            this.subjectTable.Rows.AddAt(attachRowValue + 1, subjectRow);
            //变颜色
            subjectRow.BackColor = fatherRow.BackColor;
            refreshAttachRow(root);
            rowHadEdit(model.Subject_id);
            MakeClickableErrorMessage();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            saveRow((TableRow)subjectTable.FindControl("subjectRow" + root.Subject_id), false);
            JscriptMsg("保存成功！", "", "Success");
        }

        //通过subjectRow存储数据
        //temp表示是不是临时存储
        //返回为空正确，否则错误语句
        protected void saveRow(TableRow subjectRow, bool temp)
        {
            if (subjectRow.Visible == false)
            {
                return;
            }
            //存自己
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            int subjectId = Convert.ToInt32(subjectRow.ID.Replace("subjectRow", ""));
            Model.CCOM.Subject model = subjectDic[subjectId];
            List<Model.CCOM.Subject> subjectList = bll.GetModelList("Fs_id=" + subjectId);
            if (model.Subject_level != 0)
            {
                TextBox title = (TextBox)subjectRow.FindControl("title" + subjectId);
                model.Subject_title = title.Text;
                DropDownList valueType = (DropDownList)subjectRow.FindControl("valueType" + subjectId);
                model.Value_type = Convert.ToInt32(valueType.SelectedValue);
                if (model.Value_type == 2)
                {
                    TextBox valueCount = (TextBox)subjectRow.FindControl("valueCount" + subjectId);
                    model.Value_count = Convert.ToInt32(valueCount.Text);
                }
                //特殊项
                if (model.Subject_level == 1 || model.Subject_level == 2)
                {
                    if (model.Subject_level == 2)
                    {
                        DropDownList subjectType = (DropDownList)subjectRow.FindControl("subjectType" + subjectId);
                        model.Subject_type = subjectType.SelectedIndex == 1;
                        DropDownList manageAgency = (DropDownList)subjectRow.FindControl("manageAgency" + subjectId);
                        model.Manage_Agency_id = Convert.ToInt32(manageAgency.SelectedValue);
                    }
                    TextBox weight = (TextBox)subjectRow.FindControl("weight" + subjectId);
                    model.Subject_weight = Convert.ToInt32(weight.Text);
                }
                TextBox description = (TextBox)subjectRow.FindControl("description" + subjectId);
                model.Subject_description = description.Text;
                bll.Update(model);
            }
            //临时存仍为修改状态，无子节点
            if (!temp)
            {
                //存子节点
                foreach (Model.CCOM.Subject Cmodel in subjectList)
                {
                    int childrenId = Cmodel.Subject_id;
                    saveRow((TableRow)this.subjectTable.FindControl("subjectRow" + childrenId), false);
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            TableRow subjectRow = (TableRow)btnDelete.Parent.Parent;
            int subjectId = Convert.ToInt32(subjectRow.ID.Replace("subjectRow", ""));
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            bll.Delete(subjectId);
            removeDic(subjectId);
            subjectDic.Clear();
            List<Model.CCOM.Subject> subjectList = bll.GetModelList("Major_Agency_id=" + Convert.ToInt32(this.ddlMajor.SelectedItem.Value));
            foreach (Model.CCOM.Subject subject in subjectList)
            {
                subjectDic.Add(subject.Subject_id, subject);
            }
            refreshAttachRow(root);
        }

        protected void removeDic(int subjectId)
        {
            TableRow subjectRow = (TableRow)this.subjectTable.FindControl("subjectRow" + subjectId);
            this.subjectTable.Rows.Remove(subjectRow);
            foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
            {
                if (Cmodel.Fs_id == subjectId)
                {
                    removeDic(Cmodel.Subject_id);
                }
            }
            subjectTable.Rows.Remove(subjectRow);
        }

        protected void changeChildrenRow(Model.CCOM.Subject subject, bool isShow, bool isMyself)
        {
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            if (!isMyself)
            {
                TableRow subjectRow = (TableRow)this.subjectTable.FindControl("subjectRow" + subject.Subject_id);
                subjectRow.Visible = isShow;
                ImageButton symbol = (ImageButton)subjectRow.FindControl("symbol" + subject.Subject_id);
                if (symbol.ImageUrl == "../../../images/exam/add.png")
                {
                    return;
                }
            }
            foreach (Model.CCOM.Subject model in subjectDic.Values)
            {
                if (model.Fs_id == subject.Subject_id)
                {
                    changeChildrenRow(model, isShow, false);
                }
            }
        }
        #endregion

        #region 绑定机构
        public void BindAgency(DropDownList ddlAgency)
        {
            ddlAgency.DataSource = ds;
            ddlAgency.DataTextField = "Agency_name";
            ddlAgency.DataValueField = "Agency_id";
            ddlAgency.DataBind();
        }

        public void BindChildAgency(Model.CCOM.Agency model, int level)
        {
            string tag = "";
            DataRow dr = dt.NewRow();
            if (model != null)
            {
                for (int i = 0; i < level; i++)
                    tag += "　";
                tag += "┠";
                dr["Agency_name"] = tag + model.Agency_name;
                dr["Agency_id"] = model.Agency_id;
                dt.Rows.Add(dr);
            }
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            List<Model.CCOM.Agency> listAgency = bll.GetModelList(" Agency_father=" + (model == null ? 0 : model.Agency_id));
            if (level <= 2)
            {
                foreach (Model.CCOM.Agency agencyModel in listAgency)
                {
                    BindChildAgency(agencyModel, level + 1);
                }
            }
        }
        #endregion

        //将validator通知变为链接
        private void MakeClickableErrorMessage()
        {
            foreach (BaseValidator validator in this.Validators)
            {
                if (validator.ControlToValidate == string.Empty)
                {
                    continue;
                }
                string clientID = this.FindControl(validator.ControlToValidate).ClientID;
                string script = string.Format("<a href= \"javascript:setFocus('{0}');\">{1}</a>", clientID, validator.ErrorMessage);
                validator.ErrorMessage = script;
            }
        }

        //验证非法输入函数
        void invalid_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !Tools.CheckParams(args.Value);
        }

        //验证缺少子科目
        void lackSonValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToInt32(args.Value) > 2)
            {
                args.IsValid = true;
                return;
            }
            CustomValidator lackSonValidator = (CustomValidator)source;
            int subjectId = Convert.ToInt32(lackSonValidator.ID.Replace("lackSonValidator", ""));
            foreach (Model.CCOM.Subject model in subjectDic.Values)
            {
                if (model.Fs_id == subjectId)
                {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }

        //验证多选子项
        void errorSonValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToInt32(args.Value) > 2)
            {
                args.IsValid = true;
                return;
            }
            CustomValidator lackSonValidator = (CustomValidator)source;
            int subjectId = Convert.ToInt32(lackSonValidator.ID.Replace("errorSonValidator", ""));
            args.IsValid = (subjectDic[subjectDic[subjectId].Fs_id].Value_type != 2);
        }
    }
}