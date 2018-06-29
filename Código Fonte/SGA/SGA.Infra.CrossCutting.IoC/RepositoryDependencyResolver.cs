using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Repository.Adoption;
using SGA.Application.Repository.Core;
using SGA.Application.Repository.Pet;
using SGA.Application.Repository.Responsible;
using SGA.Infra.Repository.Context;
using SGA.Infra.Repository.Repository;
using SGA.Infra.Repository.UoW;

namespace SGA.Infra.CrossCutting.IoC
{
    internal static class RepositoryDependencyResolver
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IPetRepository, PetRepository>();

            services.AddScoped<IResponsibleRepository, ResponsibleRepository>();

            services.AddScoped<IAdoptionRepository, AdoptionRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<SgaContext>();
        }
    }
}