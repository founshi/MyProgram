//using Oracle.ManagedDataAccess.Client;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;

//namespace MyFunctionTest
//{
//    public class ClassOracel
//    {
//        private string _SqlCnn;//连接字符串
//        private ArrayList _SqlList; //SQL语句集合数组
//        private List<OracleParameter[]> paramList;//参数的集合
//        #region 构造函数
//        public ClassOracel(string sqlcnn)
//        {
//            _SqlList = new ArrayList();
//            paramList = new List<OracleParameter[]>();//参数的集合
//            this._SqlCnn = sqlcnn;
//        }
//        public ClassOracel()
//        {
//            _SqlList = new ArrayList();
//            paramList = new List<OracleParameter[]>();//参数的集合
//        }
//        #endregion
//        #region  属性数据库连接字符串
//        public string Sqlconnection
//        {
//            get
//            {
//                return _SqlCnn;
//            }
//            set
//            {
//                _SqlCnn = value;
//            }

//        }
//        #endregion
//        #region 获取数据库表中的信息
//        /// <summary>
//        /// 通过SQL查询语句获取表中的信息,并返回在DataSet中
//        /// </summary>
//        /// <param name="sql">SQL查询语句</param>
//        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>
//        /// <param name="dst">返回值DataSet</param>
//        /// <returns>执行成功返回空,否则返回错误信息</returns>
//        public string GetDB(string sql, OracleParameter[] parameters, out DataSet dst)
//        {
//            dst = null;
//            OracleConnection conn = null;

//            OracleCommand commd = null;

//            try
//            {
//                if (string.IsNullOrEmpty(_SqlCnn.Trim()))
//                {
//                    return "数据库连接字符串不能为空.";
//                }
//                conn = new OracleConnection(_SqlCnn);
//                conn.Open();

//                commd = new OracleCommand(sql, conn);
//                if (parameters != null)
//                {
//                    commd.Parameters.AddRange(parameters);
//                }
//                OracleDataAdapter adapter = new OracleDataAdapter();
//                adapter.SelectCommand = commd;
//                dst = new DataSet();
//                adapter.Fill(dst);//给DataSet赋值
//                return string.Empty;
//            }
//            catch (Exception ex)
//            {
//                dst = null;
//                return ex.Message;
//            }
//            finally
//            {
//                if (commd != null) commd.Dispose();
//                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
//                if (conn != null) conn.Dispose();
//            }
//        }
//        /// <summary>
//        /// 通过SQL查询语句获取表中的信息,并返回在DataTable中
//        /// </summary>
//        /// <param name="sql">SQL查询语句</param>
//        /// <param name="parameters">执行SQL查询语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>
//        /// <param name="dst">返回值DataTable</param>
//        /// <returns>执行成功返回空,否则返回错误信息</returns>
//        public string GetDB(string sql, OracleParameter[] parameters, out DataTable dst)
//        {
//            dst = null;
//            OracleConnection conn = null;

//            OracleCommand commd = null;

//            try
//            {
//                if (string.IsNullOrEmpty(_SqlCnn.Trim()))
//                {
//                    return "数据库连接字符串不能为空.";
//                }
//                conn = new OracleConnection(_SqlCnn);
//                conn.Open();

