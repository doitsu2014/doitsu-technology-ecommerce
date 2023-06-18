using Api.Models;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Optional;

namespace Api.Extensions;

public static class ApiExtension
{
    public static IActionResult ToActionResult<T>(this Option<T> data, string message = "")
    {
        return data.Match<IActionResult>(resp => new ObjectResult(new ApiResponseWithMessageModel<T>(resp, message)
            {
                Message = message
            }),
            () => new ObjectResult(new NotFoundResult())
        );
    }

    public static IActionResult ToActionResult<T>(this Option<T, ErrorResult> data, string message = "")
    {
        return data.Match<IActionResult>(resp => new ObjectResult(new ApiResponseWithMessageModel<T>(resp, message)
            {
                Message = message
            }),
            error => new ObjectResult(new ApiResponseWithMessageModel(error.ErrorMessage))
            {
                StatusCode = (int) error.StatusCode
            });
    }
}