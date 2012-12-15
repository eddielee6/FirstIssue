using FirstIssue.WebApp.Models;
using FirstIssue.WebApp.Models.Azure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace FirstIssue.WebApp
{
    public class FirstIssueConfig
    {
        public static void Initialize()
        {
            SetupDatabase();
            SetupBlobStorage();
            SetupMembership();
        }

        private static void SetupDatabase()
        {
            // Cant use this initializer in production - got to be migrations            
            Database.SetInitializer(new FirstIssueInitializer());
            var context = new FirstIssueContext();
            context.Database.Initialize(true);
            // context.Database.Initialize(false);
        }

        private static void SetupBlobStorage()
        {
            var storageAccount = CloudStorageAccountFactory.CreateCloudStorageAccount();
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(MagazineCoverContext.MagazineCoverContainer);
            container.CreateIfNotExists();
        }

        private static void SetupMembership()
        {
            WebSecurity.InitializeDatabaseConnection(
               "FirstIssueContext",
               "Users",
               "UserId",
               "UserName", autoCreateTables: true);

            CreateDefaultUsersIfNotAlready();
        }

        private static void CreateDefaultUsersIfNotAlready()
        {
            if (!WebSecurity.UserExists("marvin"))
            {
                CreateAdminUser("marvin");
            }
            if (!WebSecurity.UserExists("eddie"))
            {
                CreateAdminUser("eddie");
            }
            if (!WebSecurity.UserExists("weiran"))
            {
                CreateAdminUser("weiran");
            }
            if (!WebSecurity.UserExists("drew"))
            {
               CreateAdminUser("drew");
            }
            if (!WebSecurity.UserExists("matt"))
            {
                CreateAdminUser("matt");
            }
        }

        private static void CreateAdminUser(string name, string password = "password")
        {
            WebSecurity.CreateUserAndAccount(
                    name,
                    password,
                    new { IsActive = true });
        }
    }
}