﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using university.Web.AdminMetro.CCOM.CEEManege;

namespace university.Web.AdminMetro.CCOM.AdmitManage
{
    public partial class SelectAdmission : university.UI.ManagePage
    {
        protected int st_index = 0;
        protected string keywords = "";
        protected long user_id = 0;
        protected int agency_id = -1;
        protected string major_id = "0";
        protected int period_id = 0;

        protected bool hasAdmission = true;

        public SelectAdmission()
        {
            this.checkFunID = true;
            this.checkUserStaus = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = GetAdminInfo_CCOM().User_id;
            var agency = new BLL.CCOM.Admin_agency().GetModel("User_id = " + user_id);
            if (agency != null)
            {
                agency_id = agency.Agency_id;
            }

            var period = new BLL.CCOM.Period().GetModel("Period_state = " + DataDic.Period_state_On);
            if (period != null)
            {
                period_id = period.Period_id;
            }
            string str = MyRequest.GetQueryString("major_id");
            if (str != null && str != "")
                major_id = DESEncrypt.Decrypt(MyRequest.GetQueryString("major_id"));

            if (!Page.IsPostBack)
            {
                keywords = MyRequest.GetQueryString("keywords");
                if (Tools.CheckParams(keywords))
                {
                    keywords = "";
                }
                this.txtKeywords.Text = keywords;

                RalBind();
            }

            this.major_id = this.ddlMajor.SelectedValue;
        }


        private void RalBind()
        {
            try
            {
                string strWhere = " Agency_type = " + DataDic.CCOM_Major_type;
                if (agency_id != DataDic.CCOM_Agency_id)
                {
                    strWhere += (" AND Agency_father = " + agency_id);
                }

                BLL.CCOM.Agency Bll = new BLL.CCOM.Agency();
                DataSet ds = Bll.GetList(strWhere);
                this.ddlMajor.DataSource = ds.Tables[0].DefaultView;
                this.ddlMajor.DataTextField = "Agency_name";
                this.ddlMajor.DataValueField = "Agency_id";
                this.ddlMajor.DataBind();

                this.ddlMajor.SelectedValue = major_id;

                this.major_id = this.ddlMajor.SelectedValue;

                ddlMajor_SelectedIndexChanged(null, null);

            }
            catch
            {
                JscriptMsg("数据出错", "", "Error");
            }
        }

        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str1 = " Agency_id=" + major_id + " AND Period_id=" + period_id + " AND UP_calculation_status > 4";
            var model1 = new BLL.CCOM.User_property().GetModelList(str1);
            if (model1.Count > 0)
            {
                hasAdmission = false;
            }
            this.btnSubmit.Enabled = hasAdmission;

            string order = "";
            string strWhere = "";

            order = "Transcript_score DESC, Transcript_AEE_ranking asc ,UP_CCOM_number asc";
            strWhere = CombSqlTxt(this.keywords);
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

            BLL.CCOM.View_TotalScore bll = new BLL.CCOM.View_TotalScore();

            //计算数量
            int totalCount = bll.GetRecordCount(_strWhere);
            //   txtSearchResult.Text = "本次命中" + totalCount.ToString() + "条";

            //绑定当页
            this.rptList.DataSource = bll.GetListByPage(_strWhere, _order, start_index, end_index);

            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("SelectAdmission.aspx", "fun_id={0}&page={1}&keywords={2}&major_id={3}", DESEncrypt.Encrypt(this.fun_id), "__id__",
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id));
            this.PageContent.InnerHtml = Utils.OutPageList(pageSize, page, totalCount, pageUrl, 8, true);
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            if (Tools.CheckParams(_keywords))
                return " 1=0 ";

            StringBuilder strTemp = new StringBuilder();

            //搜索关键字
            _keywords = _keywords.Trim();
            if (!_keywords.Equals(""))
            {
                strTemp.Append(" (User_realname like '%" + _keywords + "%'");
                strTemp.Append(" or UP_CCOM_number= '" + _keywords + "')");
            }
            else
            {
                strTemp.Append(" 1=1 ");
            }


