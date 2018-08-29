using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;

namespace university.Common
{
    /// <summary>
    /// WordExtrator：从word文档中抽取出html内容，以显示在富文本编辑器中
    /// </summary>
    public class WordExtrator
    {
        public WordExtrator()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 从word(.doc|.docx)文件中抽取出html内容，word中图片存储在word文件所在目录
        /// Trap: word转化过程有可能出现异常
        /// FIX:解决转化后，图片在IE显示水平居中问题；word图片尺寸调整
        /// </summary>
        /// <param name="docFileName">word文件的相对路径</param>
        /// <param name="deleteTmpFile">是否删除中间文件</param>
        /// <returns>抽取的html String</returns>
        public String GetHtmlFromWord(String docFileName, bool deleteTmpFile)
        {
            String htmlFilePath = WordToHtml(docFileName);
            String htmlStr = GetHtmlFromHtmlFile(htmlFilePath);
            String specificHtml = findUsedFromHtml(htmlStr, docFileName);
            if (deleteTmpFile)
                DeleteTmpHtmlFile(docFileName);
            return specificHtml;
        }

        #region 导入word到编辑器

        /// <summary>
        /// word转成html
        /// </summary>
        /// <param name="wordFileName">word文档的相对路径</param>
        /// <returns>转化后的Html文档的物理路径</returns>
        private string WordToHtml(object wordFileName)
        {
            wordFileName = HttpContext.Current.Server.MapPath(wordFileName.ToString());
            //在此处放置用户代码以初始化页面
            Microsoft.Office.Interop.Word.ApplicationClass word = new Microsoft.Office.Interop.Word.ApplicationClass();
            Type wordType = word.GetType();
           Microsoft.Office.Interop.Word.Documents docs = word.Documents;
            //打开文件
            Type docsType = docs.GetType();
            Microsoft.Office.Interop.Word.Document doc =
                (Microsoft.Office.Interop.Word.Document) docsType.InvokeMember("Open",
                   System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] {wordFileName, true, true});
            //转换格式，另存为
            Type docType = doc.GetType();
            string wordSaveFileName = wordFileName.ToString();
            string strSaveFileName = wordSaveFileName.Substring(0, wordSaveFileName.LastIndexOf('.')) + ".html";
            object saveFileName = (object) strSaveFileName;
            //下面是Microsoft Word 9 Object Library的写法，如果是10，可能写成：
            /*
        docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
         null, doc, new object[]{saveFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatFilteredHTML});
        */
            ///其它格式：
            ///wdFormatHTML
            ///wdFormatDocument
            ///wdFormatDOSText
            ///wdFormatDOSTextLineBreaks
            ///wdFormatEncodedText
            ///wdFormatRTF
            ///wdFormatTemplate
            ///wdFormatText
            ///wdFormatTextLineBreaks
            ///wdFormatUnicodeText
            docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod,
                null, doc, new object[] {saveFileName, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML});

