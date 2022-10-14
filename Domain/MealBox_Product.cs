namespace Domain;

public class MealBox_Product
{
    public int Id { get; set; }
    
    public int MealBoxId { get; set; }
    
    public MealBox mealBox { get; set; }
    
    public int ProductId { get; set; }
    
    public Product product { get; set; }
}