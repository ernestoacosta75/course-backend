
using course_backend.Filters;
using course_backend_data_access;
using course_backend_implementations.Services;
using course_backend_interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

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

            // Configuring AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            // DbContext Configuration
            var isHomeConnection = configuration.GetValue<bool>("isHomeConnection");
            string? connectionString =  isHomeConnection ? 
                configuration.GetConnectionString("DefaultConnection") :
                configuration.GetConnectionString("VdiConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No connection string found in configuration.");
            }
            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(configuration.GetValue<string>("frontend_url") ?? string.Empty)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IGenderService, GenderService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            //builder.Services.AddResponseCaching();

            // Add services to the container.

            //builder.Services.AddTransient<IRepository, InMemoryRepository>();
            //builder.Services.AddTransient<CustomActionFilter>();
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //app.UseMiddleware<LoggingMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            //app.UseResponseCaching();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
