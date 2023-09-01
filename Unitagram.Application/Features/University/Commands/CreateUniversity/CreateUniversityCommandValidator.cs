using FluentValidation;

namespace Unitagram.Application.Features.University.Commands.CreateUniversity;

public class CreateUniversityCommandValidator : AbstractValidator<CreateUniversityCommand>
{
    public CreateUniversityCommandValidator()
    {
        RuleFor(p => p.Domain)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must be less than 50 characters");
        
        RuleFor(p =>p.Province)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must be less than 50 characters");
        
        RuleFor(p =>p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must be less than 50 characters");
    }
}