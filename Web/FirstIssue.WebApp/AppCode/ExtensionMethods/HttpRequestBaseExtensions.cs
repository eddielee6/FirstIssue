using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.AppCode.ExtensionMethods
{
    public static class HttpRequestBaseExtensions
    {
        public static string FullUrl(this HttpRequestBase request, string path)
        {
            return string.Format("{0}{1}{2}{3}{4}", request.Url.Scheme, System.Uri.SchemeDelimiter, request.Url.Host,
                    (request.Url.IsDefaultPort ? "" : ":" + request.Url.Port), path);
        }
    }
}