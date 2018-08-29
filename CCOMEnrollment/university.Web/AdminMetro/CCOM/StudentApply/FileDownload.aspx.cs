using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using university.Common;
using System.Configuration;
using System.Data;
using System.IO; 

namespace university.Web.AdminMetro.CCOM.StudentApply
{
    public partial class FileDownload : university.UI.ManagePage
    {
        protected string FileName;
        protected string FilePath;

        public FileDownload()
        {
            //this.checkFunID = false;

            this.checkFunID = true;
            this.checkUserStaus = false;
            this.checkSchoolLevelAdminUser = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            FileName = MyRequest.GetQueryString("filename");
            FilePath = MyRequest.GetQueryString("filepath");
            string str = DoDownLoad();
            if (str == "")
            {
                Response.Redirect(ViewState["retu"].ToString());   
                //ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                this.warning.InnerText = str;
            }
        }

        protected string DoDownLoad() {
            string str="";

            // 判断传输地址是否为空    
            if (FilePath == "")
            {
                // 提示“该文件暂不提供下载”    
               return "该文件暂不提供下载！";
            }
            // 判断获取的是否为地址，而非文件名    
            if (FilePath.IndexOf("\\") > -1)
            {
                // 获取文件名    
                FileName = FilePath.Substring(FilePath.LastIndexOf("\\") + 1);
            }
            else
            {
                // url为文件名时，直接获取文件名    
                FileName = FilePath;
            }
            try
            {
                // 以字符流的方式下载文件    
                FileStream fileStream = new FileStream(@FilePath, FileMode.Open);
                byte[] bytes = new byte[(int)fileStream.Length];
                fileStream.Read(bytes, 0, bytes.Length);
                fileStream.Close();
                Response.ContentType = "application/octet-stream";

                // 通知浏览器下载   
                Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            catch(Exception e)
            {
                str = e.Message;
            }
            return str;
        }
        
    }
}