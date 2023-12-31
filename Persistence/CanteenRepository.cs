﻿using Domain;
using Domain.Services;

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
        if (canteen != null) _context.Canteen.Add(canteen);
        _context.SaveChanges();
    }

    public Canteen? GetCanteen(int id)
    {
        return _context.Canteen.Find(id);
    }

    public List<Canteen> GetCanteens()
    {
        return _context.Canteen.ToList();
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