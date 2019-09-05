using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.WorkflowService.Common.Interface
{
    /// <summary>
    /// 触发器接口
    /// </summary>
    public interface ITrigger
    {
        /// <summary>
        /// 流程完成触发器
        /// </summary>
        /// <param name="FLOWNO"></param>
        /// <param name="WORKID"></param>
        /// <param name="YWH"></param>
        /// <param name="NODEID"></param>
        void OnCompleted(string FLOWNO, int WORKID, string YWH, int NODEID);

        /// <summary>
        /// 发送前触发器
        /// </summary>
        /// <param name="FLOWNO"></param>
        /// <param name="WORKID"></param>
        /// <param name="YWH"></param>
        /// <param name="NODEID"></param>
        void OnBeforeSend(string FLOWNO, int WORKID, string YWH, int NODEID);



        /// <summary>
        /// 发送触发器
        /// </summary>
        /// <param name="FLOWNO"></param>
        /// <param name="WORKID"></param>
        /// <param name="YWH"></param>
        /// <param name="NODEID"></param>
        void OnSend(string FLOWNO, int WORKID, string YWH, int NODEID);

        /// <summary>
        /// 作废触发器
        /// </summary>
        /// <param name="FLOWNO"></param>
        /// <param name="WORKID"></param>
        /// <param name="YWH"></param>
        /// <param name="NODEID"></param>
        void OnTuiJian(string FLOWNO, int WORKID, string YWH, int NODEID);

        /// <summary>
        /// 返回触发器
        /// </summary>
        /// <param name="FLOWNO"></param>
        /// <param name="WORKID"></param>
        /// <param name="YWH"></param>
        /// <param name="NODEID"></param>
        /// <param name="TONODEID"></param>
        void OnReturn(string FLOWNO, int WORKID, string YWH, int NODEID,int TONODEID);

        /// <summary>
        /// 保存为草稿触发器
        /// </summary>
        /// <param name="workID">工作标识</param>
        /// <param name="ywh">业务号</param>
        void OnSaveAsDraft(int workID, string ywh);
    }
}