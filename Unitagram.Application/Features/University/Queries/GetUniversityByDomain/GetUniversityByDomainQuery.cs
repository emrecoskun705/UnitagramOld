using MediatR;

namespace Unitagram.Application.Features.University.Queries.GetUniversityByDomain;

public record GetUniversityByDomainQuery(string Domain) : IRequest<UniversityByDomainDto>;