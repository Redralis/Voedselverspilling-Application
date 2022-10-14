namespace Domain;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public bool IsAlcoholic { get; set; }

    public string Photo { get; set; } = string.Empty;
    
    public ICollection<MealBox_Product> MealBox_Product { get; set; }
}