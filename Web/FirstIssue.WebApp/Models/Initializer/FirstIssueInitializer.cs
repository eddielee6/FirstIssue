﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;

using FirstIssue.WebApp.AppCode.ExtensionMethods;
using FirstIssue.WebApp.Models.Azure;

namespace FirstIssue.WebApp.Models
{
    public class FirstIssueInitializer : DropCreateDatabaseIfModelChanges<FirstIssueContext>
    {   
        protected override void Seed(FirstIssueContext context)
        {
            var elmahScript = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.elmah.sql");
            var scriptSnippets = Regex.Split(elmahScript, "GO");

            foreach (var scriptSnippet in scriptSnippets)
            {
                context.Database.ExecuteSqlCommand(scriptSnippet);
            }

            var blobStorage = new MagazineCoverContext(CloudStorageAccountFactory.CreateCloudStorageAccount());
            var newId = Guid.NewGuid().ToString();
            blobStorage.AddSnapImage(newId, Assembly.GetExecutingAssembly().GetManifestResourceStream("FirstIssue.WebApp.Models.Initializer.DefaultCover.png"));

            AddFonts(context);
            context.SaveChanges();

            AddDefaultStyles(context);
            context.SaveChanges();

            AddMagazine(context, newId);
            context.SaveChanges();

            AddIssues(context, newId);
            context.SaveChanges();

            AddIssue1Articles(context);
            context.SaveChanges();

            AddIssue2Articles(context);
            context.SaveChanges();
        }

        private static void AddFonts(FirstIssueContext context)
        {
            //context.SupportedFonts.Add(new SupportedFont { Name = "Avenir" });
            //context.SupportedFonts.Add(new SupportedFont { Name = "Baskerville" });
            //context.SupportedFonts.Add(new SupportedFont { Name = "Cochin" });
            context.Fonts.Add(new Font { Name = "Courier" });
            //context.SupportedFonts.Add(new SupportedFont { Name = "Futura" });
            context.Fonts.Add(new Font { Name = "Georgia" });
            //context.SupportedFonts.Add(new SupportedFont { Name = "GillSans" });
            //context.SupportedFonts.Add(new SupportedFont { Name = "Helvetica" });
            //context.SupportedFonts.Add(new SupportedFont { Name = "HelveticaNeue" });
            //context.SupportedFonts.Add(new SupportedFont { Name = "Palatino" });
            //context.SupportedFonts.Add(new SupportedFont { Name = "Papyrus" });
            context.Fonts.Add(new Font { Name = "TimesNewRoman" });
            context.Fonts.Add(new Font { Name = "Verdana" });
            //context.SupportedFonts.Add(new SupportedFont { Name = "Zapfino" });
        }

        private static void AddDefaultStyles(FirstIssueContext context)
        {
            context.PrebuiltStyles.Add(new PrebuiltStyle
            {
                Name = "Light",
                BackgroundColour = "#eeeeee",
                TitleStyle = new TextStyle { FontId = 2, FontColour = "#999999", FontSize = 1.4 },
                SubTitleStyle = new TextStyle { FontId = 2, FontColour = "#999999", FontSize = 1.2 },
                BodyStyle = new TextStyle { FontId = 3, FontColour = "#999999", FontSize = 1 },
                ByLineStyle = new TextStyle { FontId = 3, FontColour = "#999999", FontSize = 1.1 }
            });

            context.PrebuiltStyles.Add(new PrebuiltStyle
            {
                Name = "Dark",
                BackgroundColour = "#999999",
                TitleStyle = new TextStyle { FontId = 1, FontColour = "#eeeeee", FontSize = 1.5 },
                SubTitleStyle = new TextStyle { FontId = 4, FontColour = "#eeeeee", FontSize = 1.3 },
                BodyStyle = new TextStyle { FontId = 4, FontColour = "#eeeeee", FontSize = 0.9 },
                ByLineStyle = new TextStyle { FontId = 4, FontColour = "#eeeeee", FontSize = 1 }
            });
        }

