using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

using FirstIssue.WebApp.AppCode.ExtensionMethods;

namespace FirstIssue.WebApp.Models
{
    public class FirstIssueInitializer : DropCreateDatabaseIfModelChanges<FirstIssueContext>
    {
        protected override void Seed(FirstIssueContext context)
        {
            var elmahScript = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.elmah.sql");
            var scriptSnippets = Regex.Split(elmahScript, "GO");

            foreach (var scriptSnippet in scriptSnippets)
            {
                context.Database.ExecuteSqlCommand(scriptSnippet);
            }
        }
    }
    
}