using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class SupportedFont
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupportedFontId { get; set; }

        public string Name { get; set; }
    }
}