using MediatR;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Application.Exceptions;

namespace Unitagram.Application.Features.University.Commands.CreateUniversity;

public class CreateUniversityCommandHandler : IRequestHandler<CreateUniversityCommand, Unit>
{
    private readonly IUniversityRepository _universityRepository;

    public CreateUniversityCommandHandler(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }
    
    public async Task<Unit> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateUniversityCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);

        await _universityRepository.CreateAsync(request.ToUniversity());

        return Unit.Value;
    }
}