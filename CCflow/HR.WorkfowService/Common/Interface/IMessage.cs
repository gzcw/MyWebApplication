using HR.WorkflowService.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.WorkflowService.Common.Interface
{
    /// <summary>
    /// 提醒接口
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// 获取提醒信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>消息列表</returns>
        List<Message> GetMessage(string username);
    }
}