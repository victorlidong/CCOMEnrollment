using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace university.Common
{
    /// <summary>
    /// DES加密/解密类。
    /// </summary>
    public class DESEncrypt
    {
        /// <summary>
        /// DES加密/解密类。
        /// </summary>
        private const string DESkey = "q2bxr4h4";

        public DESEncrypt()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            
        }
//        private static string MD5Hash(string Text)
//        {
//            HashAlgorithm md5 = HashAlgorithm.Create("MD5");
//            byte[] buffer = Encoding.UTF8.GetBytes(Text);
//            return Convert.ToBase64String(md5.ComputeHash(buffer)); 
//        }
        private static string MD5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            // Convert the input string to a byte array and compute the hash.
            char[] temp = input.ToCharArray();
            byte[] buf = new byte[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                buf[i] = (byte)temp[i];
            }
            byte[] data = md5Hasher.ComputeHash(buf);
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static string MD5Encrypt(string Text)
        {
            return MD5Hash(MD5Hash(Text).ToString());
        }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, DESkey);
        }


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, DESkey);
        }


        ///
        /// DEC 加密过程
        ///
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            string res = "";
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();　//把字符串放到byte数组中
                byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
                //byte[]　inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);

                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);　 //原文使用ASCIIEncoding.ASCII方法的GetBytes方法
                MemoryStream ms = new MemoryStream();　　 //使得输入密码必须输入英文文本
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                StringBuilder ret = new StringBuilder();
                foreach (byte b in ms.ToArray())
                {
                    ret.AppendFormat("{0:X2}", b);
                }
                ret.ToString();
                res = ret.ToString();
            }
            catch
            { res = "Exception"; }
            finally { }
            return res.ToString();
        }

        ///
        /// DEC 解密过程
        ///
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            string res = "";
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);　//建立加密对象的密钥和偏移量，此值重要，不能修改
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                StringBuilder ret = new StringBuilder();　//建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象

                res = System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch
            { }
            finally { }
            return res;
        }

        ///
        /// 检查己加密的字符串是否与原文相同
        ///
        public static bool ValidateString(string EnString, string FoString, int Mode)
        {
            switch (Mode)
            {
                default:
                case 1:
                    if (Decrypt(EnString, DESkey) == FoString.ToString())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 2:
                    if (Decrypt(EnString, DESkey) == FoString.ToString())
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

}
