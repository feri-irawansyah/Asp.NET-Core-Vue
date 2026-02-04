using Microsoft.AspNetCore.Mvc;
using OnboardingClient.Api.Handlers;
using OnboardingClient.Api.Interfaces;

namespace OnboardingClient.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForcastController(IWeatherForcastService service) : ControllerBase
{
    private readonly IWeatherForcastService _service = service;

    [HttpGet("list")]
    public async Task<IActionResult> GetWeatherForcast()
    {
        var result = await WeatherForcastHandler.GetWeatherForcast(_service);

        return result;
    }
}
