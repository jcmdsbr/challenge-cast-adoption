using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SGA.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        protected NativeInjectorBootstrapper()
        {
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            DomainDependecyResolver.Register(services);
            RepositoryDependencyResolver.Register(services, configuration);
        }
    }
}