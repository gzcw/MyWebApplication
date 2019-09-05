using System;
using System.Runtime.Serialization;

namespace Lab.Framework
{
    /// <summary>
    /// 实体基类
    /// </summary>
    [Serializable]
    [DataContract]
    public class IntEntity
    {
        /// <summary>
        /// 数据库名称
        /// </summary>
        public virtual string DatabaseName { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        public virtual void Save()
        {
            NH.GetSession(this.DatabaseName).Save(this);
            NH.GetSession(this.DatabaseName).Flush();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual void Delete()
        {
            NH.GetSession(this.DatabaseName).Delete(this);
            NH.GetSession(this.DatabaseName).Flush();
        }
    }
}
