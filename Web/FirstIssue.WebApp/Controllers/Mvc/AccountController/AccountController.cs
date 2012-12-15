using FirstIssue.WebApp.AppCode.EmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace FirstIssue.WebApp.Controllers
{
    public partial class AccountController : BaseController
    {
        private IEmailService _emailService = null;

        public AccountController(IEmailService emailService)
        {
            _emailService = emailService;
        }
    }
}
