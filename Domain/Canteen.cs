using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Canteen
{
    [Required(ErrorMessage = "Id moet meegegeven worden.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Stad moet een waarde bevatten.")]
    public string City { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Adres moet een waarde bevatten.")]
    public string Address { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Er moet aangegeven worden of er warme maaltijden geserveerd worden.")]
    public bool ServesWarmMeals { get; set; }
}