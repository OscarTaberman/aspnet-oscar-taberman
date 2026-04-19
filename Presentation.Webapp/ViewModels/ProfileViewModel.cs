using System.ComponentModel.DataAnnotations;

namespace Presentation.Webapp.ViewModels;

public sealed class ProfileViewModel
{
    [Display(Name = "First Name", Prompt = "Enter First Name")]
    [Required(ErrorMessage = "First Name is required.")]
    public string? FirstName { get; set; } = null!;

    [Display(Name = "Last Name", Prompt = "Enter Last Name")]
    [Required(ErrorMessage = "Last Name is required.")]
    public string? LastName { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [Display(Name = "Email Address", Prompt = "Enter Email Address")]
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; } = null!;

    [Phone(ErrorMessage = "Invalid phone number.")]
    [Display(Name = "Phone Number", Prompt = "Enter Phone Number")]
    public string? PhoneNumber { get; set; } = null!;

    [Display(Name = "Profile Picture")]
    public IFormFile? ProfileImageUrl { get; set; }

    public string? ExistingProfileImageUrl { get; set; }
}
