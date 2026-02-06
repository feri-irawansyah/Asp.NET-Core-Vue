namespace OnboardingClient.Api.Common;

public interface IExposedFeature
{
    void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    void ConfigureEndpoints(IEndpointRouteBuilder endpoints);
}
