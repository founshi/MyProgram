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

    public class CoreLoginUserPwd : IBaseCore<LoginUserPwd>
    {
        ServiceLoginUserPwd _ServiceLoginUserPwd = new ServiceLoginUserPwd();

        public ISugarQueryable<LoginUserPwd> LoadEntities(Expression<Func<LoginUserPwd, bool>> whereLambda)
        {
            return _ServiceLoginUserPwd.LoadEntities(whereLambda);
        }

        public ISugarQueryable<LoginUserPwd> LoadEntities(Expression<Func<LoginUserPwd, bool>> whereLambda, Expression<Func<LoginUserPwd, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            return _ServiceLoginUserPwd.LoadEntities(whereLambda, orderExpression, type);
        }

        public List<LoginUserPwd> LoadPageList(Expression<Func<LoginUserPwd, bool>> whereLambda, Expression<Func<LoginUserPwd, object>> orderExpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            return _ServiceLoginUserPwd.LoadPageList(whereLambda, orderExpression, type, pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return _ServiceLoginUserPwd.LoadEntitiesBySql(sql, parameters);
        }
        public int AddEntity(LoginUserPwd t)
        {
            return _ServiceLoginUserPwd.AddEntity(t);
        }
        public int AddEntitys(List<LoginUserPwd> _list)
        {
            return _ServiceLoginUserPwd.AddEntitys(_list);
        }
        public int UpdateEntity(LoginUserPwd t)
        {
            return _ServiceLoginUserPwd.UpdateEntity(t);
        }
        public int UpdateEntityBySomeColums(LoginUserPwd t, Expression<Func<LoginUserPwd, object>> columns)
        {
            return _ServiceLoginUserPwd.UpdateEntityBySomeColums(t, columns);
        }

        public int UpdateEntityByIgnoreColumns(LoginUserPwd t, Expression<Func<LoginUserPwd, object>> columns)
        {
            return _ServiceLoginUserPwd.UpdateEntityByIgnoreColumns(t, columns);
        }

        public int DeleteEntity(LoginUserPwd t)
        {
            return _ServiceLoginUserPwd.DeleteEntity(t);
        }
        public int DeleteEntitys(List<LoginUserPwd> _list)
        {
            return _ServiceLoginUserPwd.DeleteEntitys(_list);
        }
        public int DeleteEntityBySomeColum(LoginUserPwd t, Expression<Func<LoginUserPwd, bool>> whereExpression)
        {
            return _ServiceLoginUserPwd.DeleteEntityBySomeColum(t, whereExpression);
        }

        public int DeleteEntitysBySomeColum(List<LoginUserPwd> _list, params Expression<Func<LoginUserPwd, bool>>[] whereExpression)
        {
            return _ServiceLoginUserPwd.DeleteEntitysBySomeColum(_list, whereExpression);
        }


        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _ServiceLoginUserPwd.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            return _ServiceLoginUserPwd.ExecuteCommand(sqlArray, parameters);
        }

    }

}
