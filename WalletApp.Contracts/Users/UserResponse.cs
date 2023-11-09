using WalletApp.Domain.Entities.UserNamespace;

namespace WalletApp.Contracts.Users;

public class UserResponse
{
    public UserResponse(User user)
    {
        Name = user.Name;
        Email = user.Email;
    }

    public string Name { get; set; }
    
    public string Email { get; set; }
}