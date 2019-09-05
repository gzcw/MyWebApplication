using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using Lab.Framework;
using System.Web.Security;

namespace WebApplication5
{
    public class AuthorizeFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //if (httpContext.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(ApplicationUser.Current.RealName))
            //{
            //    var test = ApplicationUser.Current.Name;
            //    return base.AuthorizeCore(httpContext);
            //}
            var result = base.AuthorizeCore(httpContext);
            if (result == false)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            return result;
            //throw new DomainException("请重新登录！");
        }
    }
}