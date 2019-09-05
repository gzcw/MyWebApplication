using HR.WorkflowService.Common;
using Iesi.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 业务分组
    /// </summary>
    [DataContract]
    public class YWFZ : CommonEntity
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public YWFZ() : base("BIZ_INFO_YWFZ") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
		///<param name="iD">办文类型ID</param>
		///<param name="fZMC">分组名称</param>
		///<param name="fZSM">分组说明</param>
        public YWFZ(string iD, string fZMC, string fZSM)
            : this()
        {
            this.ID = iD;
            this.FZMC = fZMC;
            this.FZSM = fZSM;
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
            sb.Append(this.FZMC);
            sb.Append(this.FZSM);
            sb.Append(this.ISDELETE);
            sb.Append(this.ISSHARE);
            sb.Append(this.ISVALID);
            sb.Append(this.ISCONFIG);
            sb.Append(this.SORTORDER);
            sb.Append(this.CREATEPERSONID);
            sb.Append(this.CREATEDATE);
            sb.Append(this.MODIFYPERSONID);
            sb.Append(this.MODIFYDATE);
            sb.Append(this.DATAORIGIN);
            sb.Append(this.ORGANIZATIONID);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 分组名称
        /// </summary>
        [DataMember]
        public virtual string FZMC { get; set; }
        /// <summary>
        /// 分组说明
        /// </summary>
        [DataMember]
        public virtual string FZSM { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

