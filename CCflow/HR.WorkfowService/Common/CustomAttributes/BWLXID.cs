using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.WorkflowService.Common.CustomAttributes
{
    /// <summary>
    /// 办文类型特性
    /// </summary>
    public class BWLXID : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Id">标识</param>
        public BWLXID(string Id)
        {
            IDs = Id.Split(',').ToArray();
        }

        /// <summary>
        /// 标识
        /// </summary>
        public string[] IDs
        {
            get;
            set;
        }
    }
}