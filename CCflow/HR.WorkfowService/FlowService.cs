using HR.WorkflowService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
////using HR.WorkflowService.DAOs;
using System.Data;
using System.Collections;
using HR.BasicFramework.DataAccess;
using HR.WorkflowService.Common;

namespace HR.WorkflowService.Service
{
    /// <summary>
    /// 流程服务
    /// </summary>
    public class FlowService
    {
        /// <summary>
        /// 发送流程
        /// </summary>
        /// <param name="flowNo">流程编号</param>
        /// <param name="nodeID">节点ID</param>
        /// <param name="workID">工作ID</param>
        /// <param name="toNodes">发送到的节点</param>
        /// <param name="userName">用户名</param>
        /// <returns>发送结果</returns>
        public static SendReturnObject WorkOpt_SendToNodes(string flowNo, int nodeID, int workID, string toNodes,int FID, string userName)
        {
            UserLogin(userName);
            var result = BP.WF.Dev2Interface.WorkOpt_SendToNodes(flowNo, nodeID, workID, FID, toNodes);
            return new SendReturnObject()
            {
                success = true,
                IsStopFlow = result.IsStopFlow,
                VarAcceptersID = result.VarAcceptersID,
                VarAcceptersName = result.VarAcceptersName,
                VarCurrNodeID = result.VarCurrNodeID,
                VarCurrNodeName = result.VarCurrNodeName,
                VarToNodeID = result.VarToNodeID,
                VarToNodeIDs = result.VarToNodeIDs,
                VarToNodeName = result.VarToNodeName,
                VarTreadWorkIDs = result.VarTreadWorkIDs,
                VarWorkID = result.VarWorkID
            };
        }


        /// <summary>
        /// 获取我可以申请的流程
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>流程列表</returns>
        public static BP.WF.Flows GetData(string userName)
        {
            var entities = BP.WF.Dev2Interface.DB_GenerCanStartFlowsOfEntities(userName);
            return entities;
        }

        /// <summary>
        /// 获取用户草稿分页信息
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="userName">用户名</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>流程分页列表</returns>
        public static PaginationInfo GetMyPagedOfDraft(int page, int rows, string userName, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);

            //var dao = new FLOWDAO();

            var sql = string.Format("SELECT * FROM V_BIZ_FINO_BWA_DRAFT WHERE FLOWSTARTER='{0}'", userName);

            //return DataContextNH.GetBySQL<dynamic, dynamic>(sql,null,page,rows);

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 获取用户草稿列表
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>流程草稿列表</returns>
        public static IList<dynamic> GetDataOfDraft(string userName, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);

            //var dao = new FLOWDAO();

            var sql = string.Format("SELECT * FROM V_BIZ_FINO_BWA_DRAFT WHERE FLOWSTARTER='{0}'", userName);

            return QueryService.GetData(sql, filter, orders, true);
        }

        /// <summary>
        /// 获取流程所有草稿列表
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="workNoList">工作编号列表</param>
        /// <param name="total">总数</param>
        /// <returns>流程草稿列表</returns>
        public static IList<FlowData> GetPagedOfAllDraft(int page, int rows, List<string> workNoList, out int total)
        {
            var table = new DataTable("DraftTable");
            foreach (string flowNo in workNoList)
            {
                var datatable = BP.WF.Dev2Interface.DB_GetAllDraft(flowNo);
                table.Merge(datatable);
            }

            table.Columns["OID"].ColumnName = "WorkID";

            var entities = ConvertHelper.GetList<FlowData>(table).OrderByDescending(x => x.RDT);
            var result = entities.Skip((page - 1) * rows).Take(rows).ToList();

            total = entities.Count();

            return result;
        }

        /// <summary>
        /// 删除草稿数据
        /// </summary>
        /// <param name="flowNo">流程编号</param>
        /// <param name="workID">工作ID</param>
        public static void Node_DeleteDraft(string flowNo, int workID)
        {
            BP.WF.Dev2Interface.Node_DeleteDraft(flowNo, workID);
        }

