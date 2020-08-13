using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheRetinoblastomaWiki.Server.Data;

namespace TheRetinoblastomaWiki.Server.Infrastructure
{
    public static class ApplicatioBuilderExtentions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

           var dbContext = services.ServiceProvider.GetService<TheRetinoblastomaWikiDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
