using PTXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HR.WorkflowService.Common.Model
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class CommonEntity : BaseEntity<string>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tableName"></param>
        public CommonEntity(string tableName)
            : base(tableName)
        {

        }

        private int _isdelete = 0;
        private int _isshare = 0;
        private int _isvalid = 0;
        private int _isconfig = 0;
        private int _dataorigin = 1;
        private DateTime? _createdate = DateTime.Now;
        private DateTime? _modifydate = DateTime.Now;

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        public virtual DateTime? CREATEDATE
        {
            get
            {
                return _createdate;
            }
            set
            {
                _createdate = value;
            }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        public virtual int ISDELETE
        {
            get
            {
                return _isdelete;
            }
            set
            {
                _isdelete = value;
            }
        }
        /// <summary>
        /// 是否共享
        /// </summary>
        [DataMember]
        public virtual int ISSHARE
        {
            get
            {
                return _isshare;
            }
            set
            {
                _isshare = value;
            }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        [DataMember]
        public virtual int ISVALID
        {
            get
            {
                return _isvalid;
            }
            set
            {
                _isvalid = value;
            }
        }
        /// <summary>
        /// 是否可配置
        /// </summary>
        [DataMember]
        public virtual int ISCONFIG
        {
            get
            {
                return _isconfig;
            }
            set
            {
                _isconfig = value;
            }
        }
        /// <summary>
        /// 顺序号
        /// </summary>
        [DataMember]
        public virtual int? SORTORDER { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [DataMember]
        public virtual string CREATEPERSONID { get; set; }
        /// <summary>
        /// 修改人ID
        /// </summary>
        [DataMember]
        public virtual string MODIFYPERSONID { get; set; }
        /// <summary>
        /// 组织机构部门
        /// </summary>
        [DataMember]
        public virtual string ORGANIZATIONID { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [DataMember]
        public virtual DateTime? MODIFYDATE
        {
            get
            {
                return _modifydate;
            }
            set
            {
                _modifydate = value;
            }
        }
        /// <summary>
        /// 0或null系统生成数据，1迁移数据，2初始录入
        /// </summary>
        [DataMember]
        public virtual int DATAORIGIN
        {
            get
            {
                return _dataorigin;
            }
            set
            {
                _dataorigin = value;
            }
        }
    }
}