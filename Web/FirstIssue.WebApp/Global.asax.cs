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
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            SetupDatabase();
            SetupBlobStorage();
        }

        private static void SetupDatabase()
        {
            Database.SetInitializer(new FirstIssueInitializer());
            var context = new FirstIssueContext();
            context.Database.CreateIfNotExists();
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