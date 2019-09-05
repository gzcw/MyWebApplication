using BP.Port;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 公共服务类
    /// </summary>
    public class CommonService
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="userNo">用户名</param>
        /// <returns>登陆成功与否</returns>
        public static bool OnLogin(string userNo)
        {
            try
            {
                var emp = new Emp(userNo);
                HttpContext.Current.Session["CurrentUser"] = emp;
                HttpContext.Current.Session["CurrentUserName"] = userNo;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}