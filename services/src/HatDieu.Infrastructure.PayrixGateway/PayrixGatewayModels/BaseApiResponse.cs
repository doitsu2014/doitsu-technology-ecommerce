namespace HatDieu.Infrastructure.PayrixGateway.PayrixGatewayModels;

public class BaseApiResponse<T>
{
    public string Message { get; set; } = string.Empty;
    public T Data { get; set; }
}