using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
///Validator 的摘要说明
/// </summary>
public class Validator
{
   ///
    public static bool CheckImageType(string extension)
    {
        return Regex.IsMatch(extension,
           @"(^\.((png)|(bmp)|(jpg)|(gif)|(jpeg))$)",
            RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// 判断一个字符串是否为合法数字(0-32整数)
    /// </summary>
    /// <param name="s">字符串</param>
    /// <returns></returns>
    public static bool IsNumber(string s)
    {
        return IsNumber(s, 32, 0);
    }
    /// <summary>
    /// 判断一个字符串是否为合法数字(指定整数位数和小数位数)
    /// </summary>
    /// <param name="s">字符串</param>
    /// <param name="precision">整数位数</param>
    /// <param name="scale">小数位数</param>
    /// <returns></returns>
    public static bool IsNumber(string s, int precision, int scale)
    {
        if ((precision == 0) && (scale == 0))
        {
            return false;
        }
        string pattern = @"(^\d{1," + precision + "}";
        if (scale > 0)
        {
            pattern += @"\.\d{0," + scale + "}$)|" + pattern;
        }
        pattern += "$)";
        return Regex.IsMatch(s, pattern);
    }

    /// <summary>
    /// 前端输出提示
    /// </summary>
    /// <param name="type">1 输入提示；2错误提示 ；3正确提示</param>
    /// <param name="hintStr">修饰后的输出</param>
    /// <returns></returns>
    public static string getHintStr(int type,string hintStr) {
        string str = "";
        type--;
        if (type == 0) {
            str = "&nbsp;<img src='../../style/images/webimage/hint.png' alt='输入提示' style='vertical-align:middle;' />";
            if (hintStr != "")
            {
                str = str + "<span class='v_span' >" + hintStr + "</span>";
            }
        } else if (type == 1) {
            str = "&nbsp;<img src='../../style/images/webimage/wrong.png' alt='错误提示' style='vertical-align:middle;' />";
            if (hintStr != "")
            {
                str = str + "<span class='w_span' >" + hintStr + "</span>";
            }
        } else {
            str = "&nbsp;<img src='../../style/images/webimage/right.png' alt='正确' style='vertical-align:middle;' />";
            if (hintStr != "")
            {
                str = str + "<span class='r_span' >" + hintStr + "</span>";
            }
        }
        return str;
    }
    /// <summary>
    /// 检测字符串是否为空和是否超过设定的最大长度
    /// </summary>
    /// <param name="str"></param>
    /// <param name="checkNull">是否检测空串</param>
    /// <param name="maxLen">是否检测最大长度</param>
    /// <param name="length">maxLen为true时，设定最大长度</param>
    /// <returns>"不能为空！""不能超过XX",正确""</returns>
    public static string checkStrLength(string str, bool checkNull, bool maxLen, int length)
    {
        if (checkNull)
        {
            if (str == "")
            {
                return "不能为空！";
            }
        }
        if (maxLen)
        {
            if (str.Length > length)
            {
                return "长度不能大于" + length.ToString() + "！";
            }
        }
        return "";
    }
    /// <summary>
    /// 返回信息修饰，在字符串前面加一个图标
    /// </summary>
    /// <param name="info"></param>
    /// <param name="success"></param>
    /// <returns></returns>
    public static string getReturnInfo(string info,bool success)
    {
        if(success)
            return getRightInfo(info);
        return getErrorInfo(info);
    }

    //错误信息
    public static string getErrorInfo(string Info)
    {
        string str = "<span style='background-color:#F9F7E0;'><img src='../../style/images/WebImage/wrong.gif' alt='wrong' style='vertical-align:middle;' />" + Info + "</span>";
        return str;
    }
    //正确信息
    public static string getRightInfo(string Info)
    {
        string str = "<span style='background-color:#F9F7E0;'><img src='../../style/images/WebImage/right.gif' alt='right' style='vertical-align:middle;' />" + Info + "</span>";
        return str;
    }


    //验证用户名
    public static bool IsUserName(string str)  //6到20位
    {
        string pattern = @"^([a-zA-Z]){1}(\w){5,19}";
        return Regex.IsMatch(str, pattern);
    }

    //验证密码
    public static bool IsPassword(string str)  //6到16位
    {
        if (str.Length > 5 && str.Length < 17)
            return true;
        return false;
    }
    #region
    //验证邮箱
    /**/
    /// <summary>
    /// 验证邮箱
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsEmail(string source)
    {
        return Regex.IsMatch(source,
            @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@" +
            @"([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$",
            RegexOptions.IgnoreCase);
    }
    public static bool HasEmail(string source)
    {
        return Regex.IsMatch(source,
            @"[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@" +
            @"([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})",
            RegexOptions.IgnoreCase);
    }
    #endregion

    #region
    // 验证网址
    /**/
    /// <summary>
    /// 验证网址
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsUrl(string source)
    {
        return Regex.IsMatch(source,
            @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)" +
            @"|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]" +
            @"{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$",
            RegexOptions.IgnoreCase);
    }

    public static bool HasUrl(string source)
    {
        return Regex.IsMatch(source,
            @"(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)" +
            @"|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]" +
            @"{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?",
            RegexOptions.IgnoreCase);
    }
    #endregion

    #region
    //验证日期
    /**/
    /// <summary>
    /// 验证日期
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsDateTime(string source)
    {
        try
        {
            DateTime time = Convert.ToDateTime(source);
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region
    //验证手机号 验证手机号
    /**/
    /// <summary>
    /// 验证手机号
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsMobile(string source)
    {
        //return Regex.IsMatch(source, @"^(1[0-9])\d{9}$", RegexOptions.IgnoreCase);
        return Regex.IsMatch(source, @"^\d{10}|\d{12}$", RegexOptions.IgnoreCase);
    }
    public static bool HasMobile(string source)
    {
        return Regex.IsMatch(source, @"1[35]\d{9}", RegexOptions.IgnoreCase);
    }
    #endregion

    #region//验证是否符合日期格式
    public static bool IsBirthday(string source)
    {
        /// <param name="StrSource">日期字符串(MMMM/xx/yy)</param>
        return Regex.IsMatch(source, "^(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})$");
      
       }
    #endregion
    #region
    //验证IP 
    /**/
    /// <summary>
    /// 验证IP
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsIP(string source)
    {
        return Regex.IsMatch(source,
            @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])" +
            @"\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]" +
            @"|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]" +
            @"|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$",
            RegexOptions.IgnoreCase);
    }
    public static bool HasIP(string source)
    {
        return Regex.IsMatch(source,
            @"(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])" +
            @"\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]" +
            @"|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]" +
            @"|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])",
            RegexOptions.IgnoreCase);
    }
    #endregion

    #region
    //验证身份证是否有效 
    /**/
    /// <summary>
    /// 验证身份证是否有效
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public static bool IsIDCard(string Id)
    {
        if (Id.Length == 18)
        {
            bool check = IsIDCard18(Id);
            return check;
        }
        else if (Id.Length == 15)
        {
            bool check = IsIDCard15(Id);
            return check;
        }
        else
        {
            return false;
        }
    }

    public static bool IsIDCard18(string Id)
    {
        long n = 0;
        if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16)
            || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
        {
            return false;//数字验证
        }
        string address =
            "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x" +
            "15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (address.IndexOf(Id.Remove(2)) == -1)
        {
            return false;//省份验证
        }
        string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
        DateTime time = new DateTime();
        if (DateTime.TryParse(birth, out time) == false)
        {
            return false;//生日验证
        }
        string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
        string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
        char[] Ai = Id.Remove(17).ToCharArray();
        int sum = 0;
        for (int i = 0; i < 17; i++)
        {
            sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
        }
        int y = -1;
        Math.DivRem(sum, 11, out y);
        if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
        {
            return false;//校验码验证
        }
        return true;//符合GB11643-1999标准
    }

