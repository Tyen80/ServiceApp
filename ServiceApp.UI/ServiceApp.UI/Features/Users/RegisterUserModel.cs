using System.ComponentModel.DataAnnotations;

namespace ServiceApp.UI.Features.Users;

public class RegisterUserModel
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    [Compare("Password", ErrorMessage = "Password does not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
