using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 审批意见
    /// </summary>
    [DataContract]
    public class ApproveOpinion : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public ApproveOpinion() : base("WF_SYS_ApproveOpinion") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="approver">审批人</param>
        ///<param name="createtime">审批时间</param>
        ///<param name="station">岗位</param>
        ///<param name="department">部门</param>
        ///<param name="opinion">意见</param>
        ///<param name="node_id">节点标识</param>
        ///<param name="work_id">工作标识</param>
        ///<param name="nodename">节点名称</param>
        public ApproveOpinion(string iD, string approver, DateTime createtime, string station, string department, string opinion, string node_id, string work_id, string nodename)
            : this()
        {
            this.ID = iD;
            this.Approver = approver;
            this.Createtime = createtime;
            this.Station = station;
            this.Department = department;
            this.Opinion = opinion;
            this.Node_id = node_id;
            this.Work_id = work_id;
            this.Nodename = nodename;
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
            sb.Append(this.Approver);
            sb.Append(this.Createtime);
            sb.Append(this.Station);
            sb.Append(this.Department);
            sb.Append(this.Opinion);
            sb.Append(this.Node_id);
            sb.Append(this.Work_id);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 审批人
        /// </summary>
        [DataMember]
        public virtual string Approver { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        [DataMember]
        public virtual DateTime Createtime { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        [DataMember]
        public virtual string Station { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [DataMember]
        public virtual string Department { get; set; }
        /// <summary>
        /// 意见
        /// </summary>
        [DataMember]
        public virtual string Opinion { get; set; }
        /// <summary>
        /// 节点标识
        /// </summary>
        [DataMember]
        public virtual string Node_id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        [DataMember]
        public virtual string Nodename { get; set; }
        /// <summary>
        /// 工作标识
        /// </summary>
        [DataMember]
        public virtual string Work_id { get; set; }
        /// <summary>
        /// 是否同意
        /// </summary>
        [DataMember]
        public virtual int Agree { get; set; }

        private int _submit = 0;
        /// <summary>
        /// 是否同意
        /// </summary>
        [DataMember]
        public virtual int Submit
        {
            get { return _submit; }
            set { _submit = value; }
        }
        #endregion

        #region 手动追加属性

        #endregion
    }
}

