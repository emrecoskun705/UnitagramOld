using Unitagram.Domain.Common;

namespace Unitagram.Domain;

public class UniversityUser : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid UniversityId { get; set; }
}