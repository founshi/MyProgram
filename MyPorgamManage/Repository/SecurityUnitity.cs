using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Repository
{
    public class SecurityUnitity
    {
        private static byte[] Keys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79,
                                             0x53,0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="encryptString">需加密的字符串</param>
        /// <param name="encryptKey">加密密码</param>
        /// <returns>加密后的字符串</returns>
        public static string AES_Encrypt(string encryptString, string encryptKey)
        {
            encryptKey = StringUnitity.GetSubString(encryptKey, 32, "");
            encryptKey = encryptKey.PadRight(32, ' ');

            RijndaelManaged rijndaelProvider = new RijndaelManaged();
            rijndaelProvider.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32));
            rijndaelProvider.IV = Keys;
            ICryptoTransform rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            byte[] inputData = Encoding.UTF8.GetBytes(encryptString);
            byte[] encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="decryptString">需要解密的字符串</param>
        /// <param name="decryptKey">解密密码</param>
        /// <returns>解密后的字符串</returns>
        public static string AES_Decrypt(string decryptString, string decryptKey)
        {
            try
            {
                decryptKey = StringUnitity.GetSubString(decryptKey, 32, "");
                decryptKey = decryptKey.PadRight(32, ' ');

                RijndaelManaged rijndaelProvider = new RijndaelManaged();
                rijndaelProvider.Key = Encoding.UTF8.GetBytes(decryptKey);
                rijndaelProvider.IV = Keys;
                ICryptoTransform rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                byte[] inputData = Convert.FromBase64String(decryptString);
                byte[] decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// MD5 32位加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string GetMD5_32(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }




    }
}
