using System.ComponentModel.DataAnnotations;

namespace Presentation.Webapp.ViewModels;

public sealed class RegisterViewModel
{
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [Display(Name = "Email Address", Prompt = "Enter Email Address")]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = null!;
}
