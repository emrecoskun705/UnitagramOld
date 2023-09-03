namespace Unitagram.Application.Models.Identity.Jwt;

public class JwtRequest
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public IList<string> Roles { get; set; } = new List<string>();
}