using HR.WorkflowService.Common;
////using HR.WorkflowService.DAOs;
using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 办文材料
    /// </summary>
    [DataContract]
    public class BWCL : CommonEntity
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BWCL() : base("BIZ_INFO_BWCL") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="xH">序号</param>
        ///<param name="cLMC">材料名称</param>
        ///<param name="cLFZ">材料分组</param>
        ///<param name="cLYS">材料页数</param>
        ///<param name="dATAORIGIN">0或null系统生成数据，1迁移数据，2初始录入</param>
        ///<param name="iSDELETE">是否删除</param>
        ///<param name="iSSHARE">是否共享</param>
        ///<param name="iSVALID">是否有效</param>
        ///<param name="iSCONFIG">是否可配置</param>
        ///<param name="sORTORDER">顺序号</param>
        ///<param name="oRGANIZATIONID">组织机构部门</param>
        ///<param name="cREATEPERSONID">创建人ID</param>
        ///<param name="cREATEDATE">创建日期</param>
        ///<param name="mODIFYPERSONID">修改人</param>
        ///<param name="mODIFYDATE">修改日期</param>
        public BWCL(string iD, decimal? xH, string cLMC, string cLFZ, decimal? cLYS, int dATAORIGIN, int iSDELETE, int iSSHARE, int iSVALID, int iSCONFIG, int? sORTORDER, string oRGANIZATIONID, string cREATEPERSONID, DateTime? cREATEDATE, string mODIFYPERSONID, DateTime? mODIFYDATE)
            : this()
        {
            this.ID = iD;
            this.XH = xH;
            this.CLMC = cLMC;
            this.CLFZ = cLFZ;
            this.CLYS = cLYS;
            this.DATAORIGIN = dATAORIGIN;
            this.ISDELETE = iSDELETE;
            this.ISSHARE = iSSHARE;
            this.ISVALID = iSVALID;
            this.ISCONFIG = iSCONFIG;
            this.SORTORDER = sORTORDER;
            this.ORGANIZATIONID = oRGANIZATIONID;
            this.CREATEPERSONID = cREATEPERSONID;
            this.CREATEDATE = cREATEDATE;
            this.MODIFYPERSONID = mODIFYPERSONID;
            this.MODIFYDATE = mODIFYDATE;
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
            sb.Append(this.XH);
            sb.Append(this.CLMC);
            sb.Append(this.CLFZ);
            sb.Append(this.CLYS);
            //sb.Append(this.YJFS);
            //sb.Append(this.FYJFS);
            sb.Append(this.DATAORIGIN);
            sb.Append(this.ISDELETE);
            sb.Append(this.ISSHARE);
            sb.Append(this.ISVALID);
            sb.Append(this.ISCONFIG);
            sb.Append(this.SORTORDER);
            sb.Append(this.ORGANIZATIONID);
            sb.Append(this.CREATEPERSONID);
            sb.Append(this.CREATEDATE);
            sb.Append(this.MODIFYPERSONID);
            sb.Append(this.MODIFYDATE);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public virtual decimal? XH { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        [DataMember]
        public virtual string CLMC { get; set; }
        /// <summary>
        /// 材料分组
        /// </summary>
        [DataMember]
        public virtual string CLFZ { get; set; }
        /// <summary>
        /// 材料页数
        /// </summary>
        [DataMember]
        public virtual decimal? CLYS { get; set; }

        /// <summary>
        /// 收件类型
        /// </summary>
        [DataMember]
        public virtual decimal? SJLX { get; set; }
        #endregion

        #region 手动追加属性

        #endregion

        /// <summary>
        /// 保存验证
        /// </summary>
        /// <returns>验证通过与否</returns>
        public override bool OnBeforeSave()
        {
            return CheckRepeat<BWCL>(this, "CLMC", "材料名称不能相同");
        }
    }
}

