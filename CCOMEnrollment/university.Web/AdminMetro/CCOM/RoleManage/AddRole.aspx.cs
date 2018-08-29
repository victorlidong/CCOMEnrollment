using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.RoleManage
{
    public partial class AddRole : university.UI.ManagePage
    {
        public string action = MyEnums.ActionEnum.Add.ToString(); //操作类型
        private int roleId = 0;//修改参数
        public AddRole()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            action = MyRequest.GetQueryString("action");
            roleId = MyRequest.GetQueryInt("roleId");
            if (!Page.IsPostBack)
            {
                if (action == MyEnums.ActionEnum.Edit.ToString())
                {
                    if (roleId == 0)
                    {
                        JscriptMsg("传输参数不正确！", "back", "Error");
                        return;
                    }
                    ShowInfo(roleId);
                    this.btnSubmit.Text = "确认保存";
                }
                else
                {
                    this.btnSubmit.Text = "确认添加";
                }
            } 
        }
        
        #region 赋值操作=================================
        private void ShowInfo(long RoleId)
        {
            var bll = new BLL.CCOM.Role();
            var model = bll.GetModel("Role_id=" + RoleId);
            this.txtName.Text = model.Role_name;
        }
        #endregion

        #region 增加/编辑操作=================================
        private string DoAction()
        {
            string result = "";
            BLL.CCOM.Role bll = new BLL.CCOM.Role();
            Model.CCOM.Role model;
            if (action == MyEnums.ActionEnum.Add.ToString())
                model = new Model.CCOM.Role();
            else
                model = bll.GetModel("Role_id=" + roleId);
            string Name = this.txtName.Text.Trim();
            if (Tools.CheckParams(Name))
            {
                return "请勿输入非法字符";
            }

            if (Name == "")
                return "请填写角色名";
            model.Role_name = Name;
            model.Role_status = true;
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
                JscriptMsg(action == MyEnums.ActionEnum.Edit.ToString() ? "修改成功" : "添加成功", "RoleList.aspx", "Success");
                Response.Redirect("RoleList.aspx?fun_id=" + get_fun_id("CCOM/RoleManage/RoleList.aspx"));
            }
            else
                JscriptMsg(result, "", "Error");
        }
    }
}