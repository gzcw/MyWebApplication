using WebApplication5.Areas.Authorize.Models;
using Lab.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Areas.Authorize.Controllers
{
    /// <summary>
    /// 【部门】控制器
    /// </summary>
    public partial class DepartmentController
    {
        #region 视图

        /// <summary>
        /// 主页
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 表单
        /// </summary>
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// 流程表单
        /// </summary>
        public ActionResult WfForm()
        {
            return View();
        }

        /// <summary>
        /// 流程列表
        /// </summary>
        public ActionResult WfList()
        {
            return View();
        }

        /// <summary>
        /// 选择
        /// </summary>
        public ActionResult Select()
        {
            return View();
        }

        
		#endregion
		
        #region 操作

		
		
		
				/// <summary>
        /// 加载表格树数据
        /// </summary>
        public ActionResult GetTreePaged(string id, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = "SELECT T.* FROM Auth_Department T ";

            if (!string.IsNullOrEmpty(id))
            {
                sql += string.Format("WHERE T.ParentID='{0}'", id);
                var data = QueryService.GetData(sql);
                return Json_Get(data);
            }

            sql += "WHERE T.ParentID IS NULL OR T.ParentID=''";
            var result = QueryService.CreateTreePagedSQLQuery(sql, page, rows, filters, orders);
            return Json_Get(new { total = result.total, rows = result.rows });
        }
		
		
		

				 /// <summary>
        /// 获取分页数据（User）
        /// </summary>
        /// <param name="DepartmentID"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public virtual ActionResult GetPaged_User(string DepartmentID,int page, int rows, List<MyFilter> filters, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = string.Format("SELECT * FROM V_Auth_User T WHERE T.DepartmentID='{0}'", DepartmentID);

            return PagedQuery(sql, page, rows, filters, orders);
        }
		

		
				#endregion
    }
}
