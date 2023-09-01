using System.Collections.Immutable;
using FluentValidation.Results;

namespace Unitagram.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
        ValidationErrors = ImmutableDictionary<string, string[]>.Empty;
    }

    public BadRequestException(string message, ValidationResult validationResult) : base(message)
    {
        ValidationErrors = validationResult.ToDictionary();
    }

    public IDictionary<string, string[]> ValidationErrors { get; set; }
}