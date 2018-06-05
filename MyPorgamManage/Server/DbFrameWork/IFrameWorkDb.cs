using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SqlSugar;
using Entity;
namespace Server.DbFrameWork
{
    public interface IFrameWorkDb
    {
        
        /// <summary>
        /// 获取所有的数据库 这个只针对SQL Server 数据库
        /// </summary>
        /// <returns></returns>
        DataTable GetDBS();//这个需要使用SQL 
        /// <summary>
        /// 获取所有的表
        /// </summary>
        /// <returns></returns>
        List<DbTableInfo> GetTables();
        /// <summary>
        /// 获取所有的视图
        /// </summary>
        /// <returns></returns>
        List<DbTableInfo> GetViews();
        /// <summary>
        /// 获取 表的列信息
        /// </summary>
        /// <returns></returns>
        List<ColumnInfo> GetColumsFromTable(string TableName);

        List<ColumnInfo> GetColumsFromView(string ViewName);
        //DataTable GetProcs();//这个需要使用原生态的SQL
    }
}
