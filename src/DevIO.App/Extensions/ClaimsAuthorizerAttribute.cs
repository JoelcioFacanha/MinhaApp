using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevIO.App.Extensions
{
    public class ClaimsAuthorizerAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizerAttribute(string claimName, string claimValue)
            : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }
}
