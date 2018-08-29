using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using university.Common;
using System.Web.UI.WebControls;

namespace university.Web.AdminMetro.CCOM
{
    public partial class AddFatherFunction1 : university.UI.ManagePage
    {
        public AddFatherFunction1()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {    
            if (!IsPostBack)
            {
                BindFf_ID();
            } 
        }


        public void BindFf_ID()
        {
            string sql = " Ff_fatherID = " + university.Common.DataDic.Father_Function;
            BLL.CCOM.Father_function Bff = new BLL.CCOM.Father_function();
            DataSet ds = Bff.GetList(sql);
            this.ddlFf_ID.DataSource = ds.Tables[0].DefaultView;
            this.ddlFf_ID.DataTextField = "Ff_name";
            this.ddlFf_ID.DataValueField = "Ff_id";
            this.ddlFf_ID.DataBind();
            ListItem item = new ListItem("--请选择一级父功能--", "#");
            this.ddlFf_ID.Items.Insert(0, item);
        }

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            string sort = this.txtSort.Text.Trim();
            var status = this.optOpen.Checked ? false : true;
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

            string Ff_fatherID = this.ddlFf_ID.SelectedItem.Value;
            if(Ff_fatherID.Equals("#"))
            {
                JscriptMsg("请选择一级父功能！", "", "Error");
                return;
            }

            /*
            if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
            {
            }
            else
            */
            {
                string result = DoAdd(title, status, sort, Ff_fatherID);
                if (result == "")
                {
                    JscriptMsg("添加成功啦！", "AddFatherFunction1.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
                }
                else
                    JscriptMsg(result, "", "Error");
            }
        }

        #region 增加操作=================================
        private string DoAdd(string title, bool status, string sort, string Ff_fatherID)
        {
            try
            {
                var model = new Model.CCOM.Father_function();
                model.Ff_name = title;
                model.Ff_disable = status;
                model.Ff_sort = Convert.ToInt32(sort);
                model.Ff_fatherID = Convert.ToInt32(Ff_fatherID);

                BLL.CCOM.Father_function Bff = new BLL.CCOM.Father_function();
                Bff.Add(model);
            }
            catch { return "数据更新异常"; }
            return "";
        }
        #endregion
    }
}