using WalletApp.Domain.Entities;
using WalletApp.Persistence.DBContext;

namespace WalletApp.Persistence.Repositories;

public abstract class GenericRepository<TEntity> where TEntity : Entity
{
    protected WalletAppDbContext DbContext { get; }

    protected GenericRepository(WalletAppDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task Insert(TEntity entity)
    {
        await DbContext.Set<TEntity>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
    }
}