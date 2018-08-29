using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;

namespace university.Web.AdminMetro.CCOM.CEEManege
{
    public partial class FractionallineList : university.UI.ManagePage
    {
        protected int period_id = 0;
        public FractionallineList()
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

            if (!Page.IsPostBack)
            {
                RptBind();
            }
        }

        private void RptBind()
        {
            String _strWhere = " Period_id=" + period_id;
            String _order = " order by Fl_Province asc";
            var bll = new BLL.CCOM.Fractional_line();
            this.rptList.DataSource = bll.GetList(_strWhere + _order);
            this.rptList.DataBind();
        }

        public string GetProvinceName(int id)
        {
            var model = new BLL.CCOM.Province().GetModel(id);
            if (model != null)
                return model.Province_name;
            return "--";
        }
        protected void btnDeleteFenShuXian(object sender, EventArgs e)
        {
            try
            {
                int FenShuXianID = Convert.ToInt32(DESEncrypt.Decrypt((((LinkButton)sender).ToolTip)));
                new BLL.CCOM.Fractional_line().Delete(FenShuXianID);
                JscriptMsg("删除成功", "FractionallineList.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Success");
            }
            catch
            {
                JscriptMsg("删除失败", "FractionallineList.aspx?fun_id=" + DESEncrypt.Encrypt(this.fun_id), "Error");
            }
        }

        /*
        protected void btnCalculation_Click(object sender, EventArgs e)
        {
            try
            {
                new Calculation().calculateFenShuXian();
                JscriptMsg("计算分数线成功", "FractionallineList.aspx?fun_id=" + MyRequest.GetString("fun_id"), "Success");
            }
            catch
            {
                JscriptMsg("计算分数线失败，请重新尝试", "FractionallineList.aspx?fun_id=" + MyRequest.GetString("fun_id"), "Error");
            }
        }
         * */
        protected void exportexcel_ServerClick(object sender, EventArgs e)
        {
            String _strWhere = " Period_id=" + period_id;
            String _order = " order by Fl_Province asc";
            try
            {
                BLL.CCOM.Fractional_line bll = new BLL.CCOM.Fractional_line();

                List<Model.CCOM.Fractional_line> modelList = bll.GetModelList(_strWhere + _order);

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
                column.ColumnName = "省份";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "文科一本线";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "理科一本线";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "文科二本线";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "理科二本线";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "文科三本线";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "理科三本线";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "艺术类最低控制线（文科）";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "艺术类最低控制线（理科）";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "文科满分";
                ds.Tables["Sheet1"].Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "理科满分";
                ds.Tables["Sheet1"].Columns.Add(column);

                int count = modelList.Count;
                for (int i = 0, num = 1; i < count; i++, num++)
                {
                    dr = ds.Tables["Sheet1"].NewRow();
                    dr["序号"] = num.ToString();
                    dr["省份"] = GetProvinceName(modelList[i].Fl_Province);
                    dr["文科一本线"] = ((decimal)modelList[i].WenKeYiBen).ToString("F2");
                    dr["理科一本线"] = ((decimal)modelList[i].LiKeYiBen).ToString("F2");
                    dr["文科二本线"] = ((decimal)modelList[i].WenKeErBen).ToString("F2");
                    dr["理科二本线"] = ((decimal)modelList[i].LiKeErBen).ToString("F2");
                    dr["文科三本线"] = ((decimal)modelList[i].WenKeSanBen).ToString("F2");
                    dr["理科三本线"] = ((decimal)modelList[i].LiKeSanBen).ToString("F2");
                    dr["艺术类最低控制线（文科）"] = ((decimal)modelList[i].WenKeYiShuXian).ToString("F2");
                    dr["艺术类最低控制线（理科）"] = ((decimal)modelList[i].LiKeYiShuXian).ToString("F2");
                    dr["文科满分"] = ((decimal)modelList[i].WenKeZongFen).ToString("F2");
                    dr["理科满分"] = ((decimal)modelList[i].LiKeZongFen).ToString("F2");

                    ds.Tables["Sheet1"].Rows.Add(dr);
                }

                DataToExcel.ExportToExcel(ds, Server.MapPath("/upload/excel/"), "高考分数线_" + DateTime.Now.ToFileTime().ToString() + ".xlsx", this.Page);
            }
            catch
            {
                JscriptMsg("获取高考分数线出错", "", "Error");
            }
        }
    }
}