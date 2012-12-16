using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class TextStyle
    {
        [Key, Column(Order = 0)]
        public int MagazineStyleID { get; set; }
        public PrebuiltStyle MagazineStyle { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TextStyleId { get; set; }

        public int FontId { get; set; }
        public virtual Font Font { get; set; }
        public string FontColour { get; set; }
        public double FontSize { get; set; }
    }
}