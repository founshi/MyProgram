using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace Entity
{
    ///<summary>
    ///
    ///</summary>
    public  class FunctionRepository
    {
       [SugarColumn(IsPrimaryKey = true)]
        public string Fun_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Fun_ParantId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Fun_Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Func_Descpt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Fun_CLSF { get; set; }
        
    }
}
