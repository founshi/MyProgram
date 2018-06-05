using Entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Server.DbFrameWork
{

    public class FrameWorkSqlServer2008Db : IFrameWorkDb
    {
        SqlSugarClient db = null;
        public FrameWorkSqlServer2008Db(string connstring)
        {
            if (string.IsNullOrEmpty(connstring.Trim())) throw new Exception("连接字符串不能为空");
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connstring, //必填
                DbType = SqlSugar.DbType.SqlServer, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }); //默认SystemTable
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        public DataTable GetDBS()
        {
            string sqldb = " select name,user_name() cuser,'DB' type,crdate dates from sysdatabases  order by name";
            return db.Ado.GetDataTable(sqldb, new List<SugarParameter>());
        }
        /// <summary>
        /// 获取数据库中所有的表
        /// </summary>
        /// <returns></returns>
        public List<DbTableInfo> GetTables()
        {
            return db.DbMaintenance.GetTableInfoList(false);
            #region 获取所有表的原生SQL
            //string sqldb = "  select [name] from sysobjects where xtype='U'and [name]<>'dtproperties' order by [name]";
            //    return db.Ado.GetDataTable(sqldb, new List<SugarParameter>());
            #endregion
        }
        /// <summary>
        /// 获得所有的视图
        /// </summary>
        /// <returns></returns>
        public List<DbTableInfo> GetViews()
        {
            return db.DbMaintenance.GetViewInfoList(false);
            #region 获得所有的视图
            //string sqldb = "select [name] from sysobjects where xtype='V' and [name]<>'syssegments' and [name]<>'sysconstraints' order by [name]";
            //return db.Ado.GetDataTable(sqldb, new List<SugarParameter>());
            #endregion
        }
        /// <summary>
        /// 获取表中列的信息信息
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
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
            //return db.DbMaintenance.GetColumnInfosByTableName(TableName);
            #region 获取所有的表的原生SQL
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("SELECT distinct * from (select ");
            //stringBuilder.Append("colorder=C.column_id,");
            //stringBuilder.Append("ColumnName=C.name,");
            //stringBuilder.Append("deText=ISNULL(PFD.[value],N''),");
            //stringBuilder.Append("TypeName=T.name, ");
            //stringBuilder.Append("Length=C.max_length, ");
            //stringBuilder.Append("Preci=C.precision, ");
            //stringBuilder.Append("Scale=C.scale, ");
            //stringBuilder.Append("IsIdentity=CASE WHEN C.is_identity=1 THEN N'√'ELSE N'' END,");
            //stringBuilder.Append("isPK=ISNULL(IDX.PrimaryKey,N''),");
            //stringBuilder.Append("Computed=CASE WHEN C.is_computed=1 THEN N'√'ELSE N'' END, ");
            //stringBuilder.Append("IndexName=ISNULL(IDX.IndexName,N''), ");
            //stringBuilder.Append("IndexSort=ISNULL(IDX.Sort,N''), ");
            //stringBuilder.Append("Create_Date=O.Create_Date, ");
            //stringBuilder.Append("Modify_Date=O.Modify_date, ");
            //stringBuilder.Append("cisNull=CASE WHEN C.is_nullable=1 THEN N'√'ELSE N'' END, ");
            //stringBuilder.Append("defaultVal=ISNULL(D.definition,N'') ");
            //stringBuilder.Append("FROM sys.columns C ");
            //stringBuilder.Append("INNER JOIN sys.objects O ");
            //stringBuilder.Append("ON C.[object_id]=O.[object_id] ");
            //stringBuilder.Append("AND (O.type='U' or O.type='V') ");
            //stringBuilder.Append("AND O.is_ms_shipped=0 ");
            //stringBuilder.Append("INNER JOIN sys.types T ");
            //stringBuilder.Append("ON C.user_type_id=T.user_type_id ");
            //stringBuilder.Append("LEFT JOIN sys.default_constraints D ");
            //stringBuilder.Append("ON C.[object_id]=D.parent_object_id ");
            //stringBuilder.Append("AND C.column_id=D.parent_column_id ");
            //stringBuilder.Append("AND C.default_object_id=D.[object_id] ");
            //stringBuilder.Append("LEFT JOIN sys.extended_properties PFD ");
            //stringBuilder.Append("ON PFD.class=1  ");
            //stringBuilder.Append("AND C.[object_id]=PFD.major_id  ");
            //stringBuilder.Append("AND C.column_id=PFD.minor_id ");
            //stringBuilder.Append("LEFT JOIN sys.extended_properties PTB ");
            //stringBuilder.Append("ON PTB.class=1 ");
            //stringBuilder.Append("AND PTB.minor_id=0  ");
            //stringBuilder.Append("AND C.[object_id]=PTB.major_id ");
            //stringBuilder.Append("LEFT JOIN ");
            //stringBuilder.Append("( ");
            //stringBuilder.Append("SELECT  ");
            //stringBuilder.Append("IDXC.[object_id], ");
            //stringBuilder.Append("IDXC.column_id, ");
            //stringBuilder.Append("Sort=CASE INDEXKEY_PROPERTY(IDXC.[object_id],IDXC.index_id,IDXC.index_column_id,'IsDescending') ");
            //stringBuilder.Append("WHEN 1 THEN 'DESC' WHEN 0 THEN 'ASC' ELSE '' END, ");
            //stringBuilder.Append("PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'√'ELSE N'' END, ");
            //stringBuilder.Append("IndexName=IDX.Name ");
            //stringBuilder.Append("FROM sys.indexes IDX ");
            //stringBuilder.Append("INNER JOIN sys.index_columns IDXC ");
            //stringBuilder.Append("ON IDX.[object_id]=IDXC.[object_id] ");
            //stringBuilder.Append("AND IDX.index_id=IDXC.index_id ");
            //stringBuilder.Append("LEFT JOIN sys.key_constraints KC ");
            //stringBuilder.Append("ON IDX.[object_id]=KC.[parent_object_id] ");
            //stringBuilder.Append("AND IDX.index_id=KC.unique_index_id ");
            //stringBuilder.Append("INNER JOIN  ");
            //stringBuilder.Append("( ");
            //stringBuilder.Append("SELECT [object_id], Column_id, index_id=MIN(index_id) ");
            //stringBuilder.Append("FROM sys.index_columns ");
            //stringBuilder.Append("GROUP BY [object_id], Column_id ");
            //stringBuilder.Append(") IDXCUQ ");
            //stringBuilder.Append("ON IDXC.[object_id]=IDXCUQ.[object_id] ");
            //stringBuilder.Append("AND IDXC.Column_id=IDXCUQ.Column_id ");
            //stringBuilder.Append("AND IDXC.index_id=IDXCUQ.index_id ");
            //stringBuilder.Append(") IDX ");
            //stringBuilder.Append("ON C.[object_id]=IDX.[object_id] ");
            //stringBuilder.Append("AND C.column_id=IDX.column_id  ");
            //stringBuilder.Append("WHERE O.name=N'" + TableName + "' ) as t ");
            //stringBuilder.Append("ORDER BY colorder,ColumnName  ");
            //return db.Ado.GetDataTable(stringBuilder.ToString(), new List<SugarParameter>());
            #endregion
        }
        /// <summary>
        /// 获取视图中的每一列的详细信息
        /// </summary>
        /// <param name="ViewName"></param>
        /// <returns></returns>
        public List<ColumnInfo> GetColumsFromView(string ViewName)
        {
            List<ColumnInfo> _mlist = new List<ColumnInfo>();
            List<DbColumnInfo> _dbList = db.DbMaintenance.GetColumnInfosByTableName(ViewName);
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
            //return db.DbMaintenance.GetColumnInfosByTableName(ViewName);
            #region 获取视图详细信息的原生态SQL
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("SELECT distinct * from (select ");
            //stringBuilder.Append("colorder=C.column_id,");
            //stringBuilder.Append("ColumnName=C.name,");
            //stringBuilder.Append("deText=ISNULL(PFD.[value],N''),");
            //stringBuilder.Append("TypeName=T.name, ");
            //stringBuilder.Append("Length=C.max_length, ");
            //stringBuilder.Append("Preci=C.precision, ");
            //stringBuilder.Append("Scale=C.scale, ");
            //stringBuilder.Append("IsIdentity=CASE WHEN C.is_identity=1 THEN N'√'ELSE N'' END,");
            //stringBuilder.Append("isPK=ISNULL(IDX.PrimaryKey,N''),");
            //stringBuilder.Append("Computed=CASE WHEN C.is_computed=1 THEN N'√'ELSE N'' END, ");
            //stringBuilder.Append("IndexName=ISNULL(IDX.IndexName,N''), ");
            //stringBuilder.Append("IndexSort=ISNULL(IDX.Sort,N''), ");
            //stringBuilder.Append("Create_Date=O.Create_Date, ");
            //stringBuilder.Append("Modify_Date=O.Modify_date, ");
            //stringBuilder.Append("cisNull=CASE WHEN C.is_nullable=1 THEN N'√'ELSE N'' END, ");
            //stringBuilder.Append("defaultVal=ISNULL(D.definition,N'') ");
            //stringBuilder.Append("FROM sys.columns C ");
            //stringBuilder.Append("INNER JOIN sys.objects O ");
            //stringBuilder.Append("ON C.[object_id]=O.[object_id] ");
            //stringBuilder.Append("AND (O.type='U' or O.type='V') ");
            //stringBuilder.Append("AND O.is_ms_shipped=0 ");
            //stringBuilder.Append("INNER JOIN sys.types T ");
            //stringBuilder.Append("ON C.user_type_id=T.user_type_id ");
            //stringBuilder.Append("LEFT JOIN sys.default_constraints D ");
            //stringBuilder.Append("ON C.[object_id]=D.parent_object_id ");
            //stringBuilder.Append("AND C.column_id=D.parent_column_id ");
            //stringBuilder.Append("AND C.default_object_id=D.[object_id] ");
            //stringBuilder.Append("LEFT JOIN sys.extended_properties PFD ");
            //stringBuilder.Append("ON PFD.class=1  ");
            //stringBuilder.Append("AND C.[object_id]=PFD.major_id  ");
            //stringBuilder.Append("AND C.column_id=PFD.minor_id ");
            //stringBuilder.Append("LEFT JOIN sys.extended_properties PTB ");
            //stringBuilder.Append("ON PTB.class=1 ");
            //stringBuilder.Append("AND PTB.minor_id=0  ");
            //stringBuilder.Append("AND C.[object_id]=PTB.major_id ");
            //stringBuilder.Append("LEFT JOIN ");
            //stringBuilder.Append("( ");
            //stringBuilder.Append("SELECT  ");
            //stringBuilder.Append("IDXC.[object_id], ");
            //stringBuilder.Append("IDXC.column_id, ");
            //stringBuilder.Append("Sort=CASE INDEXKEY_PROPERTY(IDXC.[object_id],IDXC.index_id,IDXC.index_column_id,'IsDescending') ");
            //stringBuilder.Append("WHEN 1 THEN 'DESC' WHEN 0 THEN 'ASC' ELSE '' END, ");
            //stringBuilder.Append("PrimaryKey=CASE WHEN IDX.is_primary_key=1 THEN N'√'ELSE N'' END, ");
            //stringBuilder.Append("IndexName=IDX.Name ");
            //stringBuilder.Append("FROM sys.indexes IDX ");
            //stringBuilder.Append("INNER JOIN sys.index_columns IDXC ");
            //stringBuilder.Append("ON IDX.[object_id]=IDXC.[object_id] ");
            //stringBuilder.Append("AND IDX.index_id=IDXC.index_id ");
            //stringBuilder.Append("LEFT JOIN sys.key_constraints KC ");
            //stringBuilder.Append("ON IDX.[object_id]=KC.[parent_object_id] ");
            //stringBuilder.Append("AND IDX.index_id=KC.unique_index_id ");
            //stringBuilder.Append("INNER JOIN  ");
            //stringBuilder.Append("( ");
            //stringBuilder.Append("SELECT [object_id], Column_id, index_id=MIN(index_id) ");
            //stringBuilder.Append("FROM sys.index_columns ");
            //stringBuilder.Append("GROUP BY [object_id], Column_id ");
            //stringBuilder.Append(") IDXCUQ ");
            //stringBuilder.Append("ON IDXC.[object_id]=IDXCUQ.[object_id] ");
            //stringBuilder.Append("AND IDXC.Column_id=IDXCUQ.Column_id ");
            //stringBuilder.Append("AND IDXC.index_id=IDXCUQ.index_id ");
            //stringBuilder.Append(") IDX ");
            //stringBuilder.Append("ON C.[object_id]=IDX.[object_id] ");
            //stringBuilder.Append("AND C.column_id=IDX.column_id  ");
            //stringBuilder.Append("WHERE O.name=N'" + ViewName + "' ) as t ");
            //stringBuilder.Append("ORDER BY colorder,ColumnName  ");
            //return db.Ado.GetDataTable(stringBuilder.ToString(), new List<SugarParameter>());
            #endregion
        }
        /// <summary>
        /// 获取所有的存储过程
        /// </summary>
        /// <returns></returns>
        public DataTable GetProcs()
        {
            string sqldb = "select [name] from sysobjects where xtype='P'and [name]<>'dtproperties' order by [name]";

            return db.Ado.GetDataTable(sqldb, new List<SugarParameter>());
        }





    }
}
