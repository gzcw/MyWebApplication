using WebApplication5.Areas.Authorize.Models;
using Lab.Framework;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    /// <summary>
    /// 权限控制器
    /// </summary>
    public class AuthorizationController : BaseController
    {
        /// <summary>
        /// 获取系统菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSystemMenu()
        {
            var query = NH.Session.CreateSQLQuery(string.Format("SELECT * FROM V_AUTH_USERAUTHORIZATION T WHERE T.USERNAME='{0}' AND T.RTYPE=0 ORDER BY T.SORTNUMBER", User.Identity.Name));
            var data = query.ToDynamicList();
            var parentList = data.Where(x => x.ParentID == null||x.ParentID=="").ToList();

            var result = new List<dynamic>();
            foreach (var parent in parentList)
            {
                var item = parent;
                parent.children = GetChildren(parent.ID, data);
            }
            return Json(parentList, JsonRequestBehavior.AllowGet);
        }
        private List<dynamic> GetChildren(string parentId, IList<dynamic> data)
        {
            var result = data.Where(x => x.ParentID == parentId.ToString()).ToList();
            if (result.Count == 0)
            {
                return new List<dynamic>();
            }
            foreach (var item in result)
            {
                item.ParentID = "";
                item.iconCls = item.Icon;
                item.text = item.Name;
                item.children = GetChildren(item.ID, data);
            }
            return result;
        }
        public ActionResult Buttons()
        {
            var type = Request.QueryString["type"];
            if (type == "select")
            {
                ViewBag.buttons = new List<Auth_Authorization>() {
                new Auth_Authorization{Name="选择",Icon="icon-ok",Method="select"},
                new Auth_Authorization{Name="刷新",Icon="icon-reload",Method="refresh"}
                };
            }
            else
            {
                var url = Request.Url.AbsolutePath;
                if (Request.ApplicationPath != "/")
                {
                    url = url.Replace(Request.ApplicationPath, "");
                }
                var sql = string.Format("SELECT DISTINCT T.* FROM V_AUTH_USERAUTHORIZATION T WHERE T.RTYPE=2 AND T.USERNAME='{0}' AND T.PARENTID IN (SELECT R.ID FROM AUTH_AUTHORIZATION R WHERE R.URL='{1}') AND T.ISVALID=1 ORDER BY T.SORTNUMBER", User.Identity.Name, url);

                var data = NH.Session.CreateSQLQuery(sql).ToDynamicList();

                ViewBag.buttons = data;
            }

            return View();
        }
    }
}