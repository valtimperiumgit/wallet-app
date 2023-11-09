using System.Security.Cryptography;
using System.Text;
using WalletApp.Application.Core.Cryptography;

namespace WalletApp.Infrastructure.Cryptography;

public sealed class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = sha256.ComputeHash(bytes);

        StringBuilder builder = new StringBuilder();
            
        foreach (var hashByte in hash)
        {
            builder.Append(hashByte.ToString("x2"));
        }

        return builder.ToString();
    }
}