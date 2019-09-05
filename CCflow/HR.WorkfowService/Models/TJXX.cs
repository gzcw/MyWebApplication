using HR.WorkflowService.Common;
using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 退件信息
    /// </summary>
    [DataContract]
    public class TJXX : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)
        private DateTime? createtime = DateTime.Now;

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public TJXX() : base("BIZ_INFO_TJXX") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="bWAID">办文案ID</param>
        ///<param name="sLBH">受理编号</param>
        ///<param name="yWFZ">业务分组</param>
        ///<param name="yWLX">业务类型</param>
        ///<param name="tJYY">退件原因</param>
        ///<param name="cREATORID">创建人</param>
        ///<param name="cREATETIME">创建时间</param>
        public TJXX(string iD, string bWAID, string sLBH, string yWFZ, string yWLX, string tJYY, string cREATORID, DateTime? cREATETIME)
            : this()
        {
            this.ID = iD;
            this.BWAID = bWAID;
            this.SLBH = sLBH;
            this.YWFZ = yWFZ;
            this.YWLX = yWLX;
            this.TJYY = tJYY;
            this.CREATORID = cREATORID;
            this.CREATETIME = cREATETIME;
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
            sb.Append(this.BWAID);
            sb.Append(this.SLBH);
            sb.Append(this.YWFZ);
            sb.Append(this.YWLX);
            sb.Append(this.TJYY);
            sb.Append(this.CREATORID);
            sb.Append(this.CREATETIME);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 办文案ID
        /// </summary>
        [DataMember]
        public virtual string BWAID { get; set; }
        /// <summary>
        /// 受理编号
        /// </summary>
        [DataMember]
        public virtual string SLBH { get; set; }
        /// <summary>
        /// 业务分组
        /// </summary>
        [DataMember]
        public virtual string YWFZ { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        [DataMember]
        public virtual string YWLX { get; set; }
        /// <summary>
        /// 退件原因
        /// </summary>
        [DataMember]
        public virtual string TJYY { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public virtual string CREATORID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public virtual DateTime? CREATETIME
        {
            get
            {
                return createtime;
            }
            set
            {
                createtime = value;
            }
        }
        #endregion

        #region 手动追加属性

        #endregion
    }
}

