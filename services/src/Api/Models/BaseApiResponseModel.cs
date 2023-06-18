namespace Api.Models;

public class BaseApiResponseModel
{
    public BaseApiResponseModel()
    {
    }
}

public class BaseApiResponseModel<T> : BaseApiResponseModel
{
    public BaseApiResponseModel(T data)
    {
        this.Data = data;
    }

    public T Data { get; set; }
}