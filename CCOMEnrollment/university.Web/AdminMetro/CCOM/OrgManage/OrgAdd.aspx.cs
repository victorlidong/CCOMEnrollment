using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.OrgManage
{
    public partial class OrgAdd : university.UI.ManagePage
    {
        protected int UD_PID = 0;
        protected int TYPE_ID = 0;
        protected string selectOrgan = MyRequest.GetQueryString("selectid");
        protected bool completeFirstIntro = false;
        public OrgAdd()
        {
            this.checkFunID = false;
            //this.fun_id = MyRequest.GetQueryString("fun_id");
            this.checkUserStaus = false;
            //this.adminfuncition = true;
            this.checkSchoolLevelAdminUser = false;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListItem list1 = new ListItem("行政机构", "0");
                ListItem list2 = new ListItem("部", "1");
                ListItem list3 = new ListItem("系", "2");
                ListItem list4 = new ListItem("专业", "3");
                //this.DropDownList1.Items.Add(list1);
                //this.DropDownList1.Items.Add(list2);
                //this.DropDownList1.Items.Add(list3);
                //this.DropDownList1.Items.Add(list4);

                Model.CCOM.Agency model = new BLL.CCOM.Agency().GetModel(1);
                //this.hiduo_id.Value = model.Agency_id.ToString();

                //this.ddlAddParentID.DataSource = GetOrgList_DataSet(false);
                //this.ddlAddParentID.DataTextField = "Agency_name";
                //this.ddlAddParentID.DataValueField = "Agency_id";
                //this.ddlAddParentID.DataBind();

                try
                {
                    UD_PID = Utils.StrToInt(DESEncrypt.Decrypt(MyRequest.GetString("selectid")), 0);
                }
                catch { }
                //this.ddlAddParentID.SelectedValue = selectOrgan.ToString();
                //}
            }
        }

        protected void btnAddSubmit_Click(object sender, EventArgs e)
        { 
            //BLL.admin.Universities_Organization bll = new BLL.admin.Universities_Organization();
            //Model.admin.Universities_Organization modelfather = new Model.admin.Universities_Organization();
            //TYPE_ID = Utils.StrToInt(this.DropDownList1.SelectedValue, 0);

            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            Model.CCOM.Agency modelfather = new Model.CCOM.Agency();
            int UO_ID = 0;
            try
            {
                //UO_ID = Utils.StrToInt(this.ddlAddParentID.SelectedValue, 0);
                modelfather = bll.GetModel(UO_ID);
            }
            catch { modelfather = null; }

            if (modelfather != null)
            {
                Model.CCOM.Agency model = new Model.CCOM.Agency();
                //string[] names = this.txtAddName.Text.Split('|');
                int result = 0;
                int i = 0;
                //foreach (string name in names)
                //{
                //    if (name == "") continue;
                //    if (Tools.CheckParams(name)) 
                //    {
                //        result = 0;
                //        break;
                //    }
                //    model.Agency_name = name;
                //    model.Agency_father = UO_ID;
                //    model.Agency_type = TYPE_ID;
                //    model.Agency_status = true;
                //    result = bll.Add(model);
                //    if (result == 0)
                //        break;
                //}
        
                if (result == 0)
                {
                    JscriptMsg("添加失败，输入异常！", "back", "Error");
                }
                else
                {
                    //bll.ddlBind(this.ddlAddParentID, Utils.StrToInt(this.hiduo_id.Value, -11)); //绑定父级部门
                    JscriptMsg("添加成功！", "OrgAdd.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
                }
            }
            else JscriptMsg("添加失败，请选择自己可以管理的机构！", "back", "Error");
        }
    
    }
}