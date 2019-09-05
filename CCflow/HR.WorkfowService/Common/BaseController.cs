using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;
using HR.WorkflowService.Models;
using HR.BasicFramework.DataAccess;

namespace HR.WorkflowService.Common
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        //protected Logger log = new Logger();

        /// <summary>
        /// 当前用户
        /// </summary>
        private User currentUser;

        /// <summary>
        /// 当前系统ID编码(在应用程序的设置文件(Setting.settings)中配置)
        /// </summary>
        public string CurrentSystemID
        {
            get
            {
                return ConfigurationManager.AppSettings["USystemCode"].ToString();
            }
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public User CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    //var realName = User.Identity.Name;
                    //if (Request.Cookies["CCS"] != null && Request.Cookies["CCS"]["Name"] != null)
                    //{
                    //    realName = HttpUtility.UrlDecode(Request.Cookies["CCS"]["Name"].ToString());
                    //}
                    var departmentId = DataContextNH.GetBySQL<BWA, string>(string.Format("SELECT FK_DEPT FROM PORT_EMPDEPT T WHERE T.FK_EMP='{0}'", User.Identity.Name)).FirstOrDefault();
                    var realName = DataContextNH.GetBySQL<BWA, string>(string.Format("SELECT NAME FROM PORT_EMP T WHERE T.NO='{0}'", User.Identity.Name)).FirstOrDefault();

                    return new User()
                    {
                        UserName = User.Identity.Name,
                        RealName = realName,
                        DepartmentID = departmentId,
                        Region = new Region()
                        {
                            Code = "442000102",
                            Name = "民众镇"
                        },
                        RegionCode = "442000102",
                        OfficePhone = "020-5611632"
                    };
                }
                if (Session["CurrentUser"] == null)
                {
                    return null;
                }
                var user = Session["CurrentUser"] as BP.Port.Emp;
                //TODO:登陆时用户赋值
                return new User()
                {
                    UserName = user.No,
                    RealName = user.Name,
                    Region = new Region()
                    {
                        Code = "442000102",
                        Name = ""
                    },
                    RegionCode = "442000102",
                    OfficePhone = "020-5611632"
                };
                if (currentUser == null)
                {
                    string message;
                    //IUSystemUserDAO systemUserDAO = new USystemUserDAO();
                    //currentUser = systemUserDAO.GetUser(ConfigurationManager.AppSettings["USystemCode"].ToString(), User.Identity.Name, out message);
                }
                return currentUser;
            }
        }

        /// <summary>
        /// 客户端IP地址(若在服务端则为"::1")
        /// </summary>
        public string UserIP
        {
            get
            {
                return Request.UserHostAddress;
            }
        }

        /// <summary>
        /// 获取NameValueCollection型的当前应用程序的自定义配置信息，对应Web.config中的appSettings节。
        /// </summary>
        public NameValueCollection AppSettings
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings;
            }
        }

        /// <summary>
        /// 返回Post请求
        /// </summary>
        /// <param name="obj">返回的实体</param>
        /// <returns>序列化对象</returns>
        public JsonResult Json_Post(object obj)
        {
            return Json(obj, "text/html");
        }

        /// <summary>
        /// 返回Get请求
        /// </summary>
        /// <param name="obj">返回的实体</param>
        /// <returns>序列化对象</returns>
        public JsonResult Json_Get(object obj)
        {
            return Json(obj, JsonRequestBehavior.AllowGet);
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

        /// <summary>
        /// 执行Action前过滤器
        /// </summary>
        /// <param name="filterContext">执行内容</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
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

            //排序
            if (this.ValueProvider.GetValue("sort") != null && this.ValueProvider.GetValue("order") != null)
            {
                var sort = this.ValueProvider.GetValue("sort").AttemptedValue;
                var order = this.ValueProvider.GetValue("order").AttemptedValue;
                if (!string.IsNullOrWhiteSpace(sort) && !string.IsNullOrWhiteSpace(order))
                {
                    try
                    {
                        var sortList = sort.Split(',');
                        var directionList = order.Split(',');

                        if (sortList.Length == directionList.Length)
                        {
                            var newSortList = new List<string>();
                            for (var i = 0; i < sortList.Length; i++)
                            {
                                newSortList.Add(string.Format("{0} {1}", sortList[i], directionList[i]));
                            }
                            newDic["orders"] = string.Join(",", newSortList.Where(x => !string.IsNullOrWhiteSpace(x)));
                        }
                    }
                    catch
                    {
                    }
                }
            }

            foreach (var item in newDic)
            {
                filterContext.ActionParameters[item.Key] = item.Value;
            }

            ViewBag.WorkflowPath = "Areas/Workflow/";
            if (ConfigurationManager.AppSettings.AllKeys.Contains("WorkflowPath"))
            {
                ViewBag.WorkflowPath = ConfigurationManager.AppSettings["WorkflowPath"];
            }

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="filterContext">错误消息实体</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is DomainException)
            {
                filterContext.Result = Json_Get(
                    new
                    {
                        success = false,
                        msg = filterContext.Exception.Message,
                        message = filterContext.Exception.Message
                    });
                filterContext.Exception = null;
                filterContext.ExceptionHandled = true;
            }
            Exception ex = filterContext.Exception;
            //log.Error(ex.Message, ex);

            base.OnException(filterContext);
        }

        #region 私有方法
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