//                commd = new OracleCommand(sql, conn);
//                if (parameters != null)
//                {
//                    commd.Parameters.AddRange(parameters);
//                }
//                OracleDataAdapter adapter = new OracleDataAdapter();
//                adapter.SelectCommand = commd;
//                dst = new DataTable();
//                adapter.Fill(dst);//给DataSet赋值
//                return string.Empty;
//            }
//            catch (Exception ex)
//            {
//                dst = null;
//                return ex.Message;
//            }
//            finally
//            {
//                if (commd != null) commd.Dispose();
//                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
//                if (conn != null) conn.Dispose();
//            }
//        }
//        #endregion
//        #region 执行单条SQL语句(增加,删除,修改)
//        /// <summary>
//        /// 执行单条SQL语句(增加,删除,修改)
//        /// </summary>
//        /// <param name="sql">需要执行的SQL语句</param>
//        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>
//        /// <param name="affectedRows">执行SQL语句后受影响的行数</param>
//        /// <returns>执行正常返回空,如果执行报错返回错误信息</returns>
//        public string ExecuteSql(string sql, OracleParameter[] parameters, ref int affectedRows)
//        {
//            OracleConnection conn = null;
//            OracleCommand commd = null;
//            try
//            {
//                if (string.IsNullOrEmpty(_SqlCnn.Trim()))
//                {
//                    affectedRows = 0;
//                    return "数据库连接字符串不能为空.";
//                }
//                if (string.IsNullOrEmpty(sql.Trim()))
//                {
//                    affectedRows = 0;
//                    return "SQL语句为空,执行失败.";
//                }
//                conn = new OracleConnection(_SqlCnn);
//                conn.Open();
//                commd = new OracleCommand();
//                commd.Connection = conn;
//                commd.CommandTimeout = 30;
//                commd.CommandType = CommandType.Text;
//                commd.CommandText = sql;
//                if (parameters != null)
//                {
//                    commd.Parameters.AddRange(parameters);
//                }
//                affectedRows = commd.ExecuteNonQuery();
//                return string.Empty;
//            }
//            catch (Exception ex)
//            {
//                affectedRows = 0;
//                return ex.Message;
//            }
//            finally
//            {
//                if (commd != null) commd.Dispose();
//                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
//                if (conn != null) conn.Dispose();
//            }
//        }
//        #endregion
//        #region 批量添加SQL语句(增加,删除,修改)或者参数
//        /// <summary>
//        /// 批量添加SQL语句(增加,删除,修改)
//        /// </summary>
//        /// <param name="sql">需要执行的SQL语句(增加,删除,修改)</param>
//        /// <returns></returns>
//        public string AddSql(string sql)
//        {
//            try
//            {
//                if (string.IsNullOrEmpty(sql.Trim()))
//                {
//                    return "添加的SQL语句不能为空.";
//                }
//                _SqlList.Add(sql);
//                return string.Empty;
//            }
//            catch (Exception ex)
//            {
//                return ex.Message;
//            }

//        }
//        /// <summary>
//        /// 批量添加SQL语句的参数
//        /// </summary>
//        /// <param name="parameters">执行增删改语句所需要的参数，参数必须以它们在SQL语句中的顺序为准</param>
//        /// <returns></returns>
//        public string AddParameters(OracleParameter[] parameters)
//        {
//            try
//            {
//                paramList.Add(parameters);
//                return string.Empty;
//            }
//            catch (Exception ex)
//            {
//                return ex.Message;
//            }
//        }
//        #endregion
//        #region 移除所有的SQL语句(增加,删除,修改)或者参数
//        /// <summary>
//        /// 移除所有的SQL语句
//        /// </summary>
//        public void RemoveAllSql()
//        {
//            _SqlList.Clear();
//        }
//        /// <summary>
//        /// 移除所有的参数
//        /// </summary>
//        public void RemoveAllParameters()
//        {
//            paramList.Clear();
//        }
//        #endregion
//        #region 批量执行不带参数的SQL语句(增加,删除,修改)
//        /// <summary>
//        ///批量执行不带参数的SQL语句 
//        /// </summary>
//        /// <param name="clearList">true 清空sql语句集合</param>
//        /// <returns>执行成功返回空,否则返回错误信息</returns>
//        public string ExecuteSqls(Boolean clearList = true)
//        {
//            OracleConnection conn = null;
//            OracleCommand commd = null;
//            OracleTransaction Tran = null;

//            try
//            {
//                if (string.IsNullOrEmpty(_SqlCnn.Trim()))
//                {
//                    return "数据库连接字符串不能为空.";
//                }

//                if (0 == _SqlList.Count)
//                {
//                    return "没有您要执行的SQL语句";
//                }

