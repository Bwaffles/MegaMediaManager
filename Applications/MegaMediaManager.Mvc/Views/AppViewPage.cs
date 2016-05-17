using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MegaMediaManager.Model;
using System.Security.Claims;

namespace MegaMediaManager.Mvc
{
    public abstract class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUserPrincipal CurrentUser
        {
            get { return new AppUserPrincipal(this.User as ClaimsPrincipal); }
        }
    }
    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}