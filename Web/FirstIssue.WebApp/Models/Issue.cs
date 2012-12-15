using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class Issue
    {
        [Key, Column(Order = 0)]
        public int MagazineId { get; set; }
        public Magazine Magazine { get; set; }

        public string IssueName { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IssueId { get; set; }
        
        public int IssueNumber { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsPublished { get; set; }

        /// <summary>
        /// Id of blob in azure
        /// </summary>
        public string CoverImageId { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}