using FirstIssue.WebApp.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace FirstIssue.WebApp.Controllers
{    
    public partial class AccountController : BaseController
    {
        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.FullName, model.Password);
                    WebSecurity.Login(model.FullName, model.Password);
                    return RedirectToAction(MVC.Home.Index());
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCode.ErrToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
