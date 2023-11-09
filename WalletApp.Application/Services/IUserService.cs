using WalletApp.Contracts.Users;
using WalletApp.Domain.Entities.UserNamespace;

namespace WalletApp.Application.Services;

public interface IUserService
{
    public Task<User?> GetUserByEmail(string email);
    public Task CreateUser(User user);
    public double CalculateDailyPoints();
}