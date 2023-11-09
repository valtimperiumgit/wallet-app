using Microsoft.EntityFrameworkCore;
using WalletApp.Application.Repositories;
using WalletApp.Domain.Entities.UserNamespace;
using WalletApp.Persistence.DBContext;

namespace WalletApp.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(WalletAppDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        return await DbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }
}