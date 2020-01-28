using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CMS.Helpers;
using Kentico.Membership;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using ShawContract.Config;
using ShawContract.Models.Personalization;

[assembly: OwinStartup(typeof(ShawContract.Startup))]

namespace ShawContract
{
    public class Startup
    {
        public static string ProfilePolicyId = ConfigurationManager.AppSettings["ida:UserProfilePolicyId"];
        public static string redirectUri = ConfigurationManager.AppSettings["ida:RedirectUri"];
        public static string SignInPolicyId = ConfigurationManager.AppSettings["ida:SignInPolicyId"];
        private const string OWIN_COOKIE_PREFIX = ".AspNet.";
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AadInstance"];
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];

        public void Configuration(IAppBuilder app)
        {
            // Registers Kentico.Membership Identity types with the 'ExtendedUser' user object
            app.CreatePerOwinContext(() => KenticoUserManager<ExtendedUser>.Initialize(app, new KenticoUserManager<ExtendedUser>(new KenticoUserStore<ExtendedUser>(AppConfig.Sitename))));
            app.CreatePerOwinContext<KenticoSignInManager<ExtendedUser>>(KenticoSignInManager<ExtendedUser>.Create);

            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            // Registers the Kentico.Membership identity implementation
            app.CreatePerOwinContext(() => UserManager.Initialize(app, new UserManager(new UserStore(AppConfig.Sitename))));
            app.CreatePerOwinContext<SignInManager>(SignInManager.Create);

            // Registers the authentication cookie with the 'Essential' cookie level
            // Ensures that the cookie is preserved when changing a visitor's allowed cookie level below 'Visitor'
            CookieHelper.RegisterCookie(OWIN_COOKIE_PREFIX + DefaultAuthenticationTypes.ApplicationCookie, CookieLevel.Essential);

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            // Configures the authentication cookie
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                // Fill in the name of your sign-in action and controller
                LoginPath = new PathString(urlHelper.Action("SignIn", "Account")),
                Provider = new CookieAuthenticationProvider
                {
                    // Sets the return URL for the sign-in page redirect (fill in the name of your sign-in action and controller)
                    OnApplyRedirect = context => context.Response.Redirect(urlHelper.Action("SignIn", "Account")
                                                 + new Uri(context.RedirectUri).Query)
                }
            });
            // Uses a cookie to temporarily store information about users signing in via external authentication services
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseOpenIdConnectAuthentication(CreateOptionsFromPolicy(SignInPolicyId));
        }

        private Task AuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
        {
            notification.HandleResponse();
            if (notification.Exception.Message == "access_denied")
            {
                notification.Response.Redirect("/");
            }
            else
            {
                notification.Response.Redirect("/Home/Error?message=" + notification.Exception.Message);
            }

            return Task.FromResult(0);
        }

        private OpenIdConnectAuthenticationOptions CreateOptionsFromPolicy(string policy)
        {
            return new OpenIdConnectAuthenticationOptions
            {
                MetadataAddress = String.Format(aadInstance, tenant, policy),
                AuthenticationType = policy,
                ClientId = clientId,
                RedirectUri = redirectUri,
                PostLogoutRedirectUri = redirectUri,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthenticationFailed = AuthenticationFailed
                },
                Scope = "openid",
                ResponseType = "id_token",
                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    SaveSigninToken = true
                }
            };
        }
    }
}
