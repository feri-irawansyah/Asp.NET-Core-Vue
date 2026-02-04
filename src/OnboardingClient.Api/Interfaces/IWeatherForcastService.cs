namespace OnboardingClient.Api.Interfaces
{
    public interface IWeatherForcastService
    {
        Task<List<WeatherForcastView>> GetWeatherForcast();
    }
}
