using Microsoft.Extensions.Configuration;

namespace TheRetinoblastomaWiki.Server.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");

    }
}
