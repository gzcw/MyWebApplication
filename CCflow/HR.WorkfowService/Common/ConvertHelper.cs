using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 转换帮助类
    /// </summary>
    public class ConvertHelper
    {
        /// <summary>
        /// 表格转换实例
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="table">表格数据</param>
        /// <returns></returns>
        public static List<T> GetList<T>(DataTable table)
        {
            if (table == null || table.Rows.Count == 0)
            {
                return new List<T>();
            }
            List<T> list = new List<T>();
            T t = default(T);
            PropertyInfo[] propertypes = null;
            string tempName = string.Empty;
            foreach (DataRow row in table.Rows)
            {
                t = Activator.CreateInstance<T>();
                propertypes = t.GetType().GetProperties();
                foreach (PropertyInfo pro in propertypes)
                {
                    tempName = pro.Name;
                    if (table.Columns.Contains(tempName))
                    {
                        object value = row[tempName];
                        if (!value.ToString().Equals(""))
                        {
                            var resultValue = Convert.ChangeType(value, pro.PropertyType);
                            pro.SetValue(t, resultValue, null);
                        }
                    }
                }
                list.Add(t);
            }
            return list;
        }
    }
}
