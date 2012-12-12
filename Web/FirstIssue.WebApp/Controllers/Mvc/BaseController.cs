using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstIssue.WebApp.Models;

namespace FirstIssue.WebApp.Controllers
{
    public partial class BaseController : Controller
    {
        protected FirstIssueContext _dbContext { get; private set; }

        public BaseController()
        {
            _dbContext = new FirstIssueContext();
        }
    }
}
