class WeatherHandler
{
    internal static async Task<IResult> GetWeatherForcast(IWeatherForecastService service)
    {
        try
        {
            var data = await service.GetWeatherForcast();
            return Results.Ok(new ApiOkResponse<List<WeatherForecastView>> { Data = data });
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("not_found"))
                return Results.NotFound(new ApiErrResponse<string> { Error = ex.Message });

            return Results.Problem(
                title: "Internal Server Error",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }

    internal static async Task<IResult> CreateWeather(
        WeatherForecastCmd cmd,
        IWeatherForecastService service,
        IValidator<WeatherForecastCmd> validator
    )
    {
        try
        {
            var validation = await validator.ValidateAsync(cmd);

            if (!validation.IsValid)
                return Results.BadRequest(
                    new ApiErrResponse<List<string>>
                    {
                        Error = validation.Errors.Select(e => e.ErrorMessage).ToList(),
                    }
                );

            var data = await service.CreateWeather(cmd);
            return Results.Ok(new ApiOkResponse<WeatherForecastView> { Data = data });
        }
        catch (Exception ex)
        {
            return Results.Problem(
                title: "Internal Server Error",
                detail: ex.Message,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
}
