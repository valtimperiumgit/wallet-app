using WalletApp.Domain.Entities.UserNamespace;
using WalletApp.Domain.Enums;

namespace WalletApp.Domain.Entities.TransactionNamespace;

public class Transaction : Entity
{
    public decimal Amount { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public string IconUrl { get; set; }
    
    public bool IsPending { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid AuthorizedUserId { get; set; }

    public TransactionType Type { get; set; }
    
    public User User { get; set; }
    public User AuthorizedUser { get; set; }
}