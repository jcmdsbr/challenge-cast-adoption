using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SGA.Application.Core;
using SGA.Infra.CrossCutting.Identity.Context;
using SGA.Infra.CrossCutting.Identity.Models;
using SGA.Infra.Dapper.Core;
using SGA.Infra.Repository.Context;

namespace SGA.UI.Site.Configurations
{
    public static class ServiceExtensions
    {
        public static void AddMvcWithCustomJson(this IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
        }

        public static void AddSgaContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SgaContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddConnectionFactory(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IConnectionFactory>(x =>
                new ConnectionFactory(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureIdentityOptions(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
            });
        }

        public static void AddIdentityContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SgaIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SgaIdentityDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}