        private static void AddMagazine(FirstIssueContext context, string coverImageId)
        {
            var magazine = new Magazine()
            {
                Name = "The Magazine",
                Description = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.MagazineDescription.txt"),
                DefaultCoverImageId = coverImageId,
                MagazineStyle = new MagazineStyle
                {
                    BackgroundColour = "#eeeeee",
                    TitleStyle = new TextStyle { FontId = 2, FontColour = "#999999", FontSize = 1.4 },
                    SubTitleStyle = new TextStyle { FontId = 2, FontColour = "#999999", FontSize = 1.2 },
                    BodyStyle = new TextStyle { FontId = 3, FontColour = "#999999", FontSize = 1 },
                    ByLineStyle = new TextStyle { FontId = 3, FontColour = "#999999", FontSize = 1.1 }
                }
            };
            context.Magazines.Add(magazine);
        }

        private static void AddIssues(FirstIssueContext context, string coverImageId)
        {   
            var issue = new Issue()
            {
                MagazineId = 1,
                IssueNumber = 1,
                PublishDate = DateTime.Parse("11-10-2012"),
                IsPublished = false,
                CoverImageId = coverImageId
            };
            context.Issues.Add(issue);

            issue = new Issue()
            {
                MagazineId = 1,
                IssueNumber = 2,
                PublishDate = DateTime.Parse("25-10-2012"),
                IsPublished = false,
                CoverImageId = coverImageId
            };
            context.Issues.Add(issue);

            issue = new Issue()
            {
                MagazineId = 1,
                IssueNumber = 3,
                PublishDate = DateTime.Parse("11-08-2012"),
                IsPublished = false,
                CoverImageId = coverImageId
            };
            context.Issues.Add(issue);            
        }

        private static void AddIssue1Articles(FirstIssueContext context)
        {
            var article = new Article()
            {
                MagazineId = 1,
                IssueId = 1,
                Title = "Fireballed",
                Order = 0,
                Content = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.Issue1Article1.txt"),
            };
            context.Articles.Add(article);

            article = new Article()
            {
                MagazineId = 1,
                IssueId = 1,
                Title = "Baseball Misfits",
                Order = 1,
                Content = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.Issue1Article2.txt"),
            };
            context.Articles.Add(article);

            article = new Article()
            {
                MagazineId = 1,
                IssueId = 1,
                Title = "Alone Together, Again",
                Order = 2,
                Content = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.Issue1Article3.txt"),
            };
            context.Articles.Add(article);

            article = new Article()
            {
                MagazineId = 1,
                IssueId = 1,
                Title = "Stables and Volatiles",
                Order = 3,
                Content = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.Issue1Article4.txt"),
            };
            context.Articles.Add(article);
        }

        private static void AddIssue2Articles(FirstIssueContext context)
        {
            var article = new Article()
            {
                MagazineId = 1,
                IssueId = 2,
                Title = "Strange Game",
                Order = 0,
                Content = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.Issue2Article1.txt"),
            };
            context.Articles.Add(article);

            article = new Article()
            {
                MagazineId = 1,
                IssueId = 2,
                Title = "How to Make a Baby",
                Order = 1,
                Content = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.Issue2Article2.txt"),
            };
            context.Articles.Add(article);

            article = new Article()
            {
                MagazineId = 1,
                IssueId = 2,
                Title = "The Wet Shave",
                Order = 2,
                Content = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.Issue2Article3.txt"),
            };
            context.Articles.Add(article);

            article = new Article()
            {
                MagazineId = 1,
                IssueId = 2,
                Title = "Falling From The Friendly Skies",
                Order = 3,
                Content = Assembly.GetExecutingAssembly().GetFileResourceAsString("FirstIssue.WebApp.Models.Initializer.Issue2Article4.txt"),
            };
            context.Articles.Add(article);
        }
    }
    
}