using course_backend.Interfaces.Repositories;
using course_backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace course_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository _inMemoryRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IRepository inMemoryRepository)
        {
            _logger = logger;
            _inMemoryRepository = inMemoryRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var gendersList = _inMemoryRepository.GetAllGenders();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