        /// <summary>
        /// 获取岗位待办
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="userName">用户名</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>待办分页结果集</returns>
        public static PaginationInfo GetMyPagedOfStation(int page, int rows, string userName, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);
            var sql = string.Format("SELECT * FROM V_BIZ_INFO_BWA_GWDB WHERE FK_Emp='{0}' ORDER BY FK_Flow,ADT DESC", userName);
            //var dao = new FLOWDAO();

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
        /// <returns>个人待办分页结果集</returns>
        public static PaginationInfo GetMyPagedOfPersonal(int page, int rows, string userName, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);
            var sql = string.Format("SELECT * FROM V_BIZ_INFO_BWA_GRDB WHERE FK_Emp='{0}' ORDER BY FK_Flow,ADT DESC", userName);
            //var dao = new FLOWDAO();

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 创建空白流程，流程状态为0
        /// </summary>
        /// <param name="flowNo">流程编号</param>
        /// <param name="userName">用户名</param>
        /// <returns>流程工作标识</returns>
        public static long CreateBlankWork(string flowNo, string userName)
        {
            try
            {
                UserLogin(userName);
                var workID = BP.WF.Dev2Interface.Node_CreateBlankWork(flowNo, null, null, userName, null);
                var nodeID = BP.WF.Dev2Interface.Node_GetCurrentNodeID(flowNo, workID);
                var node = NodeService.GetNode(nodeID);
                return workID;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 保存为草稿
        /// </summary>
        /// <param name="flowNo">流程编号</param>
        /// <param name="workID">工作ID</param>
        /// <returns>成功与否</returns>
        public static bool SaveAsDraft(string flowNo, long workID)
        {
            try
            {
                BP.WF.Dev2Interface.Node_SetDraft(flowNo, workID);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 发送流程
        /// </summary>
        /// <param name="flowNo">流程编号</param>
        /// <param name="workId">工作ID</param>
        /// <param name="currentNodeID">工作ID</param>
        /// <param name="nodeID">节点ID</param>
        /// <param name="userName">用户名</param>
        /// <param name="pairs">参数</param>
        /// <param name="nextWorkers">参数</param>
        /// <returns>发送结果</returns>
        public static SendReturnObject Node_SendWork(string flowNo, int workId, int currentNodeID, int nodeID, string userName, KeyValue[] pairs = null, string nextWorkers = null)
        {
            if (nodeID <= 0)
            {
                try
                {
                    Hashtable ht = null;
                    if (pairs != null)
                    {
                        var dic = pairs.ToDictionary(x => x.Key, x => x.Value);
                        ht = new Hashtable(dic);
                    }
                    UserLogin(userName);
                    BeforeSendCheck(flowNo, workId, currentNodeID);
                    var result = BP.WF.Dev2Interface.Node_SendWork(flowNo, workId, ht, 0, nextWorkers);
                    return new SendReturnObject()
                    {
                        success = true,
                        IsStopFlow = result.IsStopFlow,
                        VarAcceptersID = result.VarAcceptersID,
                        VarAcceptersName = result.VarAcceptersName,
                        VarCurrNodeID = result.VarCurrNodeID,
                        VarCurrNodeName = result.VarCurrNodeName,
                        VarToNodeID = result.VarToNodeID,
                        VarToNodeIDs = result.VarToNodeIDs,
                        VarToNodeName = result.VarToNodeName,
                        VarTreadWorkIDs = result.VarTreadWorkIDs,
                        VarWorkID = result.VarWorkID
                    };
                }
                catch (Exception ex)
                {
                    return new SendReturnObject()
                    {
                        success = false,
                        error = ex.Message
                    };
                }
            }
            else
            {
                try
                {
                    UserLogin(userName);
                    BeforeSendCheck(flowNo, workId, currentNodeID);
                    var result = BP.WF.Dev2Interface.Node_SendWork(flowNo, workId, nodeID, nextWorkers);
                    return new SendReturnObject()
                    {
                        success = true,
                        IsStopFlow = result.IsStopFlow,
                        VarAcceptersID = result.VarAcceptersID,
                        VarAcceptersName = result.VarAcceptersName,
                        VarCurrNodeID = result.VarCurrNodeID,
                        VarCurrNodeName = result.VarCurrNodeName,
                        VarToNodeID = result.VarToNodeID,
                        VarToNodeIDs = result.VarToNodeIDs,
                        VarToNodeName = result.VarToNodeName,
                        VarTreadWorkIDs = result.VarTreadWorkIDs,
                        VarWorkID = result.VarWorkID
                    };
                }
                catch (Exception ex)
                {
                    return new SendReturnObject()
                    {
                        success = false,
                        error = ex.Message
                    };
                }
            }
        }

        /// <summary>
        /// 执行工作退回(退回指定的点)
        /// </summary>
        /// <param name="fk_flow">流程编号</param>
        /// <param name="workID">工作ID</param>
        /// <param name="fid">父ID</param>
        /// <param name="currentNodeID">当前节点ID</param>
        /// <param name="returnToNodeID">退回的节点ID</param>
        /// <param name="userName">用户名</param>
        /// <returns>成功与否</returns>
        public static bool Node_ReturnWork(string fk_flow, Int64 workID, Int64 fid, int currentNodeID, int returnToNodeID,string returnToEmp, string userName)
        {
            try
            {
                UserLogin(userName);
                var message = BP.WF.Dev2Interface.Node_ReturnWork(fk_flow, workID, fid, currentNodeID, returnToNodeID, returnToEmp,"", false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 执行-撤销发送
        /// </summary>
        /// <param name="flowNo">流程编号</param>
        /// <param name="workID">工作ID</param>
        /// <param name="userName">用户名</param>
        /// <returns>成功与否</returns>
        public static bool Flow_DoUnSend(string flowNo, Int64 workID, string userName)
        {
            try
            {
                UserLogin(userName);
                var message = BP.WF.Dev2Interface.Flow_DoUnSend(flowNo, workID);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取流程日志
        /// </summary>
        /// <param name="FK_Flow">流程编号</param>
        /// <param name="WorkID">工作ID</param>
        /// <param name="FID">父ID</param>
        /// <returns>日志列表</returns>
        public static IList<Track> DB_GenerTrack(string FK_Flow, int WorkID, int FID)
        {
            var dataTable = BP.WF.Dev2Interface.DB_GenerTrack(FK_Flow, WorkID, FID).Tables[0];
            return ConvertHelper.GetList<Track>(dataTable).ToList();
        }

        /// <summary>
        /// 根据流程编号获取迁移方向实体
        /// </summary>
        /// <param name="workflowNo">流程编号</param>
        /// <returns>连接线记录集</returns>
        public static IList<DIRECTION> GetDirectionsByFlowNo(string workflowNo)
        {
            //var dao = new DIRECTIONDAO();
            var list = DataContextNH.GetByLINQ<DIRECTION>(x => x.FK_FLOW == workflowNo, null, null, null, null);
            return list;
        }

        /// <summary>
        /// 设置是此工作为读取状态
        /// </summary>
        /// <param name="nodeID">节点标识</param>
        /// <param name="workID">工作标识</param>
        /// <param name="userName">用户名</param>
        /// <returns>成功与否</returns>
        public static bool Node_SetWorkRead(int nodeID, Int64 workID, string userName)
        {
            try
            {
                var workList = ConvertHelper.GetList<FlowData>(BP.WF.Dev2Interface.Flow_GetWorkerList(workID));
                if (workList.Where(x => x.ISREAD).Count() > 0)
                {
                    return false;
                }
                var work = workList.Where(x => !x.ISREAD && x.FK_NODE == nodeID).FirstOrDefault();
                if (work == null)
                {
                    return false;
                }

                UserLogin(userName);
                BP.WF.Dev2Interface.Node_SetWorkRead(nodeID, workID);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置是此工作为未读取状态
        /// </summary>
        /// <param name="nodeID">节点标识</param>
        /// <param name="workID">工作标识</param>
        /// <param name="userName">用户名</param>
        /// <returns>成功与否</returns>
        public static bool Node_SetWorkUnRead(int nodeID, Int64 workID, string userName)
        {
            try
            {
                BP.WF.Dev2Interface.Node_SetWorkUnRead(nodeID, workID, userName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 流程转发
        /// </summary>
        /// <param name="flowNo">流程标识</param>
        /// <param name="nodeID">节点标识</param>
        /// <param name="workID">工作标识</param>
        /// <param name="fid">父标识</param>
        /// <param name="toEmp">要转发用户</param>
        /// <param name="msg">信息</param>
        /// <param name="userName">用户名</param>
        /// <returns>成功与否</returns>
        public static bool Node_Shift(string flowNo, int nodeID, Int64 workID, Int64 fid, string toEmp, string msg, string userName)
        {
            try
            {
                UserLogin(userName);
                BP.WF.Dev2Interface.Node_Shift(flowNo, nodeID, workID, fid, toEmp, msg);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 取消流程转发
        /// </summary>
        /// <param name="flowNo">流程标识</param>
        /// <param name="workID">工作标识</param>
        /// <param name="toEmpName">已转发用户</param>
        /// <param name="userName">用户名</param>
        /// <returns>操作结果消息</returns>
        public static string Node_UnShift(string flowNo, Int64 workID, string toEmpName, string userName)
        {
            try
            {
                UserLogin(userName);
                var mwf = new BP.WF.WorkFlow(flowNo, workID);
                return mwf.DoUnShift(toEmpName);
            }
            catch
            {
                return "取消转发失败";
            }
        }

        /// <summary>
        /// 获取流程转发列表
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="userName">用户名</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>转发分页记录集</returns>
        public static PaginationInfo GetMyPageOfShift(int page, int rows, string userName, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);
            var sql = string.Format("SELECT * FROM V_BIZ_FINO_BWA_SHIFT WHERE FK_EMP='{0}' ORDER BY RDT DESC", userName);
            //var dao = new FLOWDAO();

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 退件
        /// </summary>
        /// <param name="flowNo">流程标识</param>
        /// <param name="workID">工作标识</param>
        /// <param name="isDelSubFlow">是否删除子流程</param>
        /// <param name="userName">用户名</param>
        /// <param name="msg">退件信息（一般为空）</param>
        /// <returns>成功与否</returns>
        public static bool Flow_DoDeleteFlowByFlag(string flowNo, Int64 workID, bool isDelSubFlow, string userName, string msg = "")
        {
            try
            {
                UserLogin(userName);
                BP.WF.Dev2Interface.Flow_DoDeleteFlowByFlag(flowNo, workID, msg, isDelSubFlow);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取退件列表
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="userName">用户名</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序号</param>
        /// <returns>退件分页结果集</returns>
        public static PaginationInfo GetPagedOfReturn(int page, int rows, string userName, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);
            var sql = string.Format("SELECT * FROM V_BIZ_FINO_BWA_ALL WHERE FID=0 AND WFSTATE=7 ORDER BY RDT DESC", userName);
            //var dao = new FLOWDAO();

            return QueryService.CreatePagedSQLQuery(sql, page, rows, filter, orders, true);
        }

        /// <summary>
        /// 是否最后一个节点
        /// </summary>
        /// <param name="nodeId">节点标识</param>
        /// <returns>是或否</returns>
        public static bool IsEndNode(int nodeId)
        {
            var node = new BP.WF.Node(nodeId);
            return node.IsEndNode;
        }

        /// <summary>
        /// 获取用户待办箱超时流程数
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>超时流程数</returns>
        public static int GetCountOfDbOutdate(string userName)
        {
            //var dao = new FLOWDAO();
            var sql = string.Format("SELECT COUNT(*) AS RECORDCOUNT FROM V_BIZ_INFO_BWA_GWDB WHERE FK_EMP='{0}' AND ISOUTDATE=1", userName);
            //var result = DataContextNH.GetFirstBySQL<WF_FLOW, decimal>(sql);// dao.NSession.CreateSQLQuery(sql).ListIDictionary();
            //return (int)result;
            return 0;
        }

        /// <summary>
        /// 挂起
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="flowNo"></param>
        /// <param name="workID"></param>
        /// <returns></returns>
        public static string Node_HungUpWork(string userName, string flowNo, Int64 workID)
        {
            UserLogin(userName);
            return BP.WF.Dev2Interface.Node_HungUpWork(flowNo, workID, (int)BP.WF.HungUpWay.Forever, "", "");
        }

        /// <summary>
        /// 解挂
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="flowNo"></param>
        /// <param name="workID"></param>
        /// <returns></returns>
        public static void Node_UnHungUpWork(string userName, string flowNo, Int64 workID)
        {
            UserLogin(userName);
            BP.WF.Dev2Interface.Node_UnHungUpWork(flowNo, workID, "");
        }

        /// <summary>
        /// 判断是否跨某一节点，只适合一条线流程
        /// </summary>
        /// <param name="targetNodeId"></param>
        /// <param name="fromNodeId"></param>
        /// <param name="toNodeId"></param>
        /// <returns></returns>
        public static bool CheckAcrossNodeId(int targetNodeId, int fromNodeId, int toNodeId)
        {
            if (fromNodeId == targetNodeId)
            {
                return false;
            }

            if (toNodeId == targetNodeId)
            {
                return true;
            }

            var direction = DataContextNH.GetByLINQ<DIRECTION>(x => x.TONODE.Value == fromNodeId, null, null, null, null).FirstOrDefault();

            var i = 0;
            while (direction != null)
            {
                i++;
                if (i > 100)
                {
                    return false;
                }
                if (direction.NODE == targetNodeId)
                {
                    return true;
                }
                if (direction.NODE == toNodeId) {
                    return false;
                }
                direction = DataContextNH.GetByLINQ<DIRECTION>(x => x.TONODE.Value == direction.NODE, null, null, null, null).FirstOrDefault();
            }
            return false;
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        private static void UserLogin(string userNo)
        {
            var emp = new BP.Port.Emp(userNo);
            BP.Web.WebUser.SignInOfGener(emp);
        }

        /// <summary>
        /// 发送前检查是否已退件、是否已办理
        /// </summary>
        /// <param name="fk_flow">流程标识</param>
        /// <param name="workId">工作标识</param>
        /// <param name="currentNodeID">当前节点标识</param>
        public static void BeforeSendCheck(string fk_flow, int workId, int currentNodeID)
        {
            BP.WF.GenerWorkFlow gwf = null;
            try
            {
                gwf = new BP.WF.GenerWorkFlow(workId);
            }
            catch { }

            if (gwf != null)
            {
                if (gwf.WFState == BP.WF.WFState.Delete)
                {
                    throw new Exception("该案件已经退件，请刷新页面");
                }

                var _currentNodeID = BP.WF.Dev2Interface.Node_GetCurrentNodeID(fk_flow, workId);

                if (currentNodeID != _currentNodeID)
                {
                    throw new Exception("当前环节已经完成，请刷新页面！！");
                }
            }
        }
    }

    /// <summary>
    /// 发送返回数据
    /// </summary>
    public class SendReturnObject
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success
        {
            get;
            set;
        }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string error
        {
            get;
            set;
        }
        #region 获取系统变量
        /// <summary>
        /// 工作标识字符串
        /// </summary>
        public Int64 VarWorkID
        {
            get;
            set;
        }
        /// <summary>
        /// 是否终止流程
        /// </summary>
        public bool IsStopFlow
        {
            get;
            set;
        }

        /// <summary>
        /// 到达节点ID
        /// </summary>
        public int VarToNodeID
        {
            get;
            set;
        }
        /// <summary>
        /// 到达节点IDs
        /// </summary>
        public string VarToNodeIDs
        {
            get;
            set;
        }
        /// <summary>
        /// 到达节点名称
        /// </summary>
        public string VarToNodeName
        {
            get;
            set;
        }
        /// <summary>
        /// 到达的节点名称
        /// </summary>
        public string VarCurrNodeName
        {
            get;
            set;
        }
        /// <summary>
        /// 当前节点标识
        /// </summary>
        public int VarCurrNodeID
        {
            get;
            set;
        }
        /// <summary>
        /// 接受人
        /// </summary>
        public string VarAcceptersName
        {
            get;
            set;
        }
        /// <summary>
        /// 接受人IDs
        /// </summary>
        public string VarAcceptersID
        {
            get;
            set;
        }
        /// <summary>
        /// 分流向子线程发送时产生的子线程的WorkIDs, 多个有逗号分开.
        /// </summary>
        public string VarTreadWorkIDs
        {
            get;
            set;
        }
        #endregion
    }
}
