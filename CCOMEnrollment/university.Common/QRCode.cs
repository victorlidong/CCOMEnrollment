using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using System.Drawing;
using System.Web;
using System.Drawing.Drawing2D;

namespace university.Common
{
    public class QRCode
    {
        public int version = 7;
        public string errorCorrect = "M";
        public string encoding = "Byte";
        public int scale = 4;

        public Image CreateQRCode(string data)
        {
            Image img = null;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            if (encoding == "Byte")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            }
            else if (encoding == "AlphaNumeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
            }
            else if (encoding == "Numeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
            }
            try
            {
                qrCodeEncoder.QRCodeScale = scale;
            }
            catch
            {
                return img;
            }
            try
            {
                qrCodeEncoder.QRCodeVersion = version;
            }
            catch
            {
                return img;
            }

            if (errorCorrect == "L")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            else if (errorCorrect == "M")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            else if (errorCorrect == "Q")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
            else if (errorCorrect == "H")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;

            img = qrCodeEncoder.Encode(data);
            return img;
        }


        public string DecodeQRCode(Image img)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            String decodedString = decoder.decode(new QRCodeBitmapImage(new Bitmap(img)));
            return decodedString;
        }

        public string CreateQRCode(string data, string filepath)
        {
            if(filepath == "") filepath = "/upload/qrcode/" + DateTime.Now.Date.ToOADate() + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DESEncrypt.Encrypt(data) + ".png";
            Bitmap bitmap = new Bitmap(this.CreateQRCode(data));
            bitmap.Save(HttpContext.Current.Server.MapPath(filepath));
            return filepath;
        }
    }


    public class GetQRCode
    {
        //重载方法(modify by:hpf)
        public void ProcessRequest(HttpContext context,string data, int QRCodeScale, string picpath,string qrCodeSavePath)
        {
            if (!string.IsNullOrEmpty(data))
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = QRCodeScale;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                System.Drawing.Image image = qrCodeEncoder.Encode(data);
                System.IO.MemoryStream MStream = new System.IO.MemoryStream();
                image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);
                System.IO.MemoryStream MStream1 = new System.IO.MemoryStream();
                var qrCodeImg = CombinImage(image, context.Server.MapPath(picpath));
                qrCodeImg.Save(MStream1, System.Drawing.Imaging.ImageFormat.Png);
                //如果传入二维码图片保存路径，则保存
                if (qrCodeSavePath != "")
                {
                    try
                    {
                        qrCodeImg.Save(HttpContext.Current.Server.MapPath(qrCodeSavePath));
                    }
                    catch {}
                }
                context.Response.ClearContent();
                context.Response.ContentType = "image/png";
                context.Response.BinaryWrite(MStream1.ToArray());
                //image.Dispose();
                MStream.Dispose();
                MStream1.Dispose();
            }
            context.Response.Flush();
            context.Response.End();
        }

        public void ProcessRequest_path(HttpContext context, string data, int QRCodeScale, string picpath, string qrCodeSavePath)
        {
            if (!string.IsNullOrEmpty(data))
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = QRCodeScale;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                System.Drawing.Image image = qrCodeEncoder.Encode(data);
                System.IO.MemoryStream MStream = new System.IO.MemoryStream();
                image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);
                System.IO.MemoryStream MStream1 = new System.IO.MemoryStream();
                var qrCodeImg = CombinImage(image, context.Server.MapPath(picpath));
                qrCodeImg.Save(MStream1, System.Drawing.Imaging.ImageFormat.Png);
                //如果传入二维码图片保存路径，则保存
                if (qrCodeSavePath != "")
                {
                    try
                    {
                        qrCodeImg.Save(HttpContext.Current.Server.MapPath(qrCodeSavePath));
                    }
                    catch { }
                }
                //context.Response.ClearContent();
                //context.Response.ContentType = "image/png";
                //context.Response.BinaryWrite(MStream1.ToArray());
                ////image.Dispose();
                //MStream.Dispose();
                //MStream1.Dispose();
                context.Response.Write(qrCodeSavePath);
            }
            context.Response.Flush();
            context.Response.End();
        }

        public void ProcessRequest(HttpContext context, string data, int QRCodeScale, string picpath)
        {
            ProcessRequest(context, data, QRCodeScale, picpath, "");
        }

        //生成二维码图片并保存
        public bool generateQrCodeImg(string data, int QRCodeScale, string qrCodeLogoPath, string qrCodeSavePath)
        {
            if (!string.IsNullOrEmpty(data))
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = QRCodeScale;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                System.Drawing.Image image = qrCodeEncoder.Encode(data);
                //System.IO.MemoryStream MStream = new System.IO.MemoryStream();
                //image.Save(MStream, System.Drawing.Imaging.ImageFormat.Png);
                //System.IO.MemoryStream MStream1 = new System.IO.MemoryStream();
                var qrCodeImg = CombinImage(image, HttpContext.Current.Server.MapPath(qrCodeLogoPath));
                //qrCodeImg.Save(MStream1, System.Drawing.Imaging.ImageFormat.Png);
                //如果传入二维码图片保存路径，则保存
                if (qrCodeSavePath != "")
                {
                    try
                    {
                        qrCodeImg.Save(HttpContext.Current.Server.MapPath(qrCodeSavePath));
                        return true;
                    }
                    catch { }
                }
                //image.Dispose();
                //MStream.Dispose();
                //MStream1.Dispose();
            }
            return false;
        }

        ///
        /// 调用此函数后使此两种图片合并，类似相册，有个
        /// 背景图，中间贴自己的目标图片
        ///
        /// 粘贴的源图片
        /// 粘贴的目标图片
        public static Image CombinImage(Image imgBack, string destImg)
        {
            Image img = Image.FromFile(destImg); //照片图片
            int size = imgBack.Width / 4;
            if (img.Height != size || img.Width != size)
            {
                img = KiResizeImage(img, size, size, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);
            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);
            //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);
            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框
            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);
            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }
        ///
        /// Resize图片
        ///
        /// 原始Bitmap
        /// 新的宽度
        /// 新的高度
        /// 保留着，暂时未用
        /// 处理以后的图片
        public static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

    }
}
