using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Employee
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global because field will be used in future expansion.
    [Required(ErrorMessage = "Id moet meegegeven worden.")]
    public int Id { get; set; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global because field will be used in future expansion.
    [Required(ErrorMessage = "Naam moet een waarde bevatten.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email moet een waarde bevatten.")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    // ReSharper disable once UnusedAutoPropertyAccessor.Global because field will be used in future expansion.
    [Required(ErrorMessage = "Medewerkernummer moet een waarde bevatten.")]
    public string EmployeeNr { get; set; } = string.Empty;
    
    public Canteen Canteen { get; set; } = null!;
    
    [Required(ErrorMessage = "Kantinenummer moet een waarde bevatten.")]
    public int CanteenId { get; set; }

}