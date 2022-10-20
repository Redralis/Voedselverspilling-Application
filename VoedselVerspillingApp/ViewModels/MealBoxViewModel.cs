using Domain;
using VoedselVerspillingApp.Models;

namespace VoedselVerspillingApp.ViewModels;

public class MealBoxViewModel
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string City { get; set; } = string.Empty;
    
    public DateTime PickUpTime { get; set; }
    
    public DateTime PickUpBy { get; set; }
    
    public bool IsEighteen { get; set; }
    
    public decimal Price { get; set; }

    public string MealType { get; set; } = string.Empty;

    public int? StudentId { get; set; }

    public List<CheckBoxItem>? Products { get; set; }
    
    public List<int> ProductIds { get; set; }

    public Canteen? Canteen { get; set; }
    
    public int CanteenId { get; set; }
    
}