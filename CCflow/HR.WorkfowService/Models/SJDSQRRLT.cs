using Iesi.Collections.Generic;
using Newtonsoft.Json;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 收件单与申请人关系
    /// </summary>
    [DataContract]
    public class SJDSQRRLT : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public SJDSQRRLT() : base("BIZ_INFO_SJDSQRRLT") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="sQRID">申请人ID,</param>
        ///<param name="sJDID">一般用办文案ID</param>
        public SJDSQRRLT(string iD, string sQRID, string sJDID)
            : this()
        {
            this.ID = iD;
            this.SQRID = sQRID;
            this.SJDID = sJDID;
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
            sb.Append(this.SQRID);
            sb.Append(this.SJDID);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 申请人ID,
        /// </summary>
        [DataMember]
        public virtual string SQRID { get; set; }
        /// <summary>
        /// 一般用办文案ID
        /// </summary>
        [DataMember]
        public virtual string SJDID { get; set; }
        /// <summary>
        /// 申请人角色
        /// </summary>
        [DataMember]
        public virtual string SQRJS { get; set; }
        /// <summary>
        /// 代理人ID
        /// </summary>
        [DataMember]
        public virtual string DLRID { get; set; }
        #endregion

        #region 手动追加属性

        /// <summary>
        /// 申请人
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public virtual SQR SQR
        {
            get;
            set;
        }

        #endregion
    }
}

