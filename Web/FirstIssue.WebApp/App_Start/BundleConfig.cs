using System.Web;
using System.Web.Optimization;

namespace FirstIssue.WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Libraries
            var libraryBundle = new ScriptBundle("~/Scripts/Libraries");
            libraryBundle.Include("~/Scripts/jquery-1.8.3.js");
            libraryBundle.Include("~/Scripts/modernizr-2.6.2.js");
            libraryBundle.Include("~/Scripts/bootstrap.js");
            libraryBundle.Include("~/Scripts/knockout-2.2.0.debug.js");
            libraryBundle.Include("~/Scripts/jquery.validate.js");
            libraryBundle.Include("~/Scripts/jquery.validate.unobtrusive.js");
            libraryBundle.Include("~/Scripts/jquery.unobtrusive-ajax.js");
            bundles.Add(libraryBundle);

            // CSS
            var cssBundle = new StyleBundle("~/Styles/CSS");
            cssBundle.Include("~/Content/Styles/bootstrap.css");
            cssBundle.Include("~/Content/Styles/bootstrap-responsive.css");
            cssBundle.Include("~/Content/Styles/main.css");
            bundles.Add(cssBundle);

            // Enable bundling
            BundleTable.EnableOptimizations = true;
        }
    }
}