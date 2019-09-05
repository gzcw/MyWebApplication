using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Web.SessionState;
using System.Configuration;

namespace HR.Workflow.Common
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public class DBHelper
    {
        public static OracleTransaction _trans
        {
            get
            {
                if (transDic.ContainsKey(_sessionId))
                {
                    return transDic[_sessionId];
                }
                return null;
            }
        }

        public static string _sessionId
        {
            get
            {
                return HttpContext.Current.Session.SessionID + HttpContext.Current.Timestamp.ToLongTimeString();
            }
        }



        private static Dictionary<string, OracleTransaction> transDic = new Dictionary<string, OracleTransaction>();
        private static Dictionary<string, OracleConnection> connDic = new Dictionary<string, OracleConnection>();

        public static OracleConnection _conn
        {
            get
            {
                if (connDic.ContainsKey(_sessionId))
                {
                    return connDic[_sessionId];
                }
                return null;
            }
        }

        public static OracleTransaction BeginTransaction()
        {
            var myconn = OpenConn();
            var trans = myconn.BeginTransaction();


            var test = HttpContext.Current.Session.SessionID + HttpContext.Current.Timestamp.ToLongTimeString();
            transDic[HttpContext.Current.Session.SessionID + HttpContext.Current.Timestamp.ToLongTimeString()] = trans;

            return trans;
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns></returns>
        public static OracleConnection OpenConn()
        {
            if (_conn == null)
            {
                connDic.Add(_sessionId, new OracleConnection());

                var connectionString = ConfigurationManager.ConnectionStrings["HRFlow.Oracle"].ConnectionString;

                _conn.ConnectionString = connectionString;
            }
            try
            {
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }
            }
            catch
            {
                //connDic.Add(_sessionId, new OracleConnection());
                //_conn.ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.3.21)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = zcserver)));User ID=zcgt;Password=zcgt";
                _conn.Open();
            }
            return _conn;
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="conn"></param>
        public static void CloseConn(OracleConnection conn)
        {
            if (conn == null) { return; }
            try
            {
                if (conn.State != ConnectionState.Closed && _trans == null)
                {
                    conn.Close();
                }
            }
            catch
            {
                throw new Exception("关闭数据库连接失败");
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        /// <param name="conn"></param>
        public static void CloseConn()
        {
            if (_conn == null) { return; }
            try
            {
                if (_conn.State != ConnectionState.Closed)
                {
                    _conn.Close();
                }
            }
            catch
            {
                throw new Exception("关闭数据库连接失败");
            }
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql, int page, int rows, ref int total)
        {
            var table = new DataTable();

            sql = string.Format("SELECT * FROM (SELECT TempSecond.*,ROWNUM AS XH FROM ({0}) TempSecond) TempFirst WHERE XH>={1} AND XH<={2}", sql, (page - 1) * rows + 1, page * rows);

            var totalSql = "SELECT COUNT(*) FROM (sql) TempFirst";

            OracleConnection conn = null;
            try
            {
                conn = OpenConn();

                var adapter = new OracleDataAdapter(sql, conn);

                adapter.Fill(table);

                var cmd = conn.CreateCommand();
                cmd.CommandText = totalSql;
                cmd.CommandType = CommandType.Text;
                total = (int)cmd.ExecuteScalar();
            }
            catch
            {

            }
            finally
            {
                CloseConn(conn);
            }
            return table;
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql)
        {
            var table = new DataTable();

            OracleConnection conn = null;
            try
            {
                conn = OpenConn();

                var adapter = new OracleDataAdapter(sql, conn);

                adapter.Fill(table);
            }
            catch
            {

            }
            finally
            {
                CloseConn(conn);
            }
            return table;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static object Insert(string tableName, IDictionary<string, object> form)
        {
            var columnInfo = GetTable(string.Format("SELECT COLUMN_NAME,DATA_TYPE FROM ALL_TAB_COLUMNS C WHERE  C.TABLE_NAME='{0}'", tableName));

            OracleConnection conn = conn = OpenConn();
            try
            {
                var sql = new StringBuilder();

                var values = new List<string>();
                var keys = new List<string>();

                var entityId = string.IsNullOrEmpty(form["ID"].ToString()) ? Guid.NewGuid().ToString() : form["ID"].ToString();

                foreach (string key in form.Keys)
                {
                    var value = form[key];
                    if (key == "ID")
                    {
                        values.Add(string.Format("'{0}'", entityId));
                        keys.Add(key);
                        continue;
                    }

                    var fieldInfo = columnInfo.Select(string.Format("COLUMN_NAME='{0}'", key))[0];
                    switch (fieldInfo["DATA_TYPE"].ToString())
                    {
                        case "DATE":
                            var dateVal = string.IsNullOrEmpty(form[key].ToString()) ? "NULL" : string.Format("TO_DATE('{0}','yyyy-mm-dd')", form[key].ToString());
                            values.Add(dateVal);
                            break;
                        default: values.Add(string.Format("'{0}'", value)); break;
                    }

                    keys.Add(key);
                }

                var valuesStr = values.ToString().TrimEnd(',');
                sql.AppendFormat("INSERT INTO {0}({1}) VALUES({2})", tableName, string.Join(",", keys), string.Join(",", values));

                var cmd = conn.CreateCommand();
                cmd.CommandText = sql.ToString();
                cmd.CommandType = CommandType.Text;
                if (_trans != null && _trans.Connection != null)
                {
                    cmd.Transaction = _trans;
                }
                cmd.ExecuteNonQuery();

                return LoadEntiey(tableName, entityId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(conn);
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        public static object Update(string tableName, IDictionary<string, object> form)
        {
            var zjTable = GetTable(string.Format("SELECT COLUMN_NAME,DATA_TYPE FROM ALL_TAB_COLUMNS C WHERE  C.TABLE_NAME='{0}'", tableName));

            OracleConnection conn = OpenConn();
            try
            {
                var values = new StringBuilder();

                foreach (string key in form.Keys)
                {
                    if (key == "ID" || key == "SLBH") continue;

                    var fieldInfo = zjTable.Select(string.Format("COLUMN_NAME='{0}'", key))[0];
                    switch (fieldInfo["DATA_TYPE"].ToString())
                    {
                        case "DATE":
                            var value = string.IsNullOrEmpty(form[key].ToString()) ? "NULL" : string.Format("TO_DATE('{0}','yyyy-mm-dd')", form[key].ToString());
                            values.AppendFormat("{0}={1},", key, value);
                            break;
                        default: values.AppendFormat("{0}='{1}',", key, form[key]); break;
                    }
                }
                var valuesStr = values.ToString().TrimEnd(',');

                var sql = string.Format("UPDATE {0} SET {1} WHERE ID='{2}'", tableName, valuesStr, form["ID"]);

                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;

                if (_trans != null && _trans.Connection != null)
                {
                    cmd.Transaction = _trans;
                }

                cmd.ExecuteNonQuery();

                return LoadEntiey(tableName, form["ID"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_trans == null)
                {
                    CloseConn(conn);
                }
            }
        }

        /// <summary>
        /// 加载表单
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Dictionary<string, object> LoadEntiey(string tableName, string id)
        {
            var table = new DataTable();

            var sql = string.Format("SELECT * FROM {0} WHERE ID='{1}'", tableName, id);

            OracleConnection conn = null;
            try
            {
                conn = OpenConn();

                var adapter = new OracleDataAdapter(sql, conn);

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    var serilize = JsonConvert.SerializeObject(table);
                    string resultStr = Regex.Match(serilize, @"\[(.*)\]").Groups[1].Value;
                    var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(resultStr);
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(conn);
            }
        }

        /// <summary>
        /// 通过SQL查找
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetEntityBySQL(string sql)
        {
            var table = new DataTable();

            OracleConnection conn = conn = OpenConn();
            try
            {
                var adapter = new OracleDataAdapter(sql, conn);

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    var count = table.Rows.Count;
                    for (var i = 0; i < count - 1; i++)
                    {
                        table.Rows.RemoveAt(1);
                    }

                    var serilize = JsonConvert.SerializeObject(table);
                    string resultStr = Regex.Match(serilize, @"\[(.*)\]").Groups[1].Value;
                    var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(resultStr);
                    return result;
                }
                return new Dictionary<string, object>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(conn);
            }
        }

        /// <summary>
        /// 通过SQL查找
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> FindBySQL(string sql)
        {
            var table = new DataTable();

            OracleConnection conn = null;
            try
            {
                conn = OpenConn();

                var adapter = new OracleDataAdapter(sql, conn);

                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    var serilize = JsonConvert.SerializeObject(table);
                    var result = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(serilize);
                    return result;
                }
                return new List<Dictionary<string, object>>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(conn);
            }
        }

        /// <summary>
        /// 添加或更新记录
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="form"></param>
        internal static object SaveOrUpdate(string tableName, IDictionary<string, object> form)
        {
            if (!string.IsNullOrEmpty(form["ID"].ToString()))
            {
                var table = GetTable(string.Format("SELECT * FROM {0} WHERE ID='{1}'", tableName, form["ID"]));
                if (table.Rows.Count > 0)
                {
                    return Update(tableName, form);
                }
                else
                {
                    return Insert(tableName, form);
                }
            }

            return Insert(tableName, form);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ids"></param>
        internal static void Delete(string tableName, List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                throw new Exception("删除失败,没有可删除的记录！");
            }
            else
            {
                var inIds = ids.Select(x => string.Format("'{0}'", x));
                var sql = string.Format("DELETE FROM {0} WHERE ID in ({1})", tableName, string.Join(",", inIds));

                OracleConnection conn = null;
                try
                {
                    conn = OpenConn();

                    var adapter = new OracleDataAdapter(sql, conn);

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    if (_trans != null && _trans.Connection != null)
                    {
                        cmd.Transaction = _trans;
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseConn(conn);
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="item"></param>
        internal static void Delete(string tableName, Dictionary<string, object> item)
        {
            if (!item.ContainsKey("ID") || string.IsNullOrEmpty(item["ID"].ToString()))
            {
                throw new Exception("删除失败,ID不能为空");
            }
            else
            {
                var sql = string.Format("DELETE FROM {0} WHERE ID='{1}'", tableName, item["ID"].ToString());

                OracleConnection conn = null;
                try
                {
                    conn = OpenConn();

                    var adapter = new OracleDataAdapter(sql, conn);

                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    if (_trans != null && _trans.Connection != null)
                    {
                        cmd.Transaction = _trans;
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseConn(conn);
                }
            }
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="item"></param>
        internal static int ExecuteNonQuery(string sql)
        {
            OracleConnection conn = OpenConn();
            try
            {
                var adapter = new OracleDataAdapter(sql, conn);

                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(conn);
            }
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="item"></param>
        internal static object ExecuteScalar(string sql)
        {
            OracleConnection conn = OpenConn();
            try
            {
                var adapter = new OracleDataAdapter(sql, conn);

                var cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConn(conn);
            }
        }
    }
}