//                conn = new OracleConnection(_SqlCnn);
//                conn.Open();
//                commd = new OracleCommand();
//                Tran = conn.BeginTransaction();//创建事务

//                commd.Connection = conn;
//                commd.CommandTimeout = 30;
//                commd.CommandType = CommandType.Text;
//                commd.Transaction = Tran;

//                foreach (string _str in _SqlList)
//                {
//                    commd.CommandText = _str;
//                    commd.ExecuteNonQuery();
//                }
//                Tran.Commit();//保存更改并结束当前事务    
//                if (clearList) _SqlList.Clear();
//                return string.Empty;
//            }
//            catch (Exception ex)
//            {
//                Tran.Rollback();//回滚                
//                return ex.Message;
//            }
//            finally
//            {
//                if (Tran != null) Tran.Dispose();
//                if (commd != null) commd.Dispose();
//                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
//                if (conn != null) conn.Dispose();
//            }
//        }
//        #endregion
//        #region 批量执行带参数的SQL语句(增加,删除,修改)
//        /// <summary>
//        /// 执行批量 带参数 SQL语句,执行前要先调用AddParameters
//        /// </summary>
//        /// <param name="sql">SQL语句</param>
//        /// <param name="clearList">true 清空参数集合</param>
//        /// <returns>执行成功返回空,否则返回错误信息</returns>
//        public string ExecuteSqls(string sql, Boolean clearList = true)
//        {
//            OracleConnection conn = null;
//            OracleCommand commd = null;
//            OracleTransaction Tran = null;
//            try
//            {
//                if (string.IsNullOrEmpty(_SqlCnn.Trim()))
//                {
//                    return "数据库连接字符串不能为空.";
//                }

//                if (0 == paramList.Count)
//                {
//                    return "没有您要执行的SQL语句";
//                }

//                conn = new OracleConnection(_SqlCnn);
//                conn.Open();
//                Tran = conn.BeginTransaction();//创建事务

//                foreach (var item in paramList)
//                {
//                    commd = new OracleCommand();
//                    commd.Connection = conn;
//                    commd.CommandText = sql;
//                    commd.Transaction = Tran;
//                    commd.Parameters.AddRange(item);
//                    commd.ExecuteNonQuery();
//                }
//                Tran.Commit();//保存更改并结束当前事务
//                if (clearList) paramList.Clear();
//                return string.Empty;
//            }
//            catch (Exception ex)
//            {
//                Tran.Rollback();//回滚                
//                return ex.Message;
//            }
//            finally
//            {
//                if (Tran != null) Tran.Dispose();
//                if (commd != null) commd.Dispose();
//                if (conn != null && conn.State == ConnectionState.Open) conn.Close();
//                if (conn != null) conn.Dispose();
//            }
//        }
//        #endregion

//        public void Gettables()
//        {


//            OracleConnection conn = null;

//            OracleCommand commd = null;

//            try
//            {

//                conn = new OracleConnection(_SqlCnn);
//                conn.Open();
//                var dd = conn.GetSchema("COLUMNS");
//                var aa = dd.Select("TABLE_NAME='ALARMDEF'");
//                for (int i = 0; i < aa.Length; i++)
//                {
//                    foreach (  var item in aa[i].Table.Columns)
//                    {
//                        //var s2 = item.ToString();//获取每一列的名称
//                        this.WriteFile(@"C:\11\1234.txt", item.ToString());
                        
//                    }
//                    break;
//                }
//            }
//            catch
//            { }
//            finally
//            {
//                conn.Close();
//            }

//        }

//        private void WriteFile(string Path, string Strings)
//        {

//            if (!System.IO.File.Exists(Path))
//            {
//                System.IO.FileStream f = System.IO.File.Create(Path);
//                f.Close();
//                f.Dispose();
//            }
//            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
//            f2.WriteLine(Strings);
//            f2.Close();
//            f2.Dispose();
//        }
//    }
//}
