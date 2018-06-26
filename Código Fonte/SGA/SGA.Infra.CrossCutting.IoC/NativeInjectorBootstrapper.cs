using Microsoft.Extensions.DependencyInjection;

namespace SGA.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            new DomainDependecyResolver(services);
            new RepositoryDependencyResolver(services);
        }
    }
}