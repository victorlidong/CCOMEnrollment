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
    public partial class Achievement_degree : university.UI.ManagePage
    {
        public long studentID;
        public long relationID=0;//修改参数
        public Achievement_degree()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            studentID = 0;
            if (GetAdminInfo_CCOM().Role_id == 3)
            {
                studentID = GetAdminInfo_CCOM().User_id;
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
               
                if (model == null)
                {
                    ht = " <div class=\"content\" align=\"center\"><h3>您尚无选题<h3><table class=\"table table-striped table-bordered dataTable\"></table></div>";
                    this.print_div.InnerHtml = ht;
                    btnSubmit.Visible = false;
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
            Model.CCOM.Achievement_degree stu_model = new BLL.CCOM.Achievement_degree().GetModel(" Topic_relation_id=" + relationID+"and Assess_type=1");
            Model.CCOM.Achievement_degree tea_model = new BLL.CCOM.Achievement_degree().GetModel(" Topic_relation_id=" + relationID + "and Assess_type=0");
            //如果是指导教师
            if (GetAdminInfo_CCOM().Role_id == 2)
            {
                if (stu_model != null)
                {
                    ddlstudent1.SelectedValue = stu_model.Require_one.ToString();
                    ddlstudent2.SelectedValue = stu_model.Require_two.ToString();
                    ddlstudent3.SelectedValue = stu_model.Require_three.ToString();
                    ddlstudent4.SelectedValue = stu_model.Require_four.ToString();
                    ddlstudent5.SelectedValue = stu_model.Require_five.ToString();
                    ddlstudent6.SelectedValue = stu_model.Require_six.ToString();

                }
                if (tea_model != null)
                {
                    ddlteacher1.SelectedValue = tea_model.Require_one.ToString();
                    ddlteacher2.SelectedValue = tea_model.Require_two.ToString();
                    ddlteacher3.SelectedValue = tea_model.Require_three.ToString();
                    ddlteacher4.SelectedValue = tea_model.Require_four.ToString();
                    ddlteacher5.SelectedValue = tea_model.Require_five.ToString();
                    ddlteacher6.SelectedValue = tea_model.Require_six.ToString();
                }
                ddlstudent1.Enabled = false;
                ddlstudent2.Enabled = false;
                ddlstudent3.Enabled = false;
                ddlstudent4.Enabled = false;
                ddlstudent5.Enabled = false;
                ddlstudent6.Enabled = false;
            }
            else if (GetAdminInfo_CCOM().Role_id == 3)
            {
                if (stu_model != null)
                {
                    ddlstudent1.SelectedValue = stu_model.Require_one.ToString();
                    ddlstudent2.SelectedValue = stu_model.Require_two.ToString();
                    ddlstudent3.SelectedValue = stu_model.Require_three.ToString();
                    ddlstudent4.SelectedValue = stu_model.Require_four.ToString();
                    ddlstudent5.SelectedValue = stu_model.Require_five.ToString();
                    ddlstudent6.SelectedValue = stu_model.Require_six.ToString();

                }
                if (tea_model != null)
                {
                    ddlteacher1.SelectedValue = tea_model.Require_one.ToString();
                    ddlteacher2.SelectedValue = tea_model.Require_two.ToString();
                    ddlteacher3.SelectedValue = tea_model.Require_three.ToString();
                    ddlteacher4.SelectedValue = tea_model.Require_four.ToString();
                    ddlteacher5.SelectedValue = tea_model.Require_five.ToString();
                    ddlteacher6.SelectedValue = tea_model.Require_six.ToString();
                }
                ddlteacher1.Enabled = false;
                ddlteacher2.Enabled = false;
                ddlteacher3.Enabled = false;
                ddlteacher4.Enabled = false;
                ddlteacher5.Enabled = false;
                ddlteacher6.Enabled = false;
            }
            else
            {
                if (stu_model != null)
                {
                    ddlstudent1.SelectedValue = stu_model.Require_one.ToString();
                    ddlstudent2.SelectedValue = stu_model.Require_two.ToString();
                    ddlstudent3.SelectedValue = stu_model.Require_three.ToString();
                    ddlstudent4.SelectedValue = stu_model.Require_four.ToString();
                    ddlstudent5.SelectedValue = stu_model.Require_five.ToString();
                    ddlstudent6.SelectedValue = stu_model.Require_six.ToString();

                }
                if (tea_model != null)
                {
                    ddlteacher1.SelectedValue = tea_model.Require_one.ToString();
                    ddlteacher2.SelectedValue = tea_model.Require_two.ToString();
                    ddlteacher3.SelectedValue = tea_model.Require_three.ToString();
                    ddlteacher4.SelectedValue = tea_model.Require_four.ToString();
                    ddlteacher5.SelectedValue = tea_model.Require_five.ToString();
                    ddlteacher6.SelectedValue = tea_model.Require_six.ToString();
                }
                ddlstudent1.Enabled = false;
                ddlstudent2.Enabled = false;
                ddlstudent3.Enabled = false;
                ddlstudent4.Enabled = false;
                ddlstudent5.Enabled = false;
                ddlstudent6.Enabled = false;
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
            int role = GetAdminInfo_CCOM().Role_id;
            BLL.CCOM.Achievement_degree bll = new BLL.CCOM.Achievement_degree();
            try
            {
                if (GetAdminInfo_CCOM().Role_id == 3)
                {
                    if (ddlstudent1.SelectedValue == "0" || ddlstudent2.SelectedValue == "0" || ddlstudent3.SelectedValue == "0" || ddlstudent4.SelectedValue == "0" || ddlstudent5.SelectedValue == "0" || ddlstudent6.SelectedValue == "0")
                        return "各项得分不能为空";
                    Model.CCOM.Achievement_degree stu_model = new BLL.CCOM.Achievement_degree().GetModel(" Topic_relation_id=" + relationID + "and Assess_type=1");
                    if (stu_model == null)
                    {
                        Model.CCOM.Achievement_degree model = new Model.CCOM.Achievement_degree();
                        model.Topic_relation_id = relationID;
                        model.Assess_type = true;
                        model.Require_one = Convert.ToInt32(ddlstudent1.SelectedValue);
                        model.Require_two = Convert.ToInt32(ddlstudent2.SelectedValue);
                        model.Require_three = Convert.ToInt32(ddlstudent3.SelectedValue);
                        model.Require_four = Convert.ToInt32(ddlstudent4.SelectedValue);
                        model.Require_five = Convert.ToInt32(ddlstudent5.SelectedValue);
                        model.Require_six = Convert.ToInt32(ddlstudent6.SelectedValue);
                        bll.Add(model);
                    }
                    else
                    {
                        Model.CCOM.Achievement_degree model = new BLL.CCOM.Achievement_degree().GetModel(stu_model.Ac_id);
                        model.Require_one = Convert.ToInt32(ddlstudent1.SelectedValue);
                        model.Require_two = Convert.ToInt32(ddlstudent2.SelectedValue);
                        model.Require_three = Convert.ToInt32(ddlstudent3.SelectedValue);
                        model.Require_four = Convert.ToInt32(ddlstudent4.SelectedValue);
                        model.Require_five = Convert.ToInt32(ddlstudent5.SelectedValue);
                        model.Require_six = Convert.ToInt32(ddlstudent6.SelectedValue);
                        bll.Update(model);
                    }
                }
                else//指导教师
                {
                    if (ddlteacher1.SelectedValue == "0" || ddlteacher2.SelectedValue == "0" || ddlteacher3.SelectedValue == "0" || ddlteacher4.SelectedValue == "0" || ddlteacher5.SelectedValue == "0" || ddlteacher6.SelectedValue == "0")
                        return "各项得分不能为空";
                    Model.CCOM.Achievement_degree tea_model = new BLL.CCOM.Achievement_degree().GetModel(" Topic_relation_id=" + relationID + "and Assess_type=0");
                    if (tea_model == null)
                    {
                        Model.CCOM.Achievement_degree model = new Model.CCOM.Achievement_degree();
                        model.Topic_relation_id = relationID;
                        model.Assess_type = false;
                        model.Require_one = Convert.ToInt32(ddlteacher1.SelectedValue);
                        model.Require_two = Convert.ToInt32(ddlteacher2.SelectedValue);
                        model.Require_three = Convert.ToInt32(ddlteacher3.SelectedValue);
                        model.Require_four = Convert.ToInt32(ddlteacher4.SelectedValue);
                        model.Require_five = Convert.ToInt32(ddlteacher5.SelectedValue);
                        model.Require_six = Convert.ToInt32(ddlteacher6.SelectedValue);
                        bll.Add(model);
                    }
                    else
                    {
                        Model.CCOM.Achievement_degree model = new BLL.CCOM.Achievement_degree().GetModel(tea_model.Ac_id);
                        model.Require_one = Convert.ToInt32(ddlteacher1.SelectedValue);
                        model.Require_two = Convert.ToInt32(ddlteacher2.SelectedValue);
                        model.Require_three = Convert.ToInt32(ddlteacher3.SelectedValue);
                        model.Require_four = Convert.ToInt32(ddlteacher4.SelectedValue);
                        model.Require_five = Convert.ToInt32(ddlteacher5.SelectedValue);
                        model.Require_six = Convert.ToInt32(ddlteacher6.SelectedValue);
                        bll.Update(model);
                    }
                }
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
                    JscriptMsg("提交成功！", Utils.CombUrlTxt("Achievement_degree.aspx", "fun_id={0}&studentID={1}", DESEncrypt.Encrypt(this.fun_id), DESEncrypt.Encrypt(this.studentID.ToString())), "Success");
                else
                    JscriptMsg("提交成功！", "MyStudentList.aspx?fun_id=" + get_fun_id("CCOM/ExamArrange/MyStudentList.aspx"), "Success");
            }
            else
                JscriptMsg(result, "", "Error");

        }

    }
}