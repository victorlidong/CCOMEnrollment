using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using university.Common;
using System.Web.UI.WebControls;

namespace university.Web.AdminMetro.CCOM.StudentApply
{
    public partial class StudentApply3 : university.UI.ManagePage
    {
        Model.CCOM.Subject root = null;
        long userId = 0;
        Dictionary<int, Model.CCOM.Subject> subjectDic = new Dictionary<int, Model.CCOM.Subject>();
        Dictionary<int, Dictionary<int, Model.CCOM.User_subject_value>> oldDic = new Dictionary<int, Dictionary<int, Model.CCOM.User_subject_value>>();
        Dictionary<int, Dictionary<int, Model.CCOM.User_subject_value>> newDic = new Dictionary<int, Dictionary<int, Model.CCOM.User_subject_value>>();
        Model.CCOM.Period period = null;

        String[,] levelCountValue = {
        {"一、","二、","三、","四、","五、","六、","七、","八、","九、","十、"},
        {"1.","2.","3.","4.","5.","6.","7.","8.","9.","10."},
        {"1)","2)","3)","4)","5)","6)","7)","8)","9)","10)"},
        {"①","②","③","④","⑤","⑥","⑦","⑧","⑨","⑩"},
        {"a.","b.","c.","d.","e.","f.","g.","h.","i.","j."},
        {"a)","b)","c)","d)","e)","f)","g)","h)","i)","j)"}
        };

        public StudentApply3()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //检查是否是考生
                try
                {
                    Model.CCOM.User_information user_model = GetAdminInfo_CCOM();
                    if (user_model.User_type == 6)
                    {
                        JscriptMsg("只有考生用户可以报考！", "back", "Error");
                        return;
                    }
                }
                catch
                {
                    Response.Redirect("/adminmetro/center.aspx");
                }
                //检查前面步骤是否完成
                checkBefore();
            }
            period = new BLL.CCOM.Period().GetModel("Period_state=1");
            BindAllSubject();
            MakeClickableErrorMessage();
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void checkBefore()
        {
            bool error = false;
            //添加验证信息是否齐全
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(GetAdminInfo_CCOM().User_id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + user_model.User_id);
            if (new BLL.CCOM.Family_member().GetRecordCount(" User_id = '" + user_model.User_id + "' ") < 1)
            {
                error = true;
            }
            if (user_model.User_realname == null || user_model.User_realname == "")
            {
                error = true;
            }
            if (user_model.User_birthday == null || user_model.User_realname == "")
            {
                error = true;
            }
            if (userEx_model.UP_nationality == null || userEx_model.UP_nationality < 1)
            {
                error = true;
            }
            if (userEx_model.UP_province == null || userEx_model.UP_province < 1)
            {
                error = true;
            }
            if (userEx_model.UP_degree == null || userEx_model.UP_degree < 1)
            {
                error = true;
            }
            if (userEx_model.UP_politics == null || userEx_model.UP_politics < 1)
            {
                error = true;
            }
            if (userEx_model.UP_high_school == null || userEx_model.UP_high_school == "")
            {
                error = true;
            }
            if (userEx_model.UP_CEE_number == null || userEx_model.UP_CEE_number == "")
            {
                error = true;
            }
            if (userEx_model.Agency_id < 1)
            {
                error = true;
            }
            if (userEx_model.UP_nation == null || userEx_model.UP_nation < 1)
            {
                error = true;
            }
            if (userEx_model.UP_PE_Aphone == null || userEx_model.UP_PE_Aphone == "")
            {
                error = true;
            }
            if (userEx_model.UP_PE_Iphone == null || userEx_model.UP_PE_Iphone == "")
            {
                error = true;
            }
            if (userEx_model.UP_postal_code == null || userEx_model.UP_postal_code == "")
            {
                error = true;
            }
            if (userEx_model.UP_address == null || userEx_model.UP_address == "")
            {
                error = true;
            }
            if (userEx_model.UP_receiver == null || userEx_model.UP_receiver == "")
            {
                error = true;
            }
            if (userEx_model.UP_receiver_phone == null || userEx_model.UP_receiver_phone == "")
            {
                error = true;
            }
            if (user_model.User_ID_number_type == null || user_model.User_ID_number_type < 1)
            {
                error = true;
            }
            if (user_model.User_ID_number == null || user_model.User_ID_number == "")
            {
                error = true;
            }
            if (userEx_model.UP_ID_picture == null || userEx_model.UP_ID_picture == "")
            {
                error = true;
            }
            if (userEx_model.UP_picture == null || userEx_model.UP_picture == "")
            {
                error = true;
            }
            if (userEx_model.UP_AEE_number == null || userEx_model.UP_AEE_number == "")
            {
                error = true;
            }
            if (userEx_model.UP_AEE_picture == null || userEx_model.UP_AEE_picture == "")
            {
                error = true;
            }
            if (error)
            {
                JscriptMsg("请先完成前步操作", Utils.CombUrlTxt("StudentApply1.aspx", "fun_id={0}", get_fun_id("CCOM/StudentApply/StudentApply1.aspx")), "Error");
            }
        }

