using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using Unitagram.Application.Exceptions;
using Unitagram.Application.Models.Identity.Authentication;
using Unitagram.WebAPI.Models;

namespace Unitagram.WebAPI.Controllers;

/// <summary>
/// Controller extension
/// </summary>
public static class ControllerExtensions
{
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
        var statusCode = exception switch
        {
            ValidationException validationException => 400,
            BadRequestException badRequestException => 400,
            NotFoundException notFoundException => 404,
            _ => 500
        };

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Type = exception.GetType().Name,
            Detail = exception.Message,
            Instance = requestUrl
        };

        return exception switch
        {
            ValidationException or BadRequestException => new BadRequestObjectResult(problemDetails),
            NotFoundException => new NotFoundObjectResult(problemDetails),
            _ => new StatusCodeResult(statusCode)
        };
    }
}