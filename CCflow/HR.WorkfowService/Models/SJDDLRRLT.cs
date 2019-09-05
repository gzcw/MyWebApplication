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
    public class SJDDLRRLT : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        public SJDDLRRLT() : base("BIZ_INFO_SJDDLRRLT") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
		///<param name="iD"></param>
		///<param name="sJDID">一般用办文案ID</param>
		///<param name="dLRID"></param>
        public SJDDLRRLT(string iD, string sJDID, string dLRID)
            : this()
        {
            this.ID = iD;
            this.SJDID = sJDID;
            this.DLRID = dLRID;
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
            sb.Append(this.SJDID);
            sb.Append(this.DLRID);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 一般用办文案ID
        /// </summary>
        [DataMember]
        public virtual string SJDID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public virtual string DLRID { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

