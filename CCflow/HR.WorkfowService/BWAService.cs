using HR.WorkflowService.Common.Interface;
using HR.WorkflowService.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using HR.WorkflowService.Common;
using HR.WorkflowService.Models;
using HR.BasicFramework.DataAccess;

namespace HR.WorkflowService.Service
{
    /// <summary>
    /// 办文案服务
    /// </summary>
    public class BWAService
    {

        /// <summary>
        /// 流程完成触发事件
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <param name="bwlxId">办文类型ID</param>
        public static void OnCompleted(string bwaId, string slbh, string bwlxId, int currentNodeId)
        {
            var bwa = DataContextNH.GetByID<BWA>(bwaId);
            bwa.AJZTBS = 1;
            DataContextNH.Update(bwa);

            var trigger = getTrigger(bwlxId);
            if (trigger != null)
            {
                //trigger.OnCompleted(bwaId, slbh, currentNodeId);
            }
        }

        /// <summary>
        /// 流程发送前触发事件
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <param name="slbh">受理编号</param>
        /// <param name="bwlxId">办文类型ID</param>
        /// <param name="currentNodeId">当前节点ID</param>
        /// <param name="toNodes">到达的节点ID</param>
        /// <param name="senderList">发送列表</param>
        public static void OnBeforeSend(string bwaId, string slbh, string bwlxId, int currentNodeId,ref List<dynamic> senderList)
        {
            var trigger = getTrigger(bwlxId);
            if (trigger != null)
            {
                //trigger.OnBeforeSend(bwaId, slbh, currentNodeId,ref senderList);
            }
        }

        /// <summary>
        /// 流程发送触发事件
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <param name="slbh">受理编号</param>
        /// <param name="bwlxId">办文类型ID</param>
        /// <param name="currentNodeId">当前节点ID</param>
        /// <param name="toNodes">到达的节点ID</param>
        public static void OnSend(string bwaId, string slbh, string bwlxId, int currentNodeId, string toNodes)
        {
            var trigger = getTrigger(bwlxId);
            if (trigger != null)
            {
                //trigger.OnSend(bwaId, slbh, currentNodeId,toNodes);
            }
        }

        /// <summary>
        /// 流程退件触发事件
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <param name="slbh">受理编号</param>
        /// <param name="bwlxId">办文类型ID</param>
        /// <param name="currentNodeId">当前节点ID</param>
        public static void OnTuiJian(string bwaId, string slbh, string bwlxId, int currentNodeId)
        {
            var bwa = DataContextNH.GetByID<BWA>(bwaId);
            bwa.AJZTBS = -1;
            DataContextNH.Update(bwa);

            var trigger = getTrigger(bwlxId);
            if (trigger != null)
            {
                //trigger.OnTuiJian(bwaId, slbh, currentNodeId);
            }
        }

        /// <summary>
        /// 流程退回触发事件
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <param name="slbh">受理编号</param>
        /// <param name="bwlxId">办文类型ID</param>
        /// <param name="currentNodeId">当前节点ID</param>
        /// <param name="toNodeId">退回节点ID</param>
        public static void OnReturn(string bwaId, string slbh, string bwlxId, int currentNodeId, int toNodeId)
        {
            var trigger = getTrigger(bwlxId);
            if (trigger != null)
            {
               // trigger.OnReturn(bwaId, slbh, currentNodeId, toNodeId);
            }
        }

        /// <summary>
        /// 保存为草稿触发事件
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <param name="slbh">受理编号</param>
        /// <param name="bwlxId">办文类型ID</param>
        public static void OnSaveAsDraft(int bwaId, string slbh, string bwlxId)
        {
            var trigger = getTrigger(bwlxId);
            if (trigger != null)
            {
                trigger.OnSaveAsDraft(bwaId, slbh);
            }
        }

