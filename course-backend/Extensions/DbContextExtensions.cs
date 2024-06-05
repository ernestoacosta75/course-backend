using course_backend_data_access;
using Microsoft.EntityFrameworkCore;

namespace course_backend.Extensions
{
    public static class DbContextExtensions
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var isHomeConnection = configuration.GetValue<bool>("isHomeConnection");
            string? connectionString = isHomeConnection ?
                configuration.GetConnectionString("DefaultConnection") :
                configuration.GetConnectionString("VdiConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No connection string found in configuration.");
            }

            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
