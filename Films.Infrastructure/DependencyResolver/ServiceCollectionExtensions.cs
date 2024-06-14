using Films.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Films.Domain.DependencyResolver;

namespace Films.Infrastructure.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
