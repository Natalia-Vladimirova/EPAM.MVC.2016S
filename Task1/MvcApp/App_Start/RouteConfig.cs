using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace MvcApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Static",
                url: "Home/Static",
                defaults: new { controller = "Home", action = "Static" },
                namespaces: new[] { "MvcApp.Controllers" }
            );

            routes.MapRoute(
                name: "CustomOptional",
                url: "CustomOptional/{param}",
                defaults: new { controller = "Home", action = "CustomOptional", param = UrlParameter.Optional },
                namespaces: new[] { "MvcApp.Controllers" }
            );

            routes.MapRoute(
                name: "NamespacePriority",
                url: "JSON/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "AdditionalLib" }
            );

            routes.MapRoute(
                name: "RouteConstraints",
                url: "Constraints/{id}",
                defaults: new { controller = "Home", action = "Constraints", id = UrlParameter.Optional },
                constraints: new
                {
                    id = new CompoundRouteConstraint(new IRouteConstraint[]
                    {
                        new IntRouteConstraint(),
                        new MinLengthRouteConstraint(2),
                        new MaxRouteConstraint(1000)
                    })
                },
                namespaces: new[] { "MvcApp.Controllers" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MvcApp.Controllers" }
            );
        }
    }
}
