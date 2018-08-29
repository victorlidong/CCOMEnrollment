using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using university.Common;

namespace university.Web.AdminMetro.CCOM.Certificate
{
    /// <summary>
    /// Barcode 的摘要说明
    /// </summary>
    public class Barcode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            string data = MyRequest.GetQueryString("data");
            string result = string.Empty;
            if (data != null && data.Length > 0)
            {
                try
                {
                    result = DESEncrypt.Decrypt(data);
                }
                catch
                {

                }
            }
            else
            {
                context.Response.Write("传入数据有误");
                return;
            }
            if (!File.Exists(HttpContext.Current.Server.MapPath("/AdminMetro/CCOM/Certificate/BarCode_image/" + result + ".png")))
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                System.Drawing.Image myimg = BarCodeHelper.MakeBarcodeImage(result, 2, true);
                myimg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                myimg.Save(HttpContext.Current.Server.MapPath("/AdminMetro/CCOM/Certificate/BarCode_image/" + result + ".png"));
            }
            context.Response.Write("/AdminMetro/CCOM/Certificate/BarCode_image/" + result + ".png");
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}