namespace Unitagram.Application.Features.University.Queries.GetUniversityByDomain;

public record UniversityByDomainDto
{
    public int Id { get; init; }
    public string Domain { get; init; } = string.Empty;
    public string Province { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public DateTime? DateCreated { get; init; }
    public DateTime? DateModified { get; init; }
}

public static class UniversityByDomainDtoExtensions
{
    public static UniversityByDomainDto ToUniversityByDomainDto(this Domain.University university)
    {
        return new UniversityByDomainDto()
        {
            Id = university.Id,
            Domain = university.Domain,
            Province = university.Province,
            Name = university.Name,
            DateCreated = university.DateCreated,
            DateModified = university.DateModified,
        };
    }
}