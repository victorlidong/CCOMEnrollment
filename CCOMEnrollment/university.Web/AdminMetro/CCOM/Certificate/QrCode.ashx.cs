using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using university.Common;

namespace university.Web.AdminMetro.CCOM.Certificate
{
    /// <summary>
    /// QrCode 的摘要说明
    /// </summary>
    public class QrCode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string data = MyRequest.GetQueryString("data");
            string result=string.Empty;
            if(data!=null&&data.Length>0)
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
            string pic = MyRequest.GetQueryString("pic");
            if (pic == "") pic = "/images/login/ccom_logo.png";
            int QRCodeScale = MyRequest.GetQueryInt("codescale", 10);
            if (!Tools.CheckParams(result))
            {
                GetQRCode qrcode = new GetQRCode();
                //qrcode.ProcessRequest(HttpContext.Current, result, QRCodeScale , pic);
                qrcode.ProcessRequest_path(HttpContext.Current, result, QRCodeScale, pic, "/AdminMetro/CCOM/Certificate/QRcode_image/"+result+".png");
            }
            else
            {
                context.Response.Write("传入数据包含非法字符!");
                return;
            }
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