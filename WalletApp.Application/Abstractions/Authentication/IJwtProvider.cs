using System.Security.Claims;

namespace WalletApp.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    public string Create(Claim[] claims);
}