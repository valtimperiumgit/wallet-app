using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace WalletApp.Api.Abstractions;

public abstract class ApiController : ControllerBase
{
    protected Guid GetUserIdFromToken()
    {
        string userIdClaimType = "userId";
        ClaimsPrincipal currentUser = User;

        return Guid.Parse(currentUser.Claims.FirstOrDefault(claim => claim.Type == userIdClaimType)?.Value!);
    }
}