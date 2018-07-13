using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Domain.Commands;
using SGA.Application.Domain.Queries;
using SGA.Domain.Commands;
using SGA.Infra.Dapper.Queries;

namespace SGA.Infra.CrossCutting.IoC
{
    internal static class DomainDependecyResolver
    {
        public static void Register(IServiceCollection services)
        {
            // Pet
            services.AddScoped<IPetQuery, PetQuery>();
            services.AddScoped<IRegisterNewPetCommand, RegisterNewPetCommand>();

            // Responsible
            services.AddScoped<IResponsibleQuery, ResponsibleQuery>();
            services.AddScoped<IRegisterNewResponsibleCommand, RegisterNewResponsibleCommand>();

            // Adoption
            services.AddScoped<IAdoptionQuery, AdoptionQuery>();
            services.AddScoped<IRegisterNewAdoptionCommand, RegisterNewAdoptionCommand>();
        }
    }
}