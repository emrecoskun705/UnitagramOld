using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Unitagram.Application.Exceptions;
using Unitagram.WebAPI.Models;

namespace Unitagram.WebAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        ProblemDetails problem = new();
        problem = new ProblemDetails()
        {
            Title = ex.Message,
            Status = (int)statusCode,
            Type = nameof(HttpStatusCode.InternalServerError),
            Detail = ex.StackTrace,
        };


        httpContext.Response.StatusCode = (int)statusCode;
        var logMessage = JsonConvert.SerializeObject(problem);
        _logger.LogError(logMessage);
        await httpContext.Response.WriteAsJsonAsync(problem);
    }
}