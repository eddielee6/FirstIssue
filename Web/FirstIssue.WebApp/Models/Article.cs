using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class Article
    {
        [Key, Column(Order = 0)]
        public int MagazineId { get; set; }
        public Magazine Magazine { get; set; }

        [Key, Column(Order = 1)]
        public int IssueId { get; set; }
        public Issue Issue { get; set; }

        [Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }                

        public User Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public string test { get; set; }
    }
}