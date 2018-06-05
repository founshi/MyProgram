using System;
using System.Collections.Generic;

using IServer;
using SqlSugar;
using System.Data;
using System.Linq.Expressions;
using Entity;


namespace Server
{
    public class ServiceLoginUserPwd : IBaseService<LoginUserPwd>
    {
        SqlSugarClient db = null;
        public ServiceLoginUserPwd()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ReadConnString.Connstring, //必填
                DbType = SqlSugar.DbType.Sqlite, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }); //默认SystemTable
        }

        public ISugarQueryable<LoginUserPwd> LoadEntities(Expression<Func<LoginUserPwd, bool>> whereLambda)
        {
            return db.Queryable<LoginUserPwd>().WhereIF(whereLambda != null, whereLambda);
        }
        public ISugarQueryable<LoginUserPwd> LoadEntities(Expression<Func<LoginUserPwd, bool>> whereLambda, Expression<Func<LoginUserPwd, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            if (null == orderExpression) throw new Exception("排序表达式不能为空");
            return db.Queryable<LoginUserPwd>().WhereIF(whereLambda != null, whereLambda).OrderBy(orderExpression, type);
        }


        public List<LoginUserPwd> LoadPageList(Expression<Func<LoginUserPwd, bool>> whereLambda, Expression<Func<LoginUserPwd, object>> Orderexpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            if (null == Orderexpression)
                throw new Exception("排序表达式不能为空");
            return db.Queryable<LoginUserPwd>().WhereIF(whereLambda != null, whereLambda).OrderBy(Orderexpression, type).ToPageList(pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return db.Ado.GetDataTable(sql, parameters);
        }
        public int AddEntity(LoginUserPwd t)
        {
            return db.Insertable(t).ExecuteCommand();
        }

        public int AddEntitys(List<LoginUserPwd> _list)
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
        public int UpdateEntity(LoginUserPwd t)
        {
            return db.Updateable(t).ExecuteCommand();
        }

        public int UpdateEntityBySomeColums(LoginUserPwd t, Expression<Func<LoginUserPwd, object>> columns)
        {
            if (null == columns)
                throw new Exception("更新列表达式不能为空");            
            return db.Updateable(t).UpdateColumns(columns).ExecuteCommand();
        }

        public int UpdateEntityByIgnoreColumns(LoginUserPwd t, Expression<Func<LoginUserPwd, object>> columns)
        {
            if (null == columns)
                throw new Exception("忽略更新列表达式不能为空");
            return db.Updateable(t).IgnoreColumns(columns).ExecuteCommand();
        }

        public int DeleteEntity(LoginUserPwd t)
        {
            return db.Deleteable(t).ExecuteCommand();
        }

        public int DeleteEntitys(List<LoginUserPwd> _list)
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
        public int DeleteEntityBySomeColum(LoginUserPwd t, Expression<Func<LoginUserPwd, bool>> whereExpression)
        {
            return db.Deleteable<LoginUserPwd>().Where(whereExpression).ExecuteCommand();
        }

        public int DeleteEntitysBySomeColum(List<LoginUserPwd> _list, params Expression<Func<LoginUserPwd, bool>>[] whereExpression)
        {
            Expression<Func<LoginUserPwd, bool>> _tmp = null;
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

                    db.Deleteable<LoginUserPwd>().Where(_tmp).ExecuteCommand();
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
