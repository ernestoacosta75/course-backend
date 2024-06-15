using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Films.Core.DomainServices.DependencyResolver;
using Films.Core.DomainServices.Repositories;
using Castle.DynamicProxy;
using Films.Infrastructure.Aspects;

namespace Films.Infrastructure.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddSingleton(new ProxyGenerator());
            services.AddScoped<IInterceptor, LoggingInterceptor>();
            services.AddScoped<IInterceptor, CachingInterceptor>();
        }
    }
}
