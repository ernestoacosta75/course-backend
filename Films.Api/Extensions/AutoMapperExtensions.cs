using AutoMapper;
using course_backend.Utilities;
using NetTopologySuite.Geometries;

namespace course_backend.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddSingleton(provider =>
            {
                var geometryFactory = provider.GetRequiredService<GeometryFactory>();

                // Create MapperConfiguration
                var mapperConfiguration = new MapperConfiguration(config =>
                {
                    config.AddProfile(new AutoMapperProfiles(geometryFactory));
                });

                // Return an instance of IMapper using the configuration
                return mapperConfiguration.CreateMapper();
            });
        }
     }
}
