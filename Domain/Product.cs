using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Product
{
    [Required(ErrorMessage = "Id moet meegegeven worden.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Naam moet een waarde bevatten.")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Er moet aangegeven worden of het product alcohol bevat.")]
    public bool IsAlcoholic { get; set; }

    [Required(ErrorMessage = "Er moet een foto URL meegegeven worden.")]
    public string Photo { get; set; } = string.Empty;
    
    public ICollection<MealBox> MealBoxes { get; set; }
}