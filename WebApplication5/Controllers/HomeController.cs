using Lab.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    /// <summary>
    /// 主页控制器
    /// </summary>
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (!ApplicationUser.Current.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Title = System.Configuration.ConfigurationManager.AppSettings["ProjectName"].ToString();
            ViewBag.RealName = ApplicationUser.Current.RealName;
            ViewBag.DepartmentName = ApplicationUser.Current.DepartmentName;

            return View();
        }

        public ActionResult _SystemMenu()
        {
            var result = new List<ExpandoObject>();

            var systemID = System.Configuration.ConfigurationManager.AppSettings["SystemID"].ToString();

            ViewBag.Menu = result;

            return PartialView();
        }

        /// <summary>
        /// 主页消息展示页
        /// </summary>
        /// <returns></returns>
        public ActionResult Message()
        {
            return View();
        }

        public ActionResult GetMSGData()
        {
            var messages = new List<Message>();
            var types = new List<Type>();
            try
            {
                types = GetType(typeof(IMessage)).ToList();
            }
            catch (Exception ex)
            {
                return Json_Get(ex);
            }
            foreach (var type in types)
            {
                try
                {
                    var entity = (IMessage)Activator.CreateInstance(type);
                    var message = entity.GetMessage(UserName, ApplicationUser.Current.DepartmentName);
                    if (message != null)
                    {
                        messages.AddRange(message);
                        //messages.AddRange(entity.GetMessage(CurrentUser.userName, CurrentUser.organizationName));
                    }
                }
                catch { }
            }
            return Json_Get(messages);
        }


        public static IEnumerable<Type> GetType(Type interfaceType)
        {
            var result = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in assemblies)
            {
                try
                {
                    result.AddRange(item.GetTypes().Where(t => t.GetInterfaces().Contains(interfaceType)));
                }
                catch
                {

                }
            }
            return result.ToArray();
        }
    }

}
