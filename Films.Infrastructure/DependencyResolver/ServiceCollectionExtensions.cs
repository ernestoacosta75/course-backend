using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Films.Core.DomainServices.Repositories;
using Castle.DynamicProxy;
using Films.Core.DomainServices.DatabaseContext;
using Films.Infrastructure.Aspects;
using Films.Core.DomainServices.UnitOfWorks;
using Films.Infrastructure.UnitOfWorks;
using Films.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Films.Infrastructure.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddDatabaseContext(configuration);
            var isHomeConnection = configuration.GetValue<bool>("isHomeConnection");

            string? connectionString = isHomeConnection ?
                configuration.GetConnectionString("DefaultConnection") :
                configuration.GetConnectionString("VdiConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No connection string found in configuration.");
            }

            services.AddDbContext<FilmsDbContext>(options =>
                    options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            

            services.AddSingleton(new ProxyGenerator());
            services.AddScoped<IInterceptor, LoggingInterceptor>();
        }
    }
}
