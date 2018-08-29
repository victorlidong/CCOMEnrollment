using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ScoreManage
{
    public partial class ComputScore : university.UI.ManagePage
    {
        public ComputScore()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }
        #region 赋值操作=================================
        protected void ShowInfo()
        {
            var model = new BLL.CCOM.Comput_score().GetModel(1);
            this.txtTeacher.Text = model.Ratio_teacher.ToString();
            this.txtOther.Text = model.Ratio_review.ToString();
            this.ddlM.SelectedValue = model.Ratio_software == 1 ? "1" : "0";
        }
        #endregion

        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Model.CCOM.Comput_score model = new BLL.CCOM.Comput_score().GetModel(1);
                model.Ratio_teacher = decimal.Parse(this.txtTeacher.Text);
                model.Ratio_review = decimal.Parse(this.txtOther.Text);
                model.Ratio_software = this.ddlM.SelectedValue == "1" ? 1 : 0;
                if (new BLL.CCOM.Comput_score().Update(model))
                {
                    JscriptMsg("提交成功！", "ComputScore.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
                }
                else
                {
                    JscriptMsg("提交失败！", "", "Error");
                }
            }
            catch 
            {
                JscriptMsg("提交异常！", "", "Error");
            }
            
        }

    }
}