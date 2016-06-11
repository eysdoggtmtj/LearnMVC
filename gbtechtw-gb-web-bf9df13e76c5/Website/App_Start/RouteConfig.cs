using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Website.Controllers;

namespace Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            string[] nameSpace = new string[] { typeof(BaseController).Namespace };
            routes.MapRoute(
                name: "All",
                url: "All",
                defaults: new { controller = "Home", action = "All" }, namespaces: nameSpace
            );

            routes.MapRoute(
                name: "Sidebar",
                url: "Home/Sidebar",
                defaults: new { controller = "Home", action = "Sidebar" }, namespaces: nameSpace
            );

            routes.MapRoute(
                name: "Page",
                url: "Page/{page}",
                defaults: new { controller = "Home", action = "Page" }, namespaces: nameSpace
            );

            routes.MapRoute(
                name: "Archive",
                url: "Archive/{year}/{month}",
                defaults: new { controller = "Home", action = "Archive" }, namespaces: nameSpace
            );

            routes.MapRoute(
                name: "Category",
                url: "Category/{name}",
                defaults: new { controller = "Home", action = "Category" }, namespaces: nameSpace
            );

            routes.MapRoute(
                name: "Detail",
                url: "Article/{name}",
                defaults: new { controller = "Home", action = "Detail" }, namespaces: nameSpace
            );
            
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index" }, namespaces: nameSpace
            );
        }
    }
}
