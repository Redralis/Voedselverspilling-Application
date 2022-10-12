namespace Domain.Services;

public interface ICanteenRepository
{
    public Canteen CreateCanteen(Canteen canteen);
    
    public Canteen GetCanteen(int id);

    public Canteen EditCanteen(Canteen canteen);

    public Canteen DeleteCanteen(int id);

}