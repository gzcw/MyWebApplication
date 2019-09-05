using HR.WorkflowService.Models;
using PTXT;
using System.Collections.Generic;

namespace HR.WorkflowService.IDAOs
{
    /// <summary>
    /// 办文案数据访问接口
    /// </summary>
    public interface IBWADAO : IDAO<string, BWA>
    {
        #region IBWADAO接口自定义的数据访问契约

        /// <summary>
        /// 根据ids获取办文案记录
        /// </summary>
        /// <param name="IdList">标识集合</param>
        /// <returns>办文案列表</returns>
        IList<BWA> FindByIds(List<string> IdList);

        #endregion
    }
}
