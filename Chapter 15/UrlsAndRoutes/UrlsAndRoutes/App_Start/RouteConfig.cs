using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            
            //var myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add(myRoute);

            //routes.MapRoute("ShopSchema2", "Shop/oldAction", new { controller = "Home", action="Index" });
            //routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });
            //routes.MapRoute("", "X{controller}/{action}");
            //routes.MapRoute("MyRoute", "{controller}/{action}", new { controller = "Home", action="Index" });
            //routes.MapRoute("", "Public/{controller}/{Action}", new { controller = "Home", action = "Index" });

            //routes.MapRoute("AddControllerRoute", "Home/{controller}/{action}/{id}/{*catchall}", 
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "UrlsAndRoutes.AdditionnalControllers" });
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "UrlsAndRoutes.Controllers" });

            //var route = routes.MapRoute("AddControllerRoute", "Home/{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new[] { "UrlsAndRoutes.AdditionnalControllers" });
            //route.DataTokens["UseNamespceFallBack"] = false;

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new 
                { 
                    controller = "^H.*", 
                    action = "^Index$|^About$", 
                    httpmethod = new HttpMethodConstraint("GET"),
                    id = new CompoundRouteConstraint(new IRouteConstraint[] { new AlphaRouteConstraint(), new MinLengthRouteConstraint(6)})
                },
                new[] { "UrlsAndRoutes.Controllers" });
        }
    }
}
