﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers
{
    [AllowAnonymous]
    public partial class HomeController : Controller
    {       
        public virtual ActionResult Contact()
        {
            return View();
        }
    }
}
