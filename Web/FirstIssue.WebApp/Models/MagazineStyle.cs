using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class MagazineStyle
    {
        [Key, Column(Order = 0)]
        public int MagazineId { get; set; }
        public Magazine Magazine { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MagazineStyleID { get; set; }

        public string BackgroundColour { get; set; }

        public virtual TextStyle TitleStyle { get; set; }
        public virtual TextStyle SubTitleStyle { get; set; }
        public virtual TextStyle BodyStyle { get; set; }
        public virtual TextStyle ByLineStyle { get; set; }
    }
}