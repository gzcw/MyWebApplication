using HR.WorkflowService.IDAOs;
using HR.WorkflowService.Models;
using PTXT;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.WorkflowService.DAOs
{
    /// <summary>
    /// BWCL实体类自定义的数据访问类(继承BaseDAO),自定义的数据访问方法请在此实现。
    /// </summary>
    public class BWCLDAO : BaseDAO<string, BWCL>, IBWCLDAO
    {
        #region 字段

        #endregion

        #region 属性

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BWCLDAO() { }
        #endregion

        #region 对IBWCLDAO接口契约的实现和对BaseDAO的重写

        #endregion

        #region BWCLDAO数据访问类自定义的方法

        #endregion

        /// <summary>
        /// 通过名称查找
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>办文材料列表</returns>
        public IList<BWCL> FindByName(string name)
        {
            return this.FindByHQL(string.Format("FROM BWCL WHERE CLMC='{0}'", name));
        }
    }
}