    public static bool IsIDCard15(string Id)
    {
        long n = 0;
        if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
        {
            return false;//数字验证
        }
        string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x" +
            "14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
        if (address.IndexOf(Id.Remove(2)) == -1)
        {
            return false;//省份验证
        }
        string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
        DateTime time = new DateTime();
        if (DateTime.TryParse(birth, out time) == false)
        {
            return false;//生日验证
        }
        return true;//符合15位身份证标准
    }

    /// <summary>
    ///获取身份证后6位
    /// </summary>
    /// <param name="IDCard"></param>
    /// <returns></returns>
    public static string GetIDCardLast6n(string IDCard)
    {
        int len = IDCard.Length;
        return IDCard.Substring(len - 6);
    }
    /// <summary>
    /// 根据身份证号获取生日
    /// </summary>
    /// <param name="IdCard"></param>
    /// <returns></returns>
    public static string GetBrithdayFromIdCard(string IdCard)
    {
        string rtn = "1900-01-01";
        if (IdCard.Length == 15)
        {
            rtn = IdCard.Substring(6, 6).Insert(4, "-").Insert(2, "-");
        }
        else if (IdCard.Length == 18)
        {
            rtn = IdCard.Substring(6, 8).Insert(6, "-").Insert(4, "-");
        }
        return rtn;
    }
    /// <summary>
    /// 根据身份证获取性别
    /// </summary>
    /// <param name="IdCard"></param>
    /// <returns></returns>
    public static string GetSexFromIdCard(string IdCard)
    {
        string rtn;
        string tmp = "";
        if (IdCard.Length == 15)
        {
            tmp = IdCard.Substring(IdCard.Length - 3);
        }
        else if (IdCard.Length == 18)
        {
            tmp = IdCard.Substring(IdCard.Length - 4);
            tmp = tmp.Substring(0, 3);
        }
        int sx = int.Parse(tmp);
        int outNum;
        Math.DivRem(sx, 2, out outNum);
        if (outNum == 0)
        {
            //rtn = "女";
            rtn = "0";
        }
        else
        {
            //rtn = "男";
            rtn = "1";
        }
        return rtn;
    }


