﻿using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using university.Common;
using org.in2bits.MyXls;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;// For COMException 
using log4net;

namespace university.Web.AdminMetro.CCOM.ResManage
{
    public partial class RoomBatchAdd : university.UI.ManagePage
    {
        public int uoid = 0;
        public RoomBatchAdd()
        {
            //this.checkFunID = true;
            //this.fun_id = MyRequest.GetQueryString("fun_id");
            //this.adminfuncition = true;

            this.checkFunID = false;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //BindDataItems();
            }
        }

        //动态生成Excel
        protected void prodExcel_Click(object sender, EventArgs e)
        {
            WriteXls();
        }

        public void WriteXls()
        {
            bool res = true;
            Application excel = new Application();
            try
            {
                excel.Workbooks.Add(true);
                excel.Visible = false;
                int col = 1;
                SetCol("所在楼", 1, "", col++, excel);
                SetCol("楼层", 1, "", col++, excel);
                SetCol("房间号", 1, "", col++, excel);
                SetCol("容量", 1, "", col++, excel);
                SetCol("备注", 0, "", col++, excel);
                string xlsName = "考场资源模板";
                xlsName = xlsName + ".xlsx";
                string serverUrl = Server.MapPath("~/");//serverUrl + xlsName
                //excel.ActiveWorkbook.SaveAs(serverUrl + xlsName,Excel.XlFileFormat.xlExcel8);
                excel.ActiveWorkbook.SaveCopyAs(serverUrl + xlsName);
                FileStream myFileStream = new FileStream(serverUrl + xlsName, FileMode.Open);

                long fileSize = myFileStream.Length;
                byte[] buffer = new byte[(int)fileSize];
                myFileStream.Read(buffer, 0, (int)fileSize);
                myFileStream.Close();
                HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.Charset = "UTF-8";
                response.ContentType = "application/vnd.ms-excel";

                response.AppendHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(xlsName, Encoding.UTF8).ToString()));
                response.BinaryWrite(buffer);
                response.Flush();
                response.Close();

