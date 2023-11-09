using WalletApp.Application.Core.Exceptions;
using WalletApp.Application.Repositories;
using WalletApp.Application.Services;
using WalletApp.Contracts.Core;
using WalletApp.Contracts.Transactions;
using WalletApp.Contracts.Users;
using WalletApp.Domain.Core.Abstractions;
using WalletApp.Domain.Entities.TransactionNamespace;

namespace WalletApp.Infrastructure.Services;

public class TransactionsService : ITransactionsService
{
    private readonly ITransactionsRepository _transactionsRepository;

    public TransactionsService(ITransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }

    public async Task<PaginationResponse<TransactionResponse>> GetTransactions(
        Guid userId,
        PaginationAndOrdering paginationAndOrdering)
    {
        var transactions = await _transactionsRepository.GetTransactions(userId, paginationAndOrdering);

        return new PaginationResponse<TransactionResponse>
        {
            CurrentPage = paginationAndOrdering.PageNumber,
            PageSize = paginationAndOrdering.PageSize,
            Items = transactions.Select(transaction => new TransactionResponse(transaction)).ToList(),
            TotalItems = await _transactionsRepository.CountUserTransactions(userId)
        };
    }

    public async Task<List<Transaction>> GetTransactions(Guid userId)
    {
        return await _transactionsRepository.GetTransactions(userId);
    }

    public async Task<TransactionDetailsResponse> GetTransactionDetails(Guid userId, Guid transactionId)
    {
        var transaction = await _transactionsRepository.GetTransactionDetails(transactionId);

        if (transaction is null || transaction.UserId != userId)
        {
            throw ApplicationExceptions.Transaction.TransactionNotFound;
        }

        return new TransactionDetailsResponse
        {
            Transaction = new TransactionResponse(transaction),
            CardOwner = new UserResponse(transaction.User),
            AuthorizedUser = new UserResponse(transaction.AuthorizedUser)
        };
    }
}