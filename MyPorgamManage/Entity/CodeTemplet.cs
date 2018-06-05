using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    [Serializable]
    public class CodeTemplet
    {
        /// <summary>
        /// 
        /// </summary>
       [SugarColumn(IsPrimaryKey = true)]
        public string CTemplet_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CTemplet_Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CTemplet_NameSP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CTemplet_DbType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CTemplet_CPrefix { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CTemplet_Context { get; set; }

    }
}
