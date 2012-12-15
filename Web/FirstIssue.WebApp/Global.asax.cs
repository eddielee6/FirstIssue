using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FirstIssue.WebApp.Models;
using FirstIssue.WebApp.Models.Azure;
using WebMatrix.WebData;

namespace FirstIssue.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HttpFilterConfig.RegisterHttpGlobalFilters(GlobalConfiguration.Configuration.Filters);
            AuthConfig.RegisterAuth();
            StructureMapConfig.ConfigureStructureMap();

            FirstIssueConfig.Initialize();
        }
    }
}