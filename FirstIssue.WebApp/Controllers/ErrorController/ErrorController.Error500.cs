using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers
{
    public partial class ErrorController
    {        
        public virtual ActionResult Error500()
        {
            SetupResponse(HttpStatusCode.InternalServerError);
            return View(MVC.Error.Views.Error500);
        }
    }
}
