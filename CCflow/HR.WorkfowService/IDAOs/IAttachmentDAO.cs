using HR.WorkflowService.Models;
using PTXT;
using System.Collections.Generic;

namespace HR.WorkflowService.IDAOs
{
    /// <summary>
    /// 附件数据访问接口
    /// </summary>
    public interface IAttachmentDAO : IDAO<string, Attachment>
    {
        #region IAttachmentDAO接口自定义的数据访问契约

        /// <summary>
        /// 更新记录ID
        /// </summary>
        /// <param name="entities">附件实体列表</param>
        /// <param name="recordId">记录ID</param>
        void UpdateRecordID(IList<Attachment> entities, string recordId);

        /// <summary>
        /// 根据标识集合查找
        /// </summary>
        /// <param name="IdList">标识集合</param>
        /// <returns>附件列表</returns>
        IList<Attachment> FindByIds(IList<string> IdList);

        /// <summary>
        /// 根据记录ID查找
        /// </summary>
        /// <param name="RecordId">记录ID</param>
        /// <returns>附件列表</returns>
        IList<Attachment> FindByRecordId(string RecordId);

        #endregion

    }
}
