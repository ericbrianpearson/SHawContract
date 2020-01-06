using System;
using System.Web;
using System.Web.Routing;

using Kentico.Web.Mvc;
using ShawContract.Config;

namespace ShawContract
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Enables and configures selected Kentico ASP.NET MVC integration features
            ApplicationConfig.RegisterFeatures(ApplicationBuilder.Current);

            // Registers routes including system routes for enabled features
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutofacConfiguration.ConfigureContainer();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            //log error here
            Server.ClearError();
            Response.Clear();

            if ((error is HttpException) && ((HttpException)error).GetHttpCode() == 404)
            {
                Response.Redirect("/en-us/Error/NotFound");
            }
            else
            {
                Response.Redirect("/en-us/Error/ServerError");
            }
        }
    }
}