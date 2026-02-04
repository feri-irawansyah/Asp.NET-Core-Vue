using OnboardingClient.Api.Interfaces;
using OnboardingClient.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Controllers (WAJIB)
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔥 Dependency Injection
builder.Services.AddScoped<IWeatherForcastService, WeatherForcastService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔥 Map Controllers
app.MapControllers();

app.Run();
