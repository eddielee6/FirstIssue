﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstIssue.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Home routes
            routes.MapRoute(
                name: "Home_Index",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Home_About",
                url: "About",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                name: "Home_Contact",
                url: "Contact",
                defaults: new { controller = "Home", action = "Contact" }
            );


            //Account routes
            routes.MapRoute(
                name: "Account_Login",
                url: "Login",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Account_ForgotPassword",
                url: "ForgotPassword",
                defaults: new { controller = "Account", action = "ForgotPassword" }
            );

            routes.MapRoute(
                name: "Account_ResetPassword",
                url: "ResetPassword",
                defaults: new { controller = "Account", action = "ResetPassword" }
            );

            routes.MapRoute(
                name: "Account_Register",
                url: "Register",
                defaults: new { controller = "Account", action = "Register" }
            );
        }
    }
}