using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstIssue.WebApp.Models.Azure;

namespace System.Web.Mvc
{
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Returns a URI to a Azure blob given a container name and an identifier
        /// Handles switching URL for blob storage
        /// Usage, 
        ///     img src="@Url.AzureImageUrl(container name, identifier)" 
        /// </summary>        
        public static MvcHtmlString AzureImageUrl(this UrlHelper helper, string container, string identifier)
        {
            var domain = CloudStorageAccountFactory.CreateCloudStorageAccount().BlobEndpoint;

            Uri uri;
            // Cannot find a better way of doing this - storage emulator should always be 127.0.0.1 even if on differnt port
            if (domain.Host == "127.0.0.1")
            {
                uri = new Uri(domain, string.Format("devstoreaccount1/{0}/{1}", container, identifier));
            }
            else
            {
                uri = new Uri(domain, string.Format("{0}/{1}", container, identifier));
            }

            return new MvcHtmlString(uri.ToString());
        }

        public static MvcHtmlString Login(this UrlHelper helper)
        {
            return new MvcHtmlString(helper.RouteUrl("Account_Login"));
        }

        public static MvcHtmlString ForgotPassword(this UrlHelper helper)
        {
            return new MvcHtmlString(helper.RouteUrl("Account_ForgotPassword"));
        }

        public static MvcHtmlString ResetPassword(this UrlHelper helper)
        {
            return new MvcHtmlString(helper.RouteUrl("Account_ResetPassword"));
        }

        public static MvcHtmlString Register(this UrlHelper helper)
        {
            return new MvcHtmlString(helper.RouteUrl("Account_Register"));
        }

        public static MvcHtmlString Home(this UrlHelper helper)
        {
            return new MvcHtmlString(helper.RouteUrl("Home_Index"));
        }

        public static MvcHtmlString About(this UrlHelper helper)
        {
            return new MvcHtmlString(helper.RouteUrl("Home_About"));
        }
    }
}