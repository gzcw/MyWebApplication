using HR.WorkflowService.Common;
using Iesi.Collections.Generic;
using Newtonsoft.Json;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;
using System.Linq;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 办文案
    /// </summary>
    [DataContract]
    public class BWA : CommonEntity, ICloneable
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BWA() : base("BIZ_INFO_BWA") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="bWLXID">办文类型ID</param>
        ///<param name="dJZG">登记字轨</param>
        ///<param name="dJLSH">登记流水号</param>
        ///<param name="dJZH">登记字号</param>
        ///<param name="qBWAID">之前的办文案ID</param>
        ///<param name="lCSLID">流程实例ID</param>
        ///<param name="yWFZ">申请类型名称</param>
        ///<param name="sQLX">申请类型</param>
        ///<param name="dQHJ">当前环节是否已提交.1提交,0未提交</param>
        ///<param name="dQHJMC">当前环节名称</param>
        ///<param name="sLBH">受理编号</param>
        ///<param name="aJZTBS">0处理中，1已办结，2崔办，3缓办，4督办，5挂起，-1注销</param>
        ///<param name="zL">这个是方便查询土地坐落、矿山坐落、房屋坐落的字段</param>
        ///<param name="ySBBS">与电子监察一起使用时的上报标记,,已上报的业务值为1</param>
        ///<param name="gDBS">用于档案流程-1为不用归档,0为需要归档，1为启动归档流程</param>
        ///<param name="yJBS">移交标识</param>
        ///<param name="rEGISTERDATE">立案时间</param>
        ///<param name="fINISHDATE">结案时间</param>
        ///<param name="sHDJZ">SH登记字</param>
        ///<param name="sHDJH">SH登记号</param>
        ///<param name="sHJHWCRQ">SH计划完成日期</param>
        ///<param name="iSDELETE">是否删除</param>
        ///<param name="iSSHARE">是否共享</param>
        ///<param name="iSVALID">是否有效</param>
        ///<param name="sORTORDER">顺序号</param>
        ///<param name="cREATEPERSONID">创建人ID</param>
        ///<param name="cREATEDATE">创建日期</param>
        ///<param name="mODIFYPERSONID">修改人</param>
        ///<param name="oRGANIZATIONID">组织机构部门</param>
        ///<param name="mODIFYDATE">修改日期</param>
        ///<param name="dATAORIGIN">0或null系统生成数据，1迁移数据，2初始录入</param>
        ///<param name="bWABZ">备注</param>
        ///<param name="sZTCBM">所在图层编码</param>
        ///<param name="tXGLZT">A=跳过计财，B=跳过局长，C=跳过打印发证</param>
        ///<param name="nPH">NP号</param>
        public BWA(string iD, string bWLXID, string dJZG, string dJLSH, string dJZH, string qBWAID, string lCSLID, string yWFZ, string sQLX, int? dQHJ, string dQHJMC, string sLBH, int? aJZTBS, string zL, int? ySBBS, int? gDBS, int? yJBS, DateTime rEGISTERDATE, DateTime? fINISHDATE, decimal? sHDJZ, int? sHDJH, DateTime sHJHWCRQ, int iSDELETE, int iSSHARE, int iSVALID, int? sORTORDER, string cREATEPERSONID, DateTime? cREATEDATE, string mODIFYPERSONID, string oRGANIZATIONID, DateTime? mODIFYDATE, int dATAORIGIN, string bWABZ, string sZTCBM, string tXGLZT, string nPH)
            : this()
        {
            this.ID = iD;
            this.BWLXID = bWLXID;
            this.DJZG = dJZG;
            this.DJLSH = dJLSH;
            this.DJZH = dJZH;
            this.QBWAID = qBWAID;
            this.LCSLID = lCSLID;
            this.YWFZ = yWFZ;
            this.SQLX = sQLX;
            this.DQHJ = dQHJ;
            this.DQHJMC = dQHJMC;
            this.SLBH = sLBH;
            this.AJZTBS = aJZTBS;
            this.ZL = zL;
            this.YSBBS = ySBBS;
            this.GDBS = gDBS;
            this.YJBS = yJBS;
            this.REGISTERDATE = rEGISTERDATE;
            this.FINISHDATE = fINISHDATE;
            this.SHDJZ = sHDJZ;
            this.SHDJH = sHDJH;
            this.SHJHWCRQ = sHJHWCRQ;
            this.ISDELETE = iSDELETE;
            this.ISSHARE = iSSHARE;
            this.ISVALID = iSVALID;
            this.SORTORDER = sORTORDER;
            this.CREATEPERSONID = cREATEPERSONID;
            this.CREATEDATE = cREATEDATE;
            this.MODIFYPERSONID = mODIFYPERSONID;
            this.ORGANIZATIONID = oRGANIZATIONID;
            this.MODIFYDATE = mODIFYDATE;
            this.DATAORIGIN = dATAORIGIN;
            this.BWABZ = bWABZ;
            this.SZTCBM = sZTCBM;
            this.TXGLZT = tXGLZT;
            this.NPH = nPH;
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
            sb.Append(this.BWLXID);
            sb.Append(this.DJZG);
            sb.Append(this.DJLSH);
            sb.Append(this.DJZH);
            sb.Append(this.QBWAID);
            sb.Append(this.LCSLID);
            sb.Append(this.YWFZ);
            sb.Append(this.SQLX);
            sb.Append(this.DQHJ);
            sb.Append(this.DQHJMC);
            sb.Append(this.SLBH);
            sb.Append(this.AJZTBS);
            sb.Append(this.ZL);
            sb.Append(this.YSBBS);
            sb.Append(this.GDBS);
            sb.Append(this.YJBS);
            sb.Append(this.REGISTERDATE);
            sb.Append(this.FINISHDATE);
            sb.Append(this.SHDJZ);
            sb.Append(this.SHDJH);
            sb.Append(this.SHJHWCRQ);
            sb.Append(this.ISDELETE);
            sb.Append(this.ISSHARE);
            sb.Append(this.ISVALID);
            sb.Append(this.SORTORDER);
            sb.Append(this.CREATEPERSONID);
            sb.Append(this.CREATEDATE);
            sb.Append(this.MODIFYPERSONID);
            sb.Append(this.ORGANIZATIONID);
            sb.Append(this.MODIFYDATE);
            sb.Append(this.DATAORIGIN);
            sb.Append(this.BWABZ);
            sb.Append(this.SZTCBM);
            sb.Append(this.TXGLZT);
            sb.Append(this.NPH);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 办文类型ID
        /// </summary>
        [DataMember]
        public virtual string BWLXID { get; set; }
        /// <summary>
        /// 登记字轨
        /// </summary>
        [DataMember]
        public virtual string DJZG { get; set; }
        /// <summary>
        /// 登记流水号
        /// </summary>
        [DataMember]
        public virtual string DJLSH { get; set; }
        /// <summary>
        /// 登记字号
        /// </summary>
        [DataMember]
        public virtual string DJZH { get; set; }
        /// <summary>
        /// 之前的办文案ID
        /// </summary>
        [DataMember]
        public virtual string QBWAID { get; set; }
        /// <summary>
        /// 流程实例ID
        /// </summary>
        [DataMember]
        public virtual string LCSLID { get; set; }
        /// <summary>
        /// 申请类型名称
        /// </summary>
        [DataMember]
        public virtual string YWFZ { get; set; }
        /// <summary>
        /// 申请类型
        /// </summary>
        [DataMember]
        public virtual string SQLX { get; set; }
        /// <summary>
        /// 当前环节是否已提交.1提交,0未提交
        /// </summary>
        [DataMember]
        public virtual int? DQHJ { get; set; }
        /// <summary>
        /// 当前环节名称
        /// </summary>
        [DataMember]
        public virtual string DQHJMC { get; set; }
        /// <summary>
        /// 受理编号
        /// </summary>
        [DataMember]
        public virtual string SLBH { get; set; }
        /// <summary>
        /// 0处理中，1已办结，2崔办，3缓办，4督办，5挂起，-1注销
        /// </summary>
        [DataMember]
        public virtual int? AJZTBS { get; set; }
        /// <summary>
        /// 这个是方便查询土地坐落、矿山坐落、房屋坐落的字段
        /// </summary>
        [DataMember]
        public virtual string ZL { get; set; }
        /// <summary>
        /// 与电子监察一起使用时的上报标记,,已上报的业务值为1
        /// </summary>
        [DataMember]
        public virtual int? YSBBS { get; set; }
        /// <summary>
        /// 用于档案流程-1为不用归档,0为需要归档，1为启动归档流程
        /// </summary>
        [DataMember]
        public virtual int? GDBS { get; set; }
        /// <summary>
        /// 移交标识
        /// </summary>
        [DataMember]
        public virtual int? YJBS { get; set; }
        /// <summary>
        /// 立案时间
        /// </summary>
        [DataMember]
        public virtual DateTime REGISTERDATE { get; set; }
        /// <summary>
        /// 结案时间
        /// </summary>
        [DataMember]
        public virtual DateTime? FINISHDATE { get; set; }
        /// <summary>
        /// SH登记字
        /// </summary>
        [DataMember]
        public virtual decimal? SHDJZ { get; set; }
        /// <summary>
        /// SH登记号
        /// </summary>
        [DataMember]
        public virtual int? SHDJH { get; set; }
        /// <summary>
        /// SH计划完成日期
        /// </summary>
        [DataMember]
        public virtual DateTime SHJHWCRQ { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string BWABZ { get; set; }
        /// <summary>
        /// 所在图层编码
        /// </summary>
        [DataMember]
        public virtual string SZTCBM { get; set; }
        /// <summary>
        /// A=跳过计财，B=跳过局长，C=跳过打印发证
        /// </summary>
        [DataMember]
        public virtual string TXGLZT { get; set; }
        /// <summary>
        /// NP号
        /// </summary>
        [DataMember]
        public virtual string NPH { get; set; }
        /// <summary>
        /// 行政区划代码
        /// </summary>
        [DataMember]
        public virtual string XZQHDM { get; set; }
        /// <summary>
        /// 申请人名称
        /// </summary>
        [DataMember]
        public virtual string SQRMC { get; set; }
        /// <summary>
        /// 义务人名称
        /// </summary>
        [DataMember]
        public virtual string YWRMC { get; set; }
        #endregion

        #region 手动追加属性

        /// <summary>
        /// 收件单
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public virtual SJD SJD
        {
            get;
            set;
        }
        /// <summary>
        /// 办文类型
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public virtual BWLX BWLX
        {
            get;
            set;
        }
        /// <summary>
        /// 申请人ID
        /// </summary>
        [DataMember]
        public virtual string SQRID
        {
            get
            {
                if (SJD != null && SJD.SJDSQRList.Count > 0)
                    return SJD.SJDSQRList.First().SQRID;
                return null;
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public virtual string LXDH
        {
            get
            {
                if (SJD != null)
                    return SJD.LXDH;
                return null;
            }
        }
        /// <summary>
        /// 通信地址
        /// </summary>
        [DataMember]
        public virtual string TXDZ
        {
            get
            {
                if (SJD != null && SJD.SJDSQRList.Count > 0 && SJD.SJDSQRList.First().SQR != null)
                    return SJD.SJDSQRList.First().SQR.TXDZ;
                return null;
            }
        }
        /// <summary>
        /// 图件号
        /// </summary>
        [DataMember]
        public virtual string TJH
        {
            get
            {
                if (SJD != null)
                    return SJD.TJH;
                return null;
            }
        }
        /// <summary>
        /// 收件人ID
        /// </summary>
        [DataMember]
        public virtual string SJR
        {
            get
            {
                if (SJD != null)
                    return SJD.SJR;
                return null;
            }
        }
        /// <summary>
        /// 收件时间
        /// </summary>
        [DataMember]
        public virtual DateTime? SJRQ
        {
            get
            {
                if (SJD != null)
                    return SJD.SJRQ;
                return null;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string BZ
        {
            get
            {
                if (SJD != null)
                    return SJD.BZ;
                return null;
            }
        }
        /// <summary>
        /// 办文类型名称
        /// </summary>
        [DataMember]
        public virtual string BWLXMC
        {
            get
            {
                if (BWLX != null)
                    return BWLX.BWLXMC;
                return null;
            }
        }
        /// <summary>
        /// 分组名称
        /// </summary>
        [DataMember]
        public virtual string FZMC
        {
            get
            {
                if (BWLX != null)
                    return BWLX.YWFZENTITY.FZMC;
                return null;
            }
        }
        /// <summary>
        /// 提醒用户
        /// </summary>
        [DataMember]
        public virtual string TIPUSERS
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// 克隆实体
        /// </summary>
        /// <returns>办文案对象</returns>
        public virtual object Clone()
        {
            return (BWA)this.MemberwiseClone();
        }
    }
}

