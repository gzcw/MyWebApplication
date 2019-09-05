using HR.WorkflowService.Models;
using PTXT;
using System.Collections.Generic;

namespace HR.WorkflowService.IDAOs
{
    /// <summary>
    /// 审批意见数据访问接口
    /// </summary>
    public interface IApproveOpinionDAO : IDAO<string, ApproveOpinion>
    {
        #region IApproveOpinionDAO接口自定义的数据访问契约

        /// <summary>
        /// 通过办文案ID查找
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <returns>审批意见列表</returns>
        IList<ApproveOpinion> FindByBWAID(int bwaId);

        #endregion
    }
}
