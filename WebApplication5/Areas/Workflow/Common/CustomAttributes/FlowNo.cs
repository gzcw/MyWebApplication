using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Areas.Workflow.Common.CustomAttributes
{
    /// <summary>
    /// 流程编号特性
    /// </summary>
    public class FlowNo : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="No">标识</param>
        public FlowNo(string No)
        {
            IDs = No.Split(',').ToArray();
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