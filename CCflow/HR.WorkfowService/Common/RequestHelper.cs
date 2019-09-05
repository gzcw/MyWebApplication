using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 主要用于获取URL查询参数和POST参数的值
    /// </summary>
    public class RequestHelper
    {
        #region 获取 Request.QueryString值
        /// <summary>
        /// 获取指定名称的URL查询参数(针对string型的参数值)，若未找至则返回null。
        /// </summary>
        /// <param name="parameterName">查询参数名</param>
        /// <returns>查询参数值</returns>
        public static string GetQueryString(string parameterName)
        {
            if (null == HttpContext.Current.Request.QueryString[parameterName])
            {
                return null;
            }
            return HttpContext.Current.Request.QueryString[parameterName];
        }

        /// <summary>
        /// 获取指定名称的URL查询参数(针对string型的参数值)，若未找至则返回默认值。
        /// </summary>
        /// <param name="parameterName">查询参数名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>查询参数值</returns>
        public static string GetQueryString(string parameterName, string defaultValue)
        {
            if (null == HttpContext.Current.Request.QueryString[parameterName])
            {
                return defaultValue;
            }
            return HttpContext.Current.Request.QueryString[parameterName];
        }

        /// <summary>
        /// 获取指定名称的URL查询参数(针对int型的参数值)，若未找到则返回-1。
        /// </summary>
        /// <param name="parameterName">查询参数名</param>
        /// <returns>查询参数值</returns>
        public static int GetQueryInt(string parameterName)
        {
            return GetQueryInt(parameterName, -1);
        }
        /// <summary>
        /// 获取指定名称的URL查询参数，若未找到则返回指定的默认值(针对int型的参数值)
        /// </summary>
        /// <param name="parameterName">查询参数名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>查询参数值</returns>
        public static int GetQueryInt(string parameterName, int defaultValue)
        {
            if (null == HttpContext.Current.Request.QueryString[parameterName])
            {
                return defaultValue;
            }
            int result;
            if (int.TryParse(HttpContext.Current.Request.QueryString[parameterName], out result))
            {
                return result;
            }
            return defaultValue;
        }
        #endregion

        #region 获取POST参数值
        /// <summary>
        /// 获取指定名称的POST参数(针对string型的参数值)，若未找至则返回null。
        /// </summary>
        /// <param name="parameterName">POST参数名</param>
        /// <returns>POST参数值</returns>
        public static string GetFormString(string parameterName)
        {
            if (null == HttpContext.Current.Request.Form[parameterName])
            {
                return null;
            }
            return HttpContext.Current.Request.Form[parameterName];
        }
        /// <summary>
        /// 获取指定名称的POST参数(针对int型的参数值)，若未找到则返回-1。
        /// </summary>
        /// <param name="parameterName">POST参数名</param>
        /// <returns>POST参数值</returns>
        public static int GetFormInt(string parameterName)
        {
            return GetFormInt(parameterName, -1);
        }
        /// <summary>
        /// 获取指定名称的POST参数，若未找到则返回指定的默认值(针对int型的参数值)
        /// </summary>
        /// <param name="parameterName">POST参数名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>POST参数值</returns>
        public static int GetFormInt(string parameterName, int defaultValue)
        {
            if (null == HttpContext.Current.Request.Form[parameterName])
            {
                return defaultValue;
            }
            int result;
            if (int.TryParse(HttpContext.Current.Request.Form[parameterName], out result))
            {
                return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// 获取指定名称的POST参数(针对double型的参数值)，若未找到则返回0。
        /// </summary>
        /// <param name="parameterName">POST参数名</param>
        /// <returns>POST参数值</returns>
        public static double GetFormDouble(string parameterName)
        {
            return GetFormDouble(parameterName, 0);
        }
        /// <summary>
        /// 获取指定名称的POST参数，若未找到则返回指定的默认值(针对double型的参数值)
        /// </summary>
        /// <param name="parameterName">POST参数名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>POST参数值</returns>
        public static double GetFormDouble(string parameterName, double defaultValue)
        {
            if (null == HttpContext.Current.Request.Form[parameterName])
            {
                return defaultValue;
            }
            double result;
            if (double.TryParse(HttpContext.Current.Request.Form[parameterName], out result))
            {
                return result;
            }
            return defaultValue;
        }

        /// <summary>
        /// 获取指定名称的POST参数(针对decimal型的参数值)，若未找到则返回0。
        /// </summary>
        /// <param name="parameterName">POST参数名</param>
        /// <returns>POST参数值</returns>
        public static decimal GetFormDecimal(string parameterName)
        {
            return GetFormDecimal(parameterName, 0);
        }
        /// <summary>
        /// 获取指定名称的POST参数，若未找到则返回指定的默认值(针对decimal型的参数值)
        /// </summary>
        /// <param name="parameterName">POST参数名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>POST参数值</returns>
        public static decimal GetFormDecimal(string parameterName, decimal defaultValue)
        {
            if (null == HttpContext.Current.Request.Form[parameterName])
            {
                return defaultValue;
            }
            decimal result;
            if (decimal.TryParse(HttpContext.Current.Request.Form[parameterName], out result))
            {
                return result;
            }
            return defaultValue;
        }
        #endregion
    }
}
