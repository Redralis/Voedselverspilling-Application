using System.ComponentModel;

namespace Domain;

public class MealBox
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;
    
    public DateTime PickUpTime { get; set; }
    
    public DateTime PickUpBy { get; set; }
    
    public bool IsEighteen { get; set; }
    
    public decimal Price { get; set; }

    public string MealType { get; set; } = string.Empty;
    
    public Student? ReservedBy { get; set; }

    public List<Product> Products { get; set; } = new List<Product>();

    public Canteen Canteen { get; set; } = new Canteen();
    
}