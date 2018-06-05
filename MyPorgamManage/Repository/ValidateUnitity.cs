using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Repository
{
    public class ValidateUnitity
    {
        /// <summary>
        /// 整数 验证
        /// </summary>
        private static readonly Regex RegNumber = new Regex("^[0-9]+$");
        /// <summary>
        /// 可以带正负号的 整数 验证
        /// </summary>
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        /// <summary>
        /// Email验证
        /// </summary>
        private static readonly Regex RegEmail = new Regex(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        /// <summary>
        /// Decimal验证
        /// </summary>
        private static readonly Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        /// <summary>
        /// 可以带正负号的 Decimal验证
        /// </summary>
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$


        /// <summary>
        /// 验证输入的地址是否是正确的Email格式
        /// </summary>
        /// <param name="emailAddress">Email地址</param>
        /// <returns>是正确的Email格式 返回true, 否则返回false</returns>
        public static bool IsEmail(string emailAddress)
        {
            Match m = RegEmail.Match(emailAddress);
            return m.Success;
        }
        /// <summary>
        /// 判断输入的字符是否为日期
        /// </summary>
        /// <param name="strData">输入的字符</param>
        /// <returns>字符串是日期返回true,否则返回false</returns>
        public static bool IsDate(string strData)
        {
            return Regex.IsMatch(strData, @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))");
        }
        /// <summary>
        /// 判断输入的字符串是不是 浮点数
        /// </summary>
        /// <param name="decimalNum">输入的字符串</param>
        /// <returns>如果是浮点数返回true,否则返回false</returns>
        public static bool IsDecimal(string decimalNum)
        {
            Match m = RegDecimal.Match(decimalNum);
            return m.Success;
        }
        /// <summary>
        /// 判断输入的字符串是不是 浮点数(可以带正负号)
        /// </summary>
        /// <param name="decimalNum">输入的字符串(可以带正负号)</param>
        /// <returns>如果是浮点数返回true,否则返回false</returns>
        public static bool IsDecimalSign(string decimalNum)
        {
            Match m = RegDecimalSign.Match(decimalNum);
            return m.Success;
        }
        /// <summary>
        /// 判断输入的字符串是不是 整数(可以带正负号)
        /// </summary>
        /// <param name="IntNum">输入的字符串(可以带正负号)</param>
        /// <returns>如果是整数返回true,否则返回false</returns>
        public static bool IsNumberSign(string IntNum)
        {
            Match m = RegNumberSign.Match(IntNum);
            return m.Success;
        }
        /// <summary>
        /// 判断输入的字符串是不是 整数
        /// </summary>
        /// <param name="IntNum">输入的字符串</param>
        /// <returns>如果是整数返回true,否则返回false</returns>
        public static bool IsValidInt(string IntNum)
        {
            return Regex.IsMatch(IntNum, @"^[1-9]\d*\.?[0]*$");
        }
        /// <summary>
        /// 判断输入的字符串是不是数字
        /// </summary>
        /// <param name="valNum">输入的字符串</param>
        /// <returns>如果是数字返回true,否则返回false</returns>
        public static bool IsNumber(string valNum)
        {
            Match m = RegNumber.Match(valNum);
            return m.Success;
        }
    }
}
