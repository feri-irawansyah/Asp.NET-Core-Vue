using OnboardingClient.Api.Interfaces;

namespace OnboardingClient.Api.Services;

public class CPWeatherService : IWeatherForcastService
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

    public Task<List<WeatherForcastView>> GetWeatherForcast()
    {
        var data = Enumerable
            .Range(1, 5)
            .Select(index => new WeatherForcastView
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] + "-CP",
            })
            .ToList();

        return Task.FromResult(data);
    }
}
