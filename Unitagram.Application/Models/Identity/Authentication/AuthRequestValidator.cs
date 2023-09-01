using FluentValidation;

namespace Unitagram.Application.Models.Identity.Authentication;

public class AuthRequestValidator : AbstractValidator<AuthRequest>
{
    public AuthRequestValidator()
    {
        RuleFor(a => a.Email)
            .EmailAddress().WithMessage("{PropertyName} is not valid")
            .NotEmpty().WithMessage("{PropertyName} shouldn't be empty")
            .NotNull()
            .MaximumLength(100).WithMessage("{PropertyName} should maximum of 100 characters");

        RuleFor(a => a.Password)
            .NotEmpty().WithMessage("{PropertyName} shouldn't be empty")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} should maximum of 50 characters");;
    }
    
}