            docType.InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod,
                null, doc, null);
            //退出 Word
            wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod,
                null, word, null);
            return saveFileName.ToString();
        }

        /// <summary>
        /// 读取html文件，返回字符串
        /// </summary>
        /// <param name="strHtmlFileName">html文件物理路径</param>
        /// <returns>html文件中的html String</returns>
        private string GetHtmlFromHtmlFile(string strHtmlFileName)
        {
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("gb2312");
            StreamReader sr = new StreamReader(strHtmlFileName, encoding);
            string str = sr.ReadToEnd();
            sr.Close();
            return str;
        }

        /// <summary>
        /// 抽取特定的html String
        /// </summary>
        /// <param name="strHtml">html String</param>
        /// <param name="strDocFileName">doc文件的相对路径</param>
        /// <returns>抽取的内容</returns>
        private String findUsedFromHtml(string strHtml, string strDocFileName)
        {
            string strStyle;
            string strBody;
            // stytle 部分
            int index = 0;
            int intStyleStart = 0;
            int intStyleEnd = 0;
            while (index < strHtml.Length)
            {
                int intStyleStartTmp = strHtml.IndexOf("<style>", index);
                if (intStyleStartTmp == -1)
                {
                    break;
                }
                int intContentStart = strHtml.IndexOf("<!--", intStyleStartTmp);
                if (intContentStart - intStyleStartTmp == 9)
                {
                    intStyleStart = intStyleStartTmp;
                    break;
                }
                else
                {
                    index = intStyleStartTmp + 7;
                }
            }
            index = 0;
            while (index < strHtml.Length)
            {
                int intContentEndTmp = strHtml.IndexOf("-->", index);
                if (intContentEndTmp == -1)
                {
                    break;
                }
                int intStyleEndTmp = strHtml.IndexOf("</style>", intContentEndTmp);
                if (intStyleEndTmp - intContentEndTmp == 5)
                {
                    intStyleEnd = intStyleEndTmp;
                    break;
                }
                else
                {
                    index = intContentEndTmp + 4;
                }
            }
            strStyle = strHtml.Substring(intStyleStart, intStyleEnd - intStyleStart + 8);
            // Body部分
            int bodyStart = strHtml.IndexOf("<body");
            int bodyEnd = strHtml.IndexOf("</body>");
            strBody = strHtml.Substring(bodyStart, bodyEnd - bodyStart + 7);
            //替换图片地址
            String dirPath = System.IO.Path.GetDirectoryName(strDocFileName).Replace("\\","/"); //末尾不带"/"
            String docNameNoEx = System.IO.Path.GetFileNameWithoutExtension(strDocFileName);
            String docToHtmlDirName = docNameNoEx + ".files";
            //所有word文档中的图片
            var imgFiles = Directory.GetFiles(HttpContext.Current.Server.MapPath(dirPath + "/" + docToHtmlDirName),
                "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".bmp") || s.EndsWith(".gif"));
            foreach (var img in imgFiles)
            {
                String oldName = Path.GetFileName(img);
                String newName = Utils.GetRamCode() + Path.GetExtension(img);
                
                System.IO.File.Move(img, HttpContext.Current.Server.MapPath(dirPath + "/" + newName));
                //检查有该路径是否就创建
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(dirPath + "/web/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dirPath + "/web/"));
                }
                //复制原图至web文件夹
                System.IO.File.Copy(HttpContext.Current.Server.MapPath(dirPath + "/" + newName), HttpContext.Current.Server.MapPath(dirPath + "/web/" + newName));
                //缩原图（缩略图）
                Common.Thumbnail.MakeThumbnailImage(HttpContext.Current.Server.MapPath(dirPath + "/" + newName), HttpContext.Current.Server.MapPath(dirPath + "/small" + newName), 600, 0, "W", true);
                System.IO.File.Delete(HttpContext.Current.Server.MapPath(dirPath + "/" + newName));
                strBody = strBody.Replace(docToHtmlDirName + "/" + oldName, dirPath + "/small" + newName);
            }
            strBody = strBody.Replace("v:imagedata", "img ");
            strBody = strBody.Replace("</v:imagedata>", "");
            //去掉body标签
            strBody = strBody.Replace("<body", "<div");
            strBody = strBody.Replace("</body>", "</div>");
            //return strStyle + strBody;
            return  strBody;
        }

        /// <summary>
        /// 根据doc文件相对路径，删除中间过程产生的html文件及文件夹
        /// </summary>
        /// <param name="strDocFileName">doc文件相对路径</param>
        private void DeleteTmpHtmlFile(String strDocFileName)
        {
            String docFileNameSuffix = strDocFileName.Substring(0, strDocFileName.LastIndexOf('.'));
            string htmlFileName = docFileNameSuffix + ".html";
            string htmlFileDir = docFileNameSuffix + ".files";
            try
            {
                File.Delete(HttpContext.Current.Server.MapPath(strDocFileName));
                File.Delete(HttpContext.Current.Server.MapPath(htmlFileName));
                Directory.Delete(HttpContext.Current.Server.MapPath(htmlFileDir), true);
            }
            catch (Exception ex)
            {
                //log
            }
        }

        #endregion
    }
}