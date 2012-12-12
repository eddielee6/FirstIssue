using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FirstIssue.WebApp.AppCode.ExtensionMethods
{
    public static class HttpRequestMessageExtensions
    {
        public static HttpResponseException CreateHttpResponseException(this HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            return new HttpResponseException(request.CreateErrorResponse(statusCode, message));
        }

        public static HttpResponseException CreateHttpResponseException(this HttpRequestMessage request, HttpStatusCode statusCode, string formatString, params object[] formatParams)
        {
            return request.CreateHttpResponseException(statusCode, string.Format(formatString, formatParams));
        }
    }
}