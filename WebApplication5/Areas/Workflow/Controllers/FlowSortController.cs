using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;
using System.Web.Mvc;


namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 【流程类别】控制器
    /// </summary>
    public partial class FlowSortController : StringEntityController<WF_FlowSort>
    {
        #region 视图

        #endregion

        /// <summary>
        /// 获取树结构数据
        /// </summary>
        /// <param name="filterStr">过滤条件</param>
        /// <param name="orders">排序</param>
        /// <returns>流程树结构列表</returns>
        public ActionResult GetTreeData(string filterStr = "[]", string orders = "")
        {
            var result = QueryService.GetTreeData("SELECT T.* FROM V_WF_FLOWTREE T", "ParentNo", "No");
            if (result.Count == 0)
            {
                var entity = new WF_FlowSort()
                {
                    Name = "流程类别1"
                };
                entity.SaveOrUpdate();
            }
            result = QueryService.GetTreeData("SELECT T.* FROM V_WF_FLOWTREE T", "ParentNo", "No");
            return Json_Get(result);
        }
    }
}
