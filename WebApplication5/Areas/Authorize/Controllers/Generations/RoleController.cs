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
    /// 【角色】控制器
    /// </summary>
    public partial class RoleController
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
        public ActionResult Select_User()
        {
            return View();
        }
				/// <summary>
        /// 选择页面
        /// </summary>
        public ActionResult Select_Authorization()
        {
            return View();
        }
		
		#endregion
		
        #region 操作

		
		
		
		
		
		

		

		
				
        /// <summary>
        /// 获取分页数据UserRole
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPaged_UserRole(string RoleID, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_Auth_Rlt_RoleUser T WHERE T.RoleID='{0}'", RoleID);
            return PagedQuery(sql, page, rows, filters, orders);
        }
		
        /// <summary>
        /// 获取数据UserRole
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData_UserRole(string RoleID, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_Auth_Rlt_RoleUser T WHERE T.RoleID='{0}'", RoleID);
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }

		
        /// <summary>
        /// 保存关系Auth_Rlt_UserRole
        /// </summary>
        public ActionResult SaveRelation_UserRole(string RoleID, List<string> UserIDS)
        {
            foreach (var item in UserIDS)
            {
                var entity = NH.GetSession<Auth_Role>().QueryOver<Auth_Rlt_UserRole>().Where(x => x.UserID == item && x.RoleID == RoleID).List().FirstOrDefault();
                if (entity == null)
                {
                    entity = new Auth_Rlt_UserRole()
                    {
                        RoleID = RoleID,
                        UserID = item
                    };
                    entity.Save();
                }
            }
            return Json(new { success = true });
        }

        /// <summary>
        /// 更新关系Auth_Rlt_UserRole
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRelation_UserRole(List<Auth_Rlt_UserRole> list)
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
        /// 删除关系Auth_Rlt_UserRole
        /// </summary>
        public ActionResult DeleteRelation_UserRole(List<string> ids)
        {
           try
            {
                foreach (var id in ids)
                {
                    var entity = NH.Session.Get<Auth_Rlt_UserRole>(id);
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
		
				
        /// <summary>
        /// 获取分页数据RoleAuthorization
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTreePaged_RoleAuthorization(string id, string RoleID, int page, int rows, List<MyFilter> filters, string orders = "")
        {
		    filters = filters == null ? new List<MyFilter>() : filters;

            var sql = string.Format("SELECT T.* FROM V_Auth_Rlt_RoleAuthorization T WHERE T.RoleID='{0}'", RoleID);
            if (!string.IsNullOrEmpty(id))
            {
                sql = string.Format("{0} AND T.ParentID='{1}'", sql, id);
                var data = QueryService.GetData(sql);
                return Json_Get(data);
            }

            sql += " AND (T.ParentID IS NULL OR T.ParentID='')";
            var result = QueryService.CreatePagedSQLQuery(sql, page, rows, filters, orders);
            return Json_Get(new { total = result.total, rows = result.rows });

        }
		
        /// <summary>
        /// 保存关系Auth_Rlt_RoleAuthorization
        /// </summary>
        public ActionResult SaveRelation_RoleAuthorization(string RoleID, List<string> AuthorizationIDS)
        {
            foreach (var item in AuthorizationIDS)
            {
                var entity = NH.GetSession<Auth_Role>().QueryOver<Auth_Rlt_RoleAuthorization>().Where(x => x.AuthorizationID == item && x.RoleID == RoleID).List().FirstOrDefault();
                if (entity == null)
                {
                    entity = new Auth_Rlt_RoleAuthorization()
                    {
                        RoleID = RoleID,
                        AuthorizationID = item
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
        public ActionResult UpdateRelation_NodePage(List<Auth_Rlt_RoleAuthorization> list)
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
