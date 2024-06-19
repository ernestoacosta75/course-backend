using course_backend.Extensions;
using course_backend.Filters;
using Films.Core.Application.DependencyResolver;
using Films.Infrastructure.DependencyResolver;
using Serilog;

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
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .Build();

            // Enable logging for EF Core
            //builder.Logging.AddConsole(options =>
            //{
            //    options.Format = Microsoft.Extensions.Logging.Console.ConsoleLoggerFormat.Default;
            //    options.IncludeScopes = true; // Include scopes if needed
            //    options.LogToStandardErrorThreshold = LogLevel.Information;
            //});

            //// Configure logging to file
            //builder.Logging.AddFile("app.log", options =>
            //{
            //    options.FileSizeLimitBytes = 10 * 1024 * 1024; // 10 MB file size limit
            //    options.RetainedFileCountLimit = 5; // Keep up to 5 log files
            //    options.LogLevel = LogLevel.Information; // Minimum log level for file logging
            //});

            // Configure Serilog for logging to console and file
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
  
            builder.Logging.AddSerilog();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            });

            // Register IMemoryCache
            builder.Services.AddMemoryCache();

            builder.Services.AddCustomAutoMapper();

            // Custom services
            builder.Services.AddCustomSwagger();
            builder.Services.AddCustomCors(configuration.GetValue<string>("frontend_url") ?? string.Empty);
            builder.Services.AddInfrastructure(configuration);
            // builder.Services.AddProxiedScoped<IGenderService, GenderService>();
            builder.Services.AddApplication();

            
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

            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application startup failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
