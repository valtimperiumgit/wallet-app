namespace WalletApp.Contracts.Users;

public class BalanceResponse
{
    public decimal Balance { get; set; }
    
    public decimal Available { get; set; }
}