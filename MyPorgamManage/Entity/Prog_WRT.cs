using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace Entity
{
    ///<summary>
    ///
    ///</summary>
    public  class Prog_WRT
    {
          
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary> 
           [SugarColumn(IsPrimaryKey = true)]
           public string ProgWrt_Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Prog_Id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string User_Id {get;set;}

    }
}
