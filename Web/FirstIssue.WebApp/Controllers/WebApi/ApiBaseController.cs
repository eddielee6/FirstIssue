using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstIssue.WebApp.Models;

namespace FirstIssue.WebApp.Controllers
{
    /// <summary>
    /// Prefix all API routes with API/
    /// </summary>
    public class ApiBaseController
    {
        protected FirstIssueContext _dbContext { get; private set; }

        public ApiBaseController()
        {
            _dbContext = new FirstIssueContext();
        }        
    }
}