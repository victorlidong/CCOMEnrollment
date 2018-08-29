using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;
using System.Net.Mail;

namespace university.Common
{
    public class ImgUpload
    {
        #region 图片上传流程封装
        /// <summary>
        /// 图片上传处理
        /// </summary>
        /// <param name="fromPath">缓存地址</param>
        /// <param name="toPath">目标地址所在文件夹</param>
        /// <param name="oldPath">需要替换的文件地址，新增该参数为“”</param>
        public static string imgUpload(string fromPath, string toPath, string oldPath)
        {
            string res = "";
            try
            {
                //创建文件夹
                FileOperate.FolderCreate(Utils.GetMapPath(toPath));

                //图片处理
                String toFilePath = toPath + DateTime.Now.Ticks.ToString() +
                                    FileOperate.GetPostfixStr(fromPath);
                FileOperate.FileMove(HttpContext.Current.Server.MapPath(fromPath), HttpContext.Current.Server.MapPath(toFilePath));
                toPath = toFilePath;
                res = toPath;
                if (oldPath != null && oldPath != "") {
                    if (File.Exists(oldPath))
                    {
                        FileInfo fi = new FileInfo(oldPath);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(oldPath);
                    }
                }
            }
            catch (Exception ee)
            {
                res = "";
            }
            finally
            {

            }
            return res;
        }
        #endregion
    }
}
