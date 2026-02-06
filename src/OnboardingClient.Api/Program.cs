using OnboardingClient.Api.Common;
using OnboardingClient.Api.Features.Weather;

var builder = WebApplication.CreateBuilder(args);

var brokerId = builder.Configuration["BrokerId"] ?? "Default";

var brokerServices = builder.Configuration.GetSection("BrokerService").Get<string[]>() ?? [];

Console.WriteLine($"BrokerId = {brokerId}");
Console.WriteLine($"BrokerServices = {string.Join(", ", brokerServices)}");

builder.Services.AddSingleton(new BrokerIdContext(brokerId, brokerServices));

// 🔥 Controllers (WAJIB)
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔥 Dependency Injection
var services = builder.Services;

List<IExposedFeature> features = [new WeatherFeature()];

foreach (var feature in features)
{
    feature.ConfigureServices(services, builder.Configuration);
}

var app = builder.Build();

foreach (var feature in features)
{
    feature.ConfigureEndpoints(app);
}

app.MapGet(
    "/",
    () =>
    {
        return Results.Ok(
            new
            {
                AppName = "Custommer Onboarding App",
                BrokerId = brokerId,
                BrokerServices = brokerServices,
            }
        );
    }
);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();

public partial class Program { }
