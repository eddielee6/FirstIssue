using FirstIssue.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.ViewModels
{
    public class StyleCreatorViewModel
    {
        public IEnumerable<PrebuiltStyle> PrebuiltStyles { get; set; }
    }
}