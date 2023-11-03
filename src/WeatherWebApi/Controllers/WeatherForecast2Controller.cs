using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement.Mvc;

namespace WeatherWebApi.Controllers;

[ApiController]
[Route("[controller]")]
[FeatureGate("WeatherForecast")]
public class WeatherForecast2Controller : ControllerBase
{
    private readonly WeatherService _service;
    private readonly ILogger<WeatherForecast2Controller> _logger;

    public WeatherForecast2Controller(WeatherService service, ILogger<WeatherForecast2Controller> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast2")]
    [FeatureGate("WeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return _service.Get();
    }
}
