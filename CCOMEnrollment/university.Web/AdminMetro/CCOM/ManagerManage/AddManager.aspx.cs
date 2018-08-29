using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.ManagerManage
{
    public partial class AddManager : university.UI.ManagePage
    {
        public string action; //操作类型
        private int userId;//修改参数
        public AddManager()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            action = MyEnums.ActionEnum.Add.ToString();
            userId = 0;
            action = MyRequest.GetQueryString("action");
            userId = MyRequest.GetQueryInt("userId");
            if (!Page.IsPostBack)
            {
               // BindId_Type();
                BindAgency();
             //   BindRole();
                if (action == MyEnums.ActionEnum.Edit.ToString())
                {
                    if (userId == 0)
                    {
                        JscriptMsg("传输参数不正确！", "back", "Error");
                        return;
                    }
                    ShowInfo(userId);
                    this.btnSubmit.Text = "确认保存";
                }
                else
                {
                    this.btnSubmit.Text = "确认添加";
                }
            } 
        }

        //public void BindId_Type()
        //{
        //    BLL.CCOM.Certificate_type bll = new BLL.CCOM.Certificate_type();
        //    DataSet ds = bll.GetAllList();
        //    this.ddlIdType.DataSource = ds.Tables[0].DefaultView;
        //    this.ddlIdType.DataTextField = "Ct_name";
        //    this.ddlIdType.DataValueField = "Ct_id";
        //    this.ddlIdType.DataBind();
        //    ListItem item = new ListItem("--请选择证件类型--", "#");
        //    this.ddlIdType.Items.Insert(0, item);
        //}

        public void BindAgency()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Agency_name", typeof(string)));
            dt.Columns.Add(new DataColumn("Agency_id", typeof(string))); //加密后的id
            BindChildAgency(dt, null, 0);
            ds.Tables.Add(dt);

            this.ddlAgency.DataSource = ds;
            this.ddlAgency.DataTextField = "Agency_name";
            this.ddlAgency.DataValueField = "Agency_id";
            this.ddlAgency.DataBind();
        }

        public void BindChildAgency(DataTable dt, Model.CCOM.Agency model, int level)
        {
            string tag = "";
            DataRow dr = dt.NewRow();
            if (model == null)
            {
                dr["Agency_name"] = "--请选择机构--";
                dr["Agency_id"] = "#";
            }
            else
            {
                for (int i = 0; i < level; i++)
                    tag += "　";
                tag += "┠";
                dr["Agency_name"] = tag + model.Agency_name;
                dr["Agency_id"] = model.Agency_id;
            }
            dt.Rows.Add(dr);
            BLL.CCOM.Agency bll = new BLL.CCOM.Agency();
            List<Model.CCOM.Agency> listAgency = bll.GetModelList(" Agency_father=" + (model == null ? 0 : model.Agency_id));
            foreach (Model.CCOM.Agency agencyModel in listAgency)
            {
                BindChildAgency(dt, agencyModel, level + 1);
            }
        }

        //public void BindRole()
        //{
        //    string sql = "Role_status = 1";
        //    BLL.CCOM.Role bll = new BLL.CCOM.Role();
        //    DataSet ds = bll.GetList(sql);
        //    this.ddlRole.DataSource = ds.Tables[0].DefaultView;
        //    this.ddlRole.DataTextField = "Role_name";
        //    this.ddlRole.DataValueField = "Role_id";
        //    this.ddlRole.DataBind();
        //    ListItem item = new ListItem("--请选择角色--", "#");
        //    this.ddlRole.Items.Insert(0, item);
        //}
        
        #region 赋值操作=================================
        private void ShowInfo(long UserId)
        {
            var bll = new BLL.CCOM.User_information();
            var model = bll.GetModel("User_id=" + UserId);

            this.rblSex.SelectedIndex = (model.User_gender == true) ? 1 : 0;
            this.txtMobile.Text = model.User_number;
            this.txtRealname.Text = model.User_realname;
            //if (model.User_ID_number_type != null)
            //    this.ddlIdType.SelectedIndex = model.User_ID_number_type.Value;
            //this.txtIdNumber.Text = model.User_ID_number;
            if (model.User_birthday != null)
                this.txtBirthday.Value = ((DateTime)model.User_birthday).ToString("yyyy-MM-dd");
            this.ddlAgency.SelectedValue = model.Agency_id.ToString();
            this.ddlRole.SelectedValue = model.Role_id.ToString();
        }
        #endregion

        #region 增加/编辑操作=================================
        private string DoAction()
        {
            string result = "";
            BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information model;
            if (action != MyEnums.ActionEnum.Edit.ToString())
                model = new Model.CCOM.User_information();
            else
                model = bll.GetModel("User_id=" + userId);
            string Sex = this.rblSex.SelectedValue;
            string Mobile = this.txtMobile.Text.Trim();
            string Pass1 = this.txtPass1.Text.Trim();
            string Pass2 = this.txtPass2.Text.Trim();
           // string IdNumberType = this.ddlIdType.SelectedItem.Value;
            //string IdNumber = this.txtIdNumber.Text.Trim();
            string Realname = this.txtRealname.Text.Trim();
            string Agency = this.ddlAgency.SelectedItem.Value;
          //  string Role = this.ddlRole.SelectedItem.Value;
            //必填部分
            if (Tools.CheckParams(Mobile + Realname  + Pass1 + Pass2))
            {
                return "请勿输入非法字符";
            }

            if (Realname == "")
                return "请填写真实姓名";
            model.User_realname = Realname;

            if (Mobile == "")
                return "请填写学号/工号";
            if (!Validator.IsMobile(Mobile))
                return "学号/工号不合法";
            if (action != MyEnums.ActionEnum.Edit.ToString() && bll.GetRecordCount(" User_number='" + Mobile + "'") > 0)
            {
                return "该学号/工号已被添加";
            }
            model.User_number = Mobile;
            if (action != MyEnums.ActionEnum.Edit.ToString())
            {
                if (Pass1 == "")
                {
                    return "请填写密码";
                }
                if (Pass2 == "")
                {
                    return "请填写确认密码";
                }
            }
            if (Pass1.Length > 0 || Pass2.Length > 0)
            {
                if (Pass1.Length < 6 || Pass1.Length > 16)
                    return "密码长度请控制在6-16位";
                if (Pass1 != Pass2)
                    return "两次输入密码不符";
            }
            model.User_password = DESEncrypt.MD5Encrypt(Pass1);
            model.User_addtime = DateTime.Now;

            model.User_status = true;
         
            model.Role_id = 1;
            if (Agency == "#")
            {
                return "请选择机构";
            }
            model.Agency_id = Convert.ToInt32(Agency);
            //if (Role == "#")
            //{
            //    return "请选择角色";
            //}
            //model.Role_id = Convert.ToInt32(Role);

            //选填部分
            model.User_gender = Convert.ToInt32(Sex) == 0;
            //if (IdNumber != "")
            //{
            //    if (IdNumberType == "#")
            //    {
            //        return "请选择证件类型";
            //    }
            //    //验证身份证信息，只能验证身份证
            //    else if (Convert.ToInt32(IdNumberType) == 1)
            //    {
            //        bool check = false;
            //        if (IdNumber.Length == 18)
            //        {
            //            check = CheckIDCard18(IdNumber);
            //        }
            //        else if (IdNumber.Length == 15)
            //        {
            //            check = CheckIDCard15(IdNumber);
            //        }
            //        if (check)
            //        {
            //            if (action != MyEnums.ActionEnum.Edit.ToString() && bll.GetRecordCount(" User_ID_number='" + IdNumber + "'") > 0)
            //            {
            //                return "该证件号已被添加";
            //            }
            //            model.User_ID_number_type = Convert.ToInt32(IdNumberType);
            //            model.User_ID_number = IdNumber;
            //        }
            //        else
            //        {
            //            return "请检查身份证号码是否正确";
            //        }
            //    }
            //}
            if (this.txtBirthday.Value != "")
            {
                DateTime Birthday = Convert.ToDateTime(this.txtBirthday.Value);
                model.User_birthday = Birthday;
            }
            try
            {
                if (action == MyEnums.ActionEnum.Edit.ToString()) //修改
                {
                    bll.Update(model);
                }
                else
                {
                    bll.Add(model);
                }
            }
            catch (Exception ex)
            {
                result = action == MyEnums.ActionEnum.Edit.ToString() ? "修改失败" : "添加失败" + ex.Message.ToString();
            }

            return result;
        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = DoAction();
            if (result == "")
            {
                JscriptMsg(action == MyEnums.ActionEnum.Edit.ToString() ? "修改成功" : "添加成功", "ManagerList.aspx", "Success");
                Response.Redirect("ManagerList.aspx?fun_id=" + get_fun_id("CCOM/ManagerManage/ManagerList.aspx"));
            }
            else
                JscriptMsg(result, "", "Error");
        }

        // 18位身份证验证
        private bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        // 15位身份证验证
        private bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }
    }
}