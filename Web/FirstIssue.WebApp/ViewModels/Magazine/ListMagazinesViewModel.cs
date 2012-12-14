using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstIssue.WebApp.Models;

namespace FirstIssue.WebApp.ViewModels
{
    public class ListMagazinesViewModel 
    {
        public ICollection<Magazine> Magazines { get; set; }
    }
}
