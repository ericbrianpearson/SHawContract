using Kentico.Web.Mvc;
using ShawContract.Config;
using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

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

            if ((error is HttpException))
            {
                var redirectPath = "/en-us/Error/ServerError?error=" + error.Message + "&innerError=" + error.InnerException.Message;
                redirectPath = Regex.Replace(redirectPath, @"\t|\n|\r", "");
                Response.Redirect(redirectPath);
            }
        }
    }
}