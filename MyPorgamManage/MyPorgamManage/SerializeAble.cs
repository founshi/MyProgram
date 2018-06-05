using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MyPorgamManage
{
     public class SerializeAble
    {
        public static void BinarySerialize(string objname, object obj)
        {
            try
            {
                string filename = objname + ".Binary";
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    // 用二进制格式序列化
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, obj);
                    fileStream.Close();
                }
            }
            catch //(Exception ex)
            {
                //throw new Exception(ex.Message);
            }
        }

        public static object BinaryDeserialize(string objname)
        {
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();
            //二进制格式反序列化
            object obj;
            string filename = objname + ".Binary";
            if (!System.IO.File.Exists(filename))
                throw new Exception("在反序列化之前,请先序列化");
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                obj = formatter.Deserialize(stream);
                stream.Close();
            }
            //using (FileStream fs = new FileStream(filename, FileMode.Open))
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    object obj = formatter.Deserialize(fs);
            //}
            return obj;

        }

    }
}

