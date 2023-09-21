using FluentValidation;
using Unitagram.Application.Contracts.Localization;

namespace Unitagram.Application.Models.Identity.Authentication;

public class AuthRequestValidator : AbstractValidator<AuthRequest>
{
    public AuthRequestValidator(ILocalizationService localization)
    {
        RuleFor(a => a.UserName)
            .NotEmpty().WithMessage(localization["UsernameShouldntEmpty"])
            .NotNull()
            .MaximumLength(100).WithMessage(localization["UsernameMaxChar"]);

        RuleFor(a => a.Password)
            .NotEmpty().WithMessage(localization["PasswordShouldntEmpty"])
            .NotNull()
            .MaximumLength(50).WithMessage(localization["PasswordMaxChar"]);;
    }
    
}