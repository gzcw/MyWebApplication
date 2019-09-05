using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BP.WF;
using System.Configuration;
using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;

namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 设计器控制器
    /// </summary>
    public class DesignerController : StringEntityController<WF_Flow>
    {
        #region 视图
        /// <summary>
        /// Index
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 流程设计器
        /// </summary>
        /// <returns>视图</returns>
        public ActionResult Designer()
        {
            return View();
        }
        #endregion
    }
}
