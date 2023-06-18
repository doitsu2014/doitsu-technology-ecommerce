namespace HatDieu.Api.Models;

public class ApiResponseWithMessageModel : BaseApiResponseModel
{
    public ApiResponseWithMessageModel(string message) : base()
    {
        Message = message;
    }

    public string Message { get; set; }

    public static ApiResponseWithMessageModel SpawnBasicObj(string message)
    {
        return new ApiResponseWithMessageModel(message);
    }
}

public class ApiResponseWithMessageModel<T> : BaseApiResponseModel<T>
{
    public ApiResponseWithMessageModel(T data, string message) : base(data)
    {
        Message = message;
    }

    public string Message { get; set; }
}