using FluentValidation;

namespace Unitagram.Application.Features.University.Commands.CreateUniversity;

public class CreateUniversityCommandValidator : AbstractValidator<CreateUniversityCommand>
{
    public CreateUniversityCommandValidator()
    {
        RuleFor(p => p.Domain)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must be less than 800 characters");
        
        RuleFor(p =>p.Province)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must be less than 800 characters");
        
        RuleFor(p =>p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must be less than 80 characters");
    }
}