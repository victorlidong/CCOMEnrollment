using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ConfExamInfor
{
    public partial class ConfTimeNode : university.UI.ManagePage
    {
        private static long _id = 0;
        public ConfTimeNode()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.CCOM.User_infomation model = GetAdminInfo_CCOM();
            _id = model.User_id;

            if (!Page.IsPostBack)
            {
                InitPage();
            }
        }

        #region 更新操作=================================
        protected void InitPage()
        {
            try
            {
                BLL.CCOM.Period bll = new BLL.CCOM.Period();
                var model = bll.GetModel(" Period_state=" + DataDic.Period_state_On);
                if (model.Period_register_start != null) this.txtApplyStart.Text = Convert.ToDateTime(model.Period_register_start).ToString("yyyy-MM-dd HH:mm");
                if (model.Period_register_end != null) this.txtApplyEnd.Text = Convert.ToDateTime(model.Period_register_end).ToString("yyyy-MM-dd HH:mm");
                if (model.Period_arrange_start != null) this.txtArrangeStart.Text = Convert.ToDateTime(model.Period_arrange_start).ToString("yyyy-MM-dd HH:mm");
                if (model.Period_arrange_end != null) this.txtArrangeEnd.Text = Convert.ToDateTime(model.Period_arrange_end).ToString("yyyy-MM-dd HH:mm");
            }
            catch { }
        }
        #endregion=======================================

        #region 更新操作=================================

        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (this.txtApplyEnd.Text == "" || this.txtApplyStart.Text == "" || this.txtArrangeEnd.Text == "" || this.txtArrangeStart.Text == "")
            {
                JscriptMsg("请完整填写各项", "", "Error");
                return;
            }
            else
            {
                DateTime dt_ApplyStart = Convert.ToDateTime(this.txtApplyStart.Text);
                DateTime dt_ApplyEnd = Convert.ToDateTime(this.txtApplyEnd.Text);
                DateTime dt_ArrangeStart = Convert.ToDateTime(this.txtArrangeStart.Text);
                DateTime dt_ArrangeEnd = Convert.ToDateTime(this.txtArrangeEnd.Text);

                if (DateTime.Compare(dt_ApplyStart, dt_ApplyEnd) >= 0)
                {
                    JscriptMsg("注册开启时间必须小于结束时间", "", "Error");
                    return;
                }
                if (DateTime.Compare(dt_ApplyEnd, dt_ArrangeStart) >= 0)
                {
                    JscriptMsg("注册结束时间必须小于排考开启时间", "", "Error");
                    return;
                }
                if (DateTime.Compare(dt_ArrangeStart, dt_ArrangeEnd) >= 0)
                {
                    JscriptMsg("排考开启时间必须小于排考结束时间", "", "Error");
                    return;
                }
                
                try
                {
                    BLL.CCOM.Period bll = new BLL.CCOM.Period();
                    var model = bll.GetModel(" Period_state="+DataDic.Period_state_On);

                    if (model != null)
                    {
                        model.Period_register_start = dt_ApplyStart;
                        model.Period_register_end = dt_ApplyEnd;
                        model.Period_arrange_start = dt_ArrangeStart;
                        model.Period_arrange_end = dt_ArrangeEnd;
                        bll.Update(model);
                    }
                    else
                    {
                        JscriptMsg("请开启当前周期", "", "Error");
                        return;
                    }
                }
                catch
                {
                    JscriptMsg("数据格式有误", "", "Error");
                    return;
                }
            }

            Response.Redirect("ConfAgency.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id.ToString()));
        }
        #endregion

    }
}