using Microsoft.EntityFrameworkCore;
using WalletApp.Application.Repositories;
using WalletApp.Domain.Core.Abstractions;
using WalletApp.Persistence.DBContext;
using Transaction = WalletApp.Domain.Entities.TransactionNamespace.Transaction;

namespace WalletApp.Persistence.Repositories;

public class TransactionsRepository : GenericRepository<Transaction>, ITransactionsRepository
{
    public TransactionsRepository(WalletAppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int> CountUserTransactions(Guid userId)
    {
        return await DbContext.Transactions
            .Where(transaction => transaction.UserId == userId)
            .CountAsync();
    }

    public async Task<List<Transaction>> GetTransactions(
        Guid userId,
        PaginationAndOrdering paginationAndOrdering)
    {
        var query = GetQueryByOrdering(nameof(Transaction.CreatedAt), paginationAndOrdering.Ascending);

        var transactions = await query
            .Where(transaction => transaction.UserId == userId)
            .Skip((paginationAndOrdering.PageNumber - 1) * paginationAndOrdering.PageSize)
            .Take(paginationAndOrdering.PageSize)
            .ToListAsync();

        return transactions;
    }
    
    private IQueryable<Transaction> GetQueryByOrdering(string orderBy, bool ascending)
    {
        var query = DbContext.Transactions
            .Include(transaction => transaction.User)
            .Include(transaction => transaction.AuthorizedUser)
            .AsQueryable();

        query = ascending ? 
            query.OrderBy(x => EF.Property<object>(x, orderBy))
            : query.OrderByDescending(x => EF.Property<object>(x, orderBy));

        return query;
    }

    public async Task<List<Transaction>> GetTransactions(Guid userId)
    {
        return await DbContext.Transactions.Where(transaction => transaction.UserId == userId).ToListAsync();
    }

    public async Task<Transaction?> GetTransactionDetails(Guid transactionId)
    {
        return await DbContext.Transactions
                .Include(transaction => transaction.User)
                .Include(transaction => transaction.AuthorizedUser)
                .FirstOrDefaultAsync(transaction => transaction.Id == transactionId);
    }
}