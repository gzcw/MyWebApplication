using FluentNHibernate.Mapping;
using System;
using System.Runtime.Serialization;

namespace Lab.Framework
{
    /// <summary>
    /// 实体基类
    /// </summary>
    [Serializable]
    [DataContract]
    public class BaseEntity
    {
        /// <summary>
        /// 保存或更新
        /// </summary>
        public virtual void Save()
        {
            NH.Session.Save(this);
            NH.Session.Flush();
        }
        /// <summary>
        /// 保存或更新
        /// </summary>
        public virtual void SaveOrUpdate()
        {
            NH.Session.SaveOrUpdate(this);
            NH.Session.Flush();
        }

        /// <summary>
        /// 更新
        /// </summary>
        public virtual void Update()
        {
            NH.Session.Update(this);
            NH.Session.Flush();
        }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual void Delete()
        {
            NH.Session.Delete(this);
            NH.Session.Flush();
        }
    }
}
