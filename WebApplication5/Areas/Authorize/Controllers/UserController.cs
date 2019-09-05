using WebApplication5.Areas.Authorize.Models;
using Lab.CommonBussiness;
using Lab.Framework;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;


namespace WebApplication5.Areas.Authorize.Controllers
{
    /// <summary>
    /// 【用户】控制器
    /// </summary>
    public partial class UserController : StringEntityController<Auth_User>
    {
        #region 视图

        #endregion

        public override ActionResult SaveEntity()
        {
            try
            {
                var entity = GetUpdateModel();
                if (string.IsNullOrEmpty(entity.Password))
                {
                    entity.Password = MD5Helper.MD5Encrypt64("123456");
                }
                entity.SaveOrUpdate();
                return Json(new { success = true, entity = entity });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "保存失败！" + ex.Message, error = JsonConvert.SerializeObject(ex) });
            }
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult ResetPassword(string ID)
        {
            try
            {
                var entity = NH.Session.Get<Auth_User>(ID);
                entity.Password = MD5Helper.MD5Encrypt64("123456");
                entity.SaveOrUpdate();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "保存失败！" + ex.Message, error = JsonConvert.SerializeObject(ex) });
            }
        }
    }
}