                File.Delete(serverUrl + xlsName);
            }
            catch (Exception ex)
            {
                LOGGER.Debug(ex.Message, ex);
                res = false;
            }
            finally
            {
                excel.DisplayAlerts = false;
                excel.ActiveWorkbook.Application.DisplayAlerts = false;
                excel.Quit();
                excel = null;//这一句是非常重要的，否则Excel对象不能从内存中退出
            }
            if (!res)
            {
                string msbox = "parent.f_errorTab(\"错误提示\", \"对不起，导出出错，请重新打开重试！\");";
                Response.Write("<script type=\"text/javascript\">" + msbox + "</script>");
                Response.End();
            }
        }

        protected void SetCol(string name,int required, string check, int col, Application excel)
        {
            excel.Cells[1, col] = name;
            excel.Range[excel.Cells[1, col], excel.Cells[1, col]].Font.Bold = true;                //设置字体加粗
            if (required == 1)
                excel.Range[excel.Cells[1, col], excel.Cells[1, col]].Font.ColorIndex = 3; //红色
            else
                excel.Range[excel.Cells[1, col], excel.Cells[1, col]].Font.ColorIndex = 1;
            if (check == "")
                return;
            if (check.Split('|')[0] == "select" && check.Split('|')[1].Length > 0)
            {
                Range range = excel.Range[excel.Cells[2, col], excel.Cells[9999, col]];
                string str = check.Split('|')[1].Replace(';', ',');
                range.Validation.Add(Excel.XlDVType.xlValidateList, Excel.XlDVAlertStyle.xlValidAlertStop, Type.Missing, str, Type.Missing);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

            string result = "";
            if (this.txtUserUpload.PostedFile.FileName == "")
            {
                JscriptMsg("请选择上传文件", "", "Error");
                return;
            }
            DataSet ds = new DataSet();
            string path = "../../../upload/excel/";

            #region 解决360获取绝对路径导致出错的问题
            string AbsolutePath = this.txtUserUpload.PostedFile.FileName;
            string[] pathList = new string[] { };

            pathList = AbsolutePath.Split('\\');
            AbsolutePath = pathList[pathList.Length - 1];
            #endregion

            string fileName = DateTime.Now.ToFileTime() + "_" + AbsolutePath;
            string FexName = fileName.Substring(fileName.LastIndexOf(".") + 1);
            if (FexName != "xls" && FexName != "xlsx")
            {
                JscriptMsg("请上传Excel文件", "", "Error");
                return;
            }

            string filePath = Server.MapPath(path + fileName);

            this.txtUserUpload.SaveAs(filePath);
            int success = 0, error = 0;
            try
            {
                var excel = new Common.ExcelToData();
                ds = excel.GetExcelData(filePath);
                result = ImportDataItem(ds, ref success, ref error);
            }
            catch (Exception ex)
            {
                LOGGER.Debug(ex.Message, ex);
                result = "导入发生异常情况，请联系客服";
            }
            string divinfo = "<div class=\"alert alert-block alert-info fade in\">";
            divinfo += "<button data-dismiss=\"alert\" class=\"close\" type=\"button\">×</button>";
            divinfo += "<h4 class=\"alert-heading\">导入结果</h4>";
            divinfo += "<p>";
            if (success != ds.Tables[0].DefaultView.Count)
                divinfo += "部分导入成功!<br>";
            else
                divinfo += "全部导入成功!<br>";
            divinfo += "*共有" + ds.Tables[0].DefaultView.Count + "条数据，成功" + success + "条，失败" + error + "条；<br/>";
            if (result != "")
                divinfo += "详细信息如下:<br><font color='red'>" + result;
            divinfo += "</font></p>";
            divinfo += "</div>";
            this.lblError.Text = divinfo;
            File.Delete(filePath);

        }

        protected string ImportDataItem(DataSet ds, ref int success, ref int error)//基础数据
        {
            string result = "";
            BLL.CCOM.Examination_room bll = new BLL.CCOM.Examination_room();
            Model.CCOM.Examination_room model = new Model.CCOM.Examination_room();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string checkmsg = null;
                string building = ds.Tables[0].Rows[i]["所在楼"].ToString().Trim();
                if (!ValidDFValue(building, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，所在楼名" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (building != "")
                {
                    model.Er_building = building;
                }

                string floor = ds.Tables[0].Rows[i]["楼层"].ToString().Trim();
                int floorInt;
                try
                {
                    floorInt = int.Parse(floor);
                }
                catch
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，所在楼层填写需要为整数<br/>";
                    error++;
                    continue;
                }
                if (!ValidDFValue(floor, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，所在楼层" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (floor != "")
                {
                    model.Er_floor = floorInt;
                }

                string room = ds.Tables[0].Rows[i]["房间号"].ToString().Trim();
                if (!ValidDFValue(room, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，所在房间号" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (room != "")
                {
                    model.Er_room = room;
                }

                string cap = ds.Tables[0].Rows[i]["容量"].ToString().Trim();
                int capInt;
                try
                {
                    capInt = int.Parse(cap);
                }
                catch
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，考场容量填写需要为整数<br/>";
                    error++;
                    continue;
                }
                if (!ValidDFValue(cap, true, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，考场容量" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (cap != "")
                {
                    model.Er_capacity = capInt;
                }

                string remark = ds.Tables[0].Rows[i]["备注"].ToString().Trim();
                if (!ValidDFValue(remark, false, "", ref checkmsg))
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新失败，备注" + checkmsg + "<br/>";
                    error++;
                    continue;
                }
                else if (remark != "")
                {
                    model.Er_remark = remark;
                }
                
                if (bll.Add(model) == 0)
                {
                    result += "×第" + (i + 1).ToString() + "行数据更新异常<br/>";
                    error++;
                    continue;
                }
                else
                {
                    success++;
                }
            }
            return result;
        }

        protected bool ValidDFValue(string value, bool required, string check, ref string msg)
        {
            value = value.Trim();
            if (Tools.CheckParams(value))
            {
                msg = "存在非法字符";
                return false;
            }
            if (value == "" && required)
            {
                msg = "必填字段不能为空";
                return false;
            }
            if (check.Split('|')[0] == "select" && value != "")
            {
                string[] options = check.Split('|')[1].Split(',');
                if (!options.ToList().Contains(value))
                {
                    msg = "信息不在给定范围中";
                    return false;
                }
            }
            msg = "";
            return true;
        }

    }
}