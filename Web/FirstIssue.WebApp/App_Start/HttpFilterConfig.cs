using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using FirstIssue.WebApp.Controllers.WebApi.ActionFilters;

namespace FirstIssue.WebApp
{
    public static class HttpFilterConfig
    {
        public static void RegisterHttpGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new System.Web.Http.AuthorizeAttribute());
            filters.Add(new UnhandledExceptionFilter());
        }
    }
}