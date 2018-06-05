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

    public class CoreUser_MST : IBaseCore<User_MST>
    {
        ServiceUser_MST _ServiceUser_MST = new ServiceUser_MST();

        public ISugarQueryable<User_MST> LoadEntities(Expression<Func<User_MST, bool>> whereLambda)
        {
            return _ServiceUser_MST.LoadEntities(whereLambda);
        }

        public ISugarQueryable<User_MST> LoadEntities(Expression<Func<User_MST, bool>> whereLambda, Expression<Func<User_MST, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            return _ServiceUser_MST.LoadEntities(whereLambda, orderExpression, type);
        }

        public List<User_MST> LoadPageList(Expression<Func<User_MST, bool>> whereLambda, Expression<Func<User_MST, object>> orderExpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            return _ServiceUser_MST.LoadPageList(whereLambda, orderExpression, type, pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return _ServiceUser_MST.LoadEntitiesBySql(sql, parameters);
        }
        public int AddEntity(User_MST t)
        {
            return _ServiceUser_MST.AddEntity(t);
        }
        public int AddEntitys(List<User_MST> _list)
        {
            return _ServiceUser_MST.AddEntitys(_list);
        }
        public int UpdateEntity(User_MST t)
        {
            return _ServiceUser_MST.UpdateEntity(t);
        }
        public int UpdateEntityBySomeColums(User_MST t, Expression<Func<User_MST, object>> columns)
        {
            return _ServiceUser_MST.UpdateEntityBySomeColums(t, columns);
        }

        public int UpdateEntityByIgnoreColumns(User_MST t, Expression<Func<User_MST, object>> columns)
        {
            return _ServiceUser_MST.UpdateEntityByIgnoreColumns(t, columns);
        }

        public int DeleteEntity(User_MST t)
        {
            return _ServiceUser_MST.DeleteEntity(t);
        }
        public int DeleteEntitys(List<User_MST> _list)
        {
            return _ServiceUser_MST.DeleteEntitys(_list);
        }
        public int DeleteEntityBySomeColum(User_MST t, Expression<Func<User_MST, bool>> whereExpression)
        {
            return _ServiceUser_MST.DeleteEntityBySomeColum(t, whereExpression);
        }

        public int DeleteEntitysBySomeColum(List<User_MST> _list, params Expression<Func<User_MST, bool>>[] whereExpression)
        {
            return _ServiceUser_MST.DeleteEntitysBySomeColum(_list, whereExpression);
        }


        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _ServiceUser_MST.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            return _ServiceUser_MST.ExecuteCommand(sqlArray, parameters);
        }

    }

}