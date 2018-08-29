using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.IO;  

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class Tracking_evaluation : university.UI.ManagePage
    {
        public long relationID;//修改参数
        public long studentID;
        public Tracking_evaluation()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            relationID = 0;
            studentID = 0;
            if (GetAdminInfo_CCOM().Role_id == 3)
            {
                studentID = GetAdminInfo_CCOM().User_id;
                this.btnSubmit.Visible = false;
            }
            else
                studentID = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("studentID")));
            string ht = "";
            Model.CCOM.Topic_relation model = new Model.CCOM.Topic_relation();
            model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + studentID + "and Accept_state=1");
            if (model != null)
                relationID = model.Topic_relation_id;
            if (!Page.IsPostBack)
            {
                if (studentID == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                //if(GetAdminInfo_CCOM().Role_id != 3)
                //{
                //    JscriptMsg("只有学生用户才可以提交材料！", "back", "Error");
                //    return;
                //}
               
                if (model == null)
                {
                    ht = " <div class=\"content\" align=\"center\"><h3>您尚无选题<h3><table class=\"table table-striped table-bordered dataTable\"></table></div>";
                    this.print_div.InnerHtml = ht;
                }
                else
                {
                    ShowInfo();
                }
            } 
        }

        #region 赋值操作=================================
        public void ShowInfo()
        {
            //Model.CCOM.Tracking_evaluation stu_model = new BLL.CCOM.Tracking_evaluation().GetModel(" Topic_relation_id=" + relationID+"and Assess_type=1");
            Model.CCOM.Tracking_evaluation tea_model = new BLL.CCOM.Tracking_evaluation().GetModel(" Topic_relation_id=" + relationID );
            if (tea_model != null)
            {
                ddlteacher1.SelectedValue = tea_model.Track_one.ToString();
                ddlteacher2.SelectedValue = tea_model.Track_two.ToString();
                ddlteacher3.SelectedValue = tea_model.Track_three.ToString();
                ddlteacher4.SelectedValue = tea_model.Track_four.ToString();
                ddlteacher5.SelectedValue = tea_model.Track_five.ToString();
                ddlteacher6.SelectedValue = tea_model.Track_six.ToString();
            }
            if (GetAdminInfo_CCOM().Role_id != 2)
            {
                ddlteacher1.Enabled = false;
                ddlteacher2.Enabled = false;
                ddlteacher3.Enabled = false;
                ddlteacher4.Enabled = false;
                ddlteacher5.Enabled = false;
                ddlteacher6.Enabled = false;
            }
            
        }
        #endregion

        #region 增加/编辑操作=================================
        private string DoAction()
        {
            string result = "";

            string t1 = ddlteacher1.SelectedValue;
            string t2 = ddlteacher2.SelectedValue;
            string t3 = ddlteacher3.SelectedValue;
            string t4 = ddlteacher4.SelectedValue;
            string t5 = ddlteacher5.SelectedValue;
            string t6 = ddlteacher6.SelectedValue;

            if (t1 == "0" || t2 == "0" || t3 == "0" || t4 == "0" || t5 == "0" || t6 == "0") {
                return "请评分后在提交该表";
            }


            int role = GetAdminInfo_CCOM().Role_id;
            BLL.CCOM.Tracking_evaluation bll = new BLL.CCOM.Tracking_evaluation();
            try
            {
                Model.CCOM.Tracking_evaluation tea_model = new BLL.CCOM.Tracking_evaluation().GetModel(" Topic_relation_id=" + relationID );
                if (tea_model == null)
                {
                    Model.CCOM.Tracking_evaluation model = new Model.CCOM.Tracking_evaluation();
                    model.Topic_relation_id = relationID;
                    model.Track_one = Convert.ToInt32(ddlteacher1.SelectedValue);
                    model.Track_two = Convert.ToInt32(ddlteacher2.SelectedValue);
                    model.Track_three = Convert.ToInt32(ddlteacher3.SelectedValue);
                    model.Track_four = Convert.ToInt32(ddlteacher4.SelectedValue);
                    model.Track_five = Convert.ToInt32(ddlteacher5.SelectedValue);
                    model.Track_six = Convert.ToInt32(ddlteacher6.SelectedValue);
                    bll.Add(model);
                }
                else
                {
                    Model.CCOM.Tracking_evaluation model = new BLL.CCOM.Tracking_evaluation().GetModel(tea_model.Te_id);
                    model.Track_one = Convert.ToInt32(ddlteacher1.SelectedValue);
                    model.Track_two = Convert.ToInt32(ddlteacher2.SelectedValue);
                    model.Track_three = Convert.ToInt32(ddlteacher3.SelectedValue);
                    model.Track_four = Convert.ToInt32(ddlteacher4.SelectedValue);
                    model.Track_five = Convert.ToInt32(ddlteacher5.SelectedValue);
                    model.Track_six = Convert.ToInt32(ddlteacher6.SelectedValue);
                    bll.Update(model);
                }
                //}
             }
             catch {
                result = "提交发生异常";
            }
           
            return result;
        }
        #endregion


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = DoAction();
            if (result == "")
            {
                if (GetAdminInfo_CCOM().Role_id == 3)
                    JscriptMsg("提交成功！", Utils.CombUrlTxt("Tracking_evaluation.aspx", "fun_id={0}&studentID={1}", DESEncrypt.Encrypt(this.fun_id), DESEncrypt.Encrypt(this.studentID.ToString())), "Success");
                else
                    JscriptMsg("提交成功！", "MyStudentList.aspx?fun_id=" + get_fun_id("CCOM/ExamArrange/MyStudentList.aspx"), "Success");
            }
            else
                JscriptMsg(result, "", "Error");

        }

    }
}