using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public class ServerGetTime
    {
        SqlSugarClient db = null;
        public ServerGetTime()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ReadConnString.Connstring, //必填
                DbType = SqlSugar.DbType.Sqlite, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }); //默认SystemTable
        }
        public DateTime GetNow()
        {
            //将格林威治时间转成本地时间
            return db.Ado.GetDateTime("select datetime('now','localtime')", new List<SugarParameter>());
        }


    }
}
