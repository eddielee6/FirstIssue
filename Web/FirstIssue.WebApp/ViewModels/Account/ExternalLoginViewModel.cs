using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.ViewModels.Account
{
    public class ExternalLoginViewModel
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}