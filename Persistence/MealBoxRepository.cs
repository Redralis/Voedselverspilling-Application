using Domain;
using Domain.Services;

namespace Persistence;

public class MealBoxRepository : IMealBoxRepository
{
    private readonly ApplicationDbContext _context;

    public MealBoxRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void CreateMealBox(MealBox? mealBox)
    {
        if (mealBox != null) _context.MealBox.Add(mealBox);
        _context.SaveChanges();
    }

    public MealBox? GetMealBox(int id)
    {
        return _context.MealBox.Find(id);
    }

    public void EditMealBox(MealBox mealBox)
    {
        _context.MealBox.Update(mealBox);
        _context.SaveChanges();
    }

    public void DeleteMealBox(MealBox mealBox)
    {
        _context.MealBox.Remove(mealBox);
        _context.SaveChanges();
    }

    public List<MealBox> GetAvailableMealBoxes()
    {
        return _context.MealBox.ToList().Where(m => m.StudentId == null).ToList();
    }
    
}