            strTemp.Append(" AND Period_id=" + period_id + " AND Agency_id=" + major_id);

            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("SelectAdmission"), out _pagesize))
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
                    Utils.WriteCookie("SelectAdmission_page_size", _pagesize.ToString(), 43200);
                }
            }
            string keywords = MyRequest.GetQueryString("keywords");
            Response.Redirect(Utils.CombUrlTxt("SelectAdmission.aspx", "fun_id={0}&keywords={1}&major_id={2}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id)));
        }
        #endregion
        public string getAdmission(string _up_calculation_status)
        {
            int num = Convert.ToInt32(_up_calculation_status);
            if (num > 4)
            {
                return " 已录取";
            }
            else if (hasAdmission == false)
            {
                return " 不录取";
            }
            else
                return "";
                
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("SelectAdmission.aspx", "fun_id={0}&keywords={1}&major_id={2}", DESEncrypt.Encrypt(this.fun_id),
                this.txtKeywords.Text, DESEncrypt.Encrypt(this.major_id)));
        }

        protected void btnSelectAdmission_Click(object sender, EventArgs e)
        {
            string order = "Epss_score DESC, Epss_sequence DESC ,UP_CCOM_number asc";
            string strWhere = CombSqlTxt(this.keywords);

            try
            {
                //var bll = new BLL.CCOM.View_Preliminary_Score();
                //List<Model.CCOM.View_Preliminary_Score> modelList = bll.GetModelList(strWhere + " order by " + order);
                var bll = new BLL.CCOM.User_property();
                //增加只导出选择部分学生的功能
                string name = "";
                for (int i = 0; i < rptList.Items.Count; i++)
                {
                    CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                    if (cb.Checked == true)
                    {
                        HiddenField hf = (HiddenField)rptList.Items[i].FindControl("hidChkId");
                        string _user_id = hf.Value;

                        var model = new BLL.CCOM.User_property().GetModel(" User_id=" + _user_id + " AND Period_id=" + period_id);
                        model.UP_calculation_status = 5;
                        bll.Update(model);
                        name += model.UP_CCOM_number + ", ";
                    }
                }
                if (name == "")
                {
                    JscriptMsg("请勾选录取名单", "", "Error");
                    return;
                }
                JscriptMsg("已添加录取名单：" + name + "", "SelectAdmission.aspx?fun_id="+DESEncrypt.Encrypt(this.fun_id)+"&keywords="+this.txtKeywords.Text+"&major_id="+DESEncrypt.Encrypt(this.major_id), "Success");
            }
            catch
            {
                JscriptMsg("添加录取名单出错", "", "Success");
            }
        }

        protected void exportexcel_ServerClick(object sender, EventArgs e)
        {

            string str1 = " Agency_id=" + major_id + " AND Period_id=" + period_id + " AND UP_calculation_status > 4";
            var model1 = new BLL.CCOM.User_property().GetModelList(str1);
            if (model1.Count > 0)
            {
                hasAdmission = false;
            }
            this.btnSubmit.Enabled = hasAdmission;

            string order = "";
            string strWhere = "";

            order = "Transcript_score DESC, Transcript_AEE_ranking asc ,UP_CCOM_number asc";
            strWhere = CombSqlTxt(this.keywords);
            try
            {
                var bll = new BLL.CCOM.View_TotalScore();
                List<Model.CCOM.View_TotalScore> modelList = bll.GetModelList(strWhere + " order by " + order);

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
                column.ColumnName = "状态";
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
                column.ColumnName = "专业成绩";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "专业平均序";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "专业排名";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "文考结果";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "高考总分";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "高考过线";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "高考折合分";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "最终成绩";
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
                    dr["状态"] = getAdmission(modelList[i].UP_calculation_status.ToString());
                    dr["考生号"] = modelList[i].UP_CCOM_number;
                    dr["姓名"] = modelList[i].User_realname;
                    dr["专业成绩"] = ((decimal)modelList[i].Transcript_AEE_score).ToString("F2");
                    dr["专业平均序"] = ((decimal)modelList[i].Transcript_AEE_sequence).ToString("F2");
                    dr["专业排名"] = modelList[i].Transcript_AEE_ranking;

                    if (modelList[i].Transcript_type.ToString() != "" && modelList[i].Transcript_type.ToString() != null)
                    {
                        dr["文考结果"] = modelList[i].Transcript_type == 1 ? "备取" : (modelList[i].Transcript_type == 2 ? "合格" : "正取");
                    }
                    if (modelList[i].Transcript_CEE_score.ToString() != "" && modelList[i].Transcript_CEE_score.ToString() != null)
                    {
                        dr["高考总分"] = ((decimal)modelList[i].Transcript_CEE_score).ToString("#.##");
                    }
                    if (modelList[i].Transcript_passline.ToString() != "" && modelList[i].Transcript_passline.ToString() != null)
                    {
                        dr["高考过线"] = modelList[i].Transcript_passline == false ? "否" : "是";
                    }
                    if (modelList[i].Transcript_CEE_convert_score.ToString() != "" && modelList[i].Transcript_CEE_convert_score.ToString() != null)
                    {
                        dr["高考折合分"] = ((decimal)modelList[i].Transcript_CEE_convert_score).ToString("#.##");
                    }
                    if (modelList[i].Transcript_score.ToString() != "" && modelList[i].Transcript_score.ToString() != null)
                    {
                        dr["最终成绩"] = ((decimal)modelList[i].Transcript_score).ToString("#.##");
                    }

                    ds.Tables["Sheet1"].Rows.Add(dr);
                }

                DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), this.ddlMajor.SelectedItem.Text + "_考生最终录取名单情况_" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("导出考生最终录取名单情况出错", "", "Error");
            }
        }

    }
}