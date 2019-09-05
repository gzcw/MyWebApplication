using HR.BasicFramework.DataAccess;
using HR.WorkflowService.Common;
using HR.WorkflowService.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.WorkflowService.Service
{
    /// <summary>
    /// 编号服务
    /// </summary>
    public class BHService
    {
        /// <summary>
        /// 获取编号
        /// </summary>
        /// <param name="bhId">编号ID</param>
        /// <param name="workflowName">流程名称</param>
        /// <param name="userName">用户名</param>
        /// <param name="region">区域</param>
        /// <param name="xzqhbm">行政区划编码</param>
        /// <returns>编号</returns>
        public static string CreateCode(string bhId, string workflowName = "", string userName = "", string region = "", string xzqhbm = "")
        {
            var result = string.Empty;
            using (var trans = DataContextNH.BeginTransaction<BH>())
            {
                try
                {
                    var bhEntity = SessionManager.GetSession<BH>().Get<BH>(bhId);
                    SessionManager.GetSession<BH>().Refresh(bhEntity, LockMode.Upgrade);
                    result = bhEntity.CreateCode(workflowName, userName, region, xzqhbm);
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw new DomainException("获取编号失败！");
                }
            }
            return result;
        }
    }
}
