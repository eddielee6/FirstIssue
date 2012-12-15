using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstIssue.WebApp.Models;

namespace FirstIssue.WebApp.Controllers
{
    [Authorize]
    public partial class BaseController : Controller
    {
        protected FirstIssueContext _dbContext { get; private set; }

        public BaseController()
        {
            _dbContext = new FirstIssueContext();
        }

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(MVC.Home.Index());
            }
        }
    }
}
