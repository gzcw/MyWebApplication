using HR.WorkflowService.IDAOs;
using HR.WorkflowService.Models;
using PTXT;
using System.Collections.Generic;

namespace HR.WorkflowService.DAOs
{
    /// <summary>
    /// ApproveOpinion实体对象(模型)自定义的数据访问类,自定义的数据访问方法请在此实现。
    /// </summary>
    public class ApproveOpinionDAO : BaseDAO<string, ApproveOpinion>, IApproveOpinionDAO
    {
        #region 属性

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public ApproveOpinionDAO() { }
        #endregion

        #region 对IApproveOpinionDAO接口契约的实现和对BaseDAO的重写

        /// <summary>
        /// 根据办文案ID查找
        /// </summary>
        /// <param name="bwaId">办文案ID</param>
        /// <returns>审批意见列表</returns>
        public IList<ApproveOpinion> FindByBWAID(int bwaId)
        {
            return FindByHQL(string.Format("FROM ApproveOpinion WHERE WORK_ID={0}", bwaId));
        }

        #endregion

        #region ApproveOpinionDAO数据访问类自定义的方法

        #endregion
    }
}
