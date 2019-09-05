
namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 实体类的基接口
    /// </summary>
    /// <typeparam name="IdType">实体类主键Id的数据类型(目前不考虑多列组合主键)</typeparam>
    public interface IEntity<IdType>
    {
        /// <summary>
        /// 判断给定的实体对象与当前实体对象是否相等
        /// </summary>
        /// <param name="entity">给定的实体对象</param>
        /// <returns>true相等，false不等</returns>
        bool Equals(BaseEntity<IdType> entity);
        /// <summary>
        /// 实体类主键Id
        /// </summary>
        IdType ID { get; set; }
        /// <summary>
        /// 实体类对应的关系数据库表名
        /// </summary>
        string TableName { get; set; }
    }
}
