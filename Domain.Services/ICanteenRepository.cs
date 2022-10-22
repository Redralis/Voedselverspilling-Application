namespace Domain.Services;

public interface ICanteenRepository
{
    public void CreateCanteen(Canteen? canteen);
    
    public Canteen? GetCanteen(int id);
    
    public List<Canteen> GetCanteens();

    public void EditCanteen(Canteen canteen);

    public void DeleteCanteen(Canteen canteen);

}