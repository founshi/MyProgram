using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace Entity
{
    ///<summary>
    ///
    ///</summary>
    public  class ProgList
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Prog_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Prog_Assmbly { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Prog_NameSp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Prog_CLS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Prog_Descp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Prog_Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Prog_ParantId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Prog_Status { get; set; }


    }
}
