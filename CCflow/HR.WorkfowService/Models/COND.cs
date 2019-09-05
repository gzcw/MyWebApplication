using HR.WorkflowService.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 连接线条件
    /// </summary>
    [DataContract]
    public class COND : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public COND() : base("WF_COND") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
		///<param name="mYPK">MyPK,-,主键</param>
		///<param name="cONDTYPE">条件类型</param>
		///<param name="dATAFROM">条件数据来源0表单,1岗位(对方向条件有效)</param>
		///<param name="fK_FLOW">流程</param>
		///<param name="nODEID">发生的事件MainNode</param>
		///<param name="fK_NODE">节点ID</param>
		///<param name="fK_ATTR">属性</param>
		///<param name="aTTRKEY">属性键</param>
		///<param name="aTTRNAME">中文名称</param>
		///<param name="fK_OPERATOR">运算符号</param>
		///<param name="oPERATORVALUE">要运算的值</param>
		///<param name="oPERATORVALUET">要运算的值T</param>
		///<param name="tONODEID">ToNodeID（对方向条件有效）</param>
		///<param name="cONNJUDGEWAY">条件关系,枚举类型:0,or;1,and;</param>
		///<param name="mYPOID">MyPOID</param>
		///<param name="pRI">计算优先级</param>
		///<param name="cONDORAND">方向条件类型</param>
        public COND(string mYPK, decimal? cONDTYPE, decimal? dATAFROM, string fK_FLOW, decimal? nODEID, decimal? fK_NODE, string fK_ATTR, string aTTRKEY, string aTTRNAME, string fK_OPERATOR, string oPERATORVALUE, string oPERATORVALUET, decimal? tONODEID, decimal? cONNJUDGEWAY, decimal? mYPOID, decimal? pRI, decimal? cONDORAND)
            : this()
        {
            this.MYPK = mYPK;
            this.CONDTYPE = cONDTYPE;
            this.DATAFROM = dATAFROM;
            this.FK_FLOW = fK_FLOW;
            this.NODEID = nODEID;
            this.FK_NODE = fK_NODE;
            this.FK_ATTR = fK_ATTR;
            this.ATTRKEY = aTTRKEY;
            this.ATTRNAME = aTTRNAME;
            this.FK_OPERATOR = fK_OPERATOR;
            this.OPERATORVALUE = oPERATORVALUE;
            this.OPERATORVALUET = oPERATORVALUET;
            this.TONODEID = tONODEID;
            this.CONNJUDGEWAY = cONNJUDGEWAY;
            this.MYPOID = mYPOID;
            this.PRI = pRI;
            this.CONDORAND = cONDORAND;
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
            sb.Append(this.CONDTYPE);
            sb.Append(this.DATAFROM);
            sb.Append(this.FK_FLOW);
            sb.Append(this.NODEID);
            sb.Append(this.FK_NODE);
            sb.Append(this.FK_ATTR);
            sb.Append(this.ATTRKEY);
            sb.Append(this.ATTRNAME);
            sb.Append(this.FK_OPERATOR);
            sb.Append(this.OPERATORVALUE);
            sb.Append(this.OPERATORVALUET);
            sb.Append(this.TONODEID);
            sb.Append(this.CONNJUDGEWAY);
            sb.Append(this.MYPOID);
            sb.Append(this.PRI);
            sb.Append(this.CONDORAND);
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
        /// 条件类型
        /// </summary>
        [DataMember]
        public virtual decimal? CONDTYPE { get; set; }
        /// <summary>
        /// 条件数据来源0表单,1岗位(对方向条件有效)
        /// </summary>
        [DataMember]
        public virtual decimal? DATAFROM { get; set; }
        /// <summary>
        /// 流程
        /// </summary>
        [DataMember]
        public virtual string FK_FLOW { get; set; }
        /// <summary>
        /// 发生的事件MainNode
        /// </summary>
        [DataMember]
        public virtual decimal? NODEID { get; set; }
        /// <summary>
        /// 节点ID
        /// </summary>
        [DataMember]
        public virtual decimal? FK_NODE { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        [DataMember]
        public virtual string FK_ATTR { get; set; }
        /// <summary>
        /// 属性键
        /// </summary>
        [DataMember]
        public virtual string ATTRKEY { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        [DataMember]
        public virtual string ATTRNAME { get; set; }
        /// <summary>
        /// 运算符号
        /// </summary>
        [DataMember]
        public virtual string FK_OPERATOR { get; set; }
        /// <summary>
        /// 要运算的值
        /// </summary>
        [DataMember]
        public virtual string OPERATORVALUE { get; set; }
        /// <summary>
        /// 要运算的值T
        /// </summary>
        [DataMember]
        public virtual string OPERATORVALUET { get; set; }
        /// <summary>
        /// ToNodeID（对方向条件有效）
        /// </summary>
        [DataMember]
        public virtual decimal? TONODEID { get; set; }
        /// <summary>
        /// 条件关系,枚举类型:0,or;1,and;
        /// </summary>
        [DataMember]
        public virtual decimal? CONNJUDGEWAY { get; set; }
        /// <summary>
        /// MyPOID
        /// </summary>
        [DataMember]
        public virtual decimal? MYPOID { get; set; }
        /// <summary>
        /// 计算优先级
        /// </summary>
        [DataMember]
        public virtual decimal? PRI { get; set; }
        /// <summary>
        /// 方向条件类型
        /// </summary>
        [DataMember]
        public virtual decimal? CONDORAND { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

