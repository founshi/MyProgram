using Entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Server.DbFrameWork
{
    public class FrameWorkMySqlDb : IFrameWorkDb
    {

        SqlSugarClient db = null;
        public FrameWorkMySqlDb(string connstring)
        {
            if (string.IsNullOrEmpty(connstring.Trim())) throw new Exception("连接字符串不能为空");
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ReadConnString.Connstring, //必填
                DbType = SqlSugar.DbType.MySql, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }); //默认SystemTable
        }



        public DataTable GetDBS()
        {
            throw new NotImplementedException();
        }

        public List<DbTableInfo> GetTables()
        {
            throw new NotImplementedException();
        }

        public List<DbTableInfo> GetViews()
        {
            throw new NotImplementedException();
        }

        public List<ColumnInfo> GetColumsFromTable(string TableName)
        {
            throw new NotImplementedException();
        }

        public List<ColumnInfo> GetColumsFromView(string ViewName)
        {
            throw new NotImplementedException();
        }
    }
}
