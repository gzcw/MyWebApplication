using HR.WorkflowService.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 连接线
    /// </summary>
    [DataContract]
    public class DIRECTION : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public DIRECTION() : base("WF_DIRECTION") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
		///<param name="mYPK">MyPK,-,主键</param>
		///<param name="fK_FLOW">流程</param>
		///<param name="nODE">从节点</param>
		///<param name="tONODE">到节点</param>
		///<param name="dIRTYPE">类型0前进1返回</param>
		///<param name="iSCANBACK">是否可以原路返回(对后退线有效)</param>
		///<param name="dOTS">轨迹信息</param>
        public DIRECTION(string mYPK, string fK_FLOW, int? nODE, int? tONODE, decimal? dIRTYPE, decimal? iSCANBACK, string dOTS)
            : this()
        {
            this.MYPK = mYPK;
            this.FK_FLOW = fK_FLOW;
            this.NODE = nODE;
            this.TONODE = tONODE;
            this.DIRTYPE = dIRTYPE;
            this.ISCANBACK = iSCANBACK;
            this.DOTS = dOTS;
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
            sb.Append(this.MYPK);
            sb.Append(this.FK_FLOW);
            sb.Append(this.NODE);
            sb.Append(this.TONODE);
            sb.Append(this.DIRTYPE);
            sb.Append(this.ISCANBACK);
            sb.Append(this.DOTS);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// MyPK,-,主键
        /// </summary>
        [DataMember]
        public virtual string MYPK { get; set; }
        /// <summary>
        /// 流程
        /// </summary>
        [DataMember]
        public virtual string FK_FLOW { get; set; }
        /// <summary>
        /// 从节点
        /// </summary>
        [DataMember]
        public virtual int? NODE { get; set; }
        /// <summary>
        /// 到节点
        /// </summary>
        [DataMember]
        public virtual int? TONODE { get; set; }
        /// <summary>
        /// 类型0前进1返回
        /// </summary>
        [DataMember]
        public virtual decimal? DIRTYPE { get; set; }
        /// <summary>
        /// 是否可以原路返回(对后退线有效)
        /// </summary>
        [DataMember]
        public virtual decimal? ISCANBACK { get; set; }
        /// <summary>
        /// 轨迹信息
        /// </summary>
        [DataMember]
        public virtual string DOTS { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