        protected void BindAllSubject()
        {
            userId = GetAdminInfo_CCOM().User_id;
            BLL.CCOM.User_property pbll = new BLL.CCOM.User_property();
            Model.CCOM.User_property pmodel = pbll.GetModel("User_id=" + userId);
            int majorId = pmodel.Agency_id;
            //科目字典
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            try
            {
                List<Model.CCOM.Subject> subjectList = bll.GetModelList("Major_Agency_id=" + majorId);
                foreach (Model.CCOM.Subject subject in subjectList)
                {
                    subjectDic.Add(subject.Subject_id, subject);
                }
            }
            catch (Exception e)
            {
                return;
            }
            //旧值字典
            BLL.CCOM.User_subject_value vbll = new BLL.CCOM.User_subject_value();
            try
            {
                List<Model.CCOM.User_subject_value> valueList = vbll.GetModelList("User_id=" + GetAdminInfo_CCOM().User_id);
                foreach (Model.CCOM.User_subject_value value in valueList)
                {
                    if (!oldDic.ContainsKey(value.Subject_id))
                    {
                        oldDic.Add(value.Subject_id, new Dictionary<int, Model.CCOM.User_subject_value>());
                    }
                    if (value.Usv_children == null)
                    {
                        oldDic[value.Subject_id].Add(0, value);
                    }
                    else
                    {
                        oldDic[value.Subject_id].Add((int)value.Usv_children, value);
                    }
                }
            }
            catch (Exception e)
            {
                return;
            }
            root = bll.GetModel("Major_Agency_id=" + majorId + "and Subject_level=0");
            foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
            {
                if (Cmodel.Fs_id == root.Subject_id)
                {
                    BindTest(Cmodel);
                }
            }

        }

        protected void BindTest(Model.CCOM.Subject model)
        {
            HtmlGenericControl widgetPurpleDiv = new HtmlGenericControl();
            widgetPurpleDiv.TagName = "div";
            widgetPurpleDiv.Attributes["class"] = "widget purple";
            divControls.Controls.Add(widgetPurpleDiv);

            HtmlGenericControl widgetTitleDiv = new HtmlGenericControl();
            widgetTitleDiv.TagName = "div";
            widgetTitleDiv.Attributes["class"] = "widget-title";
            widgetPurpleDiv.Controls.Add(widgetTitleDiv);
            HtmlGenericControl ff1NameH4 = new HtmlGenericControl();
            ff1NameH4.TagName = "h4";
            ff1NameH4.InnerHtml = model.Subject_title;
            widgetTitleDiv.Controls.Add(ff1NameH4);
            HtmlGenericControl toolsSpan = new HtmlGenericControl();
            toolsSpan.TagName = "span";
            toolsSpan.Attributes["class"] = "tools";
            widgetTitleDiv.Controls.Add(toolsSpan);
            HtmlGenericControl iconA = new HtmlGenericControl();
            iconA.TagName = "a";
            iconA.Attributes["href"] = "javascript:;";
            iconA.Attributes["class"] = "icon-chevron-down";
            toolsSpan.Controls.Add(iconA);

            HtmlGenericControl widgetBodyDiv = new HtmlGenericControl();
            widgetBodyDiv.TagName = "div";
            widgetBodyDiv.Attributes["class"] = "widget-body";
            widgetBodyDiv.Attributes["style"] = "display: block;";
            widgetPurpleDiv.Controls.Add(widgetBodyDiv);

            BindSubject(model, widgetBodyDiv, 0, true);
        }

