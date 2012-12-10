using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstIssue.WebApp.Controllers
{
    public partial class AccountController : Controller
    {
        public virtual ActionResult Login()
        {
            return View();
        }

        public virtual ActionResult ForgotPassword()
        {
            return View();
        }

        public virtual ActionResult ResetPassword()
        {
            return View();
        }

        public virtual ActionResult Register()
        {
            return View();
        }
    }
}
