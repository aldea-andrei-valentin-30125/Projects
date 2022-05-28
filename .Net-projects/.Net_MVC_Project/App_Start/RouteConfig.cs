using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace MVCFinalProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Restaurant",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Restaurante", action = "DeleteProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Client",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Client", action = "ViewProducts", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AddToFavorite",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Client", action = "AddToFavorite", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Client", action = "AddToCart", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteFavorite",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Client", action = "DeleteFavorite", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cart2",
                url: "{controller}/{action}",
                defaults: new { controller = "Client", action = "SendCommand" }
            );

            routes.MapRoute(
                name: "OrderDetails",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Delivery", action = "AcceptCommand", id = UrlParameter.Optional }
            );
            

        }
    }
}
