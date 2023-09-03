using FluentValidation;

namespace Unitagram.Application.Models.Identity.Jwt;

public class RefreshRequestValidator : AbstractValidator<RefreshRequest>
{
    public RefreshRequestValidator()
    {
        RuleFor(a => a.Token)
            .NotEmpty().WithMessage("{PropertyName} can't be empty")
            .NotNull();
        
        RuleFor(a => a.RefreshToken)
            .NotEmpty().WithMessage("{PropertyName} can't be empty")
            .NotNull();
    }
}