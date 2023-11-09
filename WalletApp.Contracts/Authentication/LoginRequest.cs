using System.ComponentModel.DataAnnotations;

namespace WalletApp.Contracts.Authentication;

public class LoginRequest
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(50, ErrorMessage = "Password length should be between 5 and 50.", MinimumLength = 5)]
    public string Password { get; set; }
}