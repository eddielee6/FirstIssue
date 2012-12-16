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
            RegisterArticleRoutes(routes);
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

            routes.MapRoute(
                "Magazine_Style",
                "Magazines/StyleCreator",
                MVC.Magazine.StyleCreator()
            );

            routes.MapRoute(
                "Get_Default_Style",
                "Magazines/PrebuiltStyle/{prebuiltStyleId}",
                MVC.Magazine.GetPrebuiltStyle(prebuiltStyleId: -1)
            );
        }

        private static void RegisterArticleRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "Article_Render",
                "RenderArticle",
                MVC.Article.RenderArticle()
            );

            routes.MapRoute(
                "Article_Render_CSS",
                "Render_CSS",
                MVC.Article.RenderCSS()
            );
        }

        private static void RegisterAccountRoutes(RouteCollection routes)
        {
            // Account routes
            routes.MapRoute(
                name: "Account_Login",
                url: "Account/Login",
                defaults: new { controller = "Account", action = "Login" }
            );

            routes.MapRoute(
                name: "Account_ExternalLoginsList",
                url: "Account/ExternalLoginsList",
                defaults: MVC.Account.ExternalLoginsList()
            );

            routes.MapRoute(
                name: "Account_Manage",
                url: "Account/Manage",
                defaults: MVC.Account.Manage()
            );

            routes.MapRoute(
                name: "Account_Register",
                url: "Account/Register",
                defaults: MVC.Account.Register()
            );

            routes.MapRoute(
                name: "Account_RemoveExternalLogins",
                url: "Account/RemoveExternalLogins",
                defaults: MVC.Account.RemoveExternalLogins()
            );

              routes.MapRoute(
                name: "Account_LogOff",
                url: "Account/LogOff",
                defaults: MVC.Account.LogOff()
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
