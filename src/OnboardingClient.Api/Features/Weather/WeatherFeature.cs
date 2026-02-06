using OnboardingClient.Api.Common;
using OnboardingClient.Api.Interfaces;
using OnboardingClient.Api.Services;

namespace OnboardingClient.Api.Features.Weather;

public class WeatherFeature : IExposedFeature
{
    public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IWeatherForcastService>(sp =>
        {
            var ctx = sp.GetRequiredService<BrokerIdContext>();

            return ctx.Services.Contains("Weather.CP")
                ? new CPWeatherService()
                : new WeatherForcastService();
        });
    }

    public void ConfigureEndpoints(IEndpointRouteBuilder endpoint)
    {
        var app = endpoint.MapGroup("/weather").WithOpenApi().WithTags("Weather");

        app.MapGet("/list", WeatherHandler.GetWeatherForcast)
            .WithName("Weather")
            .Produces<List<WeatherForcastView>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status500InternalServerError);
    }
}
