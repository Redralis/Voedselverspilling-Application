using System.ComponentModel.DataAnnotations;

namespace Domain;

public class MealBox
{
    [Required(ErrorMessage = "Id moet aangegeven worden.")]
    public int Id { get; set; }
    
    [StringLength(50, ErrorMessage = "Naam mag niet langer dan 50 tekens zijn.")]
    [Required(ErrorMessage = "De naam moet een waarde bevatten.")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Stad moet aangegeven worden.")]
    public string City { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Ophaaldatum- en tijd moet een datum bevatten.")]
    public DateTime PickUpTime { get; set; }
    
    [Required(ErrorMessage = "Uiterste ophaaldatum- en tijd moet een datum bevatten.")]
    public DateTime PickUpBy { get; set; }
    
    [Required(ErrorMessage = "Er moet aangegeven worden of de maaltijd 18+ is.")]
    public bool IsEighteen { get; set; }
    
    [Required(ErrorMessage = "De prijs moet een waarde bevatten.")]
    [Range(4.99, 100.01,
        ErrorMessage = "De prijs moet tussen € 4.99 en € 100.01 liggen.")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Er moet aangegeven worden of het een warme maaltijd wordt.")]
    public bool IsWarmMeal { get; set; }

    [Required(ErrorMessage = "Type maaltijd moet aangegeven worden.")]
    public string MealType { get; set; } = string.Empty;

    public int? StudentId { get; set; }

    public ICollection<Product>? Products { get; set; }

    public Canteen? Canteen { get; set; }
    
    public int CanteenId { get; set; }
    
}