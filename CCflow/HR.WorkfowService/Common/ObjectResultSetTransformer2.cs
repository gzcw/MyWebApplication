using NHibernate.Transform;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;


namespace HR.WorkflowService.Common
{
    /// <summary>
    /// NHibernate查询返回的object类型结果(集)的转换类,转换为IList&lt;dynamic&gt;
    /// </summary>
    internal class ObjectResultSetTransformer2 : IResultTransformer
    {
        /// <summary>
        /// 转换整个IList结果集
        /// </summary>
        /// <param name="collection">要转换的IList结果集</param>
        /// <returns>转换后的IList结果集</returns>
        public IList TransformList(IList collection)
        {
            return collection;
        }
        /// <summary>
        /// 转换单个object对象为dynamic类型(object对象转换成的实际类型为ExpandoObject)
        /// </summary>
        /// <param name="tuple">object对象属性成员值的数组</param>
        /// <param name="aliases">object对象属性成员名的数组</param>
        /// <returns>转换(组装)好的dynamic类型对象</returns>
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            IDictionary<string, object> resultObject = new ExpandoObject();
            for (int i = 0; i < tuple.Length; i++)
            {
                string propertyName = aliases[i];
                if (propertyName != null)
                {
                    if (propertyName == "ID")
                    {
                        resultObject[propertyName] = tuple[i];
                    }
                    else
                    {
                        resultObject[char.ToUpper(propertyName[0]) + propertyName.Substring(1, propertyName.Length - 1).ToLower()] = tuple[i];
                    }
                }
            }
            return resultObject as dynamic;
        }
    }
}