    #endregion

    #region
    //是不是Int型的
    /**/
    /// <summary>
    /// 是不是Int型的
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    /// 
    //验证正整数
    public static bool IsAboveZeroInt(string str)  //6到10位
    {
        //^([a-zA-Z]){1}(\w){5,19}
        string pattern = @"[1-9][0-9]{0,9}";
        return Regex.IsMatch(str, pattern);
    }
    public static bool IsInt(string source)
    {
        Regex regex = new Regex(@"^(-){0,1}\d+$");
        if (regex.Match(source).Success)
        {
            if ((long.Parse(source) > 0x7fffffffL) ||
                (long.Parse(source) < -2147483648L))
            {
                return false;
            }
            return true;
        }
        return false;
    }
    #endregion

    #region
    //看字符串的长度是不是在限定数之间 一个中文为两个字符
    /**/
    /// <summary>
    /// 看字符串的长度是不是在限定数之间 一个中文为两个字符
    /// </summary>
    /// <param name="source">字符串</param>
    /// <param name="begin">大于等于</param>
    /// <param name="end">小于等于</param>
    /// <returns></returns>
    public static bool IsLengthStr(string source, int begin, int end)
    {
        int length = Regex.Replace(source, @"[^\x00-\xff]", "OK").Length;
        if ((length <= begin) && (length >= end))
        {
            return false;
        }
        return true;
    }
    #endregion

    #region
    /// <summary>
    /// 验证是否为正确固定电话号码.规则[3-4位区号+"-"+]7-8位数字[+"-"+0-4位分机号码]
    /// </summary>
    /// <param name="parmString"></param>
    /// <returns></returns>
    //public static bool CheckTel(string parmString)
    //{
    //    bool result;
    //    string StringReg = @"(^((\d{7,8})|(\d{3,4})-(\d{7,8})|(\d{3,4})-(\d{7,8})-(\d{0,4})|(\d{7,8})-(\d{0,4}))$)";
    //    result = Regex.IsMatch(parmString, StringReg);
    //    return result;
    //}
    #endregion

