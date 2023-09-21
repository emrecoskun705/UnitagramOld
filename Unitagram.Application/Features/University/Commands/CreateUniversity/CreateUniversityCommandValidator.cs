using FluentValidation;
using Unitagram.Application.Contracts.Localization;

namespace Unitagram.Application.Features.University.Commands.CreateUniversity;

public class CreateUniversityCommandValidator : AbstractValidator<CreateUniversityCommand>
{
    private readonly ILocalizationService _localizer; 
    
    public CreateUniversityCommandValidator(ILocalizationService localizer)
    {
        _localizer = localizer;
        
        
        
        RuleFor(p => p.Domain)
            .NotEmpty().WithMessage(_localizer.GetLocalizedString("PropertyNameRequired"))
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must be less than 800 characters");
        
        RuleFor(p =>p.Province)
            .NotEmpty().WithMessage(_localizer.GetLocalizedString("PropertyNameRequired"))
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must be less than 800 characters");
        
        RuleFor(p =>p.Name)
            .NotEmpty().WithMessage(_localizer.GetLocalizedString("PropertyNameRequired"))
            .NotNull()
            .MaximumLength(80).WithMessage("{PropertyName} must be less than 80 characters");
    }
}