using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 流程数据
    /// </summary>
    public class FlowData
    {
        /// <summary>
        /// 流程编号
        /// </summary>
        public string FK_FLOW
        {
            get;
            set;
        }
        /// <summary>
        /// 流程编号
        /// </summary>
        public string FK_EMP
        {
            get;
            set;
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string TITLE
        {
            get;
            set;
        }
        /// <summary>
        /// 流程发起人
        /// </summary>
        public string STARTER
        {
            get;
            set;
        }
        /// <summary>
        /// 流程发起人姓名
        /// </summary>
        public string STARTNAME
        {
            get;
            set;
        }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string FLOWNAME
        {
            get;
            set;
        }
        /// <summary>
        /// 参与成员
        /// </summary>
        public string TODOEMPS
        {
            get;
            set;
        }
        /// <summary>
        /// 流程发起日期
        /// </summary>
        public DateTime RDT
        {
            get;
            set;
        }
        /// <summary>
        /// 审批节点
        /// </summary>
        public string NODENAME
        {
            get;
            set;
        }

        /// <summary>
        /// 工作标识
        /// </summary>
        public decimal WORKID
        {
            get;
            set;
        }
        /// <summary>
        /// 流程节点
        /// </summary>
        public decimal FK_NODE
        {
            get;
            set;
        }

        /// <summary>
        /// 父标识
        /// </summary>
        public decimal FID
        {
            get;
            set;
        }
        /// <summary>
        /// 流程状态
        /// </summary>
        public int WFSTATE
        {
            get;
            set;
        }
        /// <summary>
        /// 办文案标识
        /// </summary>
        public decimal BWAID
        {
            get
            {
                return FID > 0 ? FID : WORKID;
            }
        }

        /// <summary>
        /// 流程状态名称
        /// </summary>
        public string WFSTATENAME
        {
            get
            {
                return StateDic[WFSTATE];
            }
        }

        /// <summary>
        /// 是否已读
        /// </summary>
        public bool ISREAD
        {
            get;
            set;
        }

        /// <summary>
        /// 状态字典
        /// </summary>
        private static Dictionary<int, string> StateDic = new Dictionary<int, string>
        {
         {0,"空白"},
         {1,"草稿"},
         {2,"运行中"},
         {3,"已完成"},
         {4,"挂起"},
         {5,"退回"},
         {6,"转发"},
         {7,"删除"},
         {8,"加签"},
         {9,"冻结"},
         {10,"批处理"}
        };
    }
}
