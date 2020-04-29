using System.Security.Claims;

namespace PaySharp.API.Services.Contracts
{
    public interface ITokenManager
    {
        string GenerateToken(string username, string role, string userId);

        ClaimsPrincipal GetPrincipal(string token);
    }
}
