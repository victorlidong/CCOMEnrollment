using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.xmp.impl;
using Utils = university.Common.Utils;

namespace university.Web.AdminMetro.OnlineView
{
    public class OnlineViewHelper
    {

        /// <summary>
        /// 判断是否为支持的文件类型，支持txt、pdf、img、office
        /// </summary>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public static bool IsSupportFile(String fileExt )
        {
            if (Utils.IsImgExt(fileExt) || Utils.IsOfficeExt(fileExt) || Utils.IsPdfExt(fileExt) ||
                Utils.IsTxtExt(fileExt))
                return true;
            return false;
        }

        /// <summary>
        ///获取文件在线预览的跳转url；若不支持的预览文件类型或文件不存在，则返回空串
        /// </summary>
        /// <param name="viewFileRelativePath">需要在线预览的文件的相对路径，必须以"/"开头</param>
        /// <param name="fileName">文件名（供预览显示）</param>
        /// <returns></returns>
        public static String GetOnlineViewUrl(String viewFileRelativePath,String fileName)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(viewFileRelativePath)))
            {
                var fileExt = viewFileRelativePath.Substring(viewFileRelativePath.LastIndexOf('.') + 1);
                if (IsSupportFile(fileExt))
                {
                    //预览链接   
                    var url = "/AdminMetro/OnlineView/OnlineView.aspx?src=" +
                              HttpContext.Current.Server.UrlEncode(viewFileRelativePath);
                    if (fileName != "")
                    {
                        url += "&name=" + HttpContext.Current.Server.UrlEncode(fileName);
                    }
                    return url;
                }
            }
            return "";
        }

        /// <summary>
        /// 获取文件在线预览的链接html标签 ; 若不支持的预览文件类型或文件不存在，则返回空串
        /// </summary>
        /// <param name="viewFileRelativePath">需要在线预览的文件的相对路径，必须以"/"开头</param>
        /// <param name="fileName">文件名（供预览显示）</param>
        /// <param name="linkText">跳转链接显示的文字</param>
        /// <returns></returns>
        public static String GetOnlineViewWrapLink(String viewFileRelativePath, String fileName,String linkText)
        {
            var url = GetOnlineViewUrl(viewFileRelativePath, fileName);
            if (url != "")
            {
                var aLink = "<a href='" + url + "' target='_blank' class='view-link'>" + linkText + "</a>";
                return aLink;
            }
            return "";
        }


        /// <summary>
        ///  获取文件在线预览的链接html标签,默认标签文字为"[预览]"；若不支持的预览文件类型或文件不存在，则返回空串
        /// </summary>
        /// <param name="viewFileRelativePath">需要在线预览的文件的相对路径，必须以"/"开头</param>
        /// <param name="fileName">文件名（供预览显示）</param>
        /// <returns></returns>
        public static String GetOnlineViewWrapLink(String viewFileRelativePath, String fileName)
        {
            return GetOnlineViewWrapLink(viewFileRelativePath, fileName,"[预览]");
        }

        /// <summary>
        /// 获取微软平台进行Office文档在线查看的服务Url
        /// </summary>
        /// <returns></returns>
        public static String GetMsOnlineOfficeViewServiceUrl()
        {
             return ConfigurationManager.AppSettings["MsOfficeViewService"].ToString();
        }
        
    }
}