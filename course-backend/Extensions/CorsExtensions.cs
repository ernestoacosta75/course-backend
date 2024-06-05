namespace course_backend.Extensions
{
    public static class CorsExtensions
    {
        public static void AddCustomCors(this IServiceCollection services, string frontendUrl)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontendUrl)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
    }
}
