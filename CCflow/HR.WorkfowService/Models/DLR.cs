using HR.WorkflowService.Common;
using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 代理人
    /// </summary>
    [DataContract]
    public class DLR : CommonEntity
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public DLR() : base("BIZ_INFO_DLR") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
		///<param name="dLRMC">代理人名称</param>
		///<param name="dLRZJLX">代理人证件类型</param>
		///<param name="dLRZJH">代理人证件号</param>
		///<param name="dLRTXDZ">通信地址</param>
		///<param name="dLRYZBM">邮政编码</param>
		///<param name="dLRDHHM">代理人电话号码</param>
		///<param name="zGZSHM">资格证书号码</param>
		///<param name="sSJG">所属机构</param>
		///<param name="jGDM">机构代码，申请代码</param>
		///<param name="eMAIL">电子邮件</param>
		///<param name="iSDELETE">是否删除</param>
		///<param name="iSSHARE">是否共享</param>
		///<param name="iSVALID">是否有效</param>
		///<param name="iSCONFIG">是否可配置</param>
		///<param name="sORTORDER">顺序号</param>
		///<param name="cREATEPERSONID">创建人ID</param>
		///<param name="cREATEDATE">创建日期</param>
		///<param name="mODIFYPERSONID">修改人</param>
		///<param name="mODIFYDATE">修改日期</param>
		///<param name="dATAORIGIN">0或null系统生成数据，1迁移数据，2初始录入</param>
        public DLR(string iD, string dLRMC, string dLRZJLX, string dLRZJH, string dLRTXDZ, string dLRYZBM, string dLRDHHM, string zGZSHM, string sSJG, string jGDM, string eMAIL, int iSDELETE, int iSSHARE, int iSVALID, int iSCONFIG, int? sORTORDER, string cREATEPERSONID, DateTime? cREATEDATE, string mODIFYPERSONID, DateTime? mODIFYDATE, int dATAORIGIN)
            : this()
        {
            this.ID = iD;
            this.DLRMC = dLRMC;
            this.DLRZJLX = dLRZJLX;
            this.DLRZJH = dLRZJH;
            this.DLRTXDZ = dLRTXDZ;
            this.DLRYZBM = dLRYZBM;
            this.DLRDHHM = dLRDHHM;
            this.ZGZSHM = zGZSHM;
            this.SSJG = sSJG;
            this.JGDM = jGDM;
            this.EMAIL = eMAIL;
            this.ISDELETE = iSDELETE;
            this.ISSHARE = iSSHARE;
            this.ISVALID = iSVALID;
            this.ISCONFIG = iSCONFIG;
            this.SORTORDER = sORTORDER;
            this.CREATEPERSONID = cREATEPERSONID;
            this.CREATEDATE = cREATEDATE;
            this.MODIFYPERSONID = mODIFYPERSONID;
            this.MODIFYDATE = mODIFYDATE;
            this.DATAORIGIN = dATAORIGIN;
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
            sb.Append(this.DLRMC);
            sb.Append(this.DLRZJLX);
            sb.Append(this.DLRZJH);
            sb.Append(this.DLRTXDZ);
            sb.Append(this.DLRYZBM);
            sb.Append(this.DLRDHHM);
            sb.Append(this.ZGZSHM);
            sb.Append(this.SSJG);
            sb.Append(this.JGDM);
            sb.Append(this.EMAIL);
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
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 代理人名称
        /// </summary>
        [DataMember]
        public virtual string DLRMC { get; set; }
        /// <summary>
        /// 代理人证件类型
        /// </summary>
        [DataMember]
        public virtual string DLRZJLX { get; set; }
        /// <summary>
        /// 代理人证件号
        /// </summary>
        [DataMember]
        public virtual string DLRZJH { get; set; }
        /// <summary>
        /// 通信地址
        /// </summary>
        [DataMember]
        public virtual string DLRTXDZ { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        [DataMember]
        public virtual string DLRYZBM { get; set; }
        /// <summary>
        /// 代理人电话号码
        /// </summary>
        [DataMember]
        public virtual string DLRDHHM { get; set; }
        /// <summary>
        /// 资格证书号码
        /// </summary>
        [DataMember]
        public virtual string ZGZSHM { get; set; }
        /// <summary>
        /// 所属机构
        /// </summary>
        [DataMember]
        public virtual string SSJG { get; set; }
        /// <summary>
        /// 机构代码，申请代码
        /// </summary>
        [DataMember]
        public virtual string JGDM { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        [DataMember]
        public virtual string EMAIL { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

