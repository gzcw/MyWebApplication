using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 【报表定义】控制器
    /// </summary>
    public partial class FlowController
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
        /// 保存
        /// </summary>
        /// <returns></returns>
        public override ActionResult SaveEntity()
        {
            try
            {
                var entity = GetUpdateModel(null,"No");
                entity.Save();
                return Json(new { success = true, entity = entity });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "保存失败！" + ex.Message, error = JsonConvert.SerializeObject(ex) });
            }
        }
		
		
		
		
		

		

		
				#endregion
    }
}
