using HR.BasicFramework.DataAccess;
using HR.WorkflowService.Common;
////using HR.WorkflowService.DAOs;
using Iesi.Collections.Generic;
using Newtonsoft.Json;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 办文类型与办文材料关系
    /// </summary>
    [DataContract]
    public class BWLXBWCLRLT : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BWLXBWCLRLT() : base("BIZ_INFO_BWLXBWCLRLT") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="bWLXID">办文类型ID</param>
        ///<param name="bWCLID">办文材料ID</param>
        ///<param name="cLYS">材料页数</param>
        ///<param name="iSCONFIG">是否可配置</param>
        ///<param name="bBCLBS">必备材料标识</param>
        ///<param name="dATAORIGIN">0或null系统生成数据，1迁移数据，2初始录入</param>
        public BWLXBWCLRLT(string iD, string bWLXID, string bWCLID, decimal? yJFS, decimal? fYJFS, decimal? cLYS, decimal iSCONFIG, decimal? bBCLBS, decimal? dATAORIGIN)
            : this()
        {
            this.ID = iD;
            this.BWLXID = bWLXID;
            this.BWCLID = bWCLID;
            //this.YJFS = yJFS;
            //this.FYJFS = fYJFS;
            this.CLYS = cLYS;
            this.ISCONFIG = iSCONFIG;
            this.BBCLBS = bBCLBS;
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
            sb.Append(this.BWLXID);
            sb.Append(this.BWCLID);
            //sb.Append(this.YJFS);
            //sb.Append(this.FYJFS);
            sb.Append(this.CLYS);
            sb.Append(this.ISCONFIG);
            sb.Append(this.BBCLBS);
            sb.Append(this.DATAORIGIN);
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
        /// 办文材料ID
        /// </summary>
        [DataMember]
        public virtual string BWCLID { get; set; }

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
        /// 材料页数
        /// </summary>
        [DataMember]
        public virtual decimal? CLYS { get; set; }
        /// <summary>
        /// 是否可配置
        /// </summary>
        [DataMember]
        public virtual decimal ISCONFIG { get; set; }
        /// <summary>
        /// 必备材料标识
        /// </summary>
        [DataMember]
        public virtual decimal? BBCLBS { get; set; }
        /// <summary>
        /// 0或null系统生成数据，1迁移数据，2初始录入
        /// </summary>
        [DataMember]
        public virtual decimal? DATAORIGIN { get; set; }
        
        /// <summary>
        /// 收件数量
        /// </summary>
        [DataMember]
        public virtual decimal? SJSL { get; set; }
        
        /// <summary>
        /// 顺序号
        /// </summary>
        [DataMember]
        public virtual decimal? SORTORDER { get; set; }
        
        
        #endregion

        #region 手动追加属性
        /// <summary>
        /// 办文材料
        /// </summary>
        public virtual BWCL BWCL
        {
            get
            {
                if (string.IsNullOrEmpty(BWCLID))
                {
                    return null;
                }
                //var bwclDAO = new BWCLDAO();
                //return bwclDAO.FindById(BWCLID);
                return DataContextNH.GetByID<BWCL>(BWCLID);
            }
        }

        #endregion
    }
}

