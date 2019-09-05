using HR.WorkflowService.Common;
using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 办文类型
    /// </summary>
    [DataContract]
    public class BWLX : CommonEntity
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BWLX() : base("BIZ_INFO_BWLX") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="yWFZID">业务分组ID</param>
        ///<param name="yWFZ">申请类型名称</param>
        ///<param name="bWLXMC">办文类型名称</param>
        ///<param name="bWLXSM">办文类型说明</param>
        ///<param name="sFSJ">初始为不收件0，收件为1,,</param>
        ///<param name="sFGD">是否显示在档案签收列表里，0为不用归档的，1为要归档</param>
        ///<param name="dAFLID">档案分类ID</param>
        ///<param name="iSDELETE">是否删除</param>
        ///<param name="iSSHARE">是否共享</param>
        ///<param name="iSVALID">是否有效</param>
        ///<param name="iSCONFIG">是否可配置</param>
        ///<param name="oRGANIZATIONID">组织机构部门</param>
        ///<param name="sORTORDER">顺序号</param>
        ///<param name="cREATEPERSONID">创建人ID</param>
        ///<param name="cREATEDATE">创建日期</param>
        ///<param name="mODIFYPERSONID">修改人</param>
        ///<param name="mODIFYDATE">修改日期</param>
        ///<param name="dATAORIGIN">0或null系统生成数据，1迁移数据，2初始录入</param>
        ///<param name="bHID">编号ID</param>
        ///<param name="lCID">流程标识</param>
        public BWLX(string iD, string yWFZID, string yWFZ, string bWLXMC, string bWLXSM, int? sFSJ, int? sFGD, string dAFLID, int iSDELETE, int iSSHARE, int iSVALID, int iSCONFIG, string oRGANIZATIONID, int? sORTORDER, string cREATEPERSONID, DateTime? cREATEDATE, string mODIFYPERSONID, DateTime? mODIFYDATE, int dATAORIGIN, string bHID, string lCID)
            : this()
        {
            this.ID = iD;
            this.YWFZID = yWFZID;
            this.YWFZ = yWFZ;
            this.BWLXMC = bWLXMC;
            this.BWLXSM = bWLXSM;
            this.SFSJ = sFSJ;
            this.SFGD = sFGD;
            this.DAFLID = dAFLID;
            this.ISDELETE = iSDELETE;
            this.ISSHARE = iSSHARE;
            this.ISVALID = iSVALID;
            this.ISCONFIG = iSCONFIG;
            this.ORGANIZATIONID = oRGANIZATIONID;
            this.SORTORDER = sORTORDER;
            this.CREATEPERSONID = cREATEPERSONID;
            this.CREATEDATE = cREATEDATE;
            this.MODIFYPERSONID = mODIFYPERSONID;
            this.MODIFYDATE = mODIFYDATE;
            this.DATAORIGIN = dATAORIGIN;
            this.BHID = bHID;
            this.LCID = lCID;
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
            sb.Append(this.YWFZID);
            sb.Append(this.YWFZ);
            sb.Append(this.BWLXMC);
            sb.Append(this.BWLXSM);
            sb.Append(this.SFSJ);
            sb.Append(this.SFGD);
            sb.Append(this.DAFLID);
            sb.Append(this.ISDELETE);
            sb.Append(this.ISSHARE);
            sb.Append(this.ISVALID);
            sb.Append(this.ISCONFIG);
            sb.Append(this.ORGANIZATIONID);
            sb.Append(this.SORTORDER);
            sb.Append(this.CREATEPERSONID);
            sb.Append(this.CREATEDATE);
            sb.Append(this.MODIFYPERSONID);
            sb.Append(this.MODIFYDATE);
            sb.Append(this.DATAORIGIN);
            sb.Append(this.BHID);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 业务分组ID
        /// </summary>
        [DataMember]
        public virtual string YWFZID { get; set; }
        /// <summary>
        /// 申请类型名称
        /// </summary>
        [DataMember]
        public virtual string YWFZ { get; set; }
        /// <summary>
        /// 办文类型名称
        /// </summary>
        [DataMember]
        public virtual string BWLXMC { get; set; }
        /// <summary>
        /// 办文类型说明
        /// </summary>
        [DataMember]
        public virtual string BWLXSM { get; set; }
        /// <summary>
        /// 初始为不收件0，收件为1,,
        /// </summary>
        [DataMember]
        public virtual int? SFSJ { get; set; }
        /// <summary>
        /// 是否显示在档案签收列表里，0为不用归档的，1为要归档
        /// </summary>
        [DataMember]
        public virtual int? SFGD { get; set; }
        /// <summary>
        /// 档案分类ID
        /// </summary>
        [DataMember]
        public virtual string DAFLID { get; set; }
        /// <summary>
        /// 编号ID
        /// </summary>
        [DataMember]
        public virtual string BHID { get; set; }
        /// <summary>
        /// 登记字号ID
        /// </summary>
        [DataMember]
        public virtual string DJZHID { get; set; }
        /// <summary>
        /// 流程ID
        /// </summary>
        [DataMember]
        public virtual string LCID { get; set; }

        /// <summary>
        /// 计划完成天数
        /// </summary>
        [DataMember]
        public virtual string JHWCTS { get; set; }
        #endregion

        #region 手动追加属性
        /// <summary>
        /// 业务分组实体
        /// </summary>
        [JsonIgnore]
        public virtual YWFZ YWFZENTITY
        {
            get;
            set;
        }

        #endregion
    }
}

