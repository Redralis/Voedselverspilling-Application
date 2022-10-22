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
        return _context.MealBox.Include(m => m.MealBox_Product)!.ThenInclude(product => product.product)
            .First(m => m.Id == id);
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

    public List<MealBox> GetMealBoxes()
    {
        return _context.MealBox.Include(m => m.MealBox_Product)!.ThenInclude(product => product.product).ToList()
            .OrderBy(m => m.PickUpTime).ToList();
    }

    public List<MealBox> GetAvailableMealBoxes()
    {
        return _context.MealBox.Include(m => m.MealBox_Product).ThenInclude(product => product.product).ToList()
            .Where(m => m.StudentId == null).OrderBy(m => m.PickUpTime).ToList();
    }

    public List<MealBox> GetReservedMealBoxes(int id)
    {
        return _context.MealBox.Include(m => m.MealBox_Product).ThenInclude(product => product.product).ToList()
            .Where(m => m.StudentId == id).OrderBy(m => m.PickUpTime).ToList();
    }

    public string ReserveMealBox(int mealBoxId, string email)
    {
        var mealBox = GetMealBox(mealBoxId);
        var student = _studentRepository.GetStudentByEmail(email);
        if (mealBox!.StudentId != null) return "Maaltijdbox is al gereserveerd!";
        if (mealBox.IsEighteen)
        {
            if (Convert.ToDateTime(student!.DateOfBirth) > mealBox.PickUpTime.AddYears(-18))
            {
                return "Student is te jong voor deze maaltijdbox!";
            }
        }
        var box = _context.MealBox.FirstOrDefault(m => m.PickUpTime.Day == mealBox.PickUpTime.Day && m.StudentId == student.Id);
        if (box != null)
        {
            return "Student heeft al een maaltijdbox gereserveerd op deze dag!";
        }
        mealBox!.StudentId = student!.Id;
        _context.MealBox.Update(mealBox);
        _context.SaveChanges();
        return "Maaltijdbox gereserveerd!";
    }
    
    public string CancelReservationForMealBox(int mealBoxId)
    {
        var mealBox = GetMealBox(mealBoxId);
        mealBox!.StudentId = null;
        _context.MealBox.Update(mealBox);
        _context.SaveChanges();
        return "Reservatie geannuleerd!";
    }

    public void RemoveProductsFromMealBox(int mealBoxId)
    {
        var list = _context.MealBoxProduct.Where(m => m.MealBoxId == mealBoxId);
        foreach (var p in list)
        {
            _context.MealBoxProduct.Remove(p);
        }
        _context.SaveChanges();
    }
}