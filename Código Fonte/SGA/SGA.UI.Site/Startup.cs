using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGA.Infra.CrossCutting.IoC;
using SGA.UI.Site.Configurations;
using System.Data.Common;
using System.Data.SqlClient;

namespace SGA.UI.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public DbConnection DbConnection => new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));
        public void ConfigureServices(IServiceCollection services)
        {
            // Sga Context
            services.AddSgaContext(DbConnection);

            // Identity Context
            services.AddIdentityContext(DbConnection);

            //  Shared Connection String for dapper
            services.AddScoped((conn) => DbConnection);

            // Configure cookie and route login
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "SgaCookie";
                options.LoginPath = "/User/Login";
            });

            services.ConfigureIdentityOptions();

            services.AddMvcWithCustomJson();

            services.AddResponseCaching();

            NativeInjectorBootstrapper.RegisterServices(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseResponseCaching();
            app.UseMvcWithDefaultRoute();
        }
    }
}