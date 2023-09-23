using FluentValidation;
using Unitagram.Application.Contracts.Localization;

namespace Unitagram.Application.Models.Identity.Jwt;

public class RefreshRequestValidator : AbstractValidator<RefreshRequest>
{
    public RefreshRequestValidator(ILocalizationService localization)
    {
        RuleFor(a => a.Token)
            .NotEmpty().WithMessage(localization["TokenNotEmpty"])
            .NotNull();
        
        RuleFor(a => a.RefreshToken)
            .NotEmpty().WithMessage(localization["TokenNotEmpty"])
            .NotNull();
    }
}