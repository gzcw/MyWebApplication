using Iesi.Collections.Generic;
using PTXT;
using System;
using System.Runtime.Serialization;

namespace HR.Workflow.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SQRDLRRLT : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        public SQRDLRRLT() : base("BIZ_INFO_SQRDLRRLT") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
		///<param name="iD"></param>
		///<param name="dLRID"></param>
		///<param name="sQRID">申请人ID</param>
        public SQRDLRRLT(string iD, string dLRID, string sQRID)
            : this()
        {
            this.ID = iD;
            this.DLRID = dLRID;
            this.SQRID = sQRID;
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
            sb.Append(this.DLRID);
            sb.Append(this.SQRID);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string DLRID { get; set; }
        /// <summary>
        /// 申请人ID
        /// </summary>
        [DataMember]
        public virtual string SQRID { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

