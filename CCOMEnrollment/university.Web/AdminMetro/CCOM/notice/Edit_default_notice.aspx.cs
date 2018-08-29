using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace university.Web.AdminMetro.CCOM.notice
{
    public partial class Edit_default_notice : university.UI.ManagePage
    {
        public Edit_default_notice()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string notice_content = this.txtContent.Text.Trim();
            if (notice_content.Length <= 0 || notice_content.Length>250)
            {
                JscriptMsg("文字通知内容必须在1~250个字符之间！！", "", "Error");
                return ;
            }
            var bll = new BLL.CCOM.Notice();
            var notice_model = bll.GetModel(" Notice_flag=1");
            if(notice_model==null)
            {
                Model.CCOM.Notice model = new Model.CCOM.Notice();
                model.Notice_date = DateTime.Now;
                model.Notice_flag = true;
                model.Notice_sender_id = GetAdminInfo_CCOM().User_id;
                model.Notice_last_editor = GetAdminInfo_CCOM().User_id;
                model.Notice_type = false;
                model.Notice_receiver_id = "all_user";
                model.Notice_title = "[系统通知]";
                model.Notice_content = notice_content;
                long _id = bll.Add(model);
                if (_id > 0)
                {
                    JscriptMsg("默认通知编辑成功", "", "Success");
                }
            }
            else
            {
                notice_model.Notice_date = DateTime.Now;
                notice_model.Notice_last_editor = GetAdminInfo_CCOM().User_id;
                notice_model.Notice_content = notice_content;
                if(bll.Update(notice_model))
                {
                    JscriptMsg("默认通知编辑成功", "", "Success");
                }
            }
        }
    }
}