using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.ViewModels.Account
{
    public class RegisterExternalLoginViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }    
}