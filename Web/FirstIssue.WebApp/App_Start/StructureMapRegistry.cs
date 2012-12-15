using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using StructureMap.Configuration.DSL;

using FirstIssue.WebApp.AppCode.EmailService;
using FirstIssue.WebApp.AppCode.StructureMap;


namespace FirstIssue.WebApp
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry(string postmarkApiKey, string resetEmailTemplate, string activateAccountTemplate)
        {
            For<IEmailService>().Use<PostmarkEmailService>().
                Ctor<string>("apiKey").Is(postmarkApiKey);

            For<IFilterProvider>().Use<StructureMapFilterProvider>();

            //ForConcreteType<AccountController>().Configure.
            //    Ctor<string>("resetPasswordEmailTemplate").Is(resetEmailTemplate).
            //    Ctor<string>("activateAccountTemplate").Is(activateAccountTemplate);

            ScanForDefaults();
        }

        private void ScanForDefaults()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.LookForRegistries();
                scanner.Assembly(GetType().Assembly);
                scanner.WithDefaultConventions();
            });
        }
    }
}