        //children:0表示不是子节点，超过0表示第几个子节点
        protected void BindSubject(Model.CCOM.Subject model, HtmlGenericControl div, int children, bool isShow)
        {
            BLL.CCOM.Subject bll = new BLL.CCOM.Subject();
            int subjectId = model.Subject_id;
            Panel subjectPanel = null;
            if (children != 0)
            {
                subjectPanel = newSubjectPanel(model, children);
                subjectPanel.Visible = isShow;
                div.Controls.Add(subjectPanel);
            }
            if (children <= 0)
            {
                if (children != 0)
                {
                    subjectPanel.ID = "subjectPanel" + subjectId;
                }
                //子节点
                if (model.Value_type == 0)
                {
                    int i = 0;
                    //多项类型，往下Bind
                    foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                    {
                        if (Cmodel.Fs_id == model.Subject_id)
                        {
                            BindSubject(Cmodel, div, -++i, isShow);
                        }
                    }
                }
                else if (model.Value_type == 1)
                {
                    //单选，绑一个
                    BindSubject(model, div, 1, isShow);
                }
                else if (model.Value_type == 2)
                {
                    //多选类型，有几个绑几个
                    for (int i = 1; i <= model.Value_count; i++)
                    {
                        BindSubject(model, div, i, isShow);
                    }
                }
            }
            else
            {
                subjectPanel.ID = "subjectPanel" + subjectId + "children" + children;
                foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                {
                    if (Cmodel.Fs_id == subjectId)
                    {
                        BindSubject(Cmodel, div, 0, false);
                    }
                }
            }
        }

        protected void BindData()
        {
            foreach (Dictionary<int, Model.CCOM.User_subject_value> oldChildrenDic in oldDic.Values)
            {
                foreach (Model.CCOM.User_subject_value valueModel in oldChildrenDic.Values)
                {
                    if (valueModel.Usv_children != null)
                    {
                        DropDownList ddlTitle = (DropDownList)this.divControls.FindControl("title" + valueModel.Subject_id + "children" + valueModel.Usv_children);
                        ddlTitle.SelectedValue = valueModel.Usv_value;
                        visibleChange(ddlTitle);
                        TextBox tbValue = (TextBox)this.divControls.FindControl("value" + valueModel.Subject_id + "children" + valueModel.Usv_children);
                        if (tbValue != null && oldDic.ContainsKey(Convert.ToInt32(valueModel.Usv_value)))
                        {
                            Model.CCOM.User_subject_value cValueModel = oldDic[Convert.ToInt32(valueModel.Usv_value)][0];
                            tbValue.Text = cValueModel.Usv_value;
                        }
                    }
                    else
                    {
                        TextBox tbValue = null;
                        if (subjectDic[valueModel.Subject_id].Value_type == 3)
                        {
                            tbValue = (TextBox)this.divControls.FindControl("value" + valueModel.Subject_id);
                            if (tbValue != null)
                            {
                                tbValue.Text = valueModel.Usv_value;
                            }
                        }
                    }
                }
            }
        }

