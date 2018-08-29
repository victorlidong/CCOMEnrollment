using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using System.Text;
using LitJson;

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class ApplyBestList : university.UI.ManagePage
    {
        protected int st_index = 0;

        public ApplyBestList()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
           // this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _order = MyRequest.GetString("sort").Replace(",", " ");
                if (_order == "" || Tools.CheckParams(_order)) _order = " Student_id asc";
                RptBind(_order);

            }
        }

        #region 数据绑定=================================
        private void RptBind(string _order)
        {
            string _strWhere = "";
            string str = GetStudentID();
            if (str != "") _strWhere += "Student_id in (" + str + ")";
            else _strWhere += "Student_id=-1";
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            this.st_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;

            BLL.CCOM.View_Selete_Topic bll = new BLL.CCOM.View_Selete_Topic();
            //计算数量
           // int totalCount = bll.GetRecordCount(_strWhere);
            //绑定我的选题
            
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();


        
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("stu_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        protected string GetStudentID()
        {
            string result = "";
            var student_list = new BLL.CCOM.Form_review().GetModelList(" Form_type_id=1 and Review_result=1");
            foreach (var student_model in student_list)
            {
                var form2_model = new BLL.CCOM.Form_review().GetModel(" Form_type_id=2 and User_id=" + student_model.User_id);
                if (form2_model != null)
                {
                    result += student_model.User_id + ",";
                }
            }
            if (result == "") return "";
            else return Utils.DelLastComma(result); ;
        }

        protected String GetFormReview1(long userId)
        {
            var model = new BLL.CCOM.Form_review().GetModel(" User_id=" + userId + " and Form_type_id=1");
            if (model == null) return "未提交";
            else if (model.Review_result == 0)
            {
                return "<a href=\"./FormReview.aspx?studentID=" + DESEncrypt.Encrypt(userId.ToString()) + "\">待审核</a>";
            }
            else if (model.Review_result == 1)
            {
                return "<a href=\"./FormReview.aspx?studentID=" + DESEncrypt.Encrypt(userId.ToString()) + "\"><b style=\"color: green;\">及格</b></a>";
            }
            else
            {
                return "<a href=\"./FormReview.aspx?studentID=" + DESEncrypt.Encrypt(userId.ToString()) + "\"><b style=\"color: red;\">不及格</b></a>";
            }
        }

        protected String GetFormReview2(long userId)
        {
            var model = new BLL.CCOM.Form_review().GetModel(" User_id=" + userId + " and Form_type_id=2");
            if (model == null) return "未提交";
            else if (model.Review_result == 0)
            {
                return "<a href=\"./FormReview2.aspx?studentID=" + DESEncrypt.Encrypt(userId.ToString()) + "\">待审核</a>";
            }
            else if (model.Review_result == 1)
            {
                return "<a href=\"./FormReview2.aspx?studentID=" + DESEncrypt.Encrypt(userId.ToString()) + "\"><b style=\"color: green;\">及格</b></a>";
            }
            else
            {
                return "<a href=\"./FormReview2.aspx?studentID=" + DESEncrypt.Encrypt(userId.ToString()) + "\"><b style=\"color: red;\">不及格</b></a>";
            }
        }
    }
}