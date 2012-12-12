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

            // These dont belong here but not sure where should go ?  
            SetupDatabase();
            SetupBlobStorage();
        }

        private static void SetupDatabase()
        {
            // Cant use this initializer in production - got to be migrations            
            Database.SetInitializer(new FirstIssueInitializer());
            var context = new FirstIssueContext();
            context.Database.CreateIfNotExists();
            context.Database.Initialize(false);
        }

        private static void SetupBlobStorage()
        {
            var storageAccount = CloudStorageAccountFactory.CreateCloudStorageAccount();
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(MagazineCoverContext.MagazineCoverContainer);
            container.CreateIfNotExists();            
        }
    }
}