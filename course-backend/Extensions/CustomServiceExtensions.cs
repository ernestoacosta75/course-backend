using course_backend_data_access;
using course_backend_interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace course_backend.Extensions
{
    public static class CustomServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            // AutoMapper
            services.AddCustomAutoMapper();

            // CORS
            string frontendUrl = configuration.GetValue<string>("frontend_url") ?? string.Empty;
            services.AddCustomCors(frontendUrl);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        }
    }
}
