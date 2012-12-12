using System.Web;
using System.Web.Optimization;

namespace FirstIssue.WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            var jqueryCdnPath = "http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js";

            bundles.Add(new ScriptBundle(Links.bundles.scripts.jquery, jqueryCdnPath) { CdnFallbackExpression = "window.jquery" }.
                Include("~/Scripts/jquery-{version}.js"));                        

            // Libraries
            var libraryBundle = new ScriptBundle(Links.bundles.scripts.common);            
            libraryBundle.Include("~/Scripts/modernizr-2.6.2.js");
            libraryBundle.Include("~/Scripts/bootstrap.js");
            libraryBundle.Include("~/Scripts/knockout-2.2.0.debug.js");
            libraryBundle.Include("~/Scripts/jquery.validate.js");
            libraryBundle.Include("~/Scripts/jquery.validate.unobtrusive.js");
            libraryBundle.Include("~/Scripts/jquery.unobtrusive-ajax.js");
            bundles.Add(libraryBundle);

            // CSS
            var cssBundle = new StyleBundle(Links.bundles.styles.common);
            cssBundle.Include("~/Content/Styles/bootstrap.css");
            cssBundle.Include("~/Content/Styles/bootstrap-responsive.css");
            cssBundle.Include("~/Content/Styles/main.css");
            bundles.Add(cssBundle);

            // Enable bundling
            BundleTable.EnableOptimizations = true;
        }
    }
}