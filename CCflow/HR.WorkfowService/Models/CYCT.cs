using HR.WorkflowService.Common;
using Iesi.Collections.Generic;
using System;
using System.Runtime.Serialization;
using System.Web;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 常用词条
    /// </summary>
    [DataContract]
    public class CYCT : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public CYCT() : base("LS_COMMON_CYCT") { }

         /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="node_id">流程节点标识</param>
        ///<param name="page_id">流程页签标识</param>
        ///<param name="sortNumber">排序号</param>
        public CYCT(string iD, string cTMC,string cTNR)
            : this()
        {
            this.ID = iD;
            this.CTMC = cTMC;
            this.CTNR = cTNR;
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
            sb.Append(this.CTMC);

            sb.Append(this.CTNR);
            //sb.Append(this.SORTORDER);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 词条名称
        /// </summary>
        [DataMember]
        public virtual string CTMC { get; set; }
        /// <summary>
        /// 词条内容
        /// </summary>
        [DataMember]
        public virtual string CTNR { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        [DataMember]
        public virtual int ISVALID { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        public virtual int ISDELETED { get; set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        [DataMember]
        public virtual int SORTORDER { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [DataMember]
        public virtual string CREATOR { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public virtual DateTime CREATETIME { get; set; }
        #endregion
        
        #region 手动追加属性
        
        #endregion
    }
}

