using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstIssue.WebApp.Models;
using Ionic;
using Ionic.Zip;
using System.Web;


namespace FirstIssue.WebApp.Controllers.WebApi
{
    public class apiController : ApiController
    {
        // GET api/default1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/default1/5
        public byte[] GetIssue(int id)
        {

            byte[] binaryData = new byte[1];

            var context = new FirstIssueContext();
            var i = (from c in context.Issues
                     where c.IssueId == id
                     select c).FirstOrDefault();

            var a = new IssueData
                {
                    IssueId = i.IssueId,
                    IssueDate = i.PublishDate,
                    IssueTitle = i.IssueName
                };

            return binaryData;
        }

        // POST api/default1
        public void Post(string value)
        {
        }
        // PUT api/default1/5
        public void Put(int id, string value)
        {
        }
        // DELETE api/default1/5
        public void Delete(int id)
        {
        }


        public string GetContentHtml(string content)
        {
            return string.Empty;
        }
        
    }

    public class IssueData
    {
        public string IssueTitle { get; set; }
        public DateTime IssueDate { get; set; }
        public int IssueId { get; set; }
        public List<ArticleData> Articles { get; set; }



        //public void createzip()
        //{
        //    HttpResponse response = new HttpResponse()
        //    response.Cache
        //    Response.Clear();
        //    Response.BufferOutput = false; // false = stream immediately
        //    System.Web.HttpContext c = System.Web.HttpContext.Current;
        //    String ReadmeText = String.Format("README.TXT\n\nHello!\n\n" +
        //                                     "This is text for a readme.");
        //    string archiveName = String.Format("archive-{0}.zip",
        //                                      DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
        //    Response.ContentType = "application/zip";
        //    Response.AddHeader("content-disposition", "filename=" + archiveName);

        //    using (ZipFile zip = new ZipFile())
        //    {
                
        //        zip.AddFiles(f, "files");
        //        zip.AddFileFromString("Readme.txt", "", ReadmeText);
        //        zip.Save(Response.OutputStream);
        //    }
        //    Response.Close();


        //}



    }
    public class ArticleData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string SubTitle { get; set; }
        public int Order { get; set; }
    }

    
}
