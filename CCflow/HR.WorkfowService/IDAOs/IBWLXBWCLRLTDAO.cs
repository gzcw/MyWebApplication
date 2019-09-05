using HR.WorkflowService.Models;
using PTXT;
using System.Collections.Generic;

namespace HR.WorkflowService.IDAOs
{
    /// <summary>
    /// 办文类型与办文材料数据访问接口
    /// </summary>
    public interface IBWLXBWCLRLTDAO : IDAO<string, BWLXBWCLRLT>
    {
        #region IBWLXBWCLRLTDAO接口自定义的数据访问契约

        /// <summary>
        /// 根据办文类型ID查找
        /// </summary>
        /// <param name="bwlxId">办文案ID</param>
        /// <returns>办文类型与办文材料关系列表</returns>
        IList<BWLXBWCLRLT> FindByBWLXID(string bwlxId);

        #endregion
    }
}
