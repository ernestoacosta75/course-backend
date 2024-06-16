using course_backend.Extensions;
using course_backend.Filters;
using Films.Application.DependencyResolver;
using Films.Infrastructure.DependencyResolver;
using Films.Core.Application.Services.Gender;

namespace course_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Getting configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            // Enable logging for EF Core
            builder.Logging.AddConsole();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            });

            // Register IMemoryCache
            builder.Services.AddMemoryCache();

            builder.Services.AddCustomAutoMapper();

            // Custom services
            builder.Services.AddCustomSwagger();
            builder.Services.AddInfrastructure(configuration);
            builder.Services.AddProxiedScoped<IGenderService, GenderService>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
