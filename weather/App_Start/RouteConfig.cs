using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace weather
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{country}/{region}/{latitude}/{longitude}/{city}",
                defaults: new { controller = "Weather", action = "Index", country = UrlParameter.Optional, region = UrlParameter.Optional, latitude = UrlParameter.Optional, longitude = UrlParameter.Optional, city = UrlParameter.Optional, }
            );

            routes.MapRoute(
                name: "NotFound",
                url: "{*url}",
                defaults: new { controller = "Error", action = "PageNotFound" }
            );

        }
    }
}