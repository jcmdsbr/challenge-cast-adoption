using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Core;
using SGA.Application.Repository;
using SGA.Infra.Repository.Context;
using SGA.Infra.Repository.Repository;
using SGA.Infra.Repository.UoW;

namespace SGA.Infra.CrossCutting.IoC
{
    internal static class RepositoryDependencyResolver
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)

        {
            services.AddScoped<IPetRepository, PetRepository>();

            services.AddScoped<IResponsibleRepository, ResponsibleRepository>();

            services.AddScoped<IAdoptionRepository, AdoptionRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<SgaContext>();
        }
    }
}