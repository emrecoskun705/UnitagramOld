using System.Collections.Immutable;
using FluentValidation.Results;
using Unitagram.Application.Helpers;

namespace Unitagram.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(ValidationResult validationResult) : base(validationResult.ToFormattedString())
    {
    }
    
}