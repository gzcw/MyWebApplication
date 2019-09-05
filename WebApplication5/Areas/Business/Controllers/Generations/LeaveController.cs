using WebApplication5.Areas.Business.Models;
using Lab.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Areas.Business.Controllers
{
    /// <summary>
    /// 【请假管理】控制器
    /// </summary>
    public partial class LeaveController
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

		
        public virtual ActionResult GetEntityByWorkID(int WorkID)
        {
            var entity = NH.Session.QueryOver<Bus_Leave>().Where(x => x.WorkID == WorkID).List().FirstOrDefault();
            if (entity == null)
            {
                entity = new Bus_Leave()
                {
                    WorkID = WorkID
                };
            }
            return Json(entity, JsonRequestBehavior.AllowGet);
        }
		
		
				/// <summary>
        /// 加载分页数据
        /// </summary>
        public override ActionResult GetPaged(int page, int rows, List<MyFilter> filters, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = "select * from V_Bus_Leave";

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
            var sql = "select * from V_Bus_Leave";
            var data = QueryService.GetData(sql, filters, orders);
            return Json_Get(data);
        }
		
		
		
		

		

		
				#endregion
    }
}
