using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Domain.Adoption;
using SGA.Application.Domain.Pet;
using SGA.Application.Domain.Responsible;
using SGA.Domain.Adoption.Commands;
using SGA.Domain.Pet.Commands;
using SGA.Domain.Responsible.Commands;
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