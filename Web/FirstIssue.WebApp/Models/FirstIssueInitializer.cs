using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.Models
{
    public class FirstIssueInitializer : DropCreateDatabaseIfModelChanges<FirstIssueContext>
    {
        protected override void Seed(FirstIssueContext context)
        {
            base.Seed(context);

            // Test data + raw sql here 
        }
    }
}