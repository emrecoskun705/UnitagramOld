using System.ComponentModel.DataAnnotations;
using Unitagram.Core.Domain.Entities;

namespace Unitagram.Core.DTO
{
    public class UniversityDomainDTO
    {
        public int DomainId { get; set; }
        public string Name { get; set; } = string.Empty;


    }

    public static class UniversityDomainDTOExtensions
    {
        public static UniversityDomainDTO ToUniversityDomainDTO(this UniversityDomain universityDomain)
        {
            return new UniversityDomainDTO()
            {
                DomainId = universityDomain.DomainId,
                Name = universityDomain.Name,
            };
        }
    }
}
