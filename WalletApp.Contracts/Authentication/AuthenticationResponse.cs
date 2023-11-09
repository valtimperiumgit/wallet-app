using WalletApp.Contracts.Users;

namespace WalletApp.Contracts.Authentication;

public class AuthenticationResponse
{
    public UserResponse User { get; set; }
    
    public string Token { get; set; }
}