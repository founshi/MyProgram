using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class FunctionContext
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Fun_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Fun_Context { get; set; }



    }
}
