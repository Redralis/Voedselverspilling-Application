using System.Data;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class MealBoxRepository : IMealBoxRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IStudentRepository _studentRepository;

    public MealBoxRepository(ApplicationDbContext context, IStudentRepository studentRepository)
    {
        _context = context;
        _studentRepository = studentRepository;
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
        return _context.MealBox.Include(m => m.MealBox_Product).ThenInclude(product => product.product).ToList()
            .Where(m => m.StudentId == null).OrderBy(m => m.PickUpTime).ToList();
    }

    public string ReserveMealBox(int mealBoxId, string email)
    {
        var mealBox = GetMealBox(mealBoxId);
        var student = _studentRepository.GetStudent(email);
        if (mealBox.IsEighteen)
        {
            if (Convert.ToDateTime(student!.DateOfBirth) > DateTime.Now.AddYears(-18))
            {
                return "Student is te jong voor deze maaltijdbox!";
            }
        }
        mealBox!.StudentId = student!.Id;
        _context.MealBox.Update(mealBox);
        _context.SaveChanges();
        return "Maaltijdbox gereserveerd!";
    }
}