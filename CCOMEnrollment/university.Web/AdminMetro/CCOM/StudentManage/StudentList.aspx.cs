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

namespace university.Web.AdminMetro.CCOM.StudentManage
{
    public partial class StudentList : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string uo_id = MyRequest.GetQueryString("uo_id").Trim();
        protected string keywords = MyRequest.GetQueryString("keywords");
        protected string provence = MyRequest.GetQueryString("provence").Trim();

        public StudentList()
        {
            //this.adminfuncition = true;
            //this.checkFunID = true;
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
                //判断是不是管理员登录
                //Model.CCOM.User_information model = GetAdminInfo_CCOM();
                //if (model.User_type != 6)
                //    InnerRedirect(MyEnums.RediirectErrorEnum.NotAdmin);

                //绑定机构下拉菜单
                this.ddlOrgan.DataSource = GetOrgList_DataSet(false);
                this.ddlOrgan.DataTextField = "Agency_name";
                this.ddlOrgan.DataValueField = "Agency_id";
                this.ddlOrgan.DataBind();
                this.ddlOrgan.Items.Insert(0, new ListItem("全选", "0"));
                //绑定角色下拉菜单
                new BLL.CCOM.Role().BindDDL(this.ddlprovence);
                //this.ddlprovence.DataSource = GetOrgList_DataSet(false);
                //this.ddlprovence.DataTextField = "Role_name";
                //this.ddlprovence.DataValueField = "Role_id";
                //this.ddlprovence.DataBind();
                //new BLL.CCOM.Province().BindDDL(this.ddlprovence);
                this.ddlprovence.Items.Insert(0, new ListItem("全选", "0"));
                ListItem it = this.ddlprovence.Items.FindByValue("1");
                this.ddlprovence.Items.Remove(it);
                //ListItem it2 = this.ddlprovence.Items.FindByValue("4");
                //this.ddlprovence.Items.Remove(it2);
                BindRpt();

            }

        }

        protected void BindRpt()
        {
            if (uo_id.Equals(""))
                this.uo_id = this.ddlOrgan.SelectedValue;
            if (provence.Equals(""))
                this.provence = this.ddlprovence.SelectedValue;
            else
            {
                if (!uo_id.Equals("-1"))
                    this.ddlOrgan.SelectedValue = uo_id.ToString();

                if (!provence.Equals("-1"))
                    this.ddlprovence.SelectedValue = provence.ToString();
            }
            string _order = MyRequest.GetString("sort").Replace(",", " ");
            if (_order == "" || Tools.CheckParams(_order)) _order = " User_id asc";
            RptBind( CombSqlTxt(this.uo_id,this.provence, this.keywords), _order);
        }
        
        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _uo_id,string procence, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append(" Role_id!=1");
            int organ = 0;
            try
            {
                organ = Convert.ToInt32(_uo_id);
            }
            catch (Exception) { }
            if (organ >= 0)
            {
                strTemp.Append(" and Agency_id in (" + GetSonUOList(organ) + ")");
            }
            else
                strTemp.Append(" and Agency_id=-1 ");

            //BLL.CCOM.Period per_bll = new BLL.CCOM.Period();
            //Model.CCOM.Period per_model = per_bll.GetModel(" Period_state=1");
            //if (per_model != null) strTemp.Append(" and Period_id='" + per_model.Period_id + "'");
            //else strTemp.Append(" and Period_id=0");

            int Provence = 0;
            try
            {
                Provence = Convert.ToInt32(provence);
            }
            catch (Exception) { }
            if (Provence != 0) strTemp.Append(" and Role_id=" + Provence);        
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and User_realname like '%" + _keywords + "%' ");
                strTemp.Append(" or User_number like '%" + _keywords + "%' ");
            }
            return strTemp.ToString();
        }
        #endregion

        //删除
        protected void lbtSingleDelete_Click(object sender, EventArgs e)
        {
            BLL.CCOM.User_information bll = new BLL.CCOM.User_information();


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
                string keywords = MyRequest.GetQueryString("keywords");
                int page = MyRequest.GetQueryInt("page", 1);
                if (result == true)
                {
                    //JscriptMsg("删除成功！", Utils.CombUrlTxt("ManagerList.aspx", "fun_id={0}&keywords={1}&page={2}",
                    //    DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Success");
                    JscriptMsg("删除成功！", "ManagerList.aspx", "Success");
                    Response.Redirect("StudentList.aspx?fun_id=" + get_fun_id("CCOM/StudentManage/StudentList.aspx"));
                }
                else
                    JscriptMsg("删除失败！", Utils.CombUrlTxt("StudentList.aspx", "fun_id={0}&keywords={1}&page={2}",
                        DESEncrypt.Encrypt(this.fun_id), keywords, page.ToString()), "Error");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(15); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            string keywords = MyRequest.GetQueryString("keywords");
            int start_index = pageSize * (page - 1) + 1;
            this.st_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;
            this.txtKeywords.Value = keywords;

            //BLL.CCOM.View_UserAgency bll = new BLL.CCOM.View_UserAgency();
            BLL.CCOM.View_User bll = new BLL.CCOM.View_User();
            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("StudentList.aspx", "fun_id={0}&uo_id={1}&keywords={2}&sort={3}&page={4}", this.fun_id, uo_id, this.keywords, MyRequest.GetString("sort"), "__id__");
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
            this.ddlOrgan.SelectedValue = uo_id.ToString();
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

        //得到指定部门下所有的机构列表
        public string GetSonUOList(int UO_ID)
        {
            string res = "";
            res += UO_ID.ToString() + ",";
            List<Model.CCOM.Agency> modellist = new BLL.CCOM.Agency().GetModelList(" Agency_father = " + UO_ID + " and Agency_status=1");
            foreach (Model.CCOM.Agency model in modellist)
            {
                res += GetSonUOList(model.Agency_id) + ",";
            }
            return Utils.DelLastComma(res);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTableExportToExcel("考生名单", "sheet1");
        }

        /// <summary>
        /// Myxls导出Excel，保存在客户端
        /// </summary>
        private void DataTableExportToExcel(string xlsName, string sheetName)
        {
            //表头
            //决定Datatable显示哪些内容
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add("Sheet1");
            DataRow dr;
            DataColumn column;

            //1---序号
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "序号";
            ds.Tables["Sheet1"].Columns.Add(column);
            //2---姓名
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "姓名";
            ds.Tables["Sheet1"].Columns.Add(column);
            //3---学号/工号
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "联系电话";
            ds.Tables["Sheet1"].Columns.Add(column);
            //4---性别
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "性别";
            ds.Tables["Sheet1"].Columns.Add(column);
            ////5---省份
            //column = new DataColumn();
            //column.DataType = System.Type.GetType("System.String");
            //column.ColumnName = "省份";
            //ds.Tables["Sheet1"].Columns.Add(column);
           
            //6---政治面貌
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "政治面貌";
            ds.Tables["Sheet1"].Columns.Add(column);
            //7---机构
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "报考方向";
            ds.Tables["Sheet1"].Columns.Add(column);



            var ml = new BLL.CCOM.View_UserAgency().GetModelList(" User_type !=6 " + CombSqlTxt(this.uo_id,this.provence, this.keywords));

            for (int row = 0; row < ml.Count; row++)
            {
                var m = ml[row];

                dr = ds.Tables["Sheet1"].NewRow();
                dr[0] = row + 1;
                dr[1] = m.User_realname;
                dr[2] = ((Boolean) m.User_gender) == false ? "男" : "女";
                dr[3] = GetProvince(Utils.ObjectToStr(m.User_id));
                dr[4] = m.User_number;
                dr[5] = GetNationality(Utils.ObjectToStr(m.User_id));
                dr[6] = m.Agency_name;

                ds.Tables["Sheet1"].Rows.Add(dr);
            }

            //导出EXCEL，速度有点慢
            DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), xlsName + ".xlsx", this.Page);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keywords = this.txtKeywords.Value;
            Response.Redirect(Utils.CombUrlTxt("StudentList.aspx", "fun_id={0}&uo_id={1}&keywords={2}", this.fun_id.ToString(), this.ddlOrgan.SelectedValue, this.txtKeywords.Value));
        }

        //切换机构
        protected void ddlOrgan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("StudentList.aspx", "fun_id={0}&uo_id={1}&keywords={2}&provence={3}",
                this.fun_id.ToString(), this.ddlOrgan.SelectedValue, this.keywords, this.ddlprovence.SelectedValue));
        }

        //切换角色
        protected void ddlProvence_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("StudentList.aspx", "fun_id={0}&uo_id={1}&keywords={2}&provence={3}",
                this.fun_id.ToString(), this.ddlOrgan.SelectedValue, this.keywords, this.ddlprovence.SelectedValue));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("stu_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("StudentList.aspx", "fun_id={0}&uo_id={1}&keywords={2}", this.fun_id, this.ddlOrgan.SelectedValue, this.keywords));
        }

        public string GetUserActivity(bool AdminUser_Activity)
        {
            if (AdminUser_Activity)
                return "可用";
            else 
                return "禁用";
        }

        public string GetNationality(string UserID)
        {
            BLL.CCOM.User_property bll = new BLL.CCOM.User_property();
            string str = string.Empty;
            try
            {
                Model.CCOM.User_property model = bll.GetModel(" User_id='" + UserID + "'");
                str = new BLL.CCOM.Nationality().GetModel((int)model.UP_nationality).Nationality_name;
            }
            catch 
            {
                str = "未设置";
            }
            return str;
        }

        public string GetProvince(string UserID)
        {
            BLL.CCOM.User_property bll = new BLL.CCOM.User_property();
            string str = string.Empty;
            try
            {
                Model.CCOM.User_property model = bll.GetModel(" User_id='" + UserID + "'");
                str = new BLL.CCOM.Province().GetModel((int)model.UP_province).Province_name;
            }
            catch
            {
                str = "未设置";
            }
            return str;
        }

        public string GetExamNumber(string UserID)
        {
            BLL.CCOM.User_property bll = new BLL.CCOM.User_property();
            string str = string.Empty;
            try
            {
                Model.CCOM.User_property model = bll.GetModel(" User_id='" + UserID + "'");
                str = model.UP_CEE_number;
            }
            catch
            {
                str = "未设置";
            }
            return str;
        }

        public string GetPolitics(string UserID)
        {
            BLL.CCOM.User_property bll = new BLL.CCOM.User_property();
            string str = string.Empty;
            try
            {
                Model.CCOM.User_property model = bll.GetModel(" User_id='" + UserID + "'");
                str = new BLL.CCOM.Politics().GetModel((int)model.UP_politics).Politics_name;
            }
            catch
            {
                str = "未设置";
            }
            return str;
        }

        public string GetAgency(string UserID)
        {
            BLL.CCOM.User_property bll = new BLL.CCOM.User_property();
            string str = string.Empty;
            try
            {
                Model.CCOM.User_property model = bll.GetModel(" User_id='" + UserID + "'");
                str = new BLL.CCOM.Agency().GetModel((int)model.Agency_id).Agency_name;
            }
            catch
            {
                str = "未设置";
            }
            return str;
        }

        public string GetUserFace(string UserID)
        {
            BLL.CCOM.User_property bll = new BLL.CCOM.User_property();
            String facePath = "";
            try
            {
                Model.CCOM.User_property model = bll.GetModel(" User_id='" + UserID + "'");
                facePath = model.UP_picture.Trim();
            }
            catch {
                facePath = "/images/login/logo_left1.png";
            }
            if (facePath.Trim() != "" && facePath.Trim().StartsWith("http"))
                return "<img style=\"width:48px;\" src=\"" + facePath.Trim() + "\" alt=\"\" />";
            else
            {
                if (facePath.Trim() != "")
                    return "<img style=\"width:48px;\" src=\"" + DataDic.FILE_URL + facePath.Trim() + "\" alt=\"\" />";
                else
                    return "<img style=\"width:48px;\" src=\"/images/login/logo_left1.png\" alt=\"\" />";
            }
        }

    }
}