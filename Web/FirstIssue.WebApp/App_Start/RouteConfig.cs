using System;
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
            RegisterIgnoreRoutes(routes);
            RegisterErrorRoutes(routes);
            RegisterHomeRoutes(routes);
            RegisterAccountRoutes(routes);
            RegisterMagazineRoutes(routes);
        }

        private static void RegisterIgnoreRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{file}.gif");
            routes.IgnoreRoute("{file}.png");
            routes.IgnoreRoute("{file}.js");
            routes.IgnoreRoute("{file}.html");
            routes.IgnoreRoute("{file}.htm");
            routes.IgnoreRoute("{file}.css");
        }

        private static void RegisterMagazineRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "Magazine_List",
                "Magazines",
                MVC.Magazine.ListMagazines()
            );
        }

        private static void RegisterAccountRoutes(RouteCollection routes)
        {
            // Account routes
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

        private static void RegisterHomeRoutes(RouteCollection routes)
        {
            // Home routes
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
        }       

        private static void RegisterErrorRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "Error404",
                "Error404",
                MVC.Error.Error404()
            );

            routes.MapRoute(
                "Error403",
                "Error403",
                MVC.Error.Error403()
            );

            routes.MapRoute(
                "Error500",
                "Error500",
                MVC.Error.Error500()
            );

            routes.MapRoute(
                "StaticErrorPage",
                "StaticErrorPage",
                MVC.Error.StaticErrorPage()
            );
        }
    }
}