using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.update_info
{
    public partial class update_info : university.UI.ManagePage
    {
        private static long _id = 0;
        public update_info()
        {
            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Model.CCOM.User_information model = GetAdminInfo_CCOM();
            _id = model.User_id;

            if (!Page.IsPostBack)
            {
                ShowInfo();
            }
        }
        #region 赋值操作=================================
        protected void ShowInfo()
        {
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information user_model = user_bll.GetModel(_id);

            if (user_model == null)
            {
                InnerRedirect(MyEnums.RediirectErrorEnum.ParameterError);
            }

            //真实姓名
            if (user_model.User_realname == null)
            {
                txt_User_realname.Text = "请填写真实姓名";
            }
            else
            {
                this.txt_User_realname.Text = user_model.User_realname;
            }
            int agency_id = 0;
            agency_id = user_model.Agency_id;
            BLL.CCOM.Agency user_agency_bll = new BLL.CCOM.Agency();
            Model.CCOM.Agency user_agency_model = user_agency_bll.GetModel(agency_id);
            if (user_agency_model.Agency_id != 0)
            {
                 txt_Agency.Text = user_agency_model.Agency_name;
            }
            else
            {
                 div_user_agency.Visible = false;
            }
            
            //移动电话
            this.txt_User_number.Text = user_model.User_number;

            //性别
            if ((Boolean)user_model.User_gender)
            {
                this.rbl_User_gender.SelectedIndex = 1;
            }

            ////证件类型
            //this.ddl_User_ID_number_type.SelectedValue = user_model.User_ID_number_type.ToString();

            ////证件号码
            //if (user_model.User_ID_number == null)
            //{
            //    txt_User_ID_number.Text = "请填写证件号码";
            //}
            //else
            //{
            //    this.txt_User_ID_number.Text = user_model.User_ID_number;
            //}

            //出生日期
            if (user_model.User_birthday == null)
            {
                txt_User_birthday.Text = "请填写出生日期";
            }
            else
            {
                this.txt_User_birthday.Text = Convert.ToDateTime(user_model.User_birthday).ToString("yyyy-MM-dd");
            }

            //添加日期
            this.txt_User_addtime.Text = Convert.ToDateTime(user_model.User_addtime).ToString("yyyy-MM-dd");
        }
        #endregion

        #region 更新操作=================================
        private bool DoUpdateUserInfo(long _id)
        {
            BLL.CCOM.User_information user_bll = new BLL.CCOM.User_information();
            Model.CCOM.User_information user_model = user_bll.GetModel(_id);

            bool result = false;

            //更新姓名
            if (txt_User_realname.Text == "")
            {
                JscriptMsg("请填写真实姓名！", "", "Error");
                return false;
            }
            else
            {
                user_model.User_realname = this.txt_User_realname.Text;
            }

            //更改选择的结果            
            //

            //更新手机号，内容不变
            user_model.User_number = this.txt_User_number.Text;

            //更新性别

            if (this.rbl_User_gender.SelectedIndex == 0)
            {
                user_model.User_gender = false;
            }
            else
            {
                user_model.User_gender = true;
            }
            //= Convert.ToBoolean(this.rbl_User_gender.SelectedValue);

            ////更新证件类型
            //user_model.User_ID_number_type = Convert.ToInt32(this.ddl_User_ID_number_type.SelectedValue);

            ////更新证件号码
            //if (txt_User_ID_number.Text == "")
            //{
            //    JscriptMsg("请填写证件号码！", "", "Error");
            //    return false;
            //}
            //else
            //{
            //    //验证身份证信息，只能验证身份证
            //    string _txt_User_Id_number = txt_User_ID_number.Text.ToString();


            //    if (Convert.ToInt32(this.ddl_User_ID_number_type.SelectedValue) == 1)
            //    {
            //        bool check = false;

            //        if (_txt_User_Id_number.Length == 18)
            //        {
            //            check = CheckIDCard18(_txt_User_Id_number);
            //        }
            //        else if (_txt_User_Id_number.Length == 15)
            //        {
            //            check = CheckIDCard15(_txt_User_Id_number);
            //        }

            //        if (check)
            //        {
            //            user_model.User_ID_number = this.txt_User_ID_number.Text;
            //        }
            //        else
            //        {
            //            JscriptMsg("请检查身份证号码是否正确！", "", "Error");
                        
            //            return false;
            //        }
            //    }
            //    //非身份证的时候
            //    else
            //    {
            //        user_model.User_ID_number = this.txt_User_ID_number.Text;
            //    }
            //}

            //更新出生日期
            try
            {
                user_model.User_birthday = Convert.ToDateTime(this.txt_User_birthday.Text);
            }
            catch
            {
                user_model.User_birthday = null;
            }

            //更新的状态
            try
            {
                bool res = user_bll.Update(user_model);
                if (res == true)
                {
                    return res;
                }
            }
            catch
            {
                result = false;
            }
            return result;

        }

        /// <summary>
        /// 18位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
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
        /// <summary>
        /// 15位身份证验证
        /// </summary>
        /// <param name="Id">身份证号</param>
        /// <returns></returns>
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


        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                if (DoUpdateUserInfo(_id))
                {
                    JscriptMsg("更新成功！", "update_info.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
                }
                else
                {
                    JscriptMsg("更新信息失败！", "", "Error");
                }
            }
        }
        #endregion

    }
}