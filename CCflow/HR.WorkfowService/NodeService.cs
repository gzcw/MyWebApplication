using HR.BasicFramework.DataAccess;
using HR.WorkflowService.Common;
////using HR.WorkflowService.DAOs;
using HR.WorkflowService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.WorkflowService.Service
{
    /// <summary>
    /// 节点服务
    /// </summary>
    public class NodeService
    {
        /// <summary>
        /// 从CCFlow获取节点分页数据
        /// </summary>
        /// <param name="page">页</param>
        /// <param name="rows">行</param>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序</param>
        /// <returns>节点分页记录集</returns>
        public static object GetPagedFromCCFlow(int page, int rows, string filterStr = "[]", string orders = "")
        {
            var filter = QueryService.DeserializeFilter(filterStr);

            //var dao = new NODEDAO();

            var sql = "SELECT NODEID AS ID,NAME,STEP,FK_FLOW AS Definition_id FROM WF_NODE";

            //var result = QueryService.CreatePagedSQLQuery(DataContextNH., sql, page, rows, filter, orders);

            var result = DataContextNH.GetBySQL<dynamic, dynamic>(sql);

            return result;
        }

        /// <summary>
        /// 获取节点
        /// </summary>
        /// <param name="nodeID">节点ID</param>
        /// <returns>节点</returns>
        public static FlowNode GetNode(int nodeID)
        {
            return ConvertHelper.GetList<FlowNode>(BP.WF.Dev2Interface.GetNode(nodeID)).FirstOrDefault();
        }

        /// <summary>
        /// 获取下一步骤的所有节点
        /// </summary>
        /// <param name="workflowNo">流程编号</param>
        /// <param name="ndFrom">从节点</param>
        /// <param name="workid">工作ID</param>
        /// <returns>节点列表</returns>
        public static List<FlowNode> WorkOpt_GetToNodes(string workflowNo, int ndFrom, int workid, int FID)
        {
            var flowNodeList = ConvertHelper.GetList<FlowNode>(BP.WF.Dev2Interface.WorkOpt_GetToNodes(workflowNo, ndFrom, workid, FID).ToDataSet().Tables[0]);
            return flowNodeList;
        }

        /// <summary>
        /// 获取当前节点
        /// </summary>
        /// <param name="workflowNo">流程编号</param>
        /// <param name="workId">工作ID</param>
        /// <returns>节点</returns>
        public static FlowNode Node_GetCurrentNode(string workflowNo, long workId)
        {
            var nodeId = BP.WF.Dev2Interface.Node_GetCurrentNodeID(workflowNo, workId);
            var node = ConvertHelper.GetList<FlowNode>(BP.WF.Dev2Interface.GetNode(nodeId)).FirstOrDefault();
            return node;
        }

        /// <summary>
        /// 获取当前节点ID
        /// </summary>
        /// <param name="workflowNo">流程编号</param>
        /// <param name="workId">工作ID</param>
        /// <returns>节点标识</returns>
        public static int Node_GetCurrentNodeID(string workflowNo, long workId)
        {
            var nodeId = BP.WF.Dev2Interface.Node_GetCurrentNodeID(workflowNo, workId);
            return nodeId;
        }


        /// <summary>
        /// 获取当前节点ID列表
        /// </summary>
        /// <param name="workflowNo">流程编号</param>
        /// <param name="workId">工作ID</param>
        /// <returns>节点标识集</returns>
        public static List<int> Node_GetCurrentNodeIDList(string workflowNo, long workId)
        {
            var nodeIdList = BP.WF.Dev2Interface.Node_GetCurrentNodeIDList(workflowNo, workId).ToList();
            return nodeIdList;
        }

        /// <summary>
        /// 获取当前节点可以退回的节点
        /// </summary>
        /// <param name="fk_node">节点ID</param>
        /// <param name="workid">工作ID</param>
        /// <param name="fid">父ID</param>
        /// <returns>节点记录集</returns>
        public static IList<FlowNode> DB_GenerWillReturnNodes(int fk_node, int workid, int fid)
        {
            try
            {
                var dataTable = BP.WF.Dev2Interface.DB_GenerWillReturnNodes(fk_node, workid, fid);
                if (dataTable.Rows.Count == 0)
                {
                    return new List<FlowNode>();
                }

                dataTable.Columns["NO"].ColumnName = "NodeID";
                return ConvertHelper.GetList<FlowNode>(dataTable).ToList();
            }
            catch (Exception)
            {
                return new List<FlowNode>();
            }
        }

        /// <summary>
        /// 根据工作ID获取已处理的流程节点
        /// </summary>
        /// <param name="workId">工作ID</param>
        /// <returns>已处理的流程节点</returns>
        public static List<GenerWorkerlist> GetProcessedNodesByWorkId(int workId)
        {
            var workerlistTable = BP.WF.Dev2Interface.GetProcessedNodesByWorkId(workId);
            return ConvertHelper.GetList<GenerWorkerlist>(workerlistTable).OrderByDescending(x => x.ISREAD).ToList();
        }

        /// <summary>
        /// 根据工作ID、节点ID获取流程明细
        /// </summary>
        /// <param name="workId">工作ID</param>
        /// <param name="nodeId">节点ID</param>
        /// <returns>流程明细</returns>
        public static GenerWorkerlist GetOneGenerWorkerlist(int workId, int nodeId)
        {
            var workerlistTable = BP.WF.Dev2Interface.GetOneGenerWorklist(workId, nodeId);
            return ConvertHelper.GetList<GenerWorkerlist>(workerlistTable).FirstOrDefault();
        }

        /// <summary>
        /// 根据流程编号获取节点
        /// </summary>
        /// <param name="workflowNo">流程编号</param>
        /// <returns>节点列表</returns>
        public static List<FlowNode> GetNodesByFlowNo(string workflowNo)
        {

            var nodeTable = BP.WF.Dev2Interface.GetNodesByFlowNo(workflowNo);
            return ConvertHelper.GetList<FlowNode>(nodeTable);
        }

        /// <summary>
        /// 获取节点以前的节点集合
        /// </summary>
        /// <param name="nodeId">节点ID</param>
        /// <returns>节点集合</returns>
        public static List<FlowNode> GetPreviousNodeList(int nodeId)
        {
            var node = NodeService.GetNode(nodeId);
            var directions = FlowService.GetDirectionsByFlowNo(node.FK_Flow);
            directions = directions.Where(x => x.NODE != x.TONODE).ToList();

            var result = new List<FlowNode>();

            GetPreNodeList(directions, nodeId, result);

            return result;
        }

        /// <summary>
        /// 获取之前节点集合
        /// </summary>
        /// <param name="directions">方向集合</param>
        /// <param name="nodeId">节点ID</param>
        /// <returns>节点集合</returns>
        private static void GetPreNodeList(IList<DIRECTION> directions, int nodeId, List<FlowNode> result)
        {
            var node = NodeService.GetNode(nodeId);
            result.Add(node);

            foreach (var direction in directions)
            {
                if (result.Where(x => x.NodeID == direction.NODE).Count() > 0)
                {
                    continue;
                }
                if (direction.TONODE == nodeId)
                {
                    var fromNode = NodeService.GetNode(direction.NODE.Value);
                    if (fromNode != null)
                    {
                        result.Add(fromNode);
                    }
                    if (directions.Where(x => x.TONODE == direction.NODE && result.Where(y => y.NodeID == x.NODE).Count() == 0).Count() > 0)
                    {
                       GetPreNodeList(directions, direction.NODE.Value, result);
                    }
                }
            }
        }
    }
}