        //children:0表示不是子节点，超过0表示第几个子节点
        protected void showSubject(Model.CCOM.Subject model, int children, bool isShow)
        {
            int subjectId = model.Subject_id;
            Panel subjectPanel = null;
            if (children <= 0)
            {
                subjectPanel = (Panel)this.divControls.FindControl("subjectPanel" + subjectId);
                if (model.Value_type == 0)
                {
                    //多项类型，往下Bind
                    int i = 0;
                    foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                    {
                        if (Cmodel.Fs_id == model.Subject_id)
                        {
                            showSubject(Cmodel, -++i, isShow);
                        }
                    }
                }
                else if (model.Value_type == 1)
                {
                    //单选，绑一个
                    showSubject(model, 1, isShow);
                }
                else if (model.Value_type == 2)
                {
                    //多选类型，有几个绑几个
                    for (int i = 1; i <= model.Value_count; i++)
                    {
                        showSubject(model, i, isShow);
                    }
                }
            }
            else
            {
                subjectPanel = (Panel)this.divControls.FindControl("subjectPanel" + model.Subject_id + "children" + children);
                DropDownList title = (DropDownList)subjectPanel.FindControl("title" + model.Subject_id + "children" + children);
                HiddenField oldTitle = (HiddenField)subjectPanel.FindControl("oldTitle" + model.Subject_id + "children" + children);
                Label description = (Label)subjectPanel.FindControl("description" + model.Subject_id + "children" + children);
                if (title.Text != oldTitle.Value)
                {
                    if (oldTitle.Value != "#")
                    {
                        foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                        {
                            if (Cmodel.Fs_id == Convert.ToInt32(oldTitle.Value))
                            {
                                showSubject(Cmodel, 0, false);
                            }
                        }
                    }
                    if (title.Text != "#")
                    {
                        foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                        {
                            if (Cmodel.Fs_id == Convert.ToInt32(title.Text))
                            {
                                showSubject(Cmodel, 0, true);
                            }
                        }
                        if (subjectDic[Convert.ToInt32(title.SelectedValue)].Value_type == 3)
                        {
                            subjectPanel.FindControl("value" + model.Subject_id + "children" + children).Visible = true;
                            ((RequiredFieldValidator)subjectPanel.FindControl("valueValidator" + model.Subject_id + "children" + children)).Enabled = true;
                            ((CustomValidator)subjectPanel.FindControl("CvalueValidator" + model.Subject_id + "children" + children)).Enabled = true;
                        }
                        else
                        {
                            subjectPanel.FindControl("value" + model.Subject_id + "children" + children).Visible = false;
                            ((RequiredFieldValidator)subjectPanel.FindControl("valueValidator" + model.Subject_id + "children" + children)).Enabled = false;
                            ((CustomValidator)subjectPanel.FindControl("CvalueValidator" + model.Subject_id + "children" + children)).Enabled = false;
                        }
                        description.Text = ":" + model.Subject_description;
                    }
                    else
                    {
                        subjectPanel.FindControl("value" + model.Subject_id + "children" + children).Visible = false;
                        ((RequiredFieldValidator)subjectPanel.FindControl("valueValidator" + model.Subject_id + "children" + children)).Enabled = false;
                        ((CustomValidator)subjectPanel.FindControl("CvalueValidator" + model.Subject_id + "children" + children)).Enabled = false;
                        description.Text = "";
                    }
                    oldTitle.Value = title.Text;
                }
            }
            subjectPanel.Visible = isShow;
        }

