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
    public partial class StudentApply2 : university.UI.ManagePage
    {
        protected long id = 0;
        protected bool iseditmine = true;

        public StudentApply2()
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
                Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(GetAdminInfo_CCOM().User_id);
                this.id = user_model.User_id;
                //if (user_model.User_type == 6) 
                //{
                //    JscriptMsg("只有考生用户可以报考！", "back", "Error");
                //    return;
                //}
                Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + id);
            }
            catch
            {
                Response.Redirect("/adminmetro/center.aspx");
            }
            if (!Page.IsPostBack)
            {
                bllBasicInfo(id);
            }
        }
        
        //基本信息绑定
        public void bllBasicInfo(long SchoolUserID)
        {
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + id);

            //string IDType = user_model.User_ID_number_type.ToString();
            //string IDNumber = user_model.User_ID_number;
            string IDPicture = userEx_model.UP_ID_picture;
            string Picture = userEx_model.UP_picture;
            string AEENumber = userEx_model.UP_AEE_number;
            string AEEPicture = userEx_model.UP_AEE_picture;
            //展示信息
            //if (IDType != "")  this.lblIDType.Text = new BLL.CCOM.Certificate_type().GetModel(int.Parse(IDType)).Ct_name;
            //this.lblIDNumber.Text = IDNumber;
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
            //if (IDType != null && IDType != "" && int.Parse(IDType) > 0)
            //{
            //    this.ddlIDType.SelectedValue = IDType;
            //}
            //else 
            //{
            //    this.ddlIDType.Items.Insert(0, new ListItem("请选择", "0"));
            //}
            //this.txtIDNumber.Text = IDNumber;
            this.txtIDPicture.Text = IDPicture;
            this.txtPicture.Text = Picture;
            this.txtAEENumber.Text = AEENumber;
            this.txtAEEPicture.Text = AEEPicture;
        }

        protected void OnClickNextStep(object sender, EventArgs e)
        {
            //添加验证信息是否齐全
            Model.CCOM.User_infomation user_model = new BLL.CCOM.User_infomation().GetModel(GetAdminInfo_CCOM().User_id);
            Model.CCOM.User_property userEx_model = new BLL.CCOM.User_property().GetModel(" User_id=" + user_model.User_id);
            //if (user_model.User_ID_number_type == null || user_model.User_ID_number_type < 1)
            //{
            //    JscriptMsg("请填加证件类型！", "", "Error");
            //    return;
            //}
            //if (user_model.User_ID_number == null || user_model.User_ID_number == "")
            //{
            //    JscriptMsg("请填写证件号码！", "", "Error");
            //    return;
            //}
            if (userEx_model == null)
            {
                JscriptMsg("请完善用户信息！", "", "Error");
                return;
            }
            if (userEx_model.UP_ID_picture == null || userEx_model.UP_ID_picture == "")
            {
                JscriptMsg("请上传证件照片！", "", "Error");
                return;
            }
            if (userEx_model.UP_picture == null || userEx_model.UP_picture == "")
            {
                JscriptMsg("请上传近期免冠照片！", "", "Error");
                return;
            }
            if (userEx_model.UP_AEE_number == null || userEx_model.UP_AEE_number == "")
            {
                JscriptMsg("请填写省艺术联考考生号！", "", "Error");
                return;
            }
            if (userEx_model.UP_AEE_picture == null || userEx_model.UP_AEE_picture == "")
            {
                JscriptMsg("请上传省艺术联考合格证！", "", "Error");
                return;
            }
            
            //跳转到第三步
            JscriptMsg("证件上传成功！", Utils.CombUrlTxt("StudentApply3.aspx", "fun_id={0}", DESEncrypt.Encrypt(this.fun_id)), "Success");
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