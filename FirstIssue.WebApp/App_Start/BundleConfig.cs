using System.Web;
using System.Web.Optimization;

namespace FirstIssue.WebApp
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS bundles
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Styles/normalize.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Styles/main.css"));


            // Enable bundling
            BundleTable.EnableOptimizations = true;
        }
    }
}