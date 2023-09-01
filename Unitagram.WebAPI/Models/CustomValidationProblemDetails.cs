using Microsoft.AspNetCore.Mvc;

namespace Unitagram.WebAPI.Models;

/// <summary>
/// Custom Validation problem details
/// </summary>
public class CustomProblemDetails : ProblemDetails
{
    /// <summary>
    /// Stores errors
    /// </summary>
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}