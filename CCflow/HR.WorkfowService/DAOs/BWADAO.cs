using HR.WorkflowService.IDAOs;
using HR.WorkflowService.Models;
using PTXT;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.WorkflowService.DAOs
{
    /// <summary>
    /// BWA实体类自定义的数据访问类(继承BaseDAO),自定义的数据访问方法请在此实现。
    /// </summary>
    public class BWADAO : BaseDAO<string, BWA>, IBWADAO
    {
        #region 字段

        #endregion

        #region 属性

        #endregion

        #region 构造方法
        /// <summary>
        /// 构造方法
        /// </summary>
        public BWADAO() { }
        #endregion

        #region 对IBWADAO接口契约的实现和对BaseDAO的重写

        /// <summary>
        /// 根据ids获取办文案记录
        /// </summary>
        /// <param name="IdList">标识列表</param>
        /// <returns>办文案列表</returns>
        public IList<BWA> FindByIds(List<string> IdList)
        {
            try
            {
                var result = new List<BWA>();
                foreach (var id in IdList)
                {
                    var entity = this.FindById(id);
                    if (entity != null)
                    {
                        result.Add(entity);
                    }
                }
                return result;
            }
            catch
            {
                throw new Exception("提供的IdList参数不正确");
            }
        }

        #endregion

        #region BWADAO数据访问类自定义的方法

        #endregion
    }
}
