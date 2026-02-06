namespace OnboardingClient.Api.Services.Weather;

public class CPWeatherService : IWeatherForecastService
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
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] + "-CP",
            })
            .ToList();

        return Task.FromResult(data);
    }

    public Task<WeatherForecastView> CreateWeather(WeatherForecastCmd cmd)
    {
        var data = new WeatherForecastView
        {
            Date = cmd.Date,
            TemperatureC = cmd.TemperatureC,
            Summary = cmd.Summary,
        };

        return Task.FromResult(data);
    }
}
