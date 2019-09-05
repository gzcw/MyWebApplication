using HR.WorkflowService.IDAOs;
using HR.WorkflowService.Models;
using PTXT;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.WorkflowService.DAOs
{
    /// <summary>
    /// BWLXBWCLRLT实体类自定义的数据访问类(继承BaseDAO),自定义的数据访问方法请在此实现。
    /// </summary>
    public class BWLXBWCLRLTDAO : BaseDAO<string, BWLXBWCLRLT>, IBWLXBWCLRLTDAO
    {
        #region 字段

        #endregion

        #region 属性

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BWLXBWCLRLTDAO() { }
        #endregion

        #region 对IBWLXBWCLRLTDAO接口契约的实现和对BaseDAO的重写
        /// <summary>
        /// 根据办文类型标识查找
        /// </summary>
        /// <param name="bwlxId">办文类型标识</param>
        /// <returns>办文类型与办文材料列表</returns>
        public IList<BWLXBWCLRLT> FindByBWLXID(string bwlxId)
        {
            return this.FindByHQL(string.Format("FROM BWLXBWCLRLT WHERE BWLXID='{0}'", bwlxId));
        }

        #endregion

        #region BWLXBWCLRLTDAO数据访问类自定义的方法

        #endregion

    }
}
