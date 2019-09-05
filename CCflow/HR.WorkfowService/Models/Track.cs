using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 流程运行轨迹
    /// </summary>
    public class Track
    {
        /// <summary>
        /// 日期时间
        /// </summary>
        public string RDT
        {
            get;
            set;
        }
        /// <summary>
        /// 从节点
        /// </summary>
        public string NDFrom
        {
            get;
            set;
        }
        /// <summary>
        /// 从节点名称
        /// </summary>
        public string NDFromT
        {
            get;
            set;
        }
        /// <summary>
        /// 从人员
        /// </summary>
        public string EmpFromT
        {
            get;
            set;
        }
        /// <summary>
        /// 从人员
        /// </summary>
        public string EmpFrom
        {
            get;
            set;
        }
        /// <summary>
        /// 到节点
        /// </summary>
        public string NDTo
        {
            get;
            set;
        }
        /// <summary>
        /// 到节点名称
        /// </summary>
        public string NDToT
        {
            get;
            set;
        }
        /// <summary>
        /// 到人员
        /// </summary>
        public string EmpToT
        {
            get;
            set;
        }
        /// <summary>
        /// 到人员
        /// </summary>
        public string EmpTo
        {
            get;
            set;
        }
        /// <summary>
        /// 实际执行人
        /// </summary>
        public string Exer
        {
            get;
            set;
        }
        /// <summary>
        /// 操作类型
        /// </summary>
        public int ActionType
        {
            get;
            set;
        }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg
        {
            get;
            set;
        }
        /// <summary>
        /// 流程状态标识
        /// </summary>
        public int WfState
        {
            get;
            set;
        }
        /// <summary>
        /// 是否读取
        /// </summary>
        public int IsRead
        {
            get;
            set;
        }
        /// <summary>
        /// 是否读取
        /// </summary>
        public int IsPass
        {
            get;
            set;
        }
    }
}
