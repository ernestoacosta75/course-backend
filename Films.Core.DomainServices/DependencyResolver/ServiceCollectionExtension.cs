using Films.Core.DomainServices.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Films.Core.DomainServices.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var isHomeConnection = configuration.GetValue<bool>("isHomeConnection");

            string? connectionString = isHomeConnection ?
                configuration.GetConnectionString("DefaultConnection") :
                configuration.GetConnectionString("VdiConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No connection string found in configuration.");
            }

            services.AddDbContext<FilmsDbContext>(options =>
                options.UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Warning),
                ServiceLifetime.Scoped);
        }
    }
}
