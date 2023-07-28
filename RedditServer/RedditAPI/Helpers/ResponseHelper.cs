using Common.Constants;
using Entities.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace RedditAPI.Helpers;

public static class ResponseHelper
{
    public static IActionResult CreateResourceResponse(object? data,
        string message = MessageConstants.GlobalCreated)
    {
        ApiResponse response = new()
        {
            StatusCode = StatusCodes.Status201Created,
            Message = message,
            Data = data,
            Success = true
        };

        return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
    }

    public static IActionResult SuccessResponse(object? data,
        string message = MessageConstants.GlobalSuccess,
        int statusCode = StatusCodes.Status200OK)
    {
        ApiResponse response = new()
        {
            StatusCode = statusCode,
            Message = message,
            Data = data,
            Success = true
        };

        return new ObjectResult(response) { StatusCode = statusCode };
    }
}
