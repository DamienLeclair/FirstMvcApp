﻿using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute("NewRoute", "App/Do{action}", new { controller = "Home" });

            routes.MapRoute(
                "MyRoute",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional });

        }
    }
}
