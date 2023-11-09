using WalletApp.Contracts.Transactions;
using WalletApp.Domain.Core.Abstractions;
using WalletApp.Domain.Entities.TransactionNamespace;

namespace WalletApp.Application.Repositories;

public interface ITransactionsRepository
{
    public Task<int> CountUserTransactions(Guid userId);
    public Task<List<Transaction>> GetTransactions(Guid userId, PaginationAndOrdering paginationAndOrdering);
    public Task<List<Transaction>> GetTransactions(Guid userId);
    public Task<Transaction?> GetTransactionDetails(Guid transactionId);
}