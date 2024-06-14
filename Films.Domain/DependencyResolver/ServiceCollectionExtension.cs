using Films.Domain.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Films.Domain.DependencyResolver
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
                options.UseSqlServer(connectionString));
        }
    }
}
