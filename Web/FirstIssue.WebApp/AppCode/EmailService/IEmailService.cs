using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.AppCode.EmailService
{
    public interface IEmailService
    {
        void SendEmail(string from, string to, string subject, string bodyText);
    }
}