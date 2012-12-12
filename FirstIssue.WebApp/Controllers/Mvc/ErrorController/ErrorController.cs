using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers
{
    [AllowAnonymous]
    public partial class ErrorController : BaseController
    {
        private void SetupResponse(HttpStatusCode statusCode)
        {
            Response.ClearHeaders();
            Response.ClearContent();
            Response.StatusCode = (int)statusCode;
            Response.TrySkipIisCustomErrors = true;
        }
    }
}
