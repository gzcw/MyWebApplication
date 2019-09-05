using NHibernate.Transform;
using System.Collections;
using System.Collections.Generic;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// NHibernate查询返回的object类型结果(集)的转换类,转换为IList&lt;IDictionary&lt;string, object&gt;&gt;
    /// </summary>
    internal class ObjectResultSetTransformer : IResultTransformer
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
        /// 转换单个object对象为IDictionary&lt;string, object&gt;类型对象
        /// </summary>
        /// <param name="tuple">object对象属性成员值的数组</param>
        /// <param name="aliases">object对象属性成员名的数组</param>
        /// <returns>转换(组装)好的IDictionary&lt;string, object&gt;类型对象</returns>
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            IDictionary<string, object> resultObject = new Dictionary<string, object>();
            for (int i = 0; i < tuple.Length; i++)
            {
                string propertyName = aliases[i];
                if (propertyName != null)
                {
                    resultObject[propertyName.ToUpper()] = tuple[i];//全部属性名都使用大写字母
                }
            }
            return resultObject;
        }
    }
}
