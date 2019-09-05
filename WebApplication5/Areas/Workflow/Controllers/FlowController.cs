using WebApplication5.Areas.Workflow.Common;
using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 【流程定义】控制器
    /// </summary>
    public partial class FlowController : StringEntityController<WF_Flow>
    {
        #region 视图
        /// <summary>
        /// 新建业务
        /// </summary>
        /// <returns></returns>
        public ActionResult XinJianYeWu()
        {
            return View();
        }

        /// <summary>
        /// 流程面板
        /// </summary>
        /// <returns></returns>
        public ActionResult WfPanel()
        {
            return View();
        }
        /// <summary>
        /// 流程图
        /// </summary>
        /// <returns></returns>
        public ActionResult WfChart()
        {
            return View();
        }

        #endregion

        /// <summary>
        /// 获取我的流程
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMyFlowList()
        {
            var flowList = NH.Session.CreateSQLQuery(string.Format("SELECT T.* FROM WF_FLOW T INNER JOIN V_FLOWSTARTER V ON V.FK_Flow=T.NO WHERE V.FK_Emp='{0}'", ApplicationUser.Current.Name)).AddEntity(typeof(WF_Flow)).List<WF_Flow>();
            var result = flowList.OrderBy(x => x).GroupBy(x => new { FK_Flow = x.FK_FlowSort, Idx = x.WF_FlowSort.Idx }).OrderBy(x => x.Key.Idx).ToList();

            return Json_Get(result);
        }

        /// <summary>
        /// 检查流程
        /// </summary>
        /// <param name="workflowNo">流程编号</param>
        /// <returns>检查结果</returns>
        public ActionResult Check(string workflowNo)
        {
            try
            {
                var fl1 = new BP.WF.Flow(workflowNo);
                var msg = fl1.DoCheck();
                return Json(new { success = true, msg = msg });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        /// <summary>
        /// 创建空白流程
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateBlankWork(string flowNo)
        {
            var msg = string.Empty;
            BP.WF.Dev2Interface.Port_Login(ApplicationUser.Current.Name, "dd2f628c-3f38-4c8c-aa83-1a52ebf6a45a");
            var workID = BP.WF.Dev2Interface.Node_CreateBlankWork(flowNo, ApplicationUser.Current.Name);

            if (workID == -1)
            {
                return Json(new { success = false, message = "流程服务器连接失败。" });
            }

            var nodeID = BP.WF.Dev2Interface.Node_GetCurrentNodeID(flowNo, workID);
            return Json(new { success = true, workID = workID, nodeID = nodeID });
        }

        /// <summary>
        /// 保存为草稿
        /// </summary>
        /// <param name="WorkID">工作ID</param>
        /// <returns>操作结果</returns>
        public ActionResult SaveAsDraft(int WorkID)
        {
            var work = NH.Session.QueryOver<WF_GenerWorkFlow>().Where(x => x.WorkID == WorkID).List().FirstOrDefault();
            var flow = NH.Session.Load<WF_Flow>(work.FK_Flow);
            if (string.IsNullOrEmpty(work.YWH))
            {
                var ywh = Sys_BH.GetBH(flow.BHID);
                work.YWH = ywh;
                work.SaveOrUpdate();
            }
            try
            {
                if (work == null)
                {
                    throw new Exception("找不到该流程");
                }

                FlowService.OnSaveAsDraft(work.FK_Flow, WorkID, work.YWH);

                BP.WF.Dev2Interface.Node_SetDraft(work.FK_Flow, work.WorkID);
            }
            catch (DomainException ex)
            {
                return Json_Get(new { success = false, msg = ex.Message });
            }
            catch (Exception ex)
            {
                return Json_Get(new { success = false, msg = "保存失败，请联系管理员！" });
            }

            return Json_Get(new { success = true });
        }

        /// <summary>
        /// 发送流程
        /// </summary>
        /// <param name="WorkID"></param>
        /// <param name="NodeID"></param>
        /// <param name="ToNodeID"></param>
        /// <param name="WFPARAMS"></param>
        /// <param name="NEXTWORKER"></param>
        /// <returns></returns>
        public ActionResult Node_SendWork(int WorkID, int NodeID, int ToNodeID = 0, List<KeyValuePair<string, string>> WFPARAMS = null, string NEXTWORKER = null)
        {
            var work = NH.Session.Load<WF_GenerWorkFlow>(WorkID);
            var flow = NH.Session.Load<WF_Flow>(work.FK_Flow);
            if (string.IsNullOrEmpty(work.YWH))
            {
                var ywh = Sys_BH.GetBH(flow.BHID);
                work.YWH = ywh;
                work.Update();
            }
            var node = new BP.WF.Node(NodeID);

            using (var trans = NH.Session.BeginTransaction())
            {
                try
                {
                    BP.WF.Dev2Interface.Port_Login(ApplicationUser.Current.Name, "dd2f628c-3f38-4c8c-aa83-1a52ebf6a45a");
                    if (node.IsEndNode)
                    {
                        FlowService.OnCompleted(work.FK_Flow, WorkID, work.YWH, NodeID);
                    }
                    else
                    {
                        FlowService.OnSend(work.FK_Flow, WorkID, work.YWH, NodeID);
                    }

                    WFPARAMS = WFPARAMS == null ? new List<KeyValuePair<string, string>>() : WFPARAMS;

                    var result = BP.WF.Dev2Interface.Node_SendWork(work.FK_Flow, WorkID, ToNodeID, NEXTWORKER);

                    trans.Commit();

                    var message = string.Format("案件【{0}】办理成功！", work.YWH);
                    return Json(new { success = true, message = message });
                }
                catch (DomainException ex)
                {
                    trans.Rollback();
                    return Json(new { success = false, message = ex.Message });
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return Json(new { success = false, message = ex.Message });
                }
            }
        }

        /// <summary>
        /// 获取退回节点信息
        /// </summary>
        /// <returns></returns>
        public ActionResult DB_GenerWillReturnNodes(int WorkID, int NodeID, int FID = 0)
        {
            var tb = BP.WF.Dev2Interface.DB_GenerWillReturnNodes(NodeID, WorkID, FID);
            return Json_Get(tb);
        }

        /// <summary>
        /// 执行工作退回(退回指定的点)
        /// </summary>
        /// <param name="WorkID"></param>
        /// <param name="NodeID"></param>
        /// <param name="ToNodeID"></param>
        /// <returns></returns>
        public ActionResult Node_ReturnWork(int WorkID, int NodeID, int ToNodeID)
        {
            using (var trans = NH.Session.BeginTransaction())
            {
                try
                {
                    var work = NH.Session.Load<WF_GenerWorkFlow>(WorkID);
                    var CurrentNodeID = BP.WF.Dev2Interface.Node_GetCurrentNodeID(work.FK_Flow, WorkID);

                    if (CurrentNodeID != NodeID)
                    {
                        throw new DomainException("当前案件信息已更新，请刷新页面！");
                    }
                    FlowService.OnReturn(work.FK_Flow, WorkID, work.YWH, NodeID, ToNodeID);
                    var msg = BP.WF.Dev2Interface.Node_ReturnWork(WorkID, ToNodeID, "", true);

                    trans.Commit();
                    return Json_Get(new { success = true, msg = "操作成功" });
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return Json_Get(new { success = false, msg = ex.Message });
                }
            }
        }

        /// <summary>
        /// 作废
        /// </summary>
        /// <param name="WORKID"></param>
        /// <param name="NODEID"></param>
        /// <returns></returns>
        public ActionResult DeleteWork(int WORKID, int NODEID)
        {
            using (var trans = NH.Session.BeginTransaction())
            {
                try
                {
                    var work = NH.Session.Load<WF_GenerWorkFlow>(WORKID);
                    var CurrentNodeID = BP.WF.Dev2Interface.Node_GetCurrentNodeID(work.FK_Flow, WORKID);

                    if (CurrentNodeID != NODEID)
                    {
                        throw new DomainException("当前案件信息已更新，请刷新页面！");
                    }

                    FlowService.OnTuiJian(work.FK_Flow, WORKID, work.YWH, NODEID);

                    BP.WF.Dev2Interface.Port_Login(ApplicationUser.Current.Name, "dd2f628c-3f38-4c8c-aa83-1a52ebf6a45a");
                    BP.WF.Dev2Interface.Flow_DoDeleteFlowByFlag(work.FK_Flow, WORKID, "", false);

                    trans.Commit();
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return Json(new { success = false, message = ex.Message });
                }
            }
        }

        /// <summary>
        /// 获取节点与连接线
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNodesAndDirections(string workflowNo)
        {
            var nodeList = NH.Session.QueryOver<WF_Node>().Where(x => x.FK_Flow == workflowNo).List();
            var directionList=NH.Session.QueryOver<WF_Direction>().Where(x => x.FK_Flow == workflowNo).List();
            return Json_Get(new { nodeList=nodeList, directionList= directionList });
        }
    }
}
