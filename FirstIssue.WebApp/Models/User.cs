using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class User
    {        
        public int UserId { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }        
        
        public string FullName { get; set; }
        
        public bool IsActive { get; set; }        
        
        /// <summary>
        /// Is admin of entire system - ie. the team will have logins with special priveledges
        /// </summary>
        public bool IsAdmin { get; set; }        
        
        public int? TwitterUserId { get; set; }
        
        public int? FacebookUserId { get; set; }
        
        public string ActivationId { get; set; }
        
        public string PasswordResetLinkId { get; set; }
        
        public DateTime? PasswordResetLinkGeneratedOn { get; set; }
    }
}