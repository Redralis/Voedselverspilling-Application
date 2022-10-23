using Microsoft.AspNetCore.Identity;

namespace VoedselVerspillingApi.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}