        protected Panel newSubjectPanel(Model.CCOM.Subject model, int children)
        {
            int level = model.Subject_level;
            int subjectId = model.Subject_id;
            //当前项Panel
            Panel subjectPanel = new Panel();
            subjectPanel.Height = 35;
            Label numLabel = new Label();
            subjectPanel.Controls.Add(numLabel);
            //空格和数字
            string blank = "";
            for (int i = 0; i < model.Subject_level; i++)
            {
                blank += "&nbsp;&nbsp;";
            }
            if (children > 0)
            {
                blank += "&nbsp;&nbsp;";
                numLabel.Text = blank + levelCountValue[model.Subject_level - 1, Math.Abs(children) - 1];
            }
            else
            {
                numLabel.Text = blank + levelCountValue[model.Subject_level - 2, Math.Abs(children) - 1];
            }

            //标题
            Label subjectLabel = new Label();
            if (children > 0)
            {
                DropDownList title = new DropDownList();
                title.ID = "title" + subjectId + "children" + children;
                title.Items.Add(new ListItem("请选择一项", "#"));
                foreach (Model.CCOM.Subject Cmodel in subjectDic.Values)
                {
                    if (Cmodel.Fs_id == subjectId)
                    {
                        ListItem item = new ListItem();
                        item.Value = Cmodel.Subject_id.ToString();
                        item.Text = Cmodel.Subject_title;
                        title.Items.Add(item);
                    }
                }
                title.SelectedIndex = 0;
                title.SelectedIndexChanged += title_SelectedIndexChanged;
                title.AutoPostBack = true;
                subjectPanel.Controls.Add(title);

                HiddenField oldTitle = new HiddenField();
                oldTitle.ID = "oldTitle" + subjectId + "children" + children;
                oldTitle.Value = title.SelectedValue;
                subjectPanel.Controls.Add(oldTitle);

                RequiredFieldValidator titleValidator = new RequiredFieldValidator();
                titleValidator.ControlToValidate = "title" + subjectId + "children" + children;
                titleValidator.ID = "titleValidator" + subjectId + "children" + children;
                titleValidator.Display = ValidatorDisplay.Dynamic;
                titleValidator.ErrorMessage = "请选择一项考试项目";
                titleValidator.InitialValue = "#";
                subjectPanel.Controls.Add(titleValidator);
            }
            else
            {
                subjectLabel.Text += model.Subject_title;
                if (model.Subject_level == 2)
                {
                    subjectLabel.Font.Bold = true;
                }
            }
            if (level == 2)
            {
                //笔试/面试
                subjectLabel.Text += "(" + ((bool)model.Subject_type ? "面试" : "笔试") + ")";
            }
            subjectLabel.Text += "&nbsp";
            subjectPanel.Controls.Add(subjectLabel);
            //文本
            TextBox value = new TextBox();
            value.Text = "请输入曲目";
            value.Attributes.Add("OnFocus", "if(this.value=='请输入曲目') {this.value=''}");
            value.Attributes.Add("OnBlur", "if(this.value==''){this.value='请输入曲目'}");
            subjectPanel.Controls.Add(value);
            RequiredFieldValidator valueValidator = new RequiredFieldValidator();
            valueValidator.Display = ValidatorDisplay.Dynamic;
            valueValidator.ErrorMessage = "请输入曲目";
            valueValidator.InitialValue = "请输入曲目";
            CustomValidator CvalueValidator = new CustomValidator();
            CvalueValidator.Display = ValidatorDisplay.Dynamic;
            CvalueValidator.ServerValidate += CvalueValidator_ServerValidate;
            CvalueValidator.ErrorMessage = "请勿输入非法字符";
            if (children > 0)
            {
                value.ID = "value" + model.Subject_id + "children" + children;
                valueValidator.ControlToValidate = "value" + model.Subject_id + "children" + children;
                valueValidator.ID = "valueValidator" + model.Subject_id + "children" + children;
                CvalueValidator.ControlToValidate = "value" + model.Subject_id + "children" + children;
                CvalueValidator.ID = "CvalueValidator" + model.Subject_id + "children" + children;
            }
            else
            {
                value.ID = "value" + model.Subject_id;
                valueValidator.ControlToValidate = "value" + model.Subject_id;
                valueValidator.ID = "valueValidator" + model.Subject_id;
                CvalueValidator.ControlToValidate = "value" + model.Subject_id;
                CvalueValidator.ID = "CvalueValidator" + model.Subject_id;
            }
            subjectPanel.Controls.Add(valueValidator);
            subjectPanel.Controls.Add(CvalueValidator);


            if (model.Value_type != 3)
            {
                valueValidator.Enabled = false;
                CvalueValidator.Enabled = false;
                value.Visible = false;
            }

            Label description = new Label();
            description.Text = ":" + model.Subject_description.ToString();
            description.Font.Italic = true;
            subjectPanel.Controls.Add(description);
            if (children > 0)
            {
                description.ID = "description" + model.Subject_id + "children" + children;
            }
            else
            {
                description.ID = "description" + model.Subject_id;
            }

            return subjectPanel;
        }

