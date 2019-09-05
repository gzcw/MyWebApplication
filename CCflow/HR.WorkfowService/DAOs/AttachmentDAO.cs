using HR.WorkflowService.IDAOs;
using HR.WorkflowService.Models;
using PTXT;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.WorkflowService.DAOs
{
    /// <summary>
    /// Attachment实体对象(模型)自定义的数据访问类,自定义的数据访问方法请在此实现。
    /// </summary>
    public class AttachmentDAO : BaseDAO<string, Attachment>, IAttachmentDAO
    {
        #region 字段

        #endregion

        #region 属性

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public AttachmentDAO() { }
        #endregion

        #region 对IAttachmentDAO接口契约的实现和对BaseDAO的重写

        #endregion

        #region AttachmentDAO数据访问类自定义的方法

        #endregion

        /// <summary>
        /// 更新业务记录ID
        /// </summary>
        /// <param name="entities">附件对象集</param>
        /// <param name="recordId">记录标识</param>
        public void UpdateRecordID(IList<Attachment> entities, string recordId)
        {
            try
            {
                var result = new List<Attachment>();
                foreach (var entity in entities)
                {
                    entity.Record_id = recordId;
                }
                this.BatchUpdate(entities);
            }
            catch
            {
                throw new Exception("更新业务记录ID失败");
            }
        }

        /// <summary>
        /// 获取附件记录集
        /// </summary>
        /// <param name="IdList">标识集</param>
        /// <returns>附件列表</returns>
        public IList<Attachment> FindByIds(IList<string> IdList)
        {
            try
            {
                var result = new List<Attachment>();
                foreach (var id in IdList)
                {
                    result.Add(this.FindById(id));
                }
                return result;
            }
            catch
            {
                throw new Exception("提供的IdList参数不正确");
            }
        }

        /// <summary>
        /// 根据记录标识查找
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>附件列表</returns>
        public IList<Attachment> FindByRecordId(string Id)
        {
            try
            {
                return FindByHQL(string.Format("FROM Attachment WHERE Record_Id='{0}'", Id));
            }
            catch
            {
                throw new Exception("执行FindByRecordId失败");
            }
        }
    }
}
