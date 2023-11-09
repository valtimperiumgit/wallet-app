using WalletApp.Domain.Entities.TransactionNamespace;
using WalletApp.Domain.Enums;

namespace WalletApp.Contracts.Transactions;

public sealed class TransactionResponse
{
    public TransactionResponse(Transaction transaction)
    {
        Id = transaction.Id;
        Amount = transaction.Amount;
        Name = transaction.Name;
        Description = transaction.Description;
        CreatedAt = transaction.CreatedAt;
        IconUrl = transaction.IconUrl;
        IsPending = transaction.IsPending;
        Type = transaction.Type;
        UserId = transaction.UserId;
        AuthorizedUserId = transaction.AuthorizedUserId;
    }
    
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid AuthorizedUserId { get; set; }

    public decimal Amount { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public string IconUrl { get; set; }

    public bool IsPending { get; set; }

    public TransactionType Type { get; set; }
}