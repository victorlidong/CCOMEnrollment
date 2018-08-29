using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using university.Common;

namespace university.Web.AdminMetro.CCOM
{
    public partial class AddFatherFunction : university.UI.ManagePage
    {
        public AddFatherFunction()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

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
            /*
            if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
            {
            }
            else
            */
            {
                string result = DoAdd(title, status, sort);
                if (result == "")
                {
                    JscriptMsg("添加成功啦！", "AddFatherFunction.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
                }
                else
                    JscriptMsg(result, "", "Error");
            }
        }

        #region 增加操作=================================
        private string DoAdd(string title, bool status, string sort)
        {
            try
            {
                var model = new Model.CCOM.Father_function();
                model.Ff_name = title;
                model.Ff_disable = status;
                model.Ff_sort = Convert.ToInt32(sort);
                model.Ff_fatherID = 0;

                BLL.CCOM.Father_function Bff = new BLL.CCOM.Father_function();
                Bff.Add(model);
            }
            catch { return "数据更新异常"; }
            return "";
        }
        #endregion
    }
}