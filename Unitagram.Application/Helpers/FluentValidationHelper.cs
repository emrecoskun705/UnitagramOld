using FluentValidation.Results;

namespace Unitagram.Application.Helpers;

public static class FluentValidationHelper
{
    public static string ToFormattedString(this ValidationResult validationResult, string delimiter = "|")
    {
        return string.Join(delimiter, validationResult.Errors.Select(error => error.ErrorMessage));
    }
}