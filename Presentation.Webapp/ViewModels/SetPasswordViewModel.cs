using System.ComponentModel.DataAnnotations;

namespace Presentation.Webapp.ViewModels;

public sealed class SetPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}
