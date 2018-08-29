using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using university.Common;
using System.Configuration;
using System.Data;

namespace university.Web.AdminMetro.CCOM.StudentApply
{
    public partial class StudentApply1 : university.UI.ManagePage
    {
        protected long id = 0;
        protected bool iseditmine = true;

        public StudentApply1()
        {
            //this.checkFunID = false;

            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取SchoolUserID
            try
            {
                Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(GetAdminInfo_CCOM().User_id);
                Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id='" + GetAdminInfo_CCOM().User_id + "'");
                this.id = user_model.User_id;
                //if (user_model.User_type == 6)
                //{
                //    JscriptMsg("只有考生用户可以报考！", "back", "Error");
                //    return;
                //}
                Model.CCOM.Period period_model = new BLL.CCOM.Period().GetModel(" Period_state=1");
                if (period_model == null) {
                    JscriptMsg("目前尚未开启报名！", "back", "Error");
                    return;
                }
                else if (userEx_model.Period_id != period_model.Period_id)
                {
                    JscriptMsg("您所处周期不在当前报名周期内！", "back", "Error");
                    return;
                }
                else if (period_model.Period_register_start > DateTime.Now)
                {
                    JscriptMsg("尚未开启报考！", "back", "Error");
                    return;
                }
            }
            catch
            {
                Response.Redirect("/adminmetro/center.aspx");
            }
            if (!Page.IsPostBack)
            {
                bllBasicInfo(id);
                bllNatureInfo(id);
                bllStuInfo(id);
                MemberBing(id);
                checkIsPay();
                setAgencyDetail();
            }
        }
        
        //基本信息绑定
        public void bllBasicInfo(long SchoolUserID)
        {
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + id);
            BLL.CCOM.Agency agencyBll = new BLL.CCOM.Agency();

            this.txtRealName.Text = user_model.User_realname.Trim();
            if (user_model.User_gender == true){
                this.ddlSex.SelectedValue = "1";
            }
            else if (user_model.User_gender == false) { 
                this.ddlSex.SelectedValue = "0";
            }
                
            try
            {
                this.txtBirthday.Text = ((DateTime)user_model.User_birthday).ToString("yyyy-MM-dd");
            }
            catch (Exception){
            }
            
            //专业方向
            this.ddlDepartment.DataSource = new BLL.CCOM.Agency().GetList(" Agency_type=2");
            this.ddlDepartment.DataTextField = "Agency_name";
            this.ddlDepartment.DataValueField = "Agency_id";
            this.ddlDepartment.DataBind();
            this.ddlDepartment.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlMajor.Items.Insert(0, new ListItem("请选择", "0"));
            int depID = 0;
            try
            {
                depID = agencyBll.GetModel(" Agency_id=" + agencyBll.GetModel(" Agency_id=" + userEx_model.Agency_id).Agency_father).Agency_id;
                this.ddlDepartment.SelectedValue = depID.ToString();

                this.ddlMajor.DataSource = agencyBll.GetList(" Agency_father=" + agencyBll.GetModel(" Agency_id=" + userEx_model.Agency_id).Agency_father);
                this.ddlMajor.DataTextField = "Agency_name";
                this.ddlMajor.DataValueField = "Agency_id";
                this.ddlMajor.DataBind();
                this.ddlMajor.SelectedValue = userEx_model.Agency_id.ToString();
            }
            catch { }
            new BLL.CCOM.Nationality().BindDDL(this.ddlNationality);
            new BLL.CCOM.Politics().BindDDL(this.ddlPolitical);
            new BLL.CCOM.Province().BindDDL(this.ddlOrigin);
            new BLL.CCOM.Nation().BindDDL(this.ddlNation);
            new BLL.CCOM.Degree().BindDDL(this.ddlDegree);
            this.ddlNationality.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlPolitical.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlOrigin.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlNation.Items.Insert(0, new ListItem("请选择", "0"));
            this.ddlDegree.Items.Insert(0, new ListItem("请选择", "0"));
            if (userEx_model != null)
            {
                if (userEx_model.Agency_id != null && userEx_model.Agency_id > 0)
                    this.ddlMajor.Text = agencyBll.GetModel(userEx_model.Agency_id).Agency_name;
                //民族
                this.ddlNationality.SelectedValue = userEx_model.UP_nationality.ToString();
                //国籍
                this.ddlNation.SelectedValue = userEx_model.UP_nation.ToString();
                //是否华侨
                this.ddlOverSeas.SelectedValue = userEx_model.UP_overseas ? "1" : "0";
                //文化程度
                this.ddlDegree.SelectedValue = userEx_model.UP_degree.ToString();
                //政治面貌
                this.ddlPolitical.SelectedValue = userEx_model.UP_politics.ToString();
                //高中毕业院校
                this.txtSeniorSchool.Text = userEx_model.UP_high_school;
                //高考报名号
                this.txtExaminationID.Text = userEx_model.UP_CEE_number;
                //生源地
                this.ddlOrigin.SelectedValue = userEx_model.UP_province.ToString();
                //考生联系电话
                this.txtPhoneNumber.Text = userEx_model.UP_PE_Aphone;
                //艺考期间电话
                this.txtykPhoneNumber.Text = userEx_model.UP_PE_Iphone;
                //录取通知书邮寄地址
                this.txtAddress.Text = userEx_model.UP_address;
                //邮编
                this.txtZipCode.Text = userEx_model.UP_postal_code;
                //收件人
                this.txtAddressee.Text = userEx_model.UP_receiver;
                //收件人电话
                this.txtAddresseeNumber.Text = userEx_model.UP_receiver_phone;
            }
        }

