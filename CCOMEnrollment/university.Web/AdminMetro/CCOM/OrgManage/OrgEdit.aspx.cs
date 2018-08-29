using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.OrgManage
{
    public partial class OrgEdit : university.UI.ManagePage
    {
        public OrgEdit()
        {
            this.checkFunID = false;
            //this.fun_id = MyRequest.GetQueryString("fun_id");
            this.checkUserStaus = false;
            //this.adminfuncition = true;
            this.checkSchoolLevelAdminUser = false;
            this.fun_id = MyRequest.GetQueryString("fun_id");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindall();
            }
        }

        protected void bindall()
        {

            Model.CCOM.Agency model = new BLL.CCOM.Agency().GetModel(1);
            if (model == null) InnerRedirect(MyEnums.RediirectErrorEnum.NotAdmin);
            else
            {
                this.hiduoid.Value = model.Agency_id.ToString();
                BLL.CCOM.Agency bll = new BLL.CCOM.Agency();

                this.ddlEditSelect.DataSource = GetOrgList_DataSet(true);
                this.ddlEditSelect.DataTextField = "Agency_name";
                this.ddlEditSelect.DataValueField = "Agency_id";
                this.ddlEditSelect.DataBind();

                int UO_ID = 0;
                try {
                    UO_ID = Utils.StrToInt(MyRequest.GetQueryString("selectid"), 0);
                }
                catch { }
                if (UO_ID == 0 || UO_ID == -1 || UO_ID == 1)
                {
                    this.txtEditName.Enabled = false;
                    this.rbEditStatus.Enabled = false;
                    this.btnEditSubmit.Enabled = false;
                    this.ddlType.Enabled = false;
                }
                else
                {
                    this.txtEditName.Enabled = true;
                    this.rbEditStatus.Enabled = true;
                    this.btnEditSubmit.Enabled = true;
                    this.ddlType.Enabled = true;
                    Model.CCOM.Agency uo = bll.GetModel(UO_ID);
                    this.ddlEditSelect.SelectedValue = MyRequest.GetString("selectid");
                    this.txtEditName.Text = uo.Agency_name;
                    this.ddlType.SelectedValue = uo.Agency_type.ToString();
                    if (uo.Agency_status)
                    { 
                        this.rbEditStatus.SelectedValue = "1";
                    }else
                    {
                        this.rbEditStatus.SelectedValue = "0";
                    }
                }

            }
        }

        protected void btnEditSubmit_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            int UO_ID = 0;
            try { UO_ID = Utils.StrToInt(MyRequest.GetQueryString("selectid"), 0); }
            catch { }
            if (UO_ID == 0 || UO_ID == -1)
            {
                JscriptMsg("添加失败，输入异常！", "back", "Error");
                return;
            }
            Model.CCOM.Agency model = bll.GetModel(UO_ID);
            String orgName = txtEditName.Text.Trim();
            if(Tools.CheckParams(orgName))
            {
                JscriptMsg("添加失败，输入异常！", "back", "Error");
                return;
            }else{
                model.Agency_name = orgName;
            }
            
            if (rbEditStatus.SelectedItem.Text.Equals("启用"))
            {
                model.Agency_status = true;
            }
            else if (rbEditStatus.SelectedItem.Text.Equals("停用"))
            {
                model.Agency_status = false;
            }
            try
            {
                model.Agency_type = int.Parse(this.ddlType.SelectedValue);
            }
            catch
            {
                JscriptMsg("添加失败，输入异常！", "back", "Error");
                return;
            }
            
            bool result = bll.Update(model);
            if (result == false)
            {
                JscriptMsg("添加失败，输入异常！", "back", "Error");
            }
            else
            {
                JscriptMsg("编辑成功！", "OrgList.aspx?fun_id=" + DESEncrypt.Encrypt(fun_id) + "&selectid=" + DESEncrypt.Encrypt(UO_ID.ToString()), "Success");
            }
        }

        protected void ddlEditSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("OrgEdit.aspx?fun_id=" + DESEncrypt.Encrypt(fun_id) + "&selectid=" + this.ddlEditSelect.SelectedValue.ToString());
        }

    }
}