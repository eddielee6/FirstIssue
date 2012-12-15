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
        
        /// <summary>
        /// Unique to this user
        /// </summary>
        public string Email { get; set; }
        
        public string UserName { get; set; }
        
        public bool IsActive { get; set; }        
    }
}