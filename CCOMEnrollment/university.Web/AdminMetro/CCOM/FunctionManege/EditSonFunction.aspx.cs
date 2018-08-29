using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.FunctionManege
{
    public partial class EditSonFunction : university.UI.ManagePage
    {
        public EditSonFunction()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                clearTxt();
                //绑定一级父功能
                BindFf1_ID();
            }
        }

        public void BindFf1_ID()
        {
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Ff_name", typeof(string)));
            dt.Columns.Add(new DataColumn("Ff_id", typeof(string))); //加密后的id
            addOtherDll(dt, DataDic.Father_Function, 0);
            ds.Tables.Add(dt);

            this.ddlFf2_ID.DataSource = ds;
            this.ddlFf2_ID.DataTextField = "Ff_name";
            this.ddlFf2_ID.DataValueField = "Ff_id";
            this.ddlFf2_ID.DataBind();
        }

        private void addOtherDll(DataTable dt, int ID, int level)
        {
            BLL.CCOM.Father_function bll = new BLL.CCOM.Father_function();
            Model.CCOM.Father_function model = bll.GetModel(" Ff_id=" + ID);
            DataRow dr = dt.NewRow();
            string tag = "";
            if (ID > 0)
            {
                for (int i = 0; i < level; i++)
                    tag += "　";
                tag += "┠";
                dr["Ff_name"] = tag + model.Ff_name;
                if (model.Ff_fatherID == DataDic.Father_Function)
                    dr["Ff_id"] = 0;
                else
                    dr["Ff_id"] = model.Ff_id;
            }
            else
            {
                dr["Ff_name"] = "--请选择父功能--";
                dr["Ff_id"] = 0;
            }
            dt.Rows.Add(dr);
            List<Model.CCOM.Father_function> listFf = bll.GetModelList(" Ff_fatherID=" + ID);
            foreach (Model.CCOM.Father_function Ffc in listFf)
            {
                addOtherDll(dt, Ffc.Ff_id, level + 1);
            }

        }

        protected void ddlFf2_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearTxt();
            string Ff_fatherID = this.ddlFf2_ID.SelectedItem.Value;
            if (Ff_fatherID.Equals("0"))
            {
                this.ddlSf_ID.Items.Clear();
                ListItem item1 = new ListItem("--请选择功能--", "0");
                this.ddlSf_ID.Items.Insert(0, item1);
                JscriptMsg("请选择二级父功能！", "", "Error");
                return;
            }
            string sql = " Ff_ID = " + Ff_fatherID;
            BLL.CCOM.Son_function Bsf = new BLL.CCOM.Son_function();
            DataSet ds = Bsf.GetList(sql);

            this.ddlSf_ID.Items.Clear();

            this.ddlSf_ID.DataSource = ds.Tables[0].DefaultView;
            this.ddlSf_ID.DataTextField = "Sf_name";
            this.ddlSf_ID.DataValueField = "Sf_id";
            this.ddlSf_ID.DataBind();
            ListItem item = new ListItem("--请选择功能--", "0");
            this.ddlSf_ID.Items.Insert(0, item);
        }

        protected void ddlSf_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Sf_ID = this.ddlSf_ID.SelectedItem.Value;
            if (Sf_ID.Equals("0"))
            {
                JscriptMsg("请选择要编辑子功能！", "", "Error");
                return;
            }
            string sql = " Sf_ID = " + Sf_ID;
            BLL.CCOM.Son_function Bsf = new BLL.CCOM.Son_function();
            Model.CCOM.Son_function Msf = Bsf.GetModel(Convert.ToInt32(Sf_ID));

            this.txtTitle.Text = Msf.Sf_name;
            this.txtURL.Text = Msf.Sf_url;
            this.txtSort.Text = Msf.Sf_sort.ToString();

            if (Msf.Sf_status == true)
            {
                this.optOpen.Checked = true;
                this.optClose.Checked = false; 
            }
            else
            {
                this.optOpen.Checked = false;
                this.optClose.Checked = true;    
            }               
        }

        public void clearTxt()
        {
            this.txtTitle.Text = "";
            this.txtURL.Text = "";
            this.txtSort.Text = "";
            this.optOpen.Checked = false;
            this.optClose.Checked = false;  
        }
        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            string sort = this.txtSort.Text.Trim();
            string url = this.txtURL.Text.Trim();
            var status = this.optOpen.Checked ? true : false;

            if (title == "")
            {
                JscriptMsg("功能名称不能为空！", "", "Error");
                return;
            }
            if (title.Length > 40)
            {
                JscriptMsg("功能名称不能多于40字！", "", "Error");
                return;
            }
            if (Tools.CheckParams(title))
            {
                JscriptMsg("功能名称不合法！", "", "Error");
                return;
            }
            /*
            if (Tools.CheckParams(url))
            {
                JscriptMsg("链接不合法！", "", "Error");
                return;
            }
            */
            if (sort == "")
            {
                JscriptMsg("排序值不能为空！", "", "Error");
                return;
            }
            if (Tools.CheckParams(sort))
            {
                JscriptMsg("排序值不合法！", "", "Error");
                return;
            }


            string Ff2_fatherID = this.ddlFf2_ID.SelectedItem.Value;
            if (Ff2_fatherID.Equals("0"))
            {
                JscriptMsg("请选择二级父功能！", "", "Error");
                return;
            }

            string Sf_ID = this.ddlSf_ID.SelectedItem.Value;
            if (Ff2_fatherID.Equals("0"))
            {
                JscriptMsg("请选择要编辑子功能！", "", "Error");
                return;
            }

            /*
            if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
            {
            }
            else
            */
            {
                string result = DoEdit(title, status, sort, Ff2_fatherID, url, Sf_ID);
                if (result == "")
                {
                    JscriptMsg("更新成功啦！", "EditSonFunction.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
                }
                else
                    JscriptMsg(result, "", "Error");
            }
        }

        #region 更新操作=================================
        private string DoEdit(string title, bool status, string sort, string Ff_fatherID, string url, string Sf_ID)
        {
            try
            {
                var model = new Model.CCOM.Son_function();
                model.Sf_id = Convert.ToInt32(Sf_ID);
                model.Sf_name = title;
                model.Sf_status = status;
                model.Sf_sort = Convert.ToInt32(sort);
                model.Ff_ID = Convert.ToInt32(Ff_fatherID);
                model.Sf_url = url;

                BLL.CCOM.Son_function Bsf = new BLL.CCOM.Son_function();
                Bsf.Update(model);
            }
            catch { return "数据更新异常"; }
            return "";
        }
        #endregion
    }
}