using System.ComponentModel.DataAnnotations;

namespace VoedselVerspillingApp.ViewModels;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Mij onthouden")]
    public bool RememberMe { get; set; }
}