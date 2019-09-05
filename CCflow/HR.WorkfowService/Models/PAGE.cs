using HR.WorkflowService.Common;
using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 页签
    /// </summary>
    [DataContract]
    public class PAGE : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public PAGE() : base("WF_SYS_Page") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
		///<param name="iD">主键ID</param>
		///<param name="definition_id">流程定义标识</param>
		///<param name="name">审核页签名称</param>
        ///<param name="url">审核页签路径</param>
        ///<param name="sortNumber">排序号</param>
        public PAGE(string iD, string definition_id, string name, string url,int sortNumber)
            : this()
        {
            this.ID = iD;
            this.FK_FLOW = definition_id;
            this.Name = name;
            this.Url = url;
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
            sb.Append(this.FK_FLOW);
            sb.Append(this.Name);
            sb.Append(this.Url);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 流程定义标识
        /// </summary>
        [DataMember]
        public virtual string FK_FLOW { get; set; }
        /// <summary>
        /// 审核页签名称
        /// </summary>
        [DataMember]
        public virtual string Name { get; set; }
        /// <summary>
        /// 审核页签路径
        /// </summary>
        [DataMember]
        public virtual string Url { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [DataMember]
        public virtual int Sortnumber { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

