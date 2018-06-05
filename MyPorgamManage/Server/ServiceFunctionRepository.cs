using System;
using System.Collections.Generic;
using IServer;
using SqlSugar;
using System.Data;
using System.Linq.Expressions;
using Entity;
namespace Server
{
    /// <summary>
    /// DLL层 
    /// </summary>
    /// <summary>
    /// DLL层 
    /// </summary>
    public class ServiceFunctionRepository : IBaseService<FunctionRepository>
    {
        SqlSugarClient db = null;
        public ServiceFunctionRepository()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ReadConnString.Connstring, //必填
                DbType = SqlSugar.DbType.Sqlite, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }); //默认SystemTable
        }

        public ISugarQueryable<FunctionRepository> LoadEntities(Expression<Func<FunctionRepository, bool>> whereLambda)
        {
            return db.Queryable<FunctionRepository>().WhereIF(whereLambda != null, whereLambda);
        }
        public ISugarQueryable<FunctionRepository> LoadEntities(Expression<Func<FunctionRepository, bool>> whereLambda, Expression<Func<FunctionRepository, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            if (null == orderExpression) throw new Exception("排序表达式不能为空");
            return db.Queryable<FunctionRepository>().WhereIF(whereLambda != null, whereLambda).OrderBy(orderExpression, type);
        }


        public List<FunctionRepository> LoadPageList(Expression<Func<FunctionRepository, bool>> whereLambda, Expression<Func<FunctionRepository, object>> Orderexpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            if (null == Orderexpression)
                throw new Exception("排序表达式不能为空");
            return db.Queryable<FunctionRepository>().WhereIF(whereLambda != null, whereLambda).OrderBy(Orderexpression, type).ToPageList(pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return db.Ado.GetDataTable(sql, parameters);
        }
        public int AddEntity(FunctionRepository t)
        {
            return db.Insertable(t).ExecuteCommand();
        }

        public int AddEntitys(List<FunctionRepository> _list)
        {
            int ExcuteVal = 0;
            try
            {
                db.Ado.BeginTran();
                //操作
                foreach (var item in _list)
                {
                    db.Insertable(item).ExecuteCommand();
                    ExcuteVal++;
                }
                db.Ado.CommitTran();
            }
            catch (Exception ex)
            {
                ExcuteVal = 0;
                db.Ado.RollbackTran();
                throw ex;
            }
            return ExcuteVal;
        }
        public int UpdateEntity(FunctionRepository t)
        {
            return db.Updateable(t).ExecuteCommand();
        }
        public int UpdateEntityBySomeColums(FunctionRepository t, Expression<Func<FunctionRepository, object>> columns)
        {
            if (null == columns)
                throw new Exception("更新列表达式不能为空");
            return db.Updateable(t).UpdateColumns(columns).ExecuteCommand();
        }

        public int UpdateEntityByIgnoreColumns(FunctionRepository t, Expression<Func<FunctionRepository, object>> columns)
        {
            if (null == columns)
                throw new Exception("忽略更新列表达式不能为空");
            return db.Updateable(t).IgnoreColumns(columns).ExecuteCommand();
        }

        public int DeleteEntity(FunctionRepository t)
        {
            return db.Deleteable(t).ExecuteCommand();
        }

        public int DeleteEntitys(List<FunctionRepository> _list)
        {
            int ExcuteVal = 0;
            try
            {
                db.Ado.BeginTran();
                //操作
                foreach (var item in _list)
                {
                    db.Deleteable(item).ExecuteCommand();
                    ExcuteVal++;
                }
                db.Ado.CommitTran();
            }
            catch (Exception ex)
            {
                ExcuteVal = 0;
                db.Ado.RollbackTran();
                throw ex;
            }
            return ExcuteVal;
        }
        	public int DeleteEntityBySomeColum(FunctionRepository t, Expression<Func<FunctionRepository, bool>> whereExpression)
        {
            return db.Deleteable<FunctionRepository>().Where(whereExpression).ExecuteCommand();
        }

            public int DeleteEntitysBySomeColum(List<FunctionRepository> _list, params Expression<Func<FunctionRepository, bool>>[] whereExpression)
            {
                Expression<Func<FunctionRepository, bool>> _tmp = null;
                if (null == whereExpression) throw new Exception("删除条件不可为空");
                if (whereExpression.Length == 0) throw new Exception("删除条件不可为空");
                int ExcuteVal = 0;
                try
                {
                    db.Ado.BeginTran();
                    for (int i = 0; i < _list.Count; i++)
                    {
                        if (i > whereExpression.Length)
                        {
                            _tmp = whereExpression[whereExpression.Length];
                        }
                        else
                        {
                            _tmp = whereExpression[i];
                        }

                        db.Deleteable<FunctionRepository>().Where(_tmp).ExecuteCommand();
                    }
                    db.Ado.CommitTran();
                }
                catch (Exception ex)
                {
                    ExcuteVal = 0;
                    db.Ado.RollbackTran();
                    throw ex;
                }
                return ExcuteVal;
            }
        
        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return db.Ado.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            if (sqlArray.Length != parameters.Length)
            {
                throw new Exception("sql语句和参数维数不匹配!!!");
            }
            int ExcuteVal = 0;
            try
            {
                db.Ado.BeginTran();
                //操作
                for (int i = 0; i < sqlArray.Length; i++)
                {
                    db.Ado.ExecuteCommand(sqlArray[i], parameters[i]);
                    ExcuteVal++;
                }
                db.Ado.CommitTran();
            }
            catch (Exception ex)
            {
                ExcuteVal = 0;
                db.Ado.RollbackTran();
                throw ex;
            }
            return ExcuteVal;
        }
    }

}