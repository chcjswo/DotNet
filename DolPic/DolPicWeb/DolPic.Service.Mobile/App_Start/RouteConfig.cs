using System.Web.Mvc;
using System.Web.Routing;

namespace DolPic.Service.Mobile
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
                name: "Main",
                url: "{controller}/{action}/{id}/{page}",
                defaults: new { controller = "Pics", action = "Main", id = UrlParameter.Optional, page = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "View",
                url: "{controller}/{action}/{ImgNo}/{HashTag}/{Page}",
                defaults: new { controller = "Pics", action = "PicView", ImgNo = UrlParameter.Optional, HashTag = UrlParameter.Optional, Page = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DolPicImageSave",
                url: "{controller}/{action}/{TagNo}/{ImageSrc}/{TagUrlType}/{IsView}",
                defaults: new { controller = "Pics", action = "DolPicImageSave", TagNo = UrlParameter.Optional, ImageSrc = UrlParameter.Optional, TagUrlType = UrlParameter.Optional, IsView = UrlParameter.Optional }
            );
        }
    }
}