using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    [Serializable]
    public class DBCSTypeChange
    {
        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public string DbType  { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string CsType  { get; set; }
}

    }

