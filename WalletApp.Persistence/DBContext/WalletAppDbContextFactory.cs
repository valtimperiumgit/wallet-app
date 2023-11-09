using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WalletApp.Persistence.DBContext;

public class WalletAppDbContextFactory : IDesignTimeDbContextFactory<WalletAppDbContext>
{
    public WalletAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WalletAppDbContext>();
        
        var connectionString = Environment.GetEnvironmentVariable("WALLETAPP_DB_CONNECTION_STRING")
                               ?? "Host=localhost;Port=5499;Database=test;Username=postgres;Password=2121";

        optionsBuilder.UseNpgsql(connectionString);

        return new WalletAppDbContext(optionsBuilder.Options);
    }
}