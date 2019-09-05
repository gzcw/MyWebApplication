using Newtonsoft.Json;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab.Framework
{
    /// <summary>
    /// 查询服务，查询范围为实体类T所在的数据库。
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class QueryService
    {
        //public static PagedResult<dynamic> CreatePagedSQLQuery(string sql, int page, int rows, List<MyFilter> filters = null, string orders = "", bool filterDeleted = true)
        //{
        //    var targetSql = CreateSQL(sql, filters, filterDeleted);

        //    var countSql = "select count(*) " + targetSql.Substring(targetSql.IndexOf("from", StringComparison.OrdinalIgnoreCase));

        //    var sqlStr = CreatePagedSQL(targetSql.ToString(), page, rows, orders);
        //    var ISession = NH.Session;
        //    try
        //    {
        //        var items = ISession.CreateSQLQuery(sqlStr).ToDynamicList();
        //        return new PagedResult<dynamic>
        //        {
        //            CurrentPage = page,
        //            PageCount = rows,
        //            TotalItems = Convert.ToInt64(ISession.CreateSQLQuery(countSql).UniqueResult()),
        //            Items = items
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        //ISession.Close();
        //        //ISession.Dispose();
        //    }
        //}
        /// <summary>
        /// 根据SQL查询分页结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="filterDeleted"></param>
        /// <returns></returns>
        public static PagedResult CreatePagedSQLQuery(string sql, int page, int rows, List<MyFilter> filters = null, string orders = "")
        {
            var targetSql = CreateSQL(sql, filters);

            var countSql = "select count(*) " + targetSql.Substring(targetSql.IndexOf("from", StringComparison.OrdinalIgnoreCase));

            var sqlStr = CreatePagedSQL(targetSql.ToString(), page, rows, orders);
            var ISession = NH.Session;
            try
            {
                var items = ISession.CreateSQLQuery(sqlStr).ToDynamicList();
                return new PagedResult
                {
                    rows = items,
                    total = Convert.ToInt64(ISession.CreateSQLQuery(countSql).UniqueResult())
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //ISession.Close();
                //ISession.Dispose();
            }
        }

        public static List<ExpandoObject> GetTreeData(string sql, string parentField = "ParentID", string idField = "ID", string textField = "Name")
        {
            var ISession = NH.Session;
            var records = ISession.CreateSQLQuery(string.Format("SELECT * FROM ({0}) T WHERE (T.{1} IS NOT NULL OR T.{1} != '')", sql, parentField)).ToDynamicList().Select(x => x as ExpandoObject).ToList();
            var parents = ISession.CreateSQLQuery(string.Format("SELECT * FROM ({0}) T WHERE (T.{1} IS NULL OR T.{1} = '')", sql, parentField)).ToDynamicList().Select(x => x as ExpandoObject).ToList();

            for (var i = 0; i < parents.Count(); i++)
            {
                dynamic item = parents[i];
                var children = GetChildren(item, parentField, idField, textField, records);
                if (children != null)
                {
                    item.children = children;
                }
                item.id = (parents[i] as IDictionary<string, object>)[idField];
                item.text = (parents[i] as IDictionary<string, object>)[textField];
            }
            return parents;
        }

        private static List<ExpandoObject> GetChildren(ExpandoObject record, string parentField, string idField, string textField, IList<ExpandoObject> records)
        {
            var list = records.Where(x => (x as IDictionary<string, object>)[parentField].ToString() == (record as IDictionary<string, object>)[idField].ToString()).Select(x => x as ExpandoObject).ToList();
            if (list.Count == 0)
            {
                return null;
            }
            for (var i = 0; i < list.Count(); i++)
            {
                dynamic item = list[i];
                var children = GetChildren(item, parentField, idField, textField, records);
                if (children != null)
                {
                    item.children = children;
                }
                item.id = (list[i] as IDictionary<string, object>)[idField];
                item.text = (list[i] as IDictionary<string, object>)[textField];
            }
            return list;
        }


        /// <summary>
        /// 根据SQL查询分页结果集
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="filterDeleted"></param>
        /// <returns></returns>
        public static PagedResult CreateTreePagedSQLQuery(string sql, int page, int rows, List<MyFilter> filters = null, string orders = "", string parentField = "PARENTID", string idField = "ID")
        {
            var ISession = NH.Session;
            //查询所有根节点
            if (filters.Count() == 0)
            {
                sql = string.Format("SELECT T_.*,(CASE WHEN EXISTS(SELECT * FROM ({0}) T_1 WHERE T_1.PARENTID=T_.ID) THEN 'closed' ELSE 'open' END) AS STATE FROM ({0}) T_", sql, parentField);
                return CreatePagedSQLQuery(sql, page, rows, filters, orders);
            }

            //根据条件查询
            var targetSql = CreateTreeSQL(sql, filters);
            try
            {
                var allRecords = ISession.CreateSQLQuery(targetSql).ToDynamicList().Select(x => x as ExpandoObject).ToList();
                var allParentRecords = allRecords.Where(x => (x as IDictionary<string, object>)[parentField] == null).ToList();

                var pageRecords = new List<ExpandoObject>();
                for (var i = 0; i < rows; i++)
                {
                    if ((page - 1) * rows + i >= allParentRecords.Count)
                    {
                        break;
                    }
                    pageRecords.Add(allParentRecords[(page - 1) * rows + i]);
                }

                for (var i = 0; i < pageRecords.Count(); i++)
                {
                    pageRecords[i] = GetTreeNode(pageRecords[i], allRecords);
                }
                return new PagedResult
                {
                    rows = allParentRecords,
                    total = allParentRecords.Count()
                };
            }
            catch (Exception ex)
            {
                return new PagedResult
                {

                };
                //throw ex;
            }
            finally
            {
                //ISession.Close();
                //ISession.Dispose();
            }
        }

        private static ExpandoObject GetTreeNode(ExpandoObject item, IList<ExpandoObject> data, string parentField = "PARENTID", string idField = "ID")
        {
            var children = data.Where(x => (x as IDictionary<string, object>)["PARENTID"] != null && (x as IDictionary<string, object>)[parentField].ToString() == (item as IDictionary<string, object>)[idField].ToString()).ToList();
            if (children.Count() == 0)
            {
                return item;
            }

            for (var i = 0; i < children.Count(); i++)
            {
                children[i] = GetTreeNode(children[i], data);
            }
            (item as IDictionary<string, object>).Add("children", children);
            return item;
        }

        /// <summary>
        /// 创建分页SQL
        /// </summary>
        /// <param name="sqlBuider"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        private static string CreatePagedSQL(string sql, int page, int rows, string orders)
        {
            //StringBuilder sqlBuider = new StringBuilder(sql);
            //if (!string.IsNullOrEmpty(orders))
            //{
            //    sqlBuider.Append(" Order By " + orders);
            //}
            page = page == 0 ? 1 : page;
            orders = string.IsNullOrEmpty(orders) ? "ID" : orders;
            var start_index = page == 1 ? 1 : (page - 1) * rows + 1;
            var end_index = start_index + rows - 1;
            var sqlStr = string.Format("SELECT TempSecond.*,ROW_NUMBER() OVER(Order By {0}) AS RNUM FROM ({1}) TempSecond ", orders, sql);
            sqlStr = string.Format("SELECT * FROM ({0}) _A WHERE RNUM>={1} AND RNUM<={2}", sqlStr, start_index, end_index);
            return sqlStr;
        }
        public static bool ProcessSqlStr(string inputString)
        {
            string SqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {
                    string str_Regex = @"\(|\)|\b(" + SqlStr + @")\b";
                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    if (true == Regex.IsMatch(inputString))
                        return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 创建SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="filters"></param>
        /// <param name="filterDeleted"></param>
        /// <returns></returns>
        private static string CreateSQL(string sql, List<MyFilter> filters)
        {
            var sqlBuider = new StringBuilder();
            filters = filters == null ? new List<MyFilter>() : filters;

            var dataType = new List<string>()
            {
            "int","decimal","double","float","null","not null"
            };

            sqlBuider.AppendFormat("SELECT * FROM ({0}) TempFirst WHERE 1=1", sql);

            //if (filterDeleted)
            //{
            //    filters.Add(new MyFilter() { property = "IsDeleted", value = "0", dataType = "int" });
            //}

            foreach (var field in filters)
            {
                if (field.value == null || field.value == "null")
                {
                    field.dataType = "null";
                    field.value = "null";
                    field.relation = "is";
                }
                if (field.value == "not null")
                {
                    field.dataType = "not null";
                    field.value = "not null";
                    field.relation = "is";
                }
                if (field.dataType == "datetime")
                {
                    sqlBuider.AppendFormat(" {0} {1} {2} {3} to_date('{4}','yyyy/mm/dd hh24:mi:ss') {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
                }
                else if (field.relation == "in")
                {
                    field.value = string.Join(",", field.value.Split(',').Select(x => "'" + x + "'"));
                    sqlBuider.AppendFormat(" {0} {1} {2} {3} ({4}) {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
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
        /// 创建SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="filters"></param>
        /// <param name="filterDeleted"></param>
        /// <returns></returns>
        private static string CreateTreeSQL(string sql, List<MyFilter> filters, string parentField = "PARENTID", string idField = "ID")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            if (filters.Count == 0)
            {
                return string.Format("SELECT * FROM ({0}) TempFirst WHERE {1} IS NULL", sql, parentField);
            }
            var whereBuider = new StringBuilder("WHERE");

            var dataType = new List<string>()
            {
            "int","decimal","double","float","null","not null"
            };

            foreach (var field in filters)
            {
                if (field.value == null || field.value == "null")
                {
                    field.dataType = "null";
                    field.value = "null";
                    field.relation = "is";
                }
                if (field.value == "not null")
                {
                    field.dataType = "not null";
                    field.value = "not null";
                    field.relation = "is";
                }
                if (field.dataType == "datetime")
                {
                    whereBuider.AppendFormat(" {0} {1} {2} {3} to_date('{4}','yyyy/mm/dd hh24:mi:ss') {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
                }
                else if (field.relation == "in")
                {
                    field.value = string.Join(",", field.value.Split(',').Select(x => "'" + x + "'"));
                    whereBuider.AppendFormat(" {0} {1} {2} {3} ({4}) {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
                }
                else if (dataType.Contains(field.dataType))
                {
                    whereBuider.AppendFormat(" {0} {1} {2} {3} {4} {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
                }
                else
                {
                    if (field.relation == "like")
                    {
                        field.value = "%" + field.value + "%";
                    }
                    whereBuider.AppendFormat(" {0} {1} {2} {3} '{4}' {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
                }
            }
            whereBuider.Replace("WHERE AND", "").Replace("WHERE", "");

            return string.Format("SELECT DISTINCT * FROM ({0}) T START WITH {1} CONNECT BY PRIOR {2}={3}", sql, whereBuider.ToString(), parentField, idField);
        }

        /// <summary>
        /// 根据SQL查询命令获取数据列表
        /// </summary>
        /// <param name="sql">SQL查询命令</param>
        /// <param name="filters">过滤器，默认为null</param>
        /// <param name="orders">排序字段组合字符串，例如："NAME asc"、"NAME asc,AGE desc"</param>
        /// <returns>SQL命令查询结果列表</returns>
        public static IList<dynamic> GetData(string sql, List<MyFilter> filters = null, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;

            var sourceSql = CreateSql(sql, filters, orders);
            var ISession = NH.Session;
            try
            {
                var items = ISession.CreateSQLQuery(sourceSql).ToDynamicList();

                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //ISession.Close();
                //ISession.Dispose();
            }
        }

        /// <summary>
        /// 根据过滤条件创建新的sql语句
        /// </summary>
        /// <returns>SQL语句</returns>
        public static string CreateSql(string sql, List<MyFilter> filters, string orders, string columns = "")
        {
            sql = string.Format("SELECT * FROM ({0}) TempFirst", sql);

            if (!string.IsNullOrEmpty(columns))
            {
                sql = string.Format("SELECT DISTINCT {0} FROM ({1}) TempFirst", columns, sql);
            }

            var sqlBuider = new StringBuilder(sql);

            var dataType = new List<string>()
            {
            "int","decimal","double","float","null"
            };

            sqlBuider.Append(" WHERE 1=1");

            filters = filters == null ? new List<MyFilter>() : filters;

            foreach (var field in filters)
            {
                if (field.value == null)
                {
                    field.dataType = "null";
                    field.value = "null";
                    field.relation = "is";
                }
                if (field.value == "not null")
                {
                    field.dataType = "null";
                    field.value = "not null";
                    field.relation = "is";
                }
                if (field.dataType == "datetime")
                {
                    sqlBuider.AppendFormat(" {0} {1} {2} {3} to_date('{4}','yyyy/mm/dd hh24:mi:ss') {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
                }
                else if (field.relation == "in")
                {
                    field.value = string.Join(",", field.value.Split(',').Select(x => "'" + x + "'"));
                    sqlBuider.AppendFormat(" {0} {1} {2} {3} ({4}) {5}", field.connect, field.left, field.property, field.relation, field.value, field.right);
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

            if (!string.IsNullOrEmpty(orders))
            {
                sqlBuider.Append(" Order By " + orders);
            }
            return sqlBuider.ToString();
        }

        public static List<MyFilter> DeserializeFilter(string filterStr)
        {
            return JsonConvert.DeserializeObject<List<MyFilter>>(filterStr);
        }

        public static List<MyFilter> DeserializeFilterAddCurrentUser(string filterStr, string UserName)
        {
            var filters = JsonConvert.DeserializeObject<List<MyFilter>>(filterStr);

            filters.Add(new MyFilter() { property = "Creator", value = UserName });

            return filters;
        }

        /// <summary>
        /// 获取树状列表
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <param name="filterDeleted"></param>
        /// <returns></returns>
        public static PagedResult CreateTreePagedSQLQuery1(int page, int rows, string sql, List<MyFilter> filters, string orders, string id = "")
        {
            List<dynamic> result = new List<dynamic>();
            var targetSql = CreateSQL(sql, filters);

            if (filters.Count == 0)
            {
                targetSql = string.Format("SELECT * FROM ({0}) WHERE PARENTID IS NULL", sql);
            }
            var sqlStr = CreatePagedSQL(targetSql.ToString(), page, rows, orders);
            var countSql = string.Format("SELECT COUNT(*) FROM ({0})", targetSql);

            if (!string.IsNullOrEmpty(orders))
            {
                sqlStr = string.Format("SELECT * FROM ({0}) T ORDER BY {1}", sqlStr, orders);
            }

            IList<dynamic> data = new List<dynamic>();
            IList<dynamic> total_data = new List<dynamic>();


            var ISession = NH.Session;
            try
            {
                data = ISession.CreateSQLQuery(sqlStr).ToDynamicList();
                total_data = ISession.CreateSQLQuery(sql).ToDynamicList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //ISession.Close();
                //ISession.Dispose();
            }
            if (!string.IsNullOrEmpty(id))
            {
                result = total_data.Where(x => x.Parentid == id).ToList();
                foreach (var item in result)
                {
                    if (total_data.Count(x => x.Parentid == item.Id) > 0)
                    {
                        item.children = new List<string>();
                        item.state = "closed";
                    }
                }
            }
            else if (filters.Count == 0)
            {
                foreach (var item in data)
                {
                    result.Add(item);
                    if (total_data.Count(x => x.Parentid == item.Id) > 0)
                    {
                        item.children = new List<string>();
                        item.state = "closed";
                    }
                }
            }
            else
            {
                var dic = new Dictionary<string, dynamic>();
                foreach (var item in data)
                {
                    if (item.Parentid == null && !dic.ContainsKey(item.Id))
                    {
                        result.Add(item);
                        dic.Add(item.Id, item);
                        continue;
                    }
                    CreateTreeData(ref result, ref dic, item, sql, 0);
                }
            }
            return new PagedResult
            {
                total = Convert.ToInt64(ISession.CreateSQLQuery(countSql).UniqueResult()),
                rows = result
            };
        }

        /// <summary>
        /// 创建数结构
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="sql"></param>
        /// <param name="parentField"></param>
        /// <returns></returns>
        public static void CreateTreeData(ref List<dynamic> result, ref Dictionary<string, dynamic> dic, dynamic record, string sql, int count = 0)
        {
            var ISession = NH.Session;
            try
            {
                if (dic.ContainsKey(record.Id))
                {
                    return;
                }
                dic.Add(record.Id, record);
                var query = string.Format("SELECT FirstTable.* FROM ({0}) FirstTable WHERE FirstTable.ID='{1}'", sql, record.Parentid as string);
                var parentRecord = ISession.CreateSQLQuery(query).ToDynamicList().FirstOrDefault();
                if (parentRecord == null || count >= 10)
                {
                    result.Add(record);
                }
                else if (dic.ContainsKey(parentRecord.Id))
                {
                    if (((IDictionary<string, object>)dic[parentRecord.Id]).ContainsKey("children"))
                    {
                        (dic[parentRecord.Id].children as List<dynamic>).Add(record);
                    }
                    else
                    {
                        dic[parentRecord.Id].children = new List<dynamic>() { record };
                        dic[parentRecord.Id].state = "open";
                    }
                }
                else
                {
                    parentRecord.children = new List<dynamic>() { record };
                    parentRecord.state = "open";
                    CreateTreeData(ref result, ref dic, parentRecord, sql, count + 1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
