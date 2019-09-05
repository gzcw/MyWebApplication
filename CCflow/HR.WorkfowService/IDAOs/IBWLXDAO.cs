using HR.WorkflowService.Models;
using PTXT;
using System.Collections.Generic;

namespace HR.WorkflowService.IDAOs
{
    /// <summary>
    /// 办文类型数据访问接口
    /// </summary>
    public interface IBWLXDAO : IDAO<string, BWLX>
    {
        #region IBWLXDAO接口自定义的数据访问契约

        /// <summary>
        ///根据流程ID查找 
        /// </summary>
        /// <param name="LCID">流程ID</param>
        /// <returns>办文类型</returns>
        BWLX FindByLCID(string LCID);

        #endregion
    }
}
