using HR.WorkflowService.Models;
using PTXT;
using System.Collections.Generic;

namespace HR.WorkflowService.IDAOs
{
    /// <summary>
    /// 办文材料数据访问接口
    /// </summary>
    public interface IBWCLDAO : IDAO<string, BWCL>
    {
        #region IBWCLDAO接口自定义的数据访问契约

        /// <summary>
        /// 根据名称查找
        /// </summary>
        /// <param name="name">材料名称</param>
        /// <returns>办文材料列表</returns>
        IList<BWCL> FindByName(string name);
        #endregion
    }
}
