using Microsoft.AspNetCore.Http;

namespace WalletApp.Application.Core.Exceptions;

public static class ApplicationExceptions
{
    public class User
    {
        public static readonly ApplicationException UserAlreadyExist = new
            (StatusCodes.Status400BadRequest, "The user with specified email already exist.");
    }
    
    public static class Authentication
    {
        public static readonly ApplicationException InvalidEmailOrPassword = new
            (StatusCodes.Status400BadRequest, "The specified email or password are incorrect.");
    }
    
    public static class Transaction
    {
        public static readonly ApplicationException TransactionNotFound = new
            (StatusCodes.Status404NotFound, "The transaction with specified Id not found.");
    }
}