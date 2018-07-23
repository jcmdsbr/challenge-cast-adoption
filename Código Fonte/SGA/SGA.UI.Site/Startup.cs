using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGA.Infra.CrossCutting.IoC;
using SGA.UI.Site.Configurations;

namespace SGA.UI.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Sga Context
            services.AddSgaContext(Configuration);

            // Identity Context
            services.AddIdentityContext(Configuration);

            // ConnectionFactory for dapper
            services.AddConnectionFactory(Configuration);

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