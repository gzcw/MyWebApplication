using BP.WF;
using HR.WorkflowService.Models;
using System.Collections.Generic;
using System.Linq;
using HR.BasicFramework.DataAccess;

namespace HR.WorkflowService.Service
{
    /// <summary>
    /// 审批意见服务
    /// </summary>
    public class ApproveOpinionService
    {
        /// <summary>
        /// 根据WorkID,NodeID获取当前用户的审批意见信息
        /// </summary>
        /// <param name="workID">工作ID</param>
        /// <param name="nodeID">节点ID</param>
        /// <param name="userName">用户名</param>
        /// <returns>审批意见</returns>
        public static ApproveOpinion GetOpinionOfCurrentUser(string workID, string nodeID, string userName)
        {
            //var dao = new ApproveOpinionDAO();
             //DataContextNH.GetBySQL<ApproveOpinion, ApproveOpinion>("");
            return DataContextNH.GetBySQL<ApproveOpinion, ApproveOpinion>(string.Format("SELECT * FROM WF_SYS_ApproveOpinion WHERE Work_id='{0}' AND Node_id='{1}' AND Approver='{2}'", workID, nodeID, userName)).FirstOrDefault();
        }

        /// <summary>
        /// 获取节点以前的审批意见
        /// </summary>
        /// <param name="bwaID">办文案ID</param>
        /// <param name="nodeID">节点ID</param>
        /// <returns>审批意见列表</returns>
        public static List<ApproveOpinion> GetOpinionOfPreviousNode(int bwaID, int nodeID)
        {
            //var dao = new ApproveOpinionDAO();
            var entities = DataContextNH.GetBySQL<ApproveOpinion, ApproveOpinion>(string.Format("SELECT * FROM WF_SYS_ApproveOpinion WHERE Work_id='{0}'", bwaID)).ToList();

            var nodeList = NodeService.GetPreviousNodeList(nodeID);
            entities = entities.Where(x => nodeList.Where(y => y.NodeID == int.Parse(x.Node_id)).Count() > 0).ToList();
            return entities;
        }
    }
}
