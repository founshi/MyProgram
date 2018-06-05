using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 这个不是数据库表的实例 是程序中自定义的实体
    /// </summary>
    public class ColumnInfo
    {
        public bool cisNull { get; set; }
       

        public string Colorder{ get; set; }
        

        public string ColumnName{ get; set; }
       
        public string ColumnNameRealName{ get; set; }
       
        public string DefaultVal{ get; set; }
        

        public string DeText{ get; set; }
       

        public bool IsIdentity{ get; set; }
        

        public bool IsPK{ get; set; }
       

        public string Length{ get; set; }
        

        public string Preci{ get; set; }
       

        public string Scale{ get; set; }
       

        public string TypeName{ get; set; }
        

    }
}