        /// <summary>
        /// 获取流程触发器
        /// </summary>
        /// <param name="bwlxId">办文案ID</param>
        /// <returns>触发器</returns>
        private static ITrigger getTrigger(string bwlxId)
        {
            try
            {
                var interfaceType = typeof(ITrigger);
                var assembiles = AppDomain.CurrentDomain.GetAssemblies();
                var types = new List<Type>();

                foreach (var item in assembiles)
                {
                    try
                    {
                        types.AddRange(item.GetTypes().Where(t => t.GetInterfaces().Contains(interfaceType)));
                    }
                    catch { }
                }

                //var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(interfaceType))).ToArray();
                foreach (var type in types)
                {
                    var attr = type.GetCustomAttributes(typeof(BWLXID), false).FirstOrDefault();
                    if (attr != null && (attr as BWLXID).IDs.Contains(bwlxId))
                    {
                        var trigger = (ITrigger)Activator.CreateInstance(type);
                        return trigger;
                    }
                }
                return null;
            }
            catch
            {
                throw new Exception("查找流程触发器错误");
            }
        }

        /// <summary>
        /// 获取岗位待办
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="userName">用户名</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>岗位待办分页列表</returns>
        public static PaginationInfo GetMyPagedOfStation(int page, int rows, string userName, string filterStr = "[]", string orders = "")
        {
            //var dao = new BWADAO();
            var filter = QueryService.DeserializeFilter(filterStr);
            var sql = string.Format("SELECT * FROM V_BIZ_INFO_BWA_GWDB WHERE FK_Emp='{0}' OR AUTHOR='{0}' ORDER BY RDT DESC", userName);

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 获取个人待办
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="userName">用户名</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>个人待办分页列表</returns>
        public static PaginationInfo GetMyPagedOfPersonal(int page, int rows, string userName, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);
            var sql = string.Format("SELECT * FROM V_BIZ_INFO_BWA_GRDB WHERE FK_Emp='{0}' ORDER BY RDT DESC", userName);
            //var dao = new BWADAO();

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 获取用户草稿分页信息
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="userName">用户名</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>草稿分页列表</returns>
        public static PaginationInfo GetMyPagedOfDraft(int page, int rows, string userName, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);

            //var dao = new BWADAO();

            var sql = string.Format("SELECT * FROM V_BIZ_FINO_BWA_DRAFT WHERE FLOWSTARTER='{0}'", userName);

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 业务查询列表
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>业务查询分页列表</returns>
        public static PaginationInfo GetPagedOfYWCX(int page, int rows, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);
            var sql = "SELECT * FROM V_BIZ_INFO_BWA_YWCX ORDER BY TO_NUMBER(ID) DESC,ISPASS DESC,CDT ASC";
            //var dao = new BWADAO();

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }


        /// <summary>
        /// 已办业务查询
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>业务查询分页列表</returns>
        public static PaginationInfo GetPagedOfYWCX_YB(int page, int rows, List<Filter> filter, string orders = "")
        {
            var sql = "SELECT * FROM V_BIZ_INFO_BWA_YWCX_YB";
            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 获取退件列表
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>退件分页列表</returns>
        public static PaginationInfo GetPagedOfReturn(int page, int rows, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);
            var sql = string.Format("SELECT * FROM V_BIZ_FINO_BWA_ALL WHERE FID=0 AND WFSTATE=7 ORDER BY RDT DESC");
            //var dao = new BWADAO();

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 获取流程转发列表
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="userName">用户名</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>流程转发分页列表</returns>
        public static PaginationInfo GetMyPageOfShift(int page, int rows, string userName, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);
            var sql = string.Format("SELECT * FROM V_BIZ_FINO_BWA_SHIFT WHERE FK_EMP='{0}' ORDER BY RDT DESC", userName);
            //var dao = new BWADAO();

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 获取用户待办箱超时流程数
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>待办超时总和</returns>
        public static int GetCountOfDbOutdate(string userName)
        {
            //var dao = new BWADAO();
            var sql = string.Format("SELECT COUNT(*) AS RECORDCOUNT FROM V_BIZ_INFO_BWA_GWDB WHERE FK_EMP='{0}' AND ISOUTDATE=1", userName);
            var result = DataContextNH.GetFirstBySQL<BWA, decimal>(sql);
            return (int)(result);
        }

        /// <summary>
        /// 获取用户在办箱超时流程数
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>在办超时总和</returns>
        public static int GetCountOfZbOutdate(string userName)
        {
            //var dao = new BWADAO();
            var sql = string.Format("SELECT COUNT(*) AS RECORDCOUNT FROM V_BIZ_INFO_BWA_GRDB WHERE FK_EMP='{0}' AND ISOUTDATE=1", userName);
            var result = DataContextNH.GetFirstBySQL<BWA, decimal>(sql);
            return (int)result;
        }
    }
}