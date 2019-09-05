using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 节点页签
    /// </summary>
    [DataContract]
    public class NODEPAGE : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public NODEPAGE() : base("WF_SYS_NodePage") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="node_id">流程节点标识</param>
        ///<param name="page_id">流程页签标识</param>
        ///<param name="sortNumber">排序号</param>
        public NODEPAGE(string iD, string node_id, string page_id, int sortNumber)
            : this()
        {
            this.ID = iD;
            this.Node_id = node_id;
            this.Page_id = page_id;
            this.Sortnumber = sortNumber;
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
            sb.Append(this.Node_id);
            sb.Append(this.Page_id);
            sb.Append(this.Sortnumber);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 流程节点标识
        /// </summary>
        [DataMember]
        public virtual string Node_id { get; set; }
        /// <summary>
        /// 流程页签标识
        /// </summary>
        [DataMember]
        public virtual string Page_id { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [DataMember]
        public virtual int Sortnumber { get; set; }
        /// <summary>
        /// 权限 0：只读、1：读写
        /// </summary>
        [DataMember]
        public virtual int Permission { get; set; }
        /// <summary>
        /// 自定义参数
        /// </summary>
        [DataMember]
        public virtual string Params { get; set; }
        #endregion

        #region 手动追加属性

        #endregion
    }
}

