using System.Security.Claims;
using WalletApp.Domain.Entities.UserNamespace;

namespace WalletApp.Application.Abstractions.Authentication;

public static class AuthenticationClaims
{
    public static Claim[] ForUser(User user)
    {
        return new Claim[]
        {
            new("userId", user.Id.ToString()),
            new("email", user.Email),
            new(ClaimTypes.Role, "User")
        };
    }
}