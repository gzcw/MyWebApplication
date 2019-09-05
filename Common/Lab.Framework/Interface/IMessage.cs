using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Framework
{
    public interface IMessage
    {
        /// <summary>
        /// 提醒消息接口
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="departmentName">部门名称</param>
        /// <returns></returns>
        List<Message> GetMessage(string userName, string departmentName);
    }
}
