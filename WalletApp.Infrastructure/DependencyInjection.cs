using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WalletApp.Application.Abstractions.Authentication;
using WalletApp.Application.Core.Cryptography;
using WalletApp.Application.Services;
using WalletApp.Infrastructure.Authentication;
using WalletApp.Infrastructure.Authentication.Settings;
using WalletApp.Infrastructure.Cryptography;
using WalletApp.Infrastructure.Services;

namespace WalletApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]))
            });
        
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));
        
        services.AddScoped<ITransactionsService, TransactionsService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<ICardService, CardService>();
        
        return services;
    }
}