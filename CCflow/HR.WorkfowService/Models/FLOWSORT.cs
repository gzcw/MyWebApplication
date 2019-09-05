using HR.WorkflowService.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 流程分组
    /// </summary>
    [DataContract]
    public class FLOWSORT : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public FLOWSORT() : base("WF_FLOWSORT") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
		///<param name="nO">编号,-,主键</param>
		///<param name="nAME">名称</param>
		///<param name="pARENTNO">父节点No</param>
		///<param name="tREENO">TreeNo</param>
		///<param name="iDX">Idx</param>
		///<param name="iSDIR">IsDir</param>
        public FLOWSORT(string nO, string nAME, string pARENTNO, string tREENO, decimal? iDX, decimal? iSDIR)
            : this()
        {
            this.NO = nO;
            this.NAME = nAME;
            this.PARENTNO = pARENTNO;
            this.TREENO = tREENO;
            this.IDX = iDX;
            this.ISDIR = iSDIR;
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
            sb.Append(this.NO);
            sb.Append(this.NAME);
            sb.Append(this.PARENTNO);
            sb.Append(this.TREENO);
            sb.Append(this.IDX);
            sb.Append(this.ISDIR);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 编号,-,主键
        /// </summary>
        [DataMember]
        public virtual string NO { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public virtual string NAME { get; set; }
        /// <summary>
        /// 父节点No
        /// </summary>
        [DataMember]
        public virtual string PARENTNO { get; set; }
        /// <summary>
        /// TreeNo
        /// </summary>
        [DataMember]
        public virtual string TREENO { get; set; }
        /// <summary>
        /// Idx
        /// </summary>
        [DataMember]
        public virtual decimal? IDX { get; set; }
        /// <summary>
        /// IsDir
        /// </summary>
        [DataMember]
        public virtual decimal? ISDIR { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

