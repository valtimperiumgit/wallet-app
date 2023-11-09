using WalletApp.Application.Services;
using WalletApp.Contracts.Users;
using WalletApp.Domain.Enums;

namespace WalletApp.Infrastructure.Services;

public class CardService : ICardService
{
    private readonly ITransactionsService _transactionsService;
    
    private const decimal CardLimit = 1500;

    public CardService(ITransactionsService transactionsService)
    {
        _transactionsService = transactionsService;
    }

    public async Task<BalanceResponse> CalculateBalance(Guid userId)
    {
        var userTransactions = await _transactionsService.GetTransactions(userId);
        
        var losses = userTransactions
            .Where(transaction => transaction.Type == TransactionType.Credit)
            .Sum(transaction => transaction.Amount);

        var profit = userTransactions
            .Where(transaction => transaction.Type == TransactionType.Payment)
            .Sum(transaction => transaction.Amount);

        var balance = profit - losses;
        
        return new BalanceResponse
        {
            Balance = balance,
            Available = CardLimit - balance
        };
    }
}