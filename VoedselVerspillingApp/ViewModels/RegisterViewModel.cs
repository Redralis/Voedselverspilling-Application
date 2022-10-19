using System.ComponentModel.DataAnnotations;

namespace VoedselVerspillingApp.ViewModels;

public class RegisterViewModel
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Wachtwoord Bevestigen")]
    [Compare("Password",
        ErrorMessage = "Wachtwoorden komen niet overeen.")]
    public string ConfirmPassword { get; set; }

}