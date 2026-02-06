namespace OnboardingClient.Api.Features.Weather;

public class WeatherFeature : IExposedFeature
{
    public virtual void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IWeatherForecastService>(sp =>
        {
            var context = sp.GetRequiredService<BrokerIdContext>();
            return context.HasService("Weather.CP")
                ? new CPWeatherService()
                : new WeatherForecastService();
        });

        services.AddValidatorsFromAssembly(typeof(WeatherForecastCmdValidator).Assembly);
    }

    public void ConfigureEndpoints(IEndpointRouteBuilder endpoint)
    {
        var app = endpoint.MapGroup("/weather").WithOpenApi().WithTags("Weather");

        app.MapGet("/list", WeatherHandler.GetWeatherForcast)
            .WithName("Weather")
            .Produces<ApiOkResponse<List<WeatherForecastView>>>(StatusCodes.Status200OK)
            .Produces<ApiErrResponse<string>>(StatusCodes.Status500InternalServerError);

        app.MapPost("/create", WeatherHandler.CreateWeather)
            .WithName("CreateWeather")
            .Produces<ApiOkResponse<WeatherForecastView>>(StatusCodes.Status200OK)
            .Produces<ApiErrResponse<List<string>>>(StatusCodes.Status400BadRequest)
            .Produces<ApiErrResponse<string>>(StatusCodes.Status500InternalServerError);
    }
}
