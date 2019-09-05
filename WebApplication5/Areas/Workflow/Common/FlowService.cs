using WebApplication5.Areas.Workflow.Common.CustomAttributes;
using WebApplication5.Areas.Workflow.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication5.Areas.Workflow.Common
{
    /// <summary>
    /// 流程服务
    /// </summary>
    public class FlowService
    {
        /// <summary>
        /// 流程完成触发事件
        /// </summary>
        /// <param name="WORKID">办文案ID</param>
        /// <param name="bwlxId">办文类型ID</param>
        public static void OnCompleted(string FLOWNO, int WORKID, string YWH, int NODEID)
        {
            var trigger = getTrigger(FLOWNO);
            if (trigger != null)
            {
                trigger.OnCompleted(FLOWNO, WORKID, YWH, NODEID);
            }
        }

        /// <summary>
        /// 流程发送前触发事件
        /// </summary>
        /// <param name="FLOWNO"></param>
        /// <param name="WORKID"></param>
        /// <param name="YWH"></param>
        /// <param name="NODEID"></param>
        public static void OnBeforeSend(string FLOWNO, int WORKID, string YWH, int NODEID)
        {
            var trigger = getTrigger(FLOWNO);
            if (trigger != null)
            {
                trigger.OnBeforeSend(FLOWNO, WORKID, YWH, NODEID);
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
        public static void OnSend(string FLOWNO, int WORKID, string YWH, int NODEID)
        {
            var trigger = getTrigger(FLOWNO);
            if (trigger != null)
            {
                trigger.OnSend(FLOWNO, WORKID, YWH, NODEID);
            }
        }

        /// <summary>
        /// 流程退件触发事件
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <param name="slbh">受理编号</param>
        /// <param name="bwlxId">办文类型ID</param>
        /// <param name="currentNodeId">当前节点ID</param>
        public static void OnTuiJian(string FLOWNO, int WORKID, string YWH, int NODEID)
        {
            var trigger = getTrigger(FLOWNO);
            if (trigger != null)
            {
                trigger.OnTuiJian(FLOWNO,WORKID, YWH, NODEID);
            }
        }
        /// <summary>
        /// 流程退回触发事件
        /// </summary>
        /// <param name="FLOWNO"></param>
        /// <param name="WORKID"></param>
        /// <param name="YWH"></param>
        /// <param name="NODEID"></param>
        public static void OnReturn(string FLOWNO, int WORKID, string YWH, int NODEID, int TONODEID)
        {
            var trigger = getTrigger(FLOWNO);
            if (trigger != null)
            {
                trigger.OnReturn(FLOWNO, WORKID, YWH, NODEID,TONODEID);
            }
        }

        /// <summary>
        /// 保存为草稿触发事件
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <param name="slbh">受理编号</param>
        /// <param name="bwlxId">办文类型ID</param>
        public static void OnSaveAsDraft(string flowNo, int workID, string ywh)
        {
            var trigger = getTrigger(flowNo);
            if (trigger != null)
            {
                trigger.OnSaveAsDraft(workID, ywh);
            }
        }

        /// <summary>
        /// 获取流程触发器
        /// </summary>
        /// <param name="bwlxId">办文案ID</param>
        /// <returns>触发器</returns>
        private static ITrigger getTrigger(string flowNo)
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

                foreach (var type in types)
                {
                    var attr = type.GetCustomAttributes(typeof(FlowNo), false).FirstOrDefault();
                    if (attr != null && (attr as FlowNo).IDs.Contains(flowNo))
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
    }
}