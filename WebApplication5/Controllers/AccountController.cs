using WebApplication5.Areas.Authorize.Models;
using Lab.CommonBussiness;
using Lab.Framework;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication5.Controllers
{
    /// <summary>
    /// 账户控制器
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string msg, string ReturnUrl)
        {
            ViewBag.msg = msg;
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.Title = System.Configuration.ConfigurationManager.AppSettings["ProjectName"].ToString();
            return View();
        }

        /// <summary>
        /// 处理登录请求
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isRememberMe"></param>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userName, string password, bool isRememberMe)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new Exception("请输入用户名或密码");
            }
            var user = new Auth_User();
            try
            {
                if (ValidateUser(userName, password, out user))
                {
                    FormsAuthentication.SetAuthCookie(userName, true);
                    ApplicationUser.InitLoginInfo(userName, user.RealName, user.Auth_Department.Name);
                    FormsAuthentication.RedirectFromLoginPage(userName, true);
                    return null;
                }
                return RedirectToAction("Login", "Account", new { msg = "登录失败"});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Account", new { msg = ex.Message });
            }
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="systemID"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ValidateUser(string userName, string password, out Auth_User loginUser)
        {
            try
            {
                var user = NH.Session.QueryOver<Auth_User>().Where(x => x.Name == userName && x.IsValid == true).List().FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("用户名不存在！");
                }
                if (user.Locked)
                {
                    throw new Exception("用户名已被锁定！");
                }
                var encrypt_password = MD5Helper.MD5Encrypt64(password);
                if (user.Password == encrypt_password)
                {
                    loginUser = user;
                    return true;
                }
                throw new Exception("密码有误！");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public ActionResult ModifyPassword(string oldPassword, string newPassword)
        {
            var encrypt_old_password = MD5Helper.MD5Encrypt64(oldPassword);
            var user = NH.Session.QueryOver<Auth_User>().Where(x => x.Name == ApplicationUser.Current.Name).List().FirstOrDefault();
            if (user == null)
            {
                throw new Exception("请重新登录！");
            }
            if (encrypt_old_password != user.Password)
            {
                throw new Exception("原密码有误，请查询输入！");
            }
            user.Password = MD5Helper.MD5Encrypt64(newPassword);
            user.Save();
            return Json(new { success = true });
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}