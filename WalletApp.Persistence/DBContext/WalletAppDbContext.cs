using Microsoft.EntityFrameworkCore;
using WalletApp.Domain.Entities.TransactionNamespace;
using WalletApp.Domain.Entities.UserNamespace;

namespace WalletApp.Persistence.DBContext;

public class WalletAppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseNpgsql("Host=localhost;Port=5499;Database=wallet-app;Username=postgres;Password=2121");
    }
    
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
    }
    
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }
}