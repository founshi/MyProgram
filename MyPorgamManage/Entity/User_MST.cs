using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace Entity
{
    ///<summary>
    ///
    ///</summary>
    public class User_MST
    {

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string User_Id { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string User_Name { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string User_Gener { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public int User_Status { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? User_RegTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string User_Pwd { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? User_LogTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string User_LogIp { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string User_Email { get; set; }

    }
}
