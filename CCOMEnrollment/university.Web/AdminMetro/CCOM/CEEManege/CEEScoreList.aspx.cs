using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.CEEManege
{
    public partial class CEEScoreList : university.UI.ManagePage
    {
        protected string keywords = "";
        protected string pro_id;
        protected int period_id = 0;
        public CEEScoreList()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var period = new BLL.CCOM.Period().GetModel("Period_state = 1");
            if (period != null)
            {
                period_id = period.Period_id;
            }

            pro_id = MyRequest.GetQueryString("pro_id");
            if (!string.IsNullOrEmpty(pro_id))//编辑
            {
                this.pro_id = DESEncrypt.Decrypt(pro_id);
            }

            if (!Page.IsPostBack)
            {
                keywords = MyRequest.GetQueryString("keywords");
                if (Tools.CheckParams(keywords))
                {
                    keywords = "";
                }
                this.txtKeywords.Text = keywords;

                RptBind();
            }
        }

        private void RptBind()
        {
            string order = "UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);

            var bll = new BLL.CCOM.Province();
            this.ddlProvince.DataSource = bll.GetAllList();
            this.ddlProvince.DataTextField = "Province_name";
            this.ddlProvince.DataValueField = "Province_id";
            this.ddlProvince.DataBind();
            ListItem item = new ListItem("--所有省份--", "0");
            this.ddlProvince.Items.Insert(0, item);
            if (!string.IsNullOrEmpty(pro_id))
            {
                this.ddlProvince.SelectedValue = pro_id;
            }
            try
            {
                RptBind(strWhere, order);
            }
            catch
            {
                JscriptMsg("获取考生成绩出错", "", "Error");
            }
        }

        private void RptBind(string _strWhere, string _order)
        {
            int pageSize = GetPageSize(30); //每页数量
            int page = MyRequest.GetQueryInt("page", 1);
            int start_index = pageSize * (page - 1) + 1;
            int end_index = pageSize * page;

            BLL.CCOM.View_User_CEE bll = new BLL.CCOM.View_User_CEE();

            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);
         //   txtSearchResult.Text = "本次命中" + totalCount.ToString() + "条";

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("CEEScoreList.aspx", "fun_id={0}&page={1}&keywords={2}&pro_id={3}", DESEncrypt.Encrypt(this.fun_id), "__id__",
                 this.txtKeywords.Text, DESEncrypt.Encrypt(this.ddlProvince.SelectedValue));
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            if (Tools.CheckParams(_keywords))
                return " 1=0 ";

            StringBuilder strTemp = new StringBuilder();

            strTemp.Append(" 1 = 1 AND Period_id=" + period_id);

            //搜索关键字
            _keywords = _keywords.Trim();
            if (!_keywords.Equals(""))
            {
                strTemp.Append("AND (User_realname like '%" + _keywords + "%'");
                strTemp.Append(" or UP_CCOM_number= '" + _keywords + "')");
            }

            if (!pro_id.Equals("") && !pro_id.Equals("0"))
            {
                strTemp.Append("AND UP_province =" + pro_id);
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("CEEScoreList_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #region 设置分页数量=====================
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("CEEScoreList_page_size", _pagesize.ToString(), 43200);
                }
            }
            string keywords = MyRequest.GetQueryString("keywords");
            Response.Redirect(Utils.CombUrlTxt("CEEScoreList.aspx", "fun_id={0}&keywords={1}&pro_id={2}", DESEncrypt.Encrypt(this.fun_id), this.txtKeywords.Text, DESEncrypt.Encrypt(this.ddlProvince.SelectedValue)));
        }
        #endregion

        public string GetWenOrLi(string str)
        {
            switch (str)
            {
                case "1": return "文";
                case "2": return "理";
                case "3": return "不分文理";
                default: return "";
            }
        }

        public string GetProvinceName(string pro_id)
        {
            string pro_name = "";
            try
            {
                var bll = new BLL.CCOM.Province();
                var model = bll.GetModel(" Province_id=" + pro_id);
                pro_name = model.Province_name;
            }
            catch
            {

            }
            return pro_name;
        }

        public string GetAgencyName(string agency_id)
        {
            string agency_name = "";
            try
            {
                var bll = new BLL.CCOM.Agency();
                var model = bll.GetModel(" Agency_id=" + agency_id);
                agency_name = model.Agency_name;
            }
            catch
            {

            }
            return agency_name;
        }

        protected void Excel_Click(object sender, EventArgs e)
        {
            string order = "UP_CCOM_number asc";
            string strWhere = "1=1 ";

            try
            {
                var bll = new BLL.CCOM.View_User_CEE();
                List<Model.CCOM.View_User_CEE> modelList = bll.GetModelList(strWhere + " order by " + order);

                #region
                DataSet ds = new DataSet();
                ds.Tables.Clear();

                DataTable dt = ds.Tables.Add("Sheet1");
                DataRow dr;
                DataColumn column;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "序号";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "考生号";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "姓名";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "文理";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "语文";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "数学";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "外语";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "综合";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "附加分";
                ds.Tables["Sheet1"].Columns.Add(column);

                /*
                //增加只导出选择部分学生的功能
                bool exprotAll = true;
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                    if (cb.Checked == true)
                    {
                        exprotAll = false;
                        break;
                    }
                }
               */

                //int count = exprotAll == true ? modelList.Count : rptList.Items.Count;
                int count = modelList.Count;
                for (int i = 0, num = 1; i < count; i++, num++)
                {
                    /*
                    //如果只导出部分学生且未选中，则跳过
                    if (exprotAll == false)
                    {
                        CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                        if (cb.Checked == false)
                        {
                            //增加序号
                            num--;
                            continue;
                        }
                    }
                    */

                    dr = ds.Tables["Sheet1"].NewRow();
                    dr["序号"] = num.ToString();
                    dr["姓名"] = modelList[i].User_realname;
                    dr["考生号"] = modelList[i].UP_CCOM_number;
                    dr["文理"] = modelList[i].CEE_type;

                    if (modelList[i].CEE_Chinese_score.ToString() != "" && modelList[i].CEE_Chinese_score.ToString() != null)
                    {
                        dr["语文"] = ((decimal)modelList[i].CEE_Chinese_score).ToString("#.##");
                    }
                    if (modelList[i].CEE_Math_score.ToString() != "" && modelList[i].CEE_Math_score.ToString() != null)
                    {
                        dr["数学"] = ((decimal)modelList[i].CEE_Math_score).ToString("#.##");
                    }
                    if (modelList[i].CEE_English_score.ToString() != "" && modelList[i].CEE_English_score.ToString() != null)
                    {
                        dr["外语"] = ((decimal)modelList[i].CEE_English_score).ToString("#.##");
                    }
                    if (modelList[i].CEE_comprehensive_score.ToString() != "" && modelList[i].CEE_comprehensive_score.ToString() != null)
                    {
                        dr["综合"] = ((decimal)modelList[i].CEE_comprehensive_score).ToString("#.##");
                    }
                    if (modelList[i].CEE_extra_score.ToString() != "" && modelList[i].CEE_extra_score.ToString() != null)
                    {
                        dr["附加分"] = ((decimal)modelList[i].CEE_extra_score).ToString("#.##");
                    }

                    ds.Tables["Sheet1"].Rows.Add(dr);
                }
                #endregion

                DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), "导入考生高考成绩模板" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("导入考生高考成绩模板出错", "", "Error");
            }
        }

        protected void ddlPro_SelectedIndexChanged(object sender, EventArgs e)
        {
            pro_id = this.ddlProvince.SelectedValue;

            string order = "UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);
            try
            {
                RptBind(strWhere, order);
            }
            catch
            {
                JscriptMsg("获取考生成绩出错", "", "Error");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("CEEScoreList.aspx", "fun_id={0}&keywords={1}&pro_id={2}", DESEncrypt.Encrypt(this.fun_id), this.txtKeywords.Text, DESEncrypt.Encrypt(this.ddlProvince.SelectedValue)));
        }

        protected void exportexcel_ServerClick(object sender, EventArgs e)
        {
            string order = "UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);
            try
            {
                var bll = new BLL.CCOM.View_User_CEE();
                List<Model.CCOM.View_User_CEE> modelList = bll.GetModelList(strWhere + " order by " + order);

                DataSet ds = new DataSet();
                ds.Tables.Clear();

                DataTable dt = ds.Tables.Add("Sheet1");
                DataRow dr;
                DataColumn column;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "序号";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "考生号";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "姓名";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "高考报名号";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "专业方向";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "考生类型：文/理";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "语文";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "数学";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "外语";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "综合分";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "附加分";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "总分";
                ds.Tables["Sheet1"].Columns.Add(column);

                /*
                //增加只导出选择部分学生的功能
                bool exprotAll = true;
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                    if (cb.Checked == true)
                    {
                        exprotAll = false;
                        break;
                    }
                }
               */

                //int count = exprotAll == true ? modelList.Count : rptList.Items.Count;
                int count = modelList.Count;
                for (int i = 0, num = 1; i < count; i++, num++)
                {
                    /*
                    //如果只导出部分学生且未选中，则跳过
                    if (exprotAll == false)
                    {
                        CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                        if (cb.Checked == false)
                        {
                            //增加序号
                            num--;
                            continue;
                        }
                    }
                    */

                    dr = ds.Tables["Sheet1"].NewRow();
                    dr["序号"] = num.ToString();
                    dr["考生号"] = modelList[i].UP_CCOM_number;
                    dr["姓名"] = modelList[i].User_realname;
                    dr["高考报名号"] = modelList[i].UP_CEE_number;
                    dr["专业方向"] = GetAgencyName(modelList[i].Agency_id.ToString());
                    dr["考生类型：文/理"] = GetWenOrLi(modelList[i].CEE_type.ToString());

                    if (modelList[i].CEE_Chinese_score.ToString() != "" && modelList[i].CEE_Chinese_score.ToString() != null)
                    {
                        dr["语文"] = ((decimal)modelList[i].CEE_Chinese_score).ToString("#.##");
                    }
                    if (modelList[i].CEE_Math_score.ToString() != "" && modelList[i].CEE_Math_score.ToString() != null)
                    {
                        dr["数学"] = ((decimal)modelList[i].CEE_Math_score).ToString("#.##");
                    }
                    if (modelList[i].CEE_English_score.ToString() != "" && modelList[i].CEE_English_score.ToString() != null)
                    {
                        dr["外语"] = ((decimal)modelList[i].CEE_English_score).ToString("#.##");
                    }
                    if (modelList[i].CEE_comprehensive_score.ToString() != "" && modelList[i].CEE_comprehensive_score.ToString() != null)
                    {
                        dr["综合"] = ((decimal)modelList[i].CEE_comprehensive_score).ToString("#.##");
                    }
                    if (modelList[i].CEE_extra_score.ToString() != "" && modelList[i].CEE_extra_score.ToString() != null)
                    {
                        dr["附加分"] = ((decimal)modelList[i].CEE_extra_score).ToString("#.##");
                    }
                    if (modelList[i].CEE_score.ToString() != "" && modelList[i].CEE_score.ToString() != null)
                    {
                        dr["总分"] = ((decimal)modelList[i].CEE_score).ToString("#.##");
                    }

                    ds.Tables["Sheet1"].Rows.Add(dr);
                }

                DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), this.ddlProvince.SelectedItem.Text +"_高考分数_" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("导出高考分数出错", "", "Error");
            }
        }
    }
}