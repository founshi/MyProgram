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

    public class CoreProgList : IBaseCore<ProgList>
    {
        ServiceProgList _ServiceProgList = new ServiceProgList();

        public ISugarQueryable<ProgList> LoadEntities(Expression<Func<ProgList, bool>> whereLambda)
        {
            return _ServiceProgList.LoadEntities(whereLambda);
        }

        public ISugarQueryable<ProgList> LoadEntities(Expression<Func<ProgList, bool>> whereLambda, Expression<Func<ProgList, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            return _ServiceProgList.LoadEntities(whereLambda, orderExpression, type);
        }

        public List<ProgList> LoadPageList(Expression<Func<ProgList, bool>> whereLambda, Expression<Func<ProgList, object>> orderExpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            return _ServiceProgList.LoadPageList(whereLambda, orderExpression, type, pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return _ServiceProgList.LoadEntitiesBySql(sql, parameters);
        }
        public int AddEntity(ProgList t)
        {
            return _ServiceProgList.AddEntity(t);
        }
        public int AddEntitys(List<ProgList> _list)
        {
            return _ServiceProgList.AddEntitys(_list);
        }
        public int UpdateEntity(ProgList t)
        {
            return _ServiceProgList.UpdateEntity(t);
        }
        public int UpdateEntityBySomeColums(ProgList t, Expression<Func<ProgList, object>> columns)
        {
            return _ServiceProgList.UpdateEntityBySomeColums(t, columns);
        }

        public int UpdateEntityByIgnoreColumns(ProgList t, Expression<Func<ProgList, object>> columns)
        {
            return _ServiceProgList.UpdateEntityByIgnoreColumns(t, columns);
        }

        public int DeleteEntity(ProgList t)
        {
            return _ServiceProgList.DeleteEntity(t);
        }
        public int DeleteEntitys(List<ProgList> _list)
        {
            return _ServiceProgList.DeleteEntitys(_list);
        }
        public int DeleteEntityBySomeColum(ProgList t, Expression<Func<ProgList, bool>> whereExpression)
        {
            return _ServiceProgList.DeleteEntityBySomeColum(t, whereExpression);
        }

        public int DeleteEntitysBySomeColum(List<ProgList> _list, params Expression<Func<ProgList, bool>>[] whereExpression)
        {
            return _ServiceProgList.DeleteEntitysBySomeColum(_list, whereExpression);
        }

        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _ServiceProgList.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            return _ServiceProgList.ExecuteCommand(sqlArray, parameters);
        }

    }


}