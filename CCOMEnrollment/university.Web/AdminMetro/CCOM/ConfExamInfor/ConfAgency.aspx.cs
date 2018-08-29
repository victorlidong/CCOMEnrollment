using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ConfExamInfor
{
    public partial class ConfAgency : university.UI.ManagePage
    {
        private static long _id = 0;
        public ConfAgency()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _id = GetAdminInfo_CCOM().User_id;

            if (!Page.IsPostBack)
            {
                Model.CCOM.Agency model = new BLL.CCOM.Agency().GetModel(1);
                this.ChildUOCount =
                    new BLL.CCOM.Agency().GetModelList(" Agency_father=1").Count;
                bindall();
            }
        }

        #region 更新操作=================================

        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConfMajor.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id.ToString()));
        }
        #endregion

        #region 机构操作================================
        public int ChildUOCount = -1;
        public int StuCount = -1;
        protected bool completeFirstIntro = false;
        public long adminuserid = 0;
        
        public string GetNodeData()
        {
            List<Model.CCOM.Agency> list = new BLL.CCOM.Agency().GetModelList(" ");
            LitJson.JsonData data = new LitJson.JsonData();
            data.SetJsonType(LitJson.JsonType.Array);
            int i = 0;
            int toplevel = -1;
            foreach (Model.CCOM.Agency org in list)
            {
                LitJson.JsonData line = new LitJson.JsonData();
                if (i++ == 0)
                    line["childOuter"] = false;
                if (toplevel == -1)
                    toplevel = 1;
                line["id"] = org.Agency_id.ToString();
                line["pId"] = org.Agency_father.ToString();
                //line["id"] = DESEncrypt.Encrypt(org.Agency_id.ToString());
                //line["pId"] = DESEncrypt.Encrypt(org.Agency_father.ToString());
                line["name"] = org.Agency_name;
                if (!org.Agency_status) line["name"] += "（已禁用）";
                line["iconSkin"] = "diy01";
                if (org.Agency_type < 2)
                  line["open"] = true;
                data.Add(line);
            }
            return data.ToJson();
        }
        protected void bindall()
        {
            BLL.CCOM.Agency bll = new  BLL.CCOM.Agency();

            this.ddlSelectUD.DataSource = GetOrgList_DataSet(false);
            this.ddlSelectUD.DataTextField = "Agency_name";
            this.ddlSelectUD.DataValueField = "Agency_id";
            this.ddlSelectUD.DataBind();
            //List<Model.admin.Universities_Organization> list = GetAdminUserOrg_List(false);

            if (MyRequest.GetString("selectid") != "")
                this.ddlSelectUD.SelectedValue = MyRequest.GetString("selectid");
            else if (MyRequest.GetString("keywords") != "")
            {
                if (Tools.CheckParams(MyRequest.GetString("keywords")) == false)
                {
                    List<Model.CCOM.Agency> uds = bll.GetModelList(" UO_Name like '%" + MyRequest.GetString("keywords").ToString() + "%' ");
                    if (uds.Count > 0)
                        this.ddlSelectUD.SelectedValue = uds[0].Agency_id.ToString();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("OrgList.aspx", "fun_id={0}&selectid={1}&keywords={2}", DESEncrypt.Encrypt(fun_id), "",""));
        }

        //删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int selectID = Utils.StrToInt(this.ddlSelectUD.SelectedValue, -1);
            BLL.CCOM.Admin_agency admin_bll = new BLL.CCOM.Admin_agency();
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            if (selectID == 1) 
            {
                JscriptMsg("删除失败，该机构不能删除！", "", "Error");
                return;
            }
            if (new BLL.CCOM.User_property().GetModel(" Agency_id=" + selectID) != null) 
            {
                JscriptMsg("该机构下不为空，请先删除机构下用户，再删除机构！", "", "Error");
                return;
            }
            bool result = false;
            try { 
                result = bll.Delete(selectID);
            }catch{
                JscriptMsg("删除失败！", "", "Error");
            }
            if (result == false)
                JscriptMsg("删除失败！", "", "Error");
            else
            {
                JscriptMsg("删除成功！", "", "Success");
                Response.Redirect(Utils.CombUrlTxt("OrgList.aspx", "fun_id={0}&selectid={1}&keywords={2}", DESEncrypt.Encrypt(fun_id), "",""));
            }
        }

        protected void trDepartmentList_SelectedNodeChanged(object sender, EventArgs e)
        {
            //this.ddlSelectUD.SelectedValue = this.trDepartmentList.SelectedValue;
            Response.Redirect(Utils.CombUrlTxt("OrgList.aspx", "fun_id={0}&selectid={1}&keywords={2}", DESEncrypt.Encrypt(fun_id), this.ddlSelectUD.SelectedValue.ToString(), ""));
        }
        #endregion

    }
}