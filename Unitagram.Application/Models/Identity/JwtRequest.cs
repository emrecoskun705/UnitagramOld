namespace Unitagram.Application.Models.Identity;

public class JwtRequest
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; } = string.Empty;
    public IList<string> Roles { get; set; } = new List<string>();
}