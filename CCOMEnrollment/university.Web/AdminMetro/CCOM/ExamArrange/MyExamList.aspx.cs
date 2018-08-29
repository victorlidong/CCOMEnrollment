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
using System.IO;  

namespace university.Web.AdminMetro.CCOM.ExamArrange
{
    public partial class MyExamList : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string uo_id = MyRequest.GetQueryString("uo_id").Trim();
        protected string keywords = MyRequest.GetQueryString("keywords");
        protected string subject = MyRequest.GetQueryString("subject");

        public MyExamList()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected bool completeFirstIntro = false;
        public int StuCount = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fun_id = MyRequest.GetQueryString("fun_id");

            if (!Page.IsPostBack)
            {
                string _order = MyRequest.GetString("sort").Replace(",", " ");
                if (_order == "" || Tools.CheckParams(_order)) _order = " Group_id asc";
                RptBind(CombSqlTxt(), _order);
            }

        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt()
        {
            int flag = 0;
            int i = 0;
            var model = GetAdminInfo_CCOM();
            StringBuilder strTemp = new StringBuilder();
          
            BLL.CCOM.Reply_student rs_bll = new BLL.CCOM.Reply_student();
            BLL.CCOM.Reply_commission rc_bll = new BLL.CCOM.Reply_commission();
            BLL.CCOM.Reply_group rg_bll = new BLL.CCOM.Reply_group();
            strTemp.Append("(");
            //学生
            DataSet ds = rs_bll.GetList("User_id=" + model.User_id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                flag = 1;
                strTemp.Append(ds.Tables[0].Rows[0]["Group_id"]);
                for ( i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    strTemp.Append(","+ds.Tables[0].Rows[i]["Group_id"]);
                }
            }
            //组长
            ds = rg_bll.GetList("User_id=" + model.User_id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (flag == 0)
                {
                    flag = 1;
                    strTemp.Append(ds.Tables[0].Rows[0]["Group_id"]);
                    i = 1;
                }
                else
                    i = 0;
                for (; i < ds.Tables[0].Rows.Count; i++)
                {
                    strTemp.Append("," + ds.Tables[0].Rows[i]["Group_id"]);
                }
            }
            //组员
            ds = rc_bll.GetList("User_id=" + model.User_id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (flag == 0)
                {
                    flag = 1;
                    strTemp.Append(ds.Tables[0].Rows[0]["Group_id"]);
                    i = 1;
                }
                else
                    i = 0;
                for (; i < ds.Tables[0].Rows.Count; i++)
                {
                    strTemp.Append("," + ds.Tables[0].Rows[i]["Group_id"]);
                }
            }
            if (flag == 0)
                strTemp.Append("-1");
            strTemp.Append(")");
            
            return strTemp.ToString();
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind( string _strWhere,string _order)
        {
            BLL.CCOM.Reply_group bll = new BLL.CCOM.Reply_group();
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            this.st_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            if (_strWhere != "")
                _strWhere = "Group_id in" + _strWhere;
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("MyExamList.aspx", "fun_id={0}&keywords={1}&sort={2}&page={3}", this.fun_id, this.keywords, MyRequest.GetString("sort"), "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("exam_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("exam_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("MyExamList.aspx", "fun_id={0}&keywords={1}", this.fun_id, this.keywords));
        }

        public string GetStudentNumber(long id)
        {
            try
            {
                var ml = new BLL.CCOM.Reply_student().GetModelList(" Group_id=" + id);
                int number = ml.Count;
               // if (number == 0) return "0";
               return Utils.ObjectToStr(number) ;
            }
            catch
            {
                return "0";
            }
        }

        public string GetGroupType(string type)
        {
            if (type == "1")
                return "软件验收";
            else if (type == "0")
                return "口头答辩";
            else if (type == "2")
                return "开题评审";
            else return "";
        }

        public string GetTeacherName(long id)
        {
            try
            {
                BLL.CCOM.User_information bll = new BLL.CCOM.User_information();
                Model.CCOM.User_information model = bll.GetModel(id);
                return model.User_realname;
            }
            catch
            {
                return "该教师用户不存在";
            }
        }

        protected void lbtExportStudent_Click(object sender, EventArgs e)
        {
            string fileName="";
            string editId = (((LinkButton)sender).CommandArgument.ToString()).ToString();
            if(editId.Equals("1"))
                fileName = "答辩评分表.doc";
            else
                fileName = "软件验收表.doc";
          
            // 获取文件在服务器的地址    
            string path = "../../../download/";
            string url = Server.MapPath(path) + fileName;
            // 判断传输地址是否为空    
            if (url == "")
            {
                // 提示“该文件暂不提供下载”    
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script defer>alert('该文件暂不提供下载！');</script>");
                return;
            }
            FileStream fileStream = new FileStream(url, FileMode.Open);
            byte[] bytes = new byte[(int)fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            Response.ContentType = "application/octet-stream";

            // 通知浏览器下载   
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

    }
}