using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class Magazine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MagazineId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Id of blob in azure
        /// </summary>
        public string DefaultCoverImageId { get; set; }

        public virtual ICollection<Contributor> Contributors { get; set; }
        public virtual ICollection<Subscriber> Subscribers { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}