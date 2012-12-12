using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostmarkDotNet;

namespace FirstIssue.WebApp.AppCode.EmailService
{
    public class PostmarkEmailService : IEmailService
    {
        public string _apiKey;

        public PostmarkEmailService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void SendEmail(string from, string to, string subject, string bodyText)
        {
            var message = new PostmarkMessage
            {
                From = from,
                To = to,
                Subject = subject,
                TextBody = bodyText,
                ReplyTo = "admin@firstissue.co"
            };

            var client = new PostmarkClient(_apiKey);
            var response = client.SendMessage(message);
        }
    }
}