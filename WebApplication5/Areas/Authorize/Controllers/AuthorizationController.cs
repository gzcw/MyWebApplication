using WebApplication5.Areas.Authorize.Models;
using Lab.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.RegularExpressions;
using System.Web.Mvc;


namespace WebApplication5.Areas.Authorize.Controllers
{
    /// <summary>
    /// 【资源】控制器
    /// </summary>
    public partial class AuthorizationController : StringEntityController<Auth_Authorization>
    {
        #region 视图

        #endregion



        /// <summary>
        /// 获取图标
        /// </summary>
        /// <returns></returns>
        public ActionResult GetIcons()
        {
            try
            {
                var text = System.IO.File.ReadAllText(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"Content\CSS\custom-icon.css");
                var matches = Regex.Matches(text, @"\..*?{");
                var result = new List<dynamic>();
                foreach (Match item in matches)
                {
                    var classname = item.Value.TrimStart('.').TrimEnd('{').Trim();
                    dynamic icon = new ExpandoObject();
                    icon.id = classname;
                    icon.value = classname;
                    icon.text = classname;
                    icon.iconCls = classname;
                    result.Add(icon);
                }
                var str = "icon-add,icon-edit,icon-remove,icon-reload,icon-clear,icon-ok,icon-cancel,icon-search,icon-print,icon-cut,icon-back";
                foreach (var classname in str.Split(','))
                {
                    dynamic icon = new ExpandoObject();
                    icon.id = classname;
                    icon.value = classname;
                    icon.text = classname;
                    icon.iconCls = classname;
                    result.Add(icon);
                }
                return Json_Get(result);
            }
            catch (Exception ex)
            {
                return Json_Get(new List<string>());
            }
        }

        /// <summary>
        /// 复制实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult CopyEntity(string ID)
        {
            var entity = NH.Session.Get<Auth_Authorization>(ID);
            if (entity == null)
            {
                throw new Exception("记录不存在,请刷新页面！");
            }
            var result = entity.Clone() as Auth_Authorization;
            result.ID = null;
            result.Name += "-复制";
            result.Auth_Rlt_RoleAuthorization_LIST = null;
            result.Save();
            return Json(new { success = true, entity = entity });
        }
    }
}
