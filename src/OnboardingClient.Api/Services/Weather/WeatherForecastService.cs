namespace OnboardingClient.Api.Services.Weather;

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries =
    [
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching",
    ];

    public Task<List<WeatherForecastView>> GetWeatherForcast()
    {
        var data = Enumerable
            .Range(1, 5)
            .Select(index => new WeatherForecastView
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToList();

        return Task.FromResult(data);
    }
}
