using HR.WorkflowService.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 节点岗位
    /// </summary>
    [DataContract]
    public class NODESTATION : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public NODESTATION() : base("WF_NODESTATION") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
		///<param name="fK_NODE">节点,-,主键</param>
		///<param name="fK_STATION">工作岗位,,主外键:对应物理表:Port_Station,表描述:岗位</param>
        public NODESTATION(decimal fK_NODE, string fK_STATION)
            : this()
        {
            this.FK_NODE = fK_NODE;
            this.FK_STATION = fK_STATION;
        }
        #endregion

        #region 其他方法
        /// <summary>
        /// 重写实体对象哈希值的获取方法
        /// </summary>
        /// <returns>实体对象的哈希值</returns>
        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(this.GetType().FullName);
            sb.Append(this.FK_NODE);
            sb.Append(this.FK_STATION);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 节点,-,主键
        /// </summary>
        [DataMember]
        public virtual decimal FK_NODE { get; set; }
        /// <summary>
        /// 工作岗位,,主外键:对应物理表:Port_Station,表描述:岗位
        /// </summary>
        [DataMember]
        public virtual string FK_STATION { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

