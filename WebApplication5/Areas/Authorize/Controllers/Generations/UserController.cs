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
    /// 【用户】控制器
    /// </summary>
    public partial class UserController
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
            var sql = "select * from V_Auth_User";

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
            var sql = "select * from V_Auth_User";
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }
		
		
		
		

		

		
				
        /// <summary>
        /// 获取分页数据UserRole
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPaged_UserRole(string UserID, int page, int rows, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_Auth_Rlt_UserRole T WHERE T.UserID='{0}'", UserID);
            return PagedQuery(sql, page, rows, filters, orders);
        }
		
        /// <summary>
        /// 获取数据UserRole
        /// </summary>
        /// <returns></returns>
        public ActionResult GetData_UserRole(string UserID, List<MyFilter> filters, string orders = "")
        {
            var sql = string.Format("select T.* from V_Auth_Rlt_UserRole T WHERE T.UserID='{0}'", UserID);
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }

		
        /// <summary>
        /// 保存关系Auth_Rlt_UserRole
        /// </summary>
        public ActionResult SaveRelation_UserRole(string UserID, List<string> RoleIDS)
        {
            foreach (var item in RoleIDS)
            {
                var entity = NH.GetSession<Auth_User>().QueryOver<Auth_Rlt_UserRole>().Where(x => x.RoleID == item && x.UserID == UserID).List().FirstOrDefault();
                if (entity == null)
                {
                    entity = new Auth_Rlt_UserRole()
                    {
                        UserID = UserID,
                        RoleID = item
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
		
				#endregion
    }
}
