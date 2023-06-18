using System.Net;

namespace ApplicationCore.Models;

public class ErrorResult
{
    public ErrorResult()
    {
    }

    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; }

    public static ErrorResult CreateNotFoundObj(string errorMessage = default)
    {
        return new ErrorResult()
        {
            StatusCode = (int) HttpStatusCode.NotFound,
            ErrorMessage = errorMessage
        };
    }

    public static ErrorResult CreateBadRequestObj(string errorMessage = default)
    {
        return new ErrorResult()
        {
            StatusCode = (int) HttpStatusCode.BadRequest,
            ErrorMessage = errorMessage
        };
    }
}