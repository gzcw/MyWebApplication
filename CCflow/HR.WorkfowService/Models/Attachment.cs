using Iesi.Collections.Generic;
using HR.WorkflowService.Common;
////using HR.WorkflowService.DAOs;
using System;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Models
{
    /// <summary>
    /// 附件
    /// </summary>
    [DataContract]
    public class Attachment : BaseEntity<string>
    {
        #region 字段(一般属性后背字段定义区)

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public Attachment() : base("CM_SYS_Attachment") { }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        ///<param name="iD">标识</param>
        ///<param name="name">名称</param>
        ///<param name="filetype">文件类型</param>
        ///<param name="path">路径</param>
        ///<param name="filesize">大小</param>
        ///<param name="property">文件属性</param>
        ///<param name="isdirectory">是否目录</param>
        ///<param name="record_id">业务记录ID</param>
        ///<param name="parent_id">父记录ID</param>
        ///<param name="creator">创建用户名称</param>
        ///<param name="createtime">创建时间</param>
        ///<param name="sortnumber">排序号</param>
        public Attachment(string iD, string name, string filetype, string path, decimal? filesize, string property, bool isdirectory, string record_id, string parent_id, string creator, DateTime? createtime, decimal? sortnumber)
            : this()
        {
            this.ID = iD;
            this.Name = name;
            this.Filetype = filetype;
            this.Path = path;
            this.Filesize = filesize;
            this.Property = property;
            this.Isdirectory = isdirectory;
            this.Record_id = record_id;
            this.Parent_id = parent_id;
            this.Creator = creator;
            this.Createtime = createtime;
            this.Sortnumber = sortnumber;
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
            sb.Append(this.Name);
            sb.Append(this.Filetype);
            sb.Append(this.Path);
            sb.Append(this.Filesize);
            sb.Append(this.Property);
            sb.Append(this.Isdirectory);
            sb.Append(this.Record_id);
            sb.Append(this.Parent_id);
            sb.Append(this.Creator);
            sb.Append(this.Createtime);
            sb.Append(this.Sortnumber);
            return sb.ToString().GetHashCode();
        }
        #endregion

        #region 属性
        /// <summary>
        /// 名称
        /// </summary>
        [DataMember]
        public virtual string Name { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        [DataMember]
        public virtual string Filetype { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [DataMember]
        public virtual string Path { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        [DataMember]
        public virtual decimal? Filesize { get; set; }
        /// <summary>
        /// 文件属性
        /// </summary>
        [DataMember]
        public virtual string Property { get; set; }
        /// <summary>
        /// 是否目录
        /// </summary>
        [DataMember]
        public virtual bool Isdirectory { get; set; }
        /// <summary>
        /// 业务记录ID
        /// </summary>
        [DataMember]
        public virtual string Record_id { get; set; }
        /// <summary>
        /// 父记录ID
        /// </summary>
        [DataMember]
        public virtual string Parent_id { get; set; }
        /// <summary>
        /// 创建用户名称
        /// </summary>
        [DataMember]
        public virtual string Creator { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public virtual DateTime? Createtime { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [DataMember]
        public virtual decimal? Sortnumber { get; set; }
        #endregion

        #region 手动追加属性

        /// <summary>
        /// 父节点标识
        /// </summary>
        [DataMember]
        public virtual string _parentId
        {
            get
            {
                return Parent_id;
            }
        }

        #endregion
    }
}

