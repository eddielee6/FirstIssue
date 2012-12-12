using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;

namespace FirstIssue.WebApp.Models.Azure
{
    public static class CloudStorageAccountFactory
    {
        public static CloudStorageAccount CreateCloudStorageAccount()
        {
            return CloudStorageAccount.Parse(System.Configuration.ConfigurationManager.AppSettings["AzureStorageConnectionString"]);            
        }
    }
}