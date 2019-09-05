using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;
using HR.BasicFramework.DataAccess;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 应用控制器
    /// </summary>
    /// <typeparam name="T">实体</typeparam>
    public class ApplicationController<T> : BaseController
        where T : BaseEntity<string>, new()
    {
        #region 属性
        /// <summary>
        /// 案件流转状态
        /// </summary>
        public int WfState
        {
            get
            {
                return RequestHelper.GetQueryInt("wfState", 0);
            }
        }

        /// <summary>
        /// 办文案ID
        /// </summary>
        public string BwaId
        {
            get
            {
                return RequestHelper.GetQueryString("BwaId");
            }
        }
        #endregion

        #region 查询方法

        /// <summary>
        /// 加载表格数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序</param>
        /// <returns>分页列表</returns>
        public virtual ActionResult PageQuery(string sql, int page, int rows, string filterStr = "[]", string orders = "")
        {
            var result = getPageData(sql, page, rows, filterStr, orders);

            return Json_Get(result);
        }

        /// <summary>
        /// 获取表格分页数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序</param>
        /// <returns>分页数据集</returns>
        public static PaginationInfo getPageData(string sql, int page, int rows, string filterStr, string orders)
        {
            var filter = QueryService.DeserializeFilter(filterStr);

            if (typeof(CommonEntity).IsAssignableFrom(typeof(T)))
            {
                filter.Add(new Filter()
                {
                    property = "IsDelete",
                    relation = "=",
                    value = "0",
                    dataType = "int"
                });
            }

            //var dao = new BaseDAO<string, T>();

            var isUpper = typeof(T).Name == typeof(T).Name.ToUpper();

            var result = QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, isUpper);
            return result;
        }

        /// <summary>
        /// 加载表格数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="filters">过滤条件</param>
        /// <param name="orders">排序</param>
        /// <returns>分页数据集</returns>
        public virtual ActionResult PageQuery(string sql, int page, int rows, List<Filter> filters = null, string orders = "")
        {
            filters = filters == null ? new List<Filter>() : filters;

            if (typeof(CommonEntity).IsAssignableFrom(typeof(T)))
            {
                filters.Add(new Filter()
                {
                    property = "IsDelete",
                    relation = "=",
                    value = "0",
                    dataType = "int"
                });
            }

            //var dao = new BaseDAO<string, T>();

            var isUpper = typeof(T).Name == typeof(T).Name.ToUpper();

            var result = QueryService.CreatePagedSQLQuery(sql, page, rows, filters, orders, isUpper);

            return Json_Get(result);
        }

        /// <summary>
        /// 加载数据集
        /// </summary>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序</param>
        /// <returns>数据集</returns>
        public virtual ActionResult GetData(string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);

            //var dao = new BaseDAO<string, T>();

            var sql = "SELECT * FROM " + new T().TableName;

            var isUpper = typeof(T).Name == typeof(T).Name.ToUpper();

            var result = QueryService.GetData(sql, filter, orders, isUpper);

            return Json_Get(result);
        }

        /// <summary>
        /// 加载视图数据集
        /// </summary>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序</param>
        /// <param name="viewName">视图名称</param>
        /// <returns>数据集</returns>
        public virtual ActionResult GetViewData(string filterStr = "[]", string orders = "", string viewName = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);

            //var dao = new BaseDAO<string, T>();

            viewName = string.IsNullOrEmpty(viewName) ? "V_" + new T().TableName : viewName;
            var sql = string.Format("SELECT * FROM {0}", viewName);

            var isUpper = typeof(T).Name == typeof(T).Name.ToUpper();

            var result = QueryService.GetData(sql, filter, orders, isUpper);

            return Json_Get(result);
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>实体对象</returns>
        public virtual ActionResult GetById(string Id)
        {
            //var dao = new BaseDAO<string, T>();
            var result = DataContextNH.GetByID<T>(Id);
            return Json_Get(result);
        }

        /// <summary>
        /// 根据存储过程获取数据集
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="filterStr">过滤条件</param>
        /// <returns>数据集列表</returns>
        //public virtual IList<IDictionary<string, object>> GetDataByProcedure(string procedureName, string filterStr = "[]")
        //{
        //    var filters = QueryService.DeserializeFilter(filterStr);

        //    var dao = new BaseDAO<string, T>();

        //    var result = QueryService.GetDataByProcedure(dao.ConnectionString, procedureName, filters);

        //    return result;
        //}

        #endregion

        #region 保存、更新

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>操作结果</returns>
        public virtual ActionResult Save()
        {
            try
            {
                //var dao = new BaseDAO<string, T>();

                var entity = GetUpdateModel<T>();

                DataContextNH.Save<T>(entity);

                if (typeof(T).GetInterfaces().Contains(typeof(ICloneable)))
                {
                    return Json_Post(new { success = true, data = (entity as ICloneable).Clone() });
                }

                return Json_Post(new { success = true, data = entity });
            }
            catch (DomainException exception)
            {
                return Json_Post(new { success = false, msg = exception.Message });
            }
            catch
            {
                return Json_Post(new { success = false });
            }
        }

        /// <summary>
        /// 保存其它实体
        /// </summary>
        /// <typeparam name="A">实体类型</typeparam>
        /// <returns>实体对象</returns>
        [NonAction]
        public A Save<A>() where A : BaseEntity<string>, new()
        {
            //var dao = new BaseDAO<string, A>();

            var entity = GetUpdateModel<A>();

            DataContextNH.Save(entity);

            return entity;
        }

        /// <summary>
        /// 获取从表单提交更新后的实体
        /// </summary>
        /// <param name="dao">数据访问对象</param>
        /// <returns>实体对象</returns>
        public virtual T GetUpdateModel()
        {
            var ID = this.ValueProvider.GetValue("ID").AttemptedValue;

            var entity = DataContextNH.GetByID<T>(ID);// dao.FindById(ID);

            try
            {
                if (entity == null)
                {
                    ID = string.IsNullOrEmpty(ID) ? Guid.NewGuid().ToString() : ID;
                    entity = new T() { ID = ID };
                    UpdateModel(entity, null, null, new[] { "ID" });
                }
                else
                {
                    UpdateModel(entity, null, null, new[] { "ID" });
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("更新实体失败", ex);
            }
            return entity;
        }

        /// <summary>
        /// 获取从表单提交更新A实体
        /// </summary>
        /// <typeparam name="A">实体类型</typeparam>
        /// <param name="dao">数据访问对象</param>
        /// <param name="prefix">前缀</param>
        /// <param name="includeProperties">包含的属性</param>
        /// <param name="excludeProperties">排除的属性</param>
        /// <returns>实体对象</returns>
        public virtual A GetUpdateModel<A>(string prefix = null, string[] includeProperties = null, string[] excludeProperties = null) where A : BaseEntity<string>, new()
        {
            try
            {
                var ID = this.ValueProvider.GetValue("ID").AttemptedValue;
                excludeProperties = excludeProperties == null ? new[] { "ID" } : excludeProperties;

                var entity = DataContextNH.GetByID<A>(ID);

                if (entity == null)
                {
                    ID = string.IsNullOrEmpty(ID) ? Guid.NewGuid().ToString() : ID;
                    entity = new A() { ID = ID };
                    UpdateModel(entity, prefix, includeProperties, excludeProperties);
                }
                else
                {
                    UpdateModel(entity, prefix, includeProperties, excludeProperties);
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw new DomainException("更新实体出错," + ex.Message);
            }
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="ids">标识集合</param>
        /// <returns>操作结果</returns>
        public virtual ActionResult Delete(string[] ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    //var dao = new BaseDAO<string, T>();
                    var entity = DataContextNH.GetByID<T>(id);
                    DataContextNH.Delete(entity);
                }
            }
            catch
            {
                return Json_Get(new { success = false, message = "删除失败" });
            }
            return Json_Get(new { success = true, message = "删除成功" });
        }

        #endregion

        #region 获取表单

        /// <summary>
        /// 加载表单
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>表单数据</returns>
        public virtual ActionResult LoadForm(string id)
        {
            var entity = DataContextNH.GetByID<T>(id);
            return Json_Get(entity);
        }

        #endregion

        #region 公用过滤条件

        /// <summary>
        /// 获取当前用户区域Filters
        /// </summary>
        /// <returns>过滤条件列表</returns>
        public List<Filter> GetCurrentRegionsFilters()
        {
            var filters = new List<Filter>();

            // IRegionDAO regionDAO = new RegionDAO();
            var message = string.Empty;
            //TODO: 获取用户所属镇
            var zhenList = new List<dynamic>() { new { Name = "" } };//regionDAO.GetRegionWithSubRegionsByCode(CurrentUser.RegionCode, 3, out message);
            for (var i = 0; i < zhenList.Count; i++)
            {
                var zhen = zhenList[i];
                filters.Add(new Filter()
                {
                    left = i == 0 ? "(" : "",
                    property = "ZHEN",
                    value = zhen.Name,
                    dataType = "varchar",
                    connect = i == 0 ? "AND" : "OR",
                    right = i == zhenList.Count - 1 ? ")" : ""
                });
            }
            return filters;
        }

        /// <summary>
        /// 获取当前行政区划过滤条件
        /// </summary>
        /// <returns>过滤条件列表</returns>
        public List<Filter> GetCurrentXZQHDMFilters()
        {
            var filters = new List<Filter>();

            //IRegionDAO regionDAO = new RegionDAO();
            var message = string.Empty;
            //TODO:获取用户所属镇
            var zhenList = new List<dynamic>() { new { Code = "" } };// regionDAO.GetRegionWithSubRegionsByCode(CurrentUser.RegionCode, 3, out message);
            for (var i = 0; i < zhenList.Count; i++)
            {
                var zhen = zhenList[i];
                filters.Add(new Filter()
                {
                    left = i == 0 ? "(" : "",
                    property = "XZJDDM",
                    value = zhen.Code,
                    dataType = "varchar",
                    connect = i == 0 ? "AND" : "OR",
                    right = i == zhenList.Count - 1 ? ")" : ""
                });
            }
            return filters;
        }

        #endregion

    }
}