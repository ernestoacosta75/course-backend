
using Castle.DynamicProxy;
using course_backend.Extensions;
using course_backend.Filters;
using course_backend_aop.Aspects;
using course_backend_data_access;
using course_backend_implementations.Services;
using course_backend_interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace course_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuration
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .Build();

            // Enable logging for EF Core
            builder.Logging.AddConsole();

            // Custom services
            builder.Services.AddCustomServices(configuration);

            builder.Services.AddSingleton(new ProxyGenerator());
            builder.Services.AddScoped<IInterceptor, LoggingInterceptor>();
            builder.Services.AddScoped<IInterceptor, CachingInterceptor>();

            builder.Services.AddProxiedScoped<IGenderService, GenderService>();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            });

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
