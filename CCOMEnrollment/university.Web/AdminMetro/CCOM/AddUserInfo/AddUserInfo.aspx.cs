using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using university.Common;

namespace university.Web.AdminMetro.CCOM.AddUserInfo
{
    public partial class AddUserInfo : university.UI.ManagePage
    {
        private static long _id = 0;
        public AddUserInfo()
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
                new BLL.CCOM.Nation().BindDDL(this.ddl_UP_nation);
                new BLL.CCOM.Nationality().BindDDL(this.ddl_UP_nationality);
                new BLL.CCOM.Politics().BindDDL(this.ddl_UP_politics);
                new BLL.CCOM.Degree().BindDDL(this.ddl_UP_degree);
                new BLL.CCOM.Province().BindDDL(this.ddl_UP_province);
                showUserInfo();
            }
        }

        #region 显示信息操作=================================
        protected void showUserInfo()
        {
            BLL.CCOM.User_property user_bll = new BLL.CCOM.User_property();
            Model.CCOM.User_property user_model = user_bll.GetModel(_id);

            BLL.CCOM.Period user_bll_period = new BLL.CCOM.Period();
            Model.CCOM.Period user_model_period = user_bll_period.GetModel(user_model.Period_id);

            if (user_model == null)
            {
                InnerRedirect(MyEnums.RediirectErrorEnum.ParameterError);
            }

            //国籍
            this.ddl_UP_nation.Text = user_model.UP_nation.ToString();

            //民族
            this.ddl_UP_nationality.Text = user_model.UP_nationality.ToString();

            //政治面貌
            this.ddl_UP_politics.Text = user_model.UP_politics.ToString();

            //文化程度
            this.ddl_UP_degree.Text = user_model.UP_degree.ToString();

            //高中毕业院校
            this.txt_UP_high_school.Text = user_model.UP_high_school;

            //高考报名号
            this.txt_UP_CEE_number.Text = user_model.UP_CEE_number;

            //省艺术联考考生号
            this.txt_UP_AEE_number.Text = user_model.UP_AEE_number;

            //专业考试期间移动电话
            this.txt_UP_PE_Iphone.Text = user_model.UP_PE_Iphone;

            //常规移动电话
            this.txt_UP_PE_Aphone.Text = user_model.UP_PE_Aphone;

            //高考所在地
            this.ddl_UP_province.Text = user_model.UP_province.ToString();

            //录取通知书地址
            this.txt_UP_address.Text = user_model.UP_address;

            //收件人
            this.txt_UP_receiver.Text = user_model.UP_receiver;

            //收件人电话
            this.txt_UP_receiver_phone.Text = user_model.UP_receiver_phone;

            //邮编
            this.txt_UP_postal_code.Text = user_model.UP_postal_code;

            //证件复印图片
            string UP_ID_picture_path = user_model.UP_ID_picture.ToString();
            if (UP_ID_picture_path != "")
            {
                this.img_UP_ID_picture.Src = UP_ID_picture_path;
                this.txt_UP_ID_picture.Text = UP_ID_picture_path;
            }
            else
            {
                this.img_UP_ID_picture.Src = "";
                this.txt_UP_ID_picture.Text = "";
            }

            //近期免冠照片
            string UP_picture_path = user_model.UP_picture.ToString();
            if (UP_picture_path != "")
            {
                this.img_UP_picture.Src = UP_picture_path;
                this.txt_UP_picture.Text = UP_picture_path;
            }
            else
            {
                this.img_UP_picture.Src = "";
                this.txt_UP_picture.Text = "";
            }

            //省联考合格证
            string UP_AEE_picture_path = user_model.UP_AEE_picture.ToString();
            if (UP_AEE_picture_path != "")
            {
                this.img_UP_AEE_picture.Src = UP_AEE_picture_path;
                this.txt_UP_AEE_picture.Text = UP_AEE_picture_path;
            }
            else
            {
                this.img_UP_AEE_picture.Src = "";
                this.txt_UP_AEE_picture.Text = "";
            }

            //所属周期
            this.txt_Period_id.Text = user_model_period.Period_year.ToString();

        }
        #endregion

        #region 更新信息操作=================================
        private bool DoUpdateUserInfo(long _id)
        {
            BLL.CCOM.User_property user_bll = new BLL.CCOM.User_property();
            Model.CCOM.User_property user_model = user_bll.GetModel(_id);

            bool result = false;

            //国籍
            user_model.UP_nation = Convert.ToInt32(this.ddl_UP_nation.SelectedValue);

            //民族
            user_model.UP_nationality = Convert.ToInt32(this.ddl_UP_nationality.SelectedValue);

            //政治面貌
            user_model.UP_politics = Convert.ToInt32(this.ddl_UP_politics.SelectedValue);

            //文化程度
            user_model.UP_degree = Convert.ToInt32(this.ddl_UP_degree.SelectedValue);

            //高中毕业院校
            user_model.UP_high_school = this.txt_UP_high_school.Text;

            //高考报名号
            user_model.UP_CEE_number = this.txt_UP_CEE_number.Text;

            //省艺术联考考生号
            user_model.UP_AEE_number = this.txt_UP_AEE_number.Text;

            //专业考试期间移动电话
            user_model.UP_PE_Iphone = this.txt_UP_PE_Iphone.Text;

            //常规移动电话
            user_model.UP_PE_Aphone = this.txt_UP_PE_Aphone.Text;

            //高考所在地
            user_model.UP_province = Convert.ToInt32(this.ddl_UP_province.SelectedValue);

            //录取通知书地址
            user_model.UP_address = this.txt_UP_address.Text;

            //收件人
            user_model.UP_receiver = this.txt_UP_receiver.Text;

            //收件人电话
            this.txt_UP_receiver_phone.Text = user_model.UP_receiver_phone;

            //邮编
            user_model.UP_postal_code = this.txt_UP_postal_code.Text;

            //复印件证件图片
            if (this.txt_UP_ID_picture.Text != "")
                user_model.UP_ID_picture = Utils.Filter(this.txt_UP_ID_picture.Text.Trim());


            if (!String.IsNullOrEmpty(user_model.UP_ID_picture))
            {
                //创建文件夹
                FileOperate.FolderCreate(Utils.GetMapPath(DataDic.UP_ID_picture_Path));


                //图片处理
                String toFilePath = DataDic.UP_ID_picture_Path + DateTime.Now.Ticks.ToString() +
                                    FileOperate.GetPostfixStr(user_model.UP_ID_picture);
                FileOperate.FileMove(Server.MapPath(user_model.UP_ID_picture),
                    Server.MapPath(toFilePath));
                user_model.UP_ID_picture = toFilePath;
            }

            //上传近期免冠照片
            if (this.txt_UP_picture.Text != "")
                user_model.UP_picture = Utils.Filter(this.txt_UP_picture.Text.Trim());


            if (!String.IsNullOrEmpty(user_model.UP_picture))
            {
                //创建文件夹
                FileOperate.FolderCreate(Utils.GetMapPath(DataDic.UP_picture_Path));

                //图片处理
                String toFilePath = DataDic.UP_picture_Path + DateTime.Now.Ticks.ToString() +
                                    FileOperate.GetPostfixStr(user_model.UP_picture);
                FileOperate.FileMove(Server.MapPath(user_model.UP_picture),
                    Server.MapPath(toFilePath));
                user_model.UP_picture = toFilePath;
            }

            //上传省联考合格证
            if (this.txt_UP_AEE_picture.Text != "")
                user_model.UP_AEE_picture = Utils.Filter(this.txt_UP_AEE_picture.Text.Trim());


            if (!String.IsNullOrEmpty(user_model.UP_AEE_picture))
            {
                //创建文件夹
                FileOperate.FolderCreate(Utils.GetMapPath(DataDic.UP_AEE_picture_Path));

                //图片处理
                String toFilePath = DataDic.UP_AEE_picture_Path + DateTime.Now.Ticks.ToString() +
                                    FileOperate.GetPostfixStr(user_model.UP_AEE_picture);
                FileOperate.FileMove(Server.MapPath(user_model.UP_AEE_picture),
                    Server.MapPath(toFilePath));
                user_model.UP_AEE_picture = toFilePath;
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

        //保存
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                if (DoUpdateUserInfo(_id))
                {
                    JscriptMsg("添加信息成功！", "AddUserInfo.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
                }
                else
                {
                    JscriptMsg("添加信息失败！", "back", "Error");
                }
            }
        }
        #endregion


        //protected void ddlAdminUser_HomeProvince_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.ddl_UP_province.Items.Clear();
        //    new BLL.admin.common().BindCityDDL(this.ddl_UP_province, this.ddlAdminUser_HomeProvince.SelectedValue);
        //}

    }
}