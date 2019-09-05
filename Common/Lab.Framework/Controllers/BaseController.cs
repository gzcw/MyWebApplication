using Newtonsoft.Json;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Lab.Framework
{
    public class BaseController : Controller
    {

        /// <summary>
        /// 日志记录器
        /// </summary>
        public Logger Logger { get { return LogManager.GetCurrentClassLogger(); ; } }
        public BaseController() { }

        #region 属性

        public string UserName
        {
            get
            {
                return this.User.Identity.Name;
            }
        }

        #endregion

        #region 全局事件
        /// <summary>
        /// Action开始执行触发器
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sort = filterContext.RequestContext.HttpContext.Request.Params["sort"];
            var order = filterContext.RequestContext.HttpContext.Request.Params["order"];

            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrEmpty(order))
            {
                if (!filterContext.ActionParameters.ContainsKey("orders"))
                {
                    filterContext.ActionParameters.Add("orders", "");
                }
                var orders = filterContext.ActionParameters["orders"].ToString();

                var sortList = sort.Split(',');
                var orderList = order.Split(',');

                var result = "";
                for (var i = 0; i < sortList.Count(); i++)
                {
                    result += string.Format(",{0} {1}", sortList[i], orderList[i]);
                }
                filterContext.ActionParameters["orders"] = string.IsNullOrEmpty(orders) ? result.TrimStart(',') : orders + result;
            }

            var newDic = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> item in filterContext.ActionParameters)
            {
                if (item.Value is ICollection)
                {
                    try
                    {
                        var result = JsonConvert.DeserializeObject(Request.Params[item.Key], item.Value.GetType());
                        newDic.Add(item.Key, result);
                        ModelState[item.Key].Errors.Clear();
                    }
                    catch
                    {
                        newDic.Add(item.Key, item.Value);
                    }
                }
            }
            foreach (var item in newDic)
            {
                filterContext.ActionParameters[item.Key] = item.Value;
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Action执行完成触发器
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// Action执行异常时的处理
        /// </summary>
        /// <param name="filterContext">异常上下文</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            //Logger.Error(UpdateModelError);
            Logger.Error(filterContext.Exception);

            var exception = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            filterContext.Result = new JsonResult()
            {
                Data = new { success = false, Message = exception.Message, msg = exception.Message },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        /// <summary>
        /// 重写Controller的序列化方法
        /// </summary>
        /// <param name="data">实例化对象</param>
        /// <param name="contentType">对象类型</param>
        /// <param name="contentEncoding">内容编码</param>
        /// <param name="behavior">请求行为，是否请允许get请求</param>
        /// <returns>序列化对象</returns>
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            if (behavior == JsonRequestBehavior.DenyGet && string.Equals(this.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                return new JsonResult();
            }
            return new JsonNetResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding
            };
        }

        #endregion

        #region 公用方法

        public ActionResult Json_Get(object obj)
        {
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }

    /// <summary>
    /// 扩展JsonResult
    /// </summary>
    public class JsonNetResult : JsonResult
    {
        /// <summary>
        /// 序列化配置
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        public Formatting Formatting { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public JsonNetResult()
        {
            SerializerSettings = new JsonSerializerSettings();
        }

        /// <summary>
        /// 重写执行结果方法
        /// </summary>
        /// <param name="context">控制器内容</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                JsonTextWriter writer = new JsonTextWriter(response.Output)
                {
                    Formatting = Formatting,
                    DateFormatString = "yyyy-MM-dd HH:mm:ss.fffK"
                };
                JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(writer, Data); writer.Flush();
            }
        }

    }
}
