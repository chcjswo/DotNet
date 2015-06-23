using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DolPic.Service.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Pics", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DolPicImageSave",
                url: "{controller}/{action}/{TagNo}/{ImageSrc}/{TagUrlType}",
                defaults: new { TagNo = UrlParameter.Optional, ImageSrc = UrlParameter.Optional, TagUrlType = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Common",
                url: "Common/{controller}/{action}/{id}",
                defaults: new { controller = "Error", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}