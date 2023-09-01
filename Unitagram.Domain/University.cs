using Unitagram.Domain.Common;

namespace Unitagram.Domain;

public class University : BaseEntity
{
    public string Domain { get; set; } = string.Empty;
    
    public string Province { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    
}