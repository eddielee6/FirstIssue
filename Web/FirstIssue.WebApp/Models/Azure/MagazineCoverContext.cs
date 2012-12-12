using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FirstIssue.WebApp.Models.Azure
{
    public class MagazineCoverContext
    {
        private CloudBlobContainer _cloudBlobContainer;
        
        public const string MagazineCoverContainer = "magazinecovers";

        public MagazineCoverContext(CloudStorageAccount account)            
        {
            _cloudBlobContainer = account.CreateCloudBlobClient().GetContainerReference(MagazineCoverContext.MagazineCoverContainer);
        }        

        public void AddSnapImage(string identifier, Stream imageStream)
        {
            var cloudBlob = _cloudBlobContainer.GetBlockBlobReference(identifier);
            cloudBlob.UploadFromStream(imageStream);                    
        }
    }
}