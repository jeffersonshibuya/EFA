using System.Security.Claims;

namespace Efa.Infra.CrossCutting.AspNetIdentity.Providers
{
    public class ExtendedClaimsProvider
    {
        public static Claim CreateClaim(string type, string value)
        {
            return new Claim(type, value, ClaimValueTypes.String);
        }
    }
}