using HR.WorkflowService.Models;
using PTXT;
using System.Collections.Generic;

namespace HR.WorkflowService.IDAOs
{
    /// <summary>
    /// 打印清单数据访问接口
    /// </summary>
    public interface IDYQDDAO : IDAO<string, DYQD>
    {
        #region IDYQDDAO接口自定义的数据访问契约

        /// <summary>
        /// 根据节点ID查找打印清单
        /// </summary>
        /// <param name="nodeId">节点ID</param>
        /// <returns>打印清单列表</returns>
        IList<DYQD> FindByNodeId(string nodeId);

        #endregion
    }
}
