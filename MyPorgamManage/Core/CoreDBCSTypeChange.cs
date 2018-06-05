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
    public class CoreDBCSTypeChange : IBaseCore<DBCSTypeChange>
    {
        ServiceDBCSTypeChange _ServiceTypeChange = new ServiceDBCSTypeChange();

        public ISugarQueryable<DBCSTypeChange> LoadEntities(Expression<Func<DBCSTypeChange, bool>> whereLambda)
        {
            return _ServiceTypeChange.LoadEntities(whereLambda);
        }

        public ISugarQueryable<DBCSTypeChange> LoadEntities(Expression<Func<DBCSTypeChange, bool>> whereLambda, Expression<Func<DBCSTypeChange, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            return _ServiceTypeChange.LoadEntities(whereLambda, orderExpression, type);
        }

        public List<DBCSTypeChange> LoadPageList(Expression<Func<DBCSTypeChange, bool>> whereLambda, Expression<Func<DBCSTypeChange, object>> orderExpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            return _ServiceTypeChange.LoadPageList(whereLambda, orderExpression, type, pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return _ServiceTypeChange.LoadEntitiesBySql(sql, parameters);
        }
        public int AddEntity(DBCSTypeChange t)
        {
            return _ServiceTypeChange.AddEntity(t);
        }
        public int AddEntitys(List<DBCSTypeChange> _list)
        {
            return _ServiceTypeChange.AddEntitys(_list);
        }
        public int UpdateEntity(DBCSTypeChange t)
        {
            return _ServiceTypeChange.UpdateEntity(t);
        }
        public int UpdateEntityBySomeColums(DBCSTypeChange t, Expression<Func<DBCSTypeChange, object>> columns)
        {
            return _ServiceTypeChange.UpdateEntityBySomeColums(t, columns);
        }

        public int UpdateEntityByIgnoreColumns(DBCSTypeChange t, Expression<Func<DBCSTypeChange, object>> columns)
        {
            return _ServiceTypeChange.UpdateEntityByIgnoreColumns(t, columns);
        }

        public int DeleteEntity(DBCSTypeChange t)
        {
            return _ServiceTypeChange.DeleteEntity(t);
        }
        public int DeleteEntitys(List<DBCSTypeChange> _list)
        {
            return _ServiceTypeChange.DeleteEntitys(_list);
        }

        public int DeleteEntityBySomeColum(DBCSTypeChange t, Expression<Func<DBCSTypeChange, bool>> whereExpression)
        {
            return _ServiceTypeChange.DeleteEntityBySomeColum(t, whereExpression);
        }

        public int DeleteEntitysBySomeColum(List<DBCSTypeChange> _list, params Expression<Func<DBCSTypeChange, bool>>[] whereExpression)
        {
            return _ServiceTypeChange.DeleteEntitysBySomeColum(_list, whereExpression);
        }

        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _ServiceTypeChange.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            return _ServiceTypeChange.ExecuteCommand(sqlArray, parameters);
        }

    }

}
