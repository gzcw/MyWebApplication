using System.Collections;
using System.Linq;
namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 封装分页查询信息的分页信息类(不使用泛型，防止限死结果集的类型)
    /// </summary>
    public class PaginationInfo
    {
        /// <summary>
        /// 每页的记录数
        /// </summary>
        public int pagesize { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int pageindex { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public long total { get; set; }
        /// <summary>
        /// 返回去的记录集(注意这里使用IEnumerable接口)
        /// </summary>
        public IEnumerable rows { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="pageIndex">页码(可选参数，默认值为1)</param>
        /// <param name="pageSize">每页记录数(可选参数，默认值为10)</param>
        public PaginationInfo(int pageIndex = 1, int pageSize = 10)
        {
            this.pageindex = pageIndex;
            this.pagesize = pageSize;
            this.total = 0L;
            this.rows = new ArrayList();
        }
    }
    /// <summary>
    /// 封装分页查询信息的分页信息类扩展方法
    /// </summary>
    public static class PaginationInfoExtention
    {
        /// <summary>
        /// 提供可查询类型的分页方法扩展
        /// </summary>
        /// <param name="query">查询方法</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页的记录数</param>
        /// <returns>分页信息类</returns>
        public static PaginationInfo ToPaging(this IQueryable<dynamic> query, int pageIndex, int pageSize)
        {
            PaginationInfo info = new PaginationInfo(pageIndex, pageSize);
            info.total = query.Count();
            info.rows = query.Skip((pageIndex-1)*pageSize).Take(pageSize).ToList();
            return info;
        }
        /// <summary>
        /// 提供可查询类型的分页方法扩展
        /// </summary>
        /// <param name="query">查询方法</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页的记录数</param>
        /// <returns>分页信息类</returns>
        public static PaginationInfo ToPaging<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            PaginationInfo info = new PaginationInfo(pageIndex, pageSize);
            info.total = query.Count();
            info.rows = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return info;
        }
    }
}
