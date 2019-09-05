using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Workflow.Controllers
{
    /// <summary>
    /// 首页控制器
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index视图
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
