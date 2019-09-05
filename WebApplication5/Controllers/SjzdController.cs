using WebApplication5.Models;
using Lab.Framework;
using System.Web.Mvc;


namespace WebApplication5.Controllers
{
    /// <summary>
    /// 【数据字典】控制器
    /// </summary>
    public partial class SjzdController : StringEntityController<SYS_SJZD>
    {
        #region 视图
        /// <summary>
        /// 根据字典编码获取数据集
        /// </summary>
        /// <param name="zdbm"></param>
        /// <returns></returns>
        public ActionResult GetDataByCode(string zdbm)
        {
            var data = NH.Session.QueryOver<SYS_SJZD>().Where(x => x.ZDBM == zdbm).List();
            return Json_Get(data);
        }

        #endregion
    }
}
