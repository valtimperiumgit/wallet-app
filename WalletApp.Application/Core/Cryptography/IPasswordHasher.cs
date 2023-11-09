namespace WalletApp.Application.Core.Cryptography;

public interface IPasswordHasher
{
    public string Hash(string password);
}