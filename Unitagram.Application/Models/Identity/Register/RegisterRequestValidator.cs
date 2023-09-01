using System.Text.RegularExpressions;
using FluentValidation;
using Unitagram.Application.Models.Identity.Authentication;

namespace Unitagram.Application.Models.Identity.Register;

public class RegisterRequestValidator  : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(a => a.Email)
            .EmailAddress().WithMessage("{PropertyName} should be in a proper email address format")
            .NotEmpty().WithMessage("{PropertyName} can't be blank")
            .NotNull();

        RuleFor(a => a.UserName)
            .NotEmpty().WithMessage("{PropertyName} can't be blank")
            .NotNull()
            .MinimumLength(4).WithMessage("{PropertyName} should be minimum {PropertyValue} characters long")
            .MaximumLength(15).WithMessage("{PropertyName} should be maximum of {PropertyValue} characters long")
            .Must(ValidUsername).WithMessage("Invalid {PropertyName} please change your {PropertyName}");

        RuleFor(a => a.PhoneNumber)
            .Must(OnlyDigits).WithMessage("{PropertyName} should contain only digits");

        RuleFor(a => a.Password)
            .NotEmpty().WithMessage("{PropertyName} can't be blank")
            .MinimumLength(5).WithMessage("{PropertyName} should be minimum {PropertyValue} characters long")
            .MaximumLength(50).WithMessage("{PropertyName} should be maximum of {PropertyValue} characters long");

        RuleFor(a => a.ConfirmPassword)
            .NotEmpty().WithMessage("{PropertyName} can't be blank")
            .Equal(a => a.Password).WithMessage("{PropertyName} and {ComparisonProperty} do not match");
    }

    private bool OnlyDigits(string arg)
    {
        if (Regex.IsMatch(arg, "^[0-9]*$"))
            return true;

        return false;
    }

    private bool ValidUsername(string arg)
    {
        if (Regex.IsMatch(arg, "^(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$"))
            return true;

        return false;
    }
}
