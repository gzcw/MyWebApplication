using HR.WorkflowService.IDAOs;
using HR.WorkflowService.Models;
using PTXT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HR.WorkflowService.DAOs
{
    /// <summary>
    /// BWLX实体类自定义的数据访问类(继承BaseDAO),自定义的数据访问方法请在此实现。
    /// </summary>
    public class BWLXDAO : BaseDAO<string, BWLX>, IBWLXDAO
    {
        #region 字段

        #endregion

        #region 属性

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BWLXDAO() { }
        #endregion

        #region 对IBWLXDAO接口契约的实现和对BaseDAO的重写
        /// <summary>
        /// 根据流程标识查找
        /// </summary>
        /// <param name="LCID">流程标识</param>
        /// <returns>办文类型</returns>
        public BWLX FindByLCID(string LCID)
        {
            var bwlx = this.FindByHQL(string.Format("FROM BWLX WHERE LCID='{0}' AND ISDELETE=0", LCID)).FirstOrDefault();
            return bwlx;
        }
        #endregion

        #region BWLXDAO数据访问类自定义的方法

        #endregion


    }
}
