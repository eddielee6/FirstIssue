using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using StructureMap;
using FirstIssue.WebApp.AppCode.StructureMap;

namespace FirstIssue.WebApp
{
    public class StructureMapConfig
    {
        public static void ConfigureStructureMap()
        {
            var container = CreateStructureMapContainer();
            var smDependencyResolver = new StructureMapDependencyResolver(container);
            DependencyResolver.SetResolver(smDependencyResolver);
        }

        private static Container CreateStructureMapContainer()
        {
            // var resetPasswordEmailTemplate = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.App_GlobalResources.resetPasswordEmailTemplate.txt");
            // var activeAccountEmailTemplate = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.App_GlobalResources.activeAccountEmailTemplate.txt");

            var resetPasswordEmailTemplate = "";
            var activeAccountEmailTemplate = "";

            var postmarkApiKey = WebConfigurationManager.AppSettings["postmarkApiKey"];

            var container = new Container(x =>
            {
                x.AddRegistry(new StructureMapRegistry(postmarkApiKey, resetPasswordEmailTemplate, activeAccountEmailTemplate));
            });

            return container;
        }        
    }
}