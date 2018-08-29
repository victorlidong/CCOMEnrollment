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

namespace university.Web.AdminMetro.CCOM.StudentManage
{
    public partial class StudentEdit : university.UI.ManagePage
    {
        protected long id = 0;
        protected bool iseditmine = true;

        public StudentEdit()
        {
            //this.checkFunID = false;

            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取SchoolUserID
            try
            {
                string getID = DESEncrypt.Decrypt(MyRequest.GetQueryString("id"));
                if (getID == "")
                {
                    Page.Title = "基本信息";
                    this.id = GetAdminInfo_CCOM().User_id;
                }
                else {
                    Page.Title = "管理考生";
                    this.id = long.Parse(DESEncrypt.Decrypt(MyRequest.GetQueryString("id")));
                } 
            }
            catch
            {
                Response.Redirect("/adminmetro/CCOM/center.aspx");
            }
            if (!Page.IsPostBack)
            {
                bllBasicFace(id);
                bllBasicInfo(id);
                bllPictureInfo(id);
                bllNatureInfo(id);
                bllStuInfo(id);
                MemberBing(id);
                CheckInfo();
            }
        }

        protected void CheckInfo() {
            string self_info = "缺少：";
            string contect_info = "缺少：";
            string home_info = "缺少：";
            string id_info = "缺少：";
            string pic_info = "缺少：";
            string exam_info = "缺少：";
            //添加验证信息是否齐全
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(GetAdminInfo_CCOM().User_id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + user_model.User_id);
            if (new BLL.CCOM.Family_member().GetRecordCount(" User_id = '" + user_model.User_id + "' ") < 1)
            {
                home_info += "家庭成员信息";
            }
            if (user_model.User_realname == null || user_model.User_realname == "")
            {
                self_info += "姓名 ";
            }
            if (user_model.User_birthday == null || user_model.User_realname == "")
            {
                self_info += "出生日期 ";
            }
            if (userEx_model.UP_nationality == null || userEx_model.UP_nationality < 1)
            {
                self_info += "民族 ";
            }
            if (userEx_model.UP_province == null || userEx_model.UP_province < 1)
            {
                self_info += "高考所在地 ";
            }
            
            if (userEx_model.UP_degree == null || userEx_model.UP_degree < 1)
            {
                self_info += "文化程度 ";
            }
            if (userEx_model.UP_politics == null || userEx_model.UP_politics < 1)
            {
                self_info += "政治面貌 ";
            }
            if (userEx_model.UP_high_school == null || userEx_model.UP_high_school == "")
            {
                self_info += "高中毕业院校 ";
            }
            if (userEx_model.UP_CEE_number == null || userEx_model.UP_CEE_number == "")
            {
                self_info += "高考报名号 ";
            }
            if (userEx_model.Agency_id == null || userEx_model.Agency_id < 1)
            {
                self_info += "专业方向 ";
            }
            if (userEx_model.UP_nation == null || userEx_model.UP_nation < 1)
            {
                self_info += "国籍 ";
            }
            if (userEx_model.UP_overseas == null)
            {
                self_info += "是否华侨 ";
            }
            if (userEx_model.UP_PE_Aphone == null || userEx_model.UP_PE_Aphone == "")
            {
                contect_info += "常规移动电话 ";
            }
            if (userEx_model.UP_PE_Iphone == null || userEx_model.UP_PE_Iphone == "")
            {
                contect_info += "艺考期间移动电话 ";
            }
            if (userEx_model.UP_postal_code == null || userEx_model.UP_postal_code == "")
            {
                contect_info += "邮编 ";
            }
            if (userEx_model.UP_address == null || userEx_model.UP_address == "")
            {
                contect_info += "录取通知书邮寄地址 ";
            }
            if (userEx_model.UP_receiver == null || userEx_model.UP_receiver == "")
            {
                contect_info += "收件人 ";
            }
            if (userEx_model.UP_receiver_phone == null || userEx_model.UP_receiver_phone == "")
            {
                contect_info += "收件人电话 ";
            }
            if (user_model.User_ID_number_type == null || user_model.User_ID_number_type < 1)
            {
                id_info += "证件类型 ";
            }
            if (user_model.User_ID_number == null || user_model.User_ID_number == "")
            {
                id_info += "证件号码 ";
            }
            if (userEx_model.UP_ID_picture == null || userEx_model.UP_ID_picture == "")
            {
                id_info += "证件照片 ";
            }
            if (userEx_model.UP_picture == null || userEx_model.UP_picture == "")
            {
                pic_info += "免冠照片 ";
            }
            if (userEx_model.UP_AEE_number == null || userEx_model.UP_AEE_number == "")
            {
                exam_info += "省艺术联考考生号 ";
            }
            if (userEx_model.UP_AEE_picture == null || userEx_model.UP_AEE_picture == "")
            {
                exam_info += "省艺术联考合格证 ";
            }
            if (self_info != "缺少：") this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: red; font-size: 13px;\" ID=\"lblTip\">个人信息" + self_info + "</asp:Label><br/>");
            if (contect_info != "缺少：") this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: red; font-size: 13px;\" ID=\"lblTip\">联系方式" + contect_info + "</asp:Label><br/>");
            if (home_info != "缺少：") this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: red; font-size: 13px;\" ID=\"lblTip\">家庭信息" + home_info + "</asp:Label><br/>");
            if (id_info != "缺少：") this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: red; font-size: 13px;\" ID=\"lblTip\">证件信息" + id_info + "</asp:Label><br/>");
            if (pic_info != "缺少：") this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: red; font-size: 13px;\" ID=\"lblTip\">免冠照片" + pic_info + "</asp:Label><br/>");
            if (exam_info != "缺少：") this.deps.InnerHtml = this.deps.InnerHtml + ("<asp:Label runat=\"server\" Style=\"color: red; font-size: 13px;\" ID=\"lblTip\">省艺术联考" + exam_info + "</asp:Label><br/>");
        }

        //绑定证件信息
        public void bllPictureInfo(long SchoolUserID)
        {
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + id);
            string IDPicture = string.Empty, Picture = string.Empty, AEENumber = string.Empty, AEEPicture = string.Empty;
            string IDType = user_model.User_ID_number_type.ToString();
            string IDNumber = user_model.User_ID_number;
            if (userEx_model != null)
            {
                IDPicture = userEx_model.UP_ID_picture;
                Picture = userEx_model.UP_picture;
                AEENumber = userEx_model.UP_AEE_number;
                AEEPicture = userEx_model.UP_AEE_picture;
            }
            
            //展示信息
            try
            {
                this.lblIDType.Text = new BLL.CCOM.Certificate_type().GetModel(int.Parse(IDType)).Ct_name;
            }
            catch {
                this.lblIDType.Text = "未设置";
            }
            
            this.lblIDNumber.Text = IDNumber;
            if (IDPicture != "")
            {
                if (!IDPicture.StartsWith("http"))
                    this.lblIDPicture.Src = DataDic.FILE_URL + IDPicture;
                else this.lblIDPicture.Src = IDPicture;
            }
            else
                this.lblIDPicture.Src = "/admin/images/default_user_avatar.gif";
            if (Picture != "")
            {
                if (!Picture.StartsWith("http"))
                    this.lblPicture.Src = DataDic.FILE_URL + Picture;
                else this.lblPicture.Src = Picture;
            }
            else
                this.lblPicture.Src = "/admin/images/default_user_avatar.gif";
            this.lblAEENumber.Text = AEENumber;
            if (AEEPicture != "")
            {
                if (!AEEPicture.StartsWith("http"))
                    this.lblAEEPicture.Src = DataDic.FILE_URL + AEEPicture;
                else this.lblAEEPicture.Src = AEEPicture;
            }
            else
                this.lblAEEPicture.Src = "/admin/images/default_user_avatar.gif";
            //编辑信息
            new BLL.CCOM.Certificate_type().BindDDL(this.ddlIDType);
            if (IDType != null && IDType != "" && int.Parse(IDType) > 0)
            {
                this.ddlIDType.SelectedValue = IDType;
            }
            else
            {
                this.ddlIDType.Items.Insert(0, new ListItem("请选择", "0"));
            }
            this.txtIDNumber.Text = IDNumber;
            this.txtIDPicture.Text = IDPicture;
            this.txtPicture.Text = Picture;
            this.txtAEENumber.Text = AEENumber;
            this.txtAEEPicture.Text = AEEPicture;
        }

        //证件照
        public void bllBasicFace(long SchoolUserID)
        {
            string photoUrl = "";
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + id);
            try
            {
                photoUrl = userEx_model.UP_picture;
            }
            catch (Exception)
            {
                photoUrl = "";
            }
            if (photoUrl == null || photoUrl == "")
                photoUrl = DataDic.FILE_URL+"images/login/logo_left1.png";
            else if (!photoUrl.StartsWith("http"))
                photoUrl = DataDic.FILE_URL + photoUrl;
            this.lblFace.Text = "<img style='height:100px;' src=\"" + photoUrl + "\" alt=\"近期免冠照\" title=\"近期免冠照\" />";
        }
        
        //基本信息绑定
        public void bllBasicInfo(long SchoolUserID)
        {
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + id);
            BLL.CCOM.Agency agencyBll = new BLL.CCOM.Agency();

            this.lblUI_LoginName.Text = user_model.User_realname.Trim();
            this.txtRealName.Text = user_model.User_realname.Trim();
            string basicIntroInfo = string.Empty;
            basicIntroInfo += user_model.User_realname.Trim() + "<span>　|　</span>";
            if (user_model.User_gender == true){
                this.ddlSex.SelectedValue = "1";
                basicIntroInfo += "女";
            }
            else if (user_model.User_gender == false) { 
                this.ddlSex.SelectedValue = "0";
                basicIntroInfo += "男";
            }
            basicIntroInfo += "<span>　|　</span>";
                
            try
            {
                this.txtBirthday.Text = ((DateTime)user_model.User_birthday).ToString("yyyy-MM-dd");
                basicIntroInfo += this.txtBirthday.Text;
            }
            catch (Exception){
                basicIntroInfo += "生日";
            }
            basicIntroInfo += "<span>　|　</span>";
            try
            {
                basicIntroInfo += new BLL.CCOM.Agency().GetModel(userEx_model.Agency_id).Agency_name.Trim();
            }
            catch { 
                basicIntroInfo += "专业";
            }

            this.lblIntroInfo.Text = basicIntroInfo;
            
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
                if (userEx_model.Agency_id != null && userEx_model.Agency_id > 0) {
                    this.lblDirection.Text = new BLL.CCOM.Agency().GetModel(userEx_model.Agency_id).Agency_name.Trim();
                }
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
            var lbtn = sender as LinkButton;
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
                    JscriptMsg("删除成功！", Utils.CombUrlTxt("StudentEdit.aspx", "fun_id={0}",
                        DESEncrypt.Encrypt(this.fun_id)), "Success");
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("StudentEdit.aspx", "fun_id={0}",
                        DESEncrypt.Encrypt(this.fun_id)), "Error");
            }
        }

        #endregion

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