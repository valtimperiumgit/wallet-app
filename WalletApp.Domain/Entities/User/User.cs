using WalletApp.Domain.Entities.TransactionNamespace;

namespace WalletApp.Domain.Entities.UserNamespace;

public class User : Entity
{
    public User(Guid id, string name, string password, string email)
    {
        Id = id;
        Name = name;
        Password = password;
        Email = email;
    }

    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public ICollection<Transaction> Transactions { get; set; }
}