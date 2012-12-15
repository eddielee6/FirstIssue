using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class TextStyle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TextStyleId { get; set; }

        public int SupportedFontId { get; set; }
        public SupportedFont Font { get; set; }
        public string FontColour { get; set; }
        public double FontSize { get; set; }
    }
}