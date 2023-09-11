using Unitagram.Domain.Common;

namespace Unitagram.Domain;

public class OtpConfirmation : BaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public int RetryCount { get; set; }
    public DateTimeOffset? RetryDateTimeUtc { get; set; }
}