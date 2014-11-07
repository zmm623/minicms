using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ikende.minicms.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
    name: "blog",
    url: "blog",
    defaults: new { controller = "Home", action = "Blog", id = UrlParameter.Optional }
);

            routes.MapRoute(
 name: "blogitem",
 url: "blog/{id}",
 defaults: new { controller = "Home", action = "BlogItem", id = UrlParameter.Optional }
);


            routes.MapRoute(
       "all",
       "{page}",
       new { controller = "Home", action = "Index" },
       new { page = @"[a-zA-Z0-9\-_]+" }
    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}