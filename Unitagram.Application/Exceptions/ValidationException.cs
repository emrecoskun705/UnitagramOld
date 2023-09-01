using FluentValidation.Results;
using Unitagram.Application.Helpers;

namespace Unitagram.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(ValidationResult validationResult) : base(validationResult.ToFormattedString())
    {
    }
    
    public ValidationException(string message) : base(message)
    {
    }
    
}