        void CvalueValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !Tools.CheckParams(args.Value);
        }

        void title_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList title = (DropDownList)sender;
            visibleChange(title);
        }

        void visibleChange(DropDownList title)
        {
            int childrenIndex = title.ID.IndexOf("children");
            String subjectString = title.ID.Substring(0, childrenIndex);
            String childrenString = title.ID.Replace(subjectString, "");
            int fatherId = Convert.ToInt32(subjectString.Replace("title", ""));
            int childrenId = Convert.ToInt32(childrenString.Replace("children", ""));
            showSubject(subjectDic[fatherId], childrenId, true);
        }

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }
            if (DateTime.Now > period.Period_register_end)
            {
                JscriptMsg("已超过注册时间！", Utils.CombUrlTxt("../center.aspx", "fun_id={0}", DESEncrypt.Encrypt(this.fun_id)), "Error");
            }
            // 新值字典
            foreach (BaseValidator validator in this.Validators)
            {
                Panel subjectPanel = (Panel)validator.Parent;
                if (subjectPanel.Visible == true && validator.Enabled == true)
                {
                    int childrenIndex = subjectPanel.ID.IndexOf("children");
                    if (validator.ID.Contains("title"))
                    {
                        //下拉框
                        String subjectString = subjectPanel.ID.Substring(0, childrenIndex);
                        String childrenString = subjectPanel.ID.Replace(subjectString, "");
                        int fatherId = Convert.ToInt32(subjectString.Replace("subjectPanel", ""));
                        int childrenId = Convert.ToInt32(childrenString.Replace("children", ""));
                        DropDownList ddlTitle = (DropDownList)subjectPanel.FindControl("title" + fatherId + "children" + childrenId);
                        Model.CCOM.User_subject_value valueModel = new Model.CCOM.User_subject_value();
                        valueModel.User_id = userId;
                        valueModel.Subject_id = fatherId;
                        valueModel.Usv_children = childrenId;
                        valueModel.Usv_value = ddlTitle.SelectedValue;
                        if (!newDic.ContainsKey(fatherId))
                        {
                            newDic.Add(fatherId, new Dictionary<int, Model.CCOM.User_subject_value>());
                        }
                        if (!newDic[fatherId].ContainsKey(childrenId))
                        {
                            newDic[fatherId].Add(childrenId, valueModel);
                        }
                    }
                    else
                    {
                        //文本
                        int subjectId = 0;
                        TextBox tbValue = null;
                        if (childrenIndex == -1)
                        {
                            //非子节点
                            subjectId = Convert.ToInt32(subjectPanel.ID.Replace("subjectPanel", ""));
                            tbValue = (TextBox)subjectPanel.FindControl("value" + subjectId);
                        }
                        else
                        {
                            //子节点
                            String childrenString = subjectPanel.ID.Replace("subjectPanel", "");
                            //拿到下拉框取值
                            DropDownList ddltitle = (DropDownList)subjectPanel.FindControl("title" + childrenString);
                            subjectId = Convert.ToInt32(ddltitle.SelectedValue);
                            tbValue = (TextBox)subjectPanel.FindControl("value" + childrenString);
                        }
                        if (!newDic.ContainsKey(subjectId))
                        {
                            Model.CCOM.User_subject_value valueModel = new Model.CCOM.User_subject_value();
                            valueModel.User_id = userId;
                            valueModel.Subject_id = subjectId;
                            valueModel.Usv_value = tbValue.Text;
                            newDic.Add(subjectId, new Dictionary<int, Model.CCOM.User_subject_value>());
                            newDic[subjectId].Add(0, valueModel);
                        }
                    }
                }

            }

            BLL.CCOM.User_subject_value vbll = new BLL.CCOM.User_subject_value();
            // 对比update
            foreach (Dictionary<int, Model.CCOM.User_subject_value> newChildrenDic in newDic.Values)
            {
                foreach (Model.CCOM.User_subject_value valueModel in newChildrenDic.Values)
                {
                    if (subjectDic[valueModel.Subject_id].Value_type == 3)
                    {
                        if (oldDic.ContainsKey(valueModel.Subject_id))
                        {
                            valueModel.Usv_id = oldDic[valueModel.Subject_id][0].Usv_id;
                            vbll.Update(valueModel);
                            oldDic.Remove(valueModel.Subject_id);
                        }
                        else
                        {
                            vbll.Add(valueModel);
                        }
                    }
                    else
                    {
                        if (oldDic.ContainsKey(valueModel.Subject_id) && oldDic[valueModel.Subject_id].ContainsKey((int)valueModel.Usv_children))
                        {
                            valueModel.Usv_id = oldDic[valueModel.Subject_id][(int)valueModel.Usv_children].Usv_id;
                            vbll.Update(valueModel);
                            oldDic[valueModel.Subject_id].Remove((int)valueModel.Usv_children);
                        }
                        else
                        {
                            vbll.Add(valueModel);
                        }
                    }
                }
            }
            // 批量删除
            String deleteList = "";
            bool isFirst = true;
            foreach (Dictionary<int, Model.CCOM.User_subject_value> oldChildrenDic in oldDic.Values)
            {
                foreach (Model.CCOM.User_subject_value valueModel in oldChildrenDic.Values)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        deleteList += ",";
                    }
                    deleteList += "'" + valueModel.Usv_id + "'";
                }
            }
            if (!isFirst)
            {
                vbll.DeleteList(deleteList);
            }
            JscriptMsg("报考成功！", Utils.CombUrlTxt("../center.aspx", "fun_id={0}", DESEncrypt.Encrypt(this.fun_id)), "Success");
        }
    }
}