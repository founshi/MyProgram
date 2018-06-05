using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess;
using Entity;
namespace Server.DbFrameWork
{
    public class FrameWorkOracleDb : IFrameWorkDb
    {
        SqlSugarClient db = null;
        public FrameWorkOracleDb(string connstring)
        {
            if (string.IsNullOrEmpty(connstring.Trim())) throw new Exception("连接字符串不能为空");
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connstring, //必填
                DbType = SqlSugar.DbType.Oracle, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }); //默认SystemTable
        }
        public DataTable GetDBS()
        {
            return null;
        }
        public DataTable GetProcs()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT DISTINCT NAME FROM ALL_SOURCE  where TYPE='PROCEDURE' and OWNER NOT IN('SYS','ORDSYS')");
            return db.Ado.GetDataTable(stringBuilder.ToString());
        }

        /// <summary>
        /// 获取所有的表
        /// </summary>
        /// <returns></returns>
        public List<DbTableInfo> GetTables()
        {
            #region 获取所有表的SQL语句
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("select TNAME name from tab where TABTYPE='TABLE' order by TNAME");
            //return db.Ado.GetDataTable(stringBuilder.ToString());
            #endregion
            return db.DbMaintenance.GetTableInfoList(false);
        }
        /// <summary>
        /// 获取所有的视图
        /// </summary>
        /// <returns></returns>
        public List<DbTableInfo> GetViews()
        {
            #region 获取所有视图的SQL
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("select TNAME name from tab where TABTYPE='VIEW' order by TNAME");
            //return db.Ado.GetDataTable(stringBuilder.ToString());
            #endregion
            return db.DbMaintenance.GetViewInfoList(false);
        }

        public List<ColumnInfo> GetColumsFromTable(string TableName)
        {
            #region 获取表的每列的详细信息SQL
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT ");
            stringBuilder.Append("A.COLUMN_ID as colorder,");
            stringBuilder.Append("A.COLUMN_NAME as ColumnName,");
            stringBuilder.Append("A.DATA_TYPE as TypeName,");
            stringBuilder.Append("A.DATA_LENGTH as Length,");
            stringBuilder.Append("A.DATA_PRECISION as Preci,");
            stringBuilder.Append("DATA_SCALE as Scale,");
            stringBuilder.Append("'' as IsIdentity,");
            stringBuilder.Append("'' as isPK,");
            stringBuilder.Append("A.NULLABLE as cisNull ,");
            stringBuilder.Append("A.DATA_DEFAULT as defaultVal, ");
            stringBuilder.Append("B.COMMENTS as deText ");
            stringBuilder.Append(" FROM USER_TAB_COLUMNS A, USER_COL_COMMENTS B ");
            stringBuilder.Append(" WHERE A.TABLE_NAME = B.TABLE_NAME AND A.COLUMN_NAME = B.COLUMN_NAME AND  A.TABLE_NAME ='" + TableName.ToUpper() + "'");
            stringBuilder.Append(" ORDER BY COLUMN_ID");

            var __table = db.Ado.GetDataTable(stringBuilder.ToString());

            StringBuilder __PkSql = new StringBuilder();
            __PkSql.Append("select column_name from user_constraints c,user_cons_columns col ");
            __PkSql.Append(" where c.constraint_name=col.constraint_name and c.constraint_type='P'");
            __PkSql.Append(" and c.table_name='");
            __PkSql.Append(TableName.ToUpper());
            __PkSql.Append("'");
            var __tablepk = db.Ado.GetDataTable(__PkSql.ToString());

            foreach (DataRow dataRow in __tablepk.Rows)
            {
                DataRow[] array = __table.Select("ColumnName='" + dataRow["column_name"].ToString() + "'");
                if (array != null && array.Length != 0)
                {
                    array[0]["isPK"] = "√";
                }
            }
            __table.AcceptChanges();
            List<ColumnInfo> _mlist = new List<ColumnInfo>();
            for (int i = 0; i < __table.Rows.Count; i++)
            {
                ColumnInfo _DbColumnInfo = new ColumnInfo();

                _DbColumnInfo.Colorder = __table.Rows[i]["COLORDER"].ToString();
                _DbColumnInfo.ColumnName = __table.Rows[i]["COLUMNNAME"].ToString();
                _DbColumnInfo.TypeName = __table.Rows[i]["TYPENAME"].ToString();
                _DbColumnInfo.Length = __table.Rows[i]["LENGTH"].ToString();
                _DbColumnInfo.Preci = __table.Rows[i]["PRECI"].ToString();
                _DbColumnInfo.Scale = __table.Rows[i]["SCALE"].ToString();             
                
                if (__table.Rows[i]["ISIDENTITY"].ToString() == "√")
                {
                    _DbColumnInfo.IsIdentity = true;
                }
                else
                {
                    _DbColumnInfo.IsIdentity = false;
                }
                if (__table.Rows[i]["ISPK"].ToString() == "√")
                {
                    _DbColumnInfo.IsPK = true;
                }
                else
                {
                    _DbColumnInfo.IsPK = false;
                }
                if (__table.Rows[i]["CISNULL"].ToString() == "N")
                {
                    _DbColumnInfo.cisNull = false;
                }
                else
                {
                    _DbColumnInfo.cisNull = true;
                }
                _DbColumnInfo.DefaultVal = __table.Rows[i]["DEFAULTVAL"].ToString();
                _DbColumnInfo.DeText = string.Empty;
                _mlist.Add(_DbColumnInfo);
            }           
            #endregion
            return _mlist;            
        }

        public List<ColumnInfo> GetColumsFromView(string ViewName)
        {
            #region 获取视图的每列的详细信息SQL 语句
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT ");
            stringBuilder.Append("A.COLUMN_ID as colorder,");
            stringBuilder.Append("A.COLUMN_NAME as ColumnName,");
            stringBuilder.Append("A.DATA_TYPE as TypeName,");
            stringBuilder.Append("A.DATA_LENGTH as Length,");
            stringBuilder.Append("A.DATA_PRECISION as Preci,");
            stringBuilder.Append("DATA_SCALE as Scale,");
            stringBuilder.Append("'' as IsIdentity,");
            stringBuilder.Append("'' as isPK,");
            stringBuilder.Append("A.NULLABLE as cisNull ,");
            stringBuilder.Append("A.DATA_DEFAULT as defaultVal, ");
            stringBuilder.Append("B.COMMENTS as deText ");
            stringBuilder.Append(" FROM USER_TAB_COLUMNS A, USER_COL_COMMENTS B ");
            stringBuilder.Append(" WHERE A.TABLE_NAME = B.TABLE_NAME AND A.COLUMN_NAME = B.COLUMN_NAME AND  A.TABLE_NAME ='" + ViewName.ToUpper() + "'");
            stringBuilder.Append(" ORDER BY COLUMN_ID");

            var __table = db.Ado.GetDataTable(stringBuilder.ToString());

            StringBuilder __PkSql = new StringBuilder();
            __PkSql.Append("select column_name from user_constraints c,user_cons_columns col ");
            __PkSql.Append(" where c.constraint_name=col.constraint_name and c.constraint_type='P'");
            __PkSql.Append(" and c.table_name='");
            __PkSql.Append(ViewName.ToUpper());
            __PkSql.Append("'");
            var __tablepk = db.Ado.GetDataTable(__PkSql.ToString());

            foreach (DataRow dataRow in __tablepk.Rows)
            {
                DataRow[] array = __table.Select("ColumnName='" + dataRow["column_name"].ToString() + "'");
                if (array != null && array.Length != 0)
                {
                    array[0]["isPK"] = "√";
                }
            }
            __table.AcceptChanges();
            List<ColumnInfo> _mlist = new List<ColumnInfo>();
            for (int i = 0; i < __table.Rows.Count; i++)
            {
                ColumnInfo _DbColumnInfo = new ColumnInfo();
                _DbColumnInfo.Colorder = __table.Rows[i]["COLORDER"].ToString();
                _DbColumnInfo.ColumnName = __table.Rows[i]["COLUMNNAME"].ToString();
                _DbColumnInfo.TypeName = __table.Rows[i]["TYPENAME"].ToString();
                _DbColumnInfo.Length = __table.Rows[i]["LENGTH"].ToString();
                _DbColumnInfo.Preci = __table.Rows[i]["PRECI"].ToString();
                _DbColumnInfo.Scale = __table.Rows[i]["SCALE"].ToString();

                if (__table.Rows[i]["ISIDENTITY"].ToString() == "√")
                {
                    _DbColumnInfo.IsIdentity = true;
                }
                else
                {
                    _DbColumnInfo.IsIdentity = false;
                }
                if (__table.Rows[i]["ISPK"].ToString() == "√")
                {
                    _DbColumnInfo.IsPK = true;
                }
                else
                {
                    _DbColumnInfo.IsPK = false;
                }
                if (__table.Rows[i]["CISNULL"].ToString() == "N")
                {
                    _DbColumnInfo.cisNull = false;
                }
                else
                {
                    _DbColumnInfo.cisNull = true;
                }
                _DbColumnInfo.DefaultVal = __table.Rows[i]["DEFAULTVAL"].ToString();
                _DbColumnInfo.DeText = string.Empty;
                _mlist.Add(_DbColumnInfo);
            }


            return _mlist;
            #endregion
            //return db.DbMaintenance.GetColumnInfosByTableName(ViewName);
        }
        private void WriteFile(string Path, string Strings)
        {

            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
                f.Dispose();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();
        }

    }
}
