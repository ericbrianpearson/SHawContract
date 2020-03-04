using System;
using System.Text.RegularExpressions;
using System.Web.Routing;
using CMS.EventLog;
using Kentico.Web.Mvc;
using ShawContract.Config;

namespace ShawContract
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();
            //log error here
            Server.ClearError();
            Response.Clear();

            EventLogProvider.LogException("ShawContract", "EXCEPTION", error);
            string redirectPath = "";
            if (error.InnerException != null)
            {
                redirectPath = "/en-us/Error/ServerError?error=" + error.Message + "&innerError=" + error.InnerException.Message;
            }
            else
            {
                redirectPath = "/en-us/Error/ServerError?error=" + error.Message;
            }

            redirectPath = Regex.Replace(redirectPath, @"\t|\n|\r", "");
            Response.Redirect(redirectPath);
        }

        protected void Application_Start()
        {
            // Enables and configures selected Kentico ASP.NET MVC integration features
            ApplicationConfig.RegisterFeatures(ApplicationBuilder.Current);

            // Registers routes including system routes for enabled features
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutofacConfiguration.ConfigureContainer();
        }
    }
}
