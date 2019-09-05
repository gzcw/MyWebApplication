using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 实体类的基类
    /// </summary>
    /// <typeparam name="IdType">实体类主键Id的数据类型(目前不考虑多列组合主键)</typeparam>
    [DataContract]
    [Serializable]
    public class BaseEntity<IdType> : IEntity<IdType>
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseEntity()
        {
        }
        /// <summary>
        /// 带参构造方法
        /// </summary>
        /// <param name="tableName">当前实体类对应的数据库表名</param>
        protected BaseEntity(string tableName)
        {
            this.TableName = tableName;
        }

        /// <summary>
        /// 判断给定的实体对象与当前实体对象是否相等（若主键ID及哈希值相等，则认为两个对象相等）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Equals(BaseEntity<IdType> entity)
        {
            return ((entity != null) && this.ID.Equals(entity.ID) && this.GetHashCode() == entity.GetHashCode());
        }

        /// <summary>
        /// 实体类的主键Id
        /// </summary>
        [DataMember]
        public virtual IdType ID { get; set; }
        /// <summary>
        /// 实体类对应的关系数据库表名
        /// </summary>
        [DataMember]
        public virtual string TableName { get; set; }

        /// <summary>
        /// 保存之前事件
        /// </summary>
        /// <returns></returns>
        public virtual bool OnBeforeSave()
        {
            return true;
        }

        /// <summary>
        /// 查询字段是否重复
        /// </summary>
        public static bool CheckRepeat<T>(BaseEntity<string> entity, string columnName, string errorMsg = "已存在相同名称的记录", IList<T> list = null) where T : BaseEntity<string>, new()
        {
            return false;
            //try
            //{
            //    var dao = new BaseDAO<string, T>();
            //    var sourceEntity = dao.NStatelessSession.Get<T>(entity.ID);

            //    var value = entity.GetType().GetProperty(columnName).GetValue(entity);
            //    if (value == null || value.ToString() == string.Empty)
            //    {
            //        return true;
            //    }
            //    if (list == null)
            //    {
            //        var querySql = string.Format("FROM {0} WHERE {1}='{2}'", typeof(T).Name, columnName, value);
            //        if (entity.GetType().GetProperty("ISDELETE") != null)
            //        {
            //            querySql = string.Format("{0} AND ISDELETE=0", querySql);
            //        }
            //        list = dao.NStatelessSession.CreateQuery(querySql).List<T>();
            //    }

            //    if (list.Count == 0)
            //    {
            //        return true;
            //    }
            //    if (sourceEntity == null)
            //    {
            //        throw new DomainException(errorMsg);
            //    }

            //    var currentValue = entity.GetType().GetProperty(columnName).GetValue(entity);
            //    var sourceValue = entity.GetType().GetProperty(columnName).GetValue(sourceEntity);

            //    if (sourceEntity != null && entity.GetType().GetProperty(columnName).GetValue(entity).ToString() == entity.GetType().GetProperty(columnName).GetValue(sourceEntity).ToString())
            //    {
            //        return true;
            //    }
            //}
            //catch (DomainException exception)
            //{
            //    throw exception;
            //}
            //catch
            //{
            //    throw new DomainException(string.Format("验证失败字段【{0}】", columnName));
            //}
            //throw new DomainException(errorMsg);
        }
    }
}
