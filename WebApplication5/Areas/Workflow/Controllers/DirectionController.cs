using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;


namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 【节点方向】控制器
    /// </summary>
    public partial class DirectionController : StringEntityController<WF_Direction>
    {
        #region 视图

        #endregion

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveDirection()
        {
            try
            {
                var entity = GetUpdateModel(null, "MYPK");
                var list = NH.GetSession<WF_Direction>().QueryOver<WF_Direction>().Where(x => x.MyPK == entity.MyPK).List();
                if (list.Count > 0)
                {
                    throw new Exception("重复的连接线！");
                }
                entity.SaveOrUpdate();
                return Json(new { success = true, entity = entity });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "保存失败！" + ex.Message, error = JsonConvert.SerializeObject(ex) });
            }
        }
    }
}
