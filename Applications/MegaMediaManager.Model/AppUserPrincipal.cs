using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace MegaMediaManager.Model
{
    public class AppUserPrincipal : ClaimsPrincipal
    {
        public AppUserPrincipal(ClaimsPrincipal principal)
            : base(principal)
        {

        }

        public string Name { get { return this.FindFirst(ClaimTypes.Name).Value; } }
    }
}
