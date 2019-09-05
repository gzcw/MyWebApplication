using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 工作明细
    /// </summary>
    public class GenerWorkerlist
    {
        /// <summary>
        /// 工作节点
        /// </summary>
        public int WorkID
        {
            get;
            set;
        }

        /// <summary>
        /// 流程节点
        /// </summary>
        public string FK_Node
        {
            get;
            set;
        }

        /// <summary>
        /// 处理用户
        /// </summary>
        public string FK_Emp
        {
            get;
            set;
        }

        /// <summary>
        /// 处理用户名称
        /// </summary>
        public string FK_EmpText
        {
            get;
            set;
        }

        /// <summary>
        /// 部门
        /// </summary>
        public string FK_Dept {
            get;
            set;
        }

        /// <summary>
        /// 记录时间
        /// </summary>
        public string RDT
        {
            get;
            set;
        }

        /// <summary>
        /// 警告时间
        /// </summary>
        public string DTOFWARNING
        {
            get;
            set;
        }

        /// <summary>
        /// 转发时间
        /// </summary>
        public string ZDT
        {
            get
            {
                return DTOFWARNING;
            }
        }

        /// <summary>
        /// 完成时间
        /// </summary>
        public string CDT
        {
            get;
            set;
        }

        /// <summary>
        /// 转发人
        /// </summary>
        public string Sender
        {
            get;
            set;
        }

        /// <summary>
        /// 已读
        /// </summary>
        public string ISREAD
        {
            get;
            set;
        }

        /// <summary>
        /// 已通过
        /// </summary>
        public string ISPASS
        {
            get;
            set;
        }


    }
}
