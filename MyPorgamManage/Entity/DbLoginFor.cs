using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
namespace Entity
{
    [Serializable]
    public class DbLoginFor
    {
        [SugarColumn(IsPrimaryKey = true)]
        /// <summary>
        /// 
        /// </summary>
        public string LoginDb_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LoginDb_Descp { get; set; }
        /// <summary>
        /// 1 sqlite
        /// 2 sql server
        /// 3 oracle
        /// 4 mysql
        /// </summary>
        public int Db_Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ServerIP { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? ServerPort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ConnString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DBName { get; set; }
    }

}