    #region
    /// <summary>
    /// 验证是否为正确电话号码,包括手机号码,固定电话;规则:手机号码 18(8,6)|13|15(0,3,6,8,9)+8位数字;规定电话:规则[3-4位区号+"-"+]6-8位数字[+"-"+0-4位分机号码]
    /// </summary>
    /// <param name="parmString"></param>
    /// <returns></returns>
    public static bool CheckTelNumber(string parmString)
    {
        bool result;
        string StringReg = @"^(((18[0-9]|13[0-9]|15[0-9])\d{8})|((\d{5,8})|((\d{3,4})-(\d{7,8}))|((\d{3,4})-(\d{6,8})-(\d{0,4}))|((\d{7,8})-(\d{0,4}))))$";
        result = Regex.IsMatch(parmString, StringReg);
        return result;
    }
    #endregion

    #region
    //邮政编码 6个数字
    /**/
    /// <summary>
    /// 邮政编码 6个数字
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsPostCode(string source)
    {
        return Regex.IsMatch(source, @"^\d{6}$",
            RegexOptions.IgnoreCase);
    }
    #endregion

    #region 中文
    /**/
    /// <summary>
    /// 中文
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsChinese(string source)
    {
        return Regex.IsMatch(source, @"^[\u4e00-\u9fa5]+$",
            RegexOptions.IgnoreCase);
    }
    public static bool hasChinese(string source)
    {
        return Regex.IsMatch(source, @"[\u4e00-\u9fa5]+",
            RegexOptions.IgnoreCase);
    }
    #endregion
    #region 英文
    /**/
    /// <summary>
    /// 英文
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsEnglish(string source)
    {
        return Regex.IsMatch(source, @"^[a-zA-Z]",
            RegexOptions.IgnoreCase);
    }
   
    #endregion

    #region
    //验证是不是正常字符 字母，数字，下划线的组合
    /**/
    /// <summary>
    /// 验证是不是正常字符 字母，数字，下划线的组合
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool IsNormalChar(string source)
    {
        return Regex.IsMatch(source, @"[\w\d_]+", RegexOptions.IgnoreCase);
    }
    #endregion

    //验证是否为小数 
    public static bool IsValidDecimal(string strIn)
    {

        return Regex.IsMatch(strIn, @"[0].\d{1,2}|[1]");
    }
    //qq验证
    public static bool IsQQ(string strIn)
    {

        return Regex.IsMatch(strIn, @"\d{6,10}");
    }
    //验证后缀名 
    public static bool IsValidPostfix(string strIn)
    {
        return Regex.IsMatch(strIn, @"\.(?i:gif|jpg)$");
    }
    //数字串组成验证
    public static bool IsAllNumber(string strIn)
    {
        return Regex.IsMatch(strIn, @"\d{1,20}");
    }
    /// <summary>
    /// 检查是否为n位数字
    /// </summary>
    /// <param name="n">数字位数</param>
    /// <param name="parm">需要检查的字符串</param>
    /// <returns>检查结果</returns>
    public static bool CheckNumber(int n, string parmNumber)
    {
        bool result;
        string NumberReg = "^\\d{" + n + "}$";
        result = Regex.IsMatch(parmNumber, NumberReg);
        return result;
    }

    /**/
    /// <summary>
    /// /// 检测字符串的内容是否数字
    /// </summary>
    /// <param name="strTemp"></param>
    /// <returns></returns>

    public static Boolean IsNumeric(String strTemp)
    {
        //为了检测类似1,235,000的数据，需要将半角逗号过滤
        strTemp = strTemp.Replace(",", String.Empty);

        Regex regNum = new Regex(@"^[-]?\d+[.]?\d*$");
        return regNum.IsMatch(strTemp);
    }

    public static Boolean IsAboveNumeric(String strTemp)
    {
        try
        {
            Convert.ToDouble(strTemp);
            return true;
        }
        catch
        {
            return false;
        }
      
    }

}