        //自然属性基础信息
        public void bllNatureInfo(long SchoolUserID)
        {
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + id);
            this.lblRealName.Text = user_model.User_realname.Trim();
            if (user_model.User_gender == true)
                this.lblSex.Text = "女";
            else if (user_model.User_gender == false)
                this.lblSex.Text = "男";
            this.lblBirthday.Text = Convert.ToDateTime(user_model.User_birthday).ToString("yyyy-MM-dd");
            if (userEx_model != null)
            {
                if (userEx_model.Agency_id != null && userEx_model.Agency_id > 0)
                    this.lblDirection.Text = new BLL.CCOM.Agency().GetModel(userEx_model.Agency_id).Agency_name.Trim();
                if (userEx_model.UP_nationality != null && userEx_model.UP_nationality > 0)
                    this.lblNationality.Text = new BLL.CCOM.Nationality().GetModel((int)userEx_model.UP_nationality).Nationality_name.Trim();
                if (userEx_model.UP_nation != null && userEx_model.UP_nation > 0)
                    this.lblNation.Text = new BLL.CCOM.Nation().GetModel((int)userEx_model.UP_nation).Nation_name.Trim();
                this.lblOverSeas.Text = userEx_model.UP_overseas ? "是" : "否";
                if (userEx_model.UP_degree != null && userEx_model.UP_degree > 0)
                    this.lblDegree.Text = new BLL.CCOM.Degree().GetModel((int)userEx_model.UP_degree).Degree_name.Trim();
                if (userEx_model.UP_politics != null && userEx_model.UP_politics > 0)
                    this.lblPolitical.Text = new BLL.CCOM.Politics().GetModel((int)userEx_model.UP_politics).Politics_name.Trim();
                this.lblSeniorSchool.Text = userEx_model.UP_high_school.Trim();
                this.lblExaminationID.Text = userEx_model.UP_CEE_number.Trim();
            }
            
        }

        //学生联系方式
        public void bllStuInfo(long SchoolUserID)
        {
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + id);
            if (userEx_model != null)
            {
                if (userEx_model.UP_province != null && userEx_model.UP_province > 0)
                    this.lblOrigin.Text = new BLL.CCOM.Province().GetModel((int) userEx_model.UP_province).Province_name.Trim();
                this.lblAddress.Text = userEx_model.UP_address.Trim();
                this.lblPhoneNumber.Text = userEx_model.UP_PE_Aphone.Trim();
                this.lblykPhoneNumber.Text = userEx_model.UP_PE_Iphone.Trim();
                this.lblZipCode.Text = userEx_model.UP_postal_code.Trim();
                this.lblAddressee.Text = userEx_model.UP_receiver.Trim();
                this.lblAddresseeNumber.Text = userEx_model.UP_receiver_phone.Trim();
            }
        }

        #region 家庭成员相关=================================
        //绑定信息
        public void MemberBing(long userID) {
            int start_index = 1;
            BLL.CCOM.Family_member bll = new BLL.CCOM.Family_member();
            string _strWhere = " User_id = '" + userID + "' ";
            string _order = " Fm_id desc ";

            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, totalCount);
            this.rptList.DataBind();

            new BLL.CCOM.Politics().BindDDL(this.ddlMPolitics);
            this.ddlMPolitics.Items.Insert(0, new ListItem("请选择", "0"));
        }

        //获取家庭成员姓名
        public string GetMName(int id) {
            return new BLL.CCOM.Family_member().GetModel(" Fm_id=" + id).Fm_name;
        }

        //获取家庭成员关系
        public string GetRelation(int id) {
            return new BLL.CCOM.Family_member().GetModel(" Fm_id=" + id).Fm_relationship;
        }

        //获取家庭成员工作单位
        public string GetCompany(int id) {
            return new BLL.CCOM.Family_member().GetModel(" Fm_id=" + id).Fm_company;
        }

        //获取家庭成员联系方式
        public string GetPhoneNumber(int id) {
            return new BLL.CCOM.Family_member().GetModel(" Fm_id=" + id).Fm_phone;
        }

        //获取家庭成员政治面貌
        public string GetPolitics(int id) {
            try
            {
                return new BLL.CCOM.Politics().GetModel(" Politics_id=" + new BLL.CCOM.Family_member().GetModel(" Fm_id=" + id).Fm_politics).Politics_name;
            }
            catch {
                return "";
            }
        }

        //删除
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.Family_member bll = new BLL.CCOM.Family_member();
            var lbtn = sender as Button;
            if (lbtn != null)
            {
                var id = Int32.Parse(DESEncrypt.Decrypt(lbtn.ToolTip.ToString()));
                bool result = true;
                try
                {
                    result = bll.Delete(id);
                }
                catch
                {
                    result = false;
                }
                if (result == true)
                {
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("StudentApply1.aspx", "fun_id={0}",
                        DESEncrypt.Encrypt(this.fun_id)), "Success");
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("StudentApply1.aspx", "fun_id={0}",
                        DESEncrypt.Encrypt(this.fun_id)), "Error");
            }
        }

        #endregion

        protected void checkIsPay() {
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id='" + GetAdminInfo_CCOM().User_id + "'");
            Model.CCOM.Period period_model = new BLL.CCOM.Period().GetModel(" Period_state=1");
            if (userEx_model.UP_calculation_status == 0)
            {
                this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: red; font-size: 13px;\" ID=\"lblTip\">报名状态：未报名</asp:Label><br/>");
            }
            else if (userEx_model.UP_calculation_status == 1)
            {
                this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: green; font-size: 13px;\" ID=\"lblTip\">缴费状态：已缴费成功</asp:Label><br/>");
            }
            else {
                this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: green; font-size: 13px;\" ID=\"lblTip\">缴费状态：已缴费成功</asp:Label><br/>");
            }

            this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: red; font-size: 13px;\" ID=\"lblTip\">报考时间结束后不可更改信息，报名结束时间：" +　period_model.Period_register_end + "</asp:Label><br/>");
            if (period_model.Period_register_end < DateTime.Now) {
                this.deps.InnerHtml = ("<asp:Label runat=\"server\" Style=\"color: red; font-size: 13px;\" ID=\"lblTip\">报名已结束</asp:Label><br/>");
            }
        }

        protected void setAgencyDetail() {
            Model.CCOM.User_property model = new BLL.CCOM.User_property().GetModel(" User_id='" + GetAdminInfo_CCOM().User_id + "'");
            Model.CCOM.Major major_model = new BLL.CCOM.Major().GetModel(" Agency_id='" + model.Agency_id + "'");
            if (major_model == null)
            {
                this.Details.InnerHtml = ("<asp:Label runat=\"server\" Style=\"color: green; font-size: 13px;\" ID=\"lblTip\">无</asp:Label><br/>");
            }
            else {
                this.Details.InnerHtml = this.Details.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: green; font-size: 13px;\" ID=\"lblTip\">学制：" + major_model.Major_academic + "</asp:Label><br/>");
                this.Details.InnerHtml = this.Details.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: green; font-size: 13px;\" ID=\"lblTip\">专业要求：" + major_model.Major_require + "</asp:Label><br/>");
                this.Details.InnerHtml = this.Details.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: green; font-size: 13px;\" ID=\"lblTip\">专业参考书目：" + major_model.Major_reference + "</asp:Label><br/>");
                this.Details.InnerHtml = this.Details.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: green; font-size: 13px;\" ID=\"lblTip\">备注：" + major_model.Major_remark + "</asp:Label><br/>");
            }
        }

        protected void OnClickNextStep(object sender, EventArgs e)
        { 
            //添加验证信息是否齐全
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(GetAdminInfo_CCOM().User_id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + user_model.User_id);
            if (new BLL.CCOM.Family_member().GetRecordCount(" User_id = '" + user_model.User_id + "' ") < 1) 
            {
                JscriptMsg("请添加家庭成员信息！", "", "Error");
                return;
            }
            if (user_model.User_realname == null || user_model.User_realname == "") 
            {
                JscriptMsg("请填写姓名！", "", "Error");
                return;
            }
            if (user_model.User_birthday == null || user_model.User_realname == "")
            {
                JscriptMsg("请填写出生日期！", "", "Error");
                return;
            }
            if (userEx_model == null) 
            {
                JscriptMsg("请完善用户信息！", "", "Error");
                return;
            }
            if (userEx_model.UP_nationality == null || userEx_model.UP_nationality < 1)
            {
                JscriptMsg("请填写民族！", "", "Error");
                return;
            }
            if (userEx_model.UP_nation == null || userEx_model.UP_nation < 1)
            {
                JscriptMsg("请填写国籍！", "", "Error");
                return;
            }
            if (userEx_model.UP_degree == null || userEx_model.UP_degree < 1)
            {
                JscriptMsg("请填写文化程度！", "", "Error");
                return;
            }
            if (userEx_model.UP_politics == null || userEx_model.UP_politics < 1)
            {
                JscriptMsg("请填写政治面貌！", "", "Error");
                return;
            }
            if (userEx_model.UP_high_school == null || userEx_model.UP_high_school == "")
            {
                JscriptMsg("请填写高中毕业院校！", "", "Error");
                return;
            }
            if (userEx_model.UP_CEE_number == null || userEx_model.UP_CEE_number == "")
            {
                JscriptMsg("请填写高考报名号！", "", "Error");
                return;
            }
            if (userEx_model.Agency_id == null || userEx_model.Agency_id < 1)
            {
                JscriptMsg("请添加报考专业！", "", "Error");
                return;
            }
            if (userEx_model.UP_province == null || userEx_model.UP_province < 1)
            {
                JscriptMsg("请填加高考所在地！", "", "Error");
                return;
            }
            if (userEx_model.UP_PE_Aphone == null || userEx_model.UP_PE_Aphone == "")
            {
                JscriptMsg("请填写常规移动电话！", "", "Error");
                return;
            }
            if (userEx_model.UP_address == null || userEx_model.UP_address == "")
            {
                JscriptMsg("请填写录取通知书邮寄地址！", "", "Error");
                return;
            }
            if (userEx_model.UP_PE_Iphone == null || userEx_model.UP_PE_Iphone == "")
            {
                JscriptMsg("请填写艺考期间移动电话！", "", "Error");
                return;
            }
            if (userEx_model.UP_postal_code == null || userEx_model.UP_postal_code == "")
            {
                JscriptMsg("请填写邮编！", "", "Error");
                return;
            }
            if (userEx_model.UP_receiver == null || userEx_model.UP_receiver == "")
            {
                JscriptMsg("请填写收件人！", "", "Error");
                return;
            }
            if (userEx_model.UP_receiver_phone == null || userEx_model.UP_receiver_phone == "")
            {
                JscriptMsg("请填写收件人电话！", "", "Error");
                return;
            }
            //跳转到第二步
            JscriptMsg("保存成功！", Utils.CombUrlTxt("StudentApply2.aspx", "fun_id={0}", DESEncrypt.Encrypt(this.fun_id)), "Success");
        }

        //随机生成颜色
        public string getRandomColor(string name)
        {
            string color = "purple";
            int n = new Random().Next(1, 6);
            switch (n)
            {
                case 1:
                    color = "purple";
                    break;
                case 2:
                    color = "blue";
                    break;
                case 3:
                    color = "orange";
                    break;
                case 4:
                    color = "red";
                    break;
                case 5:
                    color = "yellow";
                    break;
                default:
                    break;
            }
            return color;
        }
    }
}