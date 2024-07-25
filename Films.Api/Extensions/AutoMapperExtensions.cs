using course_backend.Utilities;

namespace course_backend.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        }
     }
}
