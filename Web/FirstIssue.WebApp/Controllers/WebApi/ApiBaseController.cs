using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FirstIssue.WebApp.Models;

namespace FirstIssue.WebApp.Controllers
{
    public class ApiBaseController : ApiController
    {
        protected FirstIssueContext _dbContext { get; private set; }

        public ApiBaseController()
        {
            _dbContext = new FirstIssueContext();
        }        
    }
}