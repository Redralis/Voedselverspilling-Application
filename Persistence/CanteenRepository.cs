using Domain;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class CanteenRepository : ICanteenRepository
{
    private readonly ApplicationDbContext _context;

    public CanteenRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void CreateCanteen(Canteen? canteen)
    {
        _context.Canteen.Add(canteen);
        _context.SaveChanges();
    }

    public Canteen? GetCanteen(int id)
    {
        return _context.Canteen.Find(id);
    }

    public void EditCanteen(Canteen canteen)
    {
        _context.Canteen.Update(canteen);
        _context.SaveChanges();
    }

    public void DeleteCanteen(Canteen canteen)
    {
        _context.Canteen.Remove(canteen);
        _context.SaveChanges();
    }
    
}