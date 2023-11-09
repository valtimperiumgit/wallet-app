using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WalletApp.Application.Repositories;
using WalletApp.Persistence.DBContext;
using WalletApp.Persistence.Repositories;

namespace WalletApp.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WalletAppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("WalletAppDb")));
        
        services.AddScoped<ITransactionsRepository, TransactionsRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}