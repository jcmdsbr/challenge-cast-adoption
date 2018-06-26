using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SGA.Infra.CrossCutting.IoC;
using SGA.UI.Site.Configurations;

namespace SGA.UI.Site
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvcWithCustomJson();

            services.AddResponseCaching();

            NativeInjectorBootstrapper.RegisterServices(services);
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
            app.UseResponseCaching();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
