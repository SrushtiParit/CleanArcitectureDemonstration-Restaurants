
namespace Restaurants.Application.Users;
public record CurrentUser(string ID, string Email, IEnumerable<string> Roles)
{
    public bool IsInRole(string role) => Roles.Contains(role);
}
