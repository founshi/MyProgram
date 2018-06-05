using Entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Server.DbFrameWork
{
    
    public class FrameWorkSqliteDb:IFrameWorkDb
    {
        SqlSugarClient db = null;

        public FrameWorkSqliteDb(string connstring)
        {
            if (string.IsNullOrEmpty(connstring.Trim())) throw new Exception("连接字符串不能为空");
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connstring, //必填
                DbType = SqlSugar.DbType.Sqlite, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }); //默认SystemTable
        }

        public DataTable GetDBS()
        {
            return null;
        }

        public List<DbTableInfo> GetTables()
        {
            return db.DbMaintenance.GetTableInfoList(false);
        }

        public List<DbTableInfo> GetViews()
        {
            return db.DbMaintenance.GetViewInfoList(false);
        }

        public List<ColumnInfo> GetColumsFromTable(string TableName)
        {
            List<ColumnInfo> _mlist = new List<ColumnInfo>();
            List<DbColumnInfo> _dbList = db.DbMaintenance.GetColumnInfosByTableName(TableName);
            for (int i = 0; i < _dbList.Count; i++)
            {
                ColumnInfo _ColumnInfo = new ColumnInfo();
                _ColumnInfo.cisNull = _dbList[i].IsNullable;
                _ColumnInfo.Colorder = (i + 1).ToString();
                _ColumnInfo.ColumnName = _dbList[i].DbColumnName;
                _ColumnInfo.ColumnNameRealName = _dbList[i].DbColumnName;
                _ColumnInfo.DefaultVal = _dbList[i].DefaultValue;
                _ColumnInfo.DeText = _dbList[i].ColumnDescription;
                _ColumnInfo.IsIdentity = _dbList[i].IsIdentity;
                _ColumnInfo.IsPK = _dbList[i].IsPrimarykey;
                _ColumnInfo.Length = _dbList[i].Length.ToString();
                _ColumnInfo.Preci = _dbList[i].DecimalDigits.ToString();
                _ColumnInfo.Scale = _dbList[i].Scale.ToString();
                _ColumnInfo.TypeName = _dbList[i].DataType;
                _mlist.Add(_ColumnInfo);
            }
            return _mlist;
        }

        public List<ColumnInfo> GetColumsFromView(string ViewName)
        {
            //return db.DbMaintenance.GetColumnInfosByTableName(ViewName);
            return null;
        }
    }
}
