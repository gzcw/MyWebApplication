using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 数据库访问对象扩展方法定义类
    /// </summary>
    public static class DaoExtensionFunctions
    {
        /// <summary>
        /// 返回IList&lt;IDictionary&lt;string, object&gt;&gt;型的结果集
        /// </summary>
        /// <param name="query">NHibernate的IQuery对象</param>
        /// <returns>IList&lt;IDictionary&lt;string, object&gt;&gt;型的结果集</returns>
        public static IList<IDictionary<string, object>> ListIDictionary(this IQuery query)
        {
            ObjectResultSetTransformer transformer = new ObjectResultSetTransformer();
            return query.SetResultTransformer(transformer).List<IDictionary<string, object>>();
        }
        /// <summary>
        /// 返回IList&lt;dynamic&gt;型的结果集，列表中元素的实际类型为ExpandoObject。
        /// </summary>
        /// <param name="query">NHibernate的IQuery对象</param>
        /// <returns>IList&lt;dynamic&gt;型的结果集</returns>
        public static IList<dynamic> ListDynamic(this IQuery query)
        {
            ObjectResultSetTransformer2 transformer2 = new ObjectResultSetTransformer2();
            return query.SetResultTransformer(transformer2).List<dynamic>();
        }
        /// <summary>
        /// 将DataTable转换为IList&lt;IDictionary&lt;string, object&gt;&gt;型的结果集
        /// 每个IDictionary&lt;string, object&gt;对象代表了DataTable中的一个数据行
        /// </summary>
        /// <param name="dataTable">DataTable对象</param>
        /// <returns>IList&lt;IDictionary&lt;string, object&gt;&gt;型的结果集</returns>
        public static IList<IDictionary<string, object>> ToIDictionaryList(this DataTable dataTable)
        {
            IList<IDictionary<string, object>> resultList = new List<IDictionary<string, object>>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                IDictionary<string, object> dicObject = new Dictionary<string, object>();
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    dicObject[dataTable.Columns[j].ColumnName.ToUpper()] = dataTable.Rows[i][j];
                }
                resultList.Add(dicObject);
            }
            return resultList;
        }
        /// <summary>
        /// 将DataTable转换为IList&lt;TEntity&gt;型的结果集
        /// </summary>
        /// <typeparam name="TEntity">DataTable中的记录要转换成的类型</typeparam>
        /// <param name="dt">要转换的DataTable</param>
        /// <returns>IList&lt;TEntity&gt;型的结果集</returns>
        public static List<TEntity> ToList<TEntity>(this DataTable dt) where TEntity : class,new()
        {
            List<TEntity> resultList = new List<TEntity>();
            if (dt == null || dt.Rows.Count <= 0) return resultList;

            PropertyInfo[] propertys = typeof(TEntity).GetProperties();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                TEntity entity = (TEntity)Activator.CreateInstance(typeof(TEntity));
                foreach (PropertyInfo pi in propertys)
                {
                    // 属性与字段名称一致的进行赋值                           
                    if (dt.Columns[pi.Name] != null && pi.Name.Equals(dt.Columns[pi.Name].ColumnName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (dt.Rows[j][pi.Name] != DBNull.Value)
                        {
                            if (pi.PropertyType == typeof(string))
                            {
                                pi.SetValue(entity, dt.Rows[j][pi.Name], null);
                            }
                            else if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(DateTime?))
                            {
                                pi.SetValue(entity, DateTime.Parse(dt.Rows[j][pi.Name].ToString()), null);
                            }
                            else if (pi.PropertyType == typeof(sbyte) || pi.PropertyType == typeof(sbyte?))
                            {
                                pi.SetValue(entity, sbyte.Parse(dt.Rows[j][pi.Name].ToString()), null);
                            }
                            else if (pi.PropertyType == typeof(byte) || pi.PropertyType == typeof(byte?))
                            {
                                pi.SetValue(entity, byte.Parse(dt.Rows[j][pi.Name].ToString()), null);
                            }
                            else if (pi.PropertyType == typeof(short) || pi.PropertyType == typeof(short?))
                            {
                                pi.SetValue(entity, short.Parse(dt.Rows[j][pi.Name].ToString()), null);
                            }
                            else if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(int?))
                            {
                                pi.SetValue(entity, int.Parse(dt.Rows[j][pi.Name].ToString()), null);
                            }
                            else if (pi.PropertyType == typeof(long) || pi.PropertyType == typeof(long?))
                            {
                                pi.SetValue(entity, long.Parse(dt.Rows[j][pi.Name].ToString()), null);
                            }
                            else if (pi.PropertyType == typeof(float) || pi.PropertyType == typeof(float?))
                            {
                                pi.SetValue(entity, float.Parse(dt.Rows[j][pi.Name].ToString()), null);
                            }
                            else if (pi.PropertyType == typeof(double) || pi.PropertyType == typeof(double?))
                            {
                                pi.SetValue(entity, double.Parse(dt.Rows[j][pi.Name].ToString()), null);
                            }
                            else if (pi.PropertyType == typeof(decimal) || pi.PropertyType == typeof(decimal?))
                            {
                                pi.SetValue(entity, decimal.Parse(dt.Rows[j][pi.Name].ToString()), null);
                            }
                            else
                            {
                                throw new Exception(string.Format("尝试对{0}类型对象的属性{1}赋值时出错，未找到属于匹配的数据类型.", typeof(TEntity).Name, pi.Name));
                            }
                        }
                        else
                            pi.SetValue(entity, null, null);

                    }
                }
                resultList.Add(entity);
            }
            return resultList;
        }
    }
}
