using System.Linq;
using System.Security.Claims;

namespace TheRetinoblastomaWiki.Server.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user
            .Claims
            .FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?
            .Value;
    }
}
