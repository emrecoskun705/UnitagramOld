using Unitagram.Domain.Common;
using Unitagram.Domain.Primitives;

namespace Unitagram.Domain;

public class University : BaseEntity, IAuditableEntity
{
    public Guid UniversityId { get; set; }
    public string Domain { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
}