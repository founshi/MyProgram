using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class StringUnitity
    {

        public  static string GetSubString(string sourceString, int length, string tailString)
        {
            return GetSubString(sourceString, 0, length, tailString);
        }

        public static string GetSubString(string sourceString, int startIndex, int length, string tailString)
        {
            string myResult = sourceString;

            //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
            if (System.Text.RegularExpressions.Regex.IsMatch(sourceString, "[\u0800-\u4e00]+") ||
                System.Text.RegularExpressions.Regex.IsMatch(sourceString, "[\xAC00-\xD7A3]+"))
            {
                //当截取的起始位置超出字段串长度时
                if (startIndex >= sourceString.Length)
                {
                    return string.Empty;
                }
                else
                {
                    return sourceString.Substring(startIndex,
                                                   ((length + startIndex) > sourceString.Length) ? (sourceString.Length - startIndex) : length);
                }
            }

            //中文字符，如"中国人民abcd123"
            if (length <= 0)
            {
                return string.Empty;
            }
            byte[] bytesSource = Encoding.Default.GetBytes(sourceString);

            //当字符串长度大于起始位置
            if (bytesSource.Length > startIndex)
            {
                int endIndex = bytesSource.Length;

                //当要截取的长度在字符串的有效长度范围内
                if (bytesSource.Length > (startIndex + length))
                {
                    endIndex = length + startIndex;
                }
                else
                {   //当不在有效范围内时,只取到字符串的结尾
                    length = bytesSource.Length - startIndex;
                    tailString = "";
                }

                int[] anResultFlag = new int[length];
                int nFlag = 0;
                //字节大于127为双字节字符
                for (int i = startIndex; i < endIndex; i++)
                {
                    if (bytesSource[i] > 127)
                    {
                        nFlag++;
                        if (nFlag == 3)
                        {
                            nFlag = 1;
                        }
                    }
                    else
                    {
                        nFlag = 0;
                    }
                    anResultFlag[i] = nFlag;
                }
                //最后一个字节为双字节字符的一半
                if ((bytesSource[endIndex - 1] > 127) && (anResultFlag[length - 1] == 1))
                {
                    length = length + 1;
                }

                byte[] bsResult = new byte[length];
                Array.Copy(bytesSource, startIndex, bsResult, 0, length);
                myResult = Encoding.Default.GetString(bsResult);
                myResult = myResult + tailString;

                return myResult;
            }

            return string.Empty;

        }


        public static String GetNewGUID()
        {
            return Guid.NewGuid().ToString("N");
        }


    }
}
