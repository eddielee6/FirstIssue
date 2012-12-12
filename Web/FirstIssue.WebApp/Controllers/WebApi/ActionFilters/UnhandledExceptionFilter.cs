using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

using FirstIssue.WebApp.AppCode.ExtensionMethods;

namespace FirstIssue.WebApp.Controllers.WebApi.ActionFilters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var httpStatus = HttpStatusCode.InternalServerError;

            var exType = context.Exception.GetType();

            if (context.Exception is UnauthorizedAccessException)
                httpStatus = HttpStatusCode.Unauthorized;
            else if (context.Exception is ArgumentException)
                httpStatus = HttpStatusCode.NotFound;
            else if (context.Exception is NotImplementedException)
                httpStatus = HttpStatusCode.NotImplemented;

            context.Request.CreateErrorResponse(httpStatus, context.Exception.Message);

            base.OnException(context);
        }
    }
}