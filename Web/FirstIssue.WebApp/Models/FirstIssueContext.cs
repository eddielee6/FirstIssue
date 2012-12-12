using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class FirstIssueContext : DbContext
    {
        public FirstIssueContext()
        {
        }

        public FirstIssueContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { 
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Issue>().
                HasRequired(i => i.Magazine).
                WithMany(m => m.Issues).
                HasForeignKey(i => i.MagazineId).
                WillCascadeOnDelete(false);            
        }
    }
}