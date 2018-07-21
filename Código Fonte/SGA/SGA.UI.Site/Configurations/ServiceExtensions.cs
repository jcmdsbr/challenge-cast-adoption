using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SGA.Infra.CrossCutting.Identity.Context;
using SGA.Infra.CrossCutting.Identity.Models;
using SGA.Infra.Repository.Context;
using System.Data.Common;

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

        public static void AddSgaContext(this IServiceCollection services, DbConnection connection)
        {
            services.AddDbContext<SgaContext>(options => options.UseSqlServer(connection));
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

        public static void AddIdentityContext(this IServiceCollection services, DbConnection connection)
        {
            services.AddDbContext<SgaIdentityDbContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SgaIdentityDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}