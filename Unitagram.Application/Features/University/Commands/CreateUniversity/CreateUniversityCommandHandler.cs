using MediatR;
using Unitagram.Application.Contracts.Localization;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Application.Exceptions;

namespace Unitagram.Application.Features.University.Commands.CreateUniversity;

public class CreateUniversityCommandHandler : IRequestHandler<CreateUniversityCommand, Unit>
{
    private readonly IUniversityRepository _universityRepository;
    private readonly ILocalizationService _localizationService;

    public CreateUniversityCommandHandler(IUniversityRepository universityRepository, ILocalizationService localizationService)
    {
        _universityRepository = universityRepository;
        _localizationService = localizationService;
    }
    
    public async Task<Unit> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateUniversityCommandValidator(_localizationService);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);

        await _universityRepository.CreateAsync(request.ToUniversity());

        return Unit.Value;
    }
}