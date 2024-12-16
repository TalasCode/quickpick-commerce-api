using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceAPI.Service.Attribute
{
    public static class ClaimsPrincipalExtensions
    {
        public static string FindFirstValue(this ClaimsPrincipal principal, string claimType)

        {
            var claim = principal?.FindFirst(claimType);
            return claim?.Value;

        }
    }
}
