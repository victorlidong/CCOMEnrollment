using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System;

namespace university.Common
{
    public class Tools
    {
        //防sql注入
        public static bool CheckParams(string res)
        {
            string[] str = new string[35];
            str[0] = "net user";
            str[1] = "xp_cmdshell";
            str[2] = "/add";
            str[3] = "exec%20master.dbo.xp_cmdshell";
            str[4] = "net localgroup administrators";
            str[5] = " select ";
            str[6] = " count ";
            str[7] = " asc ";
            str[8] = " char ";
            str[9] = " mid ";
            str[10] = "''";
            str[11] = "'";
            str[12] = "'";
            str[13] = "insert ";
            str[14] = "delete ";
            str[15] = "drop ";
            str[16] = "truncate";
            str[17] = "from ";
            str[18] = "%";
            str[19] = " and ";
            str[20] = "script";
            str[21] = "alert";
            str[22] = "javascript";
            str[23] = "VBscript";
            str[24] = "document";
            str[25] = "window.location.href";
            str[26] = "window.open";
            str[27] = "getElementById";
            str[28] = "getElementsByName";
            str[29] = "getElementsByTagName";
            str[30]="<";
            str[31]=">";
            str[32]="*";
            str[33] = "\\";
            str[34] = "&";

            res = res.ToLower();
            int no = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (res.Contains(str[i]))
                {
                    no = 1;
                    break;
                }

            }
            if (no == 1)
            {
                return true;//有问题
            }
            else
                return false;

        }

        #region 字符数组去重

        public static string[] RemoveDup(string[] str)
        {
            List<string> listString = new List<string>();
            foreach (string eachString in str)
            {
                if (!listString.Contains(eachString))
                    listString.Add(eachString);
            }
            return listString.ToArray();
        }

        public static List<string> RemoveDup(List<string> str)
        {
            List<string> listString = new List<string>();
            foreach (string eachString in str)
            {
                if (!listString.Contains(eachString))
                    listString.Add(eachString);
            }
            return listString;
        }
        #endregion

        /// <summary>
        /// 过滤标记
        /// </summary>
        /// <param name="NoHTML">包括HTML，脚本，数据库关键字，特殊字符的源码 </param>
        /// <returns>已经去除标记后的文字</returns>
        public static string NoHtml(string Htmlstring)
        {
            if (Htmlstring == null)
            {
                return "";
            }
            else
            {
                //删除脚本
                Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                //删除HTML
                Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);

                //删除与数据库相关的词
                Htmlstring = Regex.Replace(Htmlstring, "select", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "insert", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete from", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "count''", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop table", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "truncate", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "asc", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "mid", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "char", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "exec master", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net localgroup administrators", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "and", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net user", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "or", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net", "", RegexOptions.IgnoreCase);
                //Htmlstring = Regex.Replace(Htmlstring, "*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "-", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "script", "", RegexOptions.IgnoreCase);

                //特殊的字符
                Htmlstring = Htmlstring.Replace("<", "");
                Htmlstring = Htmlstring.Replace(">", "");
                Htmlstring = Htmlstring.Replace("*", "＊");
                Htmlstring = Htmlstring.Replace("-", "");
                Htmlstring = Htmlstring.Replace("?", "？");
                Htmlstring = Htmlstring.Replace("'", "''");
                Htmlstring = Htmlstring.Replace(",", "，");
                Htmlstring = Htmlstring.Replace("/", "");
                Htmlstring = Htmlstring.Replace(";", "；");
                Htmlstring = Htmlstring.Replace("*/", "");
                Htmlstring = Htmlstring.Replace("\r\n", "");

                Htmlstring = Htmlstring.Replace("=", "");
                Htmlstring = Htmlstring.Replace("\"", "”");
                Htmlstring = Htmlstring.Replace("&", "");
                Htmlstring = Htmlstring.Replace("(", "）");
                Htmlstring = Htmlstring.Replace(")", "）");
                Htmlstring = Htmlstring.Replace("xp_", "x p_");
                Htmlstring = Htmlstring.Replace("sp_", "s p_");
                Htmlstring = Htmlstring.Replace("0x", "0 x");
                Htmlstring = Htmlstring.Replace("$", "￥");
                Htmlstring = Htmlstring.Replace("%", "％");

                Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
                return Htmlstring;
            }
        }

    }
}
