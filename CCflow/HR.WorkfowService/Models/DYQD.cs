using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 打印清单
    /// </summary>
    [DataContract]
    public class DYQD : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public DYQD() : base("BIZ_INFO_DYQD") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
		///<param name="nAME">名称</param>
		///<param name="nODE_ID">节点标识</param>
        public DYQD(string iD, string nAME, string nODE_ID)
            : this()
        {
            this.ID = iD;
            this.NAME = nAME;
            this.NODE_ID = nODE_ID;
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
            sb.Append(this.NAME);
            sb.Append(this.NODE_ID);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public virtual string NAME { get; set; }
        /// <summary>
        /// 节点标识
        /// </summary>
        [DataMember]
        public virtual string NODE_ID { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [DataMember]
        public virtual string URL { get; set; }
        /// <summary>
        /// 办文类型标识
        /// </summary>
        [DataMember]
        public virtual string BWLX_ID { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

