﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers
{   
    public partial class AccountController : BaseController
    {
        public virtual ActionResult ForgotPassword()
        {
            return View();
        }        
    }
}
