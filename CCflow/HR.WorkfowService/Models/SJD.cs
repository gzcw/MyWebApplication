using Iesi.Collections.Generic;
using Newtonsoft.Json;
using HR.WorkflowService.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 收件单
    /// </summary>
    [DataContract]
    public class SJD : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public SJD() : base("BIZ_INFO_SJD") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="bWAID">办文案ID</param>
        ///<param name="sJH">收件号</param>
        ///<param name="lXR">联系人</param>
        ///<param name="lXDH">联系电话</param>
        ///<param name="lXDZ">联系地址</param>
        ///<param name="jJRZJLX">权利人证件类型</param>
        ///<param name="jJRZJH">权利人证件号</param>
        ///<param name="sJR">收件人</param>
        ///<param name="sJRQ">收件日期</param>
        ///<param name="wXTS">温馨提示</param>
        ///<param name="bZ">备注</param>
        ///<param name="tJH">图件号</param>
        ///<param name="dATAORIGIN">0或null系统生成数据，1迁移数据，2初始录入</param>
        ///<param name="tCMC">图层名称</param>
        ///<param name="cREATEPERSONID">创建人ID</param>
        ///<param name="cREATEDATE">创建日期</param>
        ///<param name="mODIFYPERSONID">修改人</param>
        ///<param name="mODIFYDATE">修改日期</param>
        ///<param name="oRGANIZATIONID">组织机构部门</param>
        public SJD(string iD, string bWAID, string sJH, string lXR, string lXDH, string lXDZ, string jJRZJLX, string jJRZJH, string sJR, DateTime sJRQ, string wXTS, string bZ, string tJH, decimal? dATAORIGIN, string tCMC, string cREATEPERSONID, DateTime cREATEDATE, string mODIFYPERSONID, DateTime mODIFYDATE, string oRGANIZATIONID)
            : this()
        {
            this.ID = iD;
            this.BWAID = bWAID;
            this.SJH = sJH;
            this.LXR = lXR;
            this.LXDH = lXDH;
            this.LXDZ = lXDZ;
            this.JJRZJLX = jJRZJLX;
            this.JJRZJH = jJRZJH;
            this.SJR = sJR;
            this.SJRQ = sJRQ;
            this.WXTS = wXTS;
            this.BZ = bZ;
            this.TJH = tJH;
            this.DATAORIGIN = dATAORIGIN;
            this.TCMC = tCMC;
            this.CREATEPERSONID = cREATEPERSONID;
            this.CREATEDATE = cREATEDATE;
            this.MODIFYPERSONID = mODIFYPERSONID;
            this.MODIFYDATE = mODIFYDATE;
            this.ORGANIZATIONID = oRGANIZATIONID;
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
            sb.Append(this.SJH);
            sb.Append(this.LXR);
            sb.Append(this.LXDH);
            sb.Append(this.LXDZ);
            sb.Append(this.JJRZJLX);
            sb.Append(this.JJRZJH);
            sb.Append(this.SJR);
            sb.Append(this.SJRQ);
            sb.Append(this.WXTS);
            sb.Append(this.BZ);
            sb.Append(this.TJH);
            sb.Append(this.DATAORIGIN);
            sb.Append(this.TCMC);
            sb.Append(this.CREATEPERSONID);
            sb.Append(this.CREATEDATE);
            sb.Append(this.MODIFYPERSONID);
            sb.Append(this.MODIFYDATE);
            sb.Append(this.ORGANIZATIONID);
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
        /// 收件号
        /// </summary>
        [DataMember]
        public virtual string SJH { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        public virtual string LXR { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public virtual string LXDH { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        [DataMember]
        public virtual string LXDZ { get; set; }
        /// <summary>
        /// 权利人证件类型
        /// </summary>
        [DataMember]
        public virtual string JJRZJLX { get; set; }
        /// <summary>
        /// 权利人证件号
        /// </summary>
        [DataMember]
        public virtual string JJRZJH { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        [DataMember]
        public virtual string SJR { get; set; }
        /// <summary>
        /// 收件日期
        /// </summary>
        [DataMember]
        public virtual DateTime SJRQ { get; set; }
        /// <summary>
        /// 温馨提示
        /// </summary>
        [DataMember]
        public virtual string WXTS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string BZ { get; set; }
        /// <summary>
        /// 图件号
        /// </summary>
        [DataMember]
        public virtual string TJH { get; set; }
        /// <summary>
        /// 0或null系统生成数据，1迁移数据，2初始录入
        /// </summary>
        [DataMember]
        public virtual decimal? DATAORIGIN { get; set; }
        /// <summary>
        /// 图层名称
        /// </summary>
        [DataMember]
        public virtual string TCMC { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [DataMember]
        public virtual string CREATEPERSONID { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        public virtual DateTime CREATEDATE { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [DataMember]
        public virtual string MODIFYPERSONID { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public virtual DateTime MODIFYDATE { get; set; }
        /// <summary>
        /// 组织机构部门
        /// </summary>
        [DataMember]
        public virtual string ORGANIZATIONID { get; set; }
        #endregion

        #region 手动追加属性

        /// <summary>
        /// 申请人列表
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public virtual ISet<SJDSQRRLT> SJDSQRList
        {
            get;
            set;
        }

        /// <summary>
        /// 默认申请人ID
        /// </summary>
        public virtual string SQRID
        {
            get
            {
                if (SJDSQRList.Count > 0)
                    return SJDSQRList.First().SQRID;
                return null;
            }
        }

        /// <summary>
        /// 办文案
        /// </summary>
        [DataMember]
        [JsonIgnore]
        public virtual BWA BWA
        {
            get;
            set;
        }

        #endregion
    }
}

