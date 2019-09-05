using HR.WorkflowService.IDAOs;
using HR.WorkflowService.Models;
using PTXT;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.WorkflowService.DAOs
{
    /// <summary>
    /// DYQD实体类自定义的数据访问类(继承BaseDAO),自定义的数据访问方法请在此实现。
    /// </summary>
    public class DYQDDAO : BaseDAO<string, DYQD>, IDYQDDAO
    {
        #region 字段

        #endregion

        #region 属性

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public DYQDDAO() { }
        #endregion

        #region 对IDYQDDAO接口契约的实现和对BaseDAO的重写
        /// <summary>
        /// 根据节点标识查找
        /// </summary>
        /// <param name="nodeId">节点标识</param>
        /// <returns>打印清单列表</returns>
        public IList<DYQD> FindByNodeId(string nodeId)
        {
            return this.FindByHQL(string.Format("FROM DYQD WHERE NODE_ID='{0}'", nodeId));
        }

        #endregion

        #region DYQDDAO数据访问类自定义的方法

        #endregion
    }
}