using System.ComponentModel.DataAnnotations;

namespace Presentation.Webapp.ViewModels;

public sealed class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
