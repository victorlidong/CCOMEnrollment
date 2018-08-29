using System;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace university.Common
{
    /// <summary>
    /// 批量下载类
    /// 提供操作空间文件夹（在该文件夹中创建临时文件夹，将文件拷贝到该文件夹后，压缩）
    /// </summary>
    public class BatchDownLoad
    {
        //多文件创建RAR，factoryFolder提供操作空间的文件夹，fileCollection存储文件相对路径，rarFullName为RAR输出路径,renamed是否重命名，fileNewNames为文件集合中的新文件名
        //返回空串成功
        public static string MultiFileCreateRAR(string factoryFolder,List<string> fileCollection,string rarFullName,bool renamed,List<string> fileNewNames)
        {
            if (factoryFolder == "")
                factoryFolder = DataDic.Batch_Path;
            string tempFolderName = DateTime.Now.ToString("yyMMddhhmmss")+Utils.Number(3);//临时文件夹名字
            string tempFolder = factoryFolder + tempFolderName+"/";
            string tempFolderPhisical="";
            //创建临时文件夹
            if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(tempFolder)))
            {
                try
                {
                    tempFolderPhisical=System.Web.HttpContext.Current.Server.MapPath(tempFolder);
                    Directory.CreateDirectory(tempFolderPhisical);
                }catch
                {
                    return "创建临时文件夹出错！";
                }
            }
            int fCnt = 0;
            //将文件拷贝到临时文件夹
            for (int i = 0; i < fileCollection.Count; i++)
            {
                //文件物理路径
                string newFile=tempFolder+Path.GetFileName(fileCollection[i]);
                if (renamed)
                {
                    newFile = tempFolder + fileNewNames[i];
                }
                string oldFilePhisicalPath = System.Web.HttpContext.Current.Server.MapPath(fileCollection[i]);
                string newFilePhisicalPath=System.Web.HttpContext.Current.Server.MapPath(newFile);
                if (File.Exists(oldFilePhisicalPath))
                {
                    try
                    {
                        File.Copy(oldFilePhisicalPath, newFilePhisicalPath);
                        fCnt++;
                    }
                    catch
                    {
                         //return "文件拷贝出错！";
                        continue;
                    }
                }
            }
            //
            if(fCnt==0)
            {
                return "没有找到下载文件！";
            }
            string rarOutPath = System.Web.HttpContext.Current.Server.MapPath(rarFullName);
            //创建压缩文件
            try
            {
                FastZip fastZip = new FastZip();
                fastZip.CreateZip(rarOutPath, tempFolderPhisical, false, "");
            }catch{
                return "创建压缩文件失败！";
            }
            //删除临时文件夹
            try
            {
                Directory.Delete(tempFolderPhisical, true);
            }
            catch
            {
                return "删除临时文件夹失败！";
            }
            //判断压缩文件是否存在
            FileInfo rarFile = new FileInfo(rarOutPath);
            if (rarFile.Exists)
            {
                return "";
            }
            else
            {
                return "找不到创建的压缩文件！";
            }
        }
    }
}