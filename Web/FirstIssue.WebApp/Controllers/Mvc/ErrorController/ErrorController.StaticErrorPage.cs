using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers
{
    public partial class ErrorController
    {     
        public virtual ActionResult StaticErrorPage()
        {
            return File(Server.MapPath("/views/error/") + "StaticErrorPage.html", "text/html");
        }
    }
}
