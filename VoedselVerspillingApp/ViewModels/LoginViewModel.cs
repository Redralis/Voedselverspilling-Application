using System.ComponentModel.DataAnnotations;

namespace VoedselVerspillingApp.ViewModels;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Mij onthouden")]
    public bool RememberMe { get; set; }
}