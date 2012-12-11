using System;
using System.Configuration;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using FirstIssue.WebApp.AppCode.ExtensionMethods;

namespace FirstIssue.WebApp.AppCode.HttpModules
{
    public class ErrorHandlerHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.Error += Application_Error;
        }

        private static void Application_Error(object sender, EventArgs e)
        {
            if (!HttpContext.Current.IsCustomErrorEnabled)
            {
                return;
            }

            if (ErrorOriginatesFromErrorPage())
            {
                HandleErrorHandlingError();
                return;
            }

            try
            {
                var ex = GetServerException();
                var statusCode = GetHttpStatusCode(ex);

                if (statusCode == (int)HttpStatusCode.NotFound)
                {
                    TransferToAction("Error", "Error404");

                }
                else if (statusCode == (int)HttpStatusCode.Forbidden)
                {
                    TransferToAction("Error", "Error403");
                }
                else
                {
                    TransferToAction("Error", "Error500");
                }
            }
            catch
            {
                HandleErrorHandlingError();
            }

        }

        private static Exception GetServerException()
        {
            var ex = HttpContext.Current.Server.GetLastError();
            if (ex is HttpUnhandledException)
            {
                ex = ex.InnerException ?? ex;
            }
            return ex;
        }

        private static int GetHttpStatusCode(Exception exception)
        {
            var httpException = exception as HttpException;

            var statusCode = httpException != null
                ? httpException.GetHttpCode()
                : (int)HttpStatusCode.InternalServerError;

            return statusCode;
        }

        private static bool ErrorOriginatesFromErrorPage()
        {
            return HttpContext.Current.Request.Path.StartsWithIgnoreCase("/Error");
        }

        private static void HandleErrorHandlingError()
        {
            var response = HttpContext.Current.Response;
            response.ClearHeaders();
            response.ClearContent();
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            HttpContext.Current.Server.ClearError();
            TransferToAction("error", "staticerrorpage");
        }

        private static void TransferToAction(string controllerName, string actionName)
        {
            var routeData = new RouteData();

            routeData.Values.Add("controller", controllerName);
            routeData.Values.Add("action", actionName);

            var requestContext = new RequestContext(new HttpContextWrapper(HttpContext.Current), routeData);
            var controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            var controller = controllerFactory.CreateController(requestContext, controllerName);
            controller.Execute(requestContext);
            HttpContext.Current.Server.ClearError();
        }

        public void Dispose()
        {
        }
    }
}