using WebApplication5.Areas.Workflow.Models;
using Lab.Framework;
using System.Linq;
using System.Web.Mvc;


namespace WebApplication5.Areas.Workflow.Controllers
{
    /// <summary>
    /// 【流程条件】控制器
    /// </summary>
    public partial class CondController : StringEntityController<WF_Cond>
    {
        #region 视图

        #endregion

        public ActionResult LoadMyForm(string FK_Flow, int NodeID, int ToNodeID)
        {
            var entity = NH.GetSession<WF_Cond>().QueryOver<WF_Cond>().Where(x => x.NodeID == NodeID && x.ToNodeID == ToNodeID).List().FirstOrDefault();
            if (entity == null)
            {
                entity = new WF_Cond()
                {
                    FK_Flow = FK_Flow,
                    NodeID = NodeID,
                    ToNodeID = ToNodeID,
                    CondType = (int)BP.WF.Template.CondType.Dir,
                    DataFrom = (int)BP.WF.Template.ConnDataFrom.Paras,
                    FK_Operator = "=",
                    ConnJudgeWay= 0,
                    PRI = 0,
                    CondOrAnd = 0
                };
            }
            return Json_Get(entity);
        }
    }
}
