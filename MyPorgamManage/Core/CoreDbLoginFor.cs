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
    public class CoreDbLoginFor : IBaseCore<DbLoginFor>
    {
        ServiceDbLoginFor _ServiceDbLoginFor = new ServiceDbLoginFor();

        public ISugarQueryable<DbLoginFor> LoadEntities(Expression<Func<DbLoginFor, bool>> whereLambda)
        {
            return _ServiceDbLoginFor.LoadEntities(whereLambda);
        }

        public ISugarQueryable<DbLoginFor> LoadEntities(Expression<Func<DbLoginFor, bool>> whereLambda, Expression<Func<DbLoginFor, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            return _ServiceDbLoginFor.LoadEntities(whereLambda, orderExpression, type);
        }

        public List<DbLoginFor> LoadPageList(Expression<Func<DbLoginFor, bool>> whereLambda, Expression<Func<DbLoginFor, object>> orderExpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            return _ServiceDbLoginFor.LoadPageList(whereLambda, orderExpression, type, pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return _ServiceDbLoginFor.LoadEntitiesBySql(sql, parameters);
        }
        public int AddEntity(DbLoginFor t)
        {
            return _ServiceDbLoginFor.AddEntity(t);
        }
        public int AddEntitys(List<DbLoginFor> _list)
        {
            return _ServiceDbLoginFor.AddEntitys(_list);
        }
        public int UpdateEntity(DbLoginFor t)
        {
            return _ServiceDbLoginFor.UpdateEntity(t);
        }
        public int UpdateEntityBySomeColums(DbLoginFor t, Expression<Func<DbLoginFor, object>> columns)
        {
            return _ServiceDbLoginFor.UpdateEntityBySomeColums(t, columns);
        }

        public int UpdateEntityByIgnoreColumns(DbLoginFor t, Expression<Func<DbLoginFor, object>> columns)
        {
            return _ServiceDbLoginFor.UpdateEntityByIgnoreColumns(t, columns);
        }

        public int DeleteEntity(DbLoginFor t)
        {
            return _ServiceDbLoginFor.DeleteEntity(t);
        }
        public int DeleteEntitys(List<DbLoginFor> _list)
        {
            return _ServiceDbLoginFor.DeleteEntitys(_list);
        }

        public int DeleteEntityBySomeColum(DbLoginFor t, Expression<Func<DbLoginFor, bool>> whereExpression)
        {
            return _ServiceDbLoginFor.DeleteEntityBySomeColum(t, whereExpression);
        }

        public int DeleteEntitysBySomeColum(List<DbLoginFor> _list, params Expression<Func<DbLoginFor, bool>>[] whereExpression)
        {
            return _ServiceDbLoginFor.DeleteEntitysBySomeColum(_list, whereExpression);
        }

        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _ServiceDbLoginFor.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            return _ServiceDbLoginFor.ExecuteCommand(sqlArray, parameters);
        }

    }

}
