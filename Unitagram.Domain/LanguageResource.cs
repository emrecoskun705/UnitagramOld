using Unitagram.Domain.Common;
using Unitagram.Domain.Primitives;

namespace Unitagram.Domain;

public class LanguageResource : BaseEntity, IAuditableEntity
{
    public int Id { get; set; }
    public string Language { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string SourceKey { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string? ModifiedBy { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
}