using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class ExamEdit : university.UI.ManagePage
    {
        public int Group_id = 0;
        public string action; //操作类型
        public ExamEdit()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            action = MyEnums.ActionEnum.Add.ToString();
            Group_id = 0;
            action = MyRequest.GetQueryString("action");
            if (!Page.IsPostBack)
            {
             //   InitPage();
                BindId_replytype();
                if (action == MyEnums.ActionEnum.Edit.ToString())
                {
                    Group_id = int.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("id")));
                    InitView();
                    this.btnSubmit.Text = "确认保存";
                }
                else
                {
                    this.btnSubmit.Text = "确认添加";
                }
            }
        }

        public void BindId_replytype()
        {

            ListItem item1 = new ListItem("--请选择--", "#");
            ListItem item2 = new ListItem("口头答辩", "0");
            ListItem item3 = new ListItem("软件验收", "1");
            ListItem item4 = new ListItem("开题评审", "2");
            this.ddltype.Items.Add(item1);
            this.ddltype.Items.Add(item2);
            this.ddltype.Items.Add(item3);
            this.ddltype.Items.Add(item4);
        }
     

        protected void InitView() {
            Model.CCOM.Reply_group model = new BLL.CCOM.Reply_group().GetModel(Group_id);
            if (model != null) {
                try
                {
                    BLL.CCOM.User_information user_bll =new BLL.CCOM.User_information();
                    Model.CCOM.User_information user_model = new Model.CCOM.User_information();
                  
                    this.txtGroupName.Text = model.Group_name;
                    this.txtReplyTime.Value = model.Reply_time.ToString("yyyy-MM-dd HH:mm:ss");
                    this.txtReplyRoom.Text = model.Reply_room;
                    user_model=user_bll.GetModel( model.User_id);
                    this.txtTeaNumber.Text = user_model.User_number;
                    this.ddltype.SelectedValue = model.Group_type.ToString();
                }
                catch { }
            }
        }

        #region 增加/编辑操作=================================
        private string DoAction()
        {
            string result = "";
            BLL.CCOM.Reply_group bll = new BLL.CCOM.Reply_group();
            Model.CCOM.Reply_group model;
            if (action != MyEnums.ActionEnum.Edit.ToString())
                model = new Model.CCOM.Reply_group();
            else
                model = bll.GetModel(Group_id);
            string GroupName = this.txtGroupName.Text.Trim();
            string TeaNumber = this.txtTeaNumber.Text.Trim();
           // string Time = this.txtReplyTime.Text.Trim();
            string Room = this.txtReplyRoom.Text.Trim();
            string Goup_type = this.ddltype.SelectedValue;
            //必填部分
            if (Tools.CheckParams(GroupName + TeaNumber  + Room))
            {
                return "请勿输入非法字符";
            }

            if (GroupName == "")
                return "请填答辩组名称";
            if (TeaNumber == "")
                return "请填组长工号";
            if (this.txtReplyTime.Value == "")
                return "请填写答辩时间";
            if (Room == "")
                return "请填写答辩地点";

            if (Goup_type == "#")
            {
                return "请选择答辩类型";
            }
            else if (Goup_type == "0")
                model.Group_type = 0;
            else if (Goup_type == "1")
            {
                model.Group_type = 1;
            }
            else if (Goup_type == "2")
            {
                model.Group_type = 2;
            }

            model.Group_name = GroupName;
            model.Reply_time = Convert.ToDateTime(this.txtReplyTime.Value); ;
            model.Reply_room = Room;
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information uset_model;
            uset_model=user_bll.GetModel("User_number='"+TeaNumber+"'and Role_id!=3");
            if (uset_model == null)
                return "该教师用户不存在";
            else
                model.User_id = uset_model.User_id;

           
           
            try
            {
                if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
                {
                    bll.Update(model);
                }
                else
                {
                    bll.Add(model);
                }
            }
            catch (Exception ex)
            {
                result = action == MyEnums.ActionEnum.Edit.ToString() ? "修改失败" : "添加失败" + ex.Message.ToString();
            }

            return result;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = DoAction();
            if (result == "")
            {
                JscriptMsg(action == MyEnums.ActionEnum.Edit.ToString() ? "修改成功" : "添加成功", "ExamList.aspx", "Success");
                Response.Redirect("ExamList.aspx?fun_id=" + get_fun_id("CCOM/ExamArrange/ExamList.aspx"));
            }
            else
                JscriptMsg(result, "", "Error");
        }

        #region 清除下拉选择框中的重复项==========================
        protected void Resetlist(DropDownList ddl) {
            DropDownList newDdl = new DropDownList();
            foreach (ListItem item in ddl.Items)
            {
                if (newDdl.Items.FindByText(item.Text) == null)
                {
                    newDdl.Items.Add(item);
                }
            }
            ddl.Items.Clear();
            foreach (ListItem item in newDdl.Items)
            {
                ddl.Items.Add(item);
            }
        }
        #endregion

    }
}