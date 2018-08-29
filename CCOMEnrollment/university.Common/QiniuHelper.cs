using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Qiniu.RPC;
using Qiniu.RS;

namespace university.Common
{
    public class QiniuHelper
    {
        private static string QINIU_ACCESS_KEY = ConfigurationManager.AppSettings["QiniuAccessKey"].ToString();
        private static string QINIU_SECRET_KEY = ConfigurationManager.AppSettings["QiniuSecretKey"].ToString();

        public static bool Delete(string bucket, string key)
        {
            Qiniu.Conf.Config.ACCESS_KEY = QINIU_ACCESS_KEY;
            Qiniu.Conf.Config.SECRET_KEY = QINIU_SECRET_KEY;

            RSClient client = new RSClient();
            CallRet ret = client.Delete(new EntryPath(bucket, key));
            if (ret.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}