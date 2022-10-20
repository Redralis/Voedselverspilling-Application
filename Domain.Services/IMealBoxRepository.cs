namespace Domain.Services;

public interface IMealBoxRepository
{
    public void CreateMealBox(MealBox? mealBox);
    
    public MealBox? GetMealBox(int id);

    public void EditMealBox(MealBox mealBox);

    public void DeleteMealBox(MealBox mealBox);

    public List<MealBox> GetAvailableMealBoxes();

    public string ReserveMealBox(int mealBoxId, string email);

}