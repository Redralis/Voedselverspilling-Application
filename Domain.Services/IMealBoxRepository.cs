namespace Domain.Services;

public interface IMealBoxRepository
{
    public MealBox CreateMealBox(MealBox mealBox);
    
    public MealBox GetMealBox(int id);

    public MealBox EditMealBox(MealBox mealBox);

    public MealBox DeleteMealBox(int id);

}