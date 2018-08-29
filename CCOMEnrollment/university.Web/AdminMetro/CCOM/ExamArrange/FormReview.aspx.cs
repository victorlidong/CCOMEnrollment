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
    public partial class FormReview : university.UI.ManagePage
    {
        public long studentID;
        protected string reviewTr;
        protected bool isCanEdit = false;
        public FormReview()
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
            {
                studentID = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("studentID")));
            }
            this.MyUserID.Text = studentID.ToString();
            if (!Page.IsPostBack)
            {
                if (studentID == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                string ht = "";
                Model.CCOM.Topic_relation model = new Model.CCOM.Topic_relation();
                model = new BLL.CCOM.Topic_relation().GetModel(" Student_id=" + studentID + "and Accept_state=1");
                if (model == null)
                {
                    ht = " <div class=\"content\" align=\"center\"><h3>您尚无选题<h3></div>";
                    this.print_div.InnerHtml = ht;
                    //JscriptMsg("您尚无选题！", "back", "Error");
                    //return;

                }
                else
                {
                    AddSubmitButton();
                    ShowInfo();
                }
            } 
        }

        #region 赋值操作=================================
        public void ShowInfo()
        {
            var form_models = new BLL.CCOM.Form().GetModelList(" Form_page=1");
            for (int i = 0; i < form_models.Count / 3; i++)
            {
                int form1_id = form_models[i].Form_id;
                int form2_id = form_models[1 * form_models.Count / 3 + i].Form_id;
                int form3_id = form_models[2 * form_models.Count / 3 + i].Form_id;


                var form_model1 = new BLL.CCOM.Form().GetModel(form1_id);
                var form_model2 = new BLL.CCOM.Form().GetModel(form2_id);
                var form_model3 = new BLL.CCOM.Form().GetModel(form3_id);

                var form_value1 = new BLL.CCOM.Form_value().GetModel(" User_id=" + studentID + " and Form_id=" + form1_id);
                var form_value2 = new BLL.CCOM.Form_value().GetModel(" User_id=" + studentID + " and Form_id=" + form2_id);
                var form_value3 = new BLL.CCOM.Form_value().GetModel(" User_id=" + studentID + " and Form_id=" + form3_id);

                reviewTr += "<tr>";
                if (form_model1.Ff_id == 0) reviewTr += "<td style=\"width:10%\">" + form_model1.Form_name + "</td>";
                else reviewTr += "<td style=\"width:10%\">——" + form_model1.Form_name + "</td>";
                reviewTr += "<td style=\"width:2%\">";
                reviewTr += "<select runat=\"server\" id=\"ddl" + form1_id + "\" " + GetIsDisabled() + " onchange=\"ChangeSelectValue(this," + studentID + "," + form1_id + ")\" style=\"width:120px\">";
                if (form_value1 == null)
                {
                    reviewTr += "<option value=\"0\">不存在项目</option>";
                    reviewTr += "<option value=\"1\">合格</option>";
                    reviewTr += "<option value=\"2\">不合格</option>";
                }
                else
                {
                    if (form_value1.Self_value == 0) reviewTr += "<option value=\"0\" selected=\"selected\">不存在项目</option>";
                    else reviewTr += "<option value=\"0\">不存在项目</option>";
                    if (form_value1.Self_value == 1) reviewTr += "<option value=\"1\" selected=\"selected\">合格</option>";
                    else reviewTr += "<option value=\"1\">合格</option>";
                    if (form_value1.Self_value == 2) reviewTr += "<option value=\"2\" selected=\"selected\">不合格</option>";
                    else reviewTr += "<option value=\"2\">不合格</option>";
                }
                reviewTr += "</select>";
                reviewTr += "</td>";
                if (form_model2.Ff_id == 0) reviewTr += "<td style=\"width:10%\">" + form_model2.Form_name + "</td>";
                else reviewTr += "<td style=\"width:10%\">——" + form_model2.Form_name + "</td>";
                reviewTr += "<td style=\"width:2%\">";
                reviewTr += "<select runat=\"server\" id=\"ddl" + form2_id + "\" " + GetIsDisabled() + " onchange=\"ChangeSelectValue(this," + studentID + "," + form2_id + ")\" style=\"width:120px\">";
                if (form_value2 == null)
                {
                    reviewTr += "<option value=\"0\">不存在项目</option>";
                    reviewTr += "<option value=\"1\">合格</option>";
                    reviewTr += "<option value=\"2\">不合格</option>";
                }
                else
                {
                    if (form_value2.Self_value == 0) reviewTr += "<option value=\"0\" selected=\"selected\">不存在项目</option>";
                    else reviewTr += "<option value=\"0\">不存在项目</option>";
                    if (form_value2.Self_value == 1) reviewTr += "<option value=\"1\" selected=\"selected\">合格</option>";
                    else reviewTr += "<option value=\"1\">合格</option>";
                    if (form_value2.Self_value == 2) reviewTr += "<option value=\"2\" selected=\"selected\">不合格</option>";
                    else reviewTr += "<option value=\"2\">不合格</option>";
                }
                reviewTr += "</select>";
                reviewTr += "</td>";
                if (form_model3.Ff_id == 0) reviewTr += "<td style=\"width:10%\">" + form_model3.Form_name + "</td>";
                else reviewTr += "<td style=\"width:10%\">——" + form_model3.Form_name + "</td>";
                reviewTr += "<td style=\"width:2%\">";
                reviewTr += "<select runat=\"server\" id=\"ddl" + form3_id + "\" " + GetIsDisabled() + " onchange=\"ChangeSelectValue(this," + studentID + "," + form3_id + ")\" style=\"width:120px\">";
                if (form_value3 == null)
                {
                    reviewTr += "<option value=\"0\">不存在项目</option>";
                    reviewTr += "<option value=\"1\">合格</option>";
                    reviewTr += "<option value=\"2\">不合格</option>";
                }
                else
                {
                    if (form_value3.Self_value == 0) reviewTr += "<option value=\"0\" selected=\"selected\">不存在项目</option>";
                    else reviewTr += "<option value=\"0\">不存在项目</option>";
                    if (form_value3.Self_value == 1) reviewTr += "<option value=\"1\" selected=\"selected\">合格</option>";
                    else reviewTr += "<option value=\"1\">合格</option>";
                    if (form_value3.Self_value == 2) reviewTr += "<option value=\"2\" selected=\"selected\">不合格</option>";
                    else reviewTr += "<option value=\"2\">不合格</option>";
                }
                reviewTr += "</select>";
                reviewTr += "</td>";
                reviewTr += "</tr>";
            }
        }
        #endregion

        protected void AddSubmitButton()
        {
            var review_model = new BLL.CCOM.Form_review().GetModel(" User_id=" + studentID + " and Form_type_id=1");
            if (GetAdminInfo_CCOM().Role_id == 3)//学生
            {
                if (review_model == null) //学生尚未提交
                {
                    isCanEdit = true;
                    this.submit_button.InnerHtml = "<a href=\"javascript:void(0);\" class=\"btn btn-success\" onclick='SubmitForm(1)'>提交";
                }
                else//学生已经提交
                {
                    if (review_model.Review_result == 0)
                    {
                        isCanEdit = true;
                        this.submit_button.InnerHtml = "<a href=\"javascript:void(0);\" class=\"btn btn-success\" onclick='SubmitForm(1)'>提交";
                    }
                    else
                    {
                        isCanEdit = false;
                        this.submit_button.InnerHtml = review_model.Review_result == 1 ? "<b style=\"color: green;\">审核结果：及格</b>" : "<b style=\"color: red;\">审核结果：不及格</b>";
                    }
                }
            }
            else if (GetAdminInfo_CCOM().Role_id == 2)//指导教师
            {
                if (review_model == null) //学生尚未提交
                {
                    isCanEdit = true;
                    this.submit_button.InnerText = "该学生尚未提交形式审查表";
                }
                else//学生已经提交
                {
                    if (review_model.Review_result == 0)
                    {
                        isCanEdit = true;
                        this.submit_button.InnerHtml = "<a href=\"javascript:void(0);\" class=\"btn btn-success\" onclick='SubmitForm(2)'>审核";
                    }
                    else
                    {
                        isCanEdit = false;
                        this.submit_button.InnerHtml = review_model.Review_result == 1 ? "<b style=\"color: green;\">审核结果：及格</b>" : "<b style=\"color: red;\">审核结果：不及格</b>";
                    }
                }
            }
            else
            {
                if (review_model == null) //学生尚未提交
                {
                    isCanEdit = false;
                    this.submit_button.InnerText = "该学生尚未提交形式审查表";
                }
                else//学生已经提交
                {
                    if (review_model.Review_result == 0)
                    {
                        isCanEdit = false;
                        this.submit_button.InnerHtml = "<a href=\"javascript:void(0);\">尚未审核";
                    }
                    else
                    {
                        isCanEdit = false;
                        this.submit_button.InnerHtml = review_model.Review_result == 1 ? "<b style=\"color: green;\">审核结果：及格</b>" : "<b style=\"color: red;\">审核结果：不及格</b>";
                    }
                }
            }

        }

        protected string GetIsDisabled() 
        {
            if (isCanEdit) return "";
            else return "disabled=\"disabled\"";
        }
    }
}