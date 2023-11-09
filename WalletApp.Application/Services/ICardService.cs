using WalletApp.Contracts.Users;

namespace WalletApp.Application.Services;

public interface ICardService
{
    public Task<BalanceResponse> CalculateBalance(Guid userId);
}