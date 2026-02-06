public class WeatherForecastView
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class WeatherForecastCmd
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}

public class WeatherForecastCmdValidator : AbstractValidator<WeatherForecastCmd>
{
    public WeatherForecastCmdValidator()
    {
        RuleFor(x => x.Summary).NotEmpty().MaximumLength(100);
        RuleFor(x => x.TemperatureC).InclusiveBetween(-50, 60);
    }
}
