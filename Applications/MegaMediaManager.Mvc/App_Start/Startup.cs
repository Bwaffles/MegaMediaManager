using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using MegaMediaManager.Model;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using MegaMediaManager.Mvc.Managers;

namespace MegaMediaManager.Mvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(DAL.DataContextFactory.GetDataContext);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseFacebookAuthentication(appId: ConfigurationManager.AppSettings["FacebookID"], appSecret: ConfigurationManager.AppSettings["FacebookSecret"]);

            app.UseGoogleAuthentication(clientId: ConfigurationManager.AppSettings["GoogClientID"], clientSecret: ConfigurationManager.AppSettings["GoogClientSecret"]);
        }
    }
}