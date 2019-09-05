using BP.WF.Template;
using WebApplication5.Areas.Authorize.Models;
using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;


namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 【流程节点】控制器
    /// </summary>
    public partial class NodeController : IntEntityController<WF_Node>
    {
        #region 视图

        #endregion


        /// <summary>
        /// 新建节点
        /// </summary>
        /// <param name="flowNo">流程编号</param>
        /// <param name="nodeName">节点名称</param>
        /// <param name="x">x值</param>
        /// <param name="y">y值</param>
        /// <returns>操作结果</returns>
        public ActionResult AddNode(string flowNo, string nodeName = "新建节点", int x = 10, int y = 10)
        {
            var fl = new BP.WF.Flow(flowNo);
            try
            {
                BP.WF.Node nf = fl.DoNewNode(x, y);
                nf.Name = nodeName;
                nf.HisRunModel = BP.WF.RunModel.Ordinary;
                nf.HisDeliveryWay = BP.WF.DeliveryWay.ByStationOnly;
                nf.Save();
                return Json(new { success = true, msg = "新建节点成功" });
            }
            catch
            {
                return Json(new { success = false, msg = "新建节点失败" });
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteNode(int nodeId)
        {
            try
            {
                BP.WF.Node delNode = new BP.WF.Node(nodeId);
                delNode.Delete();
                var sql = string.Format("delete from wf_direction where node={0} or tonode={0}", nodeId);
                BP.DA.DBAccess.RunSQL(sql);
                //var directionList = FlowService.GetDirectionsByFlowNo(delNode.FK_Flow);
                return Json(new { success = true, msg = "删除成功" });
            }
            catch
            {
                return Json(new { success = false, msg = "删除失败" });
            }
        }

        /// <summary>
        /// 获取下一步骤的所有节点
        /// </summary>
        /// <param name="workflowNo">流程编号</param>
        /// <param name="NodeID">从节点</param>
        /// <param name="WorkID">工作ID</param>
        /// <param name="FID">父工作ID</param>
        /// <param name="paramPairs">参数</param>
        /// <returns>节点列表</returns>
        public ActionResult WorkOpt_GetToNodes(int WorkID, int NodeID, int FID, List<KeyValuePair<string, string>> wfParams = null, int singleSelect = 1)
        {
            BP.WF.Dev2Interface.Port_Login(ApplicationUser.Current.Name, "dd2f628c-3f38-4c8c-aa83-1a52ebf6a45a");
            var work = NH.Session.QueryOver<WF_GenerWorkFlow>().Where(x => x.WorkID == WorkID).List().FirstOrDefault();
            wfParams = wfParams == null ? new List<KeyValuePair<string, string>>() : wfParams;
            var nodeEntity = NH.Session.Get<WF_Node>(NodeID);

            var dic = wfParams.ToDictionary(x => x.Key, x => x.Value);
            var ht = new Hashtable(dic);
            BP.WF.Glo.SendHTOfTemp = ht;
            var result = BP.WF.Dev2Interface.WorkOpt_GetToNodes(work.FK_Flow, NodeID, WorkID, FID);// NodeService.WorkOpt_GetToNodes(workflowNo, NODEID, WORKID, FID);

            //result = result.Where(x => x.NodeID != 0).ToList();

            var data = new List<dynamic>();

            //var trackList = FlowService.DB_GenerTrack(workflowNo, WORKID, 0).ToList();
            var userList = NH.Session.QueryOver<Auth_User>().List().ToList();

            foreach (BP.WF.Node item in result)
            {
                dynamic parent = new ExpandoObject();
                parent.FK_NODE = "";
                parent.value = item.NodeID.ToString();
                parent.text = item.Name;
                parent.RUNMODEL = item.HisRunModel;

                var flow = new BP.WF.Flow(work.FK_Flow);
                var workNode = new BP.WF.WorkNode(WorkID, NodeID);
                var toNode = new BP.WF.WorkNode(WorkID, item.NodeID);

                FindWorker fw = new FindWorker();
                var dt = fw.DoIt(flow, workNode, toNode);

               // var select = new BP.WF.Template.Selector(item.NodeID);
                //var wk = item.HisWork;
                //wk.OID = WORKID;
                //wk.Retrieve();
                //var ds = select.GenerDataSet(item.NodeID, null);
                var children = new List<ExpandoObject>();
                foreach (DataRow dr in dt.Rows)
                {
                    var user = userList.Where(x => x.Name == dr["No"].ToString()).FirstOrDefault();
                    if (user == null) {
                        continue;
                    }
                    dynamic child = new ExpandoObject();
                    child.value = dr["No"].ToString();
                    child.text = user.RealName;
                    child.NODEID = item.NodeID;
                    children.Add(child);
                }
                parent.children = children;

                //var empList = new List<dynamic>();
                //var toNodeEntity = NH.Session.Get<WF_NODE>(item.NodeID.ToString());
                //if (toNodeEntity.DELIVERYWAY == 8)
                //{
                //    //指定某个环节的处理人
                //    empList = QueryService.GetData(string.Format("SELECT DISTINCT {0} AS FK_NODE, T.FK_EMP AS NO ,T.FK_EMPTEXT AS NAME FROM WF_GENERWORKERLIST t WHERE ( t.workid={1} or t.workid={2} ) AND T.FK_NODE={3}", item.NodeID, WORKID, FID, toNodeEntity.DELIVERYPARAS), null, null, true).ToList();
                //}
                //else
                //{
                //    if (nodeEntity.HISDEPTSTRS == "1")
                //    {
                //        var userName = CurrentUser.UserName;

                //        empList = QueryService.GetData(string.Format("SELECT DISTINCT TO_CHAR(NT.FK_NODE) AS FK_NODE,E.NO,E.NAME||(CASE WHEN EMP.AUTHOR IS NOT NULL THEN '(由【'||AUTHOR.NAME||'】代理)' ELSE '' END) AS NAME,E.EMPNO FROM WF_NODESTATION NT INNER JOIN PORT_EMPSTATION ES ON NT.FK_STATION=ES.FK_STATION INNER JOIN PORT_EMP E ON E.NO=ES.FK_EMP INNER JOIN PORT_EMPDEPT EP ON EP.FK_EMP=E.NO  LEFT OUTER JOIN WF_EMP EMP ON EMP.NO=E.NO LEFT OUTER JOIN PORT_EMP AUTHOR ON AUTHOR.NO=EMP.AUTHOR WHERE NT.FK_NODE='{0}' AND EP.FK_DEPT IN (SELECT FK_DEPT FROM PORT_EMPDEPT WHERE FK_EMP='{1}') ORDER BY E.EMPNO", item.NodeID, CurrentUser.UserName), null, null, true).ToList();
                //    }
                //    else
                //    {

                //        empList = QueryService.GetData(string.Format("SELECT DISTINCT TO_CHAR(NT.FK_NODE) AS FK_NODE,E.NO,E.NAME||(CASE WHEN EMP.AUTHOR IS NOT NULL THEN '(由【'||AUTHOR.NAME||'】代理)' ELSE '' END) AS NAME,E.EMPNO FROM WF_NODESTATION NT INNER JOIN PORT_EMPSTATION ES ON NT.FK_STATION=ES.FK_STATION INNER JOIN PORT_EMP E ON E.NO=ES.FK_EMP LEFT OUTER JOIN WF_EMP EMP ON EMP.NO=E.NO LEFT OUTER JOIN PORT_EMP AUTHOR ON AUTHOR.NO=EMP.AUTHOR WHERE NT.FK_NODE='{0}' ORDER BY E.EMPNO", item.NodeID), null, null, true).ToList();
                //    }
                //}
                //var test = new ExpandoObject();
                //foreach (Dictionary<string, object> emp in empList)
                //{
                //    emp.Add("RUNMODEL", item.HisRunModel);
                //}
                //data.AddRange(empList);
                data.Add(parent);
            }
            return Json_Get(data);
        }
    }
}
