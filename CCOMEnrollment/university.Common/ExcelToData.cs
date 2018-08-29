using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace university.Common
{
    public class ExcelToData
    {
        public DataSet GetExcelData(string filePath)
        {
            DataSet ds = new DataSet();
            if (filePath != null)
            {
                try
                {
                    string connStr07 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1'";
                    string queryStr = "SELECT * FROM [Sheet1$]";
                    OleDbConnection conn07 = new OleDbConnection(connStr07);
                    string fileExt = System.IO.Path.GetExtension(filePath);
                    if (fileExt == ".xls" || fileExt == ".xlsx")
                    {
                        OleDbDataAdapter myAdapter = new OleDbDataAdapter(queryStr, conn07);
                        myAdapter.Fill(ds);
                        conn07.Close();
                    }
                    else
                    {
                        // lblMessage.Text = "The file is not exist!";
                    }
                }
                catch { }
            }
            return ds;
        }
    }
}
