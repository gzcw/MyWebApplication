using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.WorkflowService.Common.Model
{
    /// <summary>
    /// 提醒实体
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// 信息内容
        /// </summary>
        public string Msg
        {
            get;
            set;
        }
    }
}