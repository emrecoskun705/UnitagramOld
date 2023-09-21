using System.Text.RegularExpressions;
using FluentValidation;
using Unitagram.Application.Contracts.Localization;
using Unitagram.Application.Models.Identity.Authentication;

namespace Unitagram.Application.Models.Identity.Register;

public class RegisterRequestValidator  : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator(ILocalizationService localization)
    {
        RuleFor(a => a.Email)
            .EmailAddress().WithMessage(localization["EmailInvalidFormat"])
            .NotEmpty().WithMessage(localization["EmailCantBlank"])
            .NotNull();

        RuleFor(a => a.UserName)
            .NotEmpty().WithMessage(localization["UsernameShouldntEmpty"])
            .NotNull()
            .MinimumLength(4).WithMessage(localization["UsernameMinLength"])
            .MaximumLength(15).WithMessage(localization["UsernameMaxLength"])
            .Must(ValidUsername).WithMessage(localization["InvalidUsername"]);

        RuleFor(a => a.PhoneNumber)
            .Must(OnlyDigits).WithMessage(localization["PhoneNumberOnlyDigit"]);

        RuleFor(a => a.Password)
            .NotEmpty().WithMessage(localization["PasswordShouldntEmpty"])
            .MinimumLength(8).WithMessage(localization["PasswordMinLength"])
            .MaximumLength(50).WithMessage(localization["PasswordMaxLength"])
            .Must(RequireUppercase).WithMessage(localization["PasswordContainUppercase"])
            .Must(RequireLowercase).WithMessage(localization["PasswordContainLowercase"]);

        RuleFor(a => a.ConfirmPassword)
            .NotEmpty().WithMessage(localization["ConfirmPasswordCantBlank"])
            .Equal(a => a.Password).WithMessage(localization["PasswordNotEquals"]);
        
    }

    private bool RequireUppercase(string args)
    {
        foreach (char c in args)
        {
            if (char.IsUpper(c))
                return true;
        }

        return false;
    }
    
    private bool RequireLowercase(string args)
    {
        foreach (char c in args)
        {
            if (char.IsLower(c))
                return true;
        }

        return false;
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
