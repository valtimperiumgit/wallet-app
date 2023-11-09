using WalletApp.Contracts.Users;

namespace WalletApp.Contracts.Transactions;

public class TransactionDetailsResponse
{
    public TransactionResponse Transaction { get; set; }
    
    public UserResponse CardOwner { get; set; }
    
    public UserResponse AuthorizedUser { get; set; }
}