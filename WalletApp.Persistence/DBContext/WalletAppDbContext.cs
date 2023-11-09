using Microsoft.EntityFrameworkCore;
using WalletApp.Domain.Entities.TransactionNamespace;
using WalletApp.Domain.Entities.UserNamespace;
using WalletApp.Domain.Enums;

namespace WalletApp.Persistence.DBContext;

public class WalletAppDbContext : DbContext
{
    public WalletAppDbContext(DbContextOptions<WalletAppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.Transactions)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);
        
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.AuthorizedUser)
            .WithMany()
            .HasForeignKey(t => t.AuthorizedUserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        SeedUsers(modelBuilder);
        SeedTransactions(modelBuilder);
    }
    
    private void SeedUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            (
                Guid.Parse("addc6bbe-85ee-4a4e-b3da-22789b650527"),
                "Test",
                "55fbbb9de6c380e13013f7f7621cfafdc939fe87c1b0af1cc425aa18f3744dec",
                "test@gmail.com"
            ),
            new User
            (
                Guid.Parse("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"),
                "Friend",
                "55fbbb9de6c380e13013f7f7621cfafdc939fe87c1b0af1cc425aa18f3744dec",
                "friend@gmail.com"
            )
        );
    }

    private void SeedTransactions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().HasData(
            new Transaction
            {
                Id = Guid.Parse("a2c8222f-e19d-401e-94df-f9ddeae2fd24"),
                Amount = 500m,
                Name = "ATM Los Angeles",
                Description = "From ATM Los Angeles",
                CreatedAt = new DateTime(2023, 10, 9, 4, 2, 3, DateTimeKind.Utc),
                IconUrl = "https://cdn-icons-png.flaticon.com/512/6059/6059866.png",
                IsPending = false,
                AuthorizedUserId = Guid.Parse("addc6bbe-85ee-4a4e-b3da-22789b650527"),
                UserId = Guid.Parse("addc6bbe-85ee-4a4e-b3da-22789b650527"),
                Type = TransactionType.Payment
            },
            new Transaction
            {
                Id = Guid.Parse("ba8ac6fc-e17d-4616-9fd7-e42caadcd3cf"),
                Amount = 21.61m,
                Name = "IKEA",
                Description = "Round Rock, Tc",
                CreatedAt = new DateTime(2023, 11, 9, 1, 2, 3, DateTimeKind.Utc),
                IconUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThmMLqHvT1CtfTxVLZB3Uhg3GyH7loVRDQFg&usqp=CAU",
                IsPending = false,
                AuthorizedUserId = Guid.Parse("addc6bbe-85ee-4a4e-b3da-22789b650527"),
                UserId = Guid.Parse("addc6bbe-85ee-4a4e-b3da-22789b650527"),
                Type = TransactionType.Credit
            },
            new Transaction
            {
                Id = Guid.Parse("b40f6bfa-5bca-43ba-92e0-75a003c90b19"),
                Amount = 43.61m,
                Name = "Apple",
                Description = "Card Number Used",
                CreatedAt = new DateTime(2023, 11, 9, 4, 5, 6, DateTimeKind.Utc),
                IconUrl = "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png?202103091141",
                IsPending = false,
                AuthorizedUserId = Guid.Parse("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"),
                UserId = Guid.Parse("addc6bbe-85ee-4a4e-b3da-22789b650527"),
                Type = TransactionType.Credit
            },
            new Transaction
            {
                Id = Guid.Parse("fe0f415c-064f-4591-b45d-328380bfa076"),
                Amount = 1000m,
                Name = "Payment",
                Description = "Some payment",
                CreatedAt = new DateTime(2023, 11, 9, 8, 7, 6, DateTimeKind.Utc),
                IconUrl = "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png?202103091141",
                IsPending = false,
                AuthorizedUserId = Guid.Parse("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"),
                UserId = Guid.Parse("d756c4f4-9b03-4a24-af9a-f6cfd431d6ae"),
                Type = TransactionType.Payment
            }
        );
    }
}