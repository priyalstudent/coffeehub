using Microsoft.AspNetCore.Mvc;

namespace CoffeeHub.Api.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public WeatherController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var apiKey = _configuration["Weather:ApiKey"];
            var url = $"https://api.shecodes.io/weather/v1/current?query={city}&key={apiKey}&units=metric";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return BadRequest("Could not fetch weather data");

            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
    }
}