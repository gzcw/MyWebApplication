using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace HR.Workflow
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class MVCExtender
    {
        /// <summary>
        /// NameValueCollection扩展
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(this NameValueCollection source)
        {
            return source.AllKeys.ToDictionary(k => k, k => (object)source.Get(k));
        }
    }
}
