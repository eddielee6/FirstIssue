using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class DefaultStyle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DefaultStyleID { get; set; }

        public string Name { get; set; }

        public string BackgroundColour { get; set; }

        public virtual TextStyle TitleStyle { get; set; }
        public virtual TextStyle SubTitleStyle { get; set; }
        public virtual TextStyle BodyStyle { get; set; }
        public virtual TextStyle ByLineStyle { get; set; }
    }
}