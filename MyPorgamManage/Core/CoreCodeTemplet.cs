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
    public class CoreCodeTemplet : IBaseCore<CodeTemplet>
    {
        ServiceCodeTemplet _ServiceCodeTemplet = new ServiceCodeTemplet();

        public ISugarQueryable<CodeTemplet> LoadEntities(Expression<Func<CodeTemplet, bool>> whereLambda)
        {
            return _ServiceCodeTemplet.LoadEntities(whereLambda);
        }

        public ISugarQueryable<CodeTemplet> LoadEntities(Expression<Func<CodeTemplet, bool>> whereLambda, Expression<Func<CodeTemplet, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            return _ServiceCodeTemplet.LoadEntities(whereLambda, orderExpression, type);
        }

        public List<CodeTemplet> LoadPageList(Expression<Func<CodeTemplet, bool>> whereLambda, Expression<Func<CodeTemplet, object>> orderExpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            return _ServiceCodeTemplet.LoadPageList(whereLambda, orderExpression, type, pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return _ServiceCodeTemplet.LoadEntitiesBySql(sql, parameters);
        }
        public int AddEntity(CodeTemplet t)
        {
            return _ServiceCodeTemplet.AddEntity(t);
        }
        public int AddEntitys(List<CodeTemplet> _list)
        {
            return _ServiceCodeTemplet.AddEntitys(_list);
        }
        public int UpdateEntity(CodeTemplet t)
        {
            return _ServiceCodeTemplet.UpdateEntity(t);
        }
        public int UpdateEntityBySomeColums(CodeTemplet t, Expression<Func<CodeTemplet, object>> columns)
        {
            return _ServiceCodeTemplet.UpdateEntityBySomeColums(t, columns);
        }

        public int UpdateEntityByIgnoreColumns(CodeTemplet t, Expression<Func<CodeTemplet, object>> columns)
        {
            return _ServiceCodeTemplet.UpdateEntityByIgnoreColumns(t, columns);
        }

        public int DeleteEntity(CodeTemplet t)
        {
            return _ServiceCodeTemplet.DeleteEntity(t);
        }
        public int DeleteEntitys(List<CodeTemplet> _list)
        {
            return _ServiceCodeTemplet.DeleteEntitys(_list);
        }

        public int DeleteEntityBySomeColum(CodeTemplet t, Expression<Func<CodeTemplet, bool>> whereExpression)
        {
            return _ServiceCodeTemplet.DeleteEntityBySomeColum(t, whereExpression);
        }

        public int DeleteEntitysBySomeColum(List<CodeTemplet> _list, params Expression<Func<CodeTemplet, bool>>[] whereExpression)
        {
            return _ServiceCodeTemplet.DeleteEntitysBySomeColum(_list, whereExpression);
        }

        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _ServiceCodeTemplet.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            return _ServiceCodeTemplet.ExecuteCommand(sqlArray, parameters);
        }

    }

}
