using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Repository
{
    public class FileUnitity
    {
        /// <summary>
        /// 读取文件到 字符串
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string FileToString(string fileName)
        {
            StreamReader sr = File.OpenText(fileName);
            StringBuilder output = new StringBuilder();
            string rl;
            while ((rl = sr.ReadLine()) != null)
            {
                output.AppendLine(rl);                
            }
            sr.Close();
            return output.ToString();
        }
        public static string FileToString(string fileName, Encoding encoding)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            return File.ReadAllText(fileName, encoding);        
        }

        public static string[] FileToArray(string fileName, Encoding encoding)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            return File.ReadAllLines(fileName, encoding);
        }
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool FileExist(string fileName)
        {
            return File.Exists(fileName);
        }
        /// <summary>
        /// 将字符串 存成新的文件,如果文件存在就删除
        /// </summary>
        /// <param name="fileName">文件名(含路径)</param>
        /// <param name="context">保存的内容</param>
        /// <param name="encoding">编码方式</param>
        public static void StringToNewFile(string fileName, string context, Encoding encoding)
        {
            if (null == encoding) encoding = Encoding.UTF8;
            if (FileUnitity.FileExist(fileName)) FileUnitity.DeleteFile(fileName);
            StreamWriter fstreamwr = new StreamWriter(fileName, true, encoding);
            fstreamwr.WriteLine(context);
            fstreamwr.Close();
            fstreamwr.Dispose();
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFile(string fileName)
        {
            File.Delete(fileName);
        }
        /// <summary>
        /// 创建空文件
        /// </summary>
        /// <param name="fileName"></param>
        public static void CreateEmptyFile(string fileName)
        {
            if (FileUnitity.FileExist(fileName)) throw new Exception("文件已经存在,不可在创建....");
            FileStream fsteam = File.Create(fileName);
            fsteam.Close();
            fsteam.Dispose();

        }

    }
}
