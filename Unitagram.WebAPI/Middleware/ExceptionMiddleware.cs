namespace Unitagram.WebAPI.Middleware;

/// <summary>
/// 
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="next"></param>
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContext"></param>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
    
}