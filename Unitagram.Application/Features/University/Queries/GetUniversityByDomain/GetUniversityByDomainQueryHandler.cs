using MediatR;
using Unitagram.Application.Contracts.Persistence;
using Unitagram.Application.Exceptions;

namespace Unitagram.Application.Features.University.Queries.GetUniversityByDomain;

public class GetUniversityByDomainQueryHandler : IRequestHandler<GetUniversityByDomainQuery, UniversityByDomainDto>
{
    private readonly IUniversityRepository _universityRepository;
    
    public GetUniversityByDomainQueryHandler(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }
    
    public async Task<UniversityByDomainDto> Handle(GetUniversityByDomainQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var university = await _universityRepository.GetByDomainAsync(request.Domain);
        
        // verify if university exists
        if (university is null)
            throw new NotFoundException(nameof(University), request.Domain);

        return university.ToUniversityByDomainDto();
    }
}