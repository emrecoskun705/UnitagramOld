using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using Unitagram.Application.Exceptions;

namespace Unitagram.WebAPI.Controllers;

/// <summary>
/// Controller extension
/// </summary>
public static class ControllerExtensions
{
    /// <summary>
    /// Return OkObjectResult if result is succeeded
    /// </summary>
    /// <param name="result">Success or exception result parameter</param>
    /// <param name="context">HttpContext for getting requestUrl</param>
    /// <typeparam name="TResult">Return type of Action and request type</typeparam>
    /// <returns>Returns ActionResult</returns>
    public static ActionResult<TResult> ToOk<TResult>(this Result<TResult> result, HttpContext context)
    {
        var request = context.Request;
        var requestUrl = $"{request.Path}{request.QueryString}";

        return result.Match<ActionResult<TResult>>(
            obj => new OkObjectResult(obj),
            exception => HandleException<TResult>(exception, requestUrl)
        );
    }
    
    private static ActionResult<TResult> HandleException<TResult>(Exception exception, string requestUrl)
    {
        // Define a dictionary to map exception types to status codes
        var statusCodeMap = new Dictionary<Type, int>
        {
            { typeof(ValidationException), 400 },
            { typeof(BadRequestException), 400 },
            { typeof(NotFoundException), 404 }
        };

        // Get the status code from the dictionary, defaulting to 500 if not found
        var statusCode = statusCodeMap.TryGetValue(exception.GetType(), out var code) ? code : 500;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Type = exception.GetType().Name,
            Detail = exception.Message,
            Instance = requestUrl
        };

        // Use a single switch statement to determine the result
        return exception switch
        {
            ValidationException or BadRequestException => new BadRequestObjectResult(problemDetails),
            NotFoundException => new NotFoundObjectResult(problemDetails),
            _ => new StatusCodeResult(statusCode)
        };
    }
}