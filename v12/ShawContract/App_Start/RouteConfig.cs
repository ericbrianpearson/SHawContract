using System.Globalization;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;
using Kentico.Web.Mvc;
using ShawContract.Config;
using ShawContract.Utils;

namespace ShawContract
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var defaultCulture = CultureInfo.GetCultureInfo("en-US");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Use lowercase urls for consistency
            routes.LowercaseUrls = true;

            // Maps routes to Kentico HTTP handlers and features enabled in ApplicationConfig.cs
            // Always map the Kentico routes before adding other routes. Issues may occur if Kentico URLs are matched by a general route, for example images might not be displayed on pages
            routes.Kentico().MapRoutes();

            var route = routes.MapRoute(
               name: "GenericContentPage",
               url: "{culture}/GenericContent/{nodeAlias}",
               defaults: new { culture = defaultCulture.Name, controller = "GenericContent", action = "Index" },
               constraints: new { culture = new SiteCultureConstraint(AppConfig.Sitename), nodeAlias = new OptionalRouteConstraint(new RegexRouteConstraint(@"[\w\d_-]*")) }
               );

            // Maps routes with cultures
            route = routes.MapRoute(
                name: "DefaultWithCulture",
                url: "{culture}/{controller}/{action}/{id}",
                defaults: new { culture = defaultCulture.Name, controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { culture = new SiteCultureConstraint(AppConfig.Sitename), id = new OptionalRouteConstraint(new IntRouteConstraint()) }
            );

            // A route value determines the culture of the current thread
            route.RouteHandler = new MultiCultureMvcRouteHandler();
        }
    }
}