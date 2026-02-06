using OnboardingClient.Api.Interfaces;

class WeatherHandler
{
    internal static async Task<IResult> GetWeatherForcast(IWeatherForcastService service)
    {
        try
        {
            var data = await service.GetWeatherForcast();
            return Results.Ok(new { data });
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("not_found"))
                return Results.NotFound(new { error = ex.Message });

            return Results.Problem(
                title: "Internal Server Error",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
}
