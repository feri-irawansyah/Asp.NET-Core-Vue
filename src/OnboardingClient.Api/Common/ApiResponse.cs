namespace OnboardingClient.Api.Common;

public class ApiOkResponse<T>
{
    public T? Data { get; set; }
}

public class ApiErrResponse<T>
{
    public T? Error { get; set; }
}
