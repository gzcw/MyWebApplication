using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Linq;
using System.Web.Security;

namespace Lab.Framework
{
    /// <summary>
    /// 用户
    /// </summary>
    public class ApplicationUser : IIdentity
    {
        public ApplicationUser(string realName, string departmentName)
        {
            this._RealName = realName;
            this._DepartmentName = departmentName;

        }

        public string AuthenticationType
        {
            get
            {
                return HttpContext.Current.User.Identity.AuthenticationType;
            }
        }

        public bool IsAuthenticated
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        public string Name
        {
            get
            {
                return HttpContext.Current.User.Identity.Name;
            }
        }

        private string _RealName;

        public string RealName
        {
            get { return _RealName; }
        }


        private string _DepartmentName;

        public string DepartmentName
        {
            get { return _DepartmentName; }
        }

        public static ApplicationUser Current
        {
            get
            {
                //return new ApplicationUser("", "");
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return new ApplicationUser("", "");
                }
                if (UserDictionary != null && UserDictionary.ContainsKey(HttpContext.Current.User.Identity.Name))
                {
                    return UserDictionary[HttpContext.Current.User.Identity.Name];
                }
                //var user = NH.Session.CreateSQLQuery(string.Format("SELECT T.REALNAME,D.NAME AS DEPARTMENTNAME FROM AUTH_USER T LEFT JOIN AUTH_DEPARTMENT D ON D.ID=T.DEPARTMENTID WHERE T.NAME='{0}'", HttpContext.Current.User.Identity.Name)).ToDynamicList().FirstOrDefault();
                //if (user == null) {
                    FormsAuthentication.SignOut();
                //}
                //InitLoginInfo(HttpContext.Current.User.Identity.Name, user.REALNAME, user.DEPARTMENTNAME);
                return new ApplicationUser("", "");
            }
        }
        public static Dictionary<string, ApplicationUser> UserDictionary
        {
            get;
            set;
        }

        /// <summary>
        /// 初始化登陆用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="realName"></param>
        /// <param name="departmentName"></param>
        public static void InitLoginInfo(string userName, string realName, string departmentName)
        {
            if (UserDictionary == null)
            {
                UserDictionary = new Dictionary<string, ApplicationUser>();
            }
            UserDictionary[userName] = new ApplicationUser(realName, departmentName);
            HttpContext.Current.Session["ApplicationUser"] = new Dictionary<string, object>()
            {
                {"UserName",userName},{"RealName",realName},{"DepartmentName",departmentName}
            };
        }
    }
}