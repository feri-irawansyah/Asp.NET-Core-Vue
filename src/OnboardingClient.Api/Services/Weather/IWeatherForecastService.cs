namespace OnboardingClient.Api.Services.Weather;

public interface IWeatherForecastService
{
    Task<List<WeatherForecastView>> GetWeatherForcast();
    Task<WeatherForecastView> CreateWeather(WeatherForecastCmd cmd)
    {
        throw new NotImplementedException("This service does not implement CreateWeather");
    }
}
