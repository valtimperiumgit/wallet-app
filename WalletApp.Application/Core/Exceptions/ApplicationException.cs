namespace WalletApp.Application.Core.Exceptions;

public class ApplicationException : Exception
{
    public int StatusCode { get; set; }
    
    public ApplicationException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}