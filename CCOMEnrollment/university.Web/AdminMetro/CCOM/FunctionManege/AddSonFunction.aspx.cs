using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using university.Common;
using System.Web.UI.WebControls;
using System.Data;

namespace university.Web.AdminMetro.CCOM
{
    public partial class AddSonFunction : university.UI.ManagePage
    {
        public AddSonFunction()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定一级父功能
                BindFf1_ID();
            }  
        }

        public void BindFf1_ID()
        {
            string sql = " Ff_fatherID = " + university.Common.DataDic.Father_Function;
            BLL.CCOM.Father_function Bff = new BLL.CCOM.Father_function();
            DataSet ds = Bff.GetList(sql);
            this.ddlFf1_ID.DataSource = ds.Tables[0].DefaultView;
            this.ddlFf1_ID.DataTextField = "Ff_name";
            this.ddlFf1_ID.DataValueField = "Ff_id";
            this.ddlFf1_ID.DataBind();
            ListItem item = new ListItem("--请选择一级父功能--", "#");
            this.ddlFf1_ID.Items.Insert(0, item);
        }

        protected void ddlFf1_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Ff_fatherID = this.ddlFf1_ID.SelectedItem.Value;
            if (Ff_fatherID.Equals("#"))
            {
                this.ddlFf2_ID.Items.Clear();
                ListItem item1 = new ListItem("--请选择二级父功能--", "#");
                this.ddlFf2_ID.Items.Insert(0, item1);
                JscriptMsg("请选择一级父功能！", "", "Error");
                return;
            }
            string sql = " Ff_fatherID = " + Ff_fatherID;
            BLL.CCOM.Father_function Bff = new BLL.CCOM.Father_function();
            DataSet ds = Bff.GetList(sql);

            this.ddlFf2_ID.Items.Clear();

            this.ddlFf2_ID.DataSource = ds.Tables[0].DefaultView;
            this.ddlFf2_ID.DataTextField = "Ff_name";
            this.ddlFf2_ID.DataValueField = "Ff_id";
            this.ddlFf2_ID.DataBind();
            ListItem item = new ListItem("--请选择二级父功能--", "#");
            this.ddlFf2_ID.Items.Insert(0, item);
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


            string Ff1_fatherID = this.ddlFf1_ID.SelectedItem.Value;
            if (Ff1_fatherID.Equals("#"))
            {
                JscriptMsg("请选择一级父功能！", "", "Error");
                return;
            }
            string Ff2_fatherID = this.ddlFf2_ID.SelectedItem.Value;
            if (Ff2_fatherID.Equals("#"))
            {
                JscriptMsg("请选择二级父功能！", "", "Error");
                return;
            }

            /*
            if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
            {
            }
            else
            */
            {
                string result = DoAdd(title, status, sort, Ff2_fatherID, url);
                if (result == "")
                {
                    JscriptMsg("添加成功啦！", "AddSonFunction.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
                }
                else
                    JscriptMsg(result, "", "Error");
            }
        }

        #region 增加操作=================================
        private string DoAdd(string title, bool status, string sort, string Ff_fatherID, string url)
        {
            try
            {
                var model = new Model.CCOM.Son_function();
                model.Sf_name = title;
                model.Sf_status = status;
                model.Sf_sort = Convert.ToInt32(sort);
                model.Ff_ID = Convert.ToInt32(Ff_fatherID);
                model.Sf_url = url;

                BLL.CCOM.Son_function Bsf = new BLL.CCOM.Son_function();
                Bsf.Add(model);
            }
            catch { return "数据更新异常"; }
            return "";
        }
        #endregion
    }
}