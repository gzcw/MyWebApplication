using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 流程节点
    /// </summary>
    public class FlowNode
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public int NodeID
        {
            get;
            set;
        }
        /// <summary>
        /// 流程ID
        /// </summary>
        public string FK_Flow
        {
            get;
            set;
        }
        /// <summary>
        /// 步骤
        /// </summary>
        public int Step
        {
            get;
            set;
        }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 被退回节点上的操作员编号
        /// </summary>
        public string Rec
        {
            get;
            set;
        }

        /// <summary>
        /// 被退回节点上的操作员名称
        /// </summary>
        public string RecName
        {
            get;
            set;
        }

        /// <summary>
        /// 条件模式
        /// </summary>
        public int CondModel
        {
            get;
            set;
        }

        /// <summary>
        /// 运行模式
        /// </summary>
        public int RunModel
        {
            get;
            set;
        }

        /// <summary>
        /// X轴
        /// </summary>
        public int X
        {
            get;
            set;
        }

        /// <summary>
        /// Y轴
        /// </summary>
        public int Y
        {
            get;
            set;
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string DOC
        {
            get;
            set;
        }

        /// <summary>
        /// 抄送方式
        /// </summary>
        public string CCROLE
        {
            get;
            set;
        }
    }
}
