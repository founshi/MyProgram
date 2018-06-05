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

    public class CoreProg_WRT : IBaseCore<Prog_WRT>
    {
        ServiceProg_WRT _ServiceProg_WRT = new ServiceProg_WRT();

        public ISugarQueryable<Prog_WRT> LoadEntities(Expression<Func<Prog_WRT, bool>> whereLambda)
        {
            return _ServiceProg_WRT.LoadEntities(whereLambda);
        }

        public ISugarQueryable<Prog_WRT> LoadEntities(Expression<Func<Prog_WRT, bool>> whereLambda, Expression<Func<Prog_WRT, object>> orderExpression, OrderByType type = OrderByType.Asc)
        {
            return _ServiceProg_WRT.LoadEntities(whereLambda, orderExpression, type);
        }

        public List<Prog_WRT> LoadPageList(Expression<Func<Prog_WRT, bool>> whereLambda, Expression<Func<Prog_WRT, object>> orderExpression, OrderByType type, int pageIndex, int pageSize, ref int totalNumber)
        {
            return _ServiceProg_WRT.LoadPageList(whereLambda, orderExpression, type, pageIndex, pageSize, ref totalNumber);
        }


        public DataTable LoadEntitiesBySql(string sql, List<SugarParameter> parameters)
        {
            return _ServiceProg_WRT.LoadEntitiesBySql(sql, parameters);
        }
        public int AddEntity(Prog_WRT t)
        {
            return _ServiceProg_WRT.AddEntity(t);
        }
        public int AddEntitys(List<Prog_WRT> _list)
        {
            return _ServiceProg_WRT.AddEntitys(_list);
        }
        public int UpdateEntity(Prog_WRT t)
        {
            return _ServiceProg_WRT.UpdateEntity(t);
        }
        public int UpdateEntityBySomeColums(Prog_WRT t, Expression<Func<Prog_WRT, object>> columns)
        {
            return _ServiceProg_WRT.UpdateEntityBySomeColums(t, columns);
        }

        public int UpdateEntityByIgnoreColumns(Prog_WRT t, Expression<Func<Prog_WRT, object>> columns)
        {
            return _ServiceProg_WRT.UpdateEntityByIgnoreColumns(t, columns);
        }

        public int DeleteEntity(Prog_WRT t)
        {
            return _ServiceProg_WRT.DeleteEntity(t);
        }
        public int DeleteEntitys(List<Prog_WRT> _list)
        {
            return _ServiceProg_WRT.DeleteEntitys(_list);
        }

        public int DeleteEntityBySomeColum(Prog_WRT t, Expression<Func<Prog_WRT, bool>> whereExpression)
        {
            return _ServiceProg_WRT.DeleteEntityBySomeColum(t, whereExpression);
        }

        public int DeleteEntitysBySomeColum(List<Prog_WRT> _list, params Expression<Func<Prog_WRT, bool>>[] whereExpression)
        {
            return _ServiceProg_WRT.DeleteEntitysBySomeColum(_list, whereExpression);
        }

        public int ExecuteCommand(string sql, List<SugarParameter> parameters)
        {
            return _ServiceProg_WRT.ExecuteCommand(sql, parameters);
        }
        public int ExecuteCommand(string[] sqlArray, List<SugarParameter>[] parameters)
        {
            return _ServiceProg_WRT.ExecuteCommand(sqlArray, parameters);
        }

    }

}