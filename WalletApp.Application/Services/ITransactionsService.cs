using WalletApp.Contracts.Core;
using WalletApp.Contracts.Transactions;
using WalletApp.Contracts.Users;
using WalletApp.Domain.Core.Abstractions;
using WalletApp.Domain.Entities.TransactionNamespace;

namespace WalletApp.Application.Services;

public interface ITransactionsService
{
    public Task<PaginationResponse<TransactionResponse>> GetTransactions(Guid userId, PaginationAndOrdering paginationAndOrdering);
    public Task<List<Transaction>> GetTransactions(Guid userId);
    public Task<TransactionDetailsResponse> GetTransactionDetails(Guid userId, Guid transactionId);
}