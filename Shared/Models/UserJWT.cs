using System.Security.Claims;

namespace Shared.Models;

public class UserJwt(User user) : ClaimsIdentity(new List<Claim>
{
    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    new Claim(ClaimTypes.Role, user.Role.ToString())
})
{
    public int Id { get; init; } = user.Id;
    public Role Role { get; init; } = user.Role;
}