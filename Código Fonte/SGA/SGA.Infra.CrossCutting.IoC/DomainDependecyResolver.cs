using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Domain.Adoption;
using SGA.Application.Domain.Pet;
using SGA.Application.Domain.Responsible;
using SGA.Infra.Repository.Repository;

namespace SGA.Infra.CrossCutting.IoC
{
    internal class DomainDependecyResolver
    {
        public DomainDependecyResolver(IServiceCollection services)
        {
            // Pet
            services.AddScoped<IPetQuery, PetRepository>();

            // Responsible
            services.AddScoped<IResponsibleQuery, ResponsibleRepository>();

            // Adoption
            services.AddScoped<IAdoptionQuery, AdoptionRepository>();
        }
    }
}