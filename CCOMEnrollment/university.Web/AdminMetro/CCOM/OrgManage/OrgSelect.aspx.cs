using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.OrgManage
{
    public partial class OrgSelect : university.UI.ManagePage
    {
        public OrgSelect()
        {
            //this.checkFunID = true;
            this.checkFunID = false;
            this.checkUserStaus = false;
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
        public string GetNodeData()
        {
            List<Model.CCOM.Agency> list = new BLL.CCOM.Agency().GetModelList(" ");
            LitJson.JsonData data = new LitJson.JsonData();
            data.SetJsonType(LitJson.JsonType.Array);
            int i = 0;
            foreach (Model.CCOM.Agency org in list)
            {
                //if (i++ == 0)
                //    continue;
                LitJson.JsonData line = new LitJson.JsonData();
                line["id"] = org.Agency_id.ToString();
                line["pId"] = org.Agency_father.ToString();
                line["name"] = org.Agency_name;
                if (!org.Agency_status) line["name"] += "（已禁用）";
                line["isParent"] = true;
                if (org.Agency_type < 2)
                    line["open"] = true;
                data.Add(line);
            }
            return data.ToJson();
        }

        protected void bindall()
        {

            Model.CCOM.Agency model = new BLL.CCOM.Agency().GetModel(1);
            if (model == null) InnerRedirect(MyEnums.RediirectErrorEnum.NotAdmin);
            else
            {
                this.hiduoid.Value = model.Agency_id.ToString();
                BLL.CCOM.Agency bll = new BLL.CCOM.Agency();

                int UO_ID = 0;
                try {
                    UO_ID = Convert.ToInt32(DESEncrypt.Decrypt(MyRequest.GetQueryString("selectid")));
                }
                catch { }

            }
        }

        //递归更改部门状态
        public void UpdateDepartmentState(int UO_ID, bool Activity)
        {
            var bll = new BLL.CCOM.Agency();
            Model.CCOM.Agency modeluo = bll.GetModel(UO_ID);
            if (modeluo != null)
            {
                modeluo.Agency_status = Activity;
                bll.Update(modeluo);
            }

            List<Model.CCOM.Agency> uds = bll.GetModelList(" Agency_father=" + UO_ID);
            foreach (Model.CCOM.Agency ud in uds)
            {
                UpdateDepartmentState(ud.Agency_id,Activity);
            }
        }

    }
}