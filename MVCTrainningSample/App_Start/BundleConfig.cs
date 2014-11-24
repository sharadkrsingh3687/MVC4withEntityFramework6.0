using System.Web;
using System.Web.Optimization;

namespace MVCTrainningSample
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                                    "~/Scripts/bootstraps/bootstrap.js",
                                    "~/Scripts/plugins/dataTables/jquery.dataTables.js",
                                    "~/Scripts/plugins/dataTables/dataTables.bootstrap.js",
                                     "~/Scripts/Layout.js",
                                     "~/Scripts/Scripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/freelancer").Include(
                                    "~/Scripts/bootstraps/bootstrap.js",                                   
                                    "~/Scripts/plugins/dataTables/jquery.dataTables.js",
                                    "~/Scripts/plugins/dataTables/dataTables.bootstrap.js"));
                                   // "~/Scripts/freelancer.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include( 
                        "~/Content/plugins/dataTables/dataTables.bootstrap.css",
                        "~/Content/bootstraps/bootstrap.css",  
                        "~/Content/styles.css",
                        "~/Content/site.css",
                        "~/Content/Layout.css",
                        "~/font-awesome-4.1.0/css/font-awesome.css"));

            bundles.Add(new ScriptBundle("~/Content/freelancer").Include(
                                    "~/Content/plugins/dataTables/dataTables.bootstrap.css",
                                    "~/Content/bootstraps/bootstrap.css",  
                                    "~/Content/freelancer.css",
                                    "~/font-awesome-4.1.0/css/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}