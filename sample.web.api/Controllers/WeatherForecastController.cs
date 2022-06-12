using Microsoft.AspNetCore.Mvc;
using sample.web.api.extensions;

namespace sample.web.api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{


    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IGetWeatherService getWeatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IGetWeatherService getWeatherService)
    {
        _logger = logger;
        this.getWeatherService = getWeatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get(string searchKeyWord)
    {
        var results = await getWeatherService.GetWeatherAsync(searchKeyWord);
        return Ok(results);

    }
    [HttpGet]
    [Route("GetWeatherForecast_2")]
    public async Task<IActionResult> Get_2(string searchKeyWord)
    {
        var results = await getWeatherService.GetWeatherReturnResultsAsync(searchKeyWord);
        return results.ToActionResult();
    }
}
