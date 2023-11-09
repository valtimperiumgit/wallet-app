using WalletApp.Domain.Entities.UserNamespace;

namespace WalletApp.Application.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUserByEmail(string email);

    public Task Insert(User user);
}