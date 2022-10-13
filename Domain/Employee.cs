namespace Domain;

public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string EmployeeNr { get; set; } = string.Empty;
    
    public Canteen Canteen { get; set; } = null!;
    public int CanteenId { get; set; }

}