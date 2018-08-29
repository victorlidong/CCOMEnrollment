using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.Security;

namespace university.Common
{
    
    /// <summary>
    ///MSOffice 的摘要说明
    /// </summary>
    public class DataToExcel
    {
        public DataToExcel()
        { }
        /// <summary>
        /// 导出DataSet数据到Excel
        /// </summary>
        /// <param name="dataSet">数据源（要导出的数据源，类型应是DataSet）</param>
        /// <param name="filePath">保存文件的路径 例：'C：\\Files\\'</param>
        /// <param name="fileName">要保存的文件名，需要加扩展有.xls 例：'Test.xls'</param>
        public static void ExportToExcel(DataSet dataSet, string filePath, string fileName, Page page)
        {
            string SavaFilesPath = filePath + fileName;
            if (dataSet.Tables.Count == 0)
            {
                throw new Exception("DataSet中没有任何可导出的表。");
            }
            //建立一个Excel进程 Application
            Microsoft.Office.Interop.Excel.Application excelApplication = new Microsoft.Office.Interop.Excel.Application();
            //默认值为 True。如果不想在宏运行时被无穷无尽的提示和警告消息所困扰，请将本属性设置为 False；这样每次出现需用户应答的消息时，Microsoft Excel
            // 将选择默认应答。
            //如果将该属性设置为 False，则在代码运行结束后，Micorosoft Excel 将该属性设置为 True，除非正运行交叉处理代码。
            //如果使用工作簿的 SaveAs 方法覆盖现有文件，“覆盖”警告默认为“No”，当 DisplayAlerts 属性值设置为 True 时，Excel 选择“Yes”。
            excelApplication.DisplayAlerts = false;
            //  建立或打开一个 Workbook对象生成新Workbook
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApplication.Workbooks.Add(Missing.Value);
            
            //删除原有的sheet
            while (workbook.Worksheets.Count > 1)
            {
                ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Delete();
            }

            bool isFrist = true;
            foreach (DataTable dt in dataSet.Tables)
            {
                Microsoft.Office.Interop.Excel.Worksheet lastWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(workbook.Worksheets.Count);

                Microsoft.Office.Interop.Excel.Worksheet newSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.Add(Type.Missing, lastWorksheet, Type.Missing, Type.Missing);

                if (isFrist == true)
                {
                    isFrist = false;
                    ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Delete();
                }

                //设置默认选中是第一个Sheet 类似于Select();  
                newSheet.Name = dt.TableName;
                ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Activate();

                //获取DataSet的列名，并创建标题行
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    newSheet.Cells[1, col + 1] = dt.Columns[col].ColumnName;
                    //Microsoft.Office.Interop.Excel.Range targetRange = excelApplication.Range["A1"];
                    newSheet.Range[newSheet.Cells[1, col + 1], newSheet.Cells[1, dt.Columns.Count]].Columns.AutoFit();
                    //newSheet
                    //Microsoft.Office.Interop.Excel.Range firstColumn = newSheet.get_Range(dt.Columns[col].ColumnName);
                    ////Range firstColumn = (Range)xlWorkSheet.Columns[0];
                    //firstColumn.EntireColumn.AutoFit();
                }
                //通过循环把数据添加到Sheet里面
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        newSheet.Cells[row + 2, col + 1] = dt.Rows[row][col].ToString();
                    }
                }
                Microsoft.Office.Interop.Excel.Range allColumn = newSheet.Columns;
                allColumn.AutoFit();
                allColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            }
            
            //删除原来的空Sheet
            //((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Delete();
           // ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Delete();
           // ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Delete();
            //设置默认选中是第一个Sheet 类似于Select();
            ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1)).Activate();
            try
            {
                workbook.Close(true, SavaFilesPath, System.Reflection.Missing.Value);
            }
            catch (Exception e)
            {
                throw e;
            }
            UploadExcel(SavaFilesPath, page, true);
            excelApplication.Quit();
            KillExcel();
        }
        /// <summary>
        /// 用来结束所以的创建的Excel进程
        /// </summary>
        private static void KillExcel()
        {
            //Process 提供对本地和远程进程的访问并使您能够启动和停止本地系统进程。
            //Process.GetProcessesByName() 获取进程名为Excel的进程
            Process[] excelProcesses = Process.GetProcessesByName("EXCEL");
            DateTime startTime = new DateTime();
            int processId = 0;
            for (int i = 0; i < excelProcesses.Length; i++)
            {
                if (startTime < excelProcesses[i].StartTime)
                {
                    startTime = excelProcesses[i].StartTime;
                    processId = i;
                }
            }
            //杀掉进程
            if (excelProcesses[processId].HasExited == false)
            {
                excelProcesses[processId].Kill();
            }
        }
        /// <summary>
        /// 提供下载
        /// </summary>
        /// <param name="path"></param>
        /// <param name="page"></param>
        ///  <param name="isDelete"></param>
        private static void UploadExcel(string path, System.Web.UI.Page page, bool isDelete)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            page.Response.Clear();
            page.Response.Charset = "GB2312";
            page.Response.ContentEncoding = System.Text.Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名
            page.Response.AddHeader("Content-Disposition", "attachment; filename=" + page.Server.UrlEncode(file.Name));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度
            page.Response.AddHeader("Content-Length", file.Length.ToString());
            // 指定返回的是一个不能被客户端读取的流，必须被下载
            page.Response.ContentType = "application/ms-excel";
            // 把文件流发送到客户端
            page.Response.WriteFile(file.FullName);
            page.Response.Flush();
            if (isDelete)
            {
                System.IO.File.Delete(path);
            }
            // 停止页面的执行
            page.Response.End();
        }

    }
}
