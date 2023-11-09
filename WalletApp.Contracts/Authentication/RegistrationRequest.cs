using System.ComponentModel.DataAnnotations;

namespace WalletApp.Contracts.Authentication;

public sealed class RegistrationRequest
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name length should be between 3 and 100.", MinimumLength = 3)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(50, ErrorMessage = "Password length should be between 5 and 50.", MinimumLength = 5)]
    public string Password { get; set; }
}