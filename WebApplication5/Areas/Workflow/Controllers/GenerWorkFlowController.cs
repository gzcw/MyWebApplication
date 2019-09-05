using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 【流程管理】控制器
    /// </summary>
    public partial class GenerWorkFlowController : IntEntityController<WF_GenerWorkFlow>
    {
        #region 视图

        /// <summary>
        /// 待办箱
        /// </summary>
        /// <returns></returns>
        public ActionResult DaiBanXiang()
        {
            return View();
        }
        /// <summary>
        /// 在办箱
        /// </summary>
        /// <returns></returns>
        public ActionResult ZaiBanXiang()
        {
            return View();
        }
        /// <summary>
        /// 已办箱
        /// </summary>
        /// <returns></returns>
        public ActionResult YiBanXiang()
        {
            return View();
        }
        /// <summary>
        /// 抄送箱
        /// </summary>
        /// <returns></returns>
        public ActionResult ChaoSongXiang()
        {
            return View();
        }

        /// <summary>
        /// 草稿箱
        /// </summary>
        /// <returns></returns>
        public ActionResult CaoGaoXiang()
        {
            return View();
        }
        /// <summary>
        /// 业务查询
        /// </summary>
        /// <returns></returns>
        public ActionResult YeWuChaXun()
        {
            return View();
        }

        /// <summary>
        /// 进展情况
        /// </summary>
        /// <returns></returns>
        public ActionResult JinZhanQingKuang()
        {
            return View();
        }

        #endregion

        /// <summary>
        /// 获取草稿箱分页数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPaged_Draft(int page, int rows, List<MyFilter> filters, string orders = "RDT DESC")
        {
            var sql = string.Format("SELECT * FROM WF_GENERWORKFLOW T WHERE T.WFSTATE=1 AND T.STARTER='{0}'", ApplicationUser.Current.Name);
            return PagedQuery(sql, page, rows, filters,orders);
        }

        /// <summary>
        /// 获取待办箱分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public ActionResult GetPaged_DaiBan(int page, int rows, List<MyFilter> filters, string orders = "ISREAD DESC,RDT DESC")
        {
            var sql = string.Format("SELECT T.*,DBO.GET_SJZD_NAME('WFSTATE',T.WFSTATE) AS WfStateName FROM WF_EMPWORKS T WHERE T.WFSTATE IN (2,5) AND T.FK_EMP='{0}'", ApplicationUser.Current.Name);
            return PagedQuery(sql, page, rows, filters, orders);
        }

        /// <summary>
        /// 获取已办箱分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public ActionResult GetPaged_YiBan(int page, int rows, List<MyFilter> filters, string orders = "RDT DESC")
        {
            var flowList = NH.Session.QueryOver<WF_Flow>().List();
            var trackSql = string.Join(" UNION ", flowList.Select(x => string.Format("SELECT WORKID,EMPFROM FROM ND{0}TRACK", int.Parse(x.No))));
            var sql = string.Format("SELECT T.*,DBO.GET_SJZD_NAME('WFSTATE',T.WFSTATE) AS WfStateName FROM WF_GENERWORKFLOW T INNER JOIN ({0}) TRACK ON TRACK.WORKID=T.WORKID WHERE TRACK.EMPFROM = '{1}'", trackSql, ApplicationUser.Current.Name);
            return PagedQuery(sql, page, rows, filters, orders);
        }


        /// <summary>
        /// 获取业务查询分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public ActionResult GetPaged_YeWuChaXun(int page, int rows, List<MyFilter> filters, string orders = "RDT DESC")
        {
            var sql = "SELECT T.*,DBO.GET_SJZD_NAME('WFSTATE',T.WFSTATE) AS WfStateName FROM WF_GENERWORKFLOW T WHERE T.WFSTATE!=0";
            return PagedQuery(sql, page, rows, filters, orders);
        }


        /// <summary>
        /// 加载进展情况信息
        /// </summary>
        /// <param name="WorkID"></param>
        /// <returns></returns>
        public ActionResult GetJinZhanQingKuang(int WorkID)
        {
            try
            {
                var work = NH.Session.Load<WF_GenerWorkFlow>(WorkID);
                var nodeList = NH.Session.QueryOver<WF_Node>().Where(x => x.FK_Flow == work.FK_Flow).List().ToList();
                var directionList = NH.Session.QueryOver<WF_Direction>().Where(x => x.FK_Flow == work.FK_Flow).List().ToList();
                var workerList = NH.Session.QueryOver<WF_GenerWorkerList>().Where(x => x.WorkID == WorkID && x.IsEnable == 1).List().OrderBy(x => x.CDT).ToList();
                var trackList = BP.WF.Dev2Interface.DB_GenerTrackTable(work.FK_Flow, WorkID, work.FID ?? 0);
                return Json_Get(new { success = true, nodeList = nodeList, directionList = directionList, workerList = workerList, trackList = trackList });
            }
            catch (Exception ex)
            {
                return Json_Get(new { success = false, msg = ex.Message });
            }
        }
    }
}
