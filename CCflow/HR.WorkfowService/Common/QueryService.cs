using Newtonsoft.Json;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.BasicFramework.DataAccess;
using HR.WorkflowService.Models;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 查询服务
    /// </summary>
    public class QueryService
    {
        /// <summary>
        /// 根据SQL查询命令获取分页列表
        /// </summary>
        /// <param name="session">当前数据库会话</param>
        /// <param name="sql">SQL查询命令</param>
        /// <param name="page">目标页码</param>
        /// <param name="rows">每页的记录数</param>
        /// <param name="filters">过滤器，默认为null</param>
        /// <param name="orders">排序字段组合字符串，例如："NAME asc"、"NAME asc,AGE desc"</param>
        /// <param name="isUpper">是否将结果列表的所有字段名转换为大写字母，默认为false</param>
        /// <returns>承载着SQL命令查询结果的特定页的分页对象</returns>
        public static PaginationInfo CreatePagedSQLQuery(string sql, int page, int rows, List<Filter> filters = null, string orders = "", bool isUpper = false) 
        {
            var sourceSql = CreateSql(sql, filters);
            var sqlBuider = new StringBuilder(sourceSql);

            page = page == 0 ? 1 : page;
            var start_index = page == 1 ? 1 : (page - 1) * rows + 1;
            var end_index = start_index + rows - 1;

            var countSql = sqlBuider.ToString();
            countSql = "select count(*) " + countSql.Substring(countSql.IndexOf("from", StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(orders))
            {
                sqlBuider.Append(" Order By " + orders);
            }

            var sqlStr = string.Format("SELECT TempSecond.*,ROWNUM AS RNUM FROM ({0}) TempSecond ", sqlBuider.ToString());
            sqlStr = string.Format("SELECT * FROM ({0}) WHERE RNUM>={1} AND RNUM<={2}", sqlStr, start_index, end_index);


            var session = HR.BasicFramework.DataAccess.SessionManager.GetSession<BWA>();

            if (isUpper)
            {
                return new PaginationInfo()
                {
                    total = Convert.ToInt64(session.CreateSQLQuery(countSql).UniqueResult()),
                    rows = session.CreateSQLQuery(sqlStr).ListIDictionary()
                };
            }
            else
            {
                return new PaginationInfo()
                {
                    total = Convert.ToInt64(session.CreateSQLQuery(countSql).UniqueResult()),
                    rows = session.CreateSQLQuery(sqlStr).ListDynamic()
                };
            }
        }
        /// <summary>
        /// 根据SQL查询命令获取数据列表
        /// </summary>
        /// <param name="session">当前数据库会话</param>
        /// <param name="sql">SQL查询命令</param>
        /// <param name="filters">过滤器，默认为null</param>
        /// <param name="orders">排序字段组合字符串，例如："NAME asc"、"NAME asc,AGE desc"</param>
        /// <param name="isUpper">是否将结果列表的所有字段名转换为大写字母，默认为false</param>
        /// <returns>SQL命令查询结果列表</returns>
        public static IList<dynamic> GetData(string sql, List<Filter> filters = null, string orders = "", bool isUpper = false)
        {
            var sourceSql = CreateSql(sql, filters);
            var sqlBuider = new StringBuilder(sourceSql);
            if (!string.IsNullOrEmpty(orders))
            {
                sqlBuider.Append(" Order By " + orders);
            }

            var session = HR.BasicFramework.DataAccess.SessionManager.GetSession<BWA>();
            if (isUpper)
            {
                return session.CreateSQLQuery(sqlBuider.ToString()).ListIDictionary().Select(x => x as dynamic).ToList();
            }
            else
            {
                return session.CreateSQLQuery(sqlBuider.ToString()).ListDynamic();
            }
        }

        /// <summary>
        /// 使用指定名称的存储过程获取数据列表
        /// </summary>
        /// <param name="connStr">数据库连接字符串</param>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="filters">过滤器，默认为null</param>
        /// <param name="outParamName">存储过程输出参数名称</param>
        /// <returns>由存储过程获取的数据列表</returns>
        //public static IList<IDictionary<string, object>> GetDataByProcedure(string connStr, string procedureName, List<Filter> filters = null, string outParamName = "returnTable")
        //{
        //    DataSet ds = new DataSet("dt");
        //    filters = filters == null ? new List<Filter>() : filters;

        //    using (OracleConnection sc = new OracleConnection(connStr))
        //    {
        //        sc.Open();

        //        try
        //        {
        //            using (OracleCommand cmd1 = new OracleCommand(procedureName, sc))
        //            {
        //                cmd1.CommandType = CommandType.StoredProcedure;

        //                foreach (var filter in filters)
        //                {
        //                    if (OracelTypeDic.ContainsKey(filter.dataType))
        //                    {
        //                        var param = cmd1.Parameters.Add(filter.property, OracelTypeDic[filter.dataType]);
        //                        param.Direction = ParameterDirection.Input;
        //                        if (filter.value == null)
        //                        {
        //                            param.Value = DBNull.Value;
        //                        }
        //                        else
        //                        {
        //                            param.Value = filter.value;
        //                        }
        //                    }
        //                }

        //                OracleParameter param1 = cmd1.Parameters.Add(outParamName, OracleDbType.RefCursor);

        //                param1.Direction = ParameterDirection.Output;
        //                OracleDataAdapter da = new OracleDataAdapter(cmd1);

        //                da.Fill(ds, "dt");
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return null;
        //            //MessageBox.Show(ex.ToString());
        //        }
        //    }
        //    return ds.Tables[0].ToIDictionaryList();
        //}

        //private static Dictionary<string, OracleDbType> OracelTypeDic = new Dictionary<string, OracleDbType> 
        //{ 
        //  { "varchar", OracleDbType.Varchar2 },
        //  { "nvarchar", OracleDbType.NVarchar2 },
        //  { "number", OracleDbType.Int64 },
        //  { "date", OracleDbType.Date },
        //  { "long", OracleDbType.Long }
        //};

        /// <summary>
        /// 根据过滤条件创建新的sql语句
        /// </summary>
        public static string CreateSql(string sql, List<Filter> filters)
        {
            sql = string.Format("SELECT * FROM ({0}) TempFirst", sql);

            var sqlBuider = new StringBuilder(sql);

            var dataType = new List<string>()
            {
            "int","decimal","double","float","null"
            };

            sqlBuider.Append(" WHERE 1=1");

            filters = filters == null ? new List<Filter>() : filters;

            foreach (var field in filters)
            {
                if (field.value == null)
                {
                    field.dataType = "null";
                    field.value = "null";
                    field.relation = "is";
                }
                if (field.dataType == "datetime")
                {
                    sqlBuider.AppendFormat(" {0} {1} {2} {3} to_date('{4}','yyyy/mm/dd hh24:mi:ss') {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
                }
                else if (dataType.Contains(field.dataType))
                {
                    sqlBuider.AppendFormat(" {0} {1} {2} {3} {4} {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
                }
                else
                {
                    if (field.relation == "like")
                    {
                        field.value = "%" + field.value + "%";
                    }
                    sqlBuider.AppendFormat(" {0} {1} {2} {3} '{4}' {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
                }
            }
            return sqlBuider.ToString();
        }

        /// <summary>
        /// 反序列化过滤条件
        /// </summary>
        /// <param name="filterStr">处于序列化状态的过滤条件</param>
        /// <returns>已反序列化的过滤条件</returns>
        public static List<Filter> DeserializeFilter(string filterStr)
        {
            return JsonConvert.DeserializeObject<List<Filter>>(filterStr);
        }

        /// <summary>
        /// 反序列化过滤条件的同时加上过滤当前用户
        /// </summary>
        /// <param name="filterStr">处于序列化状态的过滤条件</param>
        /// <param name="UserName">当前用户名</param>
        /// <returns>已反序列化并加上了当前和户名的过滤条件</returns>
        public static List<Filter> DeserializeFilterAddCurrentUser(string filterStr, string UserName)
        {
            var filters = JsonConvert.DeserializeObject<List<Filter>>(filterStr);

            filters.Add(new Filter() { property = "Creator", value = UserName });

            return filters;
        }
    }
}
