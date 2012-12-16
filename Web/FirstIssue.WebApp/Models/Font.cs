using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class Font
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FontId { get; set; }

        public string Name { get; set; }
    }
}