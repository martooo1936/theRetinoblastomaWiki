using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TheRetinoblastomaWiki.Server.Data;

namespace TheRetinoblastomaWiki.Server.Infrastructure.Extensions
{
    public static class ApplicatioBuilderExtentions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
        =>
            app
                 .UseSwagger()
                 .UseSwaggerUI(options =>
                 {
                     options.SwaggerEndpoint("/swagger/v1/swagger.json", "RB WIKI V1");
                     options.RoutePrefix = string.Empty;
                 });
        
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

           var dbContext = services.ServiceProvider.GetService<TheRetinoblastomaWikiDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
