using System;
using System.Runtime.Serialization;

namespace Lab.Framework
{
    /// <summary>
    /// 实体基类
    /// </summary>
    [Serializable]
    [DataContract]
    public class StringEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public virtual string ID { get; set; }
    }
}
