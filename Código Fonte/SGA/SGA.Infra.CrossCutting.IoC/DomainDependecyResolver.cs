using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Domain.Commands;
using SGA.Application.Domain.Queries;
using SGA.Domain.Commands;
using SGA.Infra.Repository.Repository;

namespace SGA.Infra.CrossCutting.IoC
{
    internal class DomainDependecyResolver
    {
        public DomainDependecyResolver(IServiceCollection services)
        {
            // Pet
            services.AddScoped<IPetQuery, PetRepository>();
            services.AddScoped<IRegisterNewPetCommand, RegisterNewPetCommand>();

            // Responsible
            services.AddScoped<IResponsibleQuery, ResponsibleRepository>();
            services.AddScoped<IRegisterNewResponsibleCommand, RegisterNewResponsibleCommand>();

            // Adoption
            services.AddScoped<IAdoptionQuery, AdoptionRepository>();
            services.AddScoped<IRegisterNewAdoptionCommand, RegisterNewAdoptionCommand>();
        }
    }
}