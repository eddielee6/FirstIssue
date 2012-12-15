using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class Subscriber
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriberId { get; set; }

        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public Magazine Magazine { get; set; }        
    }
}