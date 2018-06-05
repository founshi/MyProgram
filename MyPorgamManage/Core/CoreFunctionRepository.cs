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
    public class CoreFunctionRepository : IBaseCore<FunctionRepository>
    {
        ServiceFunctionRepository _ServiceFunctionRepository = new ServiceFunctionRepository();

        public ISugarQueryable<FunctionRepository> LoadEntities(Expression<Func<FunctionRepository, bool>> whereLambda)
        {
            return _ServiceFunctionRepository.LoadEntities(whereLambda);
        }

        public ISugarQueryable<FunctionRepository> LoadEntities(Expression<Func<FunctionRepository, bool>> whereLambda, Expression<Func<FunctionRepository, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            return _ServiceFunctionRepository.LoadEntities(whereLambda, orderExpression, type);
        }

        public List<FunctionRepository> LoadPageList(Expression<Func<FunctionRepository, bool>> whereLambda, Expression<Func<FunctionRepository, object>> orderExpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            return _ServiceFunctionRepository.LoadPageList(whereLambda, orderExpression, type, pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return _ServiceFunctionRepository.LoadEntitiesBySql(sql, parameters);
        }
        public int AddEntity(FunctionRepository t)
        {
            return _ServiceFunctionRepository.AddEntity(t);
        }
        public int AddEntitys(List<FunctionRepository> _list)
        {
            return _ServiceFunctionRepository.AddEntitys(_list);
        }
        public int UpdateEntity(FunctionRepository t)
        {
            return _ServiceFunctionRepository.UpdateEntity(t);
        }
        public int UpdateEntityBySomeColums(FunctionRepository t, Expression<Func<FunctionRepository, object>> columns)
        {
            return _ServiceFunctionRepository.UpdateEntityBySomeColums(t, columns);
        }

        public int UpdateEntityByIgnoreColumns(FunctionRepository t, Expression<Func<FunctionRepository, object>> columns)
        {
            return _ServiceFunctionRepository.UpdateEntityByIgnoreColumns(t, columns);
        }

        public int DeleteEntity(FunctionRepository t)
        {
            return _ServiceFunctionRepository.DeleteEntity(t);
        }
        public int DeleteEntitys(List<FunctionRepository> _list)
        {
            return _ServiceFunctionRepository.DeleteEntitys(_list);
        }
        public int DeleteEntityBySomeColum(FunctionRepository t, Expression<Func<FunctionRepository, bool>> whereExpression)
        {
            return _ServiceFunctionRepository.DeleteEntityBySomeColum(t, whereExpression);
        }

        public int DeleteEntitysBySomeColum(List<FunctionRepository> _list, params Expression<Func<FunctionRepository, bool>>[] whereExpression)
        {
            return _ServiceFunctionRepository.DeleteEntitysBySomeColum(_list, whereExpression);
        }

        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _ServiceFunctionRepository.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            return _ServiceFunctionRepository.ExecuteCommand(sqlArray, parameters);
        }

    }

}