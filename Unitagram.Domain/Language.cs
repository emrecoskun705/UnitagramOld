using Unitagram.Domain.Common;

namespace Unitagram.Domain;

public class Language : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    
    public ICollection<LanguageResource>? LanguageResources { get; set; }
}