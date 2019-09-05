using WebApplication5.Areas.Authorize.Models;
using Lab.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab.CommonBussiness.Helpers;
using System.Dynamic;

namespace WebApplication5.Areas.Authorize.Controllers
{
    /// <summary>
    /// 【操作权限】控制器
    /// </summary>
    public partial class AuthorizationController
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

        		/// <summary>
        /// 选择页面
        /// </summary>
        public ActionResult Select_Role()
        {
            return View();
        }
		
		#endregion
		
        #region 操作

		
		
				/// <summary>
        /// 加载分页数据
        /// </summary>
        public override ActionResult GetPaged(int page, int rows, List<MyFilter> filters, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = "select * from V_Auth_Authorization";

            return PagedQuery(sql, page, rows, filters, orders);
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public override ActionResult GetData(List<MyFilter> filters, string orders = "")
        {
            var sql = "select * from V_Auth_Authorization";
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }
		
				/// <summary>
        /// 加载树结构分页数据
        /// </summary>
        public ActionResult GetTreePaged(string id, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = "SELECT T.* FROM V_Auth_Authorization T ";

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
        public ActionResult GetTreeData(string orders = "SortNumber")
        {
            var sql = "SELECT * FROM V_Auth_Authorization T";
            var parentRecords = QueryService.GetData(sql+" WHERE (T.ParentID IS NULL OR T.ParentID='')", null,orders).Select(x => x as ExpandoObject).ToList();
            var allRecords= QueryService.GetData(sql, null, orders).Select(x => x as ExpandoObject).ToList();
            TreeHelper.FillChildren(ref parentRecords, allRecords, "ID", "ParentID", "Name");
            return Json_Get(parentRecords);
        }
		
		
		

		

		
				
        /// <summary>
        /// 获取分页数据RoleAuthorization
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPaged_RoleAuthorization(string AuthorizationID, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_Auth_Rlt_RoleAuthorization T WHERE T.AuthorizationID='{0}'", AuthorizationID);
            return PagedQuery(sql, page, rows, filters, orders);
        }
		
        /// <summary>
        /// 获取数据RoleAuthorization
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData_RoleAuthorization(string AuthorizationID, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_Auth_Rlt_RoleAuthorization T WHERE T.AuthorizationID='{0}'", AuthorizationID);
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }

		
        /// <summary>
        /// 保存关系Auth_Rlt_RoleAuthorization
        /// </summary>
        public ActionResult SaveRelation_RoleAuthorization(string AuthorizationID, List<string> RoleIDS)
        {
            foreach (var item in RoleIDS)
            {
                var entity = NH.GetSession<Auth_Authorization>().QueryOver<Auth_Rlt_RoleAuthorization>().Where(x => x.RoleID == item && x.AuthorizationID == AuthorizationID).List().FirstOrDefault();
                if (entity == null)
                {
                    entity = new Auth_Rlt_RoleAuthorization()
                    {
                        AuthorizationID = AuthorizationID,
                        RoleID = item
                    };
                    entity.Save();
                }
            }
            return Json(new { success = true });
        }

        /// <summary>
        /// 更新关系Auth_Rlt_RoleAuthorization
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRelation_RoleAuthorization(List<Auth_Rlt_RoleAuthorization> list)
        {
            try
            {
                foreach (var item in list)
                {
                    NH.Session.Merge(item);
                    NH.Session.Flush();
                }
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        /// <summary>
        /// 删除关系Auth_Rlt_RoleAuthorization
        /// </summary>
        public ActionResult DeleteRelation_RoleAuthorization(List<string> ids)
        {
           try
            {
                foreach (var id in ids)
                {
                    var entity = NH.Session.Get<Auth_Rlt_RoleAuthorization>(id);
                    entity.Delete();
                }
            }
            catch (DataInvalidException ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "删除失败" });
            }
            return Json(new { success = true, msg = "删除成功" });
        }
		
				#endregion
    }
}
