using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TheRetinoblastomaWiki.Server.Data;
using TheRetinoblastomaWiki.Server.Data.Models;
using TheRetinoblastomaWiki.Server.Features.Identity;
using TheRetinoblastomaWiki.Server.Features.Patients;
using TheRetinoblastomaWiki.Server.Infrastructure.Filters;

namespace TheRetinoblastomaWiki.Server.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {


        public static AppSettings GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<AppSettings>();


        }
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDbContext<TheRetinoblastomaWikiDbContext>(options => options
                    .UseSqlServer(configuration.GetDefaultConnectionString()));


        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {

            services
                .AddIdentity<User, IdentityRole>(options => {

                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<TheRetinoblastomaWikiDbContext>();

            // return services as I want to have chainable services 
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, AppSettings appSettings)
        {

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        => services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IPatientService, PatientService>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            =>
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1",
                        new OpenApiInfo 
                        {
                            Title = "My RB Wiki API", 
                            Version = "v1"
                        });
                });
            

        public static void AddApiControllers(this IServiceCollection services)
            => services
            .AddControllers(options => options
            .Filters
            .Add<ModelOrNotFoundActionFilter>());

    }
}
