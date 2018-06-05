using System;
using System.Collections.Generic;
using ICore;
using SqlSugar;
using System.Data;
using System.Linq.Expressions;
using Server;
using Entity;

namespace Core
{
    public class CoreFunctionContext : IBaseCore<FunctionContext>
    {
        ServiceFunctionContext _ServiceFunctionContext = new ServiceFunctionContext();

        public ISugarQueryable<FunctionContext> LoadEntities(Expression<Func<FunctionContext, bool>> whereLambda)
        {
            return _ServiceFunctionContext.LoadEntities(whereLambda);
        }

        public ISugarQueryable<FunctionContext> LoadEntities(Expression<Func<FunctionContext, bool>> whereLambda, Expression<Func<FunctionContext, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            return _ServiceFunctionContext.LoadEntities(whereLambda, orderExpression, type);
        }

        public List<FunctionContext> LoadPageList(Expression<Func<FunctionContext, bool>> whereLambda, Expression<Func<FunctionContext, object>> orderExpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            return _ServiceFunctionContext.LoadPageList(whereLambda, orderExpression, type, pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return _ServiceFunctionContext.LoadEntitiesBySql(sql, parameters);
        }
        public int AddEntity(FunctionContext t)
        {
            return _ServiceFunctionContext.AddEntity(t);
        }
        public int AddEntitys(List<FunctionContext> _list)
        {
            return _ServiceFunctionContext.AddEntitys(_list);
        }
        public int UpdateEntity(FunctionContext t)
        {
            return _ServiceFunctionContext.UpdateEntity(t);
        }
        public int UpdateEntityBySomeColums(FunctionContext t, Expression<Func<FunctionContext, object>> columns)
        {
            return _ServiceFunctionContext.UpdateEntityBySomeColums(t, columns);
        }

        public int UpdateEntityByIgnoreColumns(FunctionContext t, Expression<Func<FunctionContext, object>> columns)
        {
            return _ServiceFunctionContext.UpdateEntityByIgnoreColumns(t, columns);
        }

        public int DeleteEntity(FunctionContext t)
        {
            return _ServiceFunctionContext.DeleteEntity(t);
        }
        public int DeleteEntitys(List<FunctionContext> _list)
        {
            return _ServiceFunctionContext.DeleteEntitys(_list);
        }

        public int DeleteEntityBySomeColum(FunctionContext t, Expression<Func<FunctionContext, bool>> whereExpression)
        {
            return _ServiceFunctionContext.DeleteEntityBySomeColum(t, whereExpression);
        }

        public int DeleteEntitysBySomeColum(List<FunctionContext> _list, params Expression<Func<FunctionContext, bool>>[] whereExpression)
        {
            return _ServiceFunctionContext.DeleteEntitysBySomeColum(_list, whereExpression);
        }

        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _ServiceFunctionContext.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            return _ServiceFunctionContext.ExecuteCommand(sqlArray, parameters);
        }

    }

}
