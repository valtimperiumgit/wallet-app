using WalletApp.Contracts.Authentication;

namespace WalletApp.Application.Services;

public interface IAuthenticationService
{
    public Task<AuthenticationResponse> Registration(RegistrationRequest request);
    public Task<AuthenticationResponse> Login(LoginRequest request);
}