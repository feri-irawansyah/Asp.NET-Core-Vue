using Microsoft.AspNetCore.Mvc;
using OnboardingClient.Api.Interfaces;

namespace OnboardingClient.Api.Handlers;

public static class WeatherForcastHandler
{
    internal static async Task<IActionResult> GetWeatherForcast(IWeatherForcastService service)
    {
        try
        {
            var data = await service.GetWeatherForcast();
            return new OkObjectResult(new { data });
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("not_found"))
                return new NotFoundObjectResult(new { error = ex.Message });
            return new ObjectResult(new { error = $"Internal Server Error : {ex.Message}" })
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
