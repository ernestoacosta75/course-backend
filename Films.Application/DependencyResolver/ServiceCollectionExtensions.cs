using Films.Application.Services.Gender;
using Microsoft.Extensions.DependencyInjection;

namespace Films.Application.DependencyResolver
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IGenderService, GenderService>();
        }
    }
}
