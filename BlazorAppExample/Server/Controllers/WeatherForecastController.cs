using BlazorAppExample.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace BlazorAppExample.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private HttpClient Http;
        private WeatherForecast[] forecasts;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, HttpClient http)
        {
            _logger = logger;
            Http = http;

		}

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
			try
			{
				forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("GetWeatherForecast");
                return forecasts;
			}
			catch (AccessTokenNotAvailableException exception)
			{
				exception.Redirect();
                return Enumerable.Empty<WeatherForecast>();
			}
        }
    }
}