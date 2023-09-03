using System.ComponentModel.DataAnnotations;

namespace Unitagram.Application.Models.Identity.Register;

public record RegisterRequest
{
    public string Email { get; init; } = string.Empty;
    public string UserName { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string ConfirmPassword { get; init; } = string.Empty;
}