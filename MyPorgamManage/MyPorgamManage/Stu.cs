using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPorgamManage
{
    [Serializable]
    public class Stu
    {

        public int id { get; set; }
        public string name { get; set; }
        public MyEnum aMyEnum { get; set; }
    }

   public enum MyEnum
    {
        none=0,
        aha=1,
    }
}
