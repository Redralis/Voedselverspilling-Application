namespace Domain;

public class Canteen
{
    public int Id { get; set; }

    public string City { get; set; } = string.Empty;
    
    public string Address { get; set; } = string.Empty;
    
    public bool ServesWarmMeals { get; set; }
}