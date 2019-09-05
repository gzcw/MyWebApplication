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
    /// 【岗位】控制器
    /// </summary>
    public partial class StationController
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
        /// 获取分页数据（User）
        /// </summary>
        /// <param name="StationID"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="filters"></param>
        /// <param name="orders"></param>
        /// <returns></returns>
        public virtual ActionResult GetPaged_User(string StationID,int page, int rows, List<MyFilter> filters, string orders = "")
        {
            filters = filters == null ? new List<MyFilter>() : filters;
            var sql = string.Format("SELECT * FROM V_Auth_User T WHERE T.StationID='{0}'", StationID);

            return PagedQuery(sql, page, rows, filters, orders);
        }
		

		
				#endregion
    }
}
