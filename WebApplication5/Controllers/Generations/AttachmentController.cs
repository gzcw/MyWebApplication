using WebApplication5.Models;
using Lab.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.CommonBussiness.Helpers;
using System.Dynamic;

namespace WebApplication5.Controllers
{
    /// <summary>
    /// 【附件名称】控制器
    /// </summary>
    public partial class AttachmentController
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
        /// 加载树结构分页数据
        /// </summary>
        public ActionResult GetTreePaged(string id, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = "SELECT T.* FROM Sys_Attachment T ";

            if (!string.IsNullOrEmpty(id))
            {
                sql += string.Format("WHERE T.ParentID='{0}'", id);
                var data = QueryService.GetData(sql, null, orders);
                return Json_Get(data);
            }

            sql += "WHERE (T.ParentID IS NULL OR T.ParentID='')";
            var result = QueryService.CreateTreePagedSQLQuery(sql, page, rows, filters, orders);
            return Json_Get(new { total = result.total, rows = result.rows });
        }
		

        /// <summary>
        /// 加载树结构数据
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public ActionResult GetTreeData(string orders = "")
        {
            var sql = "SELECT * FROM Sys_Attachment T";
            var parentRecords = QueryService.GetData(sql+" WHERE (T.ParentID IS NULL OR T.ParentID='')", null,orders).Select(x => x as ExpandoObject).ToList();
            var allRecords= QueryService.GetData(sql, null, orders).Select(x => x as ExpandoObject).ToList();
            TreeHelper.FillChildren(ref parentRecords, allRecords, "ID", "ParentID", "Name");
            return Json_Get(parentRecords);
        }
		
		
		

		

		
				#endregion
    }
}
