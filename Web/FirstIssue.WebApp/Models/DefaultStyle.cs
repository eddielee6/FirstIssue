using System;
using System.Collections.Generic;
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

        public TextStyle TitleStyle { get; set; }
        public TextStyle SubTitleStyle { get; set; }
        public TextStyle BodyStyle { get; set; }
        public TextStyle ByLineStyle { get; set; }
    }
}