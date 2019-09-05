using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;
using System;
using System.Linq;
using System.Web.Mvc;


namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 【工作者】控制器
    /// </summary>
    public partial class GenerWorkerListController : IntEntityController<WF_GenerWorkerList>
    {
        #region 视图

        #endregion
        /// <summary>
        /// 签收
        /// </summary>
        /// <param name="WorkID"></param>
        /// <param name="NodeID"></param>
        /// <returns></returns>
        public ActionResult Sign(int WorkID, int NodeID)
        {
            using (var trans = NH.Session.BeginTransaction())
            {
                try
                {
                    var worker = NH.Session.QueryOver<WF_GenerWorkerList>().Where(x => x.WorkID == WorkID && x.FK_Node == NodeID && x.IsEnable == 1).List().ToList();

                    var entity = worker.Where(x => x.FK_Emp == ApplicationUser.Current.Name).FirstOrDefault();
                    if (entity == null)
                    {
                        throw new Exception("签收失败，请刷新页面！");
                    }
                    entity.IsRead = 1;
                    entity.Update();

                    var node = NH.Session.Load<WF_Node>(NodeID);
                    if (node.TodolistModel == 1)
                    {
                        foreach (var item in worker.Where(x => x.FK_Emp != ApplicationUser.Current.Name))
                        {
                            item.IsEnable = -1;
                            item.Update();
                        }
                    }
                    trans.Commit();
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return Json(new { success = false, msg = ex.Message });
                }
            }
        }

        /// <summary>
        /// 取消签收
        /// </summary>
        /// <param name="WORKID"></param>
        /// <returns></returns>
        public ActionResult CancelSign(int WORKID, int NODEID)
        {
            try
            {
                var worker = NH.Session.QueryOver<WF_GenerWorkerList>().Where(x => x.WorkID == WORKID && x.FK_Node == NODEID && x.FK_Emp == ApplicationUser.Current.Name && x.IsRead == 1).List().FirstOrDefault();
                if (worker == null)
                {
                    throw new Exception("取消签收失败，请刷新页面！");
                }
                worker.IsRead = 0;
                worker.Update();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }
    }
}
