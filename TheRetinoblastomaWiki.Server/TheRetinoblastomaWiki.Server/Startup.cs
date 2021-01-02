
namespace TheRetinoblastomaWiki.Server
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using TheRetinoblastomaWiki.Server.Infrastructure;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        => services
                .AddDbContext<TheRetinoblastomaWikiDbContext>(options => options
                .UseSqlServer(this.Configuration.GetDefaultConnectionString()))
                .AddIdentity()
                .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddControllers();

            #region refactoring 
            /*
            //services
            //    .AddIdentity<User, IdentityRole>(options => {

            //        options.Password.RequireDigit = false;
            //        options.Password.RequireLowercase = false;
            //        options.Password.RequireNonAlphanumeric = false;
            //        options.Password.RequireUppercase = false;
            //        options.Password.RequiredLength = 6;
            //    })
            //    .AddEntityFrameworkStores<TheRetinoblastomaWikiDbContext>();

            ///////////////////////////////
            //JWT Authentication v1 start//
            //////////////////////////////
           // var appSettingsConfiguration = this.Configuration.GetSection("ApplicationSettings");
           // services.Configure<AppSettings>(appSettingsConfiguration);

           // var appSettings = appSettingsConfiguration.Get<AppSettings>();
           // var key = Encoding.ASCII.GetBytes(appSettings.Secret);

           // services.AddAuthentication(x =>
           //{
           //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           //})
           // .AddJwtBearer(x =>
           // {
           //     x.RequireHttpsMetadata = false;
           //     x.SaveToken = true;
           //     x.TokenValidationParameters = new TokenValidationParameters
           //     {
           //         ValidateIssuerSigningKey = true,
           //         IssuerSigningKey = new SymmetricSecurityKey(key),
           //         ValidateIssuer = false,
           //         ValidateAudience = false
           //     };
           // });
            /////////////////////////////
            //JWT Authentication v1 end//
            ////////////////////////////
            ///
            */
            //services.AddControllers();
            #endregion
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            
            
            app.UseRouting()
               .UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            })
            .ApplyMigrations();
        }
    }
}
