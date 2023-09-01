namespace Unitagram.Application.Features.University.Queries.GetUniversityByDomain;

public class UniversityByDomainDto
{
    public int Id { get; set; }
    public string Domain { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
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