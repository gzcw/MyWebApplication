using System.IO;
using System.Web.Optimization;

namespace WebApplication5
{
    /// <summary>
    /// 页面资源打包配置
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// 应用程序开始时执行的配置
        /// </summary>
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                        "~/Scripts/underscore.js",
                        "~/Data/sys_data.js",
                        "~/Scripts/commonhelper.js",
                        "~/Scripts/Application.EasyUI.Extension.js",
                        "~/Scripts/Application.EasyUI.Component.js",
                        "~/Scripts/permission.js")
                        );

            bundles.Add(new StyleBundle("~/Content/CSS/mycss").Include(
                "~/Content/CSS/custom-icon.css",
                "~/Content/CSS/base.css",
                "~/Content/CSS/main.css")
                );
        }
    }
}