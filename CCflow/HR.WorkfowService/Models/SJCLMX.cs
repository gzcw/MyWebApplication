using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

using System.Linq;


namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 收件材料明细
    /// </summary>
    [DataContract]
    public class SJCLMX : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public SJCLMX() : base("BIZ_INFO_SJCLMX") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="bWCLID">办文材料ID</param>
        ///<param name="sJDID">签收单ID</param>
        ///<param name="wJDLID">文件材料ID</param>
        ///<param name="sH">序号</param>
        ///<param name="cLMC">材料名称</param>
        ///<param name="cLBH">材料的证件编号</param>
        ///<param name="cLYS">材料页数</param>
        ///<param name="yJFS">原件份数</param>
        ///<param name="fYJFS">复印件份数</param>
        ///<param name="yJBS">移交标识</param>
        ///<param name="fJLJ">扫描件路径</param>
        ///<param name="sHBZ">SH备注</param>
        ///<param name="dATAORIGIN">0或null系统生成数据，1迁移数据，2初始录入</param>
        ///<param name="cLLYBS">材料来源标识：1窗口正常收件，2补交件；</param>
        public SJCLMX(string iD, string bWCLID, string sJDID, string wJDLID, decimal? sH, string cLMC, string cLBH, decimal? cLYS, decimal? yJFS, decimal? fYJFS, decimal? yJBS, string fJLJ, string sHBZ, decimal? dATAORIGIN, decimal? cLLYBS)
            : this()
        {
            this.ID = iD;
            this.BWCLID = bWCLID;
            this.SJDID = sJDID;
            this.WJDLID = wJDLID;
            this.SH = sH;
            this.CLMC = cLMC;
            this.CLBH = cLBH;
            this.CLYS = cLYS;
            //this.YJFS = yJFS;
            //this.FYJFS = fYJFS;
            this.YJBS = yJBS;
            this.FJLJ = fJLJ;
            this.SHBZ = sHBZ;
            this.DATAORIGIN = dATAORIGIN;
            this.CLLYBS = cLLYBS;
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
            sb.Append(this.BWCLID);
            sb.Append(this.SJDID);
            sb.Append(this.WJDLID);
            sb.Append(this.SH);
            sb.Append(this.CLMC);
            sb.Append(this.CLBH);
            sb.Append(this.CLYS);
            //sb.Append(this.YJFS);
            //sb.Append(this.FYJFS);
            sb.Append(this.YJBS);
            sb.Append(this.FJLJ);
            sb.Append(this.SHBZ);
            sb.Append(this.DATAORIGIN);
            sb.Append(this.CLLYBS);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 办文材料ID
        /// </summary>
        [DataMember]
        public virtual string BWCLID { get; set; }
        /// <summary>
        /// 签收单ID
        /// </summary>
        [DataMember]
        public virtual string SJDID { get; set; }
        /// <summary>
        /// 文件材料ID
        /// </summary>
        [DataMember]
        public virtual string WJDLID { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public virtual decimal? SH { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        [DataMember]
        public virtual string CLMC { get; set; }
        /// <summary>
        /// 材料的证件编号
        /// </summary>
        [DataMember]
        public virtual string CLBH { get; set; }
        /// <summary>
        /// 材料页数
        /// </summary>
        [DataMember]
        public virtual decimal? CLYS { get; set; }

        ///// <summary>
        ///// 原件份数
        ///// </summary>
        //[DataMember]
        //public virtual decimal? YJFS { get; set; }
        ///// <summary>
        ///// 复印件份数
        ///// </summary>
        //[DataMember]
        //public virtual decimal? FYJFS { get; set; }

        /// <summary>
        /// 移交标识
        /// </summary>
        [DataMember]
        public virtual decimal? YJBS { get; set; }
        /// <summary>
        /// 扫描件路径
        /// </summary>
        [DataMember]
        public virtual string FJLJ { get; set; }
        /// <summary>
        /// SH备注
        /// </summary>
        [DataMember]
        public virtual string SHBZ { get; set; }
        /// <summary>
        /// 0或null系统生成数据，1迁移数据，2初始录入
        /// </summary>
        [DataMember]
        public virtual decimal? DATAORIGIN { get; set; }
        /// <summary>
        /// 材料来源标识：1窗口正常收件，2补交件；
        /// </summary>
        [DataMember]
        public virtual decimal? CLLYBS { get; set; }

        /// <summary>
        /// 收件类型
        /// </summary>
        [DataMember]
        public virtual decimal? SJLX { get; set; }

        /// <summary>
        /// 收件数量
        /// </summary>
        [DataMember]
        public virtual decimal? SJSL { get; set; }

        /// <summary>
        /// 是否来源证明文件
        /// </summary>
        [DataMember]
        public virtual decimal? SFLYZMWJ { get; set; }
        #endregion

        #region 手动追加属性
        
        #endregion
    }
}

