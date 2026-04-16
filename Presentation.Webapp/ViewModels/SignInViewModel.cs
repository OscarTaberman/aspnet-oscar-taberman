using System.ComponentModel.DataAnnotations;

namespace Presentation.Webapp.ViewModels;

public sealed class SignInViewModel
{
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [Display(Name = "Email Address", Prompt = "Enter Email Address")]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password, ErrorMessage = "Invalid password.")]
    [Display(Name = "Password", Prompt = "Enter Password")]